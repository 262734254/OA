<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FShaRing_Share.aspx.cs" Inherits="Common_ShareFile" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <title>共享下载</title>
    <link href="../../Css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-top: 1px #6f97b1 solid;
        border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
        <tr align="left">
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="FShaRing_Add.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        发布文件</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons">
                <a href="FShaRing_Manage.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理文件</div>
                </a>
            </td>
            <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="FShaRing_Share.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        共享下载</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" style="border-collapse:collapse;border-right: 1px #6f97b1 solid;
        border-top: 1px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-bottom: 1px #6f97b1 solid;"
         bgcolor="#CCCCCC" bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF">
        <tr height="20">
            <td style="border-top:0px;border-left:0px;" width="" align="center" bgcolor="#f6f6f6" width="240">
                <strong>文件名称</strong>
            </td>
            <td style="border-top:0px;" width="60" align="center" bgcolor="#f6f6f6" width="240">
                <strong>上传用户</strong>
            </td>
            <td style="border-top:0px;" width="64" align="center" bgcolor="#f6f6f6" height="30">
                <strong>上传时间</strong>
            </td>
            <td style="border-top:0px;" width="55" align="center" bgcolor="#f6f6f6" height="30">
                <strong>文件大小</strong>
            </td>
            <td style="border-top:0px;" width="70" align="center" bgcolor="#f6f6f6" height="30">
                <strong>文件类型</strong>
            </td>
            <td style="border-top:0px;border-right:0px" width="140" align="center" bgcolor="#f6f6f6" height="30">
                <strong>文件下载</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr height="26" onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                    onmouseout="this.style.backgroundColor='';this.style.color='';">
                    <td style="border-left:0px;" bgcolor="#FFFFFF" align="left" height="26">
                        &nbsp;<%#Eval("f_title")%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowUserName(Eval("f_user").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#Eval("f_addtime","{0:yyyy-MM-dd}")%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowFileSize(Eval("f_size").ToString())%>
                        KB
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#FileTypeName(System.IO.Path.GetExtension(Eval("f_file").ToString()))%>
                    </td>
                    <td style="border-right:0px;" bgcolor="#FFFFFF" align="center">
                        &nbsp;<a href='/<%#Eval("f_file")%>' title="点击下载"><%#System.IO.Path.GetFileName(Eval("f_file").ToString())%></a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="6" align="center" bgcolor="#e6f7ff" style="border:0px">
                <table style="border-collapse:collapse;" width="100%" border="0" align="center" cellpadding="6" cellspacing="0">
                    <tr>
                        <td height="20">
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
</asp:Content>
