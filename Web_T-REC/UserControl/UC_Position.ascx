<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Position.ascx.cs" Inherits="Web_T_REC.UserControl.UC_Position" %>

<div class="row col-md-6 col-sm-6">
    <div class="panel panel-info" id="div1" runat="server">
        <div class="panel-heading">
            <h3 class="panel-title">ค่าตัวตามตำแหน่ง</h3>
        </div>

        <div class="panel-body ">

            <div class="row">
                <div class="form-group">
                    <div class="form-horizontal">
                        <div class="col-sm-3 col-md-3">
                            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control input-sm" Width="150"></asp:DropDownList>

                        </div>
                        <div class="col-sm-3 col-md-3">
                            <asp:Button ID="btnAdd" runat="server" Text="เพิ่ม" class="btn btn-primary btn-sm" CausesValidation="false" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </div>



            </div>
            <div class="row">

                <!-- GRID -->
                <div style="padding:10px;">
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

                            <asp:TemplateField HeaderText="ตำแหน่ง">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("Position") %>'
                                        CommandName="select" CommandArgument='<%# Bind("pos_id") %>' CausesValidation="false"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="ค่าตัว">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control input-sm"
                                        onkeypress="return onlyNumbers(event)" Text='<%# Bind("cost") %>' Width="150px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>



                        </Columns>
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                    </asp:GridView>
                </div>


            </div>
        </div>
    </div>

</div>



