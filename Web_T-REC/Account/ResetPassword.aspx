<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Web_T_REC.Account.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <h1 class="text-center login-title">Reset Password</h1>
                <div class="account-wall">
                    <%--<img class="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120"
                        alt="">--%>
                    <form class="form-signin">
                        <asp:TextBox ID="inputUsername" runat="server" type="text" class="form-control" placeholder="Username" required autofocus></asp:TextBox>
                        <asp:TextBox ID="inputPassword" runat="server" type="password" class="form-control" placeholder="Password" required></asp:TextBox>
                        <%-- <input id="inputUsername" runat="server" type="text" class="form-control" placeholder="Username" required autofocus>
                <input id="inputPassword" runat="server" type="password" class="form-control" placeholder="Password" required>--%>
                        <%-- <button class="btn btn-lg btn-primary btn-block" type="submit">
                    Sign in</button>--%>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-lg btn-primary btn-block" OnClick="btnReset_Click" />
                        
                    </form>
                </div>
                
                <div>
                    <asp:Label ID="lblResult" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
