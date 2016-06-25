using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioApplication
{
    enum TransactionTypes
    {
        BuyStock = 1,
        SellStock = 2,
        WithdrawalStock = 3,
        DepositStock = 4,
        TransferBuy = 5,
        TransferSell = 6
    }

    public class PortfolioCalculations
    {
        List<StockTransaction> transactionList;
        List<DividendTransaction> dividendTransactionList;

        public void PopulateTransactionList()
        {
            transactionList = GetTransactionsEquities();
            dividendTransactionList = GetTransactionsDividends();
        }

        #region Portfolio management
        public List<Account> GetAccountList()
        {
            // pre: transactionList needs to be populated with a call to PopulationTransactionList()
            // get a list of all unique equities within the transactions list
            using (var stocks = new StockPortfolioDBEntities())
            {
                var result = stocks.tblAccounts
                    .OrderBy(a => a.AccountName)
                    .Select(a => new Account()
                    {
                        ID = a.AccountID,
                        AccountName= a.AccountName,
                        AccountNumber = (int)a.AccountNumber
                    });

                return result.ToList();
            }
        }

        public List<Equity> GetEquityListForAccount(int accountID)
        {
           // pre: transactionList needs to be populated with a call to PopulationTransactionList()
           // get a list of all unique equities within the transactions list
           var result = this.transactionList
               .Where(a => a.AccountID == accountID)
               .GroupBy(e => e.EquityID)
               .Select(g => g.First())
               .Select(e => new Equity()
               {
                   ID = e.EquityID,
                   Ticker = e.StockTicker,
                   Description = e.StockDescription
               })
               .OrderBy(e => e.Ticker);

            List<Equity> resultList = result.ToList();
            List<Equity> allEquities = GetEquityList();
            foreach(Equity e in resultList)
            {
                //e.CurrentPrice = allEquities.Where(eq => eq.ID == e.ID).CurrentPrice;
                Equity eqTemp = allEquities.Find(equity => equity.ID == e.ID);
                e.CurrentPrice = eqTemp.CurrentPrice;
                e.Description = eqTemp.Description;
            }

           return resultList;
       }

        public List<Equity> GetEquityList()
       {
           // pre: transactionList needs to be populated with a call to PopulationTransactionList()
           // get a list of all unique equities within the transactions list
           using (var stocks = new StockPortfolioDBEntities())
           {
               var result = stocks.tblEquities
                   .OrderBy(e => e.StockTicker)
                   .Select(e => new Equity()
                   {
                       ID = e.EquityID,
                       Ticker = e.StockTicker,
                       Description = e.Description,
                       CurrentPrice = (decimal)e.CurrentPrice
                   });

               return result.ToList();
           }
           /*
            * this can be used to retrieve all equities that show up in the transaction list
           var result = this.transactionList
               .GroupBy(e => e.EquityID)
               .Select(g => g.First())
               .Select(e => new Equity()
               {
                   ID = e.EquityID,
                   Ticker = e.StockTicker
               })
               .OrderBy(e => e.Ticker);

           return result.ToList();
           */
        }
        #endregion

        #region Equity Transactions
        private List<StockTransaction> GetTransactionsEquities()
        {
            List<StockTransaction> resultList = new List<StockTransaction>();
            using (var stocks = new StockPortfolioDBEntities())
            {
                var result = from trans in stocks.tblTransactionEquities
                             join tt in stocks.tblTransactionTypes on trans.TransactionTypeIDFK equals tt.TransactionTypeID
                             join equity in stocks.tblEquities on trans.EquityIDFK equals equity.EquityID
                             join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
                             orderby acc.AccountName, equity.StockTicker
                             select new StockTransaction()
                             {
                                 AccountName = acc.AccountName,
                                 StockTicker = equity.StockTicker,
                                 StockDescription = equity.Description,
                                 TransactionType = tt.TransactionType,
                                 TransactionDate = (DateTime)trans.TransactionDate,
                                 Shares = (int)trans.Shares,
                                 Price = (decimal)trans.Price,
                                 Commission = (decimal)trans.Commission,
                                 AccountID = (int)trans.AccountIDFK,
                                 EquityID = (int)trans.EquityIDFK,
                                 TransactionTypeID = (int)trans.TransactionTypeIDFK
                             };

                resultList = result.ToList();
            }
            return resultList;
        }

        private List<StockTransaction> GetTransactionsForAccount(Account account)
        {
            //pre: assumes transactionList has been populated
            //post: list should be sorted from oldest to newest
            var result = this.transactionList
                            .Where(a => a.AccountID == account.ID)
                            .OrderBy(d => d.TransactionDate);
            return result.ToList();
        }

        private List<StockTransaction> GetTransactionsForEquity(Equity equity)
        {
            //pre: assumes transactionList has been populated
            //post: list should be sorted from oldest to newest
            var result = this.transactionList
                            .Where(e => e.EquityID == equity.ID)
                            .OrderBy(d => d.TransactionDate);
            return result.ToList();
        }

        private List<StockTransaction> GetTransactionsForEquity(Equity equity, Account account)
        {
            //pre: assumes transactionList has been populated
            //post: list should be sorted from oldest to newest
            var result = GetTransactionsForEquity(equity)
                            .Where(a => a.AccountID == account.ID)
                            .OrderBy(d => d.TransactionDate);
            return result.ToList();
        }
        #endregion
                
        #region Equity Calculations
        public void EquityCalculations(Equity equity, Account account)
        {
            // pre: transaction list must be populated
            // post: equity will be populated with the most difficult aggregate calcs
            //      - ACB (averageCost)
            //      - TotalCost - in absolute dollars in the given currency for the specific equity
            //      - RealizedGain - whenever there is a sale there has to be a profit / loss
            //      - AverageCost - this is the ACB or Average Cost Basis

            List<StockTransaction> transactions = GetTransactionsForEquity(equity, account);
            EquityCalculations(equity, transactions);
        }

        public void EquityCalculations(Equity equity)
        {
            // pre: transaction list must be populated
            // post: equity will be populated with the most difficult aggregate calcs
            //      - ACB (averageCost)
            //      - TotalCost - in absolute dollars in the given currency for the specific equity
            //      - RealizedGain - whenever there is a sale there has to be a profit / loss
            //      - AverageCost - this is the ACB or Average Cost Basis

            List<StockTransaction> transactions = GetTransactionsForEquity(equity);
            this.EquityCalculations(equity, transactions);
        }

        private void EquityCalculations(Equity equity, List<StockTransaction> transactions)
        {
            decimal totalCost = 0.0m, averageCost = 0.0m, realizedGain = 0.0m;
            int shares = 0;

            if (!(transactions.Count == 0))
            {
                foreach (StockTransaction t in transactions)
                {
                    decimal priceForCalc;
                    switch(t.TransactionTypeID)
                    {
                        case ((int)TransactionTypes.BuyStock):
                            priceForCalc = t.Price;
                            break;
                        case ((int)TransactionTypes.SellStock):
                            priceForCalc = averageCost;
                            realizedGain += -1*t.Shares * (t.Price - averageCost) - t.Commission; // when we are selling stocks t.shares will be negative, so need to multiply by -1. or... could do aveCost - t.Price... same same
                            break;
                        case ((int)TransactionTypes.TransferBuy):
                        case ((int)TransactionTypes.TransferSell):
                            priceForCalc = averageCost;
                            break;
                        default:
                            priceForCalc = 0.0m;
                            break;
                    }

                    //if (t.TransactionTypeID == (int)TransactionTypes.BuyStock || t.TransactionTypeID == (int)TransactionTypes.TransferBuy)
                    //{
                    //    priceForCalc = t.Price;
                    //}
                    //else if (t.TransactionTypeID == (int)TransactionTypes.SellStock || t.TransactionTypeID == (int)TransactionTypes.TransferSell)
                    //{
                    //    priceForCalc = averageCost;
                    //    realizedGain += t.Shares * (t.Price - averageCost) - t.Commission;
                    //}
                    //else
                    //{
                    //    priceForCalc = 0.0m;
                    //}

                    shares += t.Shares;
                    totalCost += t.Shares * priceForCalc + t.Commission;
                    averageCost = shares == 0 ? 0.0m : totalCost / shares;
                }
            }

            equity.Shares = shares;
            equity.TotalCost = shares == 0 ? 0.0m : totalCost; // if there are no shares then I don't want to see the commission of the last trade - set the total cost = 0.0;
            equity.AverageCostBasis = averageCost;
            equity.RealizedGain = realizedGain;
        }
        #endregion

        #region Dividend Transactions
        private List<DividendTransaction> GetTransactionsDividends()
        {
            List<DividendTransaction> resultList = new List<DividendTransaction>();
            using (var stocks = new StockPortfolioDBEntities())
            {
                var result = from trans in stocks.tblTransactionDividends
                             join equity in stocks.tblEquities on trans.EquityIDFK equals equity.EquityID
                             join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
                             orderby acc.AccountName, equity.StockTicker
                             select new DividendTransaction()
                             {
                                 AccountName = acc.AccountName,
                                 StockTicker = equity.StockTicker,
                                 TransactionDate = (DateTime)trans.DividendDate,
                                 Dividend = (decimal)trans.DividendValue,
                                 AccountID = (int)trans.AccountIDFK,
                                 EquityID = (int)trans.EquityIDFK,
                             };
                resultList = result.ToList();
            }

            return resultList;
        }

        private List<DividendTransaction> GetDividendTransactionsForAccount(Account account)
        {
            //pre: assumes transactionList has been populated
            //post: list should be sorted from oldest to newest
            var result = this.dividendTransactionList
                            .Where(a => a.AccountID == account.ID)
                            .OrderBy(d => d.TransactionDate);
            return result.ToList();
        }

        private List<DividendTransaction> GetDividendTransactionsForEquity(Equity equity)
        {
            //pre: assumes transactionList has been populated
            //post: list should be sorted from oldest to newest
            var result = this.dividendTransactionList
                            .Where(e => e.EquityID == equity.ID);
            if(result != null)
                result = result.OrderBy(d => d.TransactionDate);
            return result.ToList();
        }

        private List<DividendTransaction> GetDividendTransactionsForEquity(Equity equity, Account account)
        {
            //pre: assumes transactionList has been populated
            //post: list should be sorted from oldest to newest
            var result = GetDividendTransactionsForEquity(equity);
            if(result != null)
            {
                var result2 = result.Where(a => a.AccountID == account.ID);
                if (result2 != null)
                    result2 = result2.OrderBy(d => d.TransactionDate);
                return result2.ToList();
            }
                            
            return result.ToList();
        }
        #endregion

        #region Dividend Calculations
        public decimal DividendCalculations(Equity equity, Account account)
        {
            // pre: transaction list must be populated
            // post: equity will be populated with the most difficult aggregate calcs
            //      - ACB (averageCost)
            //      - TotalCost - in absolute dollars in the given currency for the specific equity
            //      - RealizedGain - whenever there is a sale there has to be a profit / loss
            //      - AverageCost - this is the ACB or Average Cost Basis

            List<DividendTransaction> transactions = GetDividendTransactionsForEquity(equity, account);
            return DividendCalculations(transactions);
        }

        public decimal DividendCalculations(Equity equity)
        {
            // pre: transaction list must be populated
            // post: equity will be populated with the most difficult aggregate calcs

            List<DividendTransaction> transactions = GetDividendTransactionsForEquity(equity);
            return DividendCalculations(transactions);
        }

        private decimal DividendCalculations(List<DividendTransaction> transactions)
        {
            decimal sumDividend;

            // because the list that is being processed has already been filted, there is no need to filter it again.
            //sumDividend = transactions.Where(e => e.EquityID == equity.ID).Sum(d => (decimal)d.Dividend);
            sumDividend = transactions.Sum(d => (decimal)d.Dividend);
            return sumDividend;
        }
        #endregion

    }
}
