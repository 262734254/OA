<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Flow_SelectLeft.aspx.cs" Inherits="SystemManage_BaseData_Flow_SelectLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="../../javascript/dtree.js"></script>
<style type="text/css"> 
<!-- 
*{margin:0;padding:0;border:0;} 
body { 
background:#F0F0F0;
font-family: arial, 宋体, serif; 
font-size:12px; 
} 
#nav { 
width:180px; 
line-height: 24px; 
list-style-type: none; 
border:1px #ccc solid;
text-align:left; 
/*定义整个ul菜单的行高和背景色*/ 
} 
/*==================一级目录===================*/ 
#nav a {  
display: block;  
/*Width(一定要)，否则下面的Li会变形*/ 
} 
#nav a strong{  
display: block;  
padding-left:20px; 
/*Width(一定要)，否则下面的Li会变形*/ 
} 
#nav li {  
width: 180px;
background:#e3eef2; /*一级目录的背景色*/ 
border-bottom:#FFF 1px solid; /*下面的一条白边*/ 
float:left; 
/*float：left,本不应该设置，但由于在Firefox不能正常显示 
继承Nav的width,限制宽度，li自动向下延伸*/ 
} 
#nav li a:hover{ 
background:#ccc; /*一级目录onMouseOver显示的背景色*/ 
} 
#nav a:link { 
color:#000; text-decoration:none; 
} 
#nav a:visited { 
color:#000;text-decoration:none; 
} 
#nav a:hover { 
color:#000;text-decoration:none;font-weight:bold; 
} 
/*==================二级目录===================*/ 
#nav li ul { 
list-style:none; 
text-align:left; 
} 
#nav li ul li{ 
background: #fff; /*二级目录的背景色*/ 
border-bottom:1px #ccc solid;
} 
#nav li ul a{ 

