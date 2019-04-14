<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DataTypeList.aspx.cs" Inherits="N_Index_DataTypeList2" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <title></title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../css/group.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
        <tr>
            <td height="28" valign="bottom">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-bottom: 0px #6f97b1 solid;
                    border-left: 1px #6f97b1 solid; height: 30px; border-right: 1px #6f97b1 solid;
                    border-top: 1px #6f97b1 solid">
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
                <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c8c8c8"
                    bordercolordark="#FFFFFF" bgcolor="#CCCCCC" style="border-collapse: collapse;
                    border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid; border-bottom: 1px #6f97b1 solid;
                    border-top: 1px #6f97b1 solid">
                    <tr>
                        <td align="left" colspan="2">
                            <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c8c8c8"
                    bordercolordark="#FFFFFF" bgcolor="#CCCCCC" style="border-collapse: collapse;">
                                <tr>
                                    <asp:Repeater ID="Repeater3" runat="server">
                                        <ItemTemplate>
                                            <td style="border-top: 0px; border-left: 0px;" bgcolor="#FFFFFF" height="27"
                                                align="center">
                                                <a href="DataTypeList.aspx?typeId=<%#Eval("typeid") %>&lanmuId=0&parentid=<%#Eval("parentid") %>">
                                                    <%#Eval("typename") %></a>
                                            </td>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#FFFFFF">
                                <td style="border-top: 0px; border-left: 0px;" bgcolor="#FFFFFF" height="27" align="left">
                                    &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;<a href="ViewGongGao.aspx?Id=<%#Eval("i_id")%>&TypeId=<% =TypeId %>"><%#title(Eval("i_title"),100)%></a>
                                </td>
                                <td style="border-top: 0px; border-right: 0px;" bgcolor="#FFFFFF" style="width: 80px">
                                    <%#FormatDate(Eval("i_time").ToString())%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <tr bgcolor="#FFFFFF">
                                <td style="border-top: 0px; border-left: 0px;" bgcolor="#FFFFFF" height="27" align="left">
                                    &nbsp;&nbsp;<font size="1">●</font>&nbsp;&nbsp;
                                    <%#GetLink(Eval("Id"),TypeId,Eval("Title"),Eval("userId"),Eval("readUser")) %>
                                </td>
                                <td style="border-top: 0px; border-right: 0px;" bgcolor="#FFFFFF" style="width: 80px">
                                    <%#FormatDate(Eval("setDate").ToString())%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr runat="server">
                        <td colspan="2" style="border: 0px">
                            <table height="26" width="100%" border="0" cellspacing="0" cellpadding="0">
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
