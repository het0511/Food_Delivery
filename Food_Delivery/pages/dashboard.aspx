<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Food_Delivery.dashboard" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Dashboard</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../images/site.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .header {
            padding: 10px;
            background-color: rgba(255, 255, 255, 0.8); /* White with 80% opacity */
            box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.1);
            text-align: right;
            font-family: 'Arial Black', sans-serif; /* Beautiful font */
        }
        .restaurant-list {
            margin: 20px;
        }
        .table-striped {
            background-color: rgba(255, 255, 255, 0.8); /* White with 80% opacity */
        }
        .view-cart {
            text-align: center;
            margin: 20px;
        }
        .view-menu-button, .view-cart-button, .logout-button {
            margin: 5px;
        }
        .welcome-message {
            font-size: 18px;
            font-weight: bold;
            margin-right: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <asp:Label ID="lblWelcomeMessage" runat="server" CssClass="welcome-message"></asp:Label>
            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger logout-button" Text="Log Out" OnClick="btnLogout_Click" />
        </div>

        <div class="restaurant-list">
            <asp:GridView ID="RestaurantGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Restaurant Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="CuisineType" HeaderText="Cuisine Type" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnViewMenu" runat="server" Text="View Menu" CommandArgument='<%# Eval("RestaurantId") %>' OnClick="btnViewMenu_Click" CssClass="btn btn-primary view-menu-button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="view-cart">
            <asp:Button ID="btnViewCart" runat="server" CssClass="btn btn-success view-cart-button" Text="View Cart" OnClick="btnViewCart_Click" />
        </div>
    </form>
</body>
</html>
