<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Form_Design.aspx.cs" ValidateRequest="false" Inherits="SystemManage_Tunnel_FromDesign" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>表单智能设计器</title>
    <script src="../../javascript/ccorrect_btn.js"></script>
<script Language="JavaScript">
self.moveTo(0,0);
self.resizeTo(screen.availWidth,screen.availHeight);
self.focus();

var form_id = "<%=Request.Params["form_id"] %>";
function CheckForm()
{


  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT'); //获得表单设计器的顶层对象FCK，该方法定义位置fckeditorapi.js第47行 by dq 090521
  var FORM_HTML = FCK.EditingArea.Window.document.body.innerHTML;

  if(FORM_HTML == "")
  {
  	alert("表单内容不能为空！");
    return (false);
  }
  return (true);
}

function myclose()
{
 msg='您确定关闭表单设计器？';
 if(window.confirm(msg))
 {
    window.close();
 }   
}
var size={
	textfield_w:320,textfield_h:160,
	textarea_w:320,textarea_h:190,
	listmenu_w:320,listmenu_h:300,
	checkbox_w:320,checkbox_h:120,
	calendar_w:320,calendar_h:120,
	auto_w:320,auto_h:230,
	calc_w:420,calc_h:200,
	listview_w:420,listview_h:293,
	user_w:330,user_h:150,
	sign_w:330,sign_h:170,
	data_w:420,data_h:290,
	fetch_w:420,fetch_h:290
};

//--- 单行输入框（新） ---
function td_textfield() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT'); //获得表单设计器的顶层对象FCK，该方法定义位置fckeditorapi.js第47行 by dq 090521
  FCK.Commands.GetCommand("td_textfield").Execute(); //仿照fcktoolbarbutton.js第71行的写法 by dq 090521
}

//--- 宏控件（新） ---
function td_auto() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT'); //获得表单设计器的顶层对象FCK，该方法定义位置fckeditorapi.js第47行 by dq 090521
  FCK.Commands.GetCommand("td_auto").Execute(); //仿照fcktoolbarbutton.js第71行的写法 by dq 090521
}

//--- 计算控件（新） ---
function td_calcu() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT'); //获得表单设计器的顶层对象FCK，该方法定义位置fckeditorapi.js第47行 by dq 090521
  FCK.Commands.GetCommand("td_calcu").Execute(); //仿照fcktoolbarbutton.js第71行的写法 by dq 090521
}

//--- 列表控件（新） ---
function td_listview() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_listview").Execute(); 
}

//--- 日历控件（新） ---
function td_calendar() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_calendar").Execute(); 
}

//--- 部门人员控件（新） ---
function td_user() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_user").Execute(); 
}

//--- 签章控件（新） ---
function td_sign() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_sign").Execute(); 
}

//--- 下拉列表控件（新） ---
function td_listmenu() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_listmenu").Execute(); 
}

//--- 选择框控件（新） ---
function td_checkbox() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_checkbox").Execute(); 
}

//--- 多行输入框控件（新） ---
function td_textarea() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_textarea").Execute(); 
}

//--- 数据选择控件（新） ---
function td_data_select() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_data_select").Execute(); 
}

//--- 数据获取控件（新） ---
function td_data_fetch() {
  var FCK = FCKeditorAPI.GetInstance('FORM_CONTENT');
  FCK.Commands.GetCommand("td_data_fetch").Execute(); 
}

function cool_control(ctrl_name,scroll_flag)
{
	var URL=ctrl_name+".asp";
	var w=eval("size."+ctrl_name+"_w");
	var h=eval("size."+ctrl_name+"_h");
  loc_x=document.body.scrollLeft+event.clientX-event.offsetX-300;
  loc_y=document.body.scrollTop+event.clientY-event.offsetY+62;
  window.showModalDialog(URL,self,"edge:raised;scroll:"+scroll_flag+";status:0;help:0;resizable:1;dialogWidth:"+w+"px;dialogHeight:"+h+"px;dialogTop:"+loc_y+"px;dialogLeft:"+loc_x+"px");
}

function checkClose()
{  
  if(event.clientX>document.body.clientWidth-20 && event.clientY<0||event.altKey)
    window.event.returnValue='您确定退出表单设计器吗';   
}
</script>
</head>
<body leftmargin="0" topmargin="0" onbeforeunload="checkClose();">
    <form id="form1" runat="server">
    <div>
