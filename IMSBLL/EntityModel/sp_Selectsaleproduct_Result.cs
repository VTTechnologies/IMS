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
    
    public partial class sp_Selectsaleproduct_Result
    {
        public int saledetails_id { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> batch_id { get; set; }
        public Nullable<int> unit_id { get; set; }
        public Nullable<int> tax_id { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> dicount_amt { get; set; }
        public Nullable<decimal> tax_amt { get; set; }
        public Nullable<decimal> sale_rate { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string product_name { get; set; }
        public string unit_name { get; set; }
        public string batch_name { get; set; }
        public Nullable<decimal> tax_percentage { get; set; }
    }
}
