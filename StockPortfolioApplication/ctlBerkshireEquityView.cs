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
            Ticker = e.Ticker;
            Description = e.Description;
            Shares = e.Shares;
            Cost = e.TotalCost;
            Value = e.Shares * e.CurrentPrice;
        }

        public string Ticker { get; set; }
        public string Description { get; set; }
        public int Shares { get; set; }
        public decimal Cost { get; set; }
        public decimal Value { get; set; }// this should be a calculated view of value = current # shares * current price
    }
}
