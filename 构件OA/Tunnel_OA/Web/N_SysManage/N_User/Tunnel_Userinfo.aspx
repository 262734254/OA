<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_Userinfo.aspx.cs"
    Inherits="SystemManage_Tunnel_Userinfo" %>

<asp:content runat="server" id="contetn1" contentplaceholderid="Header"></asp:content>
<asp:content runat="server" id="Content1" contentplaceholderid="ContentPlaceHolder1">

    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 309px;
        }
    </style>

        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_UserAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新增用户</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_UserList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理用户</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF">
            <tr>
                <td height="25" align="right" style="background-color: #f6f6f6" class="style1" >
                    账号：
                </td>
                <td height="17" align="left"  style="background-color: #f6f6f6">
                    <asp:Label ID="txtUserName" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1"  >
                    真实姓名：
                </td>
                <td align="left" height="17" >
                    <asp:Label ID="txtName" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1"    style="background-color: #f6f6f6">
                    手机/电话号码：
                </td>
                <td align="left" height="17"  style="background-color: #f6f6f6">
                    <asp:Label ID="txtTel" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1" >
                    身份证：
                </td>
                <td align="left" height="17">
                    <asp:Label ID="txtIdKard" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="background-color: #f6f6f6" class="style1" >
                    出生年月：
                </td>
                <td align="left" style="height: 30px"  style="background-color: #f6f6f6">
                    <asp:Label ID="txtBirth" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1"  >
                    角色：
                </td>
                <td align="left" height="17">
                    <asp:Label ID="txtjuese" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="background-color: #f6f6f6" class="style1" >
                    部门：
                </td>
                <td align="left" height="17" style="background-color: #f6f6f6">
                    <asp:Label ID="txtbumen" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1"  >
                    职务：
                </td>
                <td align="left" height="17">
                    <asp:Label ID="txtZhiwu" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1"  >
                    项经部：
                </td>
                <td align="left" height="17">
                    <asp:Label ID="txtXJB" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1"  >
                    科室：
                </td>
                <td align="left" height="17">
                    <asp:Label ID="lblKS" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="background-color: #f6f6f6" class="style1" >
                    用户状态：
                </td>
                <td align="left" height="17"  style="background-color: #f6f6f6">
                    <asp:Label ID="txtState" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style1" >
                    邮箱：
                </td>
                <td align="left" height="17">
                
                    <asp:Label ID="txtMail" runat="server"  ReadOnly="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 31px" class="di">
                    <input id="Button1" class="button" type="button" value="返回" onclick="window.history.back();" />
                </td>
            </tr>
        </table>
</asp:content>
