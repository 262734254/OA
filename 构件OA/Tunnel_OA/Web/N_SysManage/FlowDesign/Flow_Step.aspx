<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Flow_Step.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_SysManage_FlowDesign_Flow_Step" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../Css/Css.css" type="text/css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Flow_Add.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">添加流程</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Flow_Manage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理流程</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
          <td bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="3">
              <tr>
                <td align="left"><asp:Button ID="Button1" CssClass="button" runat="server" 
                        Text="新建步骤" onclick="Button1_Click" />&nbsp;<asp:Button ID="Button2" 
                        CssClass="button" runat="server" 
                        Text="返 回" onclick="Button2_Click" /></td>
              </tr>
          </table></td>
        </tr>
      </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
          <td width="50" align="center" bgcolor="#f6f6f6"><strong>序号</strong></td>
          <td height="30" align="center" bgcolor="#f6f6f6"><strong>名称</strong></td>
          <td width="250" align="center" bgcolor="#f6f6f6"><strong>说明</strong></td>
          <td width="100" align="center" bgcolor="#f6f6f6"><strong>操作</strong></td>
        </tr>
      <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
      <ItemTemplate>
      <tr>
          <td align="center" bgcolor="#FFFFFF">&nbsp;<%=(++i) %> <font color="red">↓</font></td>
          <td height="30" align="left" bgcolor="#FFFFFF">&nbsp;<%#Eval("s_name")%></td>
          <td align="center" bgcolor="#FFFFFF" align="left">&nbsp;<%#Eval("s_depict")%></td>
          <td align="center" bgcolor="#FFFFFF"><a href="Flow_StepEdit.aspx?zid=<%#Eval("s_id") %>&bid=<%=Request.Params["bid"] %>">修改</a> <a href="?mod=del&id=<%#Eval("s_id").ToString() %>" onclick="return confirm('确认删除本步骤?')">删除</a></td>
        </tr>
      </ItemTemplate>
      </asp:Repeater>    
      </table>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>" SelectCommand="Tunnel_step_GetList" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="l_id" QueryStringField="bid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>