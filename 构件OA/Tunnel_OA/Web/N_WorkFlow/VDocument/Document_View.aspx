<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_View.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_VDocument_Document_View" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>>
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
#listuser td{ border-bottom:1px #cccccc solid}
</style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
        <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Document_In.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer;">内部公文</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon<%if(Request.Params["fid"]!="1"){ %>s<%} %>"><a href="Document_Out.aspx?fid=1" class="a">
      <div style="width:73; height:27px; cursor:pointer;">外部来文</div>
    </a></td>
    <td width="74" id="icon3" valign="bottom" bgcolor="#f6f6f6" class="showicon<%if(Request.Params["fid"]!="2"){ %>s<%} %>"><a href="Document_Out.aspx?fid=2" class="a">
      <div style="width:73; height:27px;cursor:pointer;">普通文件</div>
    </a></td>
    <td width="74" id="icon4" valign="bottom" bgcolor="#f6f6f6" class="showicon<%if(Request.Params["fid"]!="3"){ %>s<%} %>"><a href="Document_Out.aspx?fid=3" class="a">
      <div style="width:73; height:27px;cursor:pointer;">其它文件</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
      <tr>
        <td colspan="2" height="30" align="center">
            <span id="Label1"  style="font-size:16px" ><b><asp:Label ID="Label1" runat="server"></asp:Label></b></span></td>
      </tr>
      <tr>
        <td align="center" height="30" colspan="2" style="border-bottom:1px #6f97b1 solid">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
          </td>
      </tr>
      <tr>
        <td height="300" colspan="2" align="left" valign="top" id="contenttd" style="border-bottom:1px #6f97b1 solid; padding:10px">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                </td>
      </tr>
      <tr>
        <td height="30" width="50" align="center" bgcolor="#f6f6f6">附件：</td>
        <td bgcolor="#f6f6f6" align="left"><%=file%></td>
    </tr> 
      <tr>
        <td height="30" width="50" align="center" bgcolor="#f6f6f6">意见：</td>
        <td bgcolor="#f6f6f6" align="left">
            <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/Vfckeditor/" Height="100" ToolbarSet="Basic" Width="100%">
            </FCKeditorV2:FCKeditor>
          </td>
    </tr> 
      <tr>
        <td bgcolor="#f6f6f6" align="center" colspan="2">
            <asp:Button ID="Button2" runat="server" Text="阅  读" CssClass="button" 
                onclick="Button2_Click" /></td>
    </tr> 
      <tr>
        <td bgcolor="#ffffff" align="center" colspan="2">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" id="listuser" style="border-top:1px #6f97b1 solid">
          <tr>
            <td width="20%" height="30" align="center"><strong>传阅</strong></td>
            <td width="9%" align="center"><strong>状态</strong></td>
            <td width="20%" align="center"><strong>时间</strong></td>
            <td width="51%" align="center"><strong>意见</strong></td>
          </tr>
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                 <tr>
                    <td height="50" align="center"><%#ShowUserName(Eval("c_uid").ToString())%></td>
                    <td align="center"><%#(Eval("c_read").ToString()=="0"?"<font color=red>未阅</font>":"已阅")%></td>
                    <td align="center"><%#Eval("c_readdate") %>&nbsp;</td>
                    <td align="left"><%#Eval("c_content")%>&nbsp;</td>
                  </tr>
            </ItemTemplate>
            </asp:Repeater>
        </table>
        </td>
    </tr> 
    </table></td>
  </tr>
</table>
</asp:Content>