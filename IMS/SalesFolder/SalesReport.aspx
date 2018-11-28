﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SalesFolder/SalesManger.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="IMS.SalesFolder.SalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {

            var hv = $("#" + '<%= hd1.ClientID %>').val();
            var hvq = $("#" + '<%= hd2.ClientID %>').val();


            $("#<%= txtStartDate.ClientID %>").datepicker(
                {
                    dateFormat: 'yy-mm-dd',
                    minDate: new Date(hv),
                    maxDate: new Date(hvq)
                }
                );
        });

        $(function () {

            var hv = $("#" + '<%= hd3.ClientID %>').val();
            var hvq = $("#" + '<%= hd4.ClientID %>').val();


            $("#<%= txtenddate.ClientID %>").datepicker(
                {
                    dateFormat: 'yy-mm-dd',
                    minDate: new Date(hv),
                    maxDate: new Date(hvq)
                }
                );
        });
    </script>

    <style>
        tr.GridPager td {
            height: 26px;
            margin: 0;
            padding: 0;
            border: 0;
        }

        .GridPager a, .GridPager span {
            display: block;
            width: 20px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            margin: 0;
            padding: 0;
            font-size: 80%;
        }

        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #dddddd;
            height: 20px;
            font-size: 80%;
        }

        .GridPager span {
            background-color: #ccdef4;
            color: #000;
            border: 1px solid #969696;
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default ">
        <div class="panel-heading text-center">
            <h2>Sale Report</h2>
        </div>
        <div class="panel-body">

            <div>

                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-3 ">
                                <div>
                                    <div class="col-sm-10 ">
                                        <label class="control-label">
                                            Customer
                                    
                                        </label>
                                        <asp:DropDownList ID="ddlVendor" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Choose Vendor" />
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-3 ">
                                <div>
                                    <div class="col-sm-10  ">
                                        <label class="control-label">
                                            Invoice No
                                    
                                        </label>
                                        <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 ">
                                <div class=" Fhorizontal ">
                                    <div class="col-sm-10 ">
                                        <label class="control-label">
                                            From  Date
                                    
                                        </label>
                                        <asp:HiddenField ID="hd1" runat="server" />
                                        <asp:HiddenField ID="hd2" runat="server" />
                                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 ">
                                <div>
                                    <div class="col-sm-10  ">
                                        <label class="control-label">
                                            To Date
                                    
                                        </label>
                                        <asp:HiddenField ID="hd3" runat="server" />
                                        <asp:HiddenField ID="hd4" runat="server" />
                                        <asp:TextBox ID="txtenddate" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Label ID="lblerror" runat="server"></asp:Label>
            </div>

        </div>
        <div class="panel-footer text-center">
            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" OnClick="btnSearch_Click" Text="Search" />
             <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" OnClick="btnClear_Click" Text="Clear" />
        </div>
    </div>
     <div class="row">
                 <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12" style="padding-bottom: 8px">
                     <asp:Button ID="btnExporttoexcel" runat="server" CssClass="btn btn-primary " Text="Export To Excel" OnClick="btnExporttoexcel_Click" />
                     </div>
            </div>
    <div class="row">
        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12">
            <div style="overflow-x: auto">
                <asp:GridView ID="GridView1" runat="server" EmptyDataText="No Recorde Found" OnRowCommand="GridView1_RowCommand" EmptyDataRowStyle-ForeColor="Red" AutoGenerateColumns="false" CssClass="table table-bordered" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="SR.No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="sale_id" HeaderText="Sale ID" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden">
                            <HeaderStyle CssClass="hidden"></HeaderStyle>

                            <ItemStyle CssClass="hidden"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number"></asp:BoundField>
                       <asp:BoundField DataField="customerName" HeaderText="Customer"></asp:BoundField>
                        <asp:BoundField DataField="date" HeaderText="Date"></asp:BoundField>
                        <asp:BoundField DataField="PaidAmnt" HeaderText="Paid Amnt"></asp:BoundField>
                        <asp:BoundField DataField="given_amnt" HeaderText="Given Amnt"></asp:BoundField>
                        <asp:BoundField DataField="balance_amnt" HeaderText="Balance Amnt"></asp:BoundField>
                        <asp:BoundField DataField="grand_total" HeaderText="Grand Total "></asp:BoundField>                       
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                  <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Order" Font-Size="Small" CommandArgument='<%# Eval("sale_id") %>' CssClass="btn btn-success"><i class="fa fa-edit"  aria-hidden="true"> Original Order</i></asp:LinkButton>
                                 <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Invoice"  Font-Size="Small" CommandArgument='<%# Eval("sale_id") %>' CssClass="btn btn-danger"><i class="fa fa-edit" aria-hidden="true"> Combine Invoice</i></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Return" Font-Size="Small" CommandArgument='<%# Eval("sale_id") %>' CssClass="btn btn-warning"><i class="fa fa-edit" aria-hidden="true"> Return</i></asp:LinkButton>
                                <asp:LinkButton ID="LinkPayBalance" runat="server" CommandName="ViewORPayBalance" Font-Size="Small" CommandArgument='<%# Eval("sale_id") %>' CssClass="btn btn-primary"><i class="fa fa-edit" aria-hidden="true"> View/Pay Balance</i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="#428BCA" ForeColor="White" />
                    <PagerStyle CssClass="pagination-ys" />
                    <%--<PagerStyle Wrap="False" CssClass="GridPager" HorizontalAlign="Center" VerticalAlign="Middle" />--%>
                </asp:GridView>
            </div>           
        </div>
    </div>
</asp:Content>
