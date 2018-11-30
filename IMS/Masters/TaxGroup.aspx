<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TaxGroup.aspx.cs" Inherits="IMS.Masters.TaxGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lbTax]').multiselect({ includeSelectAllOption: true });
        });
    </script>





    <div class="container-fluid">

        <div>
            <a href="../Master.aspx" id="bMaster" runat="server">
                <img src="../assets/img/goback-5-w800.png" height="50" width="130" /></a>
        </div>
        <div class="panel panel-default text-center">
            <div class="panel-heading">
                <h1>Batch Master</h1>
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="col-md-12">
                        <div class="col-md-5">
                            <div class="form-group ">
                                <div class="col-sm-5 leftpadd0">
                                    <label class="control-label   ">
                                        Group Name:<asp:Label ID="lblStar" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:TextBox ID="txtBatchName" runat="server" onchange="CheckDouble()" CssClass="form-control"></asp:TextBox>                                    
                                    <asp:Label ID="lblcheckDoubleError" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="rvaldt1" runat="server" ErrorMessage="Batch name is required" ValidationGroup="v1" ControlToValidate="txtBatchName" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hd" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group ">
                                <div class="col-sm-5 leftpadd0">
                                    <label class="control-label   ">
                                         Taxes<asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                    </label>
                                </div>
                                <div class="col-sm-7">
                                    <asp:ListBox ID="lbTax" runat="server" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>                                    
                                    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Batch name is required" ValidationGroup="v1" ControlToValidate="txtBatchName" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer">
                <%--<asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Save" ValidationGroup="v1" OnClick="btnSave_Click" OnClientClick="this.disabled='true'; this.value='Processing...';" UseSubmitBehavior="false" />--%>
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary " Text="Save" ValidationGroup="v1"  />
                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="v1"  Visible="false" />
                <input class="btn btn-primary " type="button" value="Clear" onclick="cleartextboxes();" />
                <%--<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="btnCancel_Click" Style="float: right" />   
                    OnClick="btnUpdate_Click"
                    OnClick="btnSave_Click"
                    --%>
            </div>
        </div>
        <div class="row">
            <div class="alert alert-success" id="divalert" runat="server" visible="false">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <asp:Label ID="lblAlert" runat="server"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
