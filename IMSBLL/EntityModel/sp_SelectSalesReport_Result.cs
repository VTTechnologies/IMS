//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMSBLL.EntityModel
{
    using System;
    
    public partial class sp_SelectSalesReport_Result
    {
        public int sale_id { get; set; }
        public int party_id { get; set; }
        public string customerName { get; set; }
        public Nullable<decimal> grand_total { get; set; }
        public string date { get; set; }
    }
}
