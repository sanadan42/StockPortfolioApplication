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
            this.RefreshAccounts();
        }

        private void RefreshAccounts()
        {
            this.accounts = portCalcs.GetAccountList();

            // process the main account
            //  - need to process this account before the other accounts get processed
            RefreshAccount(this.allAccounts);
            
            // process each account
            foreach (Account account in this.accounts)
            {
                RefreshAccount(account);
            }
        }

        private void RefreshAccount(Account account)
        {
            List<Equity> equities = portCalcs.GetEquityListForAccount(account.ID);

            foreach (Equity equity in equities)
            {
                portCalcs.EquityCalculations(equity, account);
                if(account.ID == -1)
                {
                    equity.ACBPortfolio = equity.AverageCostBasis;
                }
                else
                {
                    equity.ACBPortfolio = this.allAccounts.GetEquities().Find(e => e.ID == equity.ID).AverageCostBasis;
                }
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
}
