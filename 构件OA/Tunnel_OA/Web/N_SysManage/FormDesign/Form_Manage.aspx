<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Form_Manage.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_SysManage_FormDesign_Form_Manage" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../Css/Css.css" type="text/css" rel="stylesheet"/>
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function edit_form(FORM_ID)
            {
              window.open("Form_Design.aspx?form_id="+FORM_ID,"cool_form","menubar=0,toolbar=0,scrollbars=no,status=0,resizable=1")
            }
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Form_Add.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">添加表单</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Form_Manage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理表单</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border-bottom:1px #6f97b1 solid;border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
          <td bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="3">
              <tr>
                <td width="100" align="right">选择搜索类别：</td>
                <td width="80" align="left"><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="fc_name" DataValueField="fc_id">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT [fc_id], [fc_name] FROM [Tunnel_flowclass] ORDER BY [fc_id]">
            </asp:SqlDataSource></td>
                <td width="80" align="right">搜索关键字：</td>
                <td width="160"><label>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </label></td>
                <td align="left"><asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl="../../images/search.gif" onclick="ImageButton1_Click" /></td>
              </tr>
          </table></td>
        </tr>
      </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
          <td width="50" align="center" bgcolor="#f6f6f6"><strong>序号</strong></td>
          <td height="30" align="center" bgcolor="#f6f6f6"><strong>名称</strong></td>
          <td width="88" align="center" bgcolor="#f6f6f6"><strong>类型 </strong></td>
          <td width="200" align="center" bgcolor="#f6f6f6"><strong>操作</strong></td>
        </tr>
      <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
      <tr>
          <td align="center" bgcolor="#FFFFFF">&nbsp;<%#Eval("f_id") %></td>
          <td height="30" align="left" bgcolor="#FFFFFF">&nbsp;<%#Eval("f_name") %></td>
          <td align="center" bgcolor="#FFFFFF"><%#GetClass(Eval("f_lcid").ToString()) %></td>
          <td align="center" bgcolor="#FFFFFF">
              <a href="javascript:edit_form(<%#Eval("f_id") %>);">智能设计器</a>&nbsp;&nbsp;
              <a href="Form_View.aspx?form_id=<%#Eval("f_id") %>" target="_blank" title="表单预览">预览</a>&nbsp;&nbsp;
              <a href="Form_Edit.aspx?id=<%#Eval("f_id") %>&fid=<%=Request.Params["id"] %>">修改</a>&nbsp;&nbsp;
              <a href="Form_Manage.aspx?id=<%=Request.Params["id"] %>&delid=<%#Tunnel.Data.DESEncrypt.Encrypt(Eval("f_id").ToString()) %>" onclick="return confirm('确认删除些表单?');">删除</a>&nbsp;</td>
        </tr>
      </ItemTemplate>
      </asp:Repeater>    
      </table>
</asp:Content>
