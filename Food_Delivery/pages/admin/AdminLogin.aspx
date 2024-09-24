<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Food_Delivery.pages.admin.AdminLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        .login-container {
            width: 300px;
            margin: 100px auto;
            padding: 20px;
            background-color: white;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        h2 {
            text-align: center;
            color: #333;
        }

        label {
            display: block;
            margin-bottom: 10px;
            color: #666;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #28a745;
            border: none;
            border-radius: 5px;
            color: white;
            font-size: 16px;
            cursor: pointer;
        }

        input[type="submit"]:hover {
            background-color: #218838;
        }

        .error-message {
            color: red;
            text-align: center;
        }
    </style>
</head>
<body>
    <div class="login-container">
        <h2>Admin Login</h2>

        <asp:Label ID="LabelMessage" runat="server" CssClass="error-message"></asp:Label>

        <form id="form1" runat="server">
            <div>
                <label for="username">Username</label>
                <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div>
                <label for="password">Password</label>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="ButtonLogin_Click" />
            </div>
        </form>
    </div>
</body>
</html>
