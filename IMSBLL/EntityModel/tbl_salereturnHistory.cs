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
    
    public partial class tbl_salereturnHistory
    {
        public int Id { get; set; }
        public Nullable<int> salereturn_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> branch_id { get; set; }
        public Nullable<int> sale_id { get; set; }
        public Nullable<int> financialyear_id { get; set; }
        public Nullable<decimal> total_tax { get; set; }
        public Nullable<decimal> total_discount { get; set; }
        public Nullable<decimal> total_amount { get; set; }
        public Nullable<decimal> grand_total { get; set; }
        public Nullable<bool> status { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public Nullable<int> paymentmode_id { get; set; }
        public Nullable<decimal> given_amnt { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<decimal> balance_amnt { get; set; }
        public Nullable<int> party_id { get; set; }
    }
}
