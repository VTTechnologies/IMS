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
    
    public partial class tbl_unit
    {
        public tbl_unit()
        {
            this.tbl_product = new HashSet<tbl_product>();
            this.tbl_purchasedetails = new HashSet<tbl_purchasedetails>();
            this.tbl_purchasereturndetails = new HashSet<tbl_purchasereturndetails>();
            this.tbl_saledetails = new HashSet<tbl_saledetails>();
            this.tbl_salereturndetails = new HashSet<tbl_salereturndetails>();
        }
    
        public int unit_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> branch_id { get; set; }
        public string unit_name { get; set; }
        public Nullable<bool> status { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
    
        public virtual tbl_branch tbl_branch { get; set; }
        public virtual tbl_company tbl_company { get; set; }
        public virtual ICollection<tbl_product> tbl_product { get; set; }
        public virtual ICollection<tbl_purchasedetails> tbl_purchasedetails { get; set; }
        public virtual ICollection<tbl_purchasereturndetails> tbl_purchasereturndetails { get; set; }
        public virtual ICollection<tbl_saledetails> tbl_saledetails { get; set; }
        public virtual ICollection<tbl_salereturndetails> tbl_salereturndetails { get; set; }
    }
}