/* padding-left二级目录中文字向右移动，但Width必须重新设置=(总宽度-padding-left)*/ 
} 
/*下面是二级目录的链接样式*/ 
#nav li ul a:link { 
color:#000; text-decoration:none; 
} 
#nav li ul a:visited { 
color:#000;text-decoration:none; 
} 
#nav li ul a:hover { 
color:#000; 
text-decoration:none; 
font-weight:blod; 
background:#bee4fd; 
/* 二级onmouseover的字体颜色、背景色*/ 
} 
/*==============================*/ 
#nav li:hover ul { 
left: auto; 
} 
#nav li.sfhover ul { 
left: auto; 
} 
#content { 
clear: left; 
} 
#nav ul.collapsed { 
display: none; 
} 
--> 
#PARENT{ 
width:180px; 
padding-left:2px; 
} 
#title{width:180px;text-align:left;padding-left:2px;font-size:18px;height:30px;padding-top:5px}
.int{ border:1px #ccc solid}
</style>
<script type="text/javascript">
    function showsearch(obj){
        if(obj.value!=""&&obj.value!="按用户名或姓名搜索"){
            parent.rightFrame.location.href="Flow_SelectRight.aspx?act=search&to_id=<%=Request.Params["to_id"] %>&to_name=<%=Request.Params["to_name"]%>&type=<%=Request.Params["type"]%>&Competence=<%=Request.Params["Competence"] %>&idh="+obj.value;}
    }
    function cleard(obj){
        if(obj.value=="按用户名或姓名搜索")
            obj.value="";
    }
    function full(obj){
        if(obj.value==""){
            obj.value="按用户名或姓名搜索";
        }
    }
    
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div><div id="title"><asp:TextBox ID="TextBox1" CssClass="int" runat="server" onkeyup="showsearch(this)" onfocus="cleard(this)" onblur="full(this)" Width="175px" Height="20px">按用户名或姓名搜索</asp:TextBox></div>
<div id="PARENT"> 
<ul id="nav"> 
        <li><a href="#" target="mainFrame" onclick="DoMenu('ChildMenu1')"><strong>> 按部门选择</strong></a> 
            <ul id="ChildMenu1" class="collapsed">
                    <li>
                    <table id="treetable" cellpadding="0" cellspacing="0" border="0" width="180px" align="left">
                    <tr>
                    <td style="padding-left:20px">
                        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Contacts" NodeIndent="10">
                            <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                            <HoverNodeStyle Font-Underline="False" />
                            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                        </asp:TreeView>
                    </td></tr></table>
                     </li>
            </ul> 
        </li>  
        <li><a href="#" target="mainFrame" onclick="DoMenu('ChildMenu2')"><strong>> 按角色选择</strong></a> 
            <ul id="ChildMenu2" class="collapsed">
                <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <li style="padding-left:20px; width:160px"><a href="Flow_SelectRight.aspx?act=jiao&idh=<%#Eval("j_id") %>&to_id=<%=Request.Params["to_id"] %>&to_name=<%=Request.Params["to_name"]%>&type=<%=Request.Params["type"]%>&Competence=<%=Request.Params["Competence"] %>" target="rightFrame"><%#Eval("j_name") %></a></li> 
                </ItemTemplate>
                </asp:Repeater>
            </ul> 
        </li> 
            <li><a href="#" target="mainFrame" onclick="DoMenu('ChildMenu3')"><strong>> 按项经部选择</strong></a> 
            <ul id="ChildMenu3" class="collapsed">
                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                <ItemTemplate>
                    <li style="padding-left:20px; width:160px"><a href="Flow_SelectRight.aspx?act=xian&idh=<%#Eval("id") %>&to_id=<%=Request.Params["to_id"] %>&to_name=<%=Request.Params["to_name"]%>&type=<%=Request.Params["type"]%>&Competence=<%=Request.Params["Competence"] %>"target="rightFrame"><%#Eval("typename")%></a></li> 
                </ItemTemplate>
                </asp:Repeater>
            </ul> 
        </li> 
               
</ul> 
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>" 
                    SelectCommand="select * from dbo.Tunnel_xjbType"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
        SelectCommand="select * from Tunnel_jiaose order by JSSort desc"></asp:SqlDataSource>
</div> 
    </div>
    </form>
</body>
</html>
<script type="text/javascript"><!-- 
var LastLeftID = ""; 
function menuFix() { 
var obj = document.getElementById("nav").getElementsByTagName("li"); 

for (var i=0; i<obj.length; i++) { 
obj[i].onmouseover=function() { 
this.className+=(this.className.length>0? " ": "") + "sfhover"; 
} 
obj[i].onMouseDown=function() { 
this.className+=(this.className.length>0? " ": "") + "sfhover"; 
} 
obj[i].onMouseUp=function() { 
this.className+=(this.className.length>0? " ": "") + "sfhover"; 
} 
obj[i].onmouseout=function() { 
this.className=this.className.replace(new RegExp("( ?|^)sfhover\\b"), ""); 
} 
} 
} 
function DoMenu(emid) 
{ 
var obj = document.getElementById(emid); 
obj.className = (obj.className.toLowerCase() == "expanded"?"collapsed":"expanded"); 
if((LastLeftID!="") && (emid!=LastLeftID)) //关闭上一个Menu 
{ 
document.getElementById(LastLeftID).className = "collapsed"; 
} 
LastLeftID = emid; 
} 
function GetMenuID() 
{ 
var MenuID=""; 
var _paramStr = new String(window.location.href); 
var _sharpPos = _paramStr.indexOf("#"); 

if (_sharpPos >= 0 && _sharpPos < _paramStr.length - 1) 
{ 
_paramStr = _paramStr.substring(_sharpPos + 1, _paramStr.length); 
} 
else 
{ 
_paramStr = ""; 
} 

if (_paramStr.length > 0) 
{ 
var _paramArr = _paramStr.split("&"); 
if (_paramArr.length>0) 
{ 
var _paramKeyVal = _paramArr[0].split("="); 
if (_paramKeyVal.length>0) 
{ 
MenuID = _paramKeyVal[1]; 
} 
} 
/* 
if (_paramArr.length>0) 
{ 
var _arr = new Array(_paramArr.length); 
} 

//取所有#后面的，菜单只需用到Menu 
//for (var i = 0; i < _paramArr.length; i++) 
{ 
var _paramKeyVal = _paramArr[i].split('='); 

if (_paramKeyVal.length>0) 
{ 
_arr[_paramKeyVal[0]] = _paramKeyVal[1]; 
} 
} 
*/ 
} 

if(MenuID!="") 
{ 
DoMenu(MenuID) 
} 
} 
GetMenuID(); //*这两个function的顺序要注意一下，不然在Firefox里GetMenuID()不起效果 
menuFix(); 
function Button1_onclick() {
    window.parent.frames.mainFrame.location.href='Tunnel_LiuAdd.aspx';
}

--></script> 

