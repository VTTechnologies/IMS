﻿using IMSBLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IMS
{
    public partial class Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// All The Events That are used in coding
        /// </summary>

        #region Events

        protected void btncategory_Click(object sender, EventArgs e)
        {


            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "../Masters/Category.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }

             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnumit_Click(object sender, EventArgs e)
        {

            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "../Masters/Unit.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }

             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btngodown_Click(object sender, EventArgs e)
        {
            try
            {

                ifm.Visible = true;
                ifm.Attributes.Add("src", "~/Masters/Godown.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnrack_Click(object sender, EventArgs e)
        {

            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "~/Masters/Rack.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btntax_Click(object sender, EventArgs e)
        {

            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "~/Masters/Tax.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnfinancialyear_Click(object sender, EventArgs e)
        {
            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "~/Masters/FinincialYear.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnbatch_Click(object sender, EventArgs e)
        {

            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "~/Masters/Batch.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnpaymentmode_Click(object sender, EventArgs e)
        {

            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "~/Masters/PaymentMode.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnparties_Click(object sender, EventArgs e)
        {
            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "../Masters/Party.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "../Masters/Product.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }

        }

        protected void btnexpenses_Click(object sender, EventArgs e)
        {


            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "~/Masters/Expense.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnBranch_Click(object sender, EventArgs e)
        {
            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "../Branch.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {


            try
            {
                ifm.Visible = true;
                ifm.Attributes.Add("src", "../Masters/User.aspx");
                main.Visible = false;
                bMaster.Visible = true;
            }
             catch(Exception ex)
            {
                ErrorLog.saveerror(ex);
            }
        }

        #endregion









    }
}