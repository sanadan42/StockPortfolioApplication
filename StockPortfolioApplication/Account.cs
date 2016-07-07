using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioApplication
{
    public class BalanceType
    {
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public int CurrencyID { get; set; }
    }

    public class Account
    {
        // each account will have a list of all equities that it contains
        // the account will also contain a list of balances
        // the different balances will allow each account to have multiple different currencies
        private List<Equity> equities;
        private List<BalanceType> balances;

        private decimal totalEquityCost, totalRealizedGain, totalUnrealizedGain, totalDividendGain, totalPLGain, totalEquityValue;

        public int ID { get; set; }
        public String AccountName { get; set; }
        public int AccountNumber { get; set; }

        public decimal TotalEquityCost { get { return totalEquityCost; } }
        public decimal TotalEquityValue { get { return totalEquityValue; } }
        public decimal TotalRealizedGain { get { return totalRealizedGain; } }
        public decimal TotalUnrealizedGain { get { return totalUnrealizedGain; } }
        public decimal TotalDividendGain { get { return totalDividendGain; } }
        public decimal TotalPLGain { get { return totalPLGain; } }

        public Account()
        {
            this.equities = new List<Equity>();
            this.balances = new List<BalanceType>();
            ClearTotals();
        }

        public List<BalanceType> GetBalances()
        {
            return this.balances;
        }

        public void SetEquities(List<Equity> eList)
        {
            this.equities = eList;
        }

        public List<Equity> GetEquities()
        {
            return this.equities;
        }

        private void ClearTotals()
        {
            this.totalEquityCost = this.totalRealizedGain = this.totalUnrealizedGain = this.totalDividendGain = this.totalPLGain = this.totalEquityValue = 0.0m;
        }

        public void RefreshTotals()
        {
            ClearTotals();
            if (this.equities != null)
            {
                foreach (Equity e in equities)
                {
                    // calculate totals
                    this.totalEquityCost += e.TotalCost;
                    this.totalEquityValue += e.Shares * e.CurrentPrice;
                    this.totalRealizedGain += e.RealizedGain;
                    this.totalUnrealizedGain += e.UnrealizedGain;
                    this.totalDividendGain += e.DividendProfit;
                    this.totalPLGain += e.TotalPL;
                }
            }
        }

        public void CalculateAccountBalances()
        {
            ClearAccountBalances();
            using (var stocks = new StockPortfolioDBEntities())
            {
                var resultEquities = stocks.tblTransactionEquities.
                                        Where(t => t.AccountIDFK == this.ID).
                                        Where(t => t.tblTransactionType.TransactionTypeID != (int)EquityTransactionTypes.TransferBuy).
                                        Where(t => t.tblTransactionType.TransactionTypeID != (int)EquityTransactionTypes.TransferSell).
                                        OrderBy(t => t.TransactionDate);
                foreach (var t in resultEquities)
                {
                    int currencyType = (int)t.tblEquity.tblStockExchanx.tblCurrency.CurrencyID;
                    // check to see if the balance for the given currency exists within the list
                    BalanceType balance = GetBalance(currencyType);
                    balance.Balance -= (decimal)t.Shares * (decimal)t.Price + (decimal)t.Commission;
                }
                
                var resultFinance = stocks.tblTransactionFinances.Where(f => f.AccountIDFK == this.ID).OrderBy(f => f.TransactionDate);
                foreach (var f in resultFinance)
                {
                    int currencyType = (int)f.CurrencyIDFK;
                    BalanceType balance = GetBalance(currencyType);
                    balance.Balance += (decimal)f.Net;
                }

                var resultDividend = stocks.tblTransactionDividends.Where(d => d.AccountIDFK == this.ID).OrderBy(d => d.DividendDate);
                foreach (var d in resultDividend)
                {
                    int currencyType = (int)d.tblEquity.tblStockExchanx.tblCurrency.CurrencyID;
                    BalanceType balance = GetBalance(currencyType);
                    balance.Balance += (decimal)d.DividendValue;
                }
            }
        }

        private BalanceType GetBalance(int currency)
        {
            // check to see if the currency type already exists, and if not then add it
            if (this.balances.Exists(b => b.CurrencyID == currency))
            {
                return this.balances.Find(b => b.CurrencyID == currency);
            }
            else
            {
                return AddBalance(currency);
            }
        }

        private BalanceType AddBalance(int currency)
        {
            BalanceType b = new BalanceType();
            b.CurrencyID = currency;
            b.Balance = 0;
            using (var db = new StockPortfolioDBEntities())
            {
                b.Currency = (string)db.tblCurrencies.First(c => c.CurrencyID == currency).CurrencyType;
            }
            this.balances.Add(b);

            return b;
        }

        private void ClearAccountBalances()
        {
            if (this.balances.Count > 0)
            {
                foreach (var b in this.balances)
                {
                    b.Balance = 0.0m;
                }
            }
        }
    }
}
