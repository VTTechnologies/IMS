﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CategoryMasterModal.aspx.cs" Inherits="IMS.Masters.CategoryMasterModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                url: '<%= ResolveUrl("~/Masters/Category.aspx/CheckDouble") %>', // this for calling the web method function in cs code.  
                data: '{categoryName: "' + $("#<%=txtCategoryName.ClientID%>")[0].value + '" }',// user name or email value  
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
            var hd1 = $("#<%=hd.ClientID%>")[0];
            switch (response.d) {
                case true:

                    msg.style.display = "block";
                    msg.style.color = "red";
                    msg.innerHTML = "This category name already Exists";
                    hd1.value = "true";
                    break;
                case false:
                    msg.style.display = "none";
                    hd1.value = "false";
                    break;
            }
        }
        function clearcategory() {
            cleartextboxes();
            $("#<%=txtCategoryName.ClientID%>").focus();
        }
    </script>
    <script type="text/javascript">
        // Reference the textbox and call its focus function
        var txt = $("<%=txtCategoryName.ClientID%>");

        txt.focus();
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div>
            <a href="../Master.aspx" id="bMaster" runat="server">
                <img src="../assets/img/goback-5-w800.png" height="50" width="130" /></a>
        </div>
        <div class="panel panel-default text-center">
            <div class="panel-heading">
                <h1>Category Master</h1>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <div class="form-group ">
                                <div class="col-sm-5 leftpadd0">
                                    <label class="control-label   ">
                                        Category Name:<asp:Label ID="lblStar" runat="server" Text="*" ForeColor="Red"></asp:Label>                                             
                                    </label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtCategoryName" onchange="CheckDouble()" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvaldt1" runat="server" Display="Dynamic" ErrorMessage="Category name is required" ValidationGroup="abc" ControlToValidate="txtCategoryName" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <asp:Label ID="lblcheckDoubleError" runat="server"></asp:Label>
                            <asp:HiddenField ID="hd" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">

                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " ValidationGroup="abc" Text="Save" OnClick="btnSave_Click"/>
                <%--<asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" ValidationGroup="abc" Text="Update" OnClick="btnUpdate_Click" Visible="false" />--%>
                <input class="btn btn-primary " type="button" value="Clear" onclick="clearcategory()" />
            </div>
        </div>
        <div class="row">
            <div class="alert alert-success" id="divalert" runat="server" visible="false">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <asp:Label ID="lblAlert" runat="server"></asp:Label>
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
                    <p>Are You Sure You want to delete This Category? </p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="btn btn-primary" OnClick="btnYes_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>