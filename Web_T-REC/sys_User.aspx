<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="sys_User.aspx.cs" Inherits="Web_T_REC.WebForm.sys_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="alert alert-warning" role="alert" id="divwarning" runat="server">
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                <span class="sr-only">warning:</span>
                <asp:Label ID="Label1" runat="server" Text="ไม่ได้รับอนุญาติให้เข้าถึงหน้านี้"></asp:Label>
            </div>

            <div id="divcon" runat="server"></div>
            <div class="panel panel-primary" id="divcontent" runat="server">
                <div class="panel-heading">
                    <h3 class="panel-title">USERs</h3>
                </div>

                <div class="panel-body">
                    <asp:GridView ID="dgSearch" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                        CssClass="table table-hover" GridLines="None" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333"
                        OnRowCommand="dgSearch_RowCommand" OnRowDataBound="dgSearch_RowDataBound" OnPageIndexChanging="dgSearch_PageIndexChanging">
                        <FooterStyle CssClass="grid-footer"></FooterStyle>

                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="grid-header" VerticalAlign="Top" BackColor="#98afc7" ForeColor="White"></HeaderStyle>
                        <FooterStyle CssClass="grid-footer" BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                        <Columns>

                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Username">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("Username") %>'
                                        CommandName="select" CommandArgument='<%# Bind("Username") %>' CausesValidation="false"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField HeaderText="Created Date" DataField="CreatedDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                            <asp:BoundField HeaderText="Created By" DataField="CreatedBy"></asp:BoundField>
                            <asp:BoundField HeaderText="Update Date" DataField="UpdatedDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                            <asp:BoundField HeaderText="Update By" DataField="UpdatedBy"></asp:BoundField>

                        </Columns>
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                    </asp:GridView>

                    <!-- Message -->
                    <div id="msg" class="alert alert-info" role="alert"  runat="server" visible="false">
                        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                        <span class="sr-only">info:</span>
                        <asp:Label ID="lblmsg" runat="server" Text="Save Success."></asp:Label>
                    </div>


                    <div id="divDetail" runat="server" class="well">
                        <asp:HiddenField ID="HiddenUsername" runat="server" />
                        <form class="form-horizontal" role="form">
                            <div class="row">
                                <div class="form-group">
                                    <div class="form-horizontal">
                                        <label class="control-label col-sm-2" for="txtUsername">Username:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="inputUsername" runat="server" type="text" class="form-control" placeholder="Username" ValidationGroup="ttt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="input username" ForeColor="Red"
                                                ControlToValidate="inputUsername" ValidationGroup="ttt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group">
                                    <div class="form-horizontal">
                                        <label class="control-label col-sm-2" for="txtPassword">Password:</label>
                                        <div class="col-sm-4">
                                            <asp:TextBox ID="inputPassword" runat="server" type="password" class="form-control" placeholder="Password" ValidationGroup="ttt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="input password" ForeColor="Red"
                                                ControlToValidate="inputPassword" ValidationGroup="ttt"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="form-group">
                                    <div class="form-horizontal">
                                        <label class="control-label col-sm-2" for="txtPassword">Role:</label>
                                        <div class="col-sm-4">
                                            <asp:RadioButtonList ID="rdbRole" runat="server" RepeatDirection="Horizontal" Width="200px">
                                                <asp:ListItem Value="1" Text="Administrator"></asp:ListItem>
                                                <asp:ListItem Value="3" Selected="True" Text="User"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                            </div>





                        </form>
                    </div>


                </div>


                <div class="panel-footer" id="divCommand" runat="server">
                    <asp:Button ID="btnAdd" runat="server" Text="เพิ่ม" class="btn btn-primary" CausesValidation="false" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnCencel" runat="server" Text="ปิด" class="btn btn-primary" CausesValidation="false" OnClick="btnCencel_Click" />
                    <asp:Button ID="btnSave" runat="server" Text="บันทีก" class="btn btn-primary" ValidationGroup="ttt" CausesValidation="true" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="ลบ" class="btn btn-danger" CausesValidation="false" OnClick="btnDelete_Click" OnClientClick="return confirm('ต้องการลบ User นี้หรือไม่?');" />
                </div>
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
