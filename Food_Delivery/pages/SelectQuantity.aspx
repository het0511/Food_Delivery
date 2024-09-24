<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectQuantity.aspx.cs" Inherits="Food_Delivery.SelectQuantity" %> 

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Select Quantity</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../images/site.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .header {
            padding: 10px;
            background-color: #ffffff;
            box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.1);
            text-align: center;
            margin-bottom: 20px;
            font-family: 'Arial Black', sans-serif; /* Beautiful font */
        }
        .quantity-selection {
            margin: 20px;
            text-align: center;
        }
        .quantity-selection input[type="number"] {
            width: 60px; /* Adjust width as needed */
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h2>Select Quantity</h2>
        </div>

        <div class="container">
            <div class="quantity-selection">
                <asp:Label ID="lblFoodItemName" runat="server" CssClass="h4" /><br /><br />
                <asp:Label ID="lblPrice" runat="server" CssClass="h5 text-muted" /><br /><br />
                <asp:Label ID="lblDescription" runat="server" CssClass="h5 text-muted" /><br /><br />
                <label for="txtQuantity">Quantity:</label>
                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control d-inline" TextMode="Number" Width="60px" OnInput="updateTotal()" min="1" Text="1" /><br /><br />
                <asp:Button ID="btnConfirmAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-success" OnClick="btnConfirmAddToCart_Click" />
            </div>
        </div>
    </form>
</body>
</html>
