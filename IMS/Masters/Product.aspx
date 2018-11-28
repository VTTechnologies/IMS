<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="IMS.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Inventory Management System</title>
    <!-- Core CSS - Include with every page -->
    <link href="../assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <link href="../assets/css/main-style.css" rel="stylesheet" />
    <!-- Page-Level CSS -->
    <link href="../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <script src="../assets/scripts/main.js"></script>
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/responsive/1.0.7/css/responsive.bootstrap.min.css" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/responsive/1.0.7/js/dataTables.responsive.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.9/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>



    <script src="../assets/src/jquery-customselect.js"></script>
<link href="../assets/src/jquery-customselect.css" rel="stylesheet" />
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#GridView1').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <script type='text/javascript'>
        function openModal() {
            $('#<%=myModal.ClientID%>').modal('show');
        }
    </script>
    <script type="text/javascript">

        function CheckDouble() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("~/Masters/Product.aspx/CheckDouble") %>', // this for calling the web method function in cs code.  
                data: '{useroremail: "' + $("#<%=txtProductCode.ClientID%>")[0].value + '" }',// user name or email value  
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess(response) {
            var msg = $("#<%=lblcheckDoubleError.ClientID%>")[0];
            var hd3 = $("#<%=hde.ClientID%>")[0];
            switch (response.d) {
                case "true":
                    msg.style.display = "block";
                    msg.style.color = "red";
                    msg.innerHTML = "This Product Code name already Exists";
                    hd3.value = true;
                    break;
                case "false":
                    msg.style.display = "none";
                    hd3.value = false;
                    break;
            }
        }


        function OnlyNumericEntry(evt) {



            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;

        }

    </script>
    <script type="text/javascript">

        function CheckDouble1() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("~/Masters/Product.aspx/CheckDouble1") %>', // this for calling the web method function in cs code.  
                data: '{useroremail: "' + $("#<%=txtProductName.ClientID%>")[0].value + '" }',// user name or email value  
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess1,
                failure: function (response) {
                    alert(response);
                }
            });
        }
        function OnSuccess1(response) {
            var msg = $("#<%=Label1.ClientID%>")[0];
             var hd1 = $("#<%=hd.ClientID%>")[0];
             switch (response.d) {
                 case "true":
                     msg.style.display = "block";
                     msg.style.color = "red";
                     msg.innerHTML = "This Product name already Exists";
                     hd1.value = true;
                     break;
                 case "false":
                     msg.style.display = "none";
                     hd1.value = false;
                     break;
             }
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="panel panel-default ">
                <div class="panel-heading text-center">
                    <h1>Product Master</h1>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="form-group ">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Category:
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="adf" InitialValue="0" Display="Dynamic" runat="server" ErrorMessage="*" ControlToValidate="ddlCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>

                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Choose Category" />
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Unit:
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="adf" InitialValue="0" Display="Dynamic" ErrorMessage="*" ControlToValidate="ddlUnit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>

                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Choose Unit" />
                                        </asp:DropDownList>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="form-group ">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Godown:
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ValidationGroup="adf" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="ddlGodown" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlGodown" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGodown_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Text="Choose godown" />
                                        </asp:DropDownList>
                                    
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Rack:
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" ValidationGroup="adf" runat="server" Display="Dynamic" ErrorMessage="*" ControlToValidate="ddlRack" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlRack" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Choose Rack" />
                                        </asp:DropDownList>
                                         <asp:Label ID="lblrackerror" runat="server" ForeColor="Red" ></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="form-group ">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Tax:
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationGroup="adf" InitialValue="0" ErrorMessage="*" ControlToValidate="ddlTax" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:DropDownList ID="ddlTax" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Choose Tax" />
                                        </asp:DropDownList>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Product Name:
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationGroup="adf" ErrorMessage="*" ControlToValidate="txtProductName" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtProductName" runat="server" onchange="CheckDouble1()" CssClass="form-control"></asp:TextBox>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>


                                        <asp:HiddenField ID="hd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="form-group ">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Product Code:
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ValidationGroup="adf" ErrorMessage="*" ControlToValidate="txtProductName" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtProductCode" runat="server" onchange="CheckDouble()" CssClass="form-control"></asp:TextBox>
                                        <asp:Label ID="lblcheckDoubleError" runat="server"></asp:Label>

                                        <asp:HiddenField ID="hde" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            HSN Code:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic" ValidationGroup="adf" ErrorMessage="*" ControlToValidate="txtHSNCode" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtHSNCode" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="form-group ">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Re-Order Level: 
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic" ValidationGroup="adf" ErrorMessage="*" ControlToValidate="txtReorderqty" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                        <i class="fa fa-question-circle-o" data-toggle="tooltip" data-placement="bottom" title="Reorder level is the inventory level at which a company would place a new order."></i>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtReorderqty" runat="server" CssClass="form-control" onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[1-9][0-9]*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtReorderqty" ErrorMessage="Re-Order Quantity should b greater then 0"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Purchase Price:
                                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ValidationGroup="adf" ErrorMessage="*" ControlToValidate="txtPurchasePrice" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtPurchasePrice" runat="server" CssClass="form-control" onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,5})?\s*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtPurchasePrice" ErrorMessage="Purchase Price should b greater then 0"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="form-group ">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">
                                            Sales Price:
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic" ValidationGroup="adf" ErrorMessage="*" ControlToValidate="txtSalesPrice" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </label>

                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtSalesPrice" runat="server" CssClass="form-control" onkeypress="return OnlyNumericEntry(event);"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationExpression="^[1-9][0-9]*$" runat="server" ValidationGroup="adf" Display="Dynamic" ForeColor="Red" ControlToValidate="txtSalesPrice" ErrorMessage="Sales Price should b greater then 0"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer text-center">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Save" OnClick="btnSave_Click" ValidationGroup="adf" OnClientClick="DisableOnSave(this,'savesale');" UseSubmitBehavior="false" />
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" Visible="false" ValidationGroup="adf" />
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" Text="Clear" OnClick="Button1_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancel_Click" Style="float: right" />
                </div>
            </div>
            <div class="row">
                <div class="alert alert-success" id="divalert" runat="server" visible="false">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <asp:Label ID="lblAlert" runat="server"></asp:Label>

                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                    <div style="overflow-x: auto">
                        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" DataKeyNames="product_id" AutoGenerateColumns="false" CssClass="table table table-striped table-bordered table-hover" SelectedIndex="0">
                            <Columns>

                                <asp:BoundField DataField="category_name" HeaderText="Category" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="product_name" HeaderText="Product Name"></asp:BoundField>
                                <asp:BoundField DataField="unit_name" HeaderText="Unit" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="godown_name" HeaderText="Godown Name" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="rack_name" HeaderText="Rack" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="tax_name" HeaderText="Tax" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="sales_price" HeaderText="Sales Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="purchas_price" HeaderText="Purchase Price" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                                <asp:BoundField DataField="product_code" HeaderText="Product Code" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="reorder_level" HeaderText="Reorder Level" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="category_id" HeaderText="Reorder Level" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="godown_id" HeaderText="Reorder Level" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="rack_id" HeaderText="Reorder Level" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="tax_id" HeaderText="Reorder Level" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="unit_id" HeaderText="Reorder Level" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:BoundField DataField="hsn_code" HeaderText="HSN Code "></asp:BoundField>
                                <asp:TemplateField HeaderText="Update">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnimg_update" runat="server" ImageUrl="~/assets/img/edit.png" CommandName="Select" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnimg_delete" CommandArgument='<%# Eval("product_id") %>' runat="server" ImageUrl="~/assets/img/remove.png" CommandName="DeleteRow" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle BackColor="#428BCA" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </div>
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
                        <p>Do You want to delete This Unit? </p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="btn btn-primary" OnClick="btnYes_Click" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>

