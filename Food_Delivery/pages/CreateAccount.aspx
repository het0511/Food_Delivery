<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Food_Delivery.CreateAccount" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Create Account</title>
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
        .create-account-container {
            //max-width: 400px;
            margin: 50px auto;
            padding: 20px;
            background-color: rgba(255, 255, 255, 0.6); /* Slightly transparent */
            box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            width: 450px;
        }
        .create-account-container h2 {
            text-align: center;
            margin-bottom: 20px;
            font-family: 'Arial Black', sans-serif; /* Beautiful font */
            font-size: 28px;
        }
        .btn-create-account, .btn-back {
            width: 100%;
            margin-bottom: 10px;
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
        <div class="create-account-container">
            <h2>Create Account</h2>
            <div class="form-group">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Placeholder="User Name" />
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="User Name is required." CssClass="text-danger" Display="Dynamic" />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email format." CssClass="text-danger" Display="Dynamic" 
                    ValidationExpression="^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$" />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" Placeholder="Mobile Number" />
                <asp:RequiredFieldValidator ID="rfvMobileNumber" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number is required." CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revMobileNumber" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Invalid Mobile Number." CssClass="text-danger" Display="Dynamic" 
                    ValidationExpression="^\d{10}$" />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Password" TextMode="Password" />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password must be at least 6 characters long." CssClass="text-danger" Display="Dynamic" 
                    ValidationExpression=".{6,}" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnCreateAccount" runat="server" CssClass="btn btn-primary btn-create-account" Text="Create Account" OnClick="btnCreateAccount_Click" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnBackToLogin" runat="server" CssClass="btn btn-secondary btn-back" Text="Back to Login" PostBackUrl="Login.aspx" CausesValidation="false" />
            </div>
            <div class="lbl-message">
                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" ForeColor="#339933" />
            </div>
        </div>
    </form>
</body>
</html>
