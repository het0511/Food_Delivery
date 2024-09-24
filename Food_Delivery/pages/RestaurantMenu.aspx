<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurantMenu.aspx.cs" Inherits="Food_Delivery.RestaurantMenu" %> 

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>Restaurant Menu</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../images/site.css" rel="stylesheet" type="text/css" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .header {
            padding: 10px;
            box-shadow: 0px 2px 5px rgba(0, 0, 0, 0.1);
            background-color: rgba(255, 255, 255, 0.8); /* White with 80% opacity */
            text-align: center;
            margin-bottom: 20px;
            font-family: 'Arial Black', sans-serif; /* Beautiful font */
        }
        .table-striped {
            background-color: rgba(255, 255, 255, 0.8); /* White with 80% opacity */
        }
        .menu-list {
            margin: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h2>Menu for <asp:Label ID="lblRestaurantName" runat="server" /></h2>
        </div>

        <div class="menu-list">
            <asp:GridView ID="FoodItemGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Food Item" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnAddToCart" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("FoodItemId") %>' OnClick="btnAddToCart_Click" CssClass="btn btn-success" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
