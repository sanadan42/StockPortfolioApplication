using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioApplication
{
    

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
                    var result = stocks.tblTransactionEquities
                                .Where(e => e.EquityIDFK == equity.ID)
                                .OrderBy(d => d.TransactionDate);
                    return result.ToList();
                }
                else
                {
                    var result = stocks.tblTransactionEquities
                                .Where(a => a.AccountIDFK == account.ID)
                                .Where(e => e.EquityIDFK == equity.ID)
                                .OrderBy(d => d.TransactionDate);
                    return result.ToList();
                }
            }
        }

        private List<tblTransactionEquity> GetTransactionsForEquity(Equity equity, Account account, DateTime date)
        {
            using (var stocks = new StockPortfolioDBEntities())
            {
                if (account.ID == -1)
                {
                    var result = stocks.tblTransactionEquities
                                .Where(e => e.EquityIDFK == equity.ID)
                                .Where(d => d.TransactionDate <= date)
                                .OrderBy(d => d.TransactionDate);
                    return result.ToList();
                }
                else
                {
                    var result = stocks.tblTransactionEquities
                                .Where(a => a.AccountIDFK == account.ID)
                                .Where(e => e.EquityIDFK == equity.ID)
                                .Where(d => d.TransactionDate <= date)
                                .OrderBy(d => d.TransactionDate);
                    return result.ToList();
                }
            }
        }
        #endregion

        private struct EquityValues
        {
            public decimal TotalCost { get; set; }
            public decimal AverageCost { get; set; }
            public decimal RealizedGain { get; set; }
            public decimal Shares { get; set; }
        }

        #region Equity Calculations
        public void EquityCalculations(Equity equity, Account account)
        {
            // pre: 
            // post: equity will be populated with the most difficult aggregate calcs
            //      - ACB (averageCost)
            //      - TotalCost - in absolute dollars in the given currency for the specific equity
            //      - RealizedGain - whenever there is a sale there has to be a profit / loss
            //      - AverageCost - this is the ACB or Average Cost Basis
            
            EquityValues values = new EquityValues();

            var transactions = GetTransactionsForEquity(equity, account);
            ACBCalcs(transactions, ref values);

            equity.Shares = values.Shares;
            equity.TotalCost = values.Shares == 0 ? 0.0m : values.TotalCost; // if there are no shares then I don't want to see the commission of the last trade - set the total cost = 0.0;
            equity.AverageCostBasis = values.AverageCost;
            equity.RealizedGain = values.RealizedGain;
        }

        public decimal ACBDate(Equity equity, Account account, DateTime date)
        {
            // pre: 
            // post: equity will be populated with the most difficult aggregate calcs
            //      - ACB (averageCost)

            EquityValues values = new EquityValues();

            var transactions = GetTransactionsForEquity(equity, account, date);
            ACBCalcs(transactions, ref values);

            return values.AverageCost;
        }

        private void ACBCalcs(List<tblTransactionEquity> transactions, ref EquityValues values)
        {
            if (!(transactions.Count == 0))
            {
                foreach (var t in transactions)
                {
                    decimal priceForCalc;
                    switch (t.TransactionTypeIDFK)
                    {
                        case ((int)EquityTransactionTypes.BuyStock):
                        case ((int)EquityTransactionTypes.DepositStock):
                            priceForCalc = (decimal)t.Price;
                            break;
                        case ((int)EquityTransactionTypes.SellStock):
                        case ((int)EquityTransactionTypes.TransferBuy):
                        case ((int)EquityTransactionTypes.TransferSell):
                            priceForCalc = values.AverageCost;
                            break;
                        default:
                            priceForCalc = 0.0m;
                            break;
                    }

                    if( t.TransactionTypeIDFK == ((int)EquityTransactionTypes.SellStock))
                        // when we are selling stocks t.shares will be negative, so need to multiply by -1. or... could do aveCost - t.Price... same same
                        values.RealizedGain += -1 * (decimal)t.Shares * ((decimal)t.Price - values.AverageCost) - (decimal)t.Commission;
                    values.Shares += (decimal)t.Shares;
                    values.TotalCost += (decimal)t.Shares * priceForCalc + (decimal)t.Commission;
                    values.AverageCost = values.Shares == 0.0m ? 0.0m : values.TotalCost / values.Shares;
                }
            }
        }
        #endregion

        #region Dividend Transactions
        /*
        private List<tblTransactionDividend> GetTransactionsDividends(Equity equity, Account account)
        {
            using (var stocks = new StockPortfolioDBEntities())
            {
                if (account.ID != -1)
                {
                    var result = stocks.tblTransactionDividends
                                .Where(a => a.AccountIDFK == account.ID)
                                .Where(e => e.EquityIDFK == equity.ID)
                                .OrderBy(d => d.DividendDate);
                    
                    return result.ToList();
                }
                else
                {
                    var result = stocks.tblTransactionDividends
                                .Where(e => e.EquityIDFK == equity.ID)
                                .OrderBy(d => d.DividendDate);
                    
                    return result.ToList();
                }
            }
        }
        */
        #endregion

        #region Dividend Calculations
        public decimal DividendCalculations(Equity equity, Account account)
        {
            // pre: 
            // post: sum of dividends
            //
            // possible improvement could be to move this to server side?

            using (var stocks = new StockPortfolioDBEntities())
            {
                if (account.ID != -1)
                {
                    var result = stocks.tblTransactionDividends
                                .Where(a => a.AccountIDFK == account.ID)
                                .Where(e => e.EquityIDFK == equity.ID)
                                .OrderBy(d => d.DividendDate)
                                .Sum(v => v.DividendValue);

                    return result == null ? 0.0m : (decimal)result;
                }
                else
                {
                    var result = stocks.tblTransactionDividends
                                .Where(e => e.EquityIDFK == equity.ID)
                                .OrderBy(d => d.DividendDate)
                                .Sum(v => v.DividendValue);

                    return result == null ? 0.0m : (decimal)result;
                }
            }
        }
        #endregion

    }
}
