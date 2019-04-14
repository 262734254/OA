<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_Permission.aspx.cs" Inherits="Default_Permission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>设置默认权限</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="设置默认权限" />
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" 
            DataTextField="q_name" DataValueField="q_id" Height="485px" 
            SelectionMode="Multiple" Width="152px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>" 
            SelectCommand="SELECT [q_id], [q_name]+'<<'+[q_mark] as q_name FROM [Tunnel_quanxian] ORDER BY [q_mark]">
        </asp:SqlDataSource>
       
    </div>
    </form>
</body>
</html>
