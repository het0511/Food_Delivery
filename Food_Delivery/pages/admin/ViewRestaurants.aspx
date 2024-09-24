<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRestaurants.aspx.cs" Inherits="Food_Delivery.pages.admin.ViewRestaurants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Restaurants</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
        }

        .container {
            width: 800px;
            margin: 50px auto;
            background-color: white;
            padding: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        h2 {
            text-align: center;
            color: #007bff;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        table, th, td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        th {
            background-color: #007bff;
            color: white;
        }

        td {
            text-align: center;
        }

        .button-delete, .button-edit {
            background-color: #dc3545;
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 5px;
            cursor: pointer;
        }

        .button-edit {
            background-color: #007bff;
        }

        .button-delete:hover {
            background-color: #c82333;
        }

        .button-edit:hover {
            background-color: #0056b3;
        }

        .button-add, .button-dashboard {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 5px;
            cursor: pointer;
            margin-right: 10px;
            margin-top: 20px;
        }

        .button-dashboard {
            background-color: #6c757d;
        }

        .button-add:hover {
            background-color: #218838;
        }

        .button-dashboard:hover {
            background-color: #5a6268;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Registered Restaurants</h2>

            <asp:GridView ID="GridViewRestaurants" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewRestaurants_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="CuisineType" HeaderText="Cuisine Type" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <!-- Edit Button -->
                            <asp:Button ID="ButtonEdit" runat="server" Text="Edit" CommandName="EditRestaurant" CommandArgument='<%# Eval("RestaurantId") %>' CssClass="button-edit" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <!-- Delete Button -->
                            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CommandName="DeleteRestaurant" CommandArgument='<%# Eval("RestaurantId") %>' CssClass="button-delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div class="button-container">
                <!-- Button to add a new restaurant -->
                <asp:Button ID="ButtonAddRestaurant" runat="server" Text="Add Restaurant" OnClick="ButtonAddRestaurant_Click" CssClass="button-add" />
                
                <!-- Button to go back to the dashboard -->
                <asp:Button ID="ButtonBackToDashboard" runat="server" Text="Back to Dashboard" OnClick="ButtonBackToDashboard_Click" CssClass="button-dashboard" />
            </div>
        </div>
    </form>
</body>
</html>
