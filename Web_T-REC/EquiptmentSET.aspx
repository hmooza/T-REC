<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EquiptmentSET.aspx.cs" Inherits="Web_T_REC.EquiptmentSET" %>

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
                    <h3 class="panel-title">Equipment SET</h3>
                </div>
                <asp:UpdatePanel ID="upd" runat="server" >
                    <ContentTemplate>
                        <div class="panel-body">
                            <!-- GRID -->
                            <div>
                                <asp:GridView ID="grid_SetName" runat="server" Width="100%" PageSize="10" AllowPaging="True"
                                    CssClass="table table-hover" GridLines="None" CellPadding="4" AutoGenerateColumns="False" ForeColor="#333333"
                                    OnRowCommand="grid_SetName_RowCommand">
                                    <FooterStyle CssClass="grid-footer"></FooterStyle>
                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="grid-header" VerticalAlign="Top" BackColor="#98afc7" ForeColor="White"></HeaderStyle>
                                    <FooterStyle CssClass="grid-footer" BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>
                                    <Columns>
                                        <asp:TemplateField HeaderText="No.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SET Name">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkSetName" runat="server" Text='<%# Bind("SETName") %>'
                                                    CommandName="lnkSetName" CommandArgument='<%# Bind("SETName") %>' CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="รายละเอียด" DataField="Price" DataFormatString="{0:n2}"></asp:BoundField>
                                        <asp:BoundField HeaderText="ราคาเซท" DataField="Description" DataFormatString="{0:n2}"></asp:BoundField>
                                        <asp:BoundField DataField="SET_ID" HeaderStyle-CssClass="displayNone" ItemStyle-CssClass="displayNone" FooterStyle-CssClass="displayNone" />
                                    </Columns>
                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                                </asp:GridView>
                            </div>

                            <!-- PANEL Detail  -->
                            <div class="panel panel-info" id="div1" runat="server">
                                <div class="panel-heading">
                                    <h3 class="panel-title">
                                        <asp:Label ID="lblSetName" runat="server" Text="Detail"></asp:Label>
                                    </h3>
                                </div>
                                <div class="panel-body">
                                    <!-- Row Detail-->
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="form-horizontal">
                                                <label class="control-label col-sm-2 col-md-2" for="txtUsername">เพิ่มอุปกรณ์:</label>
                                                <div class="col-sm-2 col-md-2">
                                                    ประเภท:
                                            <asp:DropDownList ID="ddlType" runat="server" type="text" class="form-control" ValidationGroup="" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
                                                </div>

                                                <div class="col-sm-2 col-md-2">
                                                    ชนิด:
                                            <asp:DropDownList ID="ddlCategory" runat="server" type="text" class="form-control" ValidationGroup="" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                                </div>

                                                <div class="col-sm-2 col-md-2">
                                                    รายการอุปกรณ์:
                                            <asp:DropDownList ID="ddlEquipmentList" runat="server" type="text" class="form-control" ValidationGroup=""></asp:DropDownList>
                                                </div>

                                                <div class="col-md-2 form-group" style="padding-top: 20px; padding-left: 20px;">
                                                    <asp:Button ID="btnAddEq" runat="server" Text="+" class="btn btn-primary" CausesValidation="false" OnClick="btnAddEq_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- GRID SET Detail -->
                                    <div>
                                        <asp:GridView ID="grid_Detail" runat="server" Width="100%" PageSize="10" AllowPaging="True"
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
                                                <asp:BoundField HeaderText="Name" DataField="Fullname" />
                                                <asp:BoundField HeaderText="ราคาเช่า" DataField="CostRent" DataFormatString="{0:n2}" />
                                                <asp:BoundField HeaderText="Last Update" DataField="UpdatedDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                                                <asp:BoundField HeaderText="Update By" DataField="UpdatedBy"></asp:BoundField>
                                                <asp:BoundField DataField="ID" HeaderStyle-CssClass="displayNone" ItemStyle-CssClass="displayNone" FooterStyle-CssClass="displayNone" />
                                                <asp:BoundField DataField="CostRent" HeaderStyle-CssClass="displayNone" ItemStyle-CssClass="displayNone" FooterStyle-CssClass="displayNone" />
                                            </Columns>
                                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center"></PagerStyle>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="form-horizontal" style="padding-left: 10px;">
                                                <label class="control-label col-sm-2 col-md-1" for="txtSetName">SET Name :</label>
                                                <div class="col-sm-3 col-md-3">
                                                    <asp:TextBox ID="txtSetName" runat="server" type="text" class="form-control" placeholder="SET Name" ValidationGroup="updatedata"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_SetName" runat="server" ErrorMessage="กรุณาระบุ SET Name" ForeColor="Red"
                                                        ControlToValidate="txtSetName" ValidationGroup="updatedata"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 form-group">
                                                    <%--<asp:Button ID="btnCreateSetName" runat="server" Text="+" class="btn btn-primary" CausesValidation="false" OnClick="btnCreateSetName_Click" />--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="form-horizontal" style="padding-left: 10px;">
                                                <label class="control-label col-sm-2 col-md-1" for="txtDescription">รายละเอียด :</label>
                                                <div class="col-sm-3 col-md-3">
                                                    <asp:TextBox ID="txtDescription" runat="server" type="text" class="form-control" placeholder="Description" ValidationGroup="updatedata"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Description" runat="server" ErrorMessage="กรุณาระบุ รายละเอียด" ForeColor="Red"
                                                        ControlToValidate="txtDescription" ValidationGroup="updatedata"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 form-group">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- TOTAL Cost -->
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="form-horizontal" style="padding-left: 10px;">
                                                <label class="control-label col-sm-2 col-md-1" for="txtPrice">ราคาเซท :</label>
                                                <div class="col-sm-3 col-md-3">
                                                    <asp:TextBox ID="txtPrice" runat="server" type="text" class="form-control" placeholder="ราคาเซท" ValidationGroup="updatedata"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator_Price" runat="server" ErrorMessage="กรุณาระบุ ราคาเซท" ForeColor="Red"
                                                        ControlToValidate="txtPrice" ValidationGroup="updatedata"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 form-group">
                                                </div>
                                                <!-- ราคา -->
                                                <%--<div class="col-sm-4 col-md-4" style="padding-top: 20px;">
                                    <div>
                                        <div class="input-group">
                                            <span class="input-group-addon">ราคาเซท</span>
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control  text-right"></asp:TextBox>
                                            <span class="input-group-addon" id="Span2">บาท</span>
                                        </div>
                                    </div>
                                </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END PANEL Detail  -->
                        </div>

                        <!-- Row 1 Create SET Name-->
                        <div class="panel-footer" id="divCommand" runat="server">
                            <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" class="btn btn-primary" CausesValidation="false" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnSave" runat="server" Text="บันทีก" class="btn btn-primary" ValidationGroup="updatedata" CausesValidation="true" OnClick="btnSave_Click" />
                            <asp:Button ID="btnDelete" runat="server" Text="ลบ" class="btn btn-danger" CausesValidation="false" OnClick="btnDelete_Click" OnClientClick="return confirm('ต้องการลบ User นี้หรือไม่?');" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
