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
    public partial class ctlTransactions : UserControl
    {
        private ctlEquityTransaction ctlEquityTrans;
        private Portfolio portfolio;

        public ctlTransactions(Portfolio p)
        {
            this.portfolio = p;

            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.ctlEquityTrans = new ctlEquityTransaction(portfolio);
            this.ctlEquityTrans.Location = new System.Drawing.Point(0, 0);
            this.ctlEquityTrans.Visible = true;

            this.pnlTransactionDisplay.Controls.Add(ctlEquityTrans);
        }

        public void RefreshData()
        {
            this.ctlEquityTrans.RefreshData();
        }
    }
}
