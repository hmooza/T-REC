<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Package.aspx.cs" Inherits="Web_T_REC.Package" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .displayNone {
            display: none;
        }
    </style>
    <script lang="javascript" type="text/javascript">
        //Except only numbers for Age textbox
        function onlyNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function Alert(message) {
            alert(message);
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
                    <h3 class="panel-title">Package</h3>
                </div>
            </div>
            <div class="panel panel-primary" id="div1" runat="server">
                <div class="panel-heading">
                    <h3 class="panel-title">Equipment</h3>
                </div>
                <div class="panel-body">
                    <!-- GRID -->
                    <div>
                        <asp:GridView ID="datagrid" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                            CssClass="table table-hover" GridLines="None" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333">
                            <FooterStyle CssClass="grid-footer"></FooterStyle>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="grid-header" VerticalAlign="Top" BackColor="#98afc7" ForeColor="White"></HeaderStyle>
                            <FooterStyle CssClass="grid-footer" BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Package Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("Name") %>'
                                            CommandName="select" CommandArgument='<%# Bind("ID") %>' CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="ราคา" DataField="Price"></asp:BoundField>
                                <asp:BoundField HeaderText="ประเภท" DataField="Description"></asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                        </asp:GridView>
                    </div>
                    <!-- Message -->
                    <div id="msg" class="alert alert-info" role="alert" runat="server" visible="false">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">info:</span>
                        <asp:Label ID="lblmsg" runat="server" Text="Save Success."></asp:Label>
                    </div>
                    <div id="divDetail" runat="server" class="well">
                        <asp:HiddenField ID="HiddenUsername" runat="server" />
                        <form class="form-horizontal" role="form">
                            <!-- Row 1 -->
                            <div class="row">
                                <div class="col-md-6 form-group has-error">
                                    ชื่ออุปกรณ์:
                                <asp:TextBox ID="txtPac_Name" runat="server" CssClass="form-control input-sm" MaxLength="20"></asp:TextBox>
                                </div>
                                <div class="col-md-6 form-group">
                                    รายละเอียด:
                                <asp:TextBox ID="txtPac_Desc" runat="server" CssClass="form-control input-sm" MaxLength="50">
                                </asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-group has-error">
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6">
                                            รายการ Set:
                                            <asp:DropDownList ID="ddlSet" runat="server" type="text" class="form-control" ValidationGroup=""></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 col-md-6" style="padding-top: 20px; padding-left: 20px;">
                                            <asp:Button ID="btnAddSet" runat="server" Text="+" class="btn btn-primary" CausesValidation="false" OnClick="btnAddSet_Click" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12">
                                            <asp:GridView ID="grid_Set" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                                                CssClass="table table-hover" GridLines="None" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333">
                                                <FooterStyle CssClass="grid-footer"></FooterStyle>
                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="grid-header" VerticalAlign="Top" BackColor="#98afc7" ForeColor="White"></HeaderStyle>
                                                <FooterStyle CssClass="grid-footer" BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="SET Name" DataField="SETName"></asp:BoundField>
                                                    <asp:BoundField DataField="SET_ID" HeaderStyle-CssClass="displayNone" ItemStyle-CssClass="displayNone" FooterStyle-CssClass="displayNone" />
                                                </Columns>
                                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 form-group has-error">
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6">
                                            รายการอุปกรณ์ :
                                            <asp:DropDownList ID="ddlEquipmentList" runat="server" type="text" class="form-control" ValidationGroup=""></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 col-md-6" style="padding-top: 20px; padding-left: 20px;">
                                            <asp:Button ID="btnAddEquip" runat="server" Text="+" class="btn btn-primary" CausesValidation="false" OnClick="btnAddEquip_Click" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-12">
                                            <asp:GridView ID="grid_Equipment" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                                                CssClass="table table-hover" GridLines="None" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333">
                                                <FooterStyle CssClass="grid-footer"></FooterStyle>
                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="grid-header" VerticalAlign="Top" BackColor="#98afc7" ForeColor="White"></HeaderStyle>
                                                <FooterStyle CssClass="grid-footer" BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Name" DataField="Name"></asp:BoundField>
                                                    <asp:BoundField DataField="ID" HeaderStyle-CssClass="displayNone" ItemStyle-CssClass="displayNone" FooterStyle-CssClass="displayNone" />
                                                </Columns>
                                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 form-group has-error">
                                    ราคา:
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control input-sm" MaxLength="20"></asp:TextBox>
                                </div>
                            </div>
                        </form>
                    </div>
                    <!-- End Detail -->

                </div>
                <!-- End body -->

                <div class="panel-footer" id="divCommand" runat="server">
                    <asp:Button ID="btnAdd" runat="server" Text="เพิ่ม" class="btn btn-primary" CausesValidation="false" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCencel" runat="server" Text="ปิด" class="btn btn-primary" CausesValidation="false" OnClick="btnCencel_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="บันทีก" class="btn btn-primary" ValidationGroup="updatedata" CausesValidation="true" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="ลบ" class="btn btn-danger" CausesValidation="false" 
                        OnClientClick="return confirm('ต้องการลบ User นี้หรือไม่?');" OnClick="btnDelete_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
