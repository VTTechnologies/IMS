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

namespace IMS
{
    public partial class Purchase : System.Web.UI.Page
    {
        IMS_TESTEntities context = new IMS_TESTEntities();
        int companyId = 0, branchId = 0,financialYearId=0;
        string user_id = string.Empty;
        bool viewOrPayBalance = false;
        int purchase_Id = 0;
        int counter = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Request.QueryString["ReportName"] !=null && Request.QueryString["Id"]!=null)
                {
                    viewOrPayBalance = Convert.ToBoolean(Request.QueryString["ReportName"]);
                    purchase_Id = Convert.ToInt32(Request.QueryString["Id"]);

                    if(viewOrPayBalance)
                    {

                    }
                }
                
                SessionValue();
                if (!IsPostBack)
                {
                    CalendarExtender1.StartDate = DateTime.Now;
                    if (ViewState["Details"] == null)
                    {
                        DataTable dataTable = new DataTable();

                        dataTable.Columns.Add("Vendore");
                        dataTable.Columns.Add("Product_id");
                        dataTable.Columns.Add("PON");
                        dataTable.Columns.Add("Date");
                        dataTable.Columns.Add("Product");
                        dataTable.Columns.Add("Batch");
                        dataTable.Columns.Add("Batch_id");
                        dataTable.Columns.Add("Quantity");
                        dataTable.Columns.Add("Price");
                        dataTable.Columns.Add("Discount");
                        dataTable.Columns.Add("Discount Amount");
                        dataTable.Columns.Add("SalePrice");
                        dataTable.Columns.Add("Tax");
                        dataTable.Columns.Add("Tax Amount");
                        dataTable.Columns.Add("Sub Total");
                        ViewState["Details"] = dataTable;
                    }
                    this.BindGrid();
                    ddlVendorbind();
                    ddlproductbind();
                    ddlbatchbind();
                    //txtdate.Text = DateTime.Now.ToString();
                    ddlpaymentmodebind();
                    getdate();                  
                    lblInvoice.Text = Common.GenerateInvoicenumber(companyId, branchId, Constants.Purchase);
                    ClearAll();
                }
               
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }


       //Methods------------------
        protected void Save()
        {
            try
            {
                
                tbl_purchase purchase = new tbl_purchase();
                purchase.company_id = companyId;
                purchase.branch_id = branchId;
                purchase.financialyear_id = financialYearId;
                purchase.InvoiceNumber = lblInvoice.Text;
               
                purchase.PaymentMode_id = Convert.ToInt32(ddlPaymentMode.SelectedValue);
                purchase.status = true;
                purchase.party_id = Convert.ToInt32(ddlVendor.SelectedValue);
                purchase.Po_Date = DateTime.Parse(txtdate.Text, new CultureInfo("en-US"));             
                purchase.po_no = txtPONo.Text;
               
                purchase.created_by = user_id;
                purchase.created_date = DateTime.Now;

                //insert into Purchase Payment Details 
                tbl_PurchasePaymentDetials purchasePaymentDetail = new tbl_PurchasePaymentDetials();
                purchasePaymentDetail.TaxAmount = Convert.ToDecimal(lblTaxAmount.Text);
                purchasePaymentDetail.DiscountAmount = Convert.ToDecimal(lblDiscountAmt.Text);
                purchasePaymentDetail.SubTotal = Convert.ToDecimal(lblsubtotal.Text);
                purchasePaymentDetail.GrandTotal = Convert.ToDecimal(lblGrandTotal.Text);
                purchasePaymentDetail.PaidAmnt = Convert.ToDecimal(txtPaidAmt.Text);
                purchasePaymentDetail.GivenAmnt = Convert.ToDecimal(txtPaidAmt.Text);
                purchasePaymentDetail.BalanceAmnt = Convert.ToDecimal(txtBalanceAmt.Text);
                purchasePaymentDetail.FromTable = "Purchase";
                purchase.tbl_PurchasePaymentDetials.Add(purchasePaymentDetail);

                for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
                {                    
                    int productId = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text);
                    int batchId = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[4].Text);
                    tbl_product product = context.tbl_product.Where(w => w.product_id == productId).FirstOrDefault();
                    
                    //Add into Purchase Details table for each product
                    tbl_purchasedetails purchaseDetails = new tbl_purchasedetails();
                    purchaseDetails.product_id = productId;
                    purchaseDetails.batch_id = batchId;
                    purchaseDetails.tax_id = product.tax_id;
                    purchaseDetails.unit_id = product.unit_id;
                    purchaseDetails.tax_amt = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[11].Text);
                    purchaseDetails.dicount_amt = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[9].Text);
                    purchaseDetails.quantity = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[5].Text);
                    purchaseDetails.amount = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[12].Text);
                    purchaseDetails.created_by = Convert.ToString(user_id);
                    purchaseDetails.created_date = DateTime.Now;
                    purchaseDetails.status = true;

                    //Enter Details In tbl_ActualPurchaseTaxAndPrice : to get the original Values at the time of Purchase Return
                    tbl_ActualPurchaseTaxAndPrice actualPurchase = new tbl_ActualPurchaseTaxAndPrice();
                    actualPurchase.product_id = productId;
                    actualPurchase.status = true;
                    actualPurchase.tax_percent = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[10].Text);
                    actualPurchase.purchase_rate = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[6].Text);
                    actualPurchase.discount_percent = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[8].Text);
                    actualPurchase.discount_amnt = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[9].Text);
                    actualPurchase.batch_id = batchId;
                    actualPurchase.sale_price = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[7].Text);
                    actualPurchase.created_by = Convert.ToString(user_id);
                    actualPurchase.created_date = DateTime.Now;

                    //Add into Actual Purchase Tax And Return Table
                    purchase.tbl_ActualPurchaseTaxAndPrice.Add(actualPurchase);                    


                    //Add Stock if not exist or update the Stock against the product
                    tbl_stock stock = new tbl_stock();
                    if (!IsProductStockExists(companyId, branchId, productId,batchId))
                    {
                        stock.company_id = companyId;
                        stock.branch_id = branchId;
                        stock.product_id = productId;
                        stock.batch_id = batchId;
                        stock.qty = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[5].Text);
                        stock.status = true;
                        stock.created_by = Convert.ToString(user_id);
                        stock.created_date = DateTime.Now;
                        context.tbl_stock.Add(stock);
                    }
                    else
                    {
                        stock = context.tbl_stock.Where(w => w.company_id == companyId && w.branch_id == branchId && w.product_id == productId && w.batch_id==batchId).FirstOrDefault();
                        stock.qty = stock.qty + Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[5].Text);
                        stock.modified_by = Convert.ToString(user_id);
                        stock.modified_date = DateTime.Now;
                    }                    
                    purchase.tbl_purchasedetails.Add(purchaseDetails);
                }

                context.tbl_purchase.Add(purchase);
                context.SaveChanges();               
                string order = purchase.InvoiceNumber;
                Session["p_id"] = purchase.purchase_id;
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Saved successfully, Your order number is " + order + "');", true);
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }


        private bool IsProductStockExists(int companyId, int branchId, int productId,int batchId)
        {
            return context.tbl_stock.Where(w => w.company_id == companyId && w.branch_id == branchId && w.product_id == productId && w.batch_id==batchId).Any();
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
            financialYearId= Convert.ToInt32(Session["financialyear_id"]);
        }
        protected void savelogic()
        {
            SqlTransaction transaction;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_Purchaseinsert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.CommandTimeout = 600000;
            con.Open();
            transaction = con.BeginTransaction("Transaction");
            cmd.Transaction = transaction;
            try
            {
               
                //ObjectParameter purchaseId = new ObjectParameter("purchase_id", typeof(int));

                //context.sp_Purchaseinsert(companyId, branchId, Convert.ToInt32(ddlVendor.SelectedValue), txtPONo.Text, txtdate.Text,
                //    Convert.ToDecimal(lblTaxAmount.Text), Convert.ToDecimal(lblDiscountAmt.Text), Convert.ToDecimal(lblsubtotal.Text),
                //    Convert.ToDecimal(lblGrandTotal.Text), User_id, DateTime.Now, purchaseId);
                cmd.Parameters.AddWithValue("@company_id", companyId);
                cmd.Parameters.AddWithValue("@branch_id", branchId);
                cmd.Parameters.AddWithValue("@party_id", ddlVendor.SelectedValue);
                cmd.Parameters.AddWithValue("@po_no", txtPONo.Text);
                cmd.Parameters.AddWithValue("@Po_Date", txtdate.Text);
                cmd.Parameters.AddWithValue("@total_tax", lblTaxAmount.Text);
                cmd.Parameters.AddWithValue("@discount", lblDiscountAmt.Text);
                cmd.Parameters.AddWithValue("@actual_amount", lblsubtotal.Text);
                cmd.Parameters.AddWithValue("@grand_total", lblGrandTotal.Text);
                cmd.Parameters.AddWithValue("@created_by", user_id);
                cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                cmd.Parameters.Add("@purchase_id", SqlDbType.Int);
                cmd.Parameters["@purchase_id"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                int mcid = Convert.ToInt32(cmd.Parameters["@purchase_id"].Value);
                cmd.Parameters.Clear();

                //GridViewRow row = gvpurchasedetails.Rows[rowIndex];
                for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
                {
                    //Purchase Details Saving Code Start Here

                    //ObjectParameter purchasedetailsId = new ObjectParameter("purchase_id", typeof(int));
                    //context.sp_PurchaseDetailinsert(
                    //    Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text), Convert.ToInt32(purchaseId), Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[4].Text),
                    //    Convert.ToInt32(User_id),  DateTime.Today.ToString(), Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[11].Text),
                    //    Convert.ToDecimal( gvpurchasedetails.Rows[i].Cells[9].Text), Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[5].Text),
                    //    Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[12].Text), Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[6].Text), 
                    //    Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[7].Text), purchasedetailsId);
                    cmd.CommandText = "sp_PurchaseDetailinsert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", gvpurchasedetails.Rows[i].Cells[2].Text);
                    cmd.Parameters.AddWithValue("@purchase_id", mcid);
                    cmd.Parameters.AddWithValue("@batch_id", gvpurchasedetails.Rows[i].Cells[4].Text);
                    cmd.Parameters.AddWithValue("@tax_amt", gvpurchasedetails.Rows[i].Cells[11].Text);
                    cmd.Parameters.AddWithValue("@dicount_amt", gvpurchasedetails.Rows[i].Cells[9].Text);
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@amount", gvpurchasedetails.Rows[i].Cells[12].Text);
                    cmd.Parameters.AddWithValue("@purchase_rate", gvpurchasedetails.Rows[i].Cells[6].Text);
                    cmd.Parameters.AddWithValue("@sale_rate", gvpurchasedetails.Rows[i].Cells[7].Text);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                    cmd.Parameters.Add("@purchasedetails_id", SqlDbType.Int);
                    cmd.Parameters["@purchasedetails_id"].Direction = ParameterDirection.Output;
                    cmd.Connection = con;
                    cmd.CommandTimeout = 600000;
                    cmd.ExecuteNonQuery();
                    int details_id = Convert.ToInt32(cmd.Parameters["@purchasedetails_id"].Value);
                    cmd.Parameters.Clear();


                    // Purchase Details Code End

                    // Stock & Stock Transaction Data Saving Code Starts Here
                    cmd.CommandText = "sp_InsertTransaction";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // code are here

                    //context.sp_InsertTransaction(companyId, branchId, Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text), Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text), "In",
                    //    Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[2].Text), Convert.ToInt32(purchasedetailsId), "Purchase", User_id, DateTime.Today);

                    cmd.Parameters.AddWithValue("@company_id", companyId);
                    cmd.Parameters.AddWithValue("@branch_id", branchId);
                    cmd.Parameters.AddWithValue("@product_id", gvpurchasedetails.Rows[i].Cells[2].Text);
                    cmd.Parameters.AddWithValue("@bacth_id", gvpurchasedetails.Rows[i].Cells[4].Text);
                    cmd.Parameters.AddWithValue("@in_out", "In");
                    cmd.Parameters.AddWithValue("@qty", Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@transactio_type_id", details_id);
                    cmd.Parameters.AddWithValue("@stocktransaction_typ", "Purchase");
                    cmd.Parameters.AddWithValue("@created_by", user_id);
                    cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                    cmd.Connection = con;
                    cmd.CommandTimeout = 600000;
                    // end

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    // Stock & Stock Transaction Data Saving Code end

                }

                //context.sp_InsertMonyTransaction(companyId, branchId, Convert.ToInt32(ddlVendor.SelectedValue), Convert.ToDecimal(txtPaidAmt.Text),Convert.ToDecimal(lblGrandTotal.Text), Convert.ToDecimal(txtBalanceAmt.Text), "Out", Convert.ToInt32(ddlPaymentMode),
                //    "Purchase",Convert.ToInt32(purchaseId), User_id, DateTime.Today);

                cmd.Parameters.Clear();
                cmd.CommandText = "sp_InsertMonyTransaction";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@company_id", companyId);
                cmd.Parameters.AddWithValue("@branch_id", branchId);
                cmd.Parameters.AddWithValue("@party_id", ddlVendor.SelectedValue);
                cmd.Parameters.AddWithValue("@given_amt", txtPaidAmt.Text);
                cmd.Parameters.AddWithValue("@grand_total", lblGrandTotal.Text);
                cmd.Parameters.AddWithValue("@balance_amt", txtBalanceAmt.Text);
                cmd.Parameters.AddWithValue("@in_out", "Out");
                cmd.Parameters.AddWithValue("@paymentmode_id", ddlPaymentMode.SelectedValue);
                cmd.Parameters.AddWithValue("@transaction_typ", "Purchase");
                cmd.Parameters.AddWithValue("@transactio_type_id", mcid);
                cmd.Parameters.AddWithValue("@created_by", user_id);
                cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                cmd.Connection = con;
                cmd.CommandTimeout = 600000;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                con.Close();
                Session["p_id"] = mcid;
                string order = mcid.ToString();

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Saved successfully, your order number is " + order + "');", true);

            }
            catch (Exception ex)
            {
               // transaction.Rollback();
                ErrorLog.saveerror(ex);
            }
            finally
            {
                //if (con != null && con.State != ConnectionState.Closed)
                //{
                //    con.Close();
                //}
            }
        }

        public void clr()
        {           
            ddlBatch.SelectedIndex = 0;
            ddlproduct.SelectedIndex = 0;
            txtquantity.Text = string.Empty;
            txtprice.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtsalesprice.Text = string.Empty;
            txtTaxpercentage.Text = string.Empty;
            txtPaidAmt.Text = string.Empty;
            txtBalanceAmt.Text = string.Empty;
        }
        public void ClearAll()
        {
            txtdate.Text = string.Empty;
            txtPONo.Text = string.Empty;
            ddlVendor.SelectedIndex = 0;
            ddlBatch.SelectedIndex = 0;
            ddlproduct.SelectedIndex = 0;
            txtquantity.Text = string.Empty;
            txtprice.Text = string.Empty;
            txtDiscount.Text = string.Empty; 
            txtsalesprice.Text = string.Empty;
            txtBalanceAmt.Text = string.Empty;
            txtPaidAmt.Text = string.Empty;
        }

        public void updatecal()
        {
            decimal a1 = Convert.ToDecimal(lblsubtotal.Text) - Convert.ToDecimal(ViewState["subtot"]);
            decimal b1 = Convert.ToDecimal(lblDiscountAmt.Text) - Convert.ToDecimal(ViewState["discountamount"]);
            decimal c = Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(ViewState["taxamount"]);
            lblsubtotal.Text = a1.ToString();
            lblDiscountAmt.Text = b1.ToString();
            lblTaxAmount.Text = c.ToString();
            decimal d = (a1 + c) - b1;
            lblGrandTotal.Text = d.ToString();
        }
        public void ddlVendorbind()
        {

            List<tbl_party> cd = context.tbl_party.Where(x => x.status == true && x.company_id == companyId && x.party_type == "Vendor").ToList();
            ddlVendor.DataTextField = "party_name";
            ddlVendor.DataValueField = "party_id";
            ddlVendor.DataSource = cd;
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem("--Select Vendor--", "0"));
        }

        public void ddlproductbind()
        {
            //context.tbl_product.Where(x => x.status == true && x.company_id == c_id).ToList();
            ddlproduct.DataTextField = "product_name";
            ddlproduct.DataValueField = "product_id";
            ddlproduct.DataSource = context.sp_SelectProduct(companyId, branchId);
            ddlproduct.DataBind();
            ddlproduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
        }

        public void ddlbatchbind()
        {
            List<tbl_batch> cd = context.tbl_batch.Where(x => x.status == true && x.company_id == companyId).ToList();
            ddlBatch.DataTextField = "batch_name";
            ddlBatch.DataValueField = "batch_id";
            ddlBatch.DataSource = cd;
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("--Select Batch--", "0"));
        }
        public void ddlpaymentmodebind()
        {
            List<tbl_paymentmode> cd = context.tbl_paymentmode.Where(x => x.status == true).ToList();
            ddlPaymentMode.DataTextField = "paymentmode_name";
            ddlPaymentMode.DataValueField = "paymentode_id";
            ddlPaymentMode.DataSource = cd;
            ddlPaymentMode.DataBind();
        }

        public bool validateddl()
        {
            if (ddlBatch.SelectedIndex == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        protected void BindGrid()
        {
            gvpurchasedetails.DataSource = (DataTable)ViewState["Details"];
            gvpurchasedetails.DataBind();
        }
        public void calculation(decimal amt, decimal tax, decimal dis)
        {
            decimal tot = 0;
            decimal tottax = 0;
            decimal dec = 0;
            decimal gtot = 0;
            tot = Convert.ToDecimal(lblsubtotal.Text) + amt;
            lblsubtotal.Text = tot.ToString();
            tottax = Convert.ToDecimal(lblTaxAmount.Text) + tax;
            lblTaxAmount.Text = tottax.ToString();
            dec = Convert.ToDecimal(lblDiscountAmt.Text) + dis;
            lblDiscountAmt.Text = dec.ToString();

            gtot = Convert.ToDecimal(lblsubtotal.Text) + (Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(lblDiscountAmt.Text));
            lblGrandTotal.Text = gtot.ToString();


        }
        public void getdate()
        {
            try
            {
                //ef code awais
               var finicialyear= context.tbl_financialyear.Where(f => f.company_id == companyId && f.status == true).SingleOrDefault();
               hd1.Value = finicialyear.start_date;
               hd2.Value = finicialyear.end_date;

               CalendarExtender1.StartDate = Convert.ToDateTime(finicialyear.start_date);
               CalendarExtender1.EndDate = Convert.ToDateTime(finicialyear.end_date);
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
            }
        }

        //Events-----
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblcheckDoubleError.Text = string.Empty;
            try
            {
                string discount = txtDiscount.Text.Trim();
                int productId = Convert.ToInt32(ddlproduct.SelectedValue);
                int batchId = Convert.ToInt32(ddlBatch.SelectedValue);
                if (string.IsNullOrEmpty(discount))
                {
                    discount = "0";
                }

                if (!ValidateQuantity(productId, batchId))
                {
                    decimal subTotal = Convert.ToDecimal(txtquantity.Text) * Convert.ToDecimal(txtprice.Text);
                    decimal a = subTotal / 100;
                    decimal discountamt = a * decimal.Parse(discount);
                    decimal tax_amount = a * decimal.Parse(txtTaxpercentage.Text);                   

                    DataTable dt = (DataTable)ViewState["Details"];
                    dt.Rows.Add(ddlVendor.SelectedItem.Text.Trim(), productId, txtPONo.Text.Trim(), txtdate.Text.Trim(), ddlproduct.SelectedItem.Text.Trim(),ddlBatch.SelectedItem.Text.Trim(),
                                      batchId,txtquantity.Text.Trim(), txtprice.Text.Trim(), discount, discountamt, txtsalesprice.Text.Trim(), txtTaxpercentage.Text, tax_amount, subTotal );
                    ViewState["Details"] = dt;
                    this.BindGrid();
                    lblcheckDoubleError.Text = string.Empty;

                    clr();
                    txtPaidAmt.Enabled = true;
                    calculation(subTotal, tax_amount, discountamt);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }

            
            //try
            //{
            //    if (validateddl() == true)
            //    {
            //        string vendor = ddlVendor.SelectedItem.Text.Trim();
            //        string PON = txtPONo.Text.Trim();
            //        string date = txtdate.Text;
            //        string pname = ddlproduct.SelectedItem.Text.Trim();
            //        string batch = ddlBatch.SelectedItem.Text.Trim();
            //        string quantity = txtquantity.Text.Trim();
            //        string price = txtprice.Text.Trim();
            //        string discount = txtDiscount.Text.Trim();
            //        string salesp = txtsalesprice.Text.Trim();
            //        if (discount == "" || discount == null)
            //        {
            //            discount = "0";
            //        }
            //        int p_id = Convert.ToInt32(ddlproduct.SelectedValue);
            //        Tax_percent t = new Tax_percent();
            //        t.company_id = companyId;
            //        t.product_id = p_id;
            //        t.All(t);
            //        string tax = t.tax_percentage;
            //        int Batch_id = Convert.ToInt32(ddlBatch.SelectedValue);
            //        int product_id = Convert.ToInt32(ddlproduct.SelectedValue);
            //        decimal SubTotal = Convert.ToDecimal(txtquantity.Text) * Convert.ToDecimal(txtprice.Text);
            //        decimal a = SubTotal / 100;
            //        decimal discountamt = a * decimal.Parse(discount);
            //        decimal b = a * decimal.Parse(tax);

            //        DataTable dt = (DataTable)ViewState["Details"];
            //        dt.Rows.Add(vendor, product_id, PON, date, pname, batch, Batch_id, quantity, price, discount, discountamt, salesp, tax, b, SubTotal);
            //        ViewState["Details"] = dt;
            //        this.BindGrid();

            //        clr();
            //        txtBalanceAmt.Enabled = true;
            //        txtPaidAmt.Enabled = true;
            //        calculation(SubTotal, b, discountamt);
            //        lblbatch.Visible = false;
            //    }
            //    else
            //    {
            //        lblbatch.Visible = true;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.saveerror(ex);
            //}

        }
        public bool ValidateQuantity(int productId,int batchId)
        {
            bool isfail = false;
            try
            {                
                if (!btnUpdate.Visible)
                {
                    for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
                    {
                        int pId = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text);
                        decimal qty = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[5].Text);
                        int bId = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[4].Text);
                        if (pId == productId && batchId == bId)
                        {
                            isfail = true;
                            lblcheckDoubleError.Visible = true;
                            lblcheckDoubleError.Text = "Already product and batch added, Please select different product and batch or update existing product.";
                            return isfail;
                        }
                    }
                }
                decimal salePrice = Convert.ToDecimal(txtsalesprice.Text);
                decimal purchasePrice = Convert.ToDecimal(txtprice.Text);
                decimal tax= Convert.ToDecimal(txtTaxpercentage.Text);
                var isProductExsits = context.tbl_ActualPurchaseTaxAndPrice.Where(w => w.product_id == productId && w.batch_id == batchId).FirstOrDefault();
                if (isProductExsits != null)
                {
                    // var samePriceExists = context.tbl_ActualPurchaseTaxAndPrice.Where(w => w.product_id == productId && w.batch_id == batchId && w.sale_price== salePrice && w.purchase_rate==purchasePrice && w.tax_percent== tax).Any();
                    if (isProductExsits.sale_price!=salePrice || isProductExsits.purchase_rate!=purchasePrice || isProductExsits.tax_percent!=tax)
                    {
                        isfail = true;
                        lblcheckDoubleError.Visible = true;
                        lblcheckDoubleError.Text = "Please change batch, As per configuration Purchase Price, Sale Price Or Tax has been changed.";
                        return isfail;

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return isfail;
        }
        protected void btnUpdate_Click(object sender, System.EventArgs e)
        {
            txtPaidAmt.Text = string.Empty;
            txtBalanceAmt.Text = string.Empty;
            lblcheckDoubleError.Text = string.Empty;
            ddlproduct.Enabled = true;
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["Details"];
                int productId = Convert.ToInt32(ddlproduct.SelectedValue);
                int batchId = Convert.ToInt32(ddlBatch.SelectedValue);
                string discount = txtDiscount.Text.Trim();
                if (discount == "" || discount == null)
                {
                    discount = "0";
                }

                if (!ValidateQuantity(productId, batchId))
                {
                    DataRow dr = dt.Select("Product_id=" + productId + "").FirstOrDefault();
                    if (dr != null)
                    {
                        decimal subTotal = Convert.ToDecimal(txtquantity.Text) * Convert.ToDecimal(dr["Price"]);
                        decimal a = subTotal / 100;
                        //decimal discount_percent = (Convert.ToDecimal(discount) * 100) / Convert.ToDecimal(dr["Sub Total"]);
                        decimal discountamt = a * Convert.ToDecimal(discount);
                        decimal tax_amount = a * Convert.ToDecimal(dr["Tax"]);

                        dr["Quantity"] = txtquantity.Text;
                        dr["Tax"] = txtTaxpercentage.Text;
                        dr["Discount"] = Convert.ToDecimal(discount);
                        dr["Discount Amount"] = discountamt;
                        dr["Sub Total"] = subTotal;
                        dr["Tax Amount"] = tax_amount;
                        dr["Price"] = txtprice.Text;                        
                        dr["SalePrice"] = txtsalesprice.Text;
                        dr["Batch_id"] = batchId;
                        dr["Batch"] = ddlBatch.SelectedItem.Text.Trim();

                        clr();
                        calculation(subTotal, tax_amount, discountamt);
                        txtPaidAmt.Enabled = true;
                        ViewState["Details"] = dt;
                        btnAdd.Visible = true;
                        btnUpdate.Visible = false;
                        counter = 0;
                        this.BindGrid();
                    }
                }
            }

            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
            
            //try
            //{


            //    if (Convert.ToString(ViewState["Details"])!= null)
            //    {
            //        if (validateddl() == true)
            //        {
            //            updatecal();
            //            int p_id = Convert.ToInt32(ddlproduct.SelectedValue);
            //            string discount = txtDiscount.Text.Trim();
            //            if (discount == "" || discount == null)
            //            {
            //                discount = "0";
            //            }
            //            Tax_percent t = new Tax_percent();
            //            t.company_id = companyId;
            //            t.product_id = p_id;
            //            t.All(t);
            //            string tax = t.tax_percentage;
            //            int Batch_id = Convert.ToInt32(ddlBatch.SelectedValue);
            //            int product_id = Convert.ToInt32(ddlproduct.SelectedValue);
            //            decimal SubTotal = Convert.ToInt32(txtquantity.Text) * Convert.ToInt32(txtprice.Text);
            //            decimal a = SubTotal / 100;
            //            decimal discountamt = a * decimal.Parse(discount);
            //            decimal b = a * decimal.Parse(tax);

            //            DataTable dt = ViewState["Details"] as DataTable;
            //            int row = Convert.ToInt32(ViewState["id"]);
            //            dt.Rows[row][0] = ddlVendor.SelectedItem.Text.Trim();
            //            dt.Rows[row][1] = ddlproduct.SelectedValue;
            //            dt.Rows[row][2] = txtPONo.Text.Trim();
            //            dt.Rows[row][3] = txtdate.Text.Trim();
            //            dt.Rows[row][4] = ddlproduct.SelectedItem.Text.Trim();
            //            dt.Rows[row][5] = ddlBatch.SelectedItem.Text.Trim();
            //            dt.Rows[row][6] = ddlBatch.SelectedValue;
            //            dt.Rows[row][7] = txtquantity.Text.Trim();
            //            dt.Rows[row][8] = txtprice.Text.Trim();
            //            dt.Rows[row][9] = txtDiscount.Text.Trim();
            //            dt.Rows[row][10] = discountamt;
            //            dt.Rows[row][11] = txtsalesprice.Text.Trim();
            //            dt.Rows[row][12] = tax;
            //            dt.Rows[row][13] = b;
            //            dt.Rows[row][14] = SubTotal;

            //            gvpurchasedetails.DataSource = dt;
            //            gvpurchasedetails.DataBind();

            //            clr();

            //            calculation(SubTotal, b, discountamt);

            //            btnAdd.Visible = true;
            //            btnUpdate.Visible = false;
            //        }
            //        else
            //        {
            //            lblbatch.Visible = true;
            //        }


            //    }



            //}
            //catch (Exception ex)
            //{

            //    ErrorLog.saveerror(ex);
            //    //Do Logging
            //}
        }

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            //savelogic();
            Save();
            
        }
        //public string a_date;
        //public string b_date;
        protected void gvpurchasedetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow grv = ((GridViewRow)((ImageButton)e.CommandSource).NamingContainer);
                decimal subTotal = Convert.ToDecimal(grv.Cells[5].Text) * Convert.ToDecimal(grv.Cells[6].Text);
                decimal a = subTotal / 100;
                decimal discount_percent = decimal.Parse(grv.Cells[9].Text) * 100 / decimal.Parse(grv.Cells[12].Text);
                decimal discountamt = a * Convert.ToDecimal(discount_percent.ToString("0.##"));
                decimal tax_amount = a * decimal.Parse(grv.Cells[10].Text);              
                

                if (e.CommandName == "Delete row")
                {
                    int rowIndex = grv.RowIndex;
                    ViewState["id"] = rowIndex;
                    DataTable dt = ViewState["Details"] as DataTable;
                    dt.Rows[rowIndex].Delete();
                    ViewState["Details"] = dt;
                    this.BindGrid();
                    DeleteCalculation(subTotal, tax_amount, discountamt);
                    clr();

                }
                else if (e.CommandName == "Update Row")
                {
                    if (!btnUpdate.Visible)
                    {
                        ViewState["id"] = grv.RowIndex;
                        ddlproduct.SelectedValue = grv.Cells[2].Text.ToString();
                        ddlBatch.SelectedValue = grv.Cells[4].Text.ToString();
                        txtquantity.Text = grv.Cells[5].Text.ToString();
                        txtprice.Text = grv.Cells[6].Text.ToString();
                        txtsalesprice.Text = grv.Cells[7].Text.ToString();
                        txtDiscount.Text = grv.Cells[8].Text.ToString();
                        txtTaxpercentage.Text = grv.Cells[10].Text.ToString();
                        btnUpdate.Visible = true;
                        btnAdd.Visible = false;
                        ddlproduct.Enabled = false;

                        DeleteCalculation(subTotal, tax_amount, discountamt);
                        //counter++;
                    }
                }

                
            }

            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }
        private void DeleteCalculation(decimal subTotal, decimal tax_amount, decimal discountamt)
        {
            decimal tot = 0;
            decimal tottax = 0;
            decimal dec = 0;
            decimal gtot = 0;
            tot = Convert.ToDecimal(lblsubtotal.Text) - subTotal;
            lblsubtotal.Text = tot.ToString("0.##");
            tottax = Convert.ToDecimal(lblTaxAmount.Text) - tax_amount;
            lblTaxAmount.Text = tottax.ToString("0.##");
            dec = Convert.ToDecimal(lblDiscountAmt.Text) - discountamt;
            lblDiscountAmt.Text = dec.ToString("0.##");

            gtot = Convert.ToDecimal(lblsubtotal.Text) + (Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(lblDiscountAmt.Text));
            lblGrandTotal.Text = gtot.ToString("0.##");
        }
        protected void btnclear_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("../Purchases/Purchase.aspx", false);
        }
       
        protected void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Convert.ToString(ViewState["total"]) != "" && Convert.ToString(ViewState["dis"]) != "" && Convert.ToString(ViewState["tax"]) != "")
                {

                    decimal t = Convert.ToDecimal(lblsubtotal.Text) - Convert.ToDecimal(ViewState["total"]);
                    decimal tx = Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(ViewState["tax"]);
                    decimal d = Convert.ToDecimal(lblDiscountAmt.Text) - Convert.ToDecimal(ViewState["dis"]);
                    lblsubtotal.Text = t.ToString();
                    lblTaxAmount.Text = tx.ToString();
                    lblDiscountAmt.Text = d.ToString();

                    if (Convert.ToString(ViewState["Details"])!= "")
                    {

                        DataTable dt = ViewState["Details"] as DataTable;
                        int row = Convert.ToInt32(ViewState["id"]);
                        dt.Rows[row].Delete();

                        gvpurchasedetails.DataSource = dt;
                        gvpurchasedetails.DataBind();
                    }

                    decimal gtot = Convert.ToDecimal(lblsubtotal.Text) + (Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(lblDiscountAmt.Text));
                    lblGrandTotal.Text = gtot.ToString();
                    txtBalanceAmt.Text = lblGrandTotal.Text;
                }

                else
                {
                    lblError.Text = "Row is empty";
                }
            }

            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        //protected void btnCancel_Click(object sender, System.EventArgs e)
        //{
        //    Response.Redirect("PurchaseHome.aspx");
        //}

     

        protected void txtGivenAmt_TextChanged(object sender, System.EventArgs e)
        {
            try
            {
                //decimal a = Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(txtGivenAmt.Text);
                //txtBalanceAmt.Text = a.ToString();
                decimal a = Convert.ToDecimal(lblGrandTotal.Text);
                decimal b = Convert.ToDecimal(txtPaidAmt.Text);
                if (a < b)
                {
                    txtPaidAmt.Text = lblGrandTotal.Text;
                    txtBalanceAmt.Text = "0";
                }

                else
                {
                    decimal c = Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(txtPaidAmt.Text);
                    txtBalanceAmt.Text = c.ToString();
                }
                UpdatePanel2.Update();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblbatch.Visible == true)
            {
                lblbatch.Visible = false;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //savelogic();
            Save();
            int a = Convert.ToInt32(Session["p_id"]);
            if (a != 0 || Convert.ToString(a) == null)
            {
                Response.Write(String.Format("<script>window.open('{0}','_blank')</script>", ResolveUrl(string.Format("~/Purchases/PrintPurchase.aspx?id={0}",a))));
            }
        }

        protected void btnClsFilter_Click(object sender, EventArgs e)
        {

        }


        protected void btn_Click(object sender, EventArgs e)
        {
            try
            {
                lblModalHeader.Text = "Add Product";
                //ModalIfram.Attributes.Add("src", "~/MasterModals/ProductMasterModel.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Pop", "AddSrcToIfram();", true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void ddlproduct_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                lblcheckDoubleError.Text = string.Empty;
                txtprice.Text = string.Empty;
                txtsalesprice.Text = string.Empty;
                int p_id = Convert.ToInt32(ddlproduct.SelectedValue);
                var product = context.tbl_product.Join(context.tbl_tax, p => p.tax_id, t => t.tax_id, (p, t) => new { p.purchas_price, p.sales_price, t.tax_percentage, p.company_id, p.branch_id, p.product_id }).Where(p => p.company_id == companyId && p.branch_id == branchId && p.product_id == p_id).SingleOrDefault();
                txtprice.Text = Convert.ToString(product.purchas_price);
                txtsalesprice.Text = Convert.ToString(product.sales_price);
                txtTaxpercentage.Text = Convert.ToString(product.tax_percentage);
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        //protected void btnCloseModel_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ddlproductbind();
        //        ddlVendorbind();
        //        ddlbatchbind();
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorLog.saveerror(ex);
        //        //Do Logging
        //    }
        //}

        protected void btnCloseMode_Click(object sender, EventArgs e)
        {
            try
            {
                ddlproductbind();
                ddlVendorbind();
                ddlbatchbind();
                ScriptManager.RegisterStartupScript(this, GetType(), "Close Modal Popup", "Closepopup();", true);
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }



    }
}