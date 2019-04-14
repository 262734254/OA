<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Tunnel_JueseAdd.aspx.cs" Inherits="SystemManage_Tunnel_JueseAdd" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
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
    <table cellspacing="1" bordercolordark="#ffffff" cellpadding="0" width="100%" align="center"
        bordercolorlight="#c1c1c1" border="1">
        <tbody>
            <tr>
                <td style="height: 30px; background-color: #f6f6f6" align="right" height="25">
                    角色名称：
                </td>
                <td align="left" height="17" style="height: 30px; background-color: #f6f6f6">
                    <asp:TextBox ID="txtName" class="inputtext" runat="server" onkeyup="javascrip:checkWord(100,event,'lbl')"
                        Width="216px"></asp:TextBox>
                    <asp:Label ID="lbl" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/100"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" height="25">
                    责任描述：
                </td>
                <td align="left" height="17">
                    <asp:TextBox ID="txtfl" runat="server" Width="218px" TextMode="MultiLine" Height="132px"
                        onkeyup="javascrip:checkWord(2000,event,'lbl0')"></asp:TextBox>
                    <asp:Label ID="lbl0" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/2000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 31px" align="center" colspan="2" class="di">
                    <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="保存" CssClass="button">
                    </asp:Button>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