<table width="100%" height="100%" class="TableBlock" align="center">
 <tr bgcolor="#DDDDDD">
   <td class="TableHeader" colspan="2" height="20">
    &nbsp;表单智能设计器：首先，将网页设计工具或Word编辑好的表格框架粘贴到表单设计区。然后，创建表单控件。
   </td>
 </tr>
 <tr bgcolor="#DDDDDD">
  <td bgcolor="#DDDDDD" width="100%" valign="top">
      <fckeditorv2:fckeditor id="FORM_CONTENT" runat="server" height="500px"></fckeditorv2:fckeditor>
  </td>
   <td valign="top" align="center">
     <table width="120" border="0" class="TableBlock" align="center">
      <tr class="TableHeader"><td align="center">表单控件</td></tr>
      <tr class="TableData">
      	<td align="center">
      	<button style="width:120px;text-Align:left" onClick="td_textfield()"><img src="../../image/form/textfield.gif" height=20 width=20 align=absmiddle>单行输入框</button><br>
        <button style="width:120px;text-Align:left" onClick="td_textarea()"><img src="../../image/form/textarea.gif" height=20 width=20 align=absmiddle>多行输入框</button><br>
        <button style="width:120px;text-Align:left" onClick="td_listmenu()"><img src="../../image/form/listmenu.gif" height=20 width=20 align=absmiddle>下拉菜单</button><br>
        <button style="width:120px;text-Align:left" onClick="td_checkbox()"><img src="../../image/form/checkbox.gif" height=20 width=20 align=absmiddle>选择框</button><br>
<%--        <button style="width:120px;text-Align:left" onClick="td_listview()"><img src="../../image/form/listview.gif" height=20 width=20 align=absmiddle>列表控件</button><br>--%>
        <button style="width:120px;text-Align:left" onClick="td_auto()"><img src="../../image/form/auto.gif" height=20 width=20 align=absmiddle>宏控件</button><br>
        <button style="width:120px;text-Align:left" onClick="td_calendar()"><img src="../../image/form/calendar.gif" height=20 width=20 align=absmiddle>日历控件</button><br>
        <%--//<button style="width:120px;text-Align:left" onClick="td_calcu()"><img src="../../image/form/calc.gif" height=20 width=20 align=absmiddle>计算控件</button><br>--%>
        <button style="width:120px;text-Align:left" onClick="td_user()"><img src="../../image/form/user.gif" height=20 width=20 align=absmiddle>人员控件</button><br>
<%--        <button style="width:120px;text-Align:left" onClick="td_sign()"><img src="../../image/form/sign.gif" height=20 width=20 align=absmiddle>签章控件</button><br>
        <button style="width:120px;text-Align:left" onClick="td_data_select()"><img src="../../image/form/data.gif" height=20 width=20 align=absmiddle>数据选择控件</button><br>
        <button style="width:120px;text-Align:left" onClick="td_data_fetch()"><img src="../../image/form/data.gif" height=20 width=20 align=absmiddle>表单数据控件</button>
--%>        </td></tr>
     </table><input type="hidden" name="CLOSE_FLAG"  value="">
     <br>
     <table width="120" border="0" class="TableBlock" align="center">
      <tr class="TableHeader"><td align="center">保存与退出</td></tr>
      <tr class="TableData">
      	<td align="center">
              <asp:Button ID="Button1" runat="server" Text="保存表单" Height="30px" Width="120px" Font-Bold="True" OnClick="Button1_Click" /><br>
        <button style="width:120px;height:30px;text-Align:center" onclick='window.open("Tunnel_FromView.aspx?FORM_ID=<%=Request.Params["form_id"] %>","form_view_10","menubar=0,toolbar=0,status=0,resizable=1,left=0,top=0,scrollbars=1,width="+(screen.availWidth-10)+",height="+(screen.availHeight-50)+"\"")'><b>预览表单</b></button><br>
        <button style="width:120px;height:30px;text-Align:center" onClick="myclose()"><b>关闭设计器</b></button></td></tr>
        </td>
      </tr>
      <tr class="TableData"><td align="center"></td></tr>
    </table>
    </div>
    </form>
</body>
</html>