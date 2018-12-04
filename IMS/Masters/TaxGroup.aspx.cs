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
                if (ViewState["Details"] == null)
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Columns.Add("type_name");
                    dataTable.Columns.Add("type_id");
                    dataTable.Columns.Add("tax_percentage");
                    ViewState["Details"] = dataTable;
                }
                if (!IsPostBack)
                {
                    lbTaxBind();
                }      
               
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

        protected void BindGrid()
        {
            try
            {
                gvtaxdetails.DataSource = (DataTable)ViewState["Details"];
                gvtaxdetails.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }
        public void lbTaxBind()
        {

            List<tbl_taxtype> cd = context.tbl_taxtype.Where(x => x.status == true && x.company_id == companyId && x.branch_id == branchId).ToList();
            ddlTaxType.DataTextField = "type_name";
            ddlTaxType.DataValueField = "type_id";
            ddlTaxType.DataSource = cd;
            ddlTaxType.DataBind();
            ddlTaxType.Items.Insert(0, new ListItem("Select Tax Type", "0"));
        }

        public void Save()
        {

        }
        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
             catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           

            try
            {
                if (ViewState["type_id"] != null && ViewState["type_name"]!=null)
                {
                     int TypeId = Convert.ToInt32(ViewState["type_id"]);
                     string TypeName = ViewState["type_name"].ToString();
                     int txtpercentage = 0;
                    //TextBox txtpercentage = (TextBox)gvtaxdetails.FooterRow.FindControl("tax_percentage");
                     DataTable tbl = (DataTable)ViewState["Details"];

                     tbl.Rows.Add(TypeName, TypeId, txtpercentage);
                            ViewState["Details"] = tbl;
                            this.BindGrid();

                }

                
                //var productDetails = context.sp_GetSaleDetailsById(saleId).ToList();
                //if (productDetails != null)
                //{
                //    var oneproductDetail = productDetails.Where(w => w.product_id == productId);
                //    if (!Convert.ToBoolean(ValidateQuantity(enteredQuantity, productId, saleId)[0]))
                //    {
                //        decimal subTotal = Convert.ToDecimal(txtquantity.Text) * Convert.ToDecimal(oneproductDetail.FirstOrDefault().sale_rate);
                //        decimal a = subTotal / 100;
                //        decimal discount_percent = (Convert.ToDecimal(oneproductDetail.FirstOrDefault().dicount_amt) * 100) / Convert.ToDecimal(oneproductDetail.FirstOrDefault().amount);
                //        decimal discountamt = a * Convert.ToDecimal(discount_percent.ToString("0.##"));
                //        decimal tax_amount = a * Convert.ToDecimal(oneproductDetail.FirstOrDefault().tax_percentage);

                //        clr();
                //        calculation(subTotal, tax_amount, discountamt);
                //        txtGivenAmt.Enabled = true;

                //        DataTable tbl = (DataTable)ViewState["Details"];

                //        tbl.Rows.Add(oneproductDetail.FirstOrDefault().saledetails_id, productId, oneproductDetail.FirstOrDefault().batch_id, oneproductDetail.FirstOrDefault().unit_id,
                //            oneproductDetail.FirstOrDefault().tax_id, subTotal, discountamt, tax_amount, oneproductDetail.FirstOrDefault().sale_rate, enteredQuantity,
                //            oneproductDetail.FirstOrDefault().product_name, oneproductDetail.FirstOrDefault().unit_name, oneproductDetail.FirstOrDefault().batch_name,
                //            oneproductDetail.FirstOrDefault().tax_percentage);
                //        ViewState["Details"] = tbl;
                //        this.BindGrid();
                //        ddlproduct.Items.FindByValue(productId.ToString()).Enabled = false;

                //    }
                //}
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

   

        protected void ddlTaxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ViewState["type_id"] = ddlTaxType.SelectedValue;
                ViewState["type_name"] = ddlTaxType.SelectedItem.Text;
               // hdntypeId.Value = ddlTaxType.SelectedValue;
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }
    }
}