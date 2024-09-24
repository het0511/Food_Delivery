<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRestaurant.aspx.cs" Inherits="Food_Delivery.pages.admin.EditRestaurant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Restaurant</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f4f6f9;
            padding-top: 50px;
        }
        .form-container {
            max-width: 600px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        .form-header {
            text-align: center;
            margin-bottom: 20px;
        }
        .btn-custom {
            background-color: #007bff;
            color: white;
            border-radius: 5px;
        }
        .btn-custom:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="form-header">
                <h2>Edit Restaurant</h2>
            </div>

            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" CssClass="alert alert-danger" Visible="false"></asp:Label>
            <asp:HiddenField ID="hfRestaurantId" runat="server" />

            <div class="form-group">
                <label for="txtName">Restaurant Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter restaurant name"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtLocation">Location</label>
                <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" Placeholder="Enter location"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtCuisineType">Cuisine Type</label>
                <asp:TextBox ID="txtCuisineType" runat="server" CssClass="form-control" Placeholder="Enter cuisine type"></asp:TextBox>
            </div>

            <div class="text-center">
                <asp:Button ID="btnUpdate" runat="server" Text="Update Restaurant" CssClass="btn btn-custom" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </form>

    <!-- Bootstrap JS and dependencies -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
