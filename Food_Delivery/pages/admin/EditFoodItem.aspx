<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFoodItem.aspx.cs" Inherits="Food_Delivery.pages.admin.EditFoodItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Food Item</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        .container {
            width: 600px;
            margin: 50px auto;
            background-color: white;
            padding: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        h2 {
            text-align: center;
            color: #007bff;
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            color: #333;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 16px;
        }

        .input-field:focus {
            border-color: #007bff;
            outline: none;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }

        .btn {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 18px;
            cursor: pointer;
            margin-top: 20px;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .btn-cancel {
            background-color: #6c757d;
        }

        .btn-cancel:hover {
            background-color: #5a6268;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .message {
            color: red;
            text-align: center;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Edit Food Item</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            
            <asp:HiddenField ID="hfFoodItemId" runat="server" />

            <div class="form-group">
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" CssClass="input-field" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtDescription">Description:</label>
                <asp:TextBox ID="txtDescription" CssClass="input-field" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtPrice">Price:</label>
                <asp:TextBox ID="txtPrice" CssClass="input-field" runat="server"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="ddlRestaurant">Restaurant:</label>
                <asp:DropDownList ID="ddlRestaurant" CssClass="input-field" runat="server"></asp:DropDownList>
            </div>

            <asp:Button ID="btnUpdate" CssClass="btn" runat="server" Text="Update Food Item" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnCancel" CssClass="btn btn-cancel" runat="server" Text="Back" PostBackUrl="~/pages/admin/ViewFoodItems.aspx" />
        </div>
    </form>
</body>
</html>
