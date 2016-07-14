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
    public partial class ctlDividendTransaction : UserControl
    {
        private Portfolio portfolio;
        private SortableBindingList<DividendTransactionDisplay> sortableTransactionList;

        public ctlDividendTransaction(Portfolio p)
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
                var accountsDividend = db.tblAccounts.OrderBy(a => a.AccountName).ToList();
                accountsDividend.Insert(0, new tblAccount());

                var dividendEquities = db.tblEquities
                                .Where(d => d.HasDividend == true)
                                .OrderBy(c => c.StockTicker)
                                .ToList();
                dividendEquities.Insert(0, new tblEquity());

                // initialize equity combo box
                cmbDividendEquity.DisplayMember = "StockTicker";
                cmbDividendEquity.ValueMember = "EquityID";
                cmbDividendEquity.DataSource = dividendEquities;

                // initialize accounts combo box
                cmbDividendAccount.DisplayMember = "AccountName";
                cmbDividendAccount.ValueMember = "AccountID";
                cmbDividendAccount.DataSource = accountsDividend;
            }
        }

        public void RefreshData()
        {
            UpdateDG();
        }

        private void UpdateDG()
        {
            sortableTransactionList = new SortableBindingList<DividendTransactionDisplay>(GetTransactions());
            dgvDividendTransactions.DataSource = sortableTransactionList;
            FormatDataGrid();
            dgvDividendTransactions.Refresh();
        }

        private void FormatDataGrid()
        {
            dgvDividendTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDividendTransactions.Columns["DividendValue"].DefaultCellStyle.Format = "c";
            dgvDividendTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn c in dgvDividendTransactions.Columns)
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private List<DividendTransactionDisplay> GetTransactions()
        {
            List<DividendTransactionDisplay> resultList = new List<DividendTransactionDisplay>();
            using (var db = new StockPortfolioDBEntities())
            {
                var result = from dt in db.tblTransactionDividends
                             orderby dt.DividendDate descending
                             select new DividendTransactionDisplay()
                             {
                                 TransactionDate = (DateTime)dt.DividendDate,
                                 AccountName = dt.tblAccount.AccountName,
                                 StockTicker = dt.tblEquity.StockTicker,
                                 DividendValue = (decimal)dt.DividendValue
                             };

                resultList = result.ToList();
            }
            return resultList;
        }

        private void InitDividendTransactions()
        {
            cmbDividendEquity.SelectedIndex = 0;
            cmbDividendAccount.SelectedIndex = 0;
            txtDividend.Text = "";
        }

        private void btnDividendSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var stockEntity = new StockPortfolioDBEntities())
                {
                    stockEntity.tblTransactionDividends.Add(new tblTransactionDividend
                    {
                        DividendDate = dtpDividend.Value,
                        EquityIDFK = (int)cmbDividendEquity.SelectedValue,
                        AccountIDFK = (int)cmbDividendAccount.SelectedValue,
                        DividendValue = decimal.Parse(txtDividend.Text)
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
                InitDividendTransactions();
                portfolio.RefreshPortfolio();
                UpdateDG();
            }
        }
    }

    public class DividendTransactionDisplay
    {
        public DateTime TransactionDate { get; set; }
        public string AccountName { get; set; }
        public string StockTicker { get; set; }
        public decimal DividendValue { get; set; }
    }

    public class DividendTransaction : StockTransactionDisplay
    {
        public int AccountID { get; set; }
        public int EquityID { get; set; }
    }
}
