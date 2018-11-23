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
            ddlFilerBy.SelectedIndex = 0;
            lstProduct.Items.Clear();
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
                    CreateReport(connectionstring, "CommonReport", sqlParams);
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
                    CreateReport(connectionstring, "CommonReport", sqlParams);
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

    
        public void CreateReport(String connectionstring, string storeProcedureName, SqlParameter[] parameter)
        {         
            var ds = Common.FillDataSet(connectionstring, storeProcedureName, parameter);

            if(ds!=null)
            { 
                if (ds.Tables["Table"].Rows.Count > 0)
                { 
                    lblCompanyName.Text = ds.Tables["Table"].Rows[0]["Company"].ToString();
                    lblAddress.Text = ds.Tables["Table"].Rows[0]["CompanyAddress"].ToString();
                    lblStartDate.Text = ds.Tables["Table"].Rows[0]["StartDate"].ToString();
                    lblEndDate.Text = ds.Tables["Table"].Rows[0]["EndDate"].ToString();
                    lblpartyname.Text = ds.Tables["Table"].Rows[0]["Party"].ToString();
                lblpartyaddress.Text = ds.Tables["Table"].Rows[0]["PartyAddress"].ToString();
                 } 
                

                ds.Tables["Table"].Columns.Remove("Company");
                ds.Tables["Table"].Columns.Remove("CompanyAddress");
                ds.Tables["Table"].Columns.Remove("StartDate");
                ds.Tables["Table"].Columns.Remove("EndDate");
                ds.Tables["Table"].Columns.Remove("Party");
                ds.Tables["Table"].Columns.Remove("PartyAddress");
                grdreport.DataSource = ds.Tables["Table"];
                grdreport.DataBind();
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

        protected void grdreport_DataBound(object sender, EventArgs e)
        {
            int firstRowSpan = 2;
            int secondRowSpan = 2;
            for (int i = grdreport.Rows.Count - 2; i >= 0; i--)
            {
                GridViewRow currRow = grdreport.Rows[i];
                GridViewRow prevRow = grdreport.Rows[i + 1];
                if (currRow.Cells[1].Text == prevRow.Cells[1].Text)
                {
                    currRow.Cells[1].RowSpan = firstRowSpan;
                    prevRow.Cells[1].Visible = false;
                    firstRowSpan += 1;

                    currRow.Cells[0].RowSpan = secondRowSpan;
                    prevRow.Cells[0].Visible = false;
                    secondRowSpan += 1;
                }
                else
                {
                    firstRowSpan = 2;
                    secondRowSpan = 2;
                }
            }
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