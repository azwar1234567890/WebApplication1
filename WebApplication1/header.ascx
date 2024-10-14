<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="WebApplication1.header" %>
<table>
    <tr>
        <td><asp:Image ID="img" ImageUrl="~/NEW BANNER.jpg" Width="100%" runat="server" /></td>
    </tr>
</table>
<div id="menu">
		<ul class="menu">
			
			<li><a href="employee.aspx"><span>ADD EMPLOYEE</span></a></li>
			<li class="last"><a href="EmployeeDetails.aspx"><span>EMPLOYEE DETAILS</span></a></li>
		</ul>
	</div>
