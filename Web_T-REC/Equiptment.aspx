<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Equiptment.aspx.cs" Inherits="Web_T_REC.Equiptment" %>

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
            <h3 class="panel-title">Equipment</h3>
        </div>

        <div class="panel-body">
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
                        <div class="col-md-2 form-group has-error">
                            ชื่ออุปกรณ์:
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm" MaxLength="250"></asp:TextBox>
                        </div>


                        <div class="col-md-4 form-group">
                            ชื่อเต็ม:
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-sm" MaxLength="1024">
                                </asp:TextBox>
                        </div>

                        <div class="col-md-2 form-group">
                            SN:
                                <asp:TextBox ID="txtSN" runat="server" CssClass="form-control input-sm" MaxLength="250"></asp:TextBox>
                        </div>
                        <div class="col-md-2 form-group">
                            เบอร์:
                                <asp:TextBox ID="txtEquipNo" runat="server" CssClass="form-control input-sm" MaxLength="250"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Row 2-->
                    <div class="row">
                        <!-- Treeview -->
                        <div style="padding-left: 20px;">ประเภท:</div>

                        <asp:HiddenField ID="hidID" runat="server" />

                        <div class="input-group col-md-2" style="padding-left: 20px;">
                            <asp:TextBox ID="txtTypeName" runat="server" CssClass="form-control input-sm" />
                            <label class="input-group-addon"
                                data-toggle="modal" data-target="#EquiptTypeModal">
                            </label>
                            <%--<asp:Button ID="Button1" runat="server" Text="..." class="input-group-addon"
                                        data-toggle="modal" data-target="#EquiptTypeModal" />--%>
                        </div>
                        <div style="padding-left: 20px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="กรุณาระบุ"
                                ControlToValidate="txtTypeName" ValidationGroup="updatedata" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>



                    <!-- Row 3 -->
                    <div class="row">
                        <div class="col-md-2 form-group">
                            ราคาซื้อ:
                                    <asp:TextBox ID="txtCostBuy" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="กรุณาระบุ"
                                ControlToValidate="txtCostBuy" ValidationGroup="updatedata" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>




                        <div class="col-md-2 form-group">
                            ราคาเช่า:
                                    <asp:TextBox ID="txtCostRent" runat="server" CssClass="form-control input-sm" onkeypress="return onlyNumbers(event)"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="กรุณาระบุ"
                                ControlToValidate="txtCostRent" ValidationGroup="updatedata" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <!-- Row 3 -->
                    <div class="row">
                        <div class="col-md-2 form-group">
                            ซื้อจากร้าน:
                                    <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <div class="control-group">
                                วันที่ซื้อ:
                                        <label for="txtBuyDate" class="control-label col-sm-2"></label>
                                <div class="controls">
                                    <div class="input-group" data-date-format="dd-mm-yyyy" data-date="01-01-2014">

                                        <asp:TextBox ID="txtBuyDate" runat="server" CssClass="date-picker form-control" Text=""></asp:TextBox>
                                        <label for="txtBuyDate" class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>

                                        </label>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="col-md-2">
                            <div class="control-group">
                                วันที่หมดประกัน:
                                        <label for="txtExpireDate" class="control-label col-sm-2"></label>
                                <div class="controls">

                                    <div class="input-group" data-date-format="dd-mm-yyyy" data-date="01-01-2014">

                                        <asp:TextBox ID="txtExpireDate" runat="server" CssClass="date-picker form-control" Text=""></asp:TextBox>
                                        <label for="txtExpireDate" class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>

                                        </label>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 form-group">
                            เลขที่ใบเสร็จ:
                                    <asp:TextBox ID="txtReceiptTax" runat="server" CssClass="form-control input-sm">
                                    </asp:TextBox>
                        </div>
                    </div><!-- Test Kub -->

                    <!-- Row 4 -->
                    <div class="row">
                        <div class="col-md-2 form-group">
                            ประเภท:
                                    <asp:DropDownList ID="TextBox9" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                        </div>

                        <div class="col-md-2 form-group">
                            ชนิด:
                                    <asp:DropDownList ID="TextBox10" runat="server" CssClass="form-control input-sm">
                                    </asp:DropDownList>
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
            <asp:Button ID="btnDelete" runat="server" Text="ลบ" class="btn btn-danger" CausesValidation="false" OnClick="btnDelete_Click" OnClientClick="return confirm('ต้องการลบ User นี้หรือไม่?');" />
        </div>
    </div>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>

    <!-- MODAL - DeleteModal   -->
    <script>

        function ConfirmDelete() {
            $('#EquiptTypeModal').modal()                      // initialized with defaults
            // $('#DeleteModal').modal({ keyboard: false })   // initialized with no keyboard
            // $('#DeleteModal').modal('show')
            return false;
        }
    </script>

    <div>
        <div class="modal fade" id="EquiptTypeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="H3">ประเภทอุปกรณ์</h4>
                    </div>
                    <div class="modal-body">


                        <div>
                            เลือกประเภทอุปกรณ์
                        </div>

                        <div class="col-md-3 form-group">
                            <asp:TreeView ID="TreeView1" runat="server" CssClass="btn-default" ImageSet="Arrows" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                                <ParentNodeStyle Font-Bold="False" />
                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                            </asp:TreeView>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button ID="Button2" runat="server" Text="เลือก" CssClass="btn btn-primary" OnClick="btnDelete_Click" />--%>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(".date-picker").datepicker();

        $(".date-picker").on("change", function () {
            var id = $(this).attr("id");
            var val = $("label[for='" + id + "']").text();
            $("#msg").text(val + " changed");
        });

    </script>
</asp:Content>
