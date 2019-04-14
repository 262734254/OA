<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="N_Search_Search" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

 
    <title></title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-top: 1px #6f97b1 solid;border-bottom: 1px #6f97b1 solid;
        border-left: 1px #6f97b1 solid;border-right: 1px #6f97b1 solid">
        <tr>
            <td bgcolor="#f6f6f6">
                <table width="100%" border="0" cellspacing="0" cellpadding="3">
                    <tr>
                        <td width="20px">
                            &nbsp;
                        </td>
                        <td width="100px">
                            选择搜索类别：
                        </td>
                        <td width="100px">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td width="80px">
                            搜索关键字：
                        </td>
                        <td width="160px">
                            <label>
                                <asp:TextBox ID="text1" runat="server" MaxLength="50" />
                            </label>
                        </td>
                        <td>
                            <asp:ImageButton ImageUrl="../images/search.gif" runat="server" OnClick="Unnamed1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="display:none" id="imgview" runat="server" name="imgview">
    <table width="100%" border="0" cellpadding="0" cellspacing="1"
        style="border-collapse:collapse;border-left: 1px #6f97b1 solid;">
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <div style="text-align: center">
                            <table style="border-collapse:collapse;">
                                <tr>
                                    <td colspan="2">
                                        &nbsp;&nbsp;<a href="../N_News/N_Picture/N_PictureView.aspx?id=<%#Eval("id") %> "
                                            title='<%#Eval("title") %>'>
                                            <img src="../N_News/N_Picture/image/_<%#Eval("i_uri") %> " border="0" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <font color="black">
                                            <%#Eval("title").ToString().Length > 10 ? Eval("title").ToString().Substring(0, 8) + "..." : Eval("title").ToString()%></font>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    </div>
    <div runat="server" id="tableview" name="tableview">
    <table  width="100%" border="0" cellpadding="0" cellspacing="1"
        bgcolor="#CCCCCC" style="border-collapse:collapse;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
            <td height="30" align="center" bgcolor="#f6f6f6">
                <strong>标题</strong>
            </td>
            <td width="110" align="center" bgcolor="#f6f6f6">
                <strong>发布时间</strong>
            </td>
            <td width="60" align="center" bgcolor="#f6f6f6">
                发布人
            </td>
            <td width="60" align="center" bgcolor="#f6f6f6">
                类型
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td height="30" align="left" bgcolor="#FFFFFF">
                        <%# TitleHerfUrl(Convert.ToInt32(Eval("id")),Eval("title").ToString()) %>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        <%# Eval("setdate")%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        <%#ShowUserName(Eval("userId").ToString())%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        <%#DropDownList1.SelectedItem.Text.ToString()%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
        <table  width="100%" border="0" cellpadding="0" cellspacing="1"
        bgcolor="#CCCCCC" style="border-collapse:collapse;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
            <td height="30" colspan="6" align="center" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr></table>
    </div>
</asp:Content>

