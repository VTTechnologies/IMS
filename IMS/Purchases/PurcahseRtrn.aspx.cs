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

namespace IMS
{
    public partial class PuchaseReturn : System.Web.UI.Page
    {
        int companyId = 0, branchId = 0, financialYearId = 0;
        string user_id = string.Empty;
        IMS_TESTEntities context = new IMS_TESTEntities();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString);
    
        int a;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (Session["deletdata"] == null)
                    {
                        DataTable deletedata = new DataTable();
                        deletedata.Columns.Add("purchase_id");
                        deletedata.Columns.Add("row");
                        deletedata.Columns.Add("product_id");
                        deletedata.Columns.Add("batch_id");
                        deletedata.Columns.Add("tax_amt");
                        deletedata.Columns.Add("quantity");
                        deletedata.Columns.Add("amount");
                        Session["deletdata"] = deletedata;
                    }


                    if (Request.QueryString["id"] != null)
                    {
                        a = Convert.ToInt32(Request.QueryString["id"]);
                    }
                    gridbind();
                    ddlVendorbind();
                    ddlproductbind();
                    ddlbatchbind();
                    ddlpaymentmodebind();

                    pagebind();

                }
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }

        }
        private void SessionValue()
        {
            user_id = Convert.ToString(Session["UserID"]);
            companyId = Convert.ToInt32(Session["company_id"]);
            branchId = Convert.ToInt32(Session["branch_id"]);
            financialYearId = Convert.ToInt32(Session["financialyear_id"]);
        }

        public void ddlVendorbind()
        {
            int c_id = Convert.ToInt32(Session["company_id"]);

            List<tbl_party> cd = context.tbl_party.Where(x => x.status == true && x.company_id == c_id && x.party_type == "Vendor").ToList();
            ddlVendor.DataTextField = "party_name";
            ddlVendor.DataValueField = "party_id";
            ddlVendor.DataSource = cd;
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem("--Select Vendor--", "0"));
        }

        public void ddlproductbind()
        {
            int c_id = Convert.ToInt32(Session["company_id"]);

            int b_id = Convert.ToInt32(Session["branch_id"]);
            //context.tbl_product.Where(x => x.status == true && x.company_id == c_id).ToList();
            ddlproduct.DataTextField = "product_name";
            ddlproduct.DataValueField = "product_id";
            ddlproduct.DataSource = context.sp_SelectProduct(c_id,b_id);
            ddlproduct.DataBind();
            ddlproduct.Items.Insert(0, new ListItem("--Select Product--", "0"));
        }

        public void ddlbatchbind()
        {
            int c_id = Convert.ToInt32(Session["company_id"]);
           List<tbl_batch> cd = context.tbl_batch.Where(x => x.status == true && x.company_id == c_id).ToList();
            ddlBatch.DataTextField = "batch_name";
            ddlBatch.DataValueField = "batch_id";
            ddlBatch.DataSource = cd;
            ddlBatch.DataBind();
            ddlBatch.Items.Insert(0, new ListItem("--Select Batch--", "0"));
        }
        public void ddlpaymentmodebind()
        {
            List<tbl_paymentmode> cd = context.tbl_paymentmode.Where(x => x.status == true ).ToList();
            ddlPaymentMode.DataTextField = "paymentmode_name";
            ddlPaymentMode.DataValueField = "paymentode_id";
            ddlPaymentMode.DataSource = cd;
            ddlPaymentMode.DataBind();
            ddlPaymentMode.Items.Insert(0, new ListItem("Select Payment Mode", "0"));
        }
        public void pagebind()
        {
            int c_id = Convert.ToInt32(Session["company_id"]);
            tbl_purchase p = new tbl_purchase();
            p.company_id = c_id;
            p.purchase_id = a;
            ////Shakeeb
            ////p.All2(p);
            ////txtdate.Text = p.date;
            ////ddlVendor.SelectedValue = p.party_id.ToString();
            ////txtPONo.Text = p.po_no;
            ////lblsubtotal.Text = p.actual_amount.ToString();
            ////lblTaxAmount.Text = p.total_tax.ToString();
            ////lblDiscountAmt.Text = p.discount.ToString();
            ////lblGrandTotal.Text = p.grand_total.ToString();
            ////txtBalanceAmt.Text = p.balance.ToString();
            ////ViewState["balanceamt"] = txtGivenAmt.Text = p.given.ToString();

        }
        public void gridbind()
        {
            //if (a != 0)
            //{

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_SelectProductbyid";
            cmd.Parameters.AddWithValue("@purchsae_id", a);
            
            cmd.Connection = con;

            try
            {

                con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                Session["table"] = ds.Tables[0]; ;
                gvpurchasedetails.DataSource = (DataTable)Session["table"];
                gvpurchasedetails.DataBind();
            }
            //           GridView1.DataSource = context.sp_SelectPurchase(c_id);
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
           // SqlHelper sh = new SqlHelper();
           // var result = context.sp_SelectProductbyid(a);
           //// Enum e = Enum.Parse(typeof(var),result);
           // DataTable dtresult = sh.LINQToDataTable(result);
           // Session["table"] = dtresult;
           // gvpurchasedetails.DataSource = (DataTable)Session["table"];
           // gvpurchasedetails.DataBind();


            //}
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                updatecal();
                 string batch = ddlBatch.SelectedItem.Text.Trim();
                string pname = ddlproduct.SelectedItem.Text.Trim();
                int c_id = Convert.ToInt32(Session["company_id"]);
                int p_id = Convert.ToInt32(ddlproduct.SelectedValue);
                string discount = txtdiscount.Text.Trim();
                Tax_percent t = new Tax_percent();
                t.company_id = c_id;
                t.product_id = p_id;
                t.All(t);
                string tax = t.tax_percentage;
                int tax_id = t.tax_id;
                int unit_id = t.unit_id;
                string unit_name = t.unit_name;
                int Batch_id = Convert.ToInt32(ddlBatch.SelectedValue);
                int product_id = Convert.ToInt32(ddlproduct.SelectedValue);
                decimal SubTotal = Convert.ToInt32(txtquantity.Text) * Convert.ToInt32(txtprice.Text);
                decimal a = SubTotal / 100;
                decimal discountamt = a * decimal.Parse(discount);
                decimal b = a * decimal.Parse(tax);


                //decimal subtot = Convert.ToDecimal(ViewState["subtot"]) - SubTotal;
                //decimal tax_amount = (subtot / 100) * decimal.Parse(tax);
                //decimal discount_amount = (subtot / 100) * decimal.Parse(discount);
                //decimal qty = Convert.ToDecimal(ViewState["qtybefore"]) - Convert.ToDecimal(txtquantity.Text);
                //ViewState["amount"] = SubTotal;
                if (Convert.ToDecimal(ViewState["qtybefore"]) < Convert.ToDecimal(txtquantity.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Return Quantity Should be equal or less then purchase quantity','False');", true);
                    return;
                }
               
                DataTable dt = Session["table"] as DataTable;
                int row = Convert.ToInt32(ViewState["id"]);
                dt.Rows[row][0] = ViewState["Purchasedetail_id"];
                dt.Rows[row][1] = ddlproduct.SelectedValue;             //ddlVendor.SelectedItem.Text.Trim();
                dt.Rows[row][2] = ddlBatch.SelectedValue;
                dt.Rows[row][3] = unit_id;
                dt.Rows[row][4] = tax_id;
                dt.Rows[row][5] = SubTotal;
                dt.Rows[row][6] = discountamt;
                dt.Rows[row][7] = b;
                dt.Rows[row][8] = txtprice.Text.Trim();
                dt.Rows[row][9] = txtsalesprice.Text.Trim(); //txtdiscount.Text.Trim();
                dt.Rows[row][10] = txtquantity.Text.Trim(); 
                dt.Rows[row][11] = pname;
                dt.Rows[row][12] = unit_name;
                dt.Rows[row][13] = batch;
                dt.Rows[row][14] = tax;

                gvpurchasedetails.DataSource = dt;
                gvpurchasedetails.DataBind();

                clr();

                calculation(SubTotal, b, discountamt);
                giventotalcal(Convert.ToDecimal(lblGrandTotal.Text), Convert.ToDecimal(txtGivenAmt.Text));
                //btnAdd.Visible = true;
                btnUpdate.Visible = false;

            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }

        }

        public void updatecal()
        {
            if (lblsubtotal.Text != "0" || lblGrandTotal.Text != "0")
            {
             decimal a1 = Convert.ToDecimal(lblsubtotal.Text) - Convert.ToDecimal(ViewState["subtot"]);
            decimal b1 = Convert.ToDecimal(lblDiscountAmt.Text) - Convert.ToDecimal(ViewState["dis"]);
            decimal c = Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(ViewState["taxamount"]);
            lblsubtotal.Text = a1.ToString();
            lblDiscountAmt.Text = b1.ToString();
            lblTaxAmount.Text = c.ToString();
            decimal d = (a1 + c) - b1;
            lblGrandTotal.Text = d.ToString();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string batch = ddlBatch.SelectedItem.Text.Trim();
                string pname = ddlproduct.SelectedItem.Text.Trim();
                int p = Convert.ToInt32(ddlproduct.SelectedValue);
                int b = Convert.ToInt32(ddlBatch.SelectedValue);
                int c_id = Convert.ToInt32(Session["company_id"]);
                int quantity = Convert.ToInt32(txtquantity.Text);
                string price = txtprice.Text.Trim();
                string discount = txtdiscount.Text.Trim();
                string salesp = txtsalesprice.Text.Trim();
                int u_id = Convert.ToInt32(Session["UserID"]);

                Tax_percent t = new Tax_percent();
                t.company_id = c_id;
                t.product_id = p;
                t.All(t);
                decimal pric3 = Convert.ToDecimal(price);
                decimal saleprice = Convert.ToDecimal(salesp);
                int tax_id = t.tax_id;
                int unit_id = t.unit_id;
                string unit_name = t.unit_name;
                string tax = t.tax_percentage;
            
                decimal SubTotal = quantity * Convert.ToInt32(txtprice.Text);
                decimal a1 = SubTotal / 100;
                decimal discountamt = a1 * decimal.Parse(discount);
                decimal tax_amount = a1 * decimal.Parse(tax);
                string date = Convert.ToString(DateTime.Today);


                DataTable dt = (DataTable)Session["table"];
                dt.Rows.Add(1,p, b, unit_id, tax_id, SubTotal, discountamt, tax_amount, price, salesp, quantity, pname, unit_name, batch, tax);
                Session["table"] = dt;
                gvpurchasedetails.DataSource = dt;
                gvpurchasedetails.DataBind();
                calculation(SubTotal, tax_amount, discountamt);
                clr();
                UpdateAdd.Update();


            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }


        public void clr()
        {
            ddlBatch.SelectedIndex = 0;
            ddlproduct.SelectedIndex = 0;
            txtquantity.Text = "";
            txtprice.Text = "";
            txtdiscount.Text = "0";
            txtsalesprice.Text = "";
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

        protected void gvpurchasedetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int c_id = Convert.ToInt32(Session["company_id"]);
                if (e.CommandName == "Delete row")
                {

                    GridViewRow grv = ((GridViewRow)((ImageButton)e.CommandSource).NamingContainer);
                    ViewState["total"] = grv.Cells[12].Text.ToString();
                    ViewState["dis"] = grv.Cells[9].Text.ToString();
                    ViewState["tax"] = grv.Cells[11].Text.ToString();

                    int rowIndex = grv.RowIndex;

                    ViewState["index"] = rowIndex;
                    ViewState["id"] = grv.Cells[13].Text.ToString();
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else if (e.CommandName == "Update Row")
                {
                    GridViewRow grv = ((GridViewRow)((ImageButton)e.CommandSource).NamingContainer);
                    ViewState["id"] = grv.RowIndex;
                    //ddlproduct.SelectedIndex = Convert.ToInt32(grv.Cells[2].Text);
                    ddlproduct.SelectedValue = grv.Cells[3].Text.ToString();
                    //ddlBatch.SelectedIndex = Convert.ToInt32(grv.Cells[4].Text);
                    ddlBatch.SelectedValue = grv.Cells[5].Text.ToString();
                    txtquantity.Text = grv.Cells[6].Text.ToString();
                    txtprice.Text = grv.Cells[7].Text.ToString();
                    //txtdiscount.Text = grv.Cells[8].Text.ToString();
                    txtsalesprice.Text = grv.Cells[8].Text.ToString();
                    ViewState["Purchasedetail_id"] = grv.Cells[13].Text.ToString();
                    btnUpdate.Visible = true;
                   // btnAdd.Visible = false;
                    ViewState["qtybefore"] = grv.Cells[6].Text.ToString();
                    ViewState["subtot"] = grv.Cells[12].Text;
                    ViewState["dis"] = Convert.ToDecimal(grv.Cells[9].Text) * 100 / Convert.ToDecimal(grv.Cells[12].Text);
                    txtdiscount.Text = ViewState["dis"].ToString();
                    ViewState["taxamount"] = grv.Cells[11].Text;
                    //int product_id = Convert.ToInt32(grv.Cells[2].Text);
                    //int qty = Convert.ToInt32(grv.Cells[2].Text);
                    txtquantity.Focus();
                    //context.sp_Updatestockquantity(product_id, qty, c_id);
                    
                    UpdateAdd.Update();
                }



            }

            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        public void giventotalcal(decimal gtot, decimal gamt)
        {
            if (gamt != 0)
            {
                decimal gttot = gamt - gtot;
                decimal tott = Convert.ToDecimal(txtGivenAmt.Text) - gttot;
               txtGivenAmt.Text = tott.ToString();
               txtBalanceAmt.Text = gttot.ToString();
               UpdatePanel2.Update();
            }
        }
        public void lblmsgwork()
        {
            if (ViewState["balanceamt"] != null)
            {
                if (Convert.ToDecimal(ViewState["balanceamt"]) > Convert.ToDecimal(lblGrandTotal.Text))
                {
                    lblmsg.Visible = true;
                    decimal amount = Convert.ToDecimal(ViewState["balanceamt"])- Convert.ToDecimal(txtGivenAmt.Text) ;
                    lblmsg.Text = "Receivable Amount from vendor is  " +amount.ToString();
                    txtBalanceAmt.Text = amount.ToString();
                  
                }

                else
                {
                    lblmsg.Visible = true;
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    decimal amount = (Convert.ToDecimal(lblGrandTotal.Text) - Convert.ToDecimal(ViewState["balanceamt"]))-Convert.ToDecimal(txtGivenAmt.Text);
                    lblmsg.Text = "Payable Amount to vendor is  " + amount.ToString();
                    txtBalanceAmt.Text = amount.ToString();
                }
            }
        }
        protected void txtGivenAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                lblmsgwork();
                UpdatePanel2.Update();
            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void ddlproduct_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                txtprice.Text = string.Empty;
                txtsalesprice.Text = string.Empty;
                int c_id = Convert.ToInt32(Session["company_id"]);
                int b_id = Convert.ToInt32(Session["branch_id"]);
                int p_id = Convert.ToInt32(ddlproduct.SelectedValue);
                tbl_product p = new tbl_product();
                p.company_id = c_id;
                p.branch_id = b_id;
                p.product_id = p_id;
                ////Shakeeb
                ////p.All(p);
                txtprice.Text = Convert.ToString(p.purchas_price);
                txtsalesprice.Text = Convert.ToString(p.sales_price);
                UpdateAdd.Update();
            }
            catch (Exception ex)
            {

                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["total"] != "" && ViewState["dis"] != "" && ViewState["tax"] != "")
                {

                    decimal t = Convert.ToDecimal(lblsubtotal.Text) - Convert.ToDecimal(ViewState["total"]);
                    decimal tx = Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(ViewState["tax"]);
                    decimal d = Convert.ToDecimal(lblDiscountAmt.Text) - Convert.ToDecimal(ViewState["dis"]);
                    lblsubtotal.Text = t.ToString();
                    lblTaxAmount.Text = tx.ToString();
                    lblDiscountAmt.Text = d.ToString();

                    if (Session["table"] != "")
                    {
                        DataTable dt = Session["table"] as DataTable;
                        if (ViewState["id"] == null)
                        {

                            int row = Convert.ToInt32(ViewState["index"]);
                            dt.Rows.RemoveAt(row);
                        }
                        else
                        {
                            int purchase_id = Convert.ToInt32(Request.QueryString["id"]);
                            if (purchase_id != 0)
                            {
                                int row = Convert.ToInt32(ViewState["id"]);
                                DataTable dttt = (DataTable)Session["deletdata"];
                                dttt.Rows.Add(purchase_id,row);
                                Session["deletdata"] = dttt;
                                int row1 = Convert.ToInt32(ViewState["index"]);
                                dt.Rows.RemoveAt(row1);
                               // context.sp_DeletePurchasedetailbyreutrn(purchase_id, row);

                                //int row1 = Convert.ToInt32(ViewState["index"]);
                                //dt.Rows[row1].Delete();
                                //context.sp_insert_purchase_return(purchase_id, row, Session["UserID"].ToString(), (DateTime.Today).ToString());
                            }
                        }


                        gvpurchasedetails.DataSource = dt;
                        gvpurchasedetails.DataBind();
                    }

                    decimal gtot = Convert.ToDecimal(lblsubtotal.Text) + (Convert.ToDecimal(lblTaxAmount.Text) - Convert.ToDecimal(lblDiscountAmt.Text));
                    lblGrandTotal.Text = gtot.ToString();
                    txtBalanceAmt.Text = lblGrandTotal.Text;
                }


            }
            catch (Exception ex)
            {
                ErrorLog.saveerror(ex);
                //Do Logging
            }
        }
    
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int flagcheck = 0;
            foreach (GridViewRow row in gvpurchasedetails.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        flagcheck = 1;
                    }
                }
            }

            if (flagcheck == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Please Checked the Product You want to return','False');", true);
                return ;
            }


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
                string user=Session["UserID"].ToString();
                int c_id = Convert.ToInt32(Session["company_id"]);
                int b_id = Convert.ToInt32(Session["branch_id"]);
                int count;
                int prmid;
                DataTable dt=(DataTable)Session["deletdata"];
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                  
                    int purchaseid = Convert.ToInt32(dt.Rows[i][0].ToString());
                    int row = Convert.ToInt32(dt.Rows[i][1].ToString());
                    context.sp_DeletePurchasedetailbyreutrn(purchaseid, row);
                    cmd.CommandText = "sp_insert_purchase_return";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Purchase_id", purchaseid);
                    cmd.Parameters.AddWithValue("@purchasedetails_id", row);
                    cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(dt.Rows[i][2].ToString()));
                    cmd.Parameters.AddWithValue("@batch_id", Convert.ToInt32(dt.Rows[i][3].ToString()));
                    cmd.Parameters.AddWithValue("@tax_amt", Convert.ToDecimal(dt.Rows[i][4].ToString()));
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToDecimal(dt.Rows[i][5].ToString()));
                    cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(dt.Rows[i][6].ToString()));
                    cmd.Parameters.AddWithValue("@created_by", user);
                    cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                    cmd.Connection = con;
                    cmd.CommandTimeout = 600000;
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                if (gvpurchasedetails.Rows.Count ==0)
                {
                    count = 0;
                }
                else
                {
                    count = 1;
                }

              int  Purchase_id=Convert.ToInt32(Request.QueryString["id"]);
               if(Purchase_id!=0)
               {
                  
                   decimal tax_amount=Convert.ToDecimal(lblTaxAmount.Text);
                   decimal sub_total=Convert.ToDecimal(lblsubtotal.Text);
                   decimal discount=Convert.ToDecimal(lblDiscountAmt.Text);
                   decimal grandtotal=Convert.ToDecimal(lblGrandTotal.Text);
                  // context.sp_UpdatePurhase(Purchase_id, count, c_id, Convert.ToInt32(ddlVendor.SelectedValue), txtPONo.Text, tax_amount, sub_total, grandtotal, discount, user, date);
                   cmd.CommandText = "sp_insertpurchasereturnmain";
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@Purchase_id", Purchase_id);
                   cmd.Parameters.AddWithValue("@branch_id", b_id);
                   cmd.Parameters.AddWithValue("@company_id", c_id);
                   cmd.Parameters.AddWithValue("@total_tax", Convert.ToDecimal(tax_amount));
                   cmd.Parameters.AddWithValue("@actual_amount", Convert.ToDecimal(sub_total));
                   cmd.Parameters.AddWithValue("@grand_total", Convert.ToDecimal(grandtotal));
                   cmd.Parameters.AddWithValue("@discount", Convert.ToDecimal(discount));
                   cmd.Parameters.AddWithValue("@created_by", user);
                   cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                   cmd.Parameters.Add("@purchasereturnmain_id", SqlDbType.Int);
                   cmd.Parameters["@purchasereturnmain_id"].Direction = ParameterDirection.Output;
                   cmd.ExecuteNonQuery();
                   Session["prmid"] = Convert.ToInt32(cmd.Parameters["@purchasereturnmain_id"].Value);
                   cmd.Parameters.Clear();
               }


               int mcid = Convert.ToInt32(Session["prmid"]);
           

                  foreach (GridViewRow row in gvpurchasedetails.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                             int salesedetail_id = Convert.ToInt32(row.Cells[13].Text);
                             if (salesedetail_id != 0)
                             {
                                 cmd.CommandText = "sp_insert_purchase_return";
                                 cmd.CommandType = CommandType.StoredProcedure;
                                 cmd.Parameters.AddWithValue("@Purchase_id", mcid);
                                 cmd.Parameters.AddWithValue("@purchasedetails_id", salesedetail_id);
                                 cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(row.Cells[3].Text));
                                 cmd.Parameters.AddWithValue("@batch_id",  Convert.ToInt32(row.Cells[5].Text));
                                 cmd.Parameters.AddWithValue("@tax_amt", Convert.ToDecimal(row.Cells[11].Text));
                                 cmd.Parameters.AddWithValue("@quantity", Convert.ToDecimal(row.Cells[6].Text));
                                 cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(ViewState["amount"]));
                                 cmd.Parameters.AddWithValue("@created_by", user);
                                 cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                                 cmd.Connection = con;
                                 cmd.CommandTimeout = 600000;
                                 cmd.ExecuteNonQuery();
                                 cmd.Parameters.Clear();

                                 //cmd.CommandText = "sp_UpdatePurchasedetails";
                                 //cmd.CommandType = CommandType.StoredProcedure;
                                 //cmd.Parameters.AddWithValue("@purchasedetails_id", salesedetail_id);
                                 //cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(row.Cells[3].Text));
                                 //cmd.Parameters.AddWithValue("@Purchase_id", mcid);
                                 //cmd.Parameters.AddWithValue("@batch_id", Convert.ToInt32(row.Cells[5].Text));
                                 //cmd.Parameters.AddWithValue("@tax_amt", Convert.ToDecimal(row.Cells[11].Text));
                                 //cmd.Parameters.AddWithValue("@dicount_amt", Convert.ToDecimal(row.Cells[9].Text));
                                 //cmd.Parameters.AddWithValue("@quantity", Convert.ToDecimal(row.Cells[6].Text));
                                 //cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(row.Cells[12].Text));
                                 //cmd.Parameters.AddWithValue("@purchase_rate", row.Cells[7].Text);
                                 //cmd.Parameters.AddWithValue("@sale_rate", row.Cells[8].Text);
                                 //cmd.Parameters.AddWithValue("@modified_by", user);
                                 //cmd.Parameters.AddWithValue("@modifie_date", DateTime.Now);
                                 //cmd.Connection = con;
                                 //cmd.CommandTimeout = 600000;
                                 //cmd.ExecuteNonQuery();
                                 //cmd.Parameters.Clear();
                                // lblmsg.Text = string.Empty;
                                 //context.sp_salereturn(sale_id, salesedetail_id, user, (DateTime.Today).ToString());
                             }
                             //else
                             //{
                             //    lblmsg.Text = "Please Select any product to return";
                             //}
                        }
                    }
                }

                ////GridViewRow row = gvpurchasedetails.Rows[rowIndex];
                //for (int i = 0; i <= gvpurchasedetails.Rows.Count - 1; i++)
                //{
                //    int purchasedetail_id=Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[12].Text);
                //    if (purchasedetail_id != 0)
                //    {
                //        context.sp_UpdatePurchasedetails( purchasedetail_id, Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[2].Text)
                //            , mcid , Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[4].Text) , Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[10].Text)
                //            , Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[8].Text), Convert.ToInt32(gvpurchasedetails.Rows[i].Cells[5].Text)
                //            , Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[11].Text), Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[6].Text)
                //            , Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[7].Text), user, date);
                //    }

                //    else
                //    {
                //        //Purchase Details Saving Code Start Here

                //        cmd.CommandText = "sp_PurchaseDetailinsert";
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@product_id", gvpurchasedetails.Rows[i].Cells[2].Text);
                //        cmd.Parameters.AddWithValue("@purchase_id", mcid);
                //        cmd.Parameters.AddWithValue("@batch_id", gvpurchasedetails.Rows[i].Cells[4].Text);
                //        cmd.Parameters.AddWithValue("@tax_amt", gvpurchasedetails.Rows[i].Cells[10].Text);
                //        cmd.Parameters.AddWithValue("@dicount_amt", gvpurchasedetails.Rows[i].Cells[8].Text);
                //        cmd.Parameters.AddWithValue("@quantity", gvpurchasedetails.Rows[i].Cells[5].Text);
                //        cmd.Parameters.AddWithValue("@amount", gvpurchasedetails.Rows[i].Cells[11].Text);
                //        cmd.Parameters.AddWithValue("@purchase_rate", gvpurchasedetails.Rows[i].Cells[6].Text);
                //        cmd.Parameters.AddWithValue("@sale_rate", gvpurchasedetails.Rows[i].Cells[7].Text);
                //        cmd.Parameters.AddWithValue("@user_id", Session["UserID"].ToString());
                //        cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                //        cmd.Connection = con;
                //        cmd.CommandTimeout = 600000;
                //        cmd.ExecuteNonQuery();
                //        cmd.Parameters.Clear();
                //        // Purchase Details Code End

                //        // Stock & Stock Transaction Data Saving Code Starts Here
                //        cmd.CommandText = "sp_InsertSaleTransaction";
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        // code are here

                //        cmd.Parameters.AddWithValue("@company_id", c_id);
                //        cmd.Parameters.AddWithValue("@branch_id", b_id);
                //        cmd.Parameters.AddWithValue("@product_id", gvpurchasedetails.Rows[i].Cells[2].Text);
                //        cmd.Parameters.AddWithValue("@bacth_id", gvpurchasedetails.Rows[i].Cells[4].Text);
                //        cmd.Parameters.AddWithValue("@in_out", "In");
                //        cmd.Parameters.AddWithValue("@qty", gvpurchasedetails.Rows[i].Cells[5].Text);
                //        cmd.Parameters.AddWithValue("@transactio_type_id", mcid);
                //        cmd.Parameters.AddWithValue("@stocktransaction_typ", "Purchase");
                //        cmd.Parameters.AddWithValue("@created_by", Session["UserID"].ToString());
                //        cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                //        cmd.Connection = con;
                //        cmd.CommandTimeout = 600000;
                //        // end

                //        cmd.ExecuteNonQuery();
                //        cmd.Parameters.Clear();
                //        // Stock & Stock Transaction Data Saving Code end
                //    }
                    
                 

                //}


                cmd.Parameters.Clear();
                
                cmd.CommandText = "sp_InsertMonyTransaction";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@company_id", c_id);
                cmd.Parameters.AddWithValue("@branch_id", b_id);
                cmd.Parameters.AddWithValue("@party_id", ddlVendor.SelectedValue);
                cmd.Parameters.AddWithValue("@given_amt", txtGivenAmt.Text);
                cmd.Parameters.AddWithValue("@grand_total", lblGrandTotal.Text);
                cmd.Parameters.AddWithValue("@balance_amt", txtBalanceAmt.Text);
                cmd.Parameters.AddWithValue("@in_out", "In");
                cmd.Parameters.AddWithValue("@paymentmode_id", ddlPaymentMode.SelectedValue);
                cmd.Parameters.AddWithValue("@transaction_typ", "Purchase Return");
                cmd.Parameters.AddWithValue("@transactio_type_id", mcid);
                cmd.Parameters.AddWithValue("@created_by", Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@created_date", DateTime.Today);
                cmd.Connection = con;
                cmd.CommandTimeout = 600000;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                con.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert('Saved Successfully','True');", true);

                //ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openalert();", true);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Purchases/PurchaseReturn.aspx", false);
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        a = Convert.ToInt32(txtOrderid.Text);
        //        ddlproduct.Enabled = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.saveerror(ex);
        //        //Do Logging
        //    }
        //}
    }
}