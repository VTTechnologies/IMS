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
    
    public partial class tbl_category
    {
        public tbl_category()
        {
            this.tbl_product = new HashSet<tbl_product>();
        }
    
        public int category_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> branch_id { get; set; }
        public string category_name { get; set; }
        public Nullable<bool> status { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
    
        public virtual tbl_branch tbl_branch { get; set; }
        public virtual tbl_company tbl_company { get; set; }
        public virtual ICollection<tbl_product> tbl_product { get; set; }
    }
}
