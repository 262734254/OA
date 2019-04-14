<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_In.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_VDocument_Document_In" %>

<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../css/Css.css" rel="stylesheet" type="text/css" />
        <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
    function shows(obj,contr){
    $("#"+contr).toggle();
        }
            function fshow(obj){
                $("#"+obj).show();
             }
            function fhide(obj){
                $("#"+obj).hide();
             }
</script>
<style type="text/css">
ul{ margin:0px; padding:0px}
li{ list-style:none; height:20px; text-align:center; margin:0px; width:100%; padding-top:5px; cursor:pointer}
</style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
        <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Document_In.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer;">内部公文</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Document_Out.aspx?fid=1" class="a">
      <div style="width:73; height:27px; cursor:pointer;">外部来文</div>
    </a></td>
    <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Document_Out.aspx?fid=2" class="a">
      <div style="width:73; height:27px;cursor:pointer;">普通文件</div>
    </a></td>
    <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Document_Out.aspx?fid=3" class="a">
      <div style="width:73; height:27px;cursor:pointer;">其它文件</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr>
    <td height="30" colspan="4" align="center" bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="3">
      <tr>
        <td width="84"><label></label>
          &nbsp;搜索关键字：</td>
        <td width="150"><label>
            <asp:TextBox ID="TextBox1" runat="server" Width="247px"></asp:TextBox>
        </label></td>
        <td align="left"><asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="../../images/search.gif" onclick="ImageButton1_Click" /></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="30" width="30%" align="center" bgcolor="#f6f6f6"><strong>标题</strong></td>
    <td width="8%" align="center" bgcolor="#f6f6f6"><strong>发布人</strong></td>
    <td width="12%" align="center" bgcolor="#f6f6f6"><strong>发布时间</strong></td>
    <td width="20%" align="center" bgcolor="#f6f6f6"><strong>附件</strong></td>
  </tr>
  <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
  <tr>
    <td height="30" align="left" bgcolor="#FFFFFF">&nbsp;<a href="Document_ViewIn.aspx?File_Id=<%#Eval("b_id") %>" target="_blank"><%#Eval("b_title")%></a></td>
    <td align="center" bgcolor="#FFFFFF"><%#ShowUserName(Eval("b_user").ToString())%></td>
    <td align="center" bgcolor="#FFFFFF"><%#Eval("b_time","{0:yyyy-MM-dd HH:mm:ss}")%></td>
    <td align="center" bgcolor="#FFFFFF"><%#getFile(Eval("b_file").ToString()) %></td>
  </tr>
  </ItemTemplate>
          </asp:Repeater>
  <tr>
    <td height="30" colspan="4" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid"><cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
              </cc1:MTCPager></td>
  </tr>
</table>
</asp:Content>