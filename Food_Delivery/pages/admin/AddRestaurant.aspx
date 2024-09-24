<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRestaurant.aspx.cs" Inherits="Food_Delivery.pages.admin.AddRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Restaurant</title>
    <link href="../../styles/add_restaurant.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Add New Restaurant</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="msg"></asp:Label>

            <div class="form-group">
                <label for="txtName">Restaurant Name:</label>
                <asp:TextBox ID="txtName" runat="server" placeholder="Enter restaurant name"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtLocation">Location:</label>
                <asp:TextBox ID="txtLocation" runat="server" placeholder="Enter restaurant location"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtCuisineType">Cuisine Type:</label>
                <asp:TextBox ID="txtCuisineType" runat="server" placeholder="Enter cuisine type"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnAdd" runat="server" Text="Add Restaurant" CssClass="btn" OnClick="btnAdd_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-cancel" OnClick="btnCancel_Click" />
            </div>
        </div>
    </form>
</body>
</html>
