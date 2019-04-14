<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_PictureManage.aspx.cs"
    Inherits="PicManage_ImageList" %>


<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>无标题页</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>

        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" bgcolor="#f6f6f6" style="border-top: 1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right: 1px #6f97b1 solid;">
            <tr>
                <td colspan="7" height="30" align="left">
                    &nbsp;关键字：
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;按时间查询<asp:DropDownList ID="ddlYear" runat="server">
                       
                    </asp:DropDownList>
                    &nbsp;按类型查询 <asp:DropDownList ID="ddlType" runat="server">
                          <asp:ListItem></asp:ListItem>
                        <asp:ListItem>工地</asp:ListItem>
                        <asp:ListItem>会议</asp:ListItem>
                        <asp:ListItem>企业文化</asp:ListItem>                        
                        
                    </asp:DropDownList>
                    <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="button" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-top:1px #6f97b1 solid;border-right: 1px #6f97b1 solid;border-bottom: 1px #6f97b1 solid">
            <tr>
                <td align="center">
                    &nbsp;<asp:DataList ID="DataList1" runat="server" RepeatColumns="4" 
                        RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;&nbsp;<a href="N_PictureView.aspx?id=<%#Eval("i_id") %>&type=2" title='<%#Eval("i_name") %>'>
                                                <img src="../N_News/N_Picture/image/_<%#Eval("i_uri") %> " border="0" /></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <font color="black">
                                                <%#Eval("i_name").ToString().Length > 10 ? Eval("i_name").ToString().Substring(0, 8)+"..." : Eval("i_name").ToString()%></font>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="center" bgcolor="#e6f7ff" height="30px" >
                    <cc1:MTCPager ID="MTCPager1" runat="server" OnPageIndexChanged="MTCPager1_PageIndexChanged"
                        PagingMode="Digit" Width="100%">
                        <PageJump CurrentPageVisiable="False" DDLVisiable="False" PageJumpType="TextBox" />
                    </cc1:MTCPager>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
