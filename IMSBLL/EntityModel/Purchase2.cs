using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using IMSBLL.DAL;


namespace IMSBLL.EntityModel
{
    public  class tbl_purchaseService
    {

        SqlHelper helper = new SqlHelper();
        public string party_name { get; set; }
        public string date { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public decimal balance { get; set; }
        public decimal given { get; set; }

        public DataTable All2(tbl_purchase p)
        {
            DataTable programs = new DataTable();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@company_id", p.company_id);
                parameters.Add("@purchsae_id", p.purchase_id);
            
                DataTable dt = helper.GetDataTableFromStoredProc(SP.SelectPurchaseinvoicebyid, parameters);
                foreach (DataRow dr in dt.Rows)
                {

                    p.party_id = Convert.ToInt32(dr["party_id"].ToString());
                    p.total_amnt = Convert.ToDecimal(dr["actual_amount"].ToString());
                    p.Po_Date = Convert.ToDateTime(dr["Date"]);
                    p.total_discount = Convert.ToDecimal(dr["discount"].ToString());
                    p.po_no = (dr["po_no"].ToString());
                    p.grand_total = Convert.ToDecimal(dr["grand_total"]);
                    p.total_tax = Convert.ToDecimal(dr["total_tax"]);
                    ////Shakeeb
                    ////p.party_name = (dr["party_name"].ToString());
                    ////p.balance = Convert.ToDecimal(dr["balance_amt"].ToString());
                    ////p.given = Convert.ToDecimal(dr["given_amt"].ToString());
                    


                }
                programs = dt;
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return programs;
        }

     


        public DataTable All(tbl_purchase p)
        {
            DataTable programs = new DataTable();
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@company_id", p.company_id);

                DataTable dt = helper.GetDataTableFromStoredProc(SP.SelectFinicialyeardate, parameters);
                foreach (DataRow dr in dt.Rows)
                {
                    ////Shakeeb
                    ////p.startdate = (dr["start_date"].ToString());
                    ////p.enddate = (dr["end_date"].ToString());
                   



                }
                programs = dt;
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return programs;
        }
    }
}
