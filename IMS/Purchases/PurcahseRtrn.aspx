﻿<%@ Page Title="" Language="C#" MasterPageFile="PurchaseManger.Master" AutoEventWireup="true" CodeBehind="PurcahseRtrn.aspx.cs" Inherits="IMS.PuchaseReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>



    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-1.11.3.min.js"></script>--%>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="../assets/alert/alertify.js"></script>
    <script src="../assets/alert/alertify.min.js"></script>
    <link href="../assets/alert/css/alertify.css" rel="stylesheet" />
    <link href="../assets/alert/css/alertify.min.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.min.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.rtl.css" rel="stylesheet" />

    <script type='text/javascript'>

        function openModal() {
            $('#<%=myModal.ClientID%>').modal('show');
        }
        function openalert(msg, val) {
            alertify.alert('Success', msg).setting({
                'onok': function () {
                    if (val == 'True') {
                        window.location.href = "PurchaseReport.aspx";
                    }

                }
            });

        }


        var txt = $("<%=txtquantity.ClientID%>");

        txt.focus();

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default ">
        <div class="panel-heading text-center">
            <h1>Purchase Return</h1>
        </div>
        <div class="panel-body">
            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
            <%--    <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="form-horizontal Fhorizontal">
                            <div class="col-sm-10 leftpadd0">
                                <label class="control-label">Purchase Order</label>
                               <asp:TextBox ID="txtOrderid" runat="server" CssClass="form-control" ></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="form-horizontal Fhorizontal">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click" Text="Search" />
                        </div>
                    </div>
                </div>--%>

                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="form-horizontal Fhorizontal">
                            <div class="col-sm-10 leftpadd0">
                                <label class="control-label">Select Vendor</label>
                                <asp:DropDownList ID="ddlVendor" runat="server" CssClass="form-control" Enabled="false" AppendDataBoundItems="true"></asp:DropDownList>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="col-sm-10 leftpadd0">
                            <label class="control-label">Purchase Order No.</label>
                            <asp:TextBox ID="txtPONo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                        </div>

                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="form-group">
                            <div class="col-sm-10 leftpadd0">
                                <label class="control-label">Date</label>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                </div>
                <div style="border: 1px solid black; margin-top: 10px; margin-bottom: 10px;"></div>
                <asp:UpdatePanel ID="UpdateAdd" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">Select Product</label>
                                    <asp:DropDownList ID="ddlproduct" runat="server" CssClass="form-control" Enabled="false" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged1" AutoPostBack="true"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">Select Batch</label>
                                    <asp:DropDownList ID="ddlBatch" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                      Return  Quantity
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" Text="*" ValidationGroup="grop " ControlToValidate="txtquantity"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtquantity" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtquantity" ErrorMessage="Quantity should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Price Per Unit
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" Text="*" ValidationGroup="grop " ControlToValidate="txtprice"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtprice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtprice" ErrorMessage="Price should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">Discount %</label>
                                    <asp:TextBox ID="txtdiscount" runat="server" CssClass="form-control" Text="0" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="^\s*(?=.*[0-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtdiscount" ErrorMessage="Discount should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Sales Price
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" Text="*" ValidationGroup="grop " ControlToValidate="txtsalesprice"></asp:RequiredFieldValidator>
                                    </label>
                                    <asp:TextBox ID="txtsalesprice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtsalesprice" ErrorMessage="Sales Price should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px; margin-top: 20px">
                                <div class="col-sm-10 leftpadd0">
                                    <%--<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" Text="Add" Width="100px" />--%>
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="grop " CssClass="btn btn-primary" Width="100px" Visible="false" />
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px; margin-top: 20px">
                                <%-- <div class="col-sm-10 leftpadd0">
                            <asp:CheckBox ID="chk" runat="server" Text="If IGST" Font-Bold="true" CssClass="checkbox" />
                        </div>--%>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-left: 0px; margin-top: 10px">
                                <asp:GridView ID="gvpurchasedetails" runat="server" CssClass="table" AutoGenerateColumns="false" BorderStyle="None" GridLines="Horizontal" OnRowCommand="gvpurchasedetails_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select" >
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SR.No" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="product_name" HeaderText="Product"></asp:BoundField>
                                        <asp:BoundField DataField="product_id" HeaderText="Product id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                        <asp:BoundField DataField="batch_name" HeaderText="Batch" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="batch_id" HeaderText="Batch id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                        <asp:BoundField DataField="quantity" HeaderText="Quantity"></asp:BoundField>
                                        <asp:BoundField DataField="purchase_rate" HeaderText="Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="sale_rate" HeaderText="Sale Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="dicount_amt" HeaderText="Discount Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="tax_percentage" HeaderText="tax percentage" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="tax_amt" HeaderText="Tax Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="amount" HeaderText="Total" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="purchasedetails_id" HeaderText="Product id" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Update">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Update Row" ID="btnimg_update" runat="server" ImageUrl="~/assets/img/edit.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Delete row" ID="btnimg_Remove" runat="server" ImageUrl="~/assets/img/remove.png" data-toggle="modal" href="#myModal" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#428BCA" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 pull-right">
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 leftpadd0 pull-right" style="padding: 0px;">
                                    <div class="form-group">
                                        <div class="col-sm-12 leftpadd0">
                                            <label class="control-label col-sm-9">Sub Total</label>
                                            <asp:Label ID="lblsubtotal" runat="server" CssClass="control-label" Text="0"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 leftpadd0 pull-right" style="padding: 0px;">
                                    <div class="form-group">
                                        <div class="col-sm-12 leftpadd0">
                                            <label class="control-label col-sm-9">Tax Amount</label>
                                            <asp:Label ID="lblTaxAmount" runat="server" CssClass="control-label" Text="0"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 leftpadd0 pull-right" style="padding: 0px;">
                                    <div class="form-group">
                                        <div class="col-sm-12 leftpadd0">
                                            <label class="control-label col-sm-9">Discount Amount</label>
                                            <asp:Label ID="lblDiscountAmt" runat="server" CssClass="control-label" Text="0"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=" col-md-4 pull-left">
                                <asp:GridView ID="gvTaxDetails" runat="server" CssClass="table " BorderStyle="None" GridLines="Horizontal">

                                    <HeaderStyle BackColor="#428BCA" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 pull-right">
                                <div style="border: 1px solid black; margin-top: 10px; margin-bottom: 10px;"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 pull-right">
                                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 leftpadd0 pull-right" style="padding: 0px;">
                                    <div class="form-group">
                                        <div class="col-sm-12 leftpadd0">
                                            <label class="control-label col-sm-9">Grand Total</label>
                                            <asp:Label ID="lblGrandTotal" runat="server" CssClass="control-label" Text="0"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="row">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <br />
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 pull-right">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 leftpadd0 pull-right" style="padding: 0px;">
                                        <div class="form-group">
                                            <div class="col-sm-12 leftpadd0">
                                                <label class="control-label col-sm-9">Payment Mode</label>
                                                <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 pull-right">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 leftpadd0 pull-right" style="padding: 0px;">
                                        <div class="form-group">
                                            <div class="col-sm-12 leftpadd0">
                                                <label class="control-label col-sm-9">
                                                    Given Amount
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtGivenAmt" ErrorMessage="*" ValidationGroup="savesale"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtGivenAmt" runat="server" CssClass="form-control" OnTextChanged="txtGivenAmt_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtGivenAmt" ErrorMessage="Given Amount Should be digits only" ValidationGroup="savesale" ValidationExpression="^[0-9]$" Display="Dynamic">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 pull-right">
                                    <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12 leftpadd0 pull-right" style="padding: 0px;">
                                        <div class="form-group">
                                            <div class="col-sm-12 leftpadd0">
                                                <label class="control-label col-sm-9">
                                                    Balance Amount
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBalanceAmt" ErrorMessage="*" ValidationGroup="savesale"></asp:RequiredFieldValidator>
                                                </label>
                                                <asp:TextBox ID="txtBalanceAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtBalanceAmt" ErrorMessage="Balance Amount Should be digits only" ValidationGroup="savesale" ValidationExpression="^[0-9]$" Display="Dynamic">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="text-center">
                                    <asp:Label ID="lblmsg" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%--<div style="border:1px solid black"></div>--%>
                </div>
            </div>
        </div>
        <div class="panel-footer leftpadd0">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary " Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog" runat="server">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Alert</h4>
                </div>
                <div class="modal-body">
                    <p>Are You Sure You want to delete it? </p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btn btn-primary" OnClick="btnOk_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <%--<asp:BoundField DataField="Discount" HeaderText="Discount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField> --%>
</asp:Content>