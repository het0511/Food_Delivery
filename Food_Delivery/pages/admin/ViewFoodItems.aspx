<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFoodItems.aspx.cs" Inherits="Food_Delivery.pages.admin.ViewFoodItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Food Items</title>
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

        table {
            width: 100%;
            border-collapse: collapse;
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

        .button-add, .button-back {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            margin: 10px;
        }

        .button-add {
            background-color: #007bff;
        }

        .button-back {
            background-color: #6c757d;
        }

        .button-add:hover {
            background-color: #0056b3;
        }

        .button-back:hover {
            background-color: #5a6268;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Food Items</h2>
            <asp:GridView ID="GridViewFoodItems" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewFoodItems_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Restaurant">
                        <ItemTemplate>
                            <%# Eval("RestaurantId") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <!-- Edit Button -->
                            <asp:Button ID="ButtonEdit" runat="server" Text="Edit" CommandName="EditFoodItem" CommandArgument='<%# Eval("FoodItemId") %>' CssClass="button-edit" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <!-- Delete Button -->
                            <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CommandName="DeleteFoodItem" CommandArgument='<%# Eval("FoodItemId") %>' CssClass="button-delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="text-align: center;">
                <!-- Add Food Item Button -->
                <asp:Button ID="ButtonAddFoodItem" runat="server" Text="Add Food Item" OnClick="ButtonAddFoodItem_Click" CssClass="button-add" />
                
                <!-- Back to Dashboard Button -->
                <asp:Button ID="ButtonBackToDashboard" runat="server" Text="Back to Dashboard" OnClick="ButtonBackToDashboard_Click" CssClass="button-back" />
            </div>
        </div>
    </form>
</body>
</html>
