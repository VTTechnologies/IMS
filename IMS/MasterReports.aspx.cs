using IMS.Reports;
using IMSBLL.EntityModel;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IMS
{
    public partial class MasterReports : System.Web.UI.Page
    {
        string Connectionstring = ConfigurationManager.ConnectionStrings["TestDBConnection"].ToString();
        IMS_TESTEntities context = new IMS_TESTEntities();
        int companyId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionValue();
            if (!Page.IsPostBack)
            {
                BindProducts();
                BindVendors();
                BindCustomers();
            }
        }
        private void SessionValue()
        {
            if (Session["company_id"] == null)
            {
                Response.Redirect("~/Registration/Login.aspx");
            }          
            companyId = Convert.ToInt32(Session["company_id"]);
           
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
        
        #region Events
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlReportType.SelectedIndex = 0;
           // ddlVendor.SelectedIndex = 0;
            //txtInvoiceNo.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtenddate.Text = string.Empty;
            ReportViewer1.Visible = false;
            ddlFilerBy.Enabled = true;
            txtStartDate.Enabled = true;
            txtenddate.Enabled = true;
        }
      
        protected void btnSearch_Click(object sender, EventArgs e)
        {
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
            ReportParameter reportParam;
            ReportViewer1.Visible = true;
            int companyId = Convert.ToInt32(Session["company_id"]);
            var logo = context.tbl_company.Where(w => w.company_id == companyId).Select(s => s.logo).SingleOrDefault();
            string logoPath = new Uri(Server.MapPath(logo)).AbsoluteUri;

            string reportDataSet = string.Empty;
            string dataTable = string.Empty;

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
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/ProductWiseStockReport.rdlc");
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    reportDataSet = "ProductWiseStockDataSet";
                    dataTable = "ProductWiseStockReport";
                    reportParam = new ReportParameter("LogoPath", logoPath);
                    ReportViewer1.LocalReport.SetParameters(reportParam);
                    CreateReport(Connectionstring, "CommonReport", sqlParams, ref ReportViewer1, reportDataSet, dataTable);

                    ReportViewer1.LocalReport.Refresh();
                    break;

                case "Inventory Report":
                    sqlParams = new SqlParameter[] {
                         new SqlParameter("@ReportType","PRODUCTINVENTORYREPORT"),
                         new SqlParameter("@CompanyId", companyId),
                          new SqlParameter("@start_date",txtStartDate.Text),
                           new SqlParameter("@end_date",txtenddate.Text),
                          new SqlParameter("@FilterIds",filterIds) 
                    };
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/ProductWiseStockReport.rdlc");
                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    reportDataSet = "ProductWiseStockDataSet";
                    dataTable = "ProductWiseStockReport";
                    reportParam = new ReportParameter("LogoPath", logoPath);
                    ReportViewer1.LocalReport.SetParameters(reportParam);
                    CreateReport(Connectionstring, "CommonReport", sqlParams, ref ReportViewer1, reportDataSet, dataTable);

                    ReportViewer1.LocalReport.Refresh();
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

        //protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlFilerBy.SelectedItem.Text == "Stock Report")
        //    {
        //        ddlFilerBy.Enabled = false;
        //        txtenddate.Enabled = false;
        //        txtStartDate.Enabled = false;
        //    }
        //    else {
        //        ddlFilerBy.Enabled = true;
        //        txtenddate.Enabled = true;
        //        txtStartDate.Enabled = true;
        //    }
        //}

        public void CreateReport(String connectionstring, string storeProcedureName, SqlParameter[] parameter, ref Microsoft.Reporting.WebForms.ReportViewer reportViewer, string reportDataSource, string tableName)
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
                ReportDataSource datasource = new ReportDataSource(reportDataSource, ds.Tables[tableName]);
               
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(datasource);
               
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
        #endregion
    }
}