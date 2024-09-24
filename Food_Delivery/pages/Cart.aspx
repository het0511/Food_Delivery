<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Food_Delivery.Cart" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Cart</title>
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
            text-align: right;
        }
        .table-striped {
            background-color: rgba(255, 255, 255, 0.8); /* White with 80% opacity */
        }
        .cart-items {
            margin: 20px;
        }
        .order-now-button {
            margin: 20px;
        }
        .empty-cart-message {
            text-align: center;
            color: #ff0000;
            font-weight: bold;
            margin: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <asp:Label ID="lblWelcomeMessage" runat="server" CssClass="welcome-message"></asp:Label>
            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger logout-button" Text="Log Out" OnClick="btnLogout_Click" />
        </div>

        <div class="cart-items">
        <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnRowCommand="CartGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="FoodItemName" HeaderText="Food Item Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Price" HeaderText="Price" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditItem" CommandArgument='<%# Eval("FoodItemId") %>' CssClass="btn btn-primary" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteItem" CommandArgument='<%# Eval("FoodItemId") %>' CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>

        <center><asp:Label ID="lblEmptyCart" runat="server" CssClass="empty-cart-message" Visible="False" /></center>

        <div class="order-now-button">
            <center><asp:Button ID="btnOrderNow" runat="server" CssClass="btn btn-success" Text="Order Now" OnClick="btnOrderNow_Click" /></center>
        </div>
    </form>
</body>
</html>
