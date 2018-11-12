<%@ Page Title="" Language="C#" MasterPageFile="~/PurchaseFolder/PurchaseManger.Master" AutoEventWireup="true" CodeBehind="PurchaseReturn.aspx.cs" Inherits="IMS.PurchaseFolder.PurchaseReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <%--    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>--%>
    <script src="../assets/alert/alertify.js"></script>
    <script src="../assets/alert/alertify.min.js"></script>
    <link href="../assets/alert/css/alertify.css" rel="stylesheet" />
    <link href="../assets/alert/css/alertify.min.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.min.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.rtl.css" rel="stylesheet" />
    <script>
        function openModal() {
            $('#<%=myModal.ClientID%>').modal('show');
        }
    </script>
    <script type='text/javascript'>
        $(function () {

            $("#<%=txtquantity.ClientID %>").keypress(function () {

                $("#<%=lblcheckDoubleError.ClientID%>").text('');
            });
           
        });
         function openalert(msg, val) {
             alertify.alert('Success', msg).setting({
                 'onok': function () {
                     if (val == 'True') {
                         window.location.href = "PurchaseReturn.aspx";
                     }
                 }
             });
         }

         function OnlyNumericEntry(evt) {
             $("#<%=lblcheckDoubleError.ClientID%>").text('');
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;

        }

        function ValidateQuantity() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("~/PurchaseFolder/PurchaseReturn.aspx/ValidateQuantity") %>', // this for calling the web method function in cs code.  
                data: '{enterdQuantity: "' + $("#<%=txtquantity.ClientID%>")[0].value + '",productid: "' + $("#<%=ddlproduct.ClientID%>")[0].value + '",purchaseId:"' + $("#<%=hdnPurchaseId.ClientID%>")[0].value + '" }',// user name or email value  
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess(response) {
            debugger;
            var msg = $("#<%=lblcheckDoubleError.ClientID%>")[0];
           <%-- var hd1 = $("#<%=hd.ClientID%>")[0];--%>
            debugger;
            switch (response.d[0]) {
                case "true":
                    msg.style.display = "block";
                    msg.innerHTML = response.d[1];
                    break;

                case "false":
                    msg.style.display = "none";
                    break;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default ">
        <div class="panel-heading text-center">
            <h1>Purchase Return</h1>
        </div>
        <div class="panel-body">
            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                <div class="row">
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="form-horizontal Fhorizontal">
                            <div class="col-sm-10 leftpadd0">
                                <asp:HiddenField ID="hdnPurchaseId" runat="server" />
                                <label class="control-label">
                                    Enter Invoice No.
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPoNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="searchvalidation"></asp:RequiredFieldValidator>
                                </label>
                                <asp:TextBox ID="txtPoNo" runat="server" CssClass="form-control" ValidationGroup="searchvalidation"></asp:TextBox>
                            </div>

                        </div>

                    </div>
                    <div class="col-md-2 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px; margin-top: 20px">
                        <div class="col-sm-10 leftpadd0">
                            <%--<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" Text="Add" Width="100px" />--%>
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" Width="100px" OnClick="btnSearch_Click" ValidationGroup="searchvalidation" />
                        </div>
                    </div>
                </div>
                <div id="OriginalPurchaseDetails" runat="server" visible="false">
                    <div class="row">
                        <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                            <div class="form-horizontal Fhorizontal">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Original Purchase Details
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-left: 0px; margin-top: 10px">
                            <asp:GridView ID="GrdOriginalPurchase" runat="server" CssClass="table" AutoGenerateColumns="false" BorderStyle="None" GridLines="Horizontal">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="product_name" HeaderText="Product"></asp:BoundField>
                                    <asp:BoundField DataField="batch_name" HeaderText="Batch" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                    <asp:BoundField DataField="quantity" HeaderText="Quantity"></asp:BoundField>
                                    <asp:BoundField DataField="purchase_rate" HeaderText="Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                    <asp:BoundField DataField="sale_rate" HeaderText="Sale Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                    <asp:BoundField DataField="discount_percent" HeaderText="Discount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                    <asp:BoundField DataField="dicount_amt" HeaderText="Discount Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                    <asp:BoundField DataField="tax_percentage" HeaderText="Tax" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                    <asp:BoundField DataField="tax_amt" HeaderText="Tax Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                    <asp:BoundField DataField="amount" HeaderText="Total" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                </Columns>
                                <HeaderStyle BackColor="#428BCA" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div style="border: 1px solid black; margin-top: 10px; margin-bottom: 10px;"></div>
                    <div class="row">
                        <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 leftpadd0" style="padding: 0px;">
                            <label class="control-label">Total Amnt:</label>
                            <asp:Label ID="lblTotalAmnt" runat="server" Text=""></asp:Label>
                        </div>
                       <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 leftpadd0" style="padding: 0px;">
                            <label class="control-label">Total Tax:</label>
                            <asp:Label ID="lblTotalTax" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 leftpadd0" style="padding: 0px;">
                            <label class="control-label">Total Discount:</label>
                            <asp:Label ID="lblTotalDiscount" runat="server" Text=""></asp:Label>
                        </div>
                       <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 leftpadd0" style="padding: 0px;">
                            <label class="control-label">Grand Total:</label>
                            <asp:Label ID="lblGrndTotal" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 leftpadd0" style="padding: 0px;">
                            <label class="control-label">Given Amnt:</label>
                            <asp:Label ID="lblGivenAmnt" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-md-2 col-lg-2 col-sm-2 col-xs-2 leftpadd0" style="padding: 0px;">
                            <label class="control-label">Balance Amnt:</label>
                            <asp:Label ID="lblBalanceAmnt" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div style="border: 1px solid black; margin-top: 10px; margin-bottom: 10px;"></div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="form-horizontal Fhorizontal">
                                    <div class="col-sm-10 leftpadd0">
                                        <label class="control-label">
                                            Select Product
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlproduct" ErrorMessage="*" ForeColor="Red" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>
                                        </label>
                                        <asp:DropDownList ID="ddlproduct" runat="server" CssClass="form-control" ValidationGroup="addvalidation" AppendDataBoundItems="true" AutoPostBack="true"></asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Return Quantity
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtquantity" ErrorMessage="*" ForeColor="Red" ValidationGroup="addvalidation"></asp:RequiredFieldValidator>
                                    </label>
                                    <%--<asp:TextBox ID="txtquantity" onkeypress="return OnlyNumericEntry(event);" ValidationGroup="addvalidation" runat="server" onchange="CheckQuantity()" CssClass="form-control"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtquantity" onkeypress="return OnlyNumericEntry(event);" ValidationGroup="addvalidation" runat="server" onchange="ValidateQuantity()" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblcheckDoubleError" runat="server" ForeColor="Red"></asp:Label>
                                    <%--<asp:HiddenField ID="hd" runat="server" />--%>
                                </div>

                            </div>
                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px; margin-top: 20px">
                                <div class="col-sm-10 leftpadd0">
                                    <%--<asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAdd_Click" Text="Add" Width="100px" />--%>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-primary" Width="100px" ValidationGroup="addvalidation" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary" Width="100px" Visible="false" ValidationGroup="addvalidation" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-left: 0px; margin-top: 10px">
                                <asp:GridView ID="gvpurchasedetails" runat="server" CssClass="table" AutoGenerateColumns="false" BorderStyle="None" GridLines="Horizontal" OnRowCommand="gvpurchasedetails_RowCommand">
                                    <Columns>
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
                                        <asp:BoundField DataField="dicount_amt" HeaderText="Discount Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="tax_percentage" HeaderText="tax percentage" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="tax_amt" HeaderText="Tax Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="amount" HeaderText="Total" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                        <asp:BoundField DataField="purchasedetails_id" HeaderText="Purchase Detail Id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>


                                        <asp:TemplateField HeaderText="Update">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Update Row" ID="btnimg_update" runat="server" ImageUrl="~/assets/img/edit.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                                            <ItemTemplate>
                                                <asp:ImageButton CommandName="Delete row" CommandArgument='<%#Eval("purchasedetails_id")%>' ID="btnimg_Remove" runat="server" ImageUrl="~/assets/img/remove.png" data-toggle="modal" href="#myModal" />
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
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtGivenAmt" ErrorMessage="*" ValidationGroup="savesale" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </label>
                                            <asp:TextBox ID="txtGivenAmt" runat="server" OnTextChanged="txtGivenAmt_TextChanged" CssClass="form-control" AutoPostBack="true" Enabled="false" onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtGivenAmt" ErrorMessage="Given Amount Should be digits only" ValidationGroup="savesale" ValidationExpression="^\s*(?=.*[0-9])\d*(?:\.\d{1,5})?\s*$" Display="Dynamic">
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
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBalanceAmt" ErrorMessage="*" ValidationGroup="savesale" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </label>
                                            <asp:TextBox ID="txtBalanceAmt" runat="server" CssClass="form-control" Enabled="false" onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtBalanceAmt" ErrorMessage="Balance Amount Should be digits only" ValidationGroup="savesale" ValidationExpression="^\s*(?=.*[0-9])\d*(?:\.\d{1,5})?\s*$" Display="Dynamic">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="panel-footer leftpadd0">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Save" OnClick="btnSave_Click" ValidationGroup="savesale" OnClientClick="this.disabled='true'; this.value='Processing...';" UseSubmitBehavior="false"/>
            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary " OnClick="btnCancel_Click" Text="Cancel" />

            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
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
    </div>
</asp:Content>
