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
    
    public partial class InventoryReport_Result
    {
        public string CompanyName { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string PartyContactNo { get; set; }
        public string CompanyAddress { get; set; }
        public string logo { get; set; }
        public string ProductName { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public Nullable<decimal> sale_rate { get; set; }
        public Nullable<decimal> dicount_amt { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> tax_percentage { get; set; }
        public Nullable<decimal> Total { get; set; }
    }
}
