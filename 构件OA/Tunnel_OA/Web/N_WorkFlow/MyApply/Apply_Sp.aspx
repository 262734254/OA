<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Apply_Sp.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="N_WorkFlow_MyApply_Apply_Sp" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Header1" runat="server" ContentPlaceHolderID="Header">
<link href="../../Css/Css.css" rel="stylesheet" type="text/css" />
        <script src="../../javascript/Calendarform.js" type="text/javascript"></script>
        <script src="../../javascript/utility.js" type="text/javascript"></script>
        <script src="../../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            function sudate(){
                if(document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value!=""||document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value!=""){
                    var reg=/^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$/;
                    if(!reg.test(document.getElementById("ctl00_ContentPlaceHolder1_TextBox1").value)){
                        alert("开始日期格式不正确");return false;
                    }   
                    if(!reg.test(document.getElementById("ctl00_ContentPlaceHolder1_TextBox2").value)){
                        alert("结束日期格式不正确");return false;
                    }         
                }
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
                .style1
    {
        width: 58px;
    }
</style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
        <tr>
          <td bgcolor="#f6f6f6"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="30" class="style1">&nbsp;时间：</td>
                <td width="240" align="left"><asp:TextBox ID="TextBox1" runat="server" Width="54px"
onpaste= "return   false "></asp:TextBox><img style="cursor:pointer" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_TextBox1')" src="../../image/icon5.gif" />&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="54px" 
onpaste= "return false "></asp:TextBox><img style="cursor:pointer" src="../../image/icon5.gif" onclick="td_calendar(this,'ctl00_ContentPlaceHolder1_TextBox2')"/></td>
                <td width="65" align="right">文号：</td>
                <td width="74"><asp:TextBox ID="TextBox3" runat="server" Width="57px"></asp:TextBox></td>
                <td width="72" align="right">名称：</td>
                <td width="149"><label>
                  <asp:TextBox ID="TextBox4" runat="server" Width="197px"></asp:TextBox>
                </label></td>
                <td>&nbsp; <asp:ImageButton ID="ImageButton1"
                    runat="server" ImageUrl="../../images/search.gif" 
                        onclick="ImageButton1_Click" OnClientClick="return sudate()" /></td>
              </tr>
          </table></td>
        </tr>
      </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
        <tr>
          <td width="40" align="center" bgcolor="#f6f6f6"><strong>文号</strong></td>
          <td height="30" align="center" bgcolor="#f6f6f6"><strong>名称</strong></td>
          <td width="60" align="center" bgcolor="#f6f6f6"><strong>发布人</strong></td>
          <td width="60" align="center" bgcolor="#f6f6f6"><strong>审批状态</strong></td>
          <td width="152" align="center" bgcolor="#f6f6f6"><strong>附件</strong></td>
          <td width="120" align="center" bgcolor="#f6f6f6"><strong>开始时间</strong></td>
          <td width="80" align="center" bgcolor="#f6f6f6"><strong>操作</strong></td>
        </tr>
         <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr>
          <td align="center" bgcolor="#FFFFFF"><%#Eval("b_id") %></td>
          <td height="30" align="left" bgcolor="#FFFFFF">&nbsp;<%#getTitleUrl(Eval("b_id").ToString(),Eval("b_title").ToString(),Eval("b_stype").ToString()) %></td>
          <td align="center" bgcolor="#FFFFFF"><%#getUserName(Eval("b_user").ToString())%></td>
          <td align="center" bgcolor="#FFFFFF">&nbsp;<%#getState(Eval("b_state").ToString()) %></td>
          <td align="center" bgcolor="#FFFFFF"><%#getFile(Eval("b_file").ToString()) %></td>
          <td align="center" bgcolor="#FFFFFF"><%#Eval("b_time", "{0:yyyy-MM-dd HH:mm:ss}")%></td>
          <td align="center" bgcolor="#FFFFFF"><%#GetMenu(Eval("b_id").ToString(), Eval("b_state").ToString(), Eval("b_user").ToString(), Eval("b_sort").ToString(),Eval("b_stype").ToString())%></td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
          <td height="30" colspan="7" align="center" bgcolor="#e6f7ff" style="border-bottom:1px #6f97b1 solid"><webdiyer:aspnetpager id="AspNetPager1" PageSize="28" runat="server" firstpagetext="首页" lastpagetext="尾页"
            nextpagetext="下一页" prevpagetext="上一页" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:aspnetpager></td>
        </tr>
      </table></td>
  </tr>
</table>
</asp:Content>