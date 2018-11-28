<%@ Page Title="" Language="C#" MasterPageFile="PurchaseManger.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="IMS.Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>



    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-1.11.3.min.js"></script>--%>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
     <script src="../assets/scripts/bootstrap-datetimepicker.min.js"></script>
    <script src="../assets/alert/alertify.js"></script>
    <script src="../assets/alert/alertify.min.js"></script>
    <link href="../assets/alert/css/alertify.css" rel="stylesheet" />
    <link href="../assets/alert/css/alertify.min.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.min.css" rel="stylesheet" />
    <link href="../assets/alert/css/themes/default.rtl.css" rel="stylesheet" />

    
    <script src="../assets/src/jquery-customselect.js"></script>
    <link href="../assets/src/jquery-customselect.css" rel="stylesheet" />
    <script type='text/javascript'>

        function openModal() {
            $('#<%=myModal.ClientID%>').modal('show');
        }
        
       

        function openalert(msg) {
            alertify.alert('Success', msg).setting({
                'onok': function () { window.location.href = "Purchase.aspx"; }
            });

        }

       

        function OnlyNumericEntry(evt) {



            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;

        }
    </script>


    <script type='text/javascript'>
     
        //$(function () {
           
        //        $('[id*=txtdate]').datepicker({
        //            changeMonth: true,
        //            changeYear: true,
        //            format: "dd/mm/yyyy",
        //            language: "tr"
        //        });
           
        //});

        function validdiscount() {
            if ($('#<%=txtDiscount.ClientID%>').val() > 100) {
                    $('#<%=txtDiscount.ClientID%>').val('100');
                }
        }
    
    </script>
    <script>
        $(function() {
            $("#ddlVendor").customselect({
                "csclass":"custom-select",  // Class to match
                "search": true, // Is searchable?
                "numitems":     4,    // Number of results per page
                "searchblank":  false,// Search blank value options?
                "showblank":    true, // Show blank value options?
                "searchvalue":  false,// Search option values?
                "hoveropen":    false,// Open the select on hover?
                "emptytext":    "",   // Change empty option text to a set value
                "showdisabled": false,// Show disabled options
                "mobilecheck":  function() {// Mobile check function / boolean
                    //return navigator.platform && navigator.userAgent.match(/(android|<a href="https://www.jqueryscript.net/tags.php?/iphone/">iphone</a>|ipad|blackberry)/i);
                    }});
        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default ">
        <div class="panel-heading text-center">
            <h1>Purchase</h1>
        </div>
        <div class="panel-body">
            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                <div class="row">
                    <div class="text-center">
                          <asp:Label ID="lblInvoice" runat="server"  ForeColor="Red"></asp:Label>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="form-horizontal Fhorizontal">
                            <div class="col-sm-10 leftpadd0">
                                <label class="control-label">
                                    Select Vendor <span style="color:red">*</span>                                      
                                </label>
                                <asp:DropDownList ID="ddlVendor" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Choose Vendor" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" Text="Please Select Vendor" ValidationGroup="grop" ControlToValidate="ddlVendor" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="col-sm-10 leftpadd0">
                            <label class="control-label">
                                Vendor Receipt No. <span style="color:red">*</span> 
                            </label>
                            <asp:TextBox ID="txtPONo" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" Text="Please Enter Receipt No" ValidationGroup="grop" ControlToValidate="txtPONo"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                        <div class="form-group">
                            <div class="col-sm-10 leftpadd0">
                                <label class="control-label">
                                    Date <span style="color:red">*</span>                                            
                                </label>
                                <asp:HiddenField ID="hd1" runat="server" />
                                <asp:HiddenField ID="hd2" runat="server" />
                                <asp:TextBox ID="txtdate" runat ="server" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdate" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Date is Required " ForeColor="Red" Text="Please Select Date" ValidationGroup="grop" ControlToValidate="txtdate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>



                </div>
                <div style="border: 1px solid black; margin-top: 10px; margin-bottom: 10px;"></div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">Select Product <span style="color:red">*</span></label>
                                    <asp:DropDownList ID="ddlproduct"  runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Choose Product" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Select Product" ForeColor="Red" Text="Please Select Product" ValidationGroup="grop" ControlToValidate="ddlproduct" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Select Batch <span style="color:red">*</span>
                              <asp:Label ID="lblbatch" runat="server" Text="*" Visible="false" ForeColor="Red"></asp:Label>
                                       
                                    </label>
                                    <asp:DropDownList ID="ddlBatch" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Choose Batch" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Select Product" ForeColor="Red" Text="Please Select Product" ValidationGroup="grop" ControlToValidate="ddlBatch" InitialValue="0"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Quantity <span style="color:red">*</span>                                
                                    </label>
                                    <asp:TextBox ID="txtquantity" runat="server" CssClass="form-control"  onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date is Required " ForeColor="Red" Text="Please Enter Quantity" ValidationGroup="grop" ControlToValidate="txtquantity"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtquantity" ErrorMessage="Quantity should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Price Per Unit <span style="color:red">*</span>                                
                                    </label>
                                    <asp:TextBox ID="txtprice" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Price" ForeColor="Red" Text="" ValidationGroup="grop" ControlToValidate="txtprice"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtprice" ErrorMessage="Price should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Discount %                           
                                    </label>
                                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control" onchange="validdiscount();"  ></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="^\s*(?=.*[0-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtDiscount" ErrorMessage="Discount should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Tax %
                                    </label>
                                    <asp:TextBox ID="txtTaxpercentage" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ValidationExpression="^\s*(?=.*[0-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtTaxpercentage" ErrorMessage="Discount could not be negative"></asp:RegularExpressionValidator>

                                </div>
                            </div>
                            <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px;">
                                <div class="col-sm-10 leftpadd0">
                                    <label class="control-label">
                                        Sales Price <span style="color:red">*</span>                                
                                    </label>
                                    <asp:TextBox ID="txtsalesprice" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="Please Enter Sales Price" Text="" ValidationGroup="grop" ControlToValidate="txtsalesprice"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtsalesprice" ErrorMessage="Sales Price should b greater then 0"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px; margin-top: 20px">
                                <%-- <div class="col-sm-10 leftpadd0">
                            <asp:CheckBox ID="chk" runat="server" Text="If IGST" Font-Bold="true" CssClass="checkbox" />
                        </div>--%>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <asp:Label ID="lblcheckDoubleError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                    <div class="col-md-4 col-lg-2 col-sm-12 col-xs-12 leftpadd0" style="padding: 0px; margin-top: 20px">
                        <div class="col-sm-10 leftpadd0">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" ValidationGroup="grop"  CssClass="btn btn-primary" Text="Add" Width="100px" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" ValidationGroup="grop" CssClass="btn btn-primary" Width="100px" Visible="false" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-left: 0px; margin-top: 10px">
                        <asp:GridView ID="gvpurchasedetails" runat="server" CssClass="table" AutoGenerateColumns="false" BorderStyle="None" GridLines="Horizontal" OnRowCommand="gvpurchasedetails_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Product" HeaderText="Product"></asp:BoundField>
                                <asp:BoundField DataField="Product_id" HeaderText="Product id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="Batch" HeaderText="Batch" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="Batch_id" HeaderText="Batch id" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
                                <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="Discount" HeaderText="Discount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="Discount Amount" HeaderText="Discount Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="Tax" HeaderText="Tax" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="Tax Amount" HeaderText="Tax Amount" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="Sub Total" HeaderText="Total" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
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
                                                Given Amount <span style="color:red">*</span>                                          
                                            </label>
                                            <asp:TextBox ID="txtGivenAmt" runat="server" CssClass="form-control" OnTextChanged="txtGivenAmt_TextChanged" AutoPostBack="true" Enabled="false"  onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ControlToValidate="txtGivenAmt" ErrorMessage="Please Enter Given Amount"  ValidationGroup="savesale" ></asp:RequiredFieldValidator>
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
                                            </label>
                                            <asp:TextBox ID="txtBalanceAmt" runat="server" CssClass="form-control" Enabled="false" onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtBalanceAmt" ErrorMessage="Please Enter Balance Amount" ValidationGroup="savesale" ForeColor="Red"></asp:RequiredFieldValidator>
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
            <%--<div style="border:1px solid black"></div>--%>
        </div>
        <div class="panel-footer ">
            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Save" OnClick="btnSave_Click"  ValidationGroup="savesale" OnClientClick="this.disabled='true'; this.value='Processing...';" UseSubmitBehavior="false"/>
            <%-- <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary " Text="Cancel" OnClick="btnCancel_Click" />--%>
            <asp:Button ID="btnclear" runat="server" CssClass="btn btn-primary " Text="Cancel" OnClick="btnclear_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <asp:Button runat="server" ID="btnPrint" CssClass="btn btn-primary" Text="Save & Print" OnClick="btnPrint_Click" />
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
                        <asp:Button ID="Button1" runat="server" Text="Ok" CssClass="btn btn-primary" OnClick="Button1_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <%-- <a href="PurchaseHome.aspx">PurchaseHome.aspx</a>--%>
    </div>
</asp:Content>
