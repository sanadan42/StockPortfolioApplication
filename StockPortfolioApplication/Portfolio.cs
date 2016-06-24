using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioApplication
{
    public class Portfolio
    {
        PortfolioCalculations portCalcs;
        List<Account> accounts;
        Account allAccounts;
        //List<Equity> allEquities;

        // create the portfolio
        public Portfolio()
        {
            // create the workhorse of portfolio calculations
            portCalcs = new PortfolioCalculations();
            // allAccounts will be used to store the totals, list of accounts, equities, etc.
            allAccounts = new Account();
            allAccounts.ID = -1;
        }

        public void RefreshPortfolio()
        {
            this.CreatePortfolio();
        }

        public void CreatePortfolio()
        {
            portCalcs.PopulateTransactionList();
            this.RefreshAllEquities();
            this.RefreshAccounts();
        }

        private void RefreshAllEquities()
        {
            // process each equity
            // this may be redudant as it must be derivable from the results of the equities in each account, but I'm not sure so let's just do it
            List<Equity> equityListFromDB = portCalcs.GetEquityList();

            if (equityListFromDB != null)
            {
                foreach (Equity equity in equityListFromDB)
                {
                    portCalcs.EquityCalculations(equity);
                    equity.ACBPortfolio = equity.AverageCostBasis;
                    equity.DividendProfit = portCalcs.DividendCalculations(equity);
                }
            }

            this.allAccounts.SetEquities(equityListFromDB);
        }

        private void RefreshAccounts()
        {
            this.accounts = portCalcs.GetAccountList();

            // process each account
            foreach (Account account in this.accounts)
            {
                RefreshAccount(account);
            }

            //RefreshAccount(this.allAccounts);
        }

        private void RefreshAccount(Account account)
        {
            List<Equity> equities = portCalcs.GetEquityListForAccount(account.ID);

            foreach (Equity equity in equities)
            {
                portCalcs.EquityCalculations(equity, account);
                equity.ACBPortfolio = this.allAccounts.GetEquities().Find(e => e.ID == equity.ID).AverageCostBasis;
                equity.DividendProfit = portCalcs.DividendCalculations(equity, account);
            }

            account.RefreshTotals();
            account.SetEquities(equities);
        }

        public List<Equity> GetEquityList()
        {
            return allAccounts.GetEquities();
        }

        public List<Equity> GetEquityList(int accountID)
        {
            if (accountID == -1)
            {
                return this.allAccounts.GetEquities();
            }
            else
            {
                return this.accounts.Where(a => a.ID == accountID).SingleOrDefault().GetEquities();
            }
        }

        public Account GetAccountSummary()
        {
            return GetAccount(-1);
        }

        public Account GetAccount (int accountID)
        {
            if(accountID == -1)
            {
                return this.allAccounts;
            }
            else
            {
                return this.accounts.Where(a => a.ID == accountID).SingleOrDefault();
            }
            
        }
    }

    public class Account
    {
        // each account will have a list of all equities that it contains
        // the account will also contain a list of balances
        // the different balances will allow each account to have multiple different currencies
        private List<Equity> equities;
        private List<BalanceType> balances;

        private decimal totalEquityCost, totalRealizedGain, totalUnrealizedGain, totalDividendGain, totalPLGain;

        public int ID { get; set; }
        public String AccountName { get; set; }
        public int AccountNumber { get; set; }

        public decimal TotalEquityCost { get { return totalEquityCost; } }
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
            this.totalEquityCost = this.totalRealizedGain = this.totalUnrealizedGain = this.totalDividendGain = this.totalPLGain = 0.0m;
        }

        public void RefreshTotals()
        {
            ClearTotals();
            if (this.equities != null)
            {
                foreach(Equity e in equities)
                {
                    // calculate totals
                    this.totalEquityCost += e.TotalCost;
                    this.totalRealizedGain += e.RealizedGain;
                    this.totalUnrealizedGain += e.UnrealizedGain;
                    this.totalDividendGain += e.DividendProfit;
                    this.totalPLGain += e.TotalPL;
                }
            }
        }
    }

    public class Equity
    {
        //private decimal CurrentPrice, acb;

        public int ID { get; set; }
        public string Ticker { get; set; }
        public string Description { get; set; }
        public int Shares { get; set; }
        public decimal CurrentPrice { get; set; }

        public decimal AverageCostBasis { get; set; }
        public decimal ACBPortfolio { get; set; } // this will be the Average Cost Basis for the equity across all accounts that it is owned in

        public decimal TotalCost { get; set; }
        public decimal RealizedGain { get; set; }
        public decimal DividendProfit { get; set; }

        public decimal UnrealizedGain
        {
            get
            {
                return Shares * (CurrentPrice - AverageCostBasis);
            }
        }

        public decimal TotalPL
        {
            get
            {
                return RealizedGain + DividendProfit;
            }
        }
        
        
        //public decimal GetACB() { return this.acb; }
        //public void SetACB(decimal acbCalc) { this.acb = acbCalc; }
    }

    public class BalanceType
    {
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }
}
