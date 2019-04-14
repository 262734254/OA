<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_ArchivesView.aspx.cs" Inherits="profile_ProfileInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>无标题页</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
<table width="100%"  border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-top:1px #6f97b1 solid">
                <tr>
                    <td align="left" colspan="2" height="30"  >
                        &nbsp;档案浏览
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#f6f6f6" height="25" align="right" style="height: 30px;">
                        <strong>档案名称：</strong></td>
                    <td bgcolor="#f6f6f6" height="17" align="left">
                        <asp:Label ID="Label1" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td bgcolor="" height="25" align="right" style="height: 30px;">
                        <strong>年份：</strong></td>
                    <td bgcolor="" height="17" align="left">
                        <asp:Label ID="Label2" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td bgcolor="#f6f6f6" align="right" height="25" style="height: 30px;">
                        <strong>部门：</strong></td>
                    <td bgcolor="#f6f6f6" align="left" height="17">
                        <asp:Label ID="Label3" runat="server"></asp:Label></td>
                </tr>
                                <tr>
                    <td bgcolor="" align="right" height="25" style="height: 30px">
                        <strong>文件类型：</strong></td>
                    <td bgcolor="" align="left" height="17">
                        <asp:Label ID="Label4" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td bgcolor="#e6f7ff" colspan="2" align="center" style="height: 31px">
                        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="返回" OnClick="btnSave_Click"  /></td>
                </tr>
            </table>
        </div>
</asp:Content>
