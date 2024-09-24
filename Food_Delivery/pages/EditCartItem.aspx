<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCartItem.aspx.cs" Inherits="Food_Delivery.pages.EditCartItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Cart Item</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .edit-cart-container {
            margin: 50px auto;
            max-width: 600px;
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        .form-group label {
            font-weight: bold;
        }
        .btn-save {
            background-color: #28a745;
            color: #fff;
        }
        .btn-cancel {
            background-color: #dc3545;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="edit-cart-container">
            <h3>Edit Quantity</h3>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            
            <div class="form-group">
                <label for="lblFoodItemName">Food Item Name:</label>
                <asp:Label ID="lblFoodItemName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtQuantity">Quantity:</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" type="number" min="1" />
            </div>

            <div class="form-group">
                <label for="lblPrice">Price (per item):</label>
                <asp:Label ID="lblPrice" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="lblTotalPrice">Total Price:</label>
                <asp:Label ID="lblTotalPrice" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-save" Text="Save Changes" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-cancel" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</body>
</html>
