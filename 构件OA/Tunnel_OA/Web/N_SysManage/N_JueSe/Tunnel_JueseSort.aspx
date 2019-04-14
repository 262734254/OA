<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Tunnel_JueseSort.aspx.cs" Inherits="N_SysManage_N_JueSe_Tunnel_JueseSort" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:content runat="server" id="content1" contentplaceholderid="Header">
</asp:content>
<asp:content runat="server" id="content2" contentplaceholderid="ContentPlaceHolder1">
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../../javascript/IframeReSize.js" type="text/javascript"></script>
    <title>角色管理</title>

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
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_JueSeGuanLi.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理角色</div>
                </a>
            </td>
            <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
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
    <table border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF" style="text-align:center">
        <tr>
            <td colspan="2" height="2"></td>
        </tr>
        <tr>
            <td>
                角色排序
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="保存"  CssClass="button" onclick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td rowspan="10">
                <asp:ListBox ID="lbxJS" runat="server" Height="355px" Width="250px"></asp:ListBox>
            </td>
            <td valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="btnFirst" runat="server" Text="首"  CssClass="button" Width="26px"  onclick="btnFirst_Click" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="Button1" runat="server" Text="上" CssClass="button" Width="26px" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="Button4" runat="server" Text="下"  CssClass="button" Width="26px" onclick="Button4_Click" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Button ID="Button5" runat="server" Text="尾" CssClass="button" 
                    onclick="Button5_Click" Width="26px" />
            </td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td  valign="middle">
                &nbsp;</td>
        </tr>
    </table>
</asp:content>
