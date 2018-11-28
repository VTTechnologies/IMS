<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentMode.aspx.cs" Inherits="IMS.PaymentMode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">--%>
    <title>Inventory Management System</title>
    <!-- Core CSS - Include with every page -->
    <%--<link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />--%>
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <%--<link href="assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />--%>
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
     <script src="http://code.jquery.com/jquery-1.7.1.min.js"></script>
     <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
    <script type="text/javascript">
        //$(function () {
        //    $('[id*=grvlist]').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
        //        "responsive": true,
        //        "sPaginationType": "full_numbers"
        //    });
        //});
        $(function () {
            $('#grvlist').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
   
    <script type="text/javascript">

        $(function () {
            $('#GridView1').prepend($("<thead></thead>").append($(this).find("tr:first"))).DataTable({
                "responsive": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>

    <script type="text/javascript">

        function CheckDouble() {
            $.ajax({
                type: "POST",
                url: '<%= ResolveUrl("~/Masters/PaymentMode.aspx/CheckDouble") %>', // this for calling the web method function in cs code.  
                data: '{useroremail: "' + $("#<%=txtName.ClientID%>")[0].value + '" }',// user name or email value  
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
              switch (response.d) {
                  case "true":
                      msg.style.display = "block";
                      msg.style.color = "red";
                      msg.innerHTML = "This paymentmode name already exists, please give another name";
                      break;
                  case "false":
                      msg.style.display = "none";
                      break;
              }
          }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="panel panel-default text-center">
                <div class="panel-heading">
                    <h1>Payment Mode Master</h1>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="col-md-12">
                            <div class="col-md-5">
                                <div class="form-group ">
                                    <div class="col-sm-5 leftpadd0">
                                        <label class="control-label   ">Payment Mode Name: </label>
                                    </div>
                                    <div class="col-sm-7">
                                        <asp:TextBox ID="txtName" runat="server" onchange="CheckDouble()" CssClass="form-control" ></asp:TextBox>
                                        <asp:Label ID="lblcheckDoubleError" runat="server"></asp:Label>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name  is required" ControlToValidate="txtName" ValidationGroup="grp" ForeColor="Red"></asp:RequiredFieldValidator>

                                         </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Save" OnClick="btnSave_Click" ValidationGroup="grp" OnClientClick="DisableOnSave(this,'grp');" UseSubmitBehavior="false"/>
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdate_Click" Visible="false" />  
                   <input class="btn btn-primary " type="button"  value="Clear" onclick="cleartextboxes();" />
                     <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancel_Click" style="float:right" />
                </div>
            </div>
            <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
                <div>

                    <asp:GridView ID="grvlist" runat="server" OnRowCommand="grvlist_RowCommand" DataKeyNames="paymentode_id" SelectedIndex="0" OnSelectedIndexChanged="grvlist_SelectedIndexChanged" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover">
                        <Columns>
                            <asp:BoundField DataField="paymentmode_name" HeaderText="Name"></asp:BoundField>
                            <asp:TemplateField HeaderText="Update">
                                <ItemTemplate>
                                    <asp:ImageButton CommandName="Select" ID="btnimg_update" runat="server" ImageUrl="~/assets/img/edit.png" />
                                   </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete"  ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                                <ItemTemplate>
                                    <asp:ImageButton  CommandName="DeleteRow"  CommandArgument='<%# Eval("paymentode_id") %>' ID="btnimg_delete" runat="server" ImageUrl="~/assets/img/remove.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#428BCA" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

