<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tunnel_UserList.aspx.cs"
    MasterPageFile="~/MasterPage.master" Inherits="SystemManage_Tunnel_UserList" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content runat="server" ID="contetn1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../../javascript/IframeReSize.js" type="text/javascript"></script>

    <script>
        function ifCheck(obj) {
            if ($(#obj).hide() == true) {
                $(#obj).show();
            } else {
                $(#obj).hide()
            }
        }
    </script>

    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="Tunnel_UserAdd.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增用户</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="Tunnel_UserList.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理用户</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
        style="border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr bgcolor="#f6f6f6">
            <td colspan="12" height="30" align="left">
                &nbsp;关键字：
                <asp:TextBox ID="TextBox1" runat="server" CssClass="inputtext"></asp:TextBox>
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                    Text="搜索" />
            </td>
        </tr>
        <tr>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%" id="yhm">
                <b>用户名</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%" id="xm">
                <b>姓名</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%" id="sj">
                <b>手机/电话号码</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%" id="yjdz">
                <b>邮件地址</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%" id="csny">
                <b>出生年月</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 10%" id="js">
                <b>角色</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%" id="bm">
                <b>部门</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%" id="zw">
                <b>职务</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%" id="Td1">
                <b>项经部</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%" id="zt">
                <b>状态</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%" id="qx">
                <b>权限设置</b>
            </td>
            <td height="30" align="center" bgcolor="#f6f6f6" style="width: 8%" id="cz">
                <b>操作</b>
            </td>
        </tr>
        <asp:Repeater ID="GridView1" runat="server">
            <ItemTemplate>
                <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                    onmouseout="this.style.backgroundColor='';this.style.color='';">
                    <td height="30" align="center" style="width: 8%" bgcolor="#ffffff" id="yhm">
                        <a href="tunnel_userinfo.aspx?id=<%#Eval("m_id") %>">
                            <%#Eval("m_login") %>
                        </a>
                    </td>
                    <td height="30" align="center" style="width: 8%" bgcolor="#ffffff" id="xm">
                        &nbsp;<%#Eval("m_name")%>
                    </td>
                    <td height="30" align="center" style="width: 10%" bgcolor="#ffffff" id="sj">
                        &nbsp;<%#Eval("m_mobile")%>
                    </td>
                    <td align="center" height="30" style="width: 10%" bgcolor="#ffffff" id="yjdz">
                        <a href="../../N_Exchange/N_ExternalMail/N_MailSend.aspx?mail=<%#rtunMail(Eval("m_mail").ToString())%>">
                            <%#Eval("m_mail") %>
                        </a>
                    </td>
                    <td height="30" align="center" style="width: 10%" bgcolor="#ffffff" id="csny">
                        &nbsp;<%#Eval("m_birth", "{0:yyyy-MM-dd}").ToString() == "1800-01-01" ? "" : Eval("m_birth", "{0:yyyy-MM-dd}")%>
                    </td>
                    <td height="30" align="center" style="width: 10%" bgcolor="#ffffff" id="js">
                        &nbsp;<%#retJue( Eval("m_jiao"))%>
                    </td>
                    <td height="30" align="center" style="width: 8%" bgcolor="#ffffff" title='<%#retBum( Eval("m_bum")) %>'
                        id="bm">
                        &nbsp;<%#retBum(Eval("m_bum")).ToString().Length > 4 ? retBum(Eval("m_bum")).Substring(0, 2)+"..": retBum(Eval("m_bum"))%>
                    </td>
                    <td height="30" align="center" style="width: 8%" bgcolor="#ffffff" id="zw">
                        &nbsp;<%#retDuty( Eval("m_duty"))%>
                    </td>
                    <td height="30" align="center" style="width: 8%" bgcolor="#ffffff" id="xjb">
                        &nbsp;<%#retXJB( Eval("m_xjb"))%>
                    </td>
                    <td height="30" align="center" style="width: 8%" bgcolor="#ffffff" id="zt">
                        &nbsp;<%#int.Parse(Eval("m_state").ToString())==1?"锁定":"开启"%>
                    </td>
                    <td height="30" align="center" style="width: 8%" bgcolor="#ffffff" id="qx">
                        <a href="../../N_Permission/Permission.aspx?uid=<%#Eval("m_id")%>">权限设置</a>
                    </td>
                    <td height="30" align="center" style="width: 10%" bgcolor="#ffffff" id="cz">
                        <asp:Panel runat="server" ID="czId">
                            <a href="Tunnel_UserUpd.aspx?updid=<%#Eval("m_id") %>">[改]</a> <a href="?delid=<%#Eval("m_id") %>"
                                onclick="return confirm('是否删除此条记录？')">[删]</a></asp:Panel>
                        <asp:Panel runat="server" ID="UNczId" Visible="false">
                            不可操作</asp:Panel>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC"
        style="border: 1px #6f97b1 solid; border-top: none">
        <tr height="30">
            <td align="right" style="width: 100%" class="di">
                &nbsp;
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr>
    </table>
</asp:Content>
