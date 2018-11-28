﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSBLL;
using IMSBLL.EntityModel;
using IMSBLL.DAL;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
namespace IMS
{
    public partial class Index : System.Web.UI.Page
    {
        /// <summary>
        /// All The objects That are used in coding
        /// </summary>
        #region object
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
        IMS_TESTEntities context = new IMS_TESTEntities();
        SqlHelper sh = new SqlHelper();
        List<DashboardOrderTableViewModel> details = new List<DashboardOrderTableViewModel>();
        int companyId;
        int branchId;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionValue();
            if (!IsPostBack)
            {
                GetcompanyInfo();
                FillDashboardInfo();
                fypopup();
            }
        }

        #region Functions are here
        private void SessionValue()
        {
            if (Session["UserID"] == null || Session["company_id"] == null || Session["branch_id"] == null || Session["financialyear_id"] == null)
            {
                Response.Redirect("~/Registration/Login.aspx");
            }
            companyId = Convert.ToInt32(Session["company_id"]);
            branchId = Convert.ToInt32(Session["branch_id"]);
        }

        public void BindGrid(List<DashboardOrderTableViewModel> list)
        {

            gvorderDeatils.DataSource = list;
            gvorderDeatils.DataBind();

        }
        private List<DashboardOrderTableViewModel> OrderDetails(string orderTypeFlag)
        {
            try
            {
                ViewState["ordertypeflag"] = orderTypeFlag;
                DateTime startdate = DateTime.Now.AddDays(-30);

                if (orderTypeFlag == "Purchase")
                {
                    details = (from s in context.tbl_purchase
                               join p in context.tbl_party on s.company_id equals p.company_id
                               join pd in context.tbl_PurchasePaymentDetials on s.purchase_id equals pd.PurchaseId
                               where s.company_id == companyId && s.party_id == p.party_id && s.status == true && s.created_date >= startdate
                               && s.created_date <= DateTime.Now
                               select new DashboardOrderTableViewModel
                               {
                                   InvoiceNumber = s.InvoiceNumber,
                                   PartyName = p.party_name,
                                   TotalTax = pd.TaxAmount,
                                   TotalAmount = pd.SubTotal,
                                   TotalDiscount = pd.DiscountAmount,
                                   GrandTotal = pd.GrandTotal,
                                   GivenAmnt = pd.GivenAmnt,
                                   BalanceAmnt = pd.BalanceAmnt,
                                   ID = s.purchase_id,
                                   Date = s.created_date
                               }).ToList();

                }
                else if (orderTypeFlag == "Sale")
                {
                    details = (from s in context.tbl_sale
                               join p in context.tbl_party on s.company_id equals p.    company_id
                               join sd in context.tbl_SalePaymentDetails on s.sale_id equals sd.SaleId
                               where s.company_id == companyId && s.company_id == companyId && s.party_id == p.party_id && s.status == true && s.created_date >= startdate
                               && s.created_date <= DateTime.Now
                               select new DashboardOrderTableViewModel
                               {
                                   InvoiceNumber = s.InvoiceNumber,
                                   PartyName = p.party_name,
                                   TotalTax = sd.TaxAmount,
                                   TotalAmount = sd.SubTotal,
                                   TotalDiscount = sd.DiscountAmount,
                                   GrandTotal = sd.GrandTotal,
                                   GivenAmnt = sd.GivenAmnt,
                                   BalanceAmnt = sd.BalanceAmnt,
                                   ID = s.sale_id,
                                   Date = s.created_date
                               }).ToList();

                }

                gvorderDeatils.DataSource = details;
                gvorderDeatils.DataBind();
                lblModelHeader.Text = orderTypeFlag + " Order In Last 30 Days";
                return details;
               

            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return details;
        }
        private void fypopup()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_last15daysf_year";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandTimeout = 600000;
            con.Open();
            int mcid = 0;
            int end_days = 0;
            int days_flag = 0;
            int c_id = Convert.ToInt32(Session["company_id"]);
            try
            {
                if (c_id != 0)
                {

                    cmd.Parameters.AddWithValue("@company_id", c_id);
                    cmd.Parameters.Add("@days_flag", SqlDbType.Int);
                    cmd.Parameters["@days_flag"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@enddays_flag", SqlDbType.Int);
                    cmd.Parameters["@enddays_flag"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@s_date", DateTime.Now);
                    cmd.Parameters.Add("@days_left", SqlDbType.Int);
                    cmd.Parameters["@days_left"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    var mcid2 = (cmd.Parameters["@days_left"].Value);
                    if (!(mcid2 is DBNull))
                        mcid = Convert.ToInt32(mcid2);
                    var end_days1 = (cmd.Parameters["@enddays_flag"].Value);
                    if (!(end_days1 is DBNull))
                        end_days = Convert.ToInt32(end_days1);
                    var idays_flag = (cmd.Parameters["@days_flag"].Value);
                    if (!(idays_flag is DBNull))
                        days_flag = Convert.ToInt32(idays_flag);
                    if (days_flag == 1)
                    {
                        Session["mcid"] = 1;
                        hd.Value = "1";
                        ClientScript.RegisterStartupScript(this.GetType(), "Pop", "$(function () {alertify.alert('Success', 'Go To Settings Page And Add New financial year'); });", true);
                    }
                    if (end_days == 1)
                    {
                        //poppup logic
                        ifrm1.Attributes.Add("src", "../Masters/FinincialYear.aspx");
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "openModal();", true);
                    }
                }


            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }

        }


        private void GetcompanyInfo()
        {
            if (Session["LoginuserName"] != null)
            {
                ownername.InnerText = Session["LoginuserName"].ToString();
            }
            GetLowstockproducts();
        }

        private void GetLowstockproducts()
        {
            try
            {
                int companyid = 0;
                int branchid = 0;

                if (Session["company_id"] != null)
                {
                    companyid = Convert.ToInt32(Session["company_id"]);
                }
                if (Session["branch_id"] != null)
                {
                    Convert.ToInt32(Session["branch_id"]);
                }
                //context.sp_product_relorderlevel_report_forcompany_only
                if (Session["UserRoleSession"] != null)
                {
                    if (Session["UserRoleSession"].ToString() == "Manager")
                    {
                        //var query = context.sp_product_relorderlevel_report_forcompany_only(companyid);

                        //DataTable dt = new DataTable();
                        //dt = sh.LINQToDataTable(query);
                        //GenerateLowstockGridonindexpage(dt);

                        grvlowstockproducts.DataSource = context.sp_product_relorderlevel_report_forcompany_only(companyid);
                        grvlowstockproducts.DataBind();
                    }
                    else
                    {
                        //var query = context.sp_product_relorderlevel_report_forcompany_only(companyid);

                        //DataTable dt = new DataTable();
                        //dt = sh.LINQToDataTable(query);
                        //GenerateLowstockGridonindexpage(dt);
                        grvlowstockproducts.DataSource = context.sp_product_relorderlevel_report_companybranch(companyid, branchid);
                        grvlowstockproducts.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private DataSet GetDashboardData()
        {
            DataSet ds = new DataSet();
            try
            {
                int companyid = 0;
                if (Session["company_id"] != null)
                {
                    companyid = Convert.ToInt32(Session["company_id"]);
                }

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_dashboarddata", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@conpanyid", companyid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                da.Fill(ds);
                con.Close();

                ds.Tables[0].TableName = "Total_Purchases";
                ds.Tables[1].TableName = "Total_sales";
                ds.Tables[2].TableName = "TOpselling_products";
                ds.Tables[3].TableName = "Customer_Vendors";
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return ds;
        }

        private DataTable Get_DashboardData()
        {
            DataTable dashBoard = new DataTable();
            try
            {
                int companyid = 0;
                if (Session["company_id"] != null)
                {
                    companyid = Convert.ToInt32(Session["company_id"]);
                }

                dashBoard = sh.LINQToDataTable(context.sp_dashboarddata(companyid));
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return dashBoard;
        }


        //private void Fill_DashboardInfo()
        //{
        //    DataTable ds = new DataTable();           
        //    ds = Get_DashboardData();

        //    //if (ds !=null)
        //    //{


        //    //        lblsalorder.Text = dt_sales.Rows[0]["TotalSalesOrder"].ToString();
        //    //        lblsalesamount.Text = dt_sales.Rows[0]["TotalAmountofSale"].ToString();



        //    //        lblpurorder.Text = dt_purchase.Rows[0][0].ToString();
        //    //        lblpurchaseamount.Text = dt_purchase.Rows[0][1].ToString();

        //    //        int b = dt_parties.Select("party_type='Vendor'").Length;
        //    //        if (b > 0)
        //    //        {
        //    //            lblcustomers.Text = dt_parties.Rows[0][0].ToString();
        //    //        }
        //    //        else
        //    //        {
        //    //            lblcustomers.Text = "0";
        //    //        }

        //    //        int a = dt_parties.Select("party_type='Customer'").Length;
        //    //        if (a != null)
        //    //        {
        //    //            if (a > 0)
        //    //            {
        //    //                lblVendors.Text = dt_parties.Rows[1][0].ToString();
        //    //            }
        //    //            else
        //    //            {
        //    //                lblVendors.Text = "0";
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            lblVendors.Text = "0";
        //    //        }

        //    //    }
        //    }
        //}


        private void FillDashboardInfo()
        {
            DataSet ds = new DataSet();
            DataTable dt_sales = new DataTable();
            DataTable dt_purchase = new DataTable();
            DataTable dt_toppruducts = new DataTable();
            DataTable dt_parties = new DataTable();
            ds = GetDashboardData();

            if (ds.Tables.Count > 0)
            {
                dt_purchase = ds.Tables[0];
                dt_sales = ds.Tables[1];
                dt_toppruducts = ds.Tables[2];
                dt_parties = ds.Tables[3];

                if (dt_sales.Rows.Count > 0)
                {
                    lblsalorder.Text = dt_sales.Rows[0]["TotalSalesOrder"].ToString();
                    lblsalesamount.Text = dt_sales.Rows[0]["TotalAmountofSale"].ToString();
                }

                if (dt_purchase.Rows.Count > 0)
                {
                    po.Text = dt_purchase.Rows[0][0].ToString();
                    lblpurchaseamount.Text = dt_purchase.Rows[0][1].ToString();
                }
                if (dt_parties.Rows.Count > 0)
                {
                    int b = dt_parties.Select("party_type='Vendor'").Length;
                    if (b > 0)
                    {
                        lblcustomers.Text = dt_parties.Rows[0][0].ToString();
                    }
                    else
                    {
                        lblcustomers.Text = "0";
                    }

                    //int a = dt_parties.Select("party_type='Customer'").Length;
                    //if (a != null)
                    //{
                    //    if (a > 0)
                    //    {
                    //        lblVendors.Text = dt_parties.Rows[1][0].ToString();
                    //    }
                    //    else
                    //    {
                    //        lblVendors.Text = "0";
                    //    }
                    //}
                    //else
                    //{
                    //    lblVendors.Text = "0";
                    //}

                }
            }
        }

        private void openModel( string flag)
        {
            try
            {
                OrderDetails(flag);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModaldetails();", true);
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        //private void GenerateLowstockGridonindexpage(DataTable dt)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        int serialno = 1;
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append("<table class='table table-bordered table-hover table-striped'>");
        //        sb.Append("<thead>");
        //        sb.Append("<tr>");

        //        sb.Append("<th>#</th><th>Product Name</th><th>Reorder Level</th> <th>Aavailable Qty</th>");

        //        sb.Append("</tr>");
        //        sb.Append("</thead>");
        //        sb.Append("<tbody>");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            sb.Append("<tr>");

        //            // Reorder level here
        //            sb.Append("<td>");
        //            sb.Append(serialno += 1);
        //            sb.Append("</td>");
        //            //-------------------------------------

        //            // Product name added here
        //            sb.Append("<td style='width:300px;'>");
        //            sb.Append("<a href='#'>" + dr["product_name"].ToString() + "</a>");
        //            sb.Append("</td>");
        //            //-----------------------------

        //            // Reorder level here
        //            sb.Append("<td style='color:green; font-size:15px'>");
        //            sb.Append(dr["Reorderlevel"].ToString());
        //            sb.Append("</td>");
        //            //-------------------------------------

        //            // Reorder level here
        //            sb.Append("<td style='color:red; font-size:15px'>");
        //            sb.Append(dr["quantity"].ToString());
        //            sb.Append("</td>");
        //            //-------------------------------------

        //            sb.Append("</tr>");
        //        }
        //        sb.Append("</tbody>");
        //        sb.Append("</table>");
        //        div_lowstockproduct.InnerHtml = sb.ToString();
        //    }


        //}

        #endregion

        /// <summary>
        /// All The Events That are used in coding
        /// </summary>

        #region Events
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void PurchaseOrderList_Click(object sender, EventArgs e)
        {
            try
            {
                openModel("Purchase");
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }
        #endregion

        protected void gvorderDeatils_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["ordertypeflag"] != null)
            {
                string flag = ViewState["ordertypeflag"].ToString();
                gvorderDeatils.PageIndex = e.NewPageIndex;
                gvorderDeatils.DataSource = OrderDetails(flag);
                gvorderDeatils.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModaldetails();", true);
            }
        }

        protected void SalesOrderList_Click(object sender, EventArgs e)
        {
            try
            {
                openModel("Sale");
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }


    }
}