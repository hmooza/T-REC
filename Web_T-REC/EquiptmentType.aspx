<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EquiptmentType.aspx.cs" Inherits="Web_T_REC.EquiptmentType" %>

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
                    <h3 class="panel-title">Equip Type - ประเภทอุปกรณ์</h3>
                </div>

                <div class="panel-body">

                    <div class="row">
                        <div class="form-horizontal">
                            <div class="col-md-6">
                                <div class="well">
                                    <!-- Treeview -->
                                    <div style="overflow: auto; height: 300px; width: 100%;">
                                        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Simple" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" NodeIndent="10">
                                            <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
                                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px" />
                                            <ParentNodeStyle Font-Bold="False" />
                                            <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" HorizontalPadding="0px" VerticalPadding="0px" />
                                        </asp:TreeView>
                                    </div>
                                </div>

                            </div>

                            <div class="col-md-6">
                                <!-- DETAIL -->
                                <asp:HiddenField ID="hidID" runat="server" />
                                <asp:HiddenField ID="hidParentID" runat="server" />

                                <div id="divDetail" runat="server" class="well">
                                    <asp:HiddenField ID="HiddenUsername" runat="server" />
                                    <form class="form-horizontal" role="form">
                                        <div class="form-group">
                                            <label class="control-label col-md-3" for="txtname">Type Name:</label>
                                            <div class="col-md-7 offset-2">
                                                <asp:TextBox ID="txtTypeName" runat="server" type="text" class="form-control" placeholder="ชื่อประเภท" ValidationGroup="ttt"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="input username" ForeColor="Red"
                                                    ControlToValidate="txtTypeName" ValidationGroup="ttt"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div id="divsub" runat="server">
                                            <div class="form-group">
                                                <div class="form-horizontal">
                                                    <label class="control-label col-md-3" for="txtname">Type Sub Name:</label>
                                                    <div class="col-md-7 offset-2">
                                                        <asp:TextBox ID="txtSubName" runat="server" type="text" class="form-control" placeholder="ชื่อประเภท" ValidationGroup="ttt"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>





                        <!-- TEST li -->
                        <%--<div class="row">
                        <div class="span3">
                            <div class="well">
                                <div>
                                    <ul class="nav nav-list">
                                        <li>
                                            <label class="tree-toggle nav-header">Bootstrap</label>
                                            <ul class="nav nav-list tree">
                                                <li><a href="#">JavaScript</a></li>
                                                <li><a href="#">CSS</a></li>
                                                <li>
                                                    <label class="tree-toggle nav-header">Buttons</label>
                                                    <ul class="nav nav-list tree">
                                                        <li><a href="#">Colors</a></li>
                                                        <li><a href="#">Sizes</a></li>
                                                        <li>
                                                            <label class="tree-toggle nav-header">Forms</label>
                                                            <ul class="nav nav-list tree">
                                                                <li><a href="#">Horizontal</a></li>
                                                                <li><a href="#">Vertical</a></li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </li>
                                        <li class="divider"></li>
                                        <li>
                                            <label class="tree-toggle nav-header">Responsive</label>
                                            <ul class="nav nav-list tree">
                                                <li><a href="#">Overview</a></li>
                                                <li><a href="#">CSS</a></li>
                                                <li>
                                                    <label class="tree-toggle nav-header">Media Queries</label>
                                                    <ul class="nav nav-list tree">
                                                        <li><a href="#">Text</a></li>
                                                        <li><a href="#">Images</a></li>
                                                        <li>
                                                            <label class="tree-toggle nav-header">Mobile Devices</label>
                                                            <ul class="nav nav-list tree">
                                                                <li><a href="#">iPhone</a></li>
                                                                <li><a href="#">Samsung</a></li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                                <li>
                                                    <label class="tree-toggle nav-header">Coding</label>
                                                    <ul class="nav nav-list tree">
                                                        <li><a href="#">JavaScript</a></li>
                                                        <li><a href="#">jQuery</a></li>
                                                        <li>
                                                            <label class="tree-toggle nav-header">HTML DOM</label>
                                                            <ul class="nav nav-list tree">
                                                                <li><a href="#">DOM Elements</a></li>
                                                                <li><a href="#">Recursive</a></li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>--%>


                        <%--    <p id="demo" onclick="myFunction()">Click me to change my text color.</p>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                    <asp:HiddenField ID="HiddenField1" runat="server" />

                    <asp:Button ID="Button1" runat="server" Text="save" OnClick="Button1_Click" />--%>

                        <%--                    <div class="container">
                        <div class="row">
                            <div class="well" style="width: 300px; padding: 8px 0;">
                                <div id="divTree" style="overflow-y: scroll; overflow-x: hidden; height: 150px;">

                                </div>
                            </div>
                        </div>
                    </div>--%>

                        <%--<div class="container">
                        <div class="row">
                            <div class="well" style="width: 300px; padding: 8px 0;">
                                <div style="overflow-y: scroll; overflow-x: hidden; height: 500px;">
                                    <ul class="nav nav-list">
                                        <li>
                                            <label class="tree-toggler nav-header">Header 1</label>
                                            <ul class="nav nav-list tree">
                                                <li><a href="#" onclick="myFunction('red')">Link test</a></li>
                                                <li><a href="#" onclick="myFunction('green')">Link</a></li>
                                                <li>
                                                    <label class="tree-toggler nav-header">Header 1.1</label>
                                                    <ul class="nav nav-list tree">
                                                        <li><a href="#">Link</a></li>
                                                        <li><a href="#">Link</a></li>
                                                        <li>
                                                            <label class="tree-toggler nav-header">Header 1.1.1</label>
                                                            <ul class="nav nav-list tree">
                                                                <li><a href="#">Link</a></li>
                                                                <li><a href="#">Link</a></li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </li>
                                        <li class="divider"></li>
                                        <li>
                                            <label class="tree-toggler nav-header">Header 2</label>
                                            <ul class="nav nav-list tree">
                                                <li><a href="#">Link</a></li>
                                                <li><a href="#">Link</a></li>
                                                <li>
                                                    <label class="tree-toggler nav-header">Header 2.1</label>
                                                    <ul class="nav nav-list tree">
                                                        <li><a href="#">Link</a></li>
                                                        <li><a href="#">Link</a></li>
                                                        <li>
                                                            <label class="tree-toggler nav-header">Header 2.1.1</label>
                                                            <ul class="nav nav-list tree">
                                                                <li><a href="#">Link</a></li>
                                                                <li><a href="#">Link</a></li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                                <li>
                                                    <label class="tree-toggler nav-header">Header 2.2</label>
                                                    <ul class="nav nav-list tree">
                                                        <li><a href="#">Link</a></li>
                                                        <li><a href="#">Link</a></li>
                                                        <li>
                                                            <label class="tree-toggler nav-header">Header 2.2.1</label>
                                                            <ul class="nav nav-list tree">
                                                                <li><a href="#">Link</a></li>
                                                                <li><a href="#">Link</a></li>
                                                            </ul>
                                                        </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>--%>





                        <!-- GRID -->
                        <div>
                            <asp:GridView ID="datagrid" runat="server" Visible="false" Width="100%" PageSize="10" AllowPaging="True"
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
                                            <asp:LinkButton ID="lnk" runat="server" Text='<%# Bind("TypeName") %>'
                                                CommandName="select" CommandArgument='<%# Bind("TypeName") %>' CausesValidation="false"></asp:LinkButton>
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


                        <!-- Message -->
                        <div id="msg" class="alert alert-info" role="alert" runat="server" visible="false">
                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                            <span class="sr-only">info:</span>
                            <asp:Label ID="lblmsg" runat="server" Text="Save Success."></asp:Label>
                        </div>



                    </div>

                    <div class="panel-footer" id="divCommand" runat="server">

                        <asp:Button ID="btnAdd" runat="server" Text="เพิ่มประเภทหลัก" class="btn btn-primary" CausesValidation="false" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnAddSub" runat="server" Text="เพิ่มประเภทย่อย" class="btn btn-primary" CausesValidation="false" OnClick="btnAddSub_Click" />
                        <asp:Button ID="btnCencel" runat="server" Text="ปิด" class="btn btn-primary" CausesValidation="false" OnClick="btnCencel_Click" />
                        <asp:Button ID="btnSave" runat="server" Text="บันทีก" class="btn btn-primary" ValidationGroup="updateuser" CausesValidation="true" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" Visible="false" runat="server" Text="ลบ" class="btn btn-danger" CausesValidation="false" OnClick="btnDelete_Click" OnClientClick="return confirm('ต้องการลบประเภทนี้หรือไม่?');" />


                        <button class="btn btn-default btn-md" data-toggle="modal" data-target="#DeleteModal" id="_btnDel" runat="server">
                            <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                        </button>

                    </div>



                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <script type="text/javascript">
        function getTree() {
            // Some logic to retrieve, or generate tree structure
            data = document.getElementById("TreeView1");
            return data;
        }


        $(".tree").treeview({ data: getTree() });

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('label.tree-toggler').click(function () {
                $(this).parent().children('ul.tree').toggle(300);
            });
        });
    </script>

    <%-- <script type="text/javascript">
        function myFunction(color) {

            document.getElementById("demo").style.color = color;
            var lnk = document.getElementById('<%= LinkButton1.ClientID %>');
            var hid = document.getElementById('<%= HiddenField1.ClientID %>');
            lnk.innerText = color;
            lnk.value = color;
            hid.value = color;
            lnk.innerText = hid.value;
        }
    </script>--%>


    <!-- MODAL - DeleteModal   -->
    <script>

        function ConfirmDelete() {
            $('#DeleteModal').modal()                      // initialized with defaults
            // $('#DeleteModal').modal({ keyboard: false })   // initialized with no keyboard
            // $('#DeleteModal').modal('show')
            return false;
        }
    </script>

    <div>
        <div class="modal fade" id="DeleteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="H3">Delete this record?</h4>
                    </div>
                    <div class="modal-body">
                        Are you sure to delete this record? 
                        <br />
                        ต้องการลบหรือไม่
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                        <asp:Button ID="Button2" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
