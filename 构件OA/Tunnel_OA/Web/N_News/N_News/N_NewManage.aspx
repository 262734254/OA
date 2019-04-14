<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_NewManage.aspx.cs" Inherits="N_News_N_News_N_NewManage" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>新闻管理</title>

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

 
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style1
        {
            width: 62px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr align="left">
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_NewAdd.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">发布新闻</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_NewManage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理新闻</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
    <table width="100%" height="30" border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;border-bottom: 0px #6f97b1 solid;
        border-left: 1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
            <td style="width: 400px" align="right" bgcolor="#f6f6f6">
                标题关键字：&nbsp;<asp:TextBox ID="TextBox1" Width="300" runat="server"></asp:TextBox>
            </td>
            <td align="left" bgcolor="#f6f6f6">
                &nbsp;<asp:Button ID="BtnSearch" runat="server" CssClass="searchbutton" OnClick="BtnSearch_Click" />
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" bordercolorlight="#c8c8c8" bordercolordark="#FFFFFF"
        style="border-collapse:collapse;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid;">
        <tr>
            <td style="border-top:0px;border-left:0px" height="30" align="center" bgcolor="#f6f6f6">
                <strong>标题</strong>
            </td>
            <td style="border-top:0px;" width="60" align="center" bgcolor="#f6f6f6">
                <strong>发布人</strong>
            </td>
            <td style="border-top:0px;" width="110" align="center" bgcolor="#f6f6f6">
                <strong>发布时间</strong>
            </td>
            <td style="border-top:0px;" width="110" align="center" bgcolor="#f6f6f6">
                
                <strong>文件下载</strong>
            </td>
            <td style="border-top:0px;" align="center" bgcolor="#f6f6f6" class="style1">
                <strong>审核状态</strong>
            </td>
            <td style="border-top:0px;border-right:0px;" width="90" align="center" bgcolor="#f6f6f6">
                <strong>操作</strong>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <tr bgcolor="#FFFFFF" height="26">
                    <td style="border-left:0px;" bgcolor="#FFFFFF" align="left" height="26">
                        &nbsp;<a href="N_NewView.aspx?Id=<%#Eval("i_id")%>&TypeId=<%=TypeId %>" title="查看详细"><%#Eval("i_title")%></a>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#ShowUserName(Eval("i_user").ToString())%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<%#Eval("i_time","{0:yyyy-MM-dd HH:mm:ss}")%>
                    </td>
                    <td bgcolor="#FFFFFF" align="center">
                        &nbsp;<a href='../../<%#Eval("i_files")%>' title="点击下载"><%#System.IO.Path.GetFileName(Eval("i_files").ToString())%></a>
                    </td>
                    <td bgcolor="#FFFFFF" align="center"><%# Audit(Eval("i_hit")) %></td>
                    <td style="border-right:0px;" bgcolor="#FFFFFF" align="center" height="26">
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName='<%#Eval("i_id") %>'
                            CommandArgument='<%#Eval("i_hit") %>' ToolTip="审核该记录" OnCommand="LinkButton3_Command">审核</asp:LinkButton>
                        <asp:LinkButton runat="server" ID="LinkButton2" CommandName='<%#Eval("i_id") %>'
                            CommandArgument='<%=TypeId %>' ToolTip="修改本条记录" OnCommand="LinkButton2_Command">修改</asp:LinkButton>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("i_user")%>' CommandName='<%#Eval("i_id")%>'
                            runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('是否删除此条记录？')"
>删除</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td height="30" colspan="6" align="center" bgcolor="#e6f7ff" style="border:0px">
                &nbsp;
                <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                    <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                </cc1:MTCPager>
            </td>
        </tr>
    </table>
</asp:Content>
