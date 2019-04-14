<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_MessageView.aspx.cs" Inherits="grzm_ViewMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <title>阅读内部邮件</title>

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>


    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table width="100%" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#c1c1c1"
            bordercolordark="#FFFFFF" style="border-collapse:collapse;border-bottom: 1px #6f97b1 solid;border-left: 1px #6f97b1 solid;border-top: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td style="border-left:0px;border-top:0px;border-right:0px" bgcolor="#f6f6f6" height="35" colspan="2" align="center">
                            <span id="Label1">标题：<%#Eval("m_title")%></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0px;border-right:0px;" align="center" colspan="2" height="35">
                            发送人：<%#ShowUserName(Eval("m_from").ToString())%>
                            发送时间：<%#Eval("m_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                            接收人：<%#ShowUserName(Eval("m_to").ToString())%>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-left:0px;border-right:0px;" colspan="2" align="left" style="padding: 10px" valign="top" height="300">
                            <%#Eval("m_content")%>
                            <br>
                            <a href='../../<%#Eval("m_file")%> ' title="点击下载">
                                <%# file(Eval("m_file").ToString())%><%#System.IO.Path.GetFileName(Eval("m_file").ToString())%></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td height="25" align="center" bgcolor="#e6f7ff" style="border:0px">
                    <asp:Button ID="Button2" runat="server" Text="删除" class="button" OnClick="LinkButton2_Command" />&nbsp;
                    <asp:Button ID="Button4" runat="server" CssClass="button" Text="返 回" 
                        onclick="Button4_Click" />
                    &nbsp;
                        <asp:Button ID="resert" runat="server" CssClass="button" Text="回 复" OnClick="resert_Click" />
                    <input id="Button3" class="button" type="button" onclick="location.href('N_MessageSend.aspx?Id=<%=Id %>&classId=2')"
                        value="转 发">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

