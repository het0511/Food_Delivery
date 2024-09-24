<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Food_Delivery.pages.admin.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        .dashboard-container {
            width: 400px;
            margin: 100px auto;
            padding: 20px;
            background-color: white;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            text-align: center;
            position: relative;
        }

        h2 {
            color: #333;
        }

        .button {
            display: block;
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            text-decoration: none;
        }

        .button:hover {
            background-color: #0056b3;
        }

        .welcome-message {
            color: #555;
            margin-bottom: 20px;
        }

        /* Style for the logout button */
        .logout-button {
            position: absolute;
            top: 10px;
            right: 10px;
            padding: 5px 10px;
            background-color: #dc3545;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
        }

        .logout-button:hover {
            background-color: #c82333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-container">
            <!-- Logout Button -->
            <asp:Button ID="ButtonLogout" runat="server" Text="Logout" CssClass="logout-button" OnClick="ButtonLogout_Click" />

            <h2>Admin Dashboard</h2>
            <asp:Label ID="LabelWelcome" runat="server" CssClass="welcome-message"></asp:Label>
            
            <!-- View Users Button -->
            <asp:Button ID="ButtonViewUsers" runat="server" Text="View Users" CssClass="button" OnClick="ButtonViewUsers_Click" />

            <!-- View Restaurants Button -->
            <asp:Button ID="ButtonViewRestaurants" runat="server" Text="View Restaurants" CssClass="button" OnClick="ButtonViewRestaurants_Click" />

            <!-- View Food Items Button -->
            <asp:Button ID="ButtonViewFoodItems" runat="server" Text="View Food Items" CssClass="button" OnClick="ButtonViewFoodItems_Click" />
        </div>
    </form>
</body>
</html>
