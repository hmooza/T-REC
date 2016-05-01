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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
