<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="employee.aspx.cs" Inherits="WebApplication1.employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table>
        <tr>
            <td><label for="txtname">Name:</label></td>
            <td><asp:TextBox runat="server" ID="txtname"></asp:TextBox></td>
        </tr>
        <tr>
            <td><label for="rbl">Gender:</label></td>
            <td>
                <asp:RadioButtonList ID="rbl" runat="server" RepeatColumns="3" style="text-align:center"></asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td><label for="ddl">Designation:</label></td>
            <td><asp:DropDownList ID="ddl" runat="server" style="text-align:center"></asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
     <style>
        table {
            width: 100%;
            margin: 20px auto;
            border-collapse: collapse;
            font-family: Arial, sans-serif;
        }
        td {
            padding: 10px;
            border: 1px solid #ccc;
            vertical-align: middle;
        }
        tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        tr:hover {
            background-color: #f1f1f1;
        }
        input[type="text"],
        select,
        input[type="submit"] {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 3px;
        }
        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #45a049;
        }
        label {
            margin-right: 10px;
        }
    </style>

</asp:Content>
