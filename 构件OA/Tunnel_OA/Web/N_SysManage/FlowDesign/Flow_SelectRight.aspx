<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Flow_SelectRight.aspx.cs" Inherits="SystemManage_BaseData_Flow_SelectLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../css/group.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="../../javascript/dtree.js"></script>
<style type="text/css"> 
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
width: 160px; 
display: block; 
padding-left:20px; 
/*Width(一定要)，否则下面的Li会变形*/ 
} 
#nav li { 
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
padding-left:20px; 
width:160px; 
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
font-weight:bold; 
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
#PARENT{ 
width:180px; 
padding-left:2px; 
} 
#title{width:100%;text-align:center;font-size:18px;height:30px;padding-top:5px}
.int{ border:1px #ccc solid}
</style>
<script type="text/javascript">
var allElements=document.getElementsByTagName("*");
function isUndefined(variable) {
	return typeof variable == 'undefined' ? true : false;
}
function borderize_on(targetelement)
{
   if(targetelement.className.indexOf("TableRowActive") < 0)
      targetelement.className = "TableRowActive " + targetelement.className;
}

function borderize_off(targetelement)
{
   if(targetelement.className.indexOf("TableRowActive") >= 0)
      targetelement.className = targetelement.className.substr(15);
}
var is_moz = (navigator.product == 'Gecko') && userAgent.substr(userAgent.indexOf('firefox') + 8, 3);
function $(obj){
    return document.getElementById(obj);
}
function getOpenner()
{
   if(is_moz)
      return parent.document;
   else
      return parent.dialogArguments.document;
}
var parent_window = getOpenner();
var to_name = parent_window.getElementById('<%=Request.Params["to_name"] %>');
var to_id = parent_window.getElementById('<%=Request.Params["to_id"] %>');
var to_tdmail = parent_window.getElementById("ctl00_ContentPlaceHolder1_td_tomail");
var type='<%=Request.Params["type"] %>';
var innerHTMLtext = parent_window.getElementById("innerHTMLtext");
    function revalue(priv_id){
       TO_VAL=to_id.value;
      targetelement=$(priv_id);
      priv_name = targetelement.title;
      priv_mail = targetelement.name;
      priv_email = priv_mail + "[" + priv_name + "];";
      if (to_name.id == "ctl00_ContentPlaceHolder1_tb_Email") {
          if (TO_VAL.indexOf("," + priv_id + ",") > 0 || TO_VAL.indexOf(priv_id + ",") == 0) {
              if (TO_VAL.indexOf(priv_id + ",") == 0) {
                  to_id.value = to_id.value.replace(priv_id + ",", "");
                  to_name.value = to_name.value.replace(priv_email, "");
              }
              if (TO_VAL.indexOf("," + priv_id + ",") > 0) {
                  to_id.value = to_id.value.replace("," + priv_id + ",", ",");
                  to_name.value = to_name.value.replace(";" + priv_email, ";");
              }
          }
          else {
              to_id.value += priv_id + ",";
              to_name.value += priv_email;
          }
      }
      else {
          if (to_name.id == "ctl00_ContentPlaceHolder1_tb_toname") {
              if (TO_VAL.indexOf("," + priv_id + ",") > 0 || TO_VAL.indexOf(priv_id + ",") == 0) {
                  if (TO_VAL.indexOf(priv_id + ",") == 0) {
                      to_id.value = to_id.value.replace(priv_id + ",", "");
                      to_name.value = to_name.value.replace(priv_name + ",", "");
                      innerHTMLtext.innerHTML = priv_name + '<IMG id=' + priv_name + priv_id + ' onclick=' + "'" + 'removeimg("' + priv_name + '","' + priv_id + '");' + "'" + ' src="../../image/remove.png">,';
                      to_tdmail.innerHTML = to_tdmail.innerHTML.replace(innerHTMLtext.innerHTML, "");
                  }
                  if (TO_VAL.indexOf("," + priv_id + ",") > 0) {
                      to_id.value = to_id.value.replace("," + priv_id + ",", ",");
                      to_name.value = to_name.value.replace("," + priv_name + ",", ",");
                      innerHTMLtext.innerHTML = "," + priv_name + '<IMG id=' + priv_name + priv_id + ' onclick=' + "'" + 'removeimg("' + priv_name + '","' + priv_id + '");' + "'" + ' src="../../image/remove.png">,';
                      to_tdmail.innerHTML = to_tdmail.innerHTML.replace(innerHTMLtext.innerHTML, ",");
                  }
              }
              else {
                  //to_tdmail.innerHTML = to_tdmail.innerHTML + priv_name + '<IMG id=' + priv_name + priv_id + ' onclick=removeimg(' + priv_id + '); src="http://localhost:50524/image/remove.png">,';
                  to_tdmail.innerHTML = to_tdmail.innerHTML + priv_name + '<IMG id=' + priv_name + priv_id + ' onclick=' + "'" + 'removeimg("' + priv_name + '","' + priv_id + '");' + "'" + ' src="../../image/remove.png">,';
                  to_id.value += priv_id + ",";
                  to_name.value += priv_name + ",";
              }
          }
          else {
            if(type!="single"){
                  if (TO_VAL.indexOf("," + priv_id + ",") > 0 || TO_VAL.indexOf(priv_id + ",") == 0) {
                      if (TO_VAL.indexOf(priv_id + ",") == 0) {
                          to_id.value = to_id.value.replace(priv_id + ",", "");
                          to_name.value = to_name.value.replace(priv_name + ",", "");
                      }
                      if (TO_VAL.indexOf("," + priv_id + ",") > 0) {
                          to_id.value = to_id.value.replace("," + priv_id + ",", ",");
                          to_name.value = to_name.value.replace("," + priv_name + ",", ",");
                      }
                  }
                  else {
                      to_id.value += priv_id + ",";
                      to_name.value += priv_name + ",";
                  } 
             }else{
                      to_id.value = priv_id;
                      to_name.value = priv_name;
             }
          }
      }
      
      
    }
 function add_all(flag)
 {
 if(type!="single"){
  if(isUndefined(flag))
     flag="";
  TO_VAL=to_id.value;
      for (step_i=0; step_i<allElements.length; step_i++)
      {
        if(allElements[step_i].className.indexOf("menulines"+flag)>=0)
        {
           user_id=allElements[step_i].id;
           user_name=allElements[step_i].title;
           user_mail = allElements[step_i].name;
           user_email = user_mail + "[" + user_name + "];";

           if (to_name.id == "ctl00_ContentPlaceHolder1_tb_Email") {
               if (TO_VAL.indexOf("," + user_id + ",") < 0 && TO_VAL.indexOf(user_id + ",") != 0) {
                   to_name.value += user_email;
                   to_id.value += user_id + ",";
                   borderize_on(allElements[step_i]);
               }
           }
           else {
               if (to_name.id == "ctl00_ContentPlaceHolder1_tb_toname") {
                   if (TO_VAL.indexOf("," + user_id + ",") < 0 && TO_VAL.indexOf(user_id + ",") != 0) {
                       to_id.value += user_id + ",";
                       to_name.value += user_name + ",";
                       to_tdmail.innerHTML = to_tdmail.innerHTML + user_name + '<IMG id=' + user_name + user_id + ' onclick=' + "'" + 'removeimg("' + user_name + '","' + user_id + '");' + "'" + ' src="../../image/remove.png">,';
                       borderize_on(allElements[step_i]);
                   }
               }
               else {
                   if (TO_VAL.indexOf("," + user_id + ",") < 0 && TO_VAL.indexOf(user_id + ",") != 0) {
                       to_id.value += user_id + ",";
                       to_name.value += user_name + ",";
                       borderize_on(allElements[step_i]);
                   }
               }
           }
        }
    }
  }
}
function del_all(flag) {
    if (isUndefined(flag))
        flag = "";

    for (step_i = 0; step_i < allElements.length; step_i++) {
        TO_VAL = to_id.value;
        TO_NAME = to_name.value;
        if (allElements[step_i].className.indexOf("menulines" + flag) >= 0) {
            user_id = allElements[step_i].id;
            user_name = allElements[step_i].title;
            user_mail = allElements[step_i].name;
            user_email = user_mail + "[" + user_name + "];";

            if (to_name.id == "ctl00_ContentPlaceHolder1_tb_Email") {
                if (TO_VAL.indexOf(user_id + ",") == 0) {
                    to_name.value = to_name.value.replace(user_email, "");
                    to_id.value = to_id.value.replace(user_id + ",", "");
                }
                else if (TO_VAL.indexOf("," + user_id) > 0) {
                    to_name.value = to_name.value.replace(";" + user_email, ";");
                    to_id.value = to_id.value.replace("," + user_id + ",", ",");
                }
            }
            else {
                if (to_name.id == "ctl00_ContentPlaceHolder1_tb_toname") {
                    if (TO_VAL.indexOf(user_id + ",") == 0) {
                        to_name.value = to_name.value.replace(user_name + ",", "");
                        to_id.value = to_id.value.replace(user_id + ",", "");
                        innerHTMLtext.innerHTML = user_name + '<IMG id=' + user_name + user_id + ' onclick=' + "'" + 'removeimg("' + user_name + '","' + user_id + '");' + "'" + ' src="../../image/remove.png">,';
                        to_tdmail.innerHTML = to_tdmail.innerHTML.replace(innerHTMLtext.innerHTML, "");
                    }
                    else if (TO_VAL.indexOf("," + user_id + ",") > 0) {
                        to_name.value = to_name.value.replace("," + user_name + ",", ",");
                        to_id.value = to_id.value.replace("," + user_id + ",", ",");
                        innerHTMLtext.innerHTML = "," + user_name + '<IMG id=' + user_name + user_id + ' onclick=' + "'" + 'removeimg("' + user_name + '","' + user_id + '");' + "'" + ' src="../../image/remove.png">,';
                        to_tdmail.innerHTML = to_tdmail.innerHTML.replace(innerHTMLtext.innerHTML, ",");
                    }
                }
                else {
                    if (TO_VAL.indexOf(user_id + ",") == 0) {
                        to_id.value = to_id.value.replace(user_id + ",", "");
                        to_name.value = to_name.value.replace(user_name + ",", "");
                    }
                    else if (TO_VAL.indexOf("," + user_id + ",") > 0) {
                        to_id.value = to_id.value.replace("," + user_id + ",", ",");
                        to_name.value = to_name.value.replace("," + user_name + ",", ",");
                    }
                }
            }
            borderize_off(allElements[step_i]);
        }
    }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<div id="PARENT"> 
<ul id="nav"> 
        <li><a href="#" onclick="add_all('1');"><strong>全部选择</strong></a></li> 
        <li><a href="#" onclick="del_all('1');"><strong>全部删除</strong></a> 
        </li>  
        <li><ul id="ChildMenu2">
            <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li <%#getShow(Eval("m_id").ToString())%>><a href="#" id='<%#Eval("m_ID") %>' class="menulines1" name='<%#Eval("m_mail") %>' onClick="revalue('<%#Eval("m_ID") %>')" title='<%#Eval("m_NAME") %>'><%#Eval("m_name") %></a></li> 
            </ItemTemplate>
            </asp:Repeater>    
            </ul> 
        </li>  
</ul> 
</div> 
<div style="width:180px;padding-left:5px;"> 
<br/><br/> 
</div>
    </div>
    </form>
</body>
</html>
<script type=text/javascript><!-- 
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

