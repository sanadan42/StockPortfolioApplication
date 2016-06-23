using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioApplication
{
    public class StockTransactionDisplay
    {
        public DateTime TransactionDate { get; set; }
        public string AccountName { get; set; }
        public string TransactionType { get; set; }
        public string StockTicker { get; set; }
        public string StockDescription { get; set; }
        public int Shares { get; set; }
        public decimal Price { get; set; }
        public decimal Commission { get; set; }
    }

    public class StockTransaction : StockTransactionDisplay
    {
        public int AccountID { get; set; }
        public int EquityID { get; set; }
        public int TransactionTypeID { get; set; }
    }

    public class DividendTransactionDisplay
    {
        public DateTime TransactionDate { get; set; }
        public string AccountName { get; set; }
        public string StockTicker { get; set; }
        public decimal Dividend { get; set; }
    }

    public class DividendTransaction : DividendTransactionDisplay
    {
        public int AccountID { get; set; }
        public int EquityID { get; set; }
    }
}
