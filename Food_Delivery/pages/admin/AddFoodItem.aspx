<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFoodItem.aspx.cs" Inherits="Food_Delivery.pages.admin.AddFoodItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Food Item</title>
    <link href="../../styles/add_food_item.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Add New Food Item</h2>
            <div class="form-group">
                <label for="Name">Name:</label>
                <asp:TextBox ID="TextBoxName" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="Description">Description:</label>
                <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="Price">Price:</label>
                <asp:TextBox ID="TextBoxPrice" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="RestaurantId">Restaurant:</label>
                <asp:DropDownList ID="DropDownListRestaurants" runat="server" CssClass="form-control" />
            </div>
            <div class="form-actions">
                <asp:Button ID="ButtonAdd" runat="server" Text="Add Food Item" OnClick="ButtonAdd_Click" CssClass="button-submit" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Back" OnClick="ButtonCancel_Click" CssClass="button-cancel" />
            </div>
        </div>
    </form>
</body>
</html>
