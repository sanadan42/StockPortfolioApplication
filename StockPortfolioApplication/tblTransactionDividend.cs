//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockPortfolioApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTransactionDividend
    {
        public int TransactionID { get; set; }
        public Nullable<int> EquityIDFK { get; set; }
        public Nullable<int> AccountIDFK { get; set; }
        public Nullable<System.DateTime> DividendDate { get; set; }
        public Nullable<decimal> DividendValue { get; set; }
    
        public virtual tblAccount tblAccount { get; set; }
        public virtual tblEquity tblEquity { get; set; }
    }
}