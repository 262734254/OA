<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserListExcel.aspx.cs"
    Inherits="TelListExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <asp:Repeater ID="GridViewE" runat="server">
            <ItemTemplate>
                <tr>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_login") %>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_name")%>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_mobile")%>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_mail")%>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_idcard")%>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_jiao")%>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_bum")%>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_duty")%>
                    </td>
                    <td height="26" align="center" style="width: 9%">
                        <%#Eval("m_birth")%>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </form>
</body>
</html>
