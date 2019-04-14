<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FlowClass_Manage.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_SysManage_FlowClass_FlowClass_Manage" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
    <link href="../../Css/Css.css" type="text/css" rel="stylesheet"/>
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="FlowClass_Add.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">添加分类</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="FlowClass_Manage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理分类</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border:1px #6f97b1 solid;border-top:none">
      <tr>
        <td width="50" height="30" align="center" bgcolor="#f6f6f6"><strong>序号</strong></td>
        <td align="center" bgcolor="#f6f6f6"><strong>名称</strong></td>
        <td width="215" align="center" bgcolor="#f6f6f6"><strong>备注</strong></td>
        <td width="100" align="center" bgcolor="#f6f6f6"><strong>操作</strong></td>
      </tr>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <tr>
            <td align="center" height="30" bgcolor="#FFFFFF">&nbsp;<%#Eval("fc_id")%></td>
            <td align="center" height="30" bgcolor="#FFFFFF">&nbsp;<%#Eval("fc_name")%></td>
            <td align="center" height="30" bgcolor="#FFFFFF">&nbsp;<%#Eval("fc_desin")%></td>
            <td align="center" height="30" bgcolor="#FFFFFF"><a href="FlowClass_Edit.aspx?id=<%#Tunnel.Data.DESEncrypt.Encrypt(Eval("fc_id").ToString()) %>">修改</a> <a href="FlowClass_Manage.aspx?mod=del&id=<%#Tunnel.Data.DESEncrypt.Encrypt(Eval("fc_id").ToString()) %>" onclick="return confirm('确认删除本分类?');">删除</a></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
            SelectCommand="SELECT [fc_id], [fc_name],[fc_desin] FROM [Tunnel_flowclass] ORDER BY [fc_id] ASC">
        </asp:SqlDataSource>
</asp:Content>
