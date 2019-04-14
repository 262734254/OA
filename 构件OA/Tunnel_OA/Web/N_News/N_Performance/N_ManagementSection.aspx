<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="N_ManagementSection.aspx.cs" Inherits="N_News_N_Performance_N_ManagementSection" %>
<%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<asp:Content ID="Header1" ContentPlaceHolderID="Header" Runat="Server">

    <script src="../../javascript/Calendarform.js" type="text/javascript"></script>
        <script src="../../javascript/utility.js" type="text/javascript"></script>
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
                </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_SectionAdd.aspx" class="a">
      <div style="width:73; height:27px; cursor:pointer;">科室考核</div>
    </a></td>
 <%--   <td width="74" id="Td1" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_Factory.aspx" class="a">
      <div style="width:73; height:27px; cursor:pointer;">分厂考核</div>
    </a></td>--%>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="N_ManagementSection.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer;">管理科室</div>
    </a></td>
    
   <%-- <td width="74" id="Td2" valign="bottom" bgcolor="#f6f6f6" class="showicons"><a href="N_ManagFactory.aspx" class="a">
      <div style="width:73; height:27px; cursor:pointer;">管理分厂</div>
    </a></td>--%>
    <td bgcolor="#f6f6f6">
        &nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid; border-top:none">
        <tr>
          <td bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="30">&nbsp;</td>
                           
                <td width="200">
                    &nbsp;</td>
               
                <td width="72" align="right">标题名称：</td>
                <td width="149"><label>
                  <asp:TextBox ID="txtTitle" Width="100" runat="server"></asp:TextBox>
                </label></td>
                <td>&nbsp; 
                    <asp:ImageButton ID="tbSeach"
                    runat="server" ImageUrl="../../images/search.gif" 
                        onclick="ImageButton1_Click" /></td>
              </tr>
          </table></td>
        </tr>
      </table>
       <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
          <td width="40" align="center" bgcolor="#f6f6f6"><strong>文号</strong></td>
          <td height="30"  width="200" align="center" bgcolor="#f6f6f6"><strong>公文名称</strong></td>
          <td width="50" align="center" bgcolor="#f6f6f6"><strong>发稿人</strong></td>
          <td width="132" align="center" bgcolor="#f6f6f6"><strong>附件</strong></td>
          <td width="100" align="center" bgcolor="#f6f6f6"><strong>开始时间</strong></td>
          <td width="80" align="center" bgcolor="#f6f6f6"><strong>操作</strong></td>
        </tr>
         <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr>
          <td align="center" bgcolor="#FFFFFF"><%#Eval("Id") %></td>
          <td height="30" align="left" bgcolor="#FFFFFF">&nbsp;<%#Eval("Title")%></td>
          <td align="center" bgcolor="#FFFFFF"><%#GetUserName(Eval("CreateUser").ToString())%></td>
          <td align="center" bgcolor="#FFFFFF"><%#getFile(Eval("File").ToString()) %></td>
          <td align="center" bgcolor="#FFFFFF"><%#Eval("CreateDate", "{0:yy-MM-dd HH:mm:ss}")%></td>
           <td align="center" bgcolor="#FFFFFF"><asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("Id")%>' CommandName='<%#Eval("File")%>' runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
          <td height="30" colspan="6" align="center" bgcolor="#e6f7ff" 
                style="border-bottom:1px #6f97b1 solid">
              <cc1:MTCPager ID="MTCPager1" runat='server' PagingMode='Digit' OnPageIndexChanged="MTCPager1_PageIndexChanged">
                <PageJump DDLVisiable="false" CurrentPageVisiable="false" PageJumpType="TextBox" />
              </cc1:MTCPager></td>
        </tr>
      </table>
        </td>
  </tr>
</table>
</asp:Content>

