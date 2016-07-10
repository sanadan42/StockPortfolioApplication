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
    public enum TransactionListEnum
    {
        Nothing = 0,
        Equity = 1,
        Dividend = 2,
        Finance = 3
    }
    public partial class ctlTransactions : UserControl
    {
        private ctlEquityTransaction ctlEquityTrans;
        private ctlFinanceTransaction ctlFinancialTrans;
        private ctlDividendTransaction ctlDividendTrans;
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
            transactionList.Add(new TransactionListSelection("Equity Transactions", (int)TransactionListEnum.Equity));
            transactionList.Add(new TransactionListSelection("Dividend Transactions", (int)TransactionListEnum.Dividend));
            transactionList.Add(new TransactionListSelection("Finance Transactions", (int)TransactionListEnum.Finance));
            this.cmbTransactionSelection.DisplayMember = "Transaction";
            this.cmbTransactionSelection.ValueMember = "Value";
            this.cmbTransactionSelection.DataSource = transactionList;
            

            this.ctlEquityTrans = new ctlEquityTransaction(portfolio);
            this.ctlEquityTrans.Location = new System.Drawing.Point(0, 0);
            this.ctlEquityTrans.Visible = false;

            this.ctlFinancialTrans = new ctlFinanceTransaction(portfolio);
            this.ctlFinancialTrans.Location = new System.Drawing.Point(0, 0);
            this.ctlFinancialTrans.Visible = false;

            this.ctlDividendTrans = new ctlDividendTransaction(portfolio);
            this.ctlDividendTrans.Location = new System.Drawing.Point(0, 0);
            this.ctlDividendTrans.Visible = false;

            this.pnlTransactionDisplay.Controls.Add(ctlEquityTrans);
            this.pnlTransactionDisplay.Controls.Add(ctlFinancialTrans);
            this.pnlTransactionDisplay.Controls.Add(ctlDividendTrans);
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
                    case (int)TransactionListEnum.Nothing:
                        ClearPanel();
                        break;
                    case (int)TransactionListEnum.Equity:
                        if (!ctlEquityTrans.Visible)
                        {
                            ClearPanel();
                            ctlEquityTrans.Visible = true;
                        }
                        break;
                    case (int)TransactionListEnum.Dividend:
                        if (!ctlDividendTrans.Visible)
                        {
                            ClearPanel();
                            ctlDividendTrans.Visible = true;
                        }
                        break;
                    case (int)TransactionListEnum.Finance:
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
