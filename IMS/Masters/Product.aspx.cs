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
using System.Configuration;

namespace IMS
{
    public partial class Product : System.Web.UI.Page
    {
        /// <summary>
        /// All The objects That are used in coding
        /// </summary>
        #region object
        IMS_TESTEntities context = new IMS_TESTEntities();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
        int companyId;
        int branchId;
        string User_id;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                SessionValue();
                if (!IsPostBack)
                {
                    PageLoad();
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

        private void PageLoad()
        {
           
            ddlcategorybind();
            ddlunitbind();
            ddlgodownbind();
            ddltaxbind();
            loadDataTable();
            ddlCategory.Focus();
        }
        private void SessionValue()
        {
            User_id = Convert.ToString(Session["UserID"]);
            companyId = Convert.ToInt32(Session["company_id"]);
            branchId = Convert.ToInt32(Session["branch_id"]);
        }
        private void loadDataTable()
        {

            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "sp_SelectProduct";
            //cmd.Parameters.AddWithValue("@company_id", c_id);
            //cmd.Parameters.AddWithValue("@branch_id", b_id);
            //cmd.Connection = con;

            try
            {

                //con.Open();
                //DataSet ds = new DataSet();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(ds);
                GridView1.DataSource = context.sp_SelectProduct(companyId,branchId); //ds.Tables[0]; 
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        [System.Web.Services.WebMethod]
        public static string CheckDouble(string useroremail)
        {
            try
            {
                if (HttpContext.Current.Session["company_id"] != null)
                {
                    SqlHelper helper = new SqlHelper();
                    DataTable data = helper.CheckDoubleValues(Convert.ToInt32(HttpContext.Current.Session["company_id"]), Convert.ToInt32(HttpContext.Current.Session["branch_id"]), "tbl_product", "product_code", useroremail);
                    if (data.Rows.Count > 0)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return "true";
        }

        [System.Web.Services.WebMethod]
        public static string CheckDouble1(string useroremail)
        {
            try
            {
                if (HttpContext.Current.Session["company_id"] != null)
                {
                    SqlHelper helper = new SqlHelper();
                    DataTable data = helper.CheckDoubleValues(Convert.ToInt32(HttpContext.Current.Session["company_id"]), Convert.ToInt32(HttpContext.Current.Session["branch_id"]), "tbl_product", "product_name", useroremail);
                    if (data.Rows.Count > 0)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return "true";
        }
        public void ddlcategorybind()
        {
            
            List<tbl_category> cd = context.tbl_category.Where(x => x.status == true && x.company_id == companyId && x.branch_id == branchId).ToList();
            ddlCategory.DataTextField = "category_name";
            ddlCategory.DataValueField = "category_id";
            ddlCategory.DataSource = cd;
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }
        public void ddlunitbind()
        {
            List<tbl_unit> cd = context.tbl_unit.Where(x => x.status == true && x.company_id == companyId && x.branch_id == branchId).ToList();
            ddlUnit.DataTextField = "unit_name";
            ddlUnit.DataValueField = "unit_id";
            ddlUnit.DataSource = cd;
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("--Select Unit--", "0"));
        }

        public void ddlgodownbind()
        {
            List<tbl_godown> gd = context.tbl_godown.Where(x => x.status == true && x.company_id == companyId && x.branch_id == branchId).ToList();

            ddlGodown.DataTextField = "godown_name";
            ddlGodown.DataValueField = "godown_id";
            ddlGodown.DataSource = gd;
            ddlGodown.DataBind();
            ddlGodown.Items.Insert(0, new ListItem("--Select Godown--", "0"));
        }
        public void ddlrackbind(int godownid)
        {
            int g_id = Convert.ToInt32(ddlGodown.SelectedValue);
            List<tbl_rack> cd = context.tbl_rack.Where(x => x.status == true && x.company_id == companyId && x.branch_id == branchId && x.godown_id==godownid).ToList();
            ddlRack.DataTextField = "rack_name";
            ddlRack.DataValueField = "rack_id";
            ddlRack.DataSource = cd;
            ddlRack.DataBind();
            ddlRack.Items.Insert(0, new ListItem("--Select Rack--", "0"));
            if (cd.Count == 0)
            {
                lblrackerror.Text = "No rack found ";
            }
            else
            {
                lblrackerror.Text = string.Empty;
            }
        }
        public void ddltaxbind()
        {
              List<tbl_tax> cd = context.tbl_tax.Where(x => x.status == true && x.company_id == companyId && x.branch_id==branchId).ToList();
            ddlTax.DataTextField = "tax_name";
            ddlTax.DataValueField = "tax_id";
            ddlTax.DataSource = cd;
            ddlTax.DataBind();
            ddlTax.Items.Insert(0, new ListItem("--Select Tax--", "0"));
        }

        private void savedcode()
        {
            try
            {
                if (hd.Value == "false")
                {
                    if (hde.Value == "false")
                    {
                        Label1.Text = String.Empty;
                        lblcheckDoubleError.Text = String.Empty;
                        tbl_product product = new tbl_product();
                        product.company_id = companyId;
                        product.branch_id = branchId;
                        product.category_id = Int32.Parse(ddlCategory.SelectedValue);
                        product.unit_id = Int32.Parse(ddlUnit.SelectedValue);
                        product.godown_id = Int32.Parse(ddlGodown.SelectedValue);
                        product.rack_id = Int32.Parse(ddlRack.SelectedValue);
                        product.tax_id = Int32.Parse(ddlTax.SelectedValue);
                        product.product_name = txtProductName.Text;
                        product.product_code = txtProductCode.Text;
                        product.hsn_code = txtHSNCode.Text;
                        product.reorder_level = Int32.Parse(txtReorderqty.Text);
                        product.purchas_price = decimal.Parse(txtPurchasePrice.Text);
                        product.sales_price = decimal.Parse(txtSalesPrice.Text);
                        product.created_by = User_id;
                        product.created_date = DateTime.Today;
                        product.status = true;
                        product.modified_by = "";
                        product.modified_date = null;
                        ////Shakeeb
                        ////pd.Insert(pd);
                        //Entity Framework Saving Awais
                        context.tbl_product.Add(product);
                        context.SaveChanges();
                        loadDataTable();
                        clr();
                        divalert.Visible = true;
                        lblAlert.Text = "Product Saved Successfully ";


                        
                        //context.tbl_product.Add(pd);
                        //context.SaveChanges();
                    }
                    else
                    {
                        divalert.Visible = false;
                        lblcheckDoubleError.ForeColor = System.Drawing.Color.Red;
                        lblcheckDoubleError.Text = "This Product Code name already Exists";
                    }

                }
                else
                {
                    divalert.Visible = false;
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "This Product name already Exists";
                }
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        private void updatecode()
        {
            try
            {
                if (hd.Value != "true")
                {
                    if (hde.Value != "true")
                    {
                        Label1.Text = string.Empty;
                        lblcheckDoubleError.Text = String.Empty;
                        GridViewRow row = GridView1.SelectedRow;
                        int product_id = Convert.ToInt32(ViewState["tax_id"]);
                        decimal sales_price = decimal.Parse(txtSalesPrice.Text);
                        decimal purchase_price = decimal.Parse(txtPurchasePrice.Text);
                        int cat_id = Int32.Parse(ddlCategory.SelectedValue);
                        int unit_id = Int32.Parse(ddlUnit.SelectedValue);
                        int godown_id = Int32.Parse(ddlGodown.SelectedValue);
                        int rack_id = Int32.Parse(ddlRack.SelectedValue);
                        int tax_id = Int32.Parse(ddlTax.SelectedValue);
                        int orderlevel = Convert.ToInt32(txtReorderqty.Text);
                        context.sp_UpdateProduct(companyId, branchId, product_id, cat_id, rack_id, godown_id, tax_id, unit_id, orderlevel, purchase_price, sales_price, txtProductCode.Text, txtHSNCode.Text, txtProductName.Text, User_id, DateTime.Today);
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                        divalert.Visible = true;
                        clr();
                        loadDataTable();
                        lblAlert.Text = "Product Updated Successfully ";
                    }
                    else
                    {
                        divalert.Visible = false;
                        lblcheckDoubleError.ForeColor = System.Drawing.Color.Red;
                        lblcheckDoubleError.Text = "This Product Code name already Exists";
                    }
                }
                else
                {
                    divalert.Visible = false;
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "This Product Name already Exists";
                }
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        public void clr()
        {
            txtHSNCode.Text = string.Empty;
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtPurchasePrice.Text = string.Empty;
            txtReorderqty.Text = string.Empty;
            txtSalesPrice.Text = string.Empty;
            ddlCategory.SelectedIndex = 0;
            ddlGodown.SelectedIndex = 0;
            ddlRack.SelectedIndex = 0;
            ddlTax.SelectedIndex = 0;
            ddlUnit.SelectedIndex = 0;
        }

        #endregion
        /// <summary>
        /// All The Events That are used in coding
        /// </summary>

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            savedcode();
        }

        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = String.Empty;
                lblcheckDoubleError.Text = String.Empty;
                GridViewRow row = GridView1.SelectedRow;
                ViewState["tax_id"] = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
                //int taxId = GridView1.SelectedIndex;
                ddlCategory.SelectedValue=row.Cells[10].Text;
                ddlUnit.SelectedValue = (row.Cells[14].Text);
                ddlGodown.SelectedValue = (row.Cells[11].Text);
                ddlRack.SelectedValue = (row.Cells[12].Text);
                ddlTax.SelectedValue = (row.Cells[13].Text);
                txtPurchasePrice.Text = row.Cells[7].Text;
                txtSalesPrice.Text = row.Cells[6].Text;
                txtProductName.Text = row.Cells[1].Text;
                txtProductCode.Text = row.Cells[8].Text;
                txtHSNCode.Text = row.Cells[15].Text;
                txtReorderqty.Text = row.Cells[9].Text;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                divalert.Visible = false;
                ddlCategory.Focus();
                hde.Value = string.Empty;
                hd.Value = string.Empty;
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }


        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updatecode();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    
                    ViewState["rowIndex"] = Convert.ToInt32(e.CommandArgument);
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
                    divalert.Visible = false;
                   
                }
            }

              catch (Exception ex)
            {
               
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = Convert.ToInt32(ViewState["rowIndex"]);

                context.sp_DeleteProduct(companyId, rowIndex);
                divalert.Visible = true;
                lblAlert.Text = "Product Deleted Successfully ";
                clr();
                loadDataTable();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                lblcheckDoubleError.Text = String.Empty;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                divalert.Visible = false;
                clr();
                ViewState["gridrow"] = null;
                hde.Value = string.Empty;
                hd.Value = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            clr();
        }

        protected void ddlGodown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lblrackerror.Text = string.Empty;
                int g_id = Convert.ToInt32(ddlGodown.SelectedValue);
                ddlrackbind(g_id);
                UpdatePanel1.Update();

            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        #endregion
    }
}