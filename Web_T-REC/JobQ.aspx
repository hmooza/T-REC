<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="JobQ.aspx.cs" Inherits="Web_T_REC.JobQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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


                    <div id="divEmpDetail" runat="server">
                        <!--   Customer -->
                        <div class="row">
                            <div class="col-md-2" style="padding-bottom: 10px;">
                                ลูกค้า
                                <asp:DropDownList ID="ddlEducation" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                            </div>

                            <div class="col-md-4">
                                ชื่อผู้ติดต่อ:
                                <asp:TextBox ID="txtNickname" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>

                            <div class="col-md-2 form-group">
                                เบอร์โทร:
                                <asp:TextBox ID="txtStu_NameT" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>



                        <!--   -->
                        <div class="row">
                            <div class="col-md-4 form-group">
                                ชื่องาน:
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>


                        <!--   -->
                        <div class="row">
                            <div class="col-md-4 form-group">
                                สถานที่:
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                        </div>

                        <!-- วันที่ -->
                        <div class="row">
                            <div class="col-md-2">
                                นัดเวลา:
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>

                            <div class="col-md-2">
                                <div class="form-horizontal">
                                    <div class="control-group">
                                        นัดวันที่:
                                        <label for="lblWorkDate" class="control-label col-sm-2"></label>
                                        <div class="controls">
                                            <div class="input-group" data-date-format="dd-mm-yyyy" data-date="01-01-2014">

                                                <asp:TextBox ID="txt_WorkDate" runat="server" CssClass="date-picker form-control" Text=""></asp:TextBox>
                                                <label for="lblStart_Date" class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <!--  -->
                        <div class="row">
                            <div class="col-md-6 form-group">
                                ที่อยู่:
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)"></asp:TextBox>
                            </div>
                        </div>

                        <!--  -->
                        <div class="row">
                            <div class="col-md-6 form-group">
                                อุปกรณ์ที่ต้องการ:
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)" TextMode="MultiLine" Height="100"></asp:TextBox>
                            </div>
                        </div>
                    </div>

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

    <script type="text/javascript">
        $(".date-picker").datepicker();

        $(".date-picker").on("change", function () {
            var id = $(this).attr("id");
            var val = $("label[for='" + id + "']").text();
            $("#msg").text(val + " changed");
        });

    </script>
</asp:Content>
