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
    
    public partial class tbl_branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_branch()
        {
            this.tbl_batch = new HashSet<tbl_batch>();
            this.tbl_category = new HashSet<tbl_category>();
            this.tbl_error_log = new HashSet<tbl_error_log>();
            this.tbl_expense = new HashSet<tbl_expense>();
            this.tbl_expenseentry = new HashSet<tbl_expenseentry>();
            this.tbl_financialyear = new HashSet<tbl_financialyear>();
            this.tbl_godown = new HashSet<tbl_godown>();
            this.tbl_mony = new HashSet<tbl_mony>();
            this.tbl_monytransaction = new HashSet<tbl_monytransaction>();
            this.tbl_party = new HashSet<tbl_party>();
            this.tbl_paymentmode = new HashSet<tbl_paymentmode>();
            this.tbl_product = new HashSet<tbl_product>();
            this.tbl_purchase = new HashSet<tbl_purchase>();
            this.tbl_purchase1 = new HashSet<tbl_purchase>();
            this.tbl_rack = new HashSet<tbl_rack>();
            this.tbl_stock = new HashSet<tbl_stock>();
            this.tbl_stocktransaction = new HashSet<tbl_stocktransaction>();
            this.tbl_tax = new HashSet<tbl_tax>();
            this.tbl_taxgroup = new HashSet<tbl_taxgroup>();
            this.tbl_taxtype = new HashSet<tbl_taxtype>();
            this.tbl_unit = new HashSet<tbl_unit>();
            this.tbl_userbranch = new HashSet<tbl_userbranch>();
            this.tbl_purchasereturn = new HashSet<tbl_purchasereturn>();
            this.tbl_sale = new HashSet<tbl_sale>();
            this.tbl_salereturn = new HashSet<tbl_salereturn>();
        }
    
        public int branch_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string branch_address { get; set; }
        public Nullable<int> country_id { get; set; }
        public Nullable<int> state_id { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
        public string telephone_no { get; set; }
        public string mobile_no { get; set; }
        public string fax_no { get; set; }
        public string email_id { get; set; }
        public string manager_name { get; set; }
        public string manager_address { get; set; }
        public string manager_mobileno { get; set; }
        public string manager_emailid { get; set; }
        public Nullable<bool> status { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string modified_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public Nullable<bool> IsMainBranch { get; set; }
        public string branch_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_batch> tbl_batch { get; set; }
        public virtual tbl_company tbl_company { get; set; }
        public virtual tbl_country tbl_country { get; set; }
        public virtual tbl_state tbl_state { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_category> tbl_category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_error_log> tbl_error_log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_expense> tbl_expense { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_expenseentry> tbl_expenseentry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_financialyear> tbl_financialyear { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_godown> tbl_godown { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_mony> tbl_mony { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_monytransaction> tbl_monytransaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_party> tbl_party { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_paymentmode> tbl_paymentmode { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_product> tbl_product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_purchase> tbl_purchase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_purchase> tbl_purchase1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_rack> tbl_rack { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_stock> tbl_stock { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_stocktransaction> tbl_stocktransaction { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_tax> tbl_tax { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_taxgroup> tbl_taxgroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_taxtype> tbl_taxtype { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_unit> tbl_unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_userbranch> tbl_userbranch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_purchasereturn> tbl_purchasereturn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_sale> tbl_sale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_salereturn> tbl_salereturn { get; set; }
    }
}
