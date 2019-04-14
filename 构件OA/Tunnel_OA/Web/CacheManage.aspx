<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CacheManage.aspx.cs" Inherits="CacheManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Cache管理器
        <br />
        <br />
        <br />
        <a href="?id=all">移除所有在线人员</a>
        <br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server">刷新</asp:HyperLink>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <table class="style1" align="center">
            <tr align="center" width=100% style="background:LightSkyBlue">
                <td width=10%>
                    login
                </td>
                <td width=10%>
                    password
                </td>
                <td width=20%>
                    姓名
                </td>
                <td width=25%>
                    键
                </td>
                <td width=25%>
                    类型
                </td>
                <td width=10%>
                    操作
                </td>
            </tr>
        </table>
        <table class="style1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  class="style1" ShowHeader="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                                onmouseout="this.style.backgroundColor='';this.style.color='';" align="center" width=100%>
                                <td width=10%>
                                    <%#ShowName(Eval("CacheKey"),1) %>
                                </td>
                                <td width=10%>
                                   <%#ShowName(Eval("CacheKey"),3) %>
                                </td>
                                <td width=20%>
                                    <%#ShowName(Eval("CacheKey"),2) %>
                                </td>
                                <td width=25%>
                                    <%#Eval("CacheKey") %>
                                </td>
                                <td width=25%>
                                    <%#Eval("CacheType") %>
                                </td>
                                <td width=10%>
                                    <a href="?id=<%#Eval("CacheKey") %>">移除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </table>
    </div>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="m_login" HeaderText="m_login" 
                SortExpression="m_login" />
            <asp:TemplateField HeaderText="m_password" SortExpression="m_password">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text=' <%#Tunnel.Data.DESEncrypt.Decrypt(Eval("m_password").ToString()) %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("m_password") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="m_name" HeaderText="m_name" 
                SortExpression="m_name" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>" 
        SelectCommand="SELECT [m_login], [m_password], [m_name] FROM [Tunnel_menber]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
