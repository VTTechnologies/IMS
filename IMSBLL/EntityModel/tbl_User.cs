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
    
    public partial class tbl_User
    {
        public tbl_User()
        {
            this.tbl_paidpayment = new HashSet<tbl_paidpayment>();
            this.tbl_subscription = new HashSet<tbl_subscription>();
            this.tbl_userbranch = new HashSet<tbl_userbranch>();
            this.tbl_userrole = new HashSet<tbl_userrole>();
        }
    
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_Emai { get; set; }
        public string user_mobieno { get; set; }
        public string password { get; set; }
        public Nullable<int> retry_attempts { get; set; }
        public Nullable<System.DateTime> last_login { get; set; }
        public Nullable<bool> islocked { get; set; }
        public Nullable<System.DateTime> locked_date { get; set; }
        public Nullable<bool> status { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    
        public virtual ICollection<tbl_paidpayment> tbl_paidpayment { get; set; }
        public virtual ICollection<tbl_subscription> tbl_subscription { get; set; }
        public virtual ICollection<tbl_userbranch> tbl_userbranch { get; set; }
        public virtual ICollection<tbl_userrole> tbl_userrole { get; set; }
    }
}
