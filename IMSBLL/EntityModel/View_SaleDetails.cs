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
    using System.Collections.Generic;
    
    public partial class View_SaleDetails
    {
        public string tax_name { get; set; }
        public string unit_name { get; set; }
        public Nullable<bool> status { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<System.DateTime> sale_date { get; set; }
        public string product_code { get; set; }
        public Nullable<decimal> tax_percent { get; set; }
        public Nullable<decimal> sale_rate { get; set; }
        public Nullable<decimal> discount_amnt { get; set; }
        public Nullable<decimal> quantity { get; set; }
        public string company_name { get; set; }
        public string company_address { get; set; }
        public int company_id { get; set; }
        public Nullable<int> financialyear_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public int sale_id { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> GivenAmnt { get; set; }
        public Nullable<decimal> BalanceAmnt { get; set; }
        public string FromTable { get; set; }
    }
}
