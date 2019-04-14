<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Tunnel_DutyList.aspx.cs"
    Inherits="SystemManage_Tunnel_DutyList" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Header">
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../../javascript/IframeReSize.js" type="text/javascript"></script>

        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid;">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="Tunnel_DutyAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                       新增职务</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Tunnel_DutyList.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        职务管理</div>
                </a>
            </td>
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid"">
            <tr>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 20%">
                    <strong>职务名称</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 20%">
                    <strong>描述</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 20%">
                    <strong>所属部门</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 20%">
                    <strong>权限设置</strong>
                </td>
                <td height="30" align="center" bgcolor="#f6f6f6" style="width: 20%">
                    <strong>操作</strong>
                </td>
            </tr>
            <asp:Repeater ID="GridView1" runat="server">
                <ItemTemplate>
                    <tr onmouseover="this.style.backgroundColor='#F2F2F2'; this.style.color='#10a019';"
                        onmouseout="this.style.backgroundColor='';this.style.color='';">
                        <td height="26" align="center" style="width: 20%" bgcolor="#ffffff">
                            <a href="tunnel_dutyinfo.aspx?id=<%#Eval("d_id") %>">
                                <%#Eval("d_name") %>
                            </a>
                        </td>
                        <td height="26" align="center" style="width: 20%" bgcolor="#ffffff">
                            &nbsp;<%#Eval("d_depict")%>
                        </td>
                        <td height="26" align="center" style="width: 20%" bgcolor="#ffffff">
                            &nbsp;<%#retBum( Eval("d_flag"))%>
                        </td>
                        <td height="26" align="center" style="width: 20%" bgcolor="#ffffff">
                            &nbsp;<a href="../../N_Permission/Permission.aspx?did=<%#Eval("d_id") %>">权限设置</a>
                        </td>
                        <td height="26" align="center" style="width: 20%" bgcolor="#ffffff">
                            <a href="Tunnel_dutyupd.aspx?updid=<%#Eval("d_id") %>">修改</a>
                            <a href="?delid=<%#Eval("d_id") %>" onclick="return confirm('是否删除此条记录？')">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td align="right" height="30" class="di" colspan="5">
                    <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                        <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
                    </cc1:MTCPager>
                </td>
            </tr>
        </table>

</asp:Content>
