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
using System.IO;
using IMS.Reports;

namespace IMS.Reports
{
    public partial class CommonReport : System.Web.UI.Page
    {
        IMS_TESTEntities context = new IMS_TESTEntities();
        string connectionstring = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;         
        int companyId, branchId;
        string User_id;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionValue();
            if (!IsPostBack)
            {               
                BindProducts();
                BindVendors();
                BindCustomers();
            }                               
            logo();
        }

        private void BindProducts()
        {
            var products = context.tbl_product.Where(w => w.company_id == companyId).ToList();
            lstProduct.DataTextField = "product_name";
            lstProduct.DataValueField = "product_id";
            lstProduct.DataSource = products;
            lstProduct.DataBind();
        }
        private void BindVendors()
        {
            var party = context.tbl_party.Where(w => w.company_id == companyId && w.party_type == "Vendor").ToList();
            lstVendor.DataTextField = "party_name";
            lstVendor.DataValueField = "party_id";
            lstVendor.DataSource = party;
            lstVendor.DataBind();
        }
        private void BindCustomers()
        {
            var party = context.tbl_party.Where(w => w.company_id == companyId && w.party_type == "Customer").ToList();
            lstCustomers.DataTextField = "party_name";
            lstCustomers.DataValueField = "party_id";
            lstCustomers.DataSource = party;
            lstCustomers.DataBind();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            displayReportSection.Visible = false;
            ddlReportType.SelectedIndex = 0;         
            txtStartDate.Text = string.Empty;
            txtenddate.Text = string.Empty;           
            ddlFilerBy.Enabled = true;
            txtStartDate.Enabled = true;
            txtenddate.Enabled = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            displayReportSection.Visible = true;
            var filterIds = string.Empty;
            foreach (ListItem item in lstProduct.Items)
            {
                if (item.Selected)
                {
                    filterIds += item.Value + ",";
                }
            }

            foreach (ListItem item in lstVendor.Items)
            {
                if (item.Selected)
                {
                    filterIds += "," + item.Value;
                }
            }
            if (ddlReportType.SelectedItem.Text != "Stock Report")
            {
                btnSearch.ValidationGroup = "search";
            }

            SqlParameter[] sqlParams;
            int companyId = Convert.ToInt32(Session["company_id"]);

            string reportDataSet = string.Empty;
            string dataTable = string.Empty;
            CommonDataSet ds = new CommonDataSet();
            switch (ddlReportType.SelectedItem.Text)
            {

                case "Stock Report":
                    sqlParams = new SqlParameter[] {
                         new SqlParameter("@ReportType","STOCKREPORT"),
                         new SqlParameter("@CompanyId", companyId),
                          new SqlParameter("@start_date",txtStartDate.Text),
                           new SqlParameter("@end_date",txtenddate.Text),
                          new SqlParameter("@FilterIds",filterIds)
                    };

                    reportDataSet = "ProductWiseStockDataSet";
                    dataTable = "ProductWiseStockReport";
                    CreateReport(connectionstring, "CommonReport", sqlParams, reportDataSet, dataTable);
                    break;


                case "Inventory Report":
                    sqlParams = new SqlParameter[] {
                         new SqlParameter("@ReportType","PRODUCTINVENTORYREPORT"),
                         new SqlParameter("@CompanyId", companyId),
                          new SqlParameter("@start_date",txtStartDate.Text),
                           new SqlParameter("@end_date",txtenddate.Text),
                          new SqlParameter("@FilterIds",filterIds)
                    };
                    reportDataSet = "CombineDataSet";
                    dataTable = "CombineDataTable";
                    CreateReport(connectionstring, "CommonReport", sqlParams, reportDataSet, dataTable);
                    break;

                default:
                    break;
            }

        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReportType.SelectedItem.Text == "Stock Report")
            {
                ddlFilerBy.Enabled = false;
                txtenddate.Enabled = false;
                txtStartDate.Enabled = false;
            }
            else {
                ddlFilerBy.Enabled = true;
                txtenddate.Enabled = true;
                txtStartDate.Enabled = true;
            }
        }

    
        public void CreateReport(String connectionstring, string storeProcedureName, SqlParameter[] parameter, string reportDataSource, string tableName)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = storeProcedureName;
                if (parameter != null)
                {
                    com.Parameters.AddRange(parameter);
                }
                CommonDataSet ds = new CommonDataSet();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds, tableName);   
                
                           
                grdreport.DataSource = ds.Tables[tableName];
                grdreport.DataBind();               

                for (int i = 0; i < ds.Tables[tableName].Rows.Count; i++)
                {     

                    lblCompanyName.Text = ds.Tables[tableName].Rows[i]["Company"].ToString();
                    lblAddress.Text = ds.Tables[tableName].Rows[i]["CompanyAddress"].ToString();
                   

                    lbldate.Text = ds.Tables[tableName].Rows[i]["Date"].ToString();
                    lblpartyname.Text = ds.Tables[tableName].Rows[i]["Party"].ToString();
                    lblpartyaddress.Text = ds.Tables[tableName].Rows[i]["PartyAddress"].ToString();
                    lblinvoiceno.Text = ds.Tables[tableName].Rows[i]["InvoiceNumber"].ToString();                   
                }

              
            }
        }

        protected void ddlFilerBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFilerBy.SelectedItem.Text == "Product Wise")
            {
                BindProducts();
                Products.Visible = true;
                Vendors.Visible = false;
                Customers.Visible = false;
            }
            else if (ddlFilerBy.SelectedItem.Text == "Vendor Wise")
            {
                BindVendors();
                Vendors.Visible = true;
                Customers.Visible = false;
                Products.Visible = false;
            }
            else if (ddlFilerBy.SelectedItem.Text == "Cutomer Wise")
            {
                BindCustomers();
                Vendors.Visible = false;
                Products.Visible = false;
                Customers.Visible = true;
            }
        }            
        private void SessionValue()
        {
            if (Session["UserID"] == null || Session["company_id"] == null || Session["branch_id"] == null)
            {
                Response.Redirect("~/Registration/Login.aspx");
            }
            User_id = Convert.ToString(Session["UserID"]);
            companyId = Convert.ToInt32(Session["company_id"]);
            branchId = Convert.ToInt32(Session["branch_id"]);
        }       
        public void logo()
        {
            var logo = context.tbl_company.Where(w => w.company_id == companyId).FirstOrDefault();
            try
            {
               
                if (logo != null)
                {

                    if (File.Exists(Server.MapPath(logo.logo)))
                    {
                        imglogo.ImageUrl = logo.logo;
                    }
                    else
                    {
                        imglogo.Visible = false;
                        lblIms.Visible = true;
                    }
                }
                else
                {
                    imglogo.Visible = false;
                    lblIms.Visible = true;
                }               
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }            
        }
       
    }
}