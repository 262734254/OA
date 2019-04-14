<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="CalendarInfo.aspx.cs" Inherits="N_Calendar_CalendarInfo" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Default.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        日程提示</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="CalendarAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新建日程</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="1" width="100%" bordercolorlight="#c1c1c1"
        bordercolordark="#FFFFFF">
        <tr bgcolor="#f6f6f6" height="30px">
            <td class="style1" align="right">
                标题：
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr height="30px">
            <td class="style1" align="right">
                待办时间：
            </td>
            <td>
                &nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr bgcolor="#f6f6f6" height="30px">
            <td class="style1" align="right">
                是否提醒：
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr height="30px">
            <td class="style1" align="right">
                内容：
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr class="di" height="30px">
            <td class="style1">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="返回" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
