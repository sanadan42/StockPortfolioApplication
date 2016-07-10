using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Forms;

namespace StockPortfolioApplication
{
    public partial class ctlFinanceTransaction : UserControl
    {
        private Portfolio portfolio;
        private SortableBindingList<FinancialTransactionDisplay> sortableTransactionList;

        public ctlFinanceTransaction(Portfolio p)
        {
            this.portfolio = p;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            InitComboBoxes();
            UpdateDG();
        }

        private void InitComboBoxes()
        {
            using (var db = new StockPortfolioDBEntities())
            {
                var transactionFinancialTypes = db.tblTransactionTypes
                                                .Where(t => t.TransactionTypeUsage == (int)TransactionUsage.Financial)
                                                .OrderBy(t => t.TransactionType).ToList();
                transactionFinancialTypes.Insert(0, new tblTransactionType());

                var entityAccounts = db.tblAccounts.OrderBy(a => a.AccountName);
                var accountsFinancial = entityAccounts.ToList();
                var accountsFinancialTo = entityAccounts.ToList();

                accountsFinancial.Insert(0, new tblAccount());
                accountsFinancialTo.Insert(0, new tblAccount());

                var currencies = db.tblCurrencies.OrderBy(c => c.CurrencyType).ToList();
                currencies.Insert(0, new tblCurrency());

                // initialize equity combo box
                cmbFinancialTransaction.DataSource = transactionFinancialTypes;
                cmbFinancialTransaction.DisplayMember = "TransactionType";
                cmbFinancialTransaction.ValueMember = "TransactionTypeID";

                // initialize accounts combo box
                cmbFinancialAccount.DataSource = accountsFinancial;
                cmbFinancialAccountTo.DataSource = accountsFinancialTo;
                cmbFinancialAccount.DisplayMember = cmbFinancialAccountTo.DisplayMember = "AccountName";
                cmbFinancialAccount.ValueMember = cmbFinancialAccountTo.ValueMember = "AccountID";

                // initialize currency combo box
                cmbFinancialCurrency.DataSource = currencies;
                cmbFinancialCurrency.DisplayMember = "CurrencyType";
                cmbFinancialCurrency.ValueMember = "CurrencyID";
            }
        }

        private void UpdateDG()
        {
            sortableTransactionList = new SortableBindingList<FinancialTransactionDisplay>(GetTransactions());
            dgvFinancialTransactions.DataSource = sortableTransactionList;
            FormatDataGrid();
            dgvFinancialTransactions.Refresh();
        }

        private void FormatDataGrid()
        {
            dgvFinancialTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinancialTransactions.Columns["Net"].DefaultCellStyle.Format = "c";
            dgvFinancialTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn c in dgvFinancialTransactions.Columns)
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private List<FinancialTransactionDisplay> GetTransactions()
        {
            List<FinancialTransactionDisplay> resultList = new List<FinancialTransactionDisplay>();
            using (var stocks = new StockPortfolioDBEntities())
            {
                var result = from ft in stocks.tblTransactionFinances
                             join tt in stocks.tblTransactionTypes on ft.TransactionIDFK equals tt.TransactionTypeID
                             join a in stocks.tblAccounts on ft.AccountIDFK equals a.AccountID
                             orderby ft.TransactionDate descending
                             select new FinancialTransactionDisplay()
                             {
                                 TransactionDate = (DateTime)ft.TransactionDate,
                                 AccountName = a.AccountName,
                                 TransactionType = tt.TransactionType,
                                 Net = (decimal)ft.Net,
                                 Currency = ft.tblCurrency.CurrencyType
                             };

                resultList = result.ToList();
            }
            return resultList;
        }

        private void btnFinancialSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    decimal netFinance = decimal.Parse(txtFincialNet.Text);

                    switch ((int)cmbFinancialTransaction.SelectedValue)
                    {
                        case (int)FinancialTransactionTypes.Fees:
                        case (int)FinancialTransactionTypes.Interest:
                        case (int)FinancialTransactionTypes.Withdrawal:
                            if (netFinance > 0)
                                netFinance *= -1;
                            break;
                        default:
                            break;
                    }

                    stockEntity.tblTransactionFinances.Add(new tblTransactionFinance
                    {
                        TransactionDate = dtpFinancialTransaction.Value,
                        TransactionIDFK = (int)cmbFinancialTransaction.SelectedValue,
                        AccountIDFK = (int)cmbFinancialAccount.SelectedValue,
                        Net = netFinance,
                        CurrencyIDFK = (int)cmbFinancialCurrency.SelectedValue
                    });
                    stockEntity.SaveChanges();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                InitFinancialTransactions();
                portfolio.RefreshPortfolio();
                UpdateDG();
            }
        }

        private void InitFinancialTransactions()
        {
            cmbFinancialTransaction.SelectedIndex = 0;
            cmbFinancialAccount.SelectedIndex = cmbFinancialAccountTo.SelectedIndex = 0;
            cmbFinancialCurrency.SelectedIndex = 0;
            txtFincialNet.Text = "";
        }

        private void dgvFinancialTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvFinancialTransactions.Columns[e.ColumnIndex].Name == "Net")
            {
                if (e.Value != null)
                {
                    if ((decimal)e.Value < 0.0m)
                    {
                        this.dgvFinancialTransactions.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.dgvFinancialTransactions.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
    }

    public class FinancialTransactionDisplay
    {
        public DateTime TransactionDate { get; set; }
        public string AccountName { get; set; }
        public string TransactionType { get; set; }
        public decimal Net { get; set; }
        public string Currency { get; set; }
    }

    public class FinancialTransaction : StockTransactionDisplay
    {
        public int AccountID { get; set; }
        public int TransactionTypeID { get; set; }
    }
}
