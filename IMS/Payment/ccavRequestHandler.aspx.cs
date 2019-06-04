using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;
using System.Collections;
using System.Configuration;
using IMSBLL.DAL;
using IMSBLL.EntityModel;
using System.Linq;

public partial class SubmitData : System.Web.UI.Page
{
    CCACrypto ccaCrypto = new CCACrypto();
    string workingKey = "FEC62AFAAFA1D5B497550DE2B0E48AA0";//put in the 32bit alpha numeric key in the quotes provided here 	
    string ccaRequest = "";
    public string strEncRequest = "";
    public string strAccessCode = "AVTZ02GE72CI75ZTIC";// put the access key in the quotes provided here.

    IMS_TESTEntities context = new IMS_TESTEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string planId = Request.QueryString["pid"].ToString();
            Session["planId"] = planId;
            string tid = string.Empty, merchant_id = string.Empty, order_id = string.Empty, amount = string.Empty, currency = string.Empty, redirect_url = string.Empty, cancel_url = string.Empty;

            merchant_id = ConfigurationManager.AppSettings["merchant_id"];
            tid = DateTime.Now.ToString("yyMMddhhmmssMs");
            Session["tid"] = tid;
            tid = "tid=" + tid;
            merchant_id = "&merchant_id=" + merchant_id;
            order_id = "&order_id=" + "IMSBIZZ" + DateTime.Now.ToString("yyMMddhhmmssMs");
            amount = "&amount=" + GetPriceByPlaneId().ToString();
            currency = "&currency=" + "INR";
            redirect_url = "&redirect_url=" + "http://localhost:44301/Subscription/Message.aspx";
            cancel_url = "&cancel_url=" + "ccavResponseHandler.php";


            ccaRequest = tid + merchant_id + order_id + amount + currency + redirect_url + cancel_url;

            //foreach (string name in Request.Form)
            //{
            //    if (name != null)
            //    {
            //        if (!name.StartsWith("_"))
            //        {
            //            ccaRequest = ccaRequest + name + "=" + Request.Form[name] + "&";
            //            /* Response.Write(name + "=" + Request.Form[name]);
            //              Response.Write("</br>");*/
            //        }
            //    }
            //}

            strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
        }
    }
    public decimal? GetPriceByPlaneId()
    {
        decimal? Price = 00;
        try
        {
            int planId = Convert.ToInt32(Request.QueryString["pid"]);
            Price = context.tbl_plan.Where(x => x.plan_id == planId).Select(x => x.price).FirstOrDefault();
        }
        catch (Exception ex)
        {
            ErrorLog.saveerror(ex);
        }
        return Price;
    }
}

