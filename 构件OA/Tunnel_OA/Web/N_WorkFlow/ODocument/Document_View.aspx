<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Document_View.aspx.cs" Inherits="Workflow_Tunnel_WordView" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<script type="text/javascript" src="../../javascript/Calendarform.js"></script>
<script type="text/javascript" src="../../javascript/utility.js"></script>
<script type="text/javascript" src="../../javascript/jquery-1.3.2.min.js"></script>
<title></title>
<script type="text/javascript">

var YOffset=0; 
var staticYOffset=0; 
var menuHeight=50; // Must be a multiple of 5! 

var lastY = 0;
var slipMenu ;

/**
* 菜单滑出
*/
function moveOut() { 
if (window.cancel) { 
cancel=""; 
} 

if (window.moving2) { 
clearTimeout(moving2); 
moving2=""; 
} 

if (slipMenu.style.pixelTop<0) { 
//此处的5要根据menuHeight来定，即两者要能整除
slipMenu.style.pixelTop += (5%menuHeight); 
moving1 = setTimeout('moveOut()', 20) ;
} else { 
clearTimeout(moving1) ;
} 
}; 

/**
* 菜单隐藏
*/
function moveBack() { 
cancel = moveBack1() ;
} 

/**
* 菜单隐藏
*/
function moveBack1() { 
if (window.moving1) { 
clearTimeout(moving1) ;
} 

if (slipMenu.style.pixelTop>(-menuHeight)) { 
slipMenu.style.pixelTop -= (5%-menuHeight); 
moving2 = setTimeout('moveBack1()', 20);
} else { 
clearTimeout(moving2) ;
} 
}; 

function makeStatic(mode) { 
winY = document.body.scrollTop;
var NM=slipMenu.style ;

if (mode=="smooth") { 
if (winY!=lastY) { 
smooth = .2 * (winY - lastY); 
if(smooth > 0) smooth = Math.ceil(smooth); 
else smooth = Math.floor(smooth); 
NM.pixelTop+=smooth; 
lastY = lastY+smooth; 
} 
setTimeout('makeStatic("smooth")', 1) 
} 
else if (mode=="advanced") { 
if (winY>YOffset-staticYOffset) { 
NM.pixelTop=winY+staticYOffset ; 
} 
else { 
NM.pixelTop=YOffset ;
} 
setTimeout('makeStatic("advanced")', 1) 
} 
} 


/**
* 初始化
*/
function init() { 
slipMenu = document.getElementById("slipMenu");
slipMenu.style.pixelTop = -menuHeight; 
slipMenu.style.visibility = "visible" ;
} 

window.onload = init;

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
    <link href="../../Css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
<div onmouseover="moveOut();" onmouseout="moveBack();" id="slipMenu" style="visibility:hidden;position:absolute;top=-50;left:200px;z-index=20; width:800px">
<TABLE border="0" cellspacing="0" cellpadding="0" width="100%" height="60" bgcolor="#f8f8f8">
<tr height="1" bgcolor="S6B7F9"><td colspan="8"></td></tr>
<TR height="48">
<td width="1" bgcolor="S6B7F9"></td>
<TD width="8%"><input id="Checkbox5" type="checkbox" checked="checked" onclick="shows(this,'forms')"/>表单</TD>
<TD width="10%"><input id="Checkbox1" type="checkbox" checked="checked" onclick="shows(this,'fujian')"/>公共附件区</TD>
<TD width="10%"><input id="Checkbox2" type="checkbox" checked="checked" onclick="shows(this,'advis')"/>审批意见</TD>
<TD width="10%"><input id="Checkbox3" type="checkbox" checked="checked" onclick="shows(this,'liucheng')" />流程图</TD>
<TD width="10%"><input id="Checkbox4" type="checkbox" checked="checked" onclick="shows(this,'closed')" />关闭按钮</TD>
<TD></TD>
<td width="1" bgcolor="S6B7F9"></td>
</TR>
<tr height="1" bgcolor="S6B7F9"><td colspan="8"></td></tr>
<TR height="10">
<TD colspan="8" align="left" bgcolor="#ffffff">&nbsp;</TD>
</TR>
</TABLE>
</div>
    <table border="0" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 100%">
    <tr>
        <td align="left">
        <br/>
        <br/> <br/>
<table border="0" id="forms" align="center" cellpadding="0" cellspacing="0" style="width: 85%">
    <tr>
        <td align="left" style="height: 46px;" colspan="2">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
    </tr>
    </table><br/>
    <%if(!"".Equals(formfile)&&!"无附件".Equals(formfile)){ %>
    <table border="1" id="fujian" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 85%">
    <tr>
        <td align="left" colspan="2" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
            &nbsp;附件区</td>
    </tr>
    <tr>
        <td align="left" colspan="2" rowspan="1" style="height: 30px; width: 662px;">
            <%=formfile %></td>
    </tr> 
    </table><br/>
    <%} if (!"".Equals(formdvice)){ %>
    
            <table border="1" id="advis" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 85%">
                <tr>
                    <td align="left" colspan="2" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
                        &nbsp;审批意见</td>
                </tr>
                <%=formdvice%>
            </table><br/>
            <%}if(isliu){ %>
       <table border="1" id="liucheng" align="center" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" bordercolorlight="#DBDBDB" style="width: 85%">
    <tr>
        <td align="left" colspan="3" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
            &nbsp;流程图</td>
    </tr><%i = 1;%><%=toptb%>
           <asp:Repeater ID="Repeater1" runat="server">
           <ItemTemplate>
           <tr>
                <td align="center" style="height: 30px; width: 10%;">第 <font color=red><%=(++i) %></font> 步</td>
                <td align="left" style="height: 30px; width: 30%">&nbsp;&nbsp;<%#getNum(Eval("e_bid").ToString(),Eval("e_nextbid").ToString()) %><%#getname(Eval("e_bid").ToString()) %></td>
                <td align="left" style="height: 50%">&nbsp;&nbsp;<strong style="color:Red"><%#getUname(Eval("e_user").ToString()) %> 主办</strong> [<%#getNum(Eval("e_bid").ToString(),Eval("e_nextbid").ToString(),1) %>]
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：<%#Eval("e_time") %>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结束于：<%#Eval("e_endtime") %>
                </td>
            </tr> 
            </ItemTemplate>
           </asp:Repeater>
           <%=nextb%>           
           <%if (isend)
         { %>
       <tr>
        <td align="left" colspan="3" rowspan="1" style="height: 30px; background-color: #e8e8e8; font-weight: bold; width: 662px;">
            &nbsp;流程结束</td>
    </tr>
    <% }%>
    </table><br/>
    <%} %>
</td>
</tr>
</table>
    </div>
        <table id="closed" border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td align="center">
                    <input id="Button1" class="butt" type="button" value="关 闭" onclick="window.close();" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
