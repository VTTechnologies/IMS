using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IMSBLL.EntityModel;
using System.Net.Mail;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using IMSBLL;
using IMSBLL.DAL;
using System.IO;
using System.Net;


namespace IMS.Registration.form_1
{
    public partial class Forgot : System.Web.UI.Page
    {
        IMS_TESTEntities context = new IMS_TESTEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        /// <summary>
        /// All The Methods That are used in coding
        /// </summary>

        #region Methods

        //code done by ather for reset password changed from email to mobile no.

        public void SendLink()
        {
            try
            {
                Guid uniqueid = Guid.NewGuid();
                string MobileNo = txtMobile.Value;
                int userId = context.tbl_User.Where(u => u.user_mobieno == MobileNo && u.status == true).Select(x => x.user_id).FirstOrDefault();
                if (userId > 0)
                {
                    Tbl_VerifyResetPass vrpass = new Tbl_VerifyResetPass();
                    vrpass.user_id = userId.ToString();
                    vrpass.uniqueidentifier = uniqueid.ToString();
                    vrpass.created_date = DateTime.Now;
                    vrpass.status = true;

                    context.Tbl_VerifyResetPass.Add(vrpass);
                    context.SaveChanges();

                    var userData = (from u in context.tbl_User
                                    join vrp in context.Tbl_VerifyResetPass on u.user_id.ToString() equals vrp.user_id
                                    where u.user_mobieno == MobileNo && u.status == true && vrp.uniqueidentifier == uniqueid.ToString()
                                    select new clsData
                                    {
                                        uniqueidentifier = vrp.uniqueidentifier,
                                        user_id = vrp.user_id,
                                        Passverify_ID = vrp.Passverify_ID.ToString(),
                                        UserMobile = u.user_mobieno
                                    }).ToList().FirstOrDefault();

                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('We have sent link on your registered mobile no. to reset your password','False');", true);
                    SendLink(userData);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('This Mobile No. is not register with IMSbizz','False');", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        private void SendLink(clsData userData)
        {
            try
            {
                string userId = string.Empty, uniqueId = string.Empty, passId = string.Empty, mobileNo = string.Empty, link = string.Empty;

                //var data = Session["userData"] as clsData;
                userId = userData.user_id;
                uniqueId = userData.uniqueidentifier;
                passId = userData.Passverify_ID.ToString();
                mobileNo = userData.UserMobile;

                if (mobileNo.Length == 10) //condition added because 91 is required for sending message from API
                {
                    mobileNo = "91" + mobileNo;
                }
                link = "https://imsbizz.com/Registration/ResetPassword.aspx?pid=" + passId;
                VerifyUser verifyUser = new VerifyUser();
                verifyUser.Dmobile = mobileNo;
                verifyUser.Message = "Please click below link to reset your password " + link + "";
                verifyUser.Message = HttpUtility.UrlEncode(verifyUser.Message);
                string res = verifyUser.SendSMSTL();
                Session["userData"] = null;
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        //protected void SendMail()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = (DataTable)Session["userdetails"];
        //        MailMessage mail = new MailMessage();
        //        //SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
        //        StringBuilder sb = new StringBuilder();
        //        mail.From = new MailAddress("imsbizz@gmail.com", "IMS Bizz");
        //        mail.To.Add(email.Value);
        //        mail.Subject = dt.Rows[0]["username"].ToString() + " here's the link to reset your password";
        //        string body = string.Empty;
        //        using (StreamReader reader = new StreamReader(Server.MapPath("~/Registration/Forgotpassword.html")))
        //        {
        //            body = reader.ReadToEnd();
        //        }
        //        body = body.Replace("{UserName}", dt.Rows[0]["username"].ToString());
        //        body = body.Replace("{id}", dt.Rows[0]["user_id"].ToString());
        //        body = body.Replace("{uid}", dt.Rows[0]["uniqueidentifier"].ToString());
        //        body = body.Replace("{pid}", dt.Rows[0]["Passverify_ID"].ToString());
        //        mail.Body = body;
        //        mail.IsBodyHtml = true;
        //        NetworkCredential NetCrd = new NetworkCredential("imsbizz@gmail.com", "Vtt@1234");
        //        SmtpServer.EnableSsl = false;
        //        //SmtpServer.UseDefaultCredentials = true;
        //        SmtpServer.UseDefaultCredentials = false;
        //        SmtpServer.Credentials = NetCrd;
        //        SmtpServer.Timeout = 200000000;

        //        SmtpServer.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.saveerror(ex);
        //    }
        //}

        //public bool ResetRequest()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        Guid uniqueid = Guid.NewGuid();
        //        Register1 r = new Register1();
        //        r.owner_Email = Email.Value;
        //        r.uniqueid = uniqueid.ToString();
        //        r.created_date = DateTime.Now;
        //        dt = r.ResetRequest(r);
        //        if (dt.Rows[0][0].ToString() == "This Email is not register with IMSbizz")
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('This Email is not register with IMSbizz','False');", true);
        //            return false;
        //        }
        //        else
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Please Check Your Email To Reset Your Password','False');", true);
        //            Session["userdetails"] = dt;
        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.saveerror(ex);
        //    }
        //    return true;
        //}
        #endregion

        /// <summary>
        /// All The Events That are used in coding
        /// </summary>

        #region Events
        protected void btnsendmail_Click(object sender, EventArgs e)
        {
            try
            {
                SendLink();
                txtMobile.Value = "";
                //if (ResetRequest())
                //{
                //    SendLink();
                //    txtMobile.Value = "";
                //}
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }

        }
        #endregion

    }
    [Serializable()]
    internal class clsData
    {
        public string user_id { get; set; }
        public string uniqueidentifier { get; set; }
        public string Passverify_ID { get; set; }
        public string UserMobile { get; set; }
    }
}