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
        public void PopulateTransactionList()
        {
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
            // pre:
            // post: a list of all unique equities within the transactions list for a given account
            //
            // looks at the list of stock transactions and finds the distinct equities for a given account
            if(accountID == -1)
            {
                return GetEquityList();
            }
            else
            {
                using (var stocks = new StockPortfolioDBEntities())
                {
                    var result = (
                                from t in stocks.tblTransactionEquities
                                join e in stocks.tblEquities on t.EquityIDFK equals e.EquityID
                                where t.AccountIDFK == accountID
                                orderby e.StockTicker
                                select new Equity
                                {
                                    ID = e.EquityID,
                                    Ticker = e.StockTicker,
                                    Description = e.Description,
                                    CurrentPrice = (decimal)e.CurrentPrice,
                                    Currency = e.tblStockExchanx.tblCurrency.CurrencyType
                                }).Distinct();

                    return result.ToList();
                }
            }
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
        }
        #endregion

        #region Equity Transactions
        private List<tblTransactionEquity> GetTransactionsForEquity(Equity equity, Account account)
        {
            using (var stocks = new StockPortfolioDBEntities())
            {
                if (account.ID == -1)
                {
                    var result = from trans in stocks.tblTransactionEquities
                                 join tt in stocks.tblTransactionTypes on trans.TransactionTypeIDFK equals tt.TransactionTypeID
                                 join eq in stocks.tblEquities on trans.EquityIDFK equals eq.EquityID
                                 join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
                                 orderby trans.TransactionDate, acc.AccountName, eq.StockTicker
                                 where eq.EquityID == equity.ID
                                 select trans;

                    return result.ToList();
                }
                else
                {

                    var result = from trans in stocks.tblTransactionEquities
                                 join tt in stocks.tblTransactionTypes on trans.TransactionTypeIDFK equals tt.TransactionTypeID
                                 join eq in stocks.tblEquities on trans.EquityIDFK equals eq.EquityID
                                 join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
                                 orderby trans.TransactionDate, acc.AccountName, eq.StockTicker
                                 where acc.AccountID == account.ID
                                 where eq.EquityID == equity.ID
                                 select trans;

                    return result.ToList();
                }
            }
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
            var transactions = GetTransactionsForEquity(equity, account);
            EquityCalculations(equity, transactions);
        }

        private void EquityCalculations(Equity equity, List<tblTransactionEquity> transactions)
        {
            decimal totalCost = 0.0m, averageCost = 0.0m, realizedGain = 0.0m;
            int shares = 0;

            if (!(transactions.Count == 0))
            {
                foreach (tblTransactionEquity t in transactions)
                {
                    decimal priceForCalc;
                    switch(t.TransactionTypeIDFK)
                    {
                        case ((int)TransactionTypes.BuyStock):
                            priceForCalc = (decimal)t.Price;
                            break;
                        case ((int)TransactionTypes.SellStock):
                            priceForCalc = averageCost;
                            realizedGain += -1*(int)t.Shares * ((decimal)t.Price - averageCost) - (decimal)t.Commission; // when we are selling stocks t.shares will be negative, so need to multiply by -1. or... could do aveCost - t.Price... same same
                            break;
                        case ((int)TransactionTypes.TransferBuy):
                        case ((int)TransactionTypes.TransferSell):
                            priceForCalc = averageCost;
                            break;
                        default:
                            priceForCalc = 0.0m;
                            break;
                    }

                    shares += (int)t.Shares;
                    totalCost += (int)t.Shares * priceForCalc + (decimal)t.Commission;
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
        private List<tblTransactionDividend> GetTransactionsDividends(Equity equity, Account account)
        {
            List<tblTransactionDividend> resultList = new List<tblTransactionDividend>();
            using (var stocks = new StockPortfolioDBEntities())
            {
                if (account.ID != -1)
                {
                    var result = from trans in stocks.tblTransactionDividends
                                 join e in stocks.tblEquities on trans.EquityIDFK equals e.EquityID
                                 join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
                                 where trans.AccountIDFK == account.ID
                                 where trans.EquityIDFK == equity.ID
                                 orderby trans.DividendDate, acc.AccountName, e.StockTicker
                                 select trans;
                    resultList = result.ToList();
                }
                else
                {
                    var result = from trans in stocks.tblTransactionDividends
                                 join e in stocks.tblEquities on trans.EquityIDFK equals e.EquityID
                                 join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
                                 where trans.EquityIDFK == equity.ID
                                 orderby trans.DividendDate, acc.AccountName, e.StockTicker
                                 select trans;
                    resultList = result.ToList();
                }
            }

            return resultList;
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

            List<tblTransactionDividend> transactions = GetTransactionsDividends(equity, account);
            return transactions.Sum(d => (decimal)d.DividendValue);
        }
        #endregion

    }
}
