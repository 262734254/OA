<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Tunnel_UserSearch.aspx.cs" Inherits="UserSearch_Tunnel_UserSearch" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content runat="server" ID="contetn1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF">
        <tr>
            <td align="center" class="tou" colspan="9" height="30">
                关键字：<asp:TextBox ID="TextBox1" runat="server" CssClass="inputtext"></asp:TextBox>&nbsp;<asp:Button
                    ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click" Text="搜索" />
            </td>
        </tr>
        <tr>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%">
                用户名
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 6%">
                真实姓名
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%">
                手机/电话号码
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 17%">
                邮件地址
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 9%">
                出生年月
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%">
                角色
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%">
                部门
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 6%">
                职务
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 6%">
                项经部
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 4%">
                状态
            </td>
        </tr>
        <asp:Repeater ID="GridViewE" runat="server">
            <ItemTemplate>
                <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                    onmouseout="this.style.backgroundColor='';this.style.color='';">
                    <td height="26" align="center" style="width: 8%">
                        <a href="tunnel_userinfo.aspx?id=<%#Eval("m_id") %>">
                            <%#Eval("m_login") %>
                        </a>
                    </td>
                    <td height="26" align="center" style="width: 6%">
                        &nbsp;<%#Eval("m_name")%>
                    </td>
                    <td height="26" align="center" style="width: 8%">
                        &nbsp;<%#Eval("m_mobile")%>
                    </td>
                    <td align="center" height="26" style="width: 18%">
                        <a href="/N_Exchange/N_ExternalMail/N_MailSend.aspx?mail=<%#rtunMail(Eval("m_mail").ToString())%>">
                            <%#Eval("m_mail") %>
                        </a>
                    </td>
                    <td height="26" align="center" style="width: 10%">
                        &nbsp;<%#Eval("m_birth","{0:D}").ToString() == "1800年1月1日"?"":Eval("m_birth","{0:yyyy-MM-dd}")%>
                    </td>
                    <td height="26" align="center" style="width: 8%">
                        &nbsp;<%#retJue( Eval("m_jiao"))%>
                    </td>
                    <td height="26" align="center" style="width: 10%">
                        &nbsp;<%#retBum( Eval("m_bum"))%>
                    </td>
                    <td height="26" align="center" style="width: 6%">
                        &nbsp;<%#retDuty( Eval("m_duty"))%>
                    </td>
                    <td height="26" align="center" style="width: 6%">
                        &nbsp;<%#retXJB( Eval("m_xjb"))%>
                    </td>
                    <td height="26" align="center" style="width: 4%">
                        &nbsp;<%#int.Parse(Eval("m_state").ToString())==1?"锁定":"开启"%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table style="width: 100%">
        <tr>
            <td align="right" style="width: 100%" class="di">
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr>
    </table>
</asp:Content>