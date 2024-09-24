<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Food_Delivery.pages.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@600&display=swap" rel="stylesheet" />
    <link href="../images/site.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            background-color: #f8f9fa;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            margin: 0;
        }
        .login-container {
            margin: 50px auto;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.6); /* Slightly transparent */
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            width: 380px;
        }
        .login-container h2 {
            text-align: center;
            margin-bottom: 20px;
            font-family: 'Arial Black', sans-serif; /* Beautiful font */
            font-size: 28px;
        }
        .btn-login, .btn-create-account {
            width: 100%;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .lbl-message {
            text-align: center;
            margin-top: 10px;
            color: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <div class="form-group">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-login" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnCreateAccount" runat="server" CssClass="btn btn-secondary btn-create-account" Text="Create New Account" PostBackUrl="CreateAccount.aspx" />
            </div>
            <div class="lbl-message">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />
            </div>
        </div>
    </form>
</body>
</html>
