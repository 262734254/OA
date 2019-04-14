<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_DutyInfo.aspx.cs"
    Inherits="SystemManage_Tunnel_DutyInfo" %>

<asp:content runat="server" id="content1" contentplaceholderid="Header">
</asp:content>
<asp:content runat="server" id="content2" contentplaceholderid="ContentPlaceHolder1">

    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 30px;
            width: 219px;
        }
        .style2
        {
            width: 219px;
        }
    </style>

        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_DutyAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                       新增职务</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_DutyList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        职务管理</div>
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
                <td height="25" align="right" style="background-color: #f6f6f6" class="style1">
                    职务名称：
                </td>
                <td height="17" align="left"  style="height: 30px; background-color: #f6f6f6">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" class="style2">
                    描述：
                </td>
                <td align="left" height="17">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25" style="background-color: #f6f6f6" class="style1">
                    部门：
                </td>
                <td align="left" height="17"  style="height: 30px; background-color: #f6f6f6">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 31px" class=di>
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="返回" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
</asp:content>
