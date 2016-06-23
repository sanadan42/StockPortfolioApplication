using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPortfolioApplication
{
    public partial class ctlBerkshireView : UserControl
    {
        List<ctlBerkshireEquityView> equityViewList;
        private string totalCostDisplay, totalValueDisplay, totalPLDisplay;

        public ctlBerkshireView()
        {
            // i don't know what repository I'm working with yet
            // trying to understand github integration

            // i changed this but i'm not sure how to upload it to the repo...
        }

        public ctlBerkshireView(Portfolio portfolio)
        {
            InitializeComponent();
            BuildEquityList(portfolio.GetEquityList());
            CreateTotals(portfolio.GetAccountSummary());
        }

        private void BuildEquityList(List<Equity> equityList)
        {
            if(equityList.Count != 0)
            {
                this.equityViewList = new List<ctlBerkshireEquityView>();

                foreach (Equity e in equityList)
                {
                    ctlBerkshireEquityView brkEquityView = new ctlBerkshireEquityView();
                    brkEquityView.Populate(e);
                    this.equityViewList.Add(brkEquityView);
                }
            }
        }

        private void CreateTotals(Account account)
        {
            decimal totalcost = account.TotalEquityCost; ;
            /*
             * alright - where am I?
             * right now I'm thinking about displaying a list similar to one in a Berkshire annual letter
             * for each of my account I want to display each of the equities I currently own, the cost I paid to buy, and the value I carried them at
             * I also want to display the total realized gains I have in that account
             * I also want to dispaly the total dividends that account has earned
             * I also want to disaply the sum of the the total realized and total dividends
             * I also want to display balances (slow down ninja Dodd)
             * 
             * I'm starting this journey with the summary account so that I can view all of my current equities in the aforementioned format
             * I then want to adjust this format so that I can display this data for a given year
             * to do that I will need to get the historical stock prices into my program
             * I will not rely upon the internet, but will create a new table in my databse for these prices and will then use the internet to populate that table
             * 
             * lots to do
             * lots to do
             * i'm going to stop for now as I am developing without a plan as to what I am attempting to do so i am unsure where I am going right now
             * and it's late
             * and I want to go to bed
             * so.... cookies?
             */



            //List<Equity> equityList = account.GetEquities();
            //decimal totalCost, totalValue, totalRealized, totalDividend, totalRealizedPL;
            //totalCost = totalValue = totalRealized = totalDividend = totalRealizedPL = 0.0m;
            //foreach (Equity e in equityList)
            //{
            //    totalCost += e.TotalCost;
            //    totalValue += e.Shares * e.CurrentPrice;
            //    totalRealized += e.RealizedGain;
            //    totalDividend += e.DividendProfit;
            //}
            //totalRealizedPL += e.RealizedGain + e.DividendProfit;
        }


        private void ctlBerkshireView_Load(object sender, EventArgs e)
        {

        }
    }
}
