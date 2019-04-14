<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OldMessage.aspx.cs" Inherits="N_News_OutMessage_NowMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>外出留言</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />        
    <script src="../../javascript/Calendarform.js" type="text/javascript"></script>
        <script src="../../javascript/utility.js" type="text/javascript"></script>
    </head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
        <div align="center">
            <table width="55%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
                bordercolordark="#FFFFFF">
                <tr>
                    <td align="left"   colspan="3" height="30">
                        &nbsp;外出留言--查询<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
ControlToValidate="TextBox2" ErrorMessage="开始日期格式不正确。" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="TextBox3" ErrorMessage="结束日期格式不正确。" 
                                
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" height="30">
                    日期：<asp:TextBox ID="TextBox2" runat="server" Width="84px"
onpaste= "return false "></asp:TextBox><img style="cursor:pointer" onclick="td_calendar(this,'TextBox2')" src="../../image/icon5.gif" />&nbsp;
－<asp:TextBox ID="TextBox3" runat="server" Width="84px" onpaste= "return false "></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'TextBox3')"/>关键字：<asp:TextBox ID="TextBox1" runat="server"  ></asp:TextBox>&nbsp;<asp:Button
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
                <tr><td colspan="3" height="30"><a href="NowMessage.aspx">查看今天外出留言记录</a></td></tr>             
            </table>
            </div>
    </form>
</body>
</html>

