<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_MailManage.aspx.cs" Inherits="N_Exchange_N_ExternalMail_N_MailManage" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>管理邮件</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:0px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_MailSend.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">发布邮件</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_MailManage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">已发邮件</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" bgcolor="#CCCCCC"
        style="border-collapse:collapse;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid">
        <tr>
            <td style="border-top:0px;border-left:0px" height="30" align="center" bgcolor="#f6f6f6">
                <strong>标题</strong>
            </td>
            <td style="border-top:0px" width="60" align="center" bgcolor="#f6f6f6">
                <strong>发件人</strong>
            </td>
            <td style="border-top:0px" width="110" align="center" bgcolor="#f6f6f6">
                <strong>附件</strong>
            </td>
            <td style="border-top:0px" width="110" align="center" bgcolor="#f6f6f6">
                <strong>发布时间</strong>
            </td>
            <td style="border-top:0px" width="140" align="center" bgcolor="#f6f6f6">
                <strong>接收邮箱</strong>
            </td>
            <td style="border-top:0px;border-right:0px" width="28" align="center" bgcolor="#f6f6f6">
                <strong>操作</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr style="height:26px;">
                    <td style="border-left:0px" bgcolor="#FFFFFF" align="left" height="26">
                        &nbsp;<a href="N_MailView.aspx?Id=<%#Eval("r_id")%>" title="查看详细"><%#Eval("r_title")%></a>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowUserName(Eval("r_user").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<a href='../<%#Eval("r_file")%>' title="点击下载"><%#System.IO.Path.GetFileName(Eval("r_file").ToString())%></a>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#Eval("r_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center" height="26">
                        &nbsp;<%#Eval("r_toEmail")%>
                    </td>
                    <td style="border-right:0px" bgcolor="#FFFFFF" align="center" height="26">
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("r_id")%>' CommandName='<%#Eval("r_file")%>'
                            runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('是否删除此条记录？')"
>删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td height="30" colspan="7" align="center" bgcolor="#e6f7ff" style="border-collapse:collapse;border-top:0px;border-right:0px;border-left:0px;border-bottom:0px">
                <table width="100%" style="height:28px;" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="85%" align="center">
                            <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                            </cc1:MTCPager>
                        </td>
                    </tr>
                </table>
                <label>
                </label>
            </td>
        </tr>
    </table>
  </asp:Content>