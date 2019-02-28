using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace IMS.Registration
{
    public class sendSMS
    {
        public string SendSMS()
        {
            String message = HttpUtility.UrlEncode("Test Message from ather TL Account");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "Y6Hd1CBueb0-r3TJqtADICdON6gmatBlF2w7rIzMsp"},
                {"numbers" , "8208425126"},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }
}