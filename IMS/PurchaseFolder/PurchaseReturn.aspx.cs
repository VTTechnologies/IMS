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

namespace IMS.PurchaseFolder
{
    public partial class PurchaseReturn : System.Web.UI.Page
    {
        /// <summary>
        /// Objects That are used in coding
        /// </summary>
        static int companyId = 0, branchId = 0, financialYearId = 0;
        string user_id = string.Empty;
        IMS_TESTEntities context = new IMS_TESTEntities();
        SqlHelper helper = new SqlHelper();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionValue();
            if (!IsPostBack)
            {
                if (ViewState["Details"] == null)
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Columns.Add("purchasedetails_id");
                    dataTable.Columns.Add("Product_id");
                    dataTable.Columns.Add("batch_id");
                    dataTable.Columns.Add("unit_id");
                    dataTable.Columns.Add("tax_id");
                    dataTable.Columns.Add("amount");
                    dataTable.Columns.Add("dicount_amt");
                    dataTable.Columns.Add("tax_amt");
                    dataTable.Columns.Add("purchase_rate");
                    dataTable.Columns.Add("quantity");
                    dataTable.Columns.Add("product_name");
                    dataTable.Columns.Add("unit_name");
                    dataTable.Columns.Add("batch_name");
                    dataTable.Columns.Add("tax_percentage");
                    ViewState["Details"] = dataTable;
                }
                this.BindGrid();
                ddlpaymentmodebind();
            }
        }
        /// <summary>
        /// All The Methods
        /// </summary>

        #region Methods
        [System.Web.Services.WebMethod]
        public static string[] ValidateQuantity(decimal enterdQuantity,int productid,int purchaseId)
        {           
            string[] isfail = new string[2];
            IMS_TESTEntities context = new IMS_TESTEntities();
           // int purchaseId = Convert.ToInt32(hdnPurchaseId.Value);
            try
            {
                if (enterdQuantity != 0 && productid != 0)
                {
                    if (companyId != 0 && purchaseId != 0)
                    {
                        SqlHelper helper = new SqlHelper();
                        var stockQuantity = context.tbl_stock.Where(s => s.company_id == companyId && s.product_id == productid).FirstOrDefault();

                        var returnQuantity = context.GetReturnQuantity(purchaseId, Constants.Purchase, productid,companyId).FirstOrDefault();
                        if (enterdQuantity <= returnQuantity)
                        {
                            if (stockQuantity.qty < Convert.ToDecimal(enterdQuantity))
                            {
                                isfail[0] = "true";
                                //lblcheckDoubleError.Visible = true;
                                isfail[1] = "Insufficient stock quantity.";
                                return isfail;
                            }
                        }
                        else
                        {
                            if (stockQuantity.qty <= returnQuantity)
                            {
                                isfail[0] = "true";
                                //lblcheckDoubleError.Visible = true;
                                isfail[1] = "Only " + stockQuantity.qty + " can be return for the selected product, Since some of item sold.";
                                return isfail;
                            }
                            else {
                                isfail[0] = "true";
                                //lblcheckDoubleError.Visible = true;
                                isfail[1] = "Only " + returnQuantity + " can be return for the selected product.";
                                return isfail;
                            }
                        }
                    }
                }
                else
                {
                    isfail[0] = "true";
                    //lblcheckDoubleError.Visible = true;
                    isfail[1] = "Please select product or enter correct return quantity.";
                    return isfail;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
            return isfail;
        }
        //public bool ProductChecker(int id)
        //{
        //    for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
        //    {
        //        int pid = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text);
        //        decimal qty = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[5].Text);

        //        if (pid == id)
        //        {
        //            ddlproduct.ClearSelection();
        //            ddlproduct.Items.FindByValue(pid.ToString()).Enabled = false;
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public bool productvalid(int productid, decimal enterdQuantity, int count)
        {
            decimal totalqty = 0;
            decimal availableqty = 0;

            decimal stockQuantity = Convert.ToDecimal(Session["quant"]);
            for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
            {
                int pid = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text);
                decimal gridQty = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[5].Text);

                if (pid == productid)
                {
                    if (count == 0)
                    {
                        ddlproduct.Items.Remove(ddlproduct.Items.FindByValue(pid.ToString()));
                        //totalqty = gridQty + enterdQuantity + totalqty;
                    }

                }
            }

            if (stockQuantity < totalqty || stockQuantity < enterdQuantity)
            {
                lblcheckDoubleError.ForeColor = System.Drawing.Color.Red;
                lblcheckDoubleError.Text = "Out Of Stock";
                return false;
            }

            else
            {
                availableqty = stockQuantity - enterdQuantity;
                lblcheckDoubleError.ForeColor = System.Drawing.Color.Green;
                lblcheckDoubleError.Text = "Avialable Quantity In Stock " + availableqty;
                return true;
            }
            // if(total > avali)

        }
        public void ddlpaymentmodebind()
        {
            int c_id = Convert.ToInt32(Session["company_id"]);
            List<tbl_paymentmode> cd = context.tbl_paymentmode.Where(x => x.status == true).ToList();
            ddlPaymentMode.DataTextField = "paymentmode_name";
            ddlPaymentMode.DataValueField = "paymentode_id";
            ddlPaymentMode.DataSource = cd;
            ddlPaymentMode.DataBind();
        }
        private void BindOrigianlPurchaseGrid()
        {
            try
            {
                int purchaseId = Convert.ToInt32(hdnPurchaseId.Value);
                var purcahseDetails= context.sp_GetPurchaseDetailsById(purchaseId).ToList();
                if(purcahseDetails!=null)
                {
                    lblBalanceAmnt.Text = purcahseDetails.FirstOrDefault().balance_amnt.ToString();
                    lblGivenAmnt.Text = purcahseDetails.FirstOrDefault().given_amnt.ToString();
                    lblTotalAmnt.Text = purcahseDetails.FirstOrDefault().total_amnt.ToString();
                    lblTotalTax.Text = purcahseDetails.FirstOrDefault().total_tax.ToString();
                    lblTotalDiscount.Text = purcahseDetails.FirstOrDefault().total_discount.ToString();
                    lblGrndTotal.Text = purcahseDetails.FirstOrDefault().grand_total.ToString();
                }
               
                GrdOriginalPurchase.DataSource = purcahseDetails;
                GrdOriginalPurchase.DataBind();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
            }
        }
        protected void BindGrid()
        {
            try
            {          
                gvpurchasedetails.DataSource = (DataTable)ViewState["Details"];
                gvpurchasedetails.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }
        public void GetpurchaseDetails()
        {
            try
            {
                var purchase = context.tbl_purchase.Where(w => w.InvoiceNumber == txtPoNo.Text && w.company_id == companyId && w.branch_id == branchId).FirstOrDefault();
                if (purchase == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Invoice does not exist, Please enter valid Invoice Number.','True');", true);
                    return;
                }
                hdnPurchaseId.Value = purchase.purchase_id.ToString();

                var products = context.tbl_purchasedetails.Join(context.tbl_product, pd => pd.product_id, p => p.product_id, (pd, p) => new { pd.purchase_id, pd.product_id, p.product_name }).Where(w => w.purchase_id == purchase.purchase_id).ToList();

                ddlproduct.DataTextField = "product_name";
                ddlproduct.DataValueField = "product_id";
                ddlproduct.DataSource = products;
                ddlproduct.DataBind();
                ddlproduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
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
        public void calculation(decimal amt, decimal tax, decimal dis)
        {
            decimal tot = 0;
            decimal tottax = 0;
            decimal dec = 0;
            decimal gtot = 0;
            tot = Convert.ToDecimal(lblsubtotal.Text) + amt;
            lblsubtotal.Text = tot.ToString("0.##");
            tottax = Convert.ToDecimal(lblTaxAmount.Text) + tax;
            lblTaxAmount.Text = tottax.ToString("0.##");
            dec = Convert.ToDecimal(lblDiscountAmt.Text) + dis;
            lblDiscountAmt.Text = dec.ToString("0.##");

            gtot = Convert.ToDecimal(lblsubtotal.Text) + (Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(lblDiscountAmt.Text));
            lblGrandTotal.Text = gtot.ToString("0.##");


        }

        public void clr()
        {

            ddlproduct.SelectedIndex = 0;
            txtquantity.Text = string.Empty;
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

        protected void Save()
        {
            try
            {
                int purchaseId = Convert.ToInt32(hdnPurchaseId.Value);
                if (purchaseId == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Please Enter Purchase No','False');", true);
                    return;
                }
                //Get Origianl Purchase Details
                tbl_purchase purchase = new tbl_purchase();
                purchase = context.tbl_purchase.Where(pd => pd.purchase_id == purchaseId && pd.company_id == companyId && pd.branch_id == branchId).FirstOrDefault();

                tbl_purchasereturn purchaseReturn = new tbl_purchasereturn();
                purchaseReturn.purchase_id = purchaseId;
                purchaseReturn.company_id = companyId;
                purchaseReturn.branch_id = branchId;
                purchaseReturn.financialyear_id = financialYearId;
                purchaseReturn.InvoiceNumber = txtPoNo.Text;
                purchaseReturn.given_amnt = Convert.ToDecimal(txtGivenAmt.Text);
                purchaseReturn.balance_amnt = Convert.ToDecimal(txtBalanceAmt.Text);
                purchaseReturn.paymentmode_id = Convert.ToInt32(ddlPaymentMode.SelectedValue);
                purchaseReturn.status = true;
                purchaseReturn.party_id = Convert.ToInt32(purchase.party_id);
                purchaseReturn.total_tax = Convert.ToDecimal(lblTaxAmount.Text);
                purchaseReturn.total_discount = Convert.ToDecimal(lblDiscountAmt.Text);
                purchaseReturn.total_amount = Convert.ToDecimal(lblsubtotal.Text);
                purchaseReturn.grand_total = Convert.ToDecimal(lblGrandTotal.Text);
                purchaseReturn.created_by = user_id;
                purchaseReturn.created_date = DateTime.Now;

                for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
                {
                    int productId = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text);
                    int batchId = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[4].Text);
                    tbl_product product = context.tbl_product.Where(w => w.product_id == productId).FirstOrDefault();


                    tbl_purchasereturndetails purchaseReturnDetails = new tbl_purchasereturndetails();
                    purchaseReturnDetails.product_id = productId;
                    purchaseReturnDetails.batch_id = batchId;
                    purchaseReturnDetails.tax_id = product.tax_id;
                    purchaseReturnDetails.unit_id = product.unit_id;
                    purchaseReturnDetails.tax_amt = gvpurchasedetails.Rows[i].Cells[10].Text;
                    purchaseReturnDetails.quantity = Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[5].Text);
                    purchaseReturnDetails.amount = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[11].Text);
                    purchaseReturnDetails.created_by = Convert.ToString(user_id);
                    purchaseReturnDetails.created_date = Convert.ToDateTime(DateTime.Now);
                    purchaseReturnDetails.status = true;

                    tbl_stock stock = new tbl_stock();
                    stock = context.tbl_stock.Where(w => w.company_id == companyId && w.branch_id == branchId && w.product_id == productId && w.batch_id == batchId).FirstOrDefault();
                    stock.qty = stock.qty - Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[5].Text);
                    stock.modified_by = Convert.ToString(user_id);
                    stock.modified_date = Convert.ToDateTime(DateTime.Now);

                    purchaseReturn.tbl_purchasereturndetails.Add(purchaseReturnDetails);
                }

                //Update Original Given And Balance amnt on Return
                purchase.given_amnt = purchase.given_amnt - purchaseReturn.given_amnt;
                purchase.balance_amnt = purchase.balance_amnt - purchaseReturn.balance_amnt;
                purchase.modified_by = Convert.ToString(user_id);
                purchase.modified_date = Convert.ToDateTime(DateTime.Now);

                context.tbl_purchasereturn.Add(purchaseReturn);
                context.SaveChanges();
                string invoiceNumber = purchaseReturn.InvoiceNumber;
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('saved Successfully, You order number is " + invoiceNumber + "','True');", true);
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }
        #endregion


        /// <summary>
        /// All The Events That are used in this page
        /// </summary>

        #region Events
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OriginalPurchaseDetails.Visible = true;
            ddlproduct.Items.Clear();
            GetpurchaseDetails();
            BindOrigianlPurchaseGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int purchaseId = Convert.ToInt32(hdnPurchaseId.Value);
            lblcheckDoubleError.Text = string.Empty;
            int productId = Convert.ToInt32(ddlproduct.SelectedValue);
            decimal enteredQuantity = Convert.ToDecimal(txtquantity.Text);

            try
            {
                //Get Original price, Tax and discount happened during Purchase
                var productDetails = context.sp_GetPurchaseDetailsById(purchaseId).ToList();
                if (productDetails != null)
                {
                   var oneproductDetail = productDetails.Where(w => w.product_id == productId);
                    if (!Convert.ToBoolean(ValidateQuantity(enteredQuantity, productId, purchaseId)[0]))
                    {
                        decimal subTotal = Convert.ToDecimal(txtquantity.Text) * Convert.ToDecimal(oneproductDetail.FirstOrDefault().purchase_rate);
                        decimal a = subTotal / 100;
                        decimal discount_percent = (Convert.ToDecimal(oneproductDetail.FirstOrDefault().dicount_amt) * 100) / Convert.ToDecimal(oneproductDetail.FirstOrDefault().amount);
                        decimal discountamt = a * Convert.ToDecimal(discount_percent.ToString("0.##"));
                        decimal tax_amount = a * Convert.ToDecimal(oneproductDetail.FirstOrDefault().tax_percentage);

                        clr();
                        calculation(subTotal, tax_amount, discountamt);
                        txtBalanceAmt.Enabled = true;
                        txtGivenAmt.Enabled = true;

                        DataTable tbl = (DataTable)ViewState["Details"];
                                                
                        tbl.Rows.Add(oneproductDetail.FirstOrDefault().purchasedetails_id, productId, oneproductDetail.FirstOrDefault().batch_id, oneproductDetail.FirstOrDefault().unit_id,
                            oneproductDetail.FirstOrDefault().tax_id, subTotal, discountamt, tax_amount, oneproductDetail.FirstOrDefault().purchase_rate, enteredQuantity,
                            oneproductDetail.FirstOrDefault().product_name, oneproductDetail.FirstOrDefault().unit_name, oneproductDetail.FirstOrDefault().batch_name, 
                            oneproductDetail.FirstOrDefault().tax_percentage);
                        ViewState["Details"] = tbl;
                        this.BindGrid();
                        ddlproduct.Items.FindByValue(productId.ToString()).Enabled = false;                      

                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void SaveLogic()
        {
            SqlTransaction transaction;
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandTimeout = 600000;
            con.Open();
            transaction = con.BeginTransaction("Transaction");
            cmd.Transaction = transaction;
            try
            {
                string date = DateTime.Today.ToString();
                string user = Session["UserID"].ToString();
                int c_id = Convert.ToInt32(Session["company_id"]);
                int b_id = Convert.ToInt32(Session["branch_id"]);
                int party_id = 0;
                int a = Convert.ToInt32(hdnPurchaseId.Value);
                if (a != 0)
                {
                    //tbl_purchase p = new tbl_purchase();
                    //p.company_id = c_id;
                    //p.purchase_id = a;
                    //// p.All2(p);
                    var purchase = context.tbl_purchase.Where(pd => pd.purchase_id == a && pd.company_id == c_id).FirstOrDefault();
                    party_id = Convert.ToInt32(purchase.party_id);

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Please Enter Purchase No','False');", true);
                    return;
                }


                int Purchase_id = Convert.ToInt32(a);
                if (Purchase_id != 0)
                {

                    decimal tax_amount = Convert.ToDecimal(lblTaxAmount.Text);
                    decimal sub_total = Convert.ToDecimal(lblsubtotal.Text);
                    decimal discount = Convert.ToDecimal(lblDiscountAmt.Text);
                    decimal grandtotal = Convert.ToDecimal(lblGrandTotal.Text);

                    //Purchase Return Main Table Insertion Code
                    cmd.CommandText = "sp_insertpurchasereturnmain";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Purchase_id", Purchase_id);
                    cmd.Parameters.AddWithValue("@branch_id", b_id);
                    cmd.Parameters.AddWithValue("@company_id", c_id);
                    cmd.Parameters.AddWithValue("@total_tax", tax_amount);
                    cmd.Parameters.AddWithValue("@actual_amount", sub_total);
                    cmd.Parameters.AddWithValue("@grand_total", grandtotal);
                    cmd.Parameters.AddWithValue("@total_discount ", discount);
                    cmd.Parameters.AddWithValue("@created_by", user);
                    cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                    cmd.Parameters.Add("@purchasereturnmain_id", SqlDbType.Int);
                    cmd.Parameters["@purchasereturnmain_id"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    Session["prmid"] = Convert.ToInt32(cmd.Parameters["@purchasereturnmain_id"].Value);
                    cmd.Parameters.Clear();
                }


                int mcid = Convert.ToInt32(Session["prmid"]);

                for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
                {
                    GridViewRow row = gvpurchasedetails.Rows[i];
                    //Purchase Details Saving Code Start Here
                    int salesedetail_id = Convert.ToInt32(row.Cells[12].Text);
                    if (salesedetail_id != 0)
                    {
                        cmd.CommandText = "sp_insert_purchase_return";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@purchasereturnmain_id", mcid);
                        cmd.Parameters.AddWithValue("@purchasedetails_id", salesedetail_id);
                        cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(row.Cells[2].Text));
                        cmd.Parameters.AddWithValue("@batch_id", Convert.ToInt32(row.Cells[4].Text));
                        cmd.Parameters.AddWithValue("@tax_amt", Convert.ToDecimal(row.Cells[10].Text));
                        cmd.Parameters.AddWithValue("@quantity", Convert.ToDecimal(row.Cells[5].Text));
                        cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(row.Cells[11].Text));
                        cmd.Parameters.AddWithValue("@created_by", user);
                        cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                        cmd.Connection = con;
                        cmd.CommandTimeout = 600000;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    // Stock & Stock Transaction Data Saving Code end

                }




                cmd.Parameters.Clear();

                cmd.CommandText = "sp_InsertMonyTransaction";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@company_id", c_id);
                cmd.Parameters.AddWithValue("@branch_id", b_id);
                cmd.Parameters.AddWithValue("@party_id", party_id);
                cmd.Parameters.AddWithValue("@given_amt", txtGivenAmt.Text);
                cmd.Parameters.AddWithValue("@grand_total", lblGrandTotal.Text);
                cmd.Parameters.AddWithValue("@balance_amt", txtBalanceAmt.Text);
                cmd.Parameters.AddWithValue("@in_out", "In");
                cmd.Parameters.AddWithValue("@paymentmode_id", ddlPaymentMode.SelectedValue);
                cmd.Parameters.AddWithValue("@transaction_typ", "Purchase Return");
                cmd.Parameters.AddWithValue("@transactio_type_id", mcid);
                cmd.Parameters.AddWithValue("@created_by", user);
                cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                cmd.Connection = con;
                cmd.CommandTimeout = 600000;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                con.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Saved successfully','True');", true);


            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        //protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int purchaseId = Convert.ToInt32(hdnPurchaseId.Value);
        //        lblcheckDoubleError.Text = string.Empty;
        //        int productId = Convert.ToInt32(ddlproduct.SelectedValue);
        //        var stockQuantity = context.tbl_stock.Where(s => s.company_id == companyId && s.product_id == productId).FirstOrDefault();
        //        var returnQuantity = context.GetReturnQuantity(purchaseId, Constants.Purchase, productId).FirstOrDefault().Value;
        //        //int data = helper.GetStockQuantity(Convert.ToInt32(HttpContext.Current.Session["company_id"]), Convert.ToInt32(p_id));
        //        Session["quant"] = stockQuantity.qty;
        //        txtAvailableQuantity.Text = returnQuantity.ToString();
        //        //lblcheckDoubleError.ForeColor = System.Drawing.Color.Green;
        //        //lblcheckDoubleError.Text = "Avialable Quantity In Stock " + stockQuantity.qty;
        //        UpdatePanel1.Update();
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorLog.saveerror(ex);
        //        //Do Logging
        //    }
        //}


        

        protected void gvpurchasedetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow grv = ((GridViewRow)((ImageButton)e.CommandSource).NamingContainer);

                decimal subTotal = Convert.ToDecimal(grv.Cells[5].Text) * Convert.ToDecimal(grv.Cells[6].Text);
                decimal a = subTotal / 100;
                decimal discount_percent = decimal.Parse(grv.Cells[7].Text) * 100 / decimal.Parse(grv.Cells[10].Text);
                decimal discountamt = a * Convert.ToDecimal(discount_percent.ToString("0.##"));
                decimal tax_amount = a * decimal.Parse(grv.Cells[8].Text);
                DeleteCalculation(subTotal, tax_amount, discountamt);

                if (e.CommandName == "Delete row")
                {                    
                    int rowIndex = grv.RowIndex;
                    ViewState["id"] = rowIndex;                                 
                    ddlproduct.Items.FindByValue(grv.Cells[2].Text).Enabled = true;
                    DataTable dt = ViewState["Details"] as DataTable;
                    dt.Rows[rowIndex].Delete();
                    ViewState["Details"] = dt;
                    this.BindGrid();                   

                }
                else if (e.CommandName == "Update Row")
                {
                    if (!btnUpdate.Visible)
                    {
                        
                        ViewState["id"] = grv.RowIndex;
                        ddlproduct.SelectedValue = grv.Cells[2].Text.ToString();

                        ddlproduct.Items.FindByValue(grv.Cells[2].Text).Enabled = true;
                        txtquantity.Text = grv.Cells[5].Text.ToString();
                        btnUpdate.Visible = true;
                        btnAdd.Visible = false;
                        ddlproduct.Enabled = false;                        
                        DeleteCalculation(subTotal, tax_amount, discountamt);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);                
            }
        }

        private void DeleteCalculation(decimal subTotal,decimal tax_amount ,decimal discountamt)
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int purchaseId = Convert.ToInt32(hdnPurchaseId.Value);
            lblcheckDoubleError.Text = string.Empty;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["Details"];
            int productId = Convert.ToInt32(ddlproduct.SelectedValue);
            decimal enteredQuantity = Convert.ToDecimal(txtquantity.Text);
            try
            {
                if (!Convert.ToBoolean(ValidateQuantity(enteredQuantity, productId, purchaseId)[0]))
                {
                    DataRow dr = dt.Select("product_id="+ productId + "").FirstOrDefault();
                    if (dr != null)
                    {                    
                        decimal subTotal = Convert.ToDecimal(txtquantity.Text) * Convert.ToDecimal(dr["purchase_rate"]);
                        decimal a = subTotal / 100;
                        decimal discount_percent = (Convert.ToDecimal(dr["dicount_amt"]) * 100) / Convert.ToDecimal(dr["amount"]);
                        decimal discountamt = a * Convert.ToDecimal(discount_percent.ToString("0.##"));
                        decimal tax_amount = a * Convert.ToDecimal(dr["tax_percentage"]);

                        dr["quantity"] = txtquantity.Text;
                        dr["tax_amt"] = tax_amount;
                        dr["dicount_amt"] = discountamt;
                        dr["amount"] = subTotal;

                        clr();                       
                        calculation(subTotal, tax_amount, discountamt);
                        txtBalanceAmt.Enabled = true;
                        txtGivenAmt.Enabled = true;                      
                        ViewState["Details"] = dt;
                        ddlproduct.Enabled = true;
                        this.BindGrid();
                        ddlproduct.Items.FindByValue(productId.ToString()).Enabled = false;
                        btnUpdate.Visible = false;
                        btnAdd.Visible = true;
                    }
                }             
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);               
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["total"] != null && ViewState["dis"] != null && ViewState["tax"] != null)
                {
                    updatecal();

                    if (ViewState["Details"] != null)
                    {
                        DataTable dt = ViewState["Details"] as DataTable;
                        int row = Convert.ToInt32(ViewState["id"]);
                        dt.Rows[row].Delete();
                        lblcheckDoubleError.Text = string.Empty;
                        gvpurchasedetails.DataSource = dt;
                        gvpurchasedetails.DataBind();
                    }
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("PurchaseReturn.aspx", false);
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void txtGivenAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //decimal a = Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(txtGivenAmt.Text);
                //txtBalanceAmt.Text = a.ToString();
                decimal a = Convert.ToDecimal(lblGrandTotal.Text);
                decimal b = Convert.ToDecimal(txtGivenAmt.Text);
                if (a < b)
                {
                    txtGivenAmt.Text = lblGrandTotal.Text;
                    txtBalanceAmt.Text = "0";
                }
                else
                {
                    decimal c = Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(txtGivenAmt.Text);
                    txtBalanceAmt.Text = c.ToString();
                }
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }
        #endregion
    }
}