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
    public partial class ctlEquityTransaction : UserControl
    {
        private Portfolio portfolio;
        private SortableBindingList<StockTransaction> sortableTransactionList;

        public ctlEquityTransaction(Portfolio p)
        {
            this.portfolio = p;
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            dgvEquityTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateDG();

            using (var stockEntity = new StockPortfolioDBEntities())
            {

                var transactionTypes = stockEntity.tblTransactionTypes.OrderBy(t => t.TransactionType);
                var transactionEquityTypes = transactionTypes.Where(t => t.TransactionTypeUsage == (int)TransactionUsage.Equity).ToList();
                transactionEquityTypes.Insert(0, new tblTransactionType());

                var entityAccounts = stockEntity.tblAccounts.OrderBy(a => a.AccountName);
                var accountsEquity = entityAccounts.ToList();
                var accountsEquityTo = entityAccounts.ToList();

                accountsEquity.Insert(0, new tblAccount());
                accountsEquityTo.Insert(0, new tblAccount());

                var equitiesAll = stockEntity.tblEquities.OrderBy(c => c.StockTicker);
                var equities = equitiesAll.ToList();
                var dividendEquities = equitiesAll.Where(d => d.HasDividend == true).ToList();
                equities.Insert(0, new tblEquity());
                dividendEquities.Insert(0, new tblEquity());

                var currencies = stockEntity.tblCurrencies.OrderBy(c => c.CurrencyType).ToList();
                currencies.Insert(0, new tblCurrency());

                // initialize equity combo box
                cmbTransactionEquity.DataSource = transactionEquityTypes;
                cmbTransactionEquity.DisplayMember = "TransactionType";
                cmbTransactionEquity.ValueMember = "TransactionTypeID";

                // initialize accounts combo box
                cmbAccountEquity.DataSource = accountsEquity;
                cmbAccountTo.DataSource = accountsEquityTo;
                cmbAccountEquity.DisplayMember = cmbAccountTo.DisplayMember = "AccountName";
                cmbAccountEquity.ValueMember = cmbAccountTo.ValueMember = "AccountID";
                cmbAccountTo.Visible = false;

                // initialize Equity combo box
                cmbEquityEquity.DataSource = equities;
                cmbEquityEquity.DisplayMember = "StockTicker";
                cmbEquityEquity.ValueMember = "EquityID";

                lblAccountTo.Visible = false;
            }
        }

        public void RefreshData()
        {
            UpdateDG();
        }

        private void UpdateDG()
        {
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

            dgvEquityTransactions.Columns["Shares"].DefaultCellStyle.Format = "d";
        }

        private void ChangeDGColors()
        {
            foreach (DataGridViewRow row in dgvEquityTransactions.Rows)
            {
                foreach (DataGridViewColumn col in dgvEquityTransactions.Columns)
                {
                    switch (col.Name)
                    {
                        case "Shares":
                            var cell = dgvEquityTransactions.Rows[row.Index].Cells[col.Index];
                            if (cell.Value != null)
                            {
                                if ((int)cell.Value < 0)
                                {
                                    cell.Style.ForeColor = Color.Red;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
        }

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
                                 Shares = (int)trans.Shares,
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

        private void InitEquityTransactions()
        {
            cmbTransactionEquity.SelectedIndex = 0;
            cmbAccountEquity.SelectedIndex = cmbAccountTo.SelectedIndex = 0;
            cmbEquityEquity.SelectedIndex = 0;
            numEquityShares.Value = 0;
            txtPrice.Text = "";
            txtCommission.Text = "";
            txtExchangeRate.Text = "";
        }

        private void cmbTransactionEquity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // instead of strings these should probably be values that correspond to the selected value that is returned
            bool accountToStatus = cmbTransactionEquity.Text == "TRF-B" || cmbTransactionEquity.Text == "TRF-S";
            lblAccountTo.Visible = accountToStatus;
            cmbAccountTo.Visible = accountToStatus;
        }

        private void btnTransactionSave_Click(object sender, EventArgs e)
        {
            int shareModifier = 1;
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    if ((int)cmbTransactionEquity.SelectedValue == (int)EquityTransactionTypes.SellStock)
                    {
                        if ((int)numEquityShares.Value > 0)
                            shareModifier = -1;
                    }

                    stockEntity.tblTransactionEquities.Add(new tblTransactionEquity
                    {
                        TransactionDate = dtpTransactionDate.Value,
                        TransactionTypeIDFK = (int)cmbTransactionEquity.SelectedValue,
                        AccountIDFK = (int)cmbAccountEquity.SelectedValue,
                        EquityIDFK = (int)cmbEquityEquity.SelectedValue,
                        Shares = shareModifier * (int)numEquityShares.Value,
                        Price = decimal.Parse(txtPrice.Text),
                        Commission = decimal.Parse(txtCommission.Text),
                        ExchangeRate = decimal.Parse(txtExchangeRate.Text)
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
                InitEquityTransactions();
                //portfolio.RefreshPortfolio();
                UpdateDG();
            }
        }

    }
}