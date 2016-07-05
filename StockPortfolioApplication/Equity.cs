using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioApplication
{
    public class Equity
    {
        //private decimal CurrentPrice, acb;

        public int ID { get; set; }
        public string Ticker { get; set; }
        public string Description { get; set; }
        public int Shares { get; set; }
        public decimal CurrentPrice { get; set; }

        public decimal AverageCostBasis { get; set; }
        public decimal ACBPortfolio { get; set; } // this will be the Average Cost Basis for the equity across all accounts that it is owned in

        public decimal TotalCost { get; set; }
        public decimal RealizedGain { get; set; }
        public decimal DividendProfit { get; set; }

        public decimal UnrealizedGain
        {
            get
            {
                return Shares * (CurrentPrice - AverageCostBasis);
            }
        }

        public decimal TotalPL
        {
            get
            {
                return RealizedGain + DividendProfit;
            }
        }

        public string Currency { get; set; }


        //public decimal GetACB() { return this.acb; }
        //public void SetACB(decimal acbCalc) { this.acb = acbCalc; }
    }
}
