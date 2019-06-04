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

namespace IMS.Subscription
{
    public partial class Message : System.Web.UI.Page
    {
        int success = 0;

        /// <summary>
        /// All The objects That are used in coding
        /// </summary>
        #region object
        IMS_TESTEntities context = new IMS_TESTEntities();
        SqlHelper sqlHelper = new SqlHelper();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (true)
            {
                if(Session["CustomerId"] != null && Session["tid"] != null && Session["planId"] != null)
                {
                    SaveDetailsOfSubscription(Session["CustomerId"].ToString(), Session["tid"].ToString(), Session["planId"].ToString());
                }
                //result();
            }
            else
            {
                failuerdiv.Visible = true;
                successdiv.Visible = false;
            }
        }

        /// <summary>
        /// All The Methods That are used in coding
        /// </summary>

        #region Methods

        public DataTable SelectPlanById(int PlnId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = sqlHelper.LINQToDataTable(context.tbl_plan.Where(x => x.plan_id == PlnId).ToList());
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return dt;
        }

        public DataTable InsertPaymentAndSubscriptionDetails(int planId, int userId, int companyId, string transactionId, DateTime startDate,DateTime endDate, decimal paidAmount)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertPaymentAndSubscriptionDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 600000;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@planId", planId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@companyId", companyId);
                cmd.Parameters.AddWithValue("@transactionId", transactionId);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                cmd.Parameters.AddWithValue("@paidAmount", paidAmount);
                int val = cmd.ExecuteNonQuery();                
                con.Close();
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return dt;
        }

        public void SaveDetailsOfSubscription(string CustomerId, string tid, string planId)
        {
            DataTable dtPlan = new DataTable();
            DataTable dtUser = new DataTable();
            try
            {
                dtPlan = SelectPlanById(Convert.ToInt32(planId));
                //dtUser = GetUserById(CustomerId);

                int UserId = 0;
                int CompanyId = 0;

                int Duration = Convert.ToInt32(dtPlan.Rows[0][4]); // deuration in months
                decimal Price = Convert.ToDecimal(dtPlan.Rows[0][3]);

                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate.AddMonths(Duration);


                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;
                cmd.CommandText = "GetUserDetailsAndCompanyByUserId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.CommandTimeout = 600000;
                if (con.State== ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@userMobile", CustomerId);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    CompanyId = (int)reader["company_id"];
                    UserId = (int)reader["user_id"];
                }
                con.Close();

                InsertPaymentAndSubscriptionDetails(Convert.ToInt32(planId), Convert.ToInt32(UserId), Convert.ToInt32(CompanyId), tid, startDate, endDate, Price);

            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }
        private void result()
        {
            decimal paidamount = 0;
            int c_id = Convert.ToInt32(Session["company_id"]);
            int u_id = Convert.ToInt32(Session["UserID"]);
            int p_id = 0;
            int t_id = 0;
            DateTime s_date=DateTime.Now;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Salesinsert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandTimeout = 600000;
            con.Open();
            cmd.Parameters.AddWithValue("@company_id", c_id);
            cmd.Parameters.AddWithValue("@user_id", u_id);
            cmd.Parameters.AddWithValue("@plan_id", p_id);
            cmd.Parameters.AddWithValue("@transaction_id", t_id);
            cmd.Parameters.AddWithValue("@paidamount", paidamount);
            cmd.Parameters.AddWithValue("@start_date", s_date);
            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}