﻿using System;
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
using System.Data.Entity.Core.Objects;
using System.Globalization;
using IMS.Reports;

namespace IMS
{
    public partial class ViewORPayBalancePurchase : System.Web.UI.Page
    {
        IMS_TESTEntities context = new IMS_TESTEntities();
        int companyId = 0, branchId = 0, financialYearId = 0;
        string user_id = string.Empty;
        bool viewOrPayBalance = false;
        int purchase_Id = 0;
        string connectionstring = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ViewOrPayBalance"] != null && Request.QueryString["Id"] != null)
                {
                    viewOrPayBalance = Convert.ToBoolean(Request.QueryString["ViewOrPayBalance"]);
                    purchase_Id = Convert.ToInt32(Request.QueryString["Id"]);

                    if (viewOrPayBalance)
                    {
                        btnSave.Enabled = true;
                        txtPaidAmnt.Enabled = true;
                    }
                }

                SessionValue();
                if (!IsPostBack)
                {
                    this.FetchData(purchase_Id);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        //Methods------------------
        private void FetchData(int purchaseId)
        {

            SqlParameter[] sqlParams = new SqlParameter[] {
                         new SqlParameter("@Id", purchaseId),
                         new SqlParameter("@FromTable","COMBINEPURCHASEANDRETURN")
                    };

            var ds = Common.FillDataSet(connectionstring, "PurchaseOrPurchaseReturnReport", sqlParams);
            if (ds.Tables["Table"] != null)
            {
                decimal balanceAmnt = 0, totalDiscount = 0, subTotal = 0, grandTotal = 0, totalTax = 0;

                for (int i = 0; i < ds.Tables["Table"].Rows.Count; i++)
                {
                    if (ds.Tables["Table"].Rows[i]["Type"].ToString() == "Purchase")
                    {
                        totalTax = totalTax + Convert.ToDecimal(ds.Tables["Table"].Rows[i]["TaxAmnt"]);
                        totalDiscount = totalDiscount + Convert.ToDecimal(ds.Tables["Table"].Rows[i]["DiscountAmnt"]);
                        subTotal = subTotal + Convert.ToDecimal(ds.Tables["Table"].Rows[i]["ProductAmount"]);
                       
                    }
                    else if (ds.Tables["Table"].Rows[i]["Type"].ToString() == "Return")
                    {
                        totalTax = totalTax - Convert.ToDecimal(ds.Tables["Table"].Rows[i]["TaxAmnt"]);
                        totalDiscount = totalDiscount - Convert.ToDecimal(ds.Tables["Table"].Rows[i]["DiscountAmnt"]);
                        subTotal = subTotal - Convert.ToDecimal(ds.Tables["Table"].Rows[i]["ProductAmount"]);
                        
                    }

                }
                grandTotal = subTotal + totalTax - totalDiscount;


                DataRow dr = ds.Tables["Table"].Select("Id=" + purchaseId + "").FirstOrDefault();
                txtPaymentMode.Text = dr["PaymentMode"].ToString();
                lblInvoice.Text = dr["InvoiceNumber"].ToString();
                txtVendor.Text = dr["Party"].ToString();
                txtPONo.Text = dr["PoNo"].ToString();
                txtdate.Text = dr["Date"].ToString();

                //Get only Given and Balance Amnt and Calcualte Remainig as per Transaction
                DataRow drpurchase = ds.Tables["Table"].Select("Type='Purchase'").FirstOrDefault();
                DataRow drreturn = ds.Tables["Table"].Select("Type='Return'").FirstOrDefault();

                lblsubtotal.Text = subTotal.ToString();
                lblTaxAmount.Text = totalTax.ToString();
                lblDiscountAmt.Text = totalDiscount.ToString();
                lblGrandTotal.Text = grandTotal.ToString();
                lblGivenAmnt.Text = dr["GivenAmnt"].ToString();

                balanceAmnt = Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(lblGivenAmnt.Text);

                if (balanceAmnt < 0)
                    btnGetRefund.Visible = true;
               
                txtBalanceAmnt.Text = balanceAmnt.ToString();
                lblBalanceAmnt.Text = balanceAmnt.ToString();
               

                gvpurchasedetails.DataSource = ds.Tables["Table"];
                gvpurchasedetails.DataBind();
              
            }
        }

        protected void Update()
        {
            try
            {
                lblError.Text = string.Empty;
                if (ValidCalculation())
                {
                    tbl_PurchasePaymentDetials purchasePaymentDetails = context.tbl_PurchasePaymentDetials.Where(w => w.PurchaseId == purchase_Id).FirstOrDefault();

                    purchasePaymentDetails.GivenAmnt = Convert.ToDecimal(txtPaidAmnt.Text);
                    purchasePaymentDetails.BalanceAmnt = Convert.ToDecimal(txtBalanceAmnt.Text);

                    context.tbl_PurchasePaymentDetials.Add(purchasePaymentDetails);
                    context.SaveChanges();
                    int? order = purchasePaymentDetails.PurchaseId;
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Saved successfully, Your order number is " + order + "');", true);
                }
                else
                {
                    lblError.Text = "Calculation doesn't match, please check calculation.";
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }
        private bool ValidCalculation()
        {
            bool valid = false;
            if (Convert.ToDecimal(lblGrandTotal.Text) == (Convert.ToDecimal(lblGivenAmnt.Text) + Convert.ToDecimal(txtPaidAmnt.Text)))
            {
                valid = true;
            }
            return valid;
        }

        private void SessionValue()
        {
            if (Session["UserID"] == null || Session["company_id"] == null || Session["branch_id"] == null || Session["financialyear_id"] == null)
            {
                Response.Redirect("~/Registration/Login.aspx");
            }
            user_id = Convert.ToString(Session["UserID"]);
            companyId = Convert.ToInt32(Session["company_id"]);
            branchId = Convert.ToInt32(Session["branch_id"]);
            financialYearId = Convert.ToInt32(Session["financialyear_id"]);
        }

        protected void gvpurchasedetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Image img = (Image)e.Row.FindControl("image");

                    if (e.Row.Cells[1].Text == "Purchase")
                    {
                        img.ImageUrl = "/Uploads/up.png";
                        img.Visible = true;
                    }
                    else if (e.Row.Cells[1].Text == "Return")
                    {
                        img.ImageUrl = "/Uploads/down.png";
                        img.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void gvpurchasedetails_DataBound(object sender, EventArgs e)
        {
            int firstRowSpan = 2;
            int secondRowSpan = 2;
            for (int i = gvpurchasedetails.Rows.Count - 2; i >= 0; i--)
            {
                GridViewRow currRow = gvpurchasedetails.Rows[i];
                GridViewRow prevRow = gvpurchasedetails.Rows[i + 1];
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

        protected void btnGetRefund_Click(object sender, EventArgs e)
        {           
            string balanceAmnt = txtBalanceAmnt.Text.Replace('-', ' ');
            decimal paidAmnt = txtPaidAmnt.Text == "" ? 0 : Convert.ToDecimal(txtPaidAmnt.Text);
            txtPaidAmnt.Text = (Convert.ToDecimal(balanceAmnt) + paidAmnt).ToString();
            txtBalanceAmnt.Text = "0";
            btnGetRefund.Visible = false;
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            Update();
        }

        protected void txtGivenAmt_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
               
                decimal remainingBalance = Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(lblGivenAmnt.Text);
                
                if (remainingBalance < 0)
                {
                    btnGetRefund.Visible = true;
                    txtBalanceAmnt.Text = (remainingBalance + Convert.ToDecimal(txtPaidAmnt.Text)).ToString();
                }
                else if (txtPaidAmnt.Text == "0" || string.IsNullOrEmpty(txtPaidAmnt.Text))
                {
                    btnGetRefund.Visible = false;
                    txtBalanceAmnt.Text = remainingBalance.ToString();
                    return;
                }
                else
                {
                    txtBalanceAmnt.Text = (remainingBalance - Convert.ToDecimal(txtPaidAmnt.Text)).ToString();
                }

                UpdatePanel2.Update();
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }


    }
}