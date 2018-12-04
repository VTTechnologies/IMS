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
    
    public partial class tbl_state
    {
        public tbl_state()
        {
            this.tbl_branch = new HashSet<tbl_branch>();
            this.tbl_company = new HashSet<tbl_company>();
            this.tbl_party = new HashSet<tbl_party>();
        }
    
        public int state_id { get; set; }
        public Nullable<int> country_id { get; set; }
        public string state_name { get; set; }
        public Nullable<bool> status { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
    
        public virtual ICollection<tbl_branch> tbl_branch { get; set; }
        public virtual ICollection<tbl_company> tbl_company { get; set; }
        public virtual tbl_country tbl_country { get; set; }
        public virtual ICollection<tbl_party> tbl_party { get; set; }
    }
}
