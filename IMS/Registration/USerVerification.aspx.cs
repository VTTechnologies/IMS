using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IMSBLL.EntityModel;

namespace IMS.Registration
{
    public partial class USerVerification : System.Web.UI.Page
    {
        IMS_TESTEntities context = new IMS_TESTEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                btnOTP.Text = "Generate OTP";
            }
        }

        protected void btnOTP_Click(object sender, EventArgs e)
        {
            SendOtp();
            otpDiv.Style.Add("display", "normal");
            btnOTP.Text = "Re-Generate OTP";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            string otp = string.Empty;
            if (txtOtp.Value == null || txtOtp.Value == "")
            {
                Response.Write("<script>alert('Please enter OTP')</script>");
                return;
            }
            var userdata = context.tbl_User.Where(u => u.user_id == userId).FirstOrDefault();
            if(txtOtp.Value == userdata.OTP)
            {
                userdata.IsVerified = true;
                context.SaveChanges();
            }
            else
            {
                Response.Write("<script>alert('Wrong OTP')</script>");
                return;
            }
        }
        
        public void SendOtp()
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            var tblUser = context.tbl_User.Where(u => u.user_id == userId).FirstOrDefault();
            string MobileNo = tblUser.user_mobieno;
            if(MobileNo.Length == 10) //condition added because 91 is required for sending message from API
            {
                MobileNo = "91" + MobileNo;
            }
            VerifyUser verifyUser = new VerifyUser();
            verifyUser.Source = "TRYBMS";
            verifyUser.Username = "athar.sayed8055";
            verifyUser.Password = "93354218";
            verifyUser.OTP = verifyUser.GenerateRandomOTP(4);
            verifyUser.Dmobile = MobileNo;
            verifyUser.Message = "Your one time password is " + verifyUser.OTP;
            verifyUser.Message = HttpUtility.UrlEncode(verifyUser.Message);

            string res = verifyUser.SendSMSTL();

            //Update otp to DB;
            tblUser.OTP = verifyUser.OTP;
            context.SaveChanges();
        }

    }
}