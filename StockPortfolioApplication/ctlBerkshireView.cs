﻿using System;
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
        Portfolio portfolio;

        List<ctlBerkshireEquityView> equityViewList;
        private string totalCostDisplay, totalValueDisplay, totalPLDisplay;

        public ctlBerkshireView()
        {
            portfolio = new Portfolio();
            portfolio.CreatePortfolio();

            Init();
        }

        public ctlBerkshireView(Portfolio portfolio)
        {
            this.portfolio = portfolio;

            Init();
        }

        private void Init()
        {
            InitializeComponent();
            BuildEquityList(portfolio.GetEquityList());

            foreach (ctlBerkshireEquityView brk in equityViewList)
            {
                this.Controls.Add(brk);
            }
            // this isn't needed because the totals that I want already exist as part of the account structure
            //CreateTotals(portfolio.GetAccountSummary());

        }

        private void BuildEquityList(List<Equity> equityList)
        {
            if(equityList.Count != 0)
            {
                this.equityViewList = new List<ctlBerkshireEquityView>();

                int y = 0;
                foreach (Equity e in equityList)
                {
                    ctlBerkshireEquityView brkEquityView = new ctlBerkshireEquityView();
                    y += brkEquityView.Size.Height;
                    brkEquityView.Location = new Point(0, y);
                    brkEquityView.Populate(e);
                    brkEquityView.Visible = true;
                    this.equityViewList.Add(brkEquityView);
                }
            }
        }


        private void CreateTotals(Account account)
        {
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
        }


        private void ctlBerkshireView_Load(object sender, EventArgs e)
        {

        }
    }
}
