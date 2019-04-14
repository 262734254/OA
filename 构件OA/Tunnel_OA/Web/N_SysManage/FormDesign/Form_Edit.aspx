<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Form_Edit.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_SysManage_FormDesign_Form_Edit" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<style type="text/css">
.STYLE1 {color: #FF0000}
</style>
    <link href="../../Css/Css.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript">
    function res(){
        if(document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value==""){
            alert("请输入表单名称！");
            document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").focus();
            return false;
        }
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
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td width="80" height="30" align="center" bgcolor="#f6f6f6">表单名称：</td>
        <td bgcolor="#f6f6f6">
            <asp:TextBox ID="TextBox1" runat="server" Width="161px"></asp:TextBox>
&nbsp;&nbsp;<span class="STYLE1">* </span>0/100</td>
      </tr>
      <tr>
        <td height="30" align="center">表单分类：</td>
        <td><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="fc_name" DataValueField="fc_id">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT [fc_id], [fc_name] FROM [Tunnel_flowclass] ORDER BY [fc_id]">
            </asp:SqlDataSource></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="Button1" runat="server" Text="修 改" OnClientClick="return res()" 
                CssClass="button" onclick="Button1_Click" />
&nbsp;&nbsp;
          <input type="reset" name="Submit2" value="重 置" class="button"/></td>
      </tr>
      
    </table></td>
  </tr>
</table>
</asp:Content>
