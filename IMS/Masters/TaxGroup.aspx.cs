using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IMSBLL.EntityModel;
using IMSBLL.DAL;

namespace IMS.Masters
{
    public partial class TaxGroup : System.Web.UI.Page
    {
        /// <summary>
        /// All The objects That are used in coding
        /// </summary>
        #region object
        IMS_TESTEntities context = new IMS_TESTEntities();
        int companyId;
        int branchId;
        string User_id;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SessionValue();
                lbTaxBind();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        /// <summary>
        /// All The Methods That are used in coding
        /// </summary>

        #region Methods
        private void SessionValue()
        {
            User_id = Convert.ToString(Session["UserID"]);
            companyId = Convert.ToInt32(Session["company_id"]);
            branchId = Convert.ToInt32(Session["branch_id"]);
        }

        public void lbTaxBind()
        {

            List<tbl_tax> cd = context.tbl_tax.Where(x => x.status == true && x.company_id == companyId && x.branch_id == branchId).ToList();
            lbTax.DataTextField = "tax_name";
            lbTax.DataValueField = "tax_id";
            lbTax.DataSource = cd;
            lbTax.DataBind();
            lbTax.Items.Insert(0, new ListItem("--Select Tax--", "0"));
        }
        #endregion
    }
}