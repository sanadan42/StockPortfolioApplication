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
    public partial class ctlBerkshireEquityView : UserControl
    {
        public ctlBerkshireEquityView()
        {
            InitializeComponent();
        }

        public void Populate(Equity e)
        {
            this.lblTicker.Text = e.Ticker;
            this.lblDescription.Text = e.Description;
            this.lblShares.Text = e.Shares.ToString();
            this.lblCostCalculated.Text = e.TotalCost.ToString("C");
            this.lblValueCalculated.Text = (e.Shares * e.CurrentPrice).ToString("C");

            //Ticker = e.Ticker;
            //Description = e.Description;
            //Shares = e.Shares;
            //Cost = e.TotalCost;
            //Value = e.Shares * e.CurrentPrice;
        }

        public void SetAsHeader()
        {
            this.lblTicker.Text = "Ticker";
            this.lblDescription.Text = "Description";
            this.lblShares.Text = "Shares";
            this.lblCostCalculated.Text = "Cost";
            this.lblValueCalculated.Text = "Value";
        }

        public int TickerHPos { get { return lblTicker.Location.X; } }
        public int DecriptionHPos { get { return lblDescription.Location.X; } }
        public int SharesHPos { get { return lblShares.Location.X; } }
        public int CostHPos { get { return lblCostCalculated.Location.X; } }
        public int ValueHPos { get { return lblValueCalculated.Location.X; } }

        public string Ticker { get; set; }
        public string Description { get; set; }
        public int Shares { get; set; }
        public decimal Cost { get; set; }
        public decimal Value { get; set; }// this should be a calculated view of value = current # shares * current price
    }
}
