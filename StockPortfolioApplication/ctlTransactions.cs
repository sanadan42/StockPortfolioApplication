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
        private ctlFinanceTransaction ctlFinancialTrans;
        private Portfolio portfolio;

        public ctlTransactions(Portfolio p)
        {
            this.portfolio = p;

            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            List<TransactionListSelection> transactionList = new List<TransactionListSelection>();
            transactionList.Add(new TransactionListSelection("", 0));
            transactionList.Add(new TransactionListSelection("Equity Transactions", 1));
            transactionList.Add(new TransactionListSelection("Finance Transactions", 2));
            this.cmbTransactionSelection.DisplayMember = "Transaction";
            this.cmbTransactionSelection.ValueMember = "Value";
            this.cmbTransactionSelection.DataSource = transactionList;
            

            this.ctlEquityTrans = new ctlEquityTransaction(portfolio);
            this.ctlEquityTrans.Location = new System.Drawing.Point(0, 0);
            this.ctlEquityTrans.Visible = false;

            this.ctlFinancialTrans = new ctlFinanceTransaction(portfolio);
            this.ctlFinancialTrans.Location = new System.Drawing.Point(0, 0);
            this.ctlFinancialTrans.Visible = false;

            this.pnlTransactionDisplay.Controls.Add(ctlEquityTrans);
            this.pnlTransactionDisplay.Controls.Add(ctlFinancialTrans);
        }

        public void RefreshData()
        {
            this.ctlEquityTrans.RefreshData();
        }

        private void ClearPanel()
        {
            foreach(Control c in pnlTransactionDisplay.Controls)
            {
                c.Visible = false;
            }
        }

        private void cmbTransactionSelection_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTransactionSelection.SelectedValue != null)
            {
                switch ((int)cmbTransactionSelection.SelectedValue)
                {
                    case 0:
                        ClearPanel();
                        break;
                    case 1:
                        if (!ctlEquityTrans.Visible)
                        {
                            ClearPanel();
                            ctlEquityTrans.Visible = true;
                        }
                        break;
                    case 2:
                        if (!ctlFinancialTrans.Visible)
                        {
                            ClearPanel();
                            ctlFinancialTrans.Visible = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        
    }

    public class TransactionListSelection
    {
        public string Transaction { get; set; }
        public int Value { get; set; }

        public TransactionListSelection(string s, int v)
        {
            Transaction = s;
            Value = v;
        }
    }

}
