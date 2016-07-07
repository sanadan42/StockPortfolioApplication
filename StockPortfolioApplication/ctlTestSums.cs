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
    public partial class ctlTestSums : UserControl
    {
        Portfolio portfolio;

        public ctlTestSums()
        {
            portfolio = new Portfolio();
            portfolio.CreatePortfolio();

            Init();
        }

        public ctlTestSums(Portfolio portfolio)
        {
            this.portfolio = portfolio;

            Init();
        }

        private void Init()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            using (var stocks = new StockPortfolioDBEntities())
            {
                var accounts = stocks.tblAccounts.OrderBy(a => a.AccountName).ToList();
                accounts.Insert(0, new tblAccount() { AccountID = -1});

                // initialize accounts combo box
                cmbAccount.DataSource = accounts;
                cmbAccount.DisplayMember = "AccountName";
                cmbAccount.ValueMember = "AccountID";
            }
        }

        private void FormatDataGrid()
        {
            dgSumShares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgSumShares.Columns["TotalCost"].DefaultCellStyle.Format =
                    dgSumShares.Columns["RealizedGain"].DefaultCellStyle.Format =
                    dgSumShares.Columns["DividendProfit"].DefaultCellStyle.Format =
                    dgSumShares.Columns["AverageCostBasis"].DefaultCellStyle.Format =
                    dgSumShares.Columns["ACBPortfolio"].DefaultCellStyle.Format =
                    dgSumShares.Columns["UnrealizedGain"].DefaultCellStyle.Format =
                    dgSumShares.Columns["TotalPL"].DefaultCellStyle.Format =
                    dgSumShares.Columns["CurrentPrice"].DefaultCellStyle.Format = "c";

            dgSumShares.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach(DataGridViewColumn c in dgSumShares.Columns)
            {
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dgSumShares.Columns["TotalCost"].DefaultCellStyle.Alignment =
            //        dgSumShares.Columns["RealizedGain"].DefaultCellStyle.Alignment =
            //        dgSumShares.Columns["DividendProfit"].DefaultCellStyle.Alignment =
            //        dgSumShares.Columns["AverageCostBasis"].DefaultCellStyle.Alignment =
            //        dgSumShares.Columns["ACBPortfolio"].DefaultCellStyle.Alignment =
            //        dgSumShares.Columns["CurrentPrice"].DefaultCellStyle.Alignment =
            //        dgSumShares.Columns["Ticker"].DefaultCellStyle.Alignment =
            //        dgSumShares.Columns["Shares"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgSumShares.Columns["Shares"].DefaultCellStyle.Format = "N0"; // N0 is for number no decimal places
        }
        
        private void btnGetAccountEquites_Click(object sender, EventArgs e)
        {
            portfolio.RefreshPortfolio();
            int accountID;
            if (cmbAccount.SelectedIndex > 0)
            {
                accountID = (int)cmbAccount.SelectedValue;
                dgSumShares.DataSource = portfolio.GetEquityList(accountID);

                Account account = portfolio.GetAccount(accountID);
                account.CalculateAccountBalances();
                Point loc = new System.Drawing.Point(lblBalanceCalc.Location.X, lblBalanceCalc.Location.Y);
                foreach(BalanceType b in account.GetBalances())
                {
                    Label tempLabel = new Label();
                    tempLabel.AutoSize = true;
                    tempLabel.Location = loc;
                    loc.Y += 13;
                    tempLabel.Text = b.Balance.ToString();
                    tempLabel.Visible = true;
                    this.Controls.Add(tempLabel);
                }
                
            }
            else
            {
                accountID = -1;
                dgSumShares.DataSource = portfolio.GetEquityList();
            }
            ChangeDGColors();
            FormatDataGrid();
            dgSumShares.Refresh();
            RefreshLabels(accountID);
        }

        private void ChangeDGColors()
        {
            foreach (DataGridViewRow row in dgSumShares.Rows)
            {
                foreach (DataGridViewColumn col in dgSumShares.Columns)
                {
                    switch(col.Name)
                    {
                        case "RealizedGain":
                        case "DividendProfit":
                        case "UnrealizedGain":
                        case "TotalPL":  
                            var cell = dgSumShares.Rows[row.Index].Cells[col.Index];//.Style.BackColor = Color.Red;
                            if (double.Parse(cell.Value.ToString()) < 0.0)
                            {
                                cell.Style.BackColor = Color.Red;
                            }
                            break;
                        default:
                            break;
                    }
                    
                }
            }
        }

        private void RefreshLabels(int accountID)
        {
            Account account = portfolio.GetAccount(accountID);
            account.RefreshTotals();
            this.lblCostCalculated.Text = account.TotalEquityCost.ToString("c");
            this.lblDividendCalculated.Text = account.TotalDividendGain.ToString("c");
            this.lblRealizedCalculated.Text = account.TotalRealizedGain.ToString("c");
            this.lblUnrealizedCalculated.Text = account.TotalUnrealizedGain.ToString("c");
            this.lblPLCalculated.Text = account.TotalPLGain.ToString("c");

            this.lblCostCalculated.Visible = this.lblDividendCalculated.Visible = this.lblRealizedCalculated.Visible = this.lblUnrealizedCalculated.Visible = this.lblPLCalculated.Visible = true;
        }

        private void btnGetAllEquities_Click(object sender, EventArgs e)
        {
            portfolio.RefreshPortfolio();
            dgSumShares.DataSource = portfolio.GetEquityList();
            FormatDataGrid();
            dgSumShares.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockDataRetriever sdr = new StockDataRetriever();
            sdr.GetHistoricalStockPrices("hos");
        }

        //private void someshit()
        //{
        //    using (var stockEntities = new StockPortfolioDBEntities())
        //    {
        //        // this works good... let's try something else
        //        var result = from e in stockEntities.tblEquities
        //                    join te in stockEntities.tblTransactionEquities on e.EquityID equals te.EquityIDFK
        //                    join a in stockEntities.tblAccounts on te.AccountIDFK equals a.AccountID
        //                    group te by new { te.EquityIDFK, e.StockTicker, a.AccountName } into g
        //                    select new
        //                    {
        //                        EquityID = g.Key.EquityIDFK,
        //                        StockTicker = g.Key.StockTicker,
        //                        AccountName = g.Key.AccountName,
        //                        Shares = g.Sum(t=>t.Shares)
        //                    };

        //        var result2 = from e in stockEntities.tblEquities
        //                     join te in stockEntities.tblTransactionEquities on e.EquityID equals te.EquityIDFK
        //                     group te by new { te.EquityIDFK, e.StockTicker } into g
        //                     select new SomeClass
        //                     {
        //                         EquityID = (int)g.Key.EquityIDFK,
        //                         Ticker = g.Key.StockTicker,
        //                         Shares = (int)g.Sum(t => t.Shares)
        //                     };
        //        var results2list = result2.Where(e => e.Shares > 0).ToList();
        //        dgSumShares.DataSource = results2list;
        //    }
        //
        //}
    }

}
