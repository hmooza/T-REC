<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuotationList.aspx.cs" Inherits="Web_T_REC.QuotationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divwarning" class="alert alert-warning" role="alert" runat="server">
        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
        <span class="sr-only">warning:</span>
        <asp:Label ID="lblmsgs" runat="server" Text="ไม่ได้รับอนุญาติให้เข้าถึงหน้านี้"></asp:Label>
    </div>

    <div class="panel panel-primary" id="divcontent" runat="server">
        <div class="panel-heading">
            <h3 class="panel-title">Equipment List</h3>
        </div>

        <div class="panel-body">
            <!-- Search Filter -->
            <div class="well">
                <%--<div class="form-horizontal" role="form">
                    <div class="form-group">
                        <label class="control-label col-md-3" for="txtNo">No.</label>
                        <div class="col-md-7 offset-2">
                            <asp:TextBox ID="txtNo" runat="server" type="text" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>--%>
                <div class="row">
                    <div class="form-horizontal">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtNo">No.</label>
                                <div class="col-md-7 offset-2">
                                    <asp:TextBox ID="txtNo" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="control-label col-md-3" for="txtNo2">No.</label>
                                <div class="col-md-7 offset-2">
                                    <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Button runat="server" ID="btnTest" Text="ทดสอบเพิ่ม" OnClick="btnTest_Click" />

            <!-- GRID -->
            <div>
                <asp:GridView ID="datagrid" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                    CssClass="table table-hover" GridLines="None" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333"
                    OnRowCommand="datagrid_RowCommand" OnRowDataBound="datagrid_RowDataBound" OnPageIndexChanging="datagrid_PageIndexChanging">
                    <FooterStyle CssClass="grid-footer"></FooterStyle>

                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="grid-header" VerticalAlign="Top" BackColor="#98afc7" ForeColor="White"></HeaderStyle>
                    <FooterStyle CssClass="grid-footer" BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                    <Columns>

                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ชื่ออุปกรณ์">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("Name") %>'
                                    CommandName="select" CommandArgument='<%# Bind("ID") %>' CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField HeaderText="ประเภท" DataField="TypeName"></asp:BoundField>
                        <asp:BoundField HeaderText="ราคาซื้อ" DataField="CostBuy"></asp:BoundField>
                        <asp:BoundField HeaderText="ราคาเช่า" DataField="CostRent"></asp:BoundField>
                        <asp:BoundField HeaderText="Last Update" DataField="UpdatedDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                        <asp:BoundField HeaderText="Update By" DataField="UpdatedBy"></asp:BoundField>

                    </Columns>
                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
