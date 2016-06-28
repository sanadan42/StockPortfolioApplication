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
    
    public partial class ctlEquities : UserControl
    {
        private List<EquityReduced> equityList;

        public ctlEquities()
        {
            InitializeComponent();
            dgEquities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnBindEquities_Click(object sender, EventArgs e)
        {
            UpdateDG();
        }

        public void RefreshGrid()
        {
            UpdateDG();
        }
        
        // all of this code is really just around to keep an example of how I can work with my data in lists
        private void btnTransactions_Click(object sender, EventArgs e)
        {
            //var result = from trans in stocks.tblTransactionEquities
            //             join equity in stocks.tblEquities on trans.EquityIDFK equals equity.EquityID
            //             join acc in stocks.tblAccounts on trans.AccountIDFK equals acc.AccountID
            //             orderby acc.AccountName, equity.StockTicker
            //             select new
            //             {
            //                 Account = acc.AccountName,
            //                 StockTicker = equity.StockTicker,
            //                 TransactionDate = trans.TransactionDate,
            //                 Shares = trans.Shares,
            //                 Price = trans.Price
            //             };
            
        }

        private void UpdateDG()
        {
            
            using (var stockEntity = new StockPortfolioDBEntities())
            {
                var result = stockEntity.tblEquities.OrderBy(c => c.StockTicker);
                equityList = new List<EquityReduced>();
                foreach (tblEquity te in result)
                {
                    equityList.Add(te.GetReducedEquity());
                }
            }

            dgEquities.DataSource = equityList;
            dgEquities.Refresh();
        }

        private void btnDGUpdate_Click(object sender, EventArgs e)
        {
            using (var stockEntity = new StockPortfolioDBEntities())
            {
                foreach (tblEquity te in stockEntity.tblEquities)
                {
                    te.CurrentPrice = equityList.Find(equity => equity.GetEquityID() == te.EquityID).CurrentPrice;
                }
                stockEntity.SaveChanges();
            }
            UpdateDG();
        }
    }

    public partial class tblEquity
    {
        public EquityReduced GetReducedEquity()
        {
            EquityReduced equity = new EquityReduced();
            equity.SetEquityID((int)EquityID);
            equity.SetExchangeIDFK((int)ExchangeIDFK);
            equity.ExchangeName = this.tblStockExchanx.ExchangeName;

            equity.StockTicker = StockTicker;
            equity.Description = Description;
            equity.CurrentPrice = CurrentPrice;
            equity.HasDividend = HasDividend;
            return equity;
        }
    }

    public class EquityReduced
    {
        
        private int equityID;
        private int exchangeIDFK;
        
        //public int EquityID { get; set; }
        //public Nullable<int> ExchangeIDFK { get; set; }
        public string StockTicker { get; set; }
        public string Description { get; set; }
        public string ExchangeName { get; set; }
        public Nullable<decimal> CurrentPrice { get; set; }
        public Nullable<bool> HasDividend { get; set; }
        
        public int GetEquityID()
        {
            return equityID;
        }       

        public void SetEquityID(int id)
        {
            this.equityID = id;
        }
        public int GetExchangeIDFK()
        {
            return this.exchangeIDFK;
        }
        public void SetExchangeIDFK(int exIDFK)
        {
            this.exchangeIDFK = exIDFK;
        }
    }

    public class MyViewModel
    {
        public string StockTicker { get; set; }
        public string Description { get; set; }
        public string ExchangeName { get; set; }

        private tblEquity equity;

        public MyViewModel(tblEquity te)
        {
            equity = te;
        }
    }
}
