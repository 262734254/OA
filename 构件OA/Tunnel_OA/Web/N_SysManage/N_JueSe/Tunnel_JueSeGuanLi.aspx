<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_JueSeGuanLi.aspx.cs"
    Inherits="SystemManage_Tunnel_JueSeGuanLi" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:content runat="server" id="content1" contentplaceholderid="Header">
</asp:content>
<asp:content runat="server" id="content2" contentplaceholderid="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../../javascript/IframeReSize.js" type="text/javascript"></script>
    <title>用户管理</title>

        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_JueseAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增角色</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_JueSeGuanLi.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理角色</div>
                </a>
            </td>
            <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_JueseSort.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        角色排序</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF">
            <tr>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 25%">
                    角色名称
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 25%">
                    责任描述
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 25%">
                    权限设置
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 25%">
                    操作
                </td>
            </tr>
            <asp:Repeater ID="GridView1" runat="server">
                <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                        onmouseout="this.style.backgroundColor='';this.style.color='';" align="center">
                        <td height="26"  style="width: 25%" align="center">
                        <%#Eval("j_name")%>
                        </td>
                        <td height="26" align="center" style="width: 25%">
                            &nbsp;<%#Eval("j_flag")%>
                        </td>
                        <td height="26" align="center" style="width: 25%">
                            &nbsp;<a href="../../N_Permission/Permission.aspx?jid=<%#Eval("j_id") %>">权限设置</a>
                        </td>
                        <td height="26"  style="width: 25%" align="center">
                            <%#showhd(Eval("j_name"),Eval("j_id")) %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td align="right" class="di" colspan=4>
                    <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                        <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                    </cc1:MTCPager>
                </td>
            </tr>
        </table>
</asp:content>
