<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Flow_Add.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_SysManage_FlowDesign_Flow_Add" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<style type="text/css">
.STYLE1 {color: #FF0000}
</style>
    <link href="../../Css/Css.css" type="text/css" rel="stylesheet"/>
    <script src="../../javascript/StrLength.js" type="text/javascript" language="javascript"></script>
    <script type="text/javascript">
    function res(){
        if(document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value==""){
            alert("请输入表单名称！");
            document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").focus();
            return false;
        }
    }
    function shiw(){
        document.getElementById("sh").style.display="";
    }
     function hiw(){
        document.getElementById("sh").style.display="none";
    }
    </script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Flow_Add.aspx" class="a">
    <div style="width:73; height:27px; cursor:pointer;">添加流程</div></a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Flow_Manage.aspx" class="a">
    <div style="width:73; height:27px;cursor:pointer;">管理流程</div></a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td width="80" height="30" align="center" bgcolor="#f6f6f6">流程分类：</td>
        <td bgcolor="#f6f6f6"><asp:DropDownList ID="DropDownList1" runat="server" Width="175px" DataSourceID="SqlDataSource1"
                        DataTextField="fc_name" DataValueField="fc_id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                        SelectCommand="SELECT [fc_id], [fc_name] FROM [Tunnel_flowclass] ORDER BY [fc_id] DESC">
                    </asp:SqlDataSource></td>
      </tr>
      <tr>
        <td height="30" align="center">流程名称：</td>
        <td><asp:TextBox ID="TextBox1" runat="server" Width="260px" onkeyup="javascrip:checkWord(200,event,'lbl1')"></asp:TextBox>&nbsp;<span class="STYLE1">*</span>
                    <asp:Label ID="lbl1" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/200"></asp:Label></td>
      </tr>
       <tr>
        <td width="80" height="30" align="center" bgcolor="#f6f6f6">所属部门：</td>
        <td bgcolor="#f6f6f6">
            <asp:DropDownList ID="DropDownList2" runat="server" Width="175px">
                    </asp:DropDownList></td>
      </tr>
      <tr>
        <td height="30" align="center">表单：</td>
        <td><asp:DropDownList ID="DropDownList4" runat="server" Width="175px" DataSourceID="SqlDataSource2"
                        DataTextField="f_name" DataValueField="f_id">
                    </asp:DropDownList>&nbsp;<span class="STYLE1">*</span>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                        SelectCommand="SELECT [f_name], [f_id] FROM [Tunnel_form] ORDER BY [f_id] DESC">
                    </asp:SqlDataSource></td>
      </tr>
      <tr>
        <td width="80" height="30" align="center" bgcolor="#f6f6f6">允许附件：</td>
        <td bgcolor="#f6f6f6"><asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">是</asp:ListItem>
                        <asp:ListItem Value="1">否</asp:ListItem>
                    </asp:RadioButtonList></td>
      </tr>
      <tr>
        <td width="80" height="30" align="center" bgcolor="#ffffff" >是否审核：</td>
        <td bgcolor="#ffffff"><asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                        RepeatLayout="Flow">
                        <asp:ListItem Value="0">是</asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">否</asp:ListItem>
                    </asp:RadioButtonList></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#ffffff">流程说明：</td>
        <td bgcolor="#ffffff"><asp:TextBox ID="TextBox2" runat="server" Height="120px" TextMode="MultiLine" Width="351px"
                        onkeyup="javascrip:checkWord(1000,event,'lbl2')"></asp:TextBox>
                    <asp:Label ID="lbl2" runat="server" Font-Size="12px" CssClass="lblzifu" Text="0/1000"/></td>
      </tr>
      <tr>
        <td height="30" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">&nbsp;</td>
        <td height="30" align="left" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid">
            <asp:Button ID="Button1" runat="server" Text="添 加" OnClientClick="return res()" 
                CssClass="button" onclick="Button1_Click" />
&nbsp;&nbsp;
          <input type="reset" name="Submit2" value="重 置" class="button"/></td>
      </tr>
      
    </table></td>
  </tr>
</table>
</asp:Content>
