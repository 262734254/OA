<%@ Page Language="C#" AutoEventWireup="true" CodeFile="N_TelList.aspx.cs" Inherits="TelList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>通讯录</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 569px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
    <div align="center">
        <table width="55%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF">
            <tr>
                <td align="left" colspan="4" height="30">
                    &nbsp;通讯录--查询
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" height="30">
                    关键字：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="Button1"
                        runat="server" CssClass="button" OnClick="Button1_Click" Text="搜索" />
                </td>
            </tr>
            <tr>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 9%">
                    <strong>用户名</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 9%">
                    <strong>姓名</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 9%">
                    <strong>手机/电话号码</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 9%">
                    <strong>邮件地址</strong>
                </td>
            </tr>
            <asp:Repeater ID="GridViewE" runat="server">
                <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#F2F2F2'" onmouseout="this.style.backgroundColor='';this.style.color='';">
                        <td height="26" align="center" style="width: 9%">
                            <%--<a href="SystemManage/tunnel_userinfo.aspx?id=<%#Eval("m_id") %>" target="_blank">--%>
                            &nbsp;<%#Eval("m_login") %>
                            <%--    </a>--%>
                        </td>
                        <td height="26" align="center" style="width: 9%">
                            &nbsp;<%#Eval("m_name")%>
                        </td>
                        <td height="26" align="center" style="width: 9%">
                            &nbsp;<%#Eval("m_mobile")%>
                        </td>
                        <td align="center" height="26" style="width: 9%">
                            <%--<a href="../grzm/SendEmail.aspx?mail=<%#rtunMail(Eval("m_mail").ToString())%>">--%>
                            &nbsp;<%#Eval("m_mail") %>
                            <%--</a>--%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table>
            <tr>
                <td align="right" class="style1">
                    <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged"
                        Visible="False">
                        <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                    </cc1:MTCPager>
                </td>
            </tr>
        </table>
        <br />
        <a href="N_TelListExcel.aspx" target="_blank" style="color: Red">下载Excel文档格式通讯录</a></div>
    </form>
</body>
</html>
