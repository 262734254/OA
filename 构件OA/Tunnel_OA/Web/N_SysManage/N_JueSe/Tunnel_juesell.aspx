<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_juesell.aspx.cs" Inherits="SystemManage_Tunnel_juesell" %>

<asp:content runat="server" id="content1" contentplaceholderid="Header">
</asp:content>
<asp:content runat="server" id="content2" contentplaceholderid="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

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
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border="1" align="center" cellpadding="0" cellspacing="1" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF">
            <tr>
                <td height="25" align="right" style="height: 30px; background-color: #f6f6f6">
                    角色名称：
                </td>
                <td height="17" align="left" style="height: 30px; background-color: #f6f6f6">
                    
                    <asp:Label ID="txtName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    责任描述：
                </td>
                <td height="17" align="left">
                    &nbsp;<asp:TextBox ID="txtfl" runat="server" Height="159px" TextMode="MultiLine"
                        Width="234px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 31px" class="di">
                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="返回" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
</asp:content>
