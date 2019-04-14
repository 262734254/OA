<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_SQLCopy.aspx.cs" Inherits="SystemManage_Tunnel_SQLCopy" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header"></asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <style type="text/css">
        .style1
        {
            width: 33%;
        }
        .style2
        {
            width: 110px;
        }
    </style>
        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="Tunnel_SQLCopy.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        数据备份</div>
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
                <td align="center" colspan="1" class="style1">
                    <asp:ListBox ID="ListBox1" runat="server" Rows="10" SelectionMode="Multiple" Width="270px">
                    </asp:ListBox>
                </td>
                <td align="center"  rowspan="2">
                    <asp:Button ID="Button4" runat="server" Text="---->>" CssClass="button" OnClick="Button4_Click" /><br />
                    <asp:Button ID="Button3" runat="server" Text="<<----" CssClass="button" OnClick="Button3_Click" />
                </td>
                <td align="center" class="style1">
                    &nbsp;<asp:ListBox ID="ListBox2" runat="server" Rows="10" SelectionMode="Multiple"
                        Width="273px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="1" style="height: 31px;background-color: #e6f7ff">
                    <asp:Button ID="Button1" runat="server" Text="备份" CssClass="button" OnClick="Button1_Click1" />&nbsp;
                    <asp:Button ID="Button5" runat="server" Text="删除备份" CssClass="button" OnClick="Button5_Click" OnClientClick="return confirm('是否删除此条记录？')" />
                </td>
                <td align="center" style="height: 31px;background-color: #e6f7ff">
                    <asp:Button ID="Button2" runat="server" Text="打包下载" CssClass="button" OnClick="Button2_Click1" />
                </td>
            </tr>
        </table>
</asp:Content>


