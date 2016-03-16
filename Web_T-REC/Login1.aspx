<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login1.aspx.cs" Inherits="Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Santisuk-System</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Mobile viewport optimized -->
    <meta name="viewport" content="width=device-width, initial-scale=1">


    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <script src="bootstrap/js/bootstrap.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <script src="bootstrap/JQuery/jquery.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="bootstrap/js/jquery-1.8.2.js"></script>
    <script src="bootstrap/js/bootstrap-datepicker.js"></script>
    <link href="bootstrap/css/datepicker.css" rel="stylesheet" />
    <link href="Script/gridviewJs.css" rel="stylesheet" />
    <script src="Script/ScriptCommon.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <%-- <div>
                <img src="Pic/ses_banner1.png" />
            </div>--%>


                <!-- BRANDNER -->
                <div>
                    <style>
                        .ratio {
                            position: relative;
                            width: 100%;
                            height: inherit;
                            padding-bottom: 0;
                            background-repeat: no-repeat;
                            background-position: center center;
                            background-size: cover;
                        }
                    </style>

                    <div class="col-lg-12 col-md-12 col-xs-12 thumb">
                        <div>
                            <img class="img-responsive" src="Pic/ses_banner1.png" alt="Responsive image" />
                        </div>
                    </div>
                </div>

                <div class="col-xs-offset-0 col-sm-6 col-md-4 col-md-offset-4">
                    <h1 class="text-center login-title">Sign in to System</h1>
                    <div class="account-wall">
                        <%-- <img class="profile-img" src="https://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/eu7opA4byxI/photo.jpg?sz=120"
                        alt="">--%>
                        <form class="form-signin">
                            <asp:TextBox ID="inputUsername" runat="server" type="text" class="form-control" placeholder="Username" required autofocus></asp:TextBox>
                            <asp:TextBox ID="inputPassword" runat="server" type="password" class="form-control" placeholder="Password" required></asp:TextBox>
                            <%-- <input id="inputUsername" runat="server" type="text" class="form-control" placeholder="Username" required autofocus>
                <input id="inputPassword" runat="server" type="password" class="form-control" placeholder="Password" required>--%>
                            <%-- <button class="btn btn-lg btn-primary btn-block" type="submit">
                    Sign in</button>--%>
                            <asp:Button ID="btnSignin" runat="server" Text="Sign in" class="btn btn-lg btn-primary btn-block" OnClick="btnSignin_Click" />
                            <%-- <label class="checkbox pull-left">
                            <input type="checkbox" value="remember-me">
                            Remember me
                        </label>
                        <a href="#" class="pull-right need-help">Need help? </a><span class="clearfix"></span>--%>
                        </form>
                    </div>
                    <%--  <a href="#" class="text-center new-account">Create an account </a>--%>
                    <div>
                        <%--<asp:Label ID="lblResult" runat="server" Text="Label" ForeColor="Red"></asp:Label>--%>
                        <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
