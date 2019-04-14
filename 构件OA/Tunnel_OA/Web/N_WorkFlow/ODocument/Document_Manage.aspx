<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_Manage.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_ODocument_Document_Manage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
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
      <div style="width:73; height:27px; cursor:pointer;">新建公文</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicon"><a href="Document_Manage.aspx" class="a">
      <div style="width:73; height:27px;cursor:pointer;">管理公文</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid; border-top:none">
        <tr>
          <td bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="40" height="30">&nbsp;类别：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="0">所有流程</asp:ListItem>
                    </asp:DropDownList></td>
                <td align="right">审批状态：</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem Value="">所有状态</asp:ListItem>
                                <asp:ListItem Value="0">审批未通过</asp:ListItem>
                                <asp:ListItem Value="2">审批中</asp:ListItem>
                                <asp:ListItem Value="3">己结束</asp:ListItem>
                            </asp:DropDownList></td>
                <td>&nbsp;</td>
                <td colspan="2"><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
ControlToValidate="TextBox1" ErrorMessage="开始日期格式不正确。"
 
                                
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="TextBox2" ErrorMessage="结束日期格式不正确。" 
                                
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$"></asp:RegularExpressionValidator>&nbsp;</td>
              </tr>
              <tr>
                <td height="30">&nbsp;时间：</td>
                <td width="200"><asp:TextBox ID="TextBox1" runat="server" Width="64px"
onpaste= "return   false "></asp:TextBox><img style="cursor:pointer" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_TextBox1')" src="../../image/icon5.gif" />&nbsp;
－<asp:TextBox
                                ID="TextBox2" runat="server" Width="64px" 
onpaste= "return   false "></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_TextBox2')"/></td>
                <td width="65" align="right">文号：</td>
                <td width="74"><asp:TextBox ID="TextBox3" runat="server" Width="37px"></asp:TextBox></td>
                <td width="72" align="right">公文名称：</td>
                <td width="149"><label>
                  <asp:TextBox ID="TextBox4" Width="100" runat="server"></asp:TextBox>
                </label></td>
                <td>&nbsp; <asp:ImageButton ID="ImageButton1"
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
          <td width="50" align="center" bgcolor="#f6f6f6"><strong>拟稿人</strong></td>
          <td width="60" align="center" bgcolor="#f6f6f6"><strong>审批状态</strong></td>
          <td width="132" align="center" bgcolor="#f6f6f6"><strong>附件</strong></td>
          <td width="100" align="center" bgcolor="#f6f6f6"><strong>开始时间</strong></td>
          <td width="80" align="center" bgcolor="#f6f6f6"><strong>操作</strong></td>
        </tr>
         <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr>
          <td align="center" bgcolor="#FFFFFF"><%#Eval("b_id") %></td>
          <td height="30" align="left" bgcolor="#FFFFFF">&nbsp;<a href="Document_View.aspx?lid=<%#Tunnel.Data.DESEncrypt.Encrypt(Eval("b_id").ToString()) %>" target="_blank"><%#Eval("b_title")%></a></td>
          <td align="center" bgcolor="#FFFFFF"><%#getUserName(Eval("b_user").ToString())%></td>
          <td align="center" bgcolor="#FFFFFF">&nbsp;<%#getState(Eval("b_state").ToString()) %></td>
          <td align="center" bgcolor="#FFFFFF"><%#getFile(Eval("b_file").ToString()) %></td>
          <td align="center" bgcolor="#FFFFFF"><%#Eval("b_time", "{0:yy-MM-dd HH:mm:ss}")%></td>
          <td align="center" bgcolor="#FFFFFF"><a href="Document_FlowView.aspx?lid=<%#Eval("b_id") %>" target="_blank">流程图</a> <%#GetMenu(Eval("b_id").ToString(), Eval("b_state").ToString(), Eval("b_user").ToString(), Eval("b_sort").ToString())%></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
          <td height="30" colspan="7" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid"><webdiyer:aspnetpager id="AspNetPager1" runat="server" firstpagetext="首页" lastpagetext="尾页"
            nextpagetext="下一页" prevpagetext="上一页" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:aspnetpager></td>
        </tr>
      </table></td>
  </tr>
</table>
</asp:Content>
