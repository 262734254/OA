<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_Manage.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_CDocument_Document_Manage" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../Css/Css.css" rel="stylesheet" type="text/css" />
            <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
        <script type="text/javascript">
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
                .style1
                {
                    width: 93px;
                }
                .style2
                {
                    height: 24px;
                    width: 93px;
                }
            </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="Document_Add.aspx" class="a">
      <div style="width:73; height:27px; cursor:pointer;">创建文件</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Document_Manage.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer;">管理文件</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  <tr>
    <td height="30" colspan="6" align="center" bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="3">
      <tr>
      <td width="54"><label></label>
          &nbsp;分类：</td>
        <td width="80" align="left"><asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="0" Text="请选择"></asp:ListItem>
            <asp:ListItem Value="1" Text="外部来文"></asp:ListItem>
            <asp:ListItem Value="2" Text="普通文件"></asp:ListItem>
            <asp:ListItem Value="3" Text="其它文件"></asp:ListItem>
            </asp:DropDownList></td>
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
    <td height="25" width="30%" align="center" bgcolor="#f6f6f6"><strong>标题</strong></td>
    <td width="8%" align="center" bgcolor="#f6f6f6"><strong>分类</strong></td>
    <td width="8%" align="center" bgcolor="#f6f6f6"><strong>发布人</strong></td>
    <td width="15%" align="center" bgcolor="#f6f6f6"><strong>发布时间</strong></td>
    <td width="10%" align="center" bgcolor="#f6f6f6"><strong>附件</strong></td>
    <td width="5%" align="center" bgcolor="#f6f6f6"><strong>操作</strong></td>
  </tr>
  <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
  <tr>
    <td height="30" align="left" bgcolor="#FFFFFF">&nbsp;<a href="Document_View.aspx?File_id=<%#Eval("f_id") %>"><%#Eval("f_title")%></a></td>
    <td align="center" bgcolor="#FFFFFF"><%#ShowSort(Eval("f_type").ToString())%></td>
    <td align="center" bgcolor="#FFFFFF"><%#ShowUserName(Eval("f_user").ToString())%></td>
    <td align="center" bgcolor="#FFFFFF"><%#Eval("f_date","{0:yyyy-MM-dd HH:mm:ss}")%></td>
    <td align="center" bgcolor="#FFFFFF"><%#getFile(Eval("f_file").ToString()) %></td>
    <td align="center" bgcolor="#FFFFFF"><asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("f_id")%>' CommandName='<%#Eval("f_file")%>' runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton></td>
  </tr>
  </ItemTemplate>
          </asp:Repeater>
  <tr>
    <td height="30" colspan="6" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid"><cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
              </cc1:MTCPager></td>
  </tr>
</table>
</asp:Content>