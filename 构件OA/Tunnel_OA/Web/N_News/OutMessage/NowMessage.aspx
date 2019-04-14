<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NowMessage.aspx.cs" Inherits="N_News_OutMessage_NowMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>外出留言</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
        <div align="center">
            <table width="55%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
                bordercolordark="#FFFFFF">
                <tr>
                    <td align="left"   colspan="3" height="30">
                        &nbsp;外出留言--查询
                    </td>
                </tr>
                <tr>
                    <td align="center"   colspan="3" height="30">
                                                关键字：<asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>&nbsp;<asp:Button
                            ID="Button1" runat="server" Height="23px" CssClass="button" OnClick="Button1_Click" Text="搜索" /></td>
                </tr>
                <tr>
                    <td height="30" align="center" bgcolor="#f6f6f6" style="width: 15%">
                        <strong>姓名</strong></td>
                    <td height="30" align="center" bgcolor="#f6f6f6" style="width: 20%">
                        <strong>留言时间</strong></td>
                    <td height="30" align="center" bgcolor="#f6f6f6">
                        <strong>内容</strong></td>
                </tr>
                
                <asp:Repeater ID="GridViewE" runat="server">
                <ItemTemplate>
                                <tr onmouseover="this.style.backgroundColor='#F2F2F2'"
                                    onmouseout="this.style.backgroundColor='';this.style.color='';">                                    
                                        <td height="26" align="center">&nbsp;
                                        <%--<a href="SystemManage/tunnel_userinfo.aspx?id=<%#Eval("m_id") %>" target="_blank">--%>
                                            <%#GetUserName(Eval("MesUser").ToString())%>
                                    <%--    </a>--%>
                                    </td>
                                    <td height="26" align="center">
                                        &nbsp;<%#Eval("MesDate")%></td>
                                    <td height="26" align="left">
                                        &nbsp;<%#Eval("MesContent")%></td>
    
                                </tr>
                            </ItemTemplate>
                </asp:Repeater>  
                <tr><td colspan="3" height="30"><a href="OldMessage.aspx">查看历史外出留言记录</a></td></tr>             
            </table>
            </div>
    </form>
</body>
</html>

