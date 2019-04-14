<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="N_NewView.aspx.cs" Inherits="Common_ViewNewsAnnouncement" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <title>查看详细</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF" style="border-collapse:collapse;border-top: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid;
            border-right: 1px #6f97b1 solid; border-bottom: 1px #6f97b1 solid;">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-left: 0px; border-top: 0px; border-right: 0px;" bgcolor="#f6f6f6"
                            height="35" colspan="2" align="center">
                            <span id="Label1"><%--标题：--%><%#Eval("i_title")%></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left: 0px; border-right: 0px;" align="center" colspan="2" height="35">
                            发布人：<%#ShowUserName(Eval("i_user").ToString())%>
                            发布时间：<%#Eval("i_time")%>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left: 0px; border-right: 0px;" colspan="2" align="left" style="padding: 10px"
                            valign="top" height="300">
                            <%#Eval("i_content")%>
                        </td>
                    </tr>
                    <tr>
                        <td style="border: 0px" height="25" align="center" bgcolor="#e6f7ff" style="border-bottom: 1px #6f97b1 solid"
                            colspan="2">
                            <input id="Button1" class="button" type="button" onclick="window.history.go(-1)"
                                value="返 回" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-left: 1px #6f97b1 solid;
            border-bottom: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
            <tr>
                <td colspan="2">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td bgcolor="#f6f6f6" colspan="7" height="30" align="center">
                                查看评论信息
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="border:0px" colspan="2">
                    <table width="100%" border="1" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC"
                        bordercolorlight="#c1c1c1" bordercolordark="#FFFFFF" style="border-collapse:collapse;border-bottom: 1px #6f97b1 solid;
                        border-right: 0px #6f97b1 solid;border-left: 0px #6f97b1 solid">
                        <tr height="25">
                            <td style="border-top:0px;border-left:0px;" width="15%" align="center" bgcolor="#f6f6f6">
                                <strong>用户</strong>
                            </td>
                            <td style="border-top:0px;" width="70%" align="center" bgcolor="#f6f6f6">
                                <strong>内容</strong>
                            </td>
                            <td style="border-top:0px;border-right:0px;" width="15%" align="center" bgcolor="#f6f6f6" height="20">
                                <strong>时间</strong>
                            </td>
                        </tr>
                        <asp:Repeater ID="Repeater2" runat="server">
                            <ItemTemplate>
                                <tr height="25">
                                    <td style="border-left:0px;" bgcolor="#FFFFFF">
                                        <%#ShowUserName(Eval("UserId").ToString())%>
                                    </td>
                                    <td bgcolor="#FFFFFF">
                                        <%#Eval("Content")%>
                                    </td>
                                    <td style="border-right:0px;" bgcolor="#FFFFFF">
                                        <%#Eval("SetDate")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td height="25" style="border:0px" align="center" class="di" colspan="3">
                                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                                </cc1:MTCPager>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    评论信息：
                </td>
                <td>
                    <asp:TextBox ID="btTitle" runat="server" TextMode="MultiLine" Rows="6" Width="500"
                        onkeyup="javascrip:checkWord(800,event,'lbl1')"></asp:TextBox>
                    <div id="lbl1" name="lbl" size="12px" class="lblzifu">
                        0/800</div>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button ID="Button3" runat="server" CssClass="button" Text=" 发表评论 " OnClick="Button3_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
