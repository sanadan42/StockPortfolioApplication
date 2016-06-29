using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPortfolioApplication
{
    public partial class MainForm : Form
    {
        private ctlStockTransaction ctlStockTrans;
        private ctlEquities ctlEquityUpdate;
        private ctlEquityExchangeCurrency ctlEECAdd;
        private ctlTestSums ctlSums;
        private ctlBerkshireView ctlBerkshire;
        private Portfolio portfolio;

        public MainForm()
        {
            portfolio = new Portfolio();
            portfolio.CreatePortfolio();

            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.ctlStockTrans = new ctlStockTransaction(portfolio);
            this.ctlStockTrans.Location = new System.Drawing.Point(0, 0);
            this.ctlStockTrans.Visible = false;

            this.ctlEquityUpdate = new ctlEquities(portfolio);
            this.ctlEquityUpdate.Location = new System.Drawing.Point(0, 0);
            this.ctlEquityUpdate.Visible = false;

            this.ctlEECAdd = new ctlEquityExchangeCurrency();
            this.ctlEECAdd.Location = new System.Drawing.Point(0, 0);
            this.ctlEECAdd.Visible = false;

            this.ctlSums = new ctlTestSums(portfolio);
            this.ctlSums.Location = new System.Drawing.Point(0, 0);
            this.ctlSums.Visible = false;

            this.ctlBerkshire = new ctlBerkshireView(portfolio);
            this.ctlBerkshire.Location = new System.Drawing.Point(0, 0);
            this.ctlBerkshire.Visible = false;

            this.pnlDisplay.Controls.Add(this.ctlStockTrans);
            this.pnlDisplay.Controls.Add(this.ctlEquityUpdate);
            this.pnlDisplay.Controls.Add(this.ctlEECAdd);
            this.pnlDisplay.Controls.Add(this.ctlSums);
            this.pnlDisplay.Controls.Add(this.ctlBerkshire);
        }

        private void btnTransactionEntryDisplay_Click(object sender, EventArgs e)
        {
            if(!this.ctlStockTrans.Visible)
            {
                ClearDisplayPanel();
                this.ctlStockTrans.Visible = true;
            }
        }

        private void btnDataGridDisplay_Click(object sender, EventArgs e)
        {
            if(!this.ctlEquityUpdate.Visible)
            {
                ClearDisplayPanel();
                this.ctlEquityUpdate.Visible = true;
            }
            ctlEquityUpdate.RefreshGrid();
        }

        private void btnEECAdd_Click(object sender, EventArgs e)
        {
            if(!this.ctlEECAdd.Visible)
            {
                ClearDisplayPanel();
                this.ctlEECAdd.Visible = true;
            }
        }

        private void ClearDisplayPanel()
        {
            foreach (Control ctl in this.pnlDisplay.Controls)
            {
                ctl.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ctlSums.Visible)
            {
                ClearDisplayPanel();
                this.ctlSums.Visible = true;
            }
        }

        private void btnBerkshireTesting_Click(object sender, EventArgs e)
        {
            if(!this.ctlBerkshire.Visible)
            {
                ClearDisplayPanel();
                this.ctlBerkshire.RefreshData();
                this.ctlBerkshire.Visible = true;
            }
        }
    }
}