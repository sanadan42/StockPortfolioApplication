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

                // initialize accounts combo box
                cmbFinancialAccount.DataSource = accountsFinancial;
                cmbFinancialAccountTo.DataSource = accountsFinancialTo;

                // initialize currency combo box
                cmbFinancialCurrency.DataSource = currencies;
                cmbFinancialCurrency.DisplayMember = "CurrencyType";
                cmbFinancialCurrency.ValueMember = "CurrencyID";
            }
        }

        private void UpdateDG()
        {
            //*************************************************
            // CHANGE THIS AND THEN UPDATE THE COMMENTS
            //*************************************************
            //*************************************************
            // ALSO, Add the fucking button save stuff in as well.
            //*************************************************
            sortableTransactionList = new SortableBindingList<FinancialTransactionDisplay>(GetTransactions());

            dgvFinancialTransactions.DataSource = sortableTransactionList;
            FormatDataGrid();
            //ChangeDGColors(); // for now this is eliminated as it looks weird and also doesn't change colors until after the dgv has been displayed, and then refresh makes things "flash"
            dgvFinancialTransactions.Refresh();

        }

        private void FormatDataGrid()
        {
            dgvFinancialTransactions.Columns["AccountID"].Visible = false;
            dgvFinancialTransactions.Columns["EquityID"].Visible = false;
            dgvFinancialTransactions.Columns["TransactionTypeID"].Visible = false;

            dgvFinancialTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinancialTransactions.Columns["Price"].DefaultCellStyle.Format =
                     dgvFinancialTransactions.Columns["Commission"].DefaultCellStyle.Format = "c";

            dgvFinancialTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn c in dgvFinancialTransactions.Columns)
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvFinancialTransactions.Columns["Shares"].DefaultCellStyle.Format = "N0"; // Number, 0 decimal places (N0)
        }
        
        private List<FinancialTransactionDisplay> GetTransactions()
        {
            List<FinancialTransactionDisplay> resultList = new List<FinancialTransactionDisplay>();
            using (var stocks = new StockPortfolioDBEntities())
            {
                var result = from ft in stocks.tblTransactionFinances
                             join tt in stocks.tblTransactionTypes on ft.TransactionIDFK equals tt.TransactionTypeID
                             join a in stocks.tblAccounts on ft.AccountIDFK equals a.AccountID
                             orderby ft.TransactionDate
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
