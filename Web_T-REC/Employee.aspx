<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Web_T_REC.Employee" %>

<%@ Register Src="~/UserControl/UC_Position.ascx" TagPrefix="uc1" TagName="UC_Position" %>


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



    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div id="divwarning" class="alert alert-warning" role="alert" runat="server">
        <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
        <span class="sr-only">warning:</span>
        <asp:Label ID="lblmsgs" runat="server" Text="ไม่ได้รับอนุญาติให้เข้าถึงหน้านี้"></asp:Label>
    </div>


    <div class="panel panel-primary" id="divcontent" runat="server">
        <div class="panel-heading">
            <h3 class="panel-title">Employee</h3>
        </div>

        <div class="panel-body">
            <!-- Message -->
            <div id="msg" class="alert alert-info" role="alert" runat="server" visible="false">
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                <span class="sr-only">info:</span>
                <asp:Label ID="lblmsg" runat="server" Text="Save Success."></asp:Label>
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

                        <asp:TemplateField HeaderText="Emp_ID">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("Emp_id") %>'
                                    CommandName="select" CommandArgument='<%# Bind("ID") %>' CausesValidation="false"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField HeaderText="Emp.Firstname" DataField="Firstname"></asp:BoundField>
                        <asp:BoundField HeaderText="Emp.Lastname" DataField="Lastname"></asp:BoundField>
                        <asp:BoundField HeaderText="Last Update" DataField="UpdatedDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                        <asp:BoundField HeaderText="Update By" DataField="UpdatedBy"></asp:BoundField>

                    </Columns>
                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                </asp:GridView>
            </div>


            <!-- รายละเอียด -->

            <div id="divDetail" runat="server">

                <fieldset>
                    <legend>ข้อมูลพนักงาน
                    </legend>

                    <!-- รหัสพนักงาน -->
                    <div class="row">
                        <div class="col-md-2" style="padding-bottom: 10px;">
                            รหัสพนักงาน : E201201
                                <asp:TextBox ID="txtEmpID" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>

                        </div>
                    </div>


                    <!-- ชื่อ -->
                    <div class="row">
                        <%--<div class="col-md-2">
                                คำนำหน้า
                                <asp:DropDownList ID="ddlTitleName" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                            </div>--%>

                        <div class="col-md-2 form-group has-error">
                            <asp:Label ID="Label5" runat="server" Text="เพศ" CssClass="control-label"></asp:Label>
                            <asp:RadioButtonList ID="rdbSex" runat="server" RepeatDirection="Horizontal" CssClass="control-label">
                                <asp:ListItem Value="0">ชาย</asp:ListItem>
                                <asp:ListItem Value="1">หญิง</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div class="col-md-2">
                            ชื่อเล่น:
                                <asp:TextBox ID="txtNickname" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>

                        <div class="col-md-2 form-group has-error">
                            ชื่อ:
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-2 form-group has-error">
                            <asp:Label ID="Label2" CssClass="control-label" runat="server" Text="นามสกุล"></asp:Label>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>


                    <!-- วันเกิด -->
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    วัน เดือน ปี เกิด:
                                        <label for="txtStu_Birthday" class="control-label col-sm-2"></label>
                                    <div class="controls">
                                        <div class="input-group" data-date-format="dd-mm-yyyy" data-date="01-01-2014">

                                            <asp:TextBox ID="txtBirthDay" runat="server" CssClass="date-picker form-control" Text=""></asp:TextBox>
                                            <label for="txtStart_Date" class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>

                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>




                        <div class="col-md-2 form-group has-error">
                            อายุ:
                                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)">
                                </asp:TextBox>
                        </div>

                        <div class="col-md-2 form-group">
                            เบอร์มือถือ:
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-2 form-group">
                            Email:
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    วันที่เริ่มงาน:
                                        <label for="lblStartWork_Date" class="control-label col-sm-2"></label>
                                    <div class="controls">
                                        <div class="input-group" data-date-format="dd-mm-yyyy" data-date="01-01-2014">

                                            <asp:TextBox ID="txtStartWotk_Date" runat="server" CssClass="date-picker form-control" Text=""></asp:TextBox>
                                            <label for="txtStartWotk_Date" class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>

                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- เลขประชาชน -->

                        <div class="col-md-2">
                            เลขประจำตัวประชาชน:
                                <asp:TextBox ID="txtIdenNo" runat="server" CssClass="form-control input-sm" MaxLength="13" onkeypress="return onlyNumbers(event)"></asp:TextBox>
                        </div>

                        <div class="col-md-2 form-group">
                            เลขบัญชีธนาคาร:
                                <asp:TextBox ID="txtAccNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-2 form-group">
                            ธนาคาร:
                                <asp:TextBox ID="txtAccName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>

                    </div>

                    <!-- ที่อยู่ -->
                    <div class="row">
                        <div class="col-md-8">
                            ที่อยู่:
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                </fieldset>




                <!-- ตำแหน่งงาน -->
                <div class="row" style="padding: 10px;">
                    <fieldset>
                        <legend>ตำแหน่งงาน:
                        </legend>
                        <div class="col-md-2">ฝ่าย/แผนก<asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control input-sm"></asp:DropDownList></div>
                        <div class="col-md-2">เงินเดือน<asp:TextBox ID="txtSalary" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)"></asp:TextBox></div>
                        <div class="col-md-2">ค่าตัว<asp:TextBox ID="txtPosition_cost" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)"></asp:TextBox></div>
                        <div class="col-md-2">ตำแหน่งงาน (มีได้หลายตำแหน่ง)<asp:TextBox ID="txtPosition_name" runat="server" CssClass="form-control input-sm"></asp:TextBox></div>




                    </fieldset>
                </div>

                <!-- Posion Detail -->
                <uc1:UC_Position runat="server" ID="UC_Position" />

            </div>


        </div>

        <div class="panel-footer" id="divCommand" runat="server">
            <asp:Button ID="btnAdd" runat="server" Text="เพิ่ม" class="btn btn-primary" CausesValidation="false" OnClick="btnAdd_Click" />
            <asp:Button ID="btnCencel" runat="server" Text="ปิด" class="btn btn-primary" CausesValidation="false" OnClick="btnCencel_Click" />
            <asp:Button ID="btnSave" runat="server" Text="บันทีก" class="btn btn-primary" ValidationGroup="updateuser" CausesValidation="true" OnClick="btnSave_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="ลบ" class="btn btn-danger" CausesValidation="false" OnClick="btnDelete_Click" OnClientClick="return confirm('ต้องการลบ User นี้หรือไม่?');" />
        </div>
    </div>

    <%--            
        </ContentTemplate>
    </asp:UpdatePanel>--%>


    <script type="text/javascript">
        $(".date-picker").datepicker();

        $(".date-picker").on("change", function () {
            var id = $(this).attr("id");
            var val = $("label[for='" + id + "']").text();
            $("#msg").text(val + " changed");
        });

    </script>
</asp:Content>
