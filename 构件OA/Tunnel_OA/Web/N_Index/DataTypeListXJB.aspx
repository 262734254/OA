<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DataTypeListXJB.aspx.cs" Inherits="N_Index_DataTypeList2" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <title></title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/group.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-collapse:collapse;">
        <tr>
            <td height="28" valign="bottom">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-bottom: 0px #6f97b1 solid;
                    border-right: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-top: 1px #6f97b1 solid;
                    height: 30px">
                    <tr>
                        <td style="width: 400px" align="right" bgcolor="#f6f6f6">
                            标题关键字：&nbsp;<asp:TextBox ID="TextBox1" Width="300" runat="server"></asp:TextBox>
                        </td>
                        <td align="left" bgcolor="#f6f6f6">
                            &nbsp;<asp:Button ID="BtnSearch" runat="server" CssClass="searchbutton" OnClick="BtnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="border: 0px">
            <td align="center" valign="top" bgcolor="#FAFAFA">
                <asp:Menu ID="Menu1" runat="server" BackColor="#F7F6F3" 
                    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#7C6F57" StaticSubMenuIndent="10px">
                    <StaticSelectedStyle BackColor="#5D7B9D" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#F7F6F3" />
                    <DynamicSelectedStyle BackColor="#5D7B9D" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
                    
                </asp:Menu>
                <table width="100%" border="1" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC"
                    bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" style="border-collapse:collapse;border-left: 1px #6f97b1 solid;
                    border-right: 1px #6f97b1 solid; border-bottom: 1px #6f97b1 solid; border-top: 1px #6f97b1 solid">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#FFFFFF">
                                <td style="border-left:0px;border-top:0px;width:" bgcolor="#FFFFFF" height="27" align="left">
                                    &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;<a href="ViewXJB.aspx?Id=<%#Eval("i_id")%>&TypeId=<% =TypeId %>&bum_id=<%=Request.QueryString["bum_id"].ToString()%>&sectype=<%#Eval("sectype") %>"><%#title(Eval("i_title"),100)%></a>
                                </td>
                                <td style="border-right:0px;border-top:0px;" bgcolor="#FFFFFF" width="80">
                                    <%#FormatDate(Eval("i_time").ToString())%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#FFFFFF">
                                <td style="border-left:0px;border-top:0px;width:" bgcolor="#FFFFFF" height="27" align="left">
                                    &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;<a href="ViewXJB.aspx?id=<%#Eval("Id")%>&TypeId=<% =TypeId %>&bum_id=<%=Request.QueryString["bum_id"].ToString()%>&sectype=<%#Eval("sectype") %>"><%#title(Eval("Title"),100)%></a>
                                </td>
                                <td style="border-right:0px;border-top:0px;" bgcolor="#FFFFFF" width="80">
                                    <%#FormatDate(Eval("setDate").ToString())%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td style="border: 0px" colspan="2">
                            <table style="border-collapse:collapse;" height="26" width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" class="di">
                                        <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                            <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                                        </cc1:MTCPager>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
