<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FShaRing_Manage.aspx.cs" Inherits="Common_ManageFile" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <title>管理文件</title>
    <link href="../../Css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
    function SelectUser(str)
    {
        window.open ('SelectUser.aspx?fileId='+str+'', '选择用户', 'height=400, width=300,toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no')
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-top: 1px #6f97b1 solid;
        border-bottom: 0px #6f97b1 solid; border-left: 1px #6f97b1 solid; border-right: 1px #6f97b1 solid">
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
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon">
                <a href="FShaRing_Manage.aspx" class="a">
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        管理文件</div>
                </a>
            </td>
            <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons">
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
        bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF" bgcolor="#CCCCCC">
        <tr height="20">
            <td style="border-top: 0px; border-left: 0px" width="" align="center" bgcolor="#f6f6f6"
                width="240">
                <strong>文件名称</strong>
            </td>
            <td style="border-top: 0px;" width="60" align="center" bgcolor="#f6f6f6" width="240">
                <strong>上传用户</strong>
            </td>
            <td style="border-top: 0px;" width="70" align="center" bgcolor="#f6f6f6" height="30">
                <strong>上传时间</strong>
            </td>
            <td style="border-top: 0px;" width="55" align="center" bgcolor="#f6f6f6" height="30">
                <strong>大小</strong>
            </td>
            <td style="border-top: 0px;" width="70" align="center" bgcolor="#f6f6f6" height="30">
                <strong>文件类型</strong>
            </td>
            <td style="border-top: 0px;" width="130" align="center" bgcolor="#f6f6f6" height="30">
                <strong>文件下载</strong>
            </td>
            <td style="border-top: 0px; border-right: 0px" width="130" align="center" bgcolor="#f6f6f6"
                height="30">
                <strong>操作</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <tr height="26" onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                    onmouseout="this.style.backgroundColor='';this.style.color='';">
                    <td style="border-left: 0px;" align="left" height="26" bgcolor="#FFFFFF">
                        &nbsp;<%#Eval("f_title")%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<%#ShowUserName(Eval("f_user").ToString())%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<%#Eval("f_addtime","{0:yyyy-MM-dd}")%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<%#ShowFileSize(Eval("f_size").ToString())%>
                        KB
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<%#FileTypeName(System.IO.Path.GetExtension(Eval("f_file").ToString()))%>
                    </td>
                    <td align="center" bgcolor="#FFFFFF">
                        &nbsp;<a href='../../<%#Eval("f_file")%>' title="点击下载"><%#System.IO.Path.GetFileName(Eval("f_file").ToString())%></a>
                    </td>
                    <td style="border-right: 0px;" align="center" height="26" bgcolor="#FFFFFF">
                        <%--<a style="cursor: hand" onclick="SelectUser('<%#Eval("f_id")%>');">传送</a>--%>
                        <asp:LinkButton ID="LinkButton3" CommandArgument='<%#Eval("f_id")%>' CommandName='0'
                            runat="server" OnCommand="LinkButton2_Command" ToolTip="取消本条记录的共享">取消</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("f_id")%>' CommandName='1'
                            runat="server" OnCommand="LinkButton2_Command" ToolTip="共享本条记录">共享</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("f_id")%>' CommandName='<%#Eval("f_file")%>'
                            runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录">删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td colspan="7" align="center" bgcolor="#e6f7ff" style="border:0px">
                <table style="border-collapse:collapse;" width="100%" border="0" align="center" cellpadding="6" cellspacing="0">
                    <tr>
                        <td height="20" >
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
