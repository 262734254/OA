<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_MailView.aspx.cs" Inherits="N_Exchange_N_ExternalMail_N_MailView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>邮件详细信息</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF" style="border-collapse:collapse;border-left: 1px #6f97b1 solid;border-right: 1px #6f97b1 solid;border-top: 1px #6f97b1 solid;border-bottom: 1px #6f97b1 solid">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-left:0px;border-top:0px;border-right:0px" bgcolor="#f6f6f6" height="35" colspan="2" align="center"  >
                            <span id="Label1">标题：<%#Eval("r_title")%></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0px;border-right:0px" align="center" colspan="2" height="35">
                            发送人：<%#ShowUserName(Eval("r_user").ToString())%>
                            发送时间：<%#Eval("r_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                            接收人邮箱：<%#Eval("r_toEmail") %>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left" style="padding: 10px;border-left:0px;border-right:0px" valign="top" height="300">
                            <%#Eval("r_Content")%>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="center" bgcolor="#e6f7ff" style="border:0px"
                            colspan="2">
                            <input id="Button1" class="button" type="button" onclick="window.history.go(-1)"
                                value="返 回" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

