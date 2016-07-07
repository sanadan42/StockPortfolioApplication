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
        private SortableBindingList<StockTransaction> sortableTransactionList;

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
            sortableTransactionList = new SortableBindingList<StockTransaction>(GetTransactionsEquities());

            dgvEquityTransactions.DataSource = sortableTransactionList;
            FormatDataGrid();
            //ChangeDGColors(); // for now this is eliminated as it looks weird and also doesn't change colors until after the dgv has been displayed, and then refresh makes things "flash"
            dgvEquityTransactions.Refresh();

        }

        private void FormatDataGrid()
        {
            dgvEquityTransactions.Columns["AccountID"].Visible = false;
            dgvEquityTransactions.Columns["EquityID"].Visible = false;
            dgvEquityTransactions.Columns["TransactionTypeID"].Visible = false;

            dgvEquityTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEquityTransactions.Columns["Price"].DefaultCellStyle.Format =
                     dgvEquityTransactions.Columns["Commission"].DefaultCellStyle.Format = "c";

            dgvEquityTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn c in dgvEquityTransactions.Columns)
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgvEquityTransactions.Columns["Shares"].DefaultCellStyle.Format = "N0"; // Number, 0 decimal places (N0)
        }

        //*************************************************
        // CHANGE THIS AND THEN UPDATE THE COMMENTS
        //*************************************************
        private List<StockTransaction> GetTransactionsEquities()
        {
            List<StockTransaction> resultList = new List<StockTransaction>();
            using (var stocks = new StockPortfolioDBEntities())
            {
                var result = from trans in stocks.tblTransactionEquities
                             join tt in stocks.tblTransactionTypes on trans.TransactionTypeIDFK equals tt.TransactionTypeID
                             join equity in stocks.tblEquities on trans.EquityIDFK equals equity.EquityID
                             join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
                             orderby acc.AccountName, equity.StockTicker
                             select new StockTransaction()
                             {
                                 AccountName = acc.AccountName,
                                 StockTicker = equity.StockTicker,
                                 StockDescription = equity.Description,
                                 TransactionType = tt.TransactionType,
                                 TransactionDate = (DateTime)trans.TransactionDate,
                                 Shares = (decimal)trans.Shares,
                                 Price = (decimal)trans.Price,
                                 Commission = (decimal)trans.Commission,
                                 AccountID = (int)trans.AccountIDFK,
                                 EquityID = (int)trans.EquityIDFK,
                                 TransactionTypeID = (int)trans.TransactionTypeIDFK
                             };

                resultList = result.ToList();
            }
            return resultList;
        }

    }
}
