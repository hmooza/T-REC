<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Web_T_REC.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script lang="javascript" type="text/javascript">
        //Except only numbers for Age textbox
        function onlyNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="divwarning" class="alert alert-warning" role="alert" runat="server">
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                <span class="sr-only">warning:</span>
                <asp:Label ID="lblmsgs" runat="server" Text="ไม่ได้รับอนุญาติให้เข้าถึงหน้านี้"></asp:Label>
            </div>
            <div class="panel panel-primary" id="divcontent" runat="server">
                <div class="panel-heading">
                    <h3 class="panel-title">Customer</h3>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="dgSearch" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                        CssClass="table table-hover" GridLines="None" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333"
                        OnRowCommand="dgSearch_RowCommand" OnRowDataBound="dgSearch_RowDataBound" OnPageIndexChanging="dgSearch_PageIndexChanging">
                        <FooterStyle CssClass="grid-footer"></FooterStyle>
                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="grid-header" VerticalAlign="Top" BackColor="#98afc7" ForeColor="White"></HeaderStyle>
                        <FooterStyle CssClass="grid-footer" BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <Columns>
                            <%--<asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField HeaderText="รหัสลูกค้า" DataField="C_ID"></asp:BoundField>
                            <asp:TemplateField HeaderText="ชื่อ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("name") %>'
                                        CommandName="select" CommandArgument='<%# Bind("C_ID") %>' CausesValidation="false"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="เบอร์โทร" DataField="Tel"></asp:BoundField>
                            <asp:BoundField HeaderText="Created Date" DataField="CreatedDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                            <asp:BoundField HeaderText="Created By" DataField="CreatedBy"></asp:BoundField>
                            <asp:BoundField HeaderText="Update Date" DataField="UpdatedDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                            <asp:BoundField HeaderText="Update By" DataField="UpdatedBy"></asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                    </asp:GridView>

                    <!-- Custormer No -->
                    <div id="divCustormerDetail" runat="server">
                        <div class="row">
                            <div class="col-md-2" style="padding-bottom: 10px;">
                                รหัสลูกค้า : 
                                <asp:TextBox ID="txtC_ID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <!-- ชื่อ -->
                        <div class="row">
                            <div class="col-md-4">
                                ชื่อผู้ติดต่อ:
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-2 form-group">
                                เบอร์โทร:
                                <asp:TextBox ID="txtTel" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="col-md-2 form-group">
                                Email:
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-2 form-group">
                                Fax:
                                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <!-- บริษัท -->
                        <div class="row">
                            <div class="col-md-4">
                                ชื่อบริษัท:
                                <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-2 form-group">
                                เบอร์โทร:
                                <asp:TextBox ID="txtTel_Company" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <!-- ที่อยู่ -->
                        <div class="row">
                            <div class="col-md-6">
                                ที่อยู่:
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>
                        <!--  -->
                        <div class="row">
                            <div class="col-md-2">
                                หมายเลขผู้เสียภาษี:
                                <asp:TextBox ID="txtTax_Number" runat="server" MaxLength="13" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer" id="divCommand" runat="server">
                    <asp:Button ID="btnAdd" runat="server" Text="เพิ่ม" class="btn btn-primary" CausesValidation="false" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCencel" runat="server" Text="ปิด" class="btn btn-primary" CausesValidation="false" OnClick="btnCencel_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="บันทีก" class="btn btn-primary" ValidationGroup="updateuser" CausesValidation="true" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="ลบ" class="btn btn-danger" CausesValidation="false" OnClick="btnDelete_Click" OnClientClick="return confirm('ต้องการลบ User นี้หรือไม่?');" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
