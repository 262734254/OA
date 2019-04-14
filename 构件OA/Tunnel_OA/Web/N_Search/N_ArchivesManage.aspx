<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_ArchivesManage.aspx.cs"
    Inherits="profile_ProfileList" %>


<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>无标题页</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#f6f6f6"
            style="border-collapse:collapse;border-top: 1px #6f97b1 solid;border-left: 1px #6f97b1 solid;border-right: 1px #6f97b1 solid;">
                        <tr>
                            <td align="left" height="25" width="150">
                                &nbsp;部门：<asp:DropDownList ID="DropDownList1" runat="server" Height="20">
                                </asp:DropDownList>
                                </td>
                                <td colspan="3" height="25" align="left">
                                &nbsp;类型：<asp:DropDownList ID="DropDownList2" runat="server" Height="20">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" height="25">
                                &nbsp;年份：<asp:TextBox ID="TextBox2" runat="server" Width="50"></asp:TextBox>
                            </td align="left" height="25" width="150">
                            <td width="150" align="left">发布人：<asp:TextBox ID="TextBox5" runat="server" Width="83"></asp:TextBox>
                            </td>
                            <td align="left" height="25" width="250">
                            关键字：<asp:TextBox ID="TextBox1" runat="server" Width="155"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:Button ID="Button1" CssClass="searchbutton" runat="server" OnClick="Button1_Click" />
                            </td>
                        </tr>
                    </table>
    
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC"
            style="border-collapse:collapse;border-left: 1px #6f97b1 solid;border-right:1px #6f97b1 solid;">
            <tr>
                <td height="30" align="center" bgcolor="#f6f6f6">
                    <strong>档案名称</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" width="80">
                    <strong>部门</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" width="150">
                    <strong>文件类型</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" width="50">
                    <strong>年份</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" width="60">
                    <strong>发布人</strong>
                </td>

            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td bgcolor="#FFFFFF" height="26" align="left">
                            &nbsp;<%#Eval("p_name")%>
                        </td>
                        <td bgcolor="#FFFFFF" height="26" align="center">
                            <%#Eval("p_bum")%>
                        </td>
                        <td bgcolor="#FFFFFF" height="26" align="center">
                            <%#Eval("p_filetype")%>
                        </td>
                        <td bgcolor="#FFFFFF" height="26" align="center">
                            <%#Eval("p_year")%>
                        </td>
                        <td bgcolor="#FFFFFF" height="26" align="center">
                            <%#showname(Eval("p_uid"))%>
                        </td>

                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td height="30" colspan="6" align="center" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid">
                    &nbsp;
                    <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                        <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                    </cc1:MTCPager>
                </td>
            </tr>
        </table>
</asp:Content>

