<%@ Page Language="C#" AutoEventWireup="true" CodeFile="indexs.aspx.cs" Inherits="indexs" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/public.css" type="text/css" rel="stylesheet" />
    <link href="css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="JavaScript" type="text/javascript">
function initArray(){
this.length=initArray.arguments.length
for(var i=0;i<this.length;i++)
this[i+1]=initArray.arguments[i] }
// 显示服务器的当前时间
var OA_TIME = new Date();
function timeview()
{
  d=new initArray("星期日","星期一","星期二","星期三","星期四","星期五","星期六"); 
  year=OA_TIME.getYear()
  month=OA_TIME.getMonth()+1
  day=OA_TIME.getDate()
  timestr=OA_TIME.toLocaleString();
  timestr=timestr.substr(timestr.indexOf(":")-2);
  timestr=timestr+"　"+year+"年"+month+"月"+day+"日"+"　"+d[OA_TIME.getDay()+1]
  document.getElementById("time_area").innerHTML = timestr;
  OA_TIME.setSeconds(OA_TIME.getSeconds()+1);
  window.setTimeout( "timeview()", 1000 );
}


// 询问注销系统
function iflogout()
{
if(window.confirm('确定退出吗？'))
 {
  parent.parent.location="Login.aspx";        // 页面跳转
 }
}

// 询问退出系统
function ifexit()
{
if(window.confirm('确定退出吗？'))
 {
  window.open("exit.php","退出系统","height=0,width=0,top=0,left=0");   //  关闭当前窗口   
  parent.parent.close();                                                // 关闭当前窗口 
 }
}

// 返回首页
function GoTable()
{
  top.mainFrame.location="main.aspx";                    // 刷新帮助框架页
}

// <!--屏蔽鼠标右键开始-->
if (window.Event)
  document.captureEvents(Event.MOUSEUP);

function nocontextmenu()
{
 event.cancelBubble = true
 event.returnValue = false;

 return false;
}

function norightclick(e)
{
 if (window.Event)
 {
  if (e.which == 2 || e.which == 3)
   return false;
 }
 else
  if (event.button == 2 || event.button == 3)
  {
   event.cancelBubble = true
   event.returnValue = false;
   return false;
  }

}
document.oncontextmenu = nocontextmenu;  // for IE5+
document.onmousedown = norightclick;     // for all others
// <!--屏蔽鼠标右键结束-->

    </script>
    <script language="javascript"  type="text/javascript">  
<!--  
  
/**//*  
**    ==================================================================================================  
**    类名：CLASS_MSN_MESSAGE  
**    功能：提供类似MSN消息框  
**    示例：  
    ---------------------------------------------------------------------------------------------------  
  
            var MSG = new CLASS_MSN_MESSAGE("aa",200,120,"短消息提示：","您有1封消息","今天请我吃饭哈");  
                MSG.show();  
  
    ---------------------------------------------------------------------------------------------------  
**    作者：ttyp  
**    邮件：ttyp@21cn.com  
**    日期：2005-3-18  
**    ==================================================================================================  
**/  
  
  
/**//*  
*    消息构造  
*/  
function CLASS_MSN_MESSAGE(id,width,height,caption,title,message,target,action){  
    this.id     = id;  
    this.title  = title;  
    this.caption= caption;  
    this.message= message;  
    this.target = target;  
    this.action = action;  
    this.width    = width?width:200;  
    this.height = height?height:120;  
    this.timeout= 150;  
    this.speed    = 20; 
    this.step    = 1; 
    this.right    = screen.width -1;  
    this.bottom = screen.height; 
    this.left    = this.right - this.width; 
    this.top    = this.bottom - this.height; 
    this.timer    = 0; 
    this.pause    = false;
    this.close    = false;
    this.autoHide    = true;
}  
  
/**//*  
*    隐藏消息方法  
*/  
CLASS_MSN_MESSAGE.prototype.hide = function(){  
    if(this.onunload()){  

        var offset  = this.height>this.bottom-this.top?this.height:this.bottom-this.top; 
        var me  = this;  

        if(this.timer>0){   
            window.clearInterval(me.timer);  
        }  

        var fun = function(){  
            if(me.pause==false||me.close){
                var x  = me.left; 
                var y  = 0; 
                var width = me.width; 
                var height = 0; 
                if(me.offset>0){ 
                    height = me.offset; 
                } 
     
                y  = me.bottom - height; 
     
                if(y>=me.bottom){ 
                    window.clearInterval(me.timer);  
                    me.Pop.hide();  
                } else { 
                    me.offset = me.offset - me.step;  
                } 
                me.Pop.show(x,y,width,height);    
            }             
        }  

        this.timer = window.setInterval(fun,this.speed)      
    }  
}  
  
/**//*  
*    消息卸载事件，可以重写  
*/  
CLASS_MSN_MESSAGE.prototype.onunload = function() {  
    return true;  
}  
/**//*  
*    消息命令事件，要实现自己的连接，请重写它  
*  
*/  
CLASS_MSN_MESSAGE.prototype.oncommand = function(){  
    //this.close = true;
    this.hide();  
 window.open("http://www.baidu.com");
   
} 
/**//*  
*    消息显示方法  
*/  
CLASS_MSN_MESSAGE.prototype.show = function(){  

    var oPopup = window.createPopup(); //IE5.5+  
    
    this.Pop = oPopup;  
  
    var w = this.width;  
    var h = this.height;  
  
    var str = "<DIV style='BORDER-RIGHT: #455690 1px solid; BORDER-TOP: #a6b4cf 1px solid; Z-INDEX: 99999; LEFT: 0px; BORDER-LEFT: #a6b4cf 1px solid; WIDTH: " + w + "px; BORDER-BOTTOM: #455690 1px solid; POSITION: absolute; TOP: 0px; HEIGHT: " + h + "px; BACKGROUND-COLOR: #c9d3f3'>"  
        str += "<TABLE style='BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid' cellSpacing=0 cellPadding=0 width='100%' bgColor=#cfdef4 border=0>"  
        str += "<TR>"  
        str += "<TD style='FONT-SIZE: 12px;COLOR: #0f2c8c' width=30 height=24></TD>"  
        str += "<TD style='PADDING-LEFT: 4px; FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #1f336b; PADDING-TOP: 4px' valign=middle width='100%'>" + this.caption + "</TD>"  
        str += "<TD style='PADDING-RIGHT: 2px; PADDING-TOP: 2px' valign=middle align=right width=19>"  
        str += "<SPAN title=关闭 style='FONT-WEIGHT: bold; FONT-SIZE: 12px; CURSOR: hand; COLOR: red; MARGIN-RIGHT: 4px' id='btSysClose' >×</SPAN></TD>"  
        str += "</TR>"  
        str += "<TR>"  
        str += "<TD style='PADDING-RIGHT: 1px;PADDING-BOTTOM: 1px' colSpan=3 height=" + (h-28) + ">"  
        str += "<DIV style='BORDER-RIGHT: #b9c9ef 1px solid; PADDING-RIGHT: 8px; BORDER-TOP: #728eb8 1px solid; PADDING-LEFT: 8px; FONT-SIZE: 12px; PADDING-BOTTOM: 8px; BORDER-LEFT: #728eb8 1px solid; WIDTH: 100%; COLOR: #1f336b; PADDING-TOP: 8px; BORDER-BOTTOM: #b9c9ef 1px solid; HEIGHT: 100%'>" + this.title + "<BR><BR>"  
        str += "<DIV style='WORD-BREAK: break-all' align=left><A href='javascript:void(0)' hidefocus=false id='btCommand'><FONT color=#ff0000>" + this.message + "</FONT></A>海潮<A href='http://www.sohu.com' hidefocus=false id='ommand'><FONT color=#ff0000>伟哥</FONT></A></DIV>"  
        str += "</DIV>"  
        str += "</TD>"  
        str += "</TR>"  
        str += "</TABLE>"  
        str += "</DIV>"  
  
    oPopup.document.body.innerHTML = str; 
    
  
    this.offset  = 0; 
    var me  = this;  

    oPopup.document.body.onmouseover = function(){me.pause=true;}
    oPopup.document.body.onmouseout = function(){me.pause=false;}

    var fun = function(){  
        var x  = me.left; 
        var y  = 0; 
        var width    = me.width; 
        var height    = me.height; 

            if(me.offset>me.height){ 
                height = me.height; 
            } else { 
                height = me.offset; 
            } 

        y  = me.bottom - me.offset; 
        if(y<=me.top){ 
            me.timeout--; 
            if(me.timeout==0){ 
                window.clearInterval(me.timer);  
                if(me.autoHide){
                    me.hide(); 
                }
            } 
        } else { 
            me.offset = me.offset + me.step; 
        } 
        me.Pop.show(x,y,width,height);    

    }  
  
    this.timer = window.setInterval(fun,this.speed)      
  
     
  
    var btClose = oPopup.document.getElementById("btSysClose");  
  
    btClose.onclick = function(){  
        me.close = true;
        me.hide();  
    }  
  
    var btCommand = oPopup.document.getElementById("btCommand");  
    btCommand.onclick = function(){  
        me.oncommand();  
    }    
  var ommand = oPopup.document.getElementById("ommand");  
      ommand.onclick = function(){  
       //this.close = true;
    me.hide();  
 window.open(ommand.href);
    }   
}  
/**//* 
** 设置速度方法 
**/ 
CLASS_MSN_MESSAGE.prototype.speed = function(s){ 
    var t = 10000; 
    try { 
        t = praseInt(s); 
    } catch(e){} 
    this.speed = t; 
} 
/**//* 
** 设置步长方法 
**/ 
CLASS_MSN_MESSAGE.prototype.step = function(s){ 
    var t = 1; 
    try { 
        t = praseInt(s); 
    } catch(e){} 
    this.step = t; 
} 
  
CLASS_MSN_MESSAGE.prototype.rect = function(left,right,top,bottom){ 
    try { 
        this.left        = left    !=null?left:this.right-this.width; 
        this.right        = right    !=null?right:this.left +this.width; 
        this.bottom        = bottom!=null?(bottom>screen.height?screen.height:bottom):screen.height; 
        this.top        = top    !=null?top:this.bottom - this.height; 
    } catch(e){} 
} 

//使用ajaxPro访问数据库 获取消息或者邮件的数目

//var MSG1 = new CLASS_MSN_MESSAGE("aa",200,120,"短消息提示：","您有1封消息","今天请我吃饭哈");  
//    MSG1.rect(null,null,null,screen.height-50); 
//    MSG1.speed    = 10; 
//    MSG1.step    = 5; 
//    //alert(MSG1.top); 
//   MSG1.show();  

//同时两个有闪烁，只能用层代替了，不过层不跨框架 
var MSG2 = new CLASS_MSN_MESSAGE("aa",200,120,"短消息提示：","您有2封消息","好的啊");  
   MSG2.rect(1000,null,null,screen.height); 
    MSG2.show();  
//-->  
</script>
    <style type="text/css">
         .td
    {
    	font-weight:bold;
    	padding-right:80px;
    	text-decoration:none;
    	font-family: "黑体";
    	
    	
    }
        .style1
        
        {
            font-size: x-large;
            font-weight: bold;
            font-family: "黑体";
        }
        .style2
        {
            font-size: large;
        }
    </style>
</head>
<body style="font-size: 12px;" onload="timeview();">
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" AutoSizePanelID="RegionPanel1"
        HideScrollbar="true" />
    <div>
        <ext:RegionPanel ID="RegionPanel1" runat="server" ShowBorder="false">
            <%--          头   Logo         --%>
            <Regions>
                <ext:Region ID="Region1" runat="server" Position="Top" ShowHeader="false" ShowBorder="false"
                    EnableCollapse="true" Title="清晨公司承制" Height="100px" Layout="Fit" Margins="0 0 0 0">
                    <Toolbars>
                        <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                            <Items>
                                <ext:ToolbarText ID="ToolbarText1" Text="&nbsp;" runat="server">
                                </ext:ToolbarText>
                                <ext:Button ID="btnExpandAll" IconUrl="~/images/expand-all.gif" Text="展开菜单&nbsp;"
                                    EnablePostBack="false" runat="server">
                                </ext:Button>
                                <ext:Button ID="btnCollapseAll" IconUrl="~/images/collapse-all.gif" Text="收起菜单&nbsp;"
                                    EnablePostBack="false" runat="server">
                                </ext:Button>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                                </ext:ToolbarFill>
                                <ext:ToolbarText ID="ToolbarText2" Text="&nbsp;" runat="server">
                                </ext:ToolbarText>
                                <ext:Image ID="UpdatePwd" runat="server" ImageUrl="images/66.gif" ></ext:Image>
                                <ext:HyperLink ID="HLUpPwd" OnClientClick="addTestTab('UpdatePwd.aspx','修改密码');"   runat="server" Text="修改密码"  CssClass="td"  ></ext:HyperLink>
                            </Items>
                        </ext:Toolbar>
                    </Toolbars>
                    <Items>
                        <ext:ContentPanel ShowBorder="false" ShowHeader="false" BodyStyle="background-color:#1C3E7E;"
                            ID="ContentPanel1" runat="server">
                      <table id="__01" height="100" cellspacing="0" cellpadding="0" width="100%" align="right"
                     background="images/index_01.gif" border="0">
               <tbody>
                <tr align="right">
                    <td width="1" style="height: 89px">
                        <img height="70" alt="" src="imagess/index_01.gif" width="1"></td>
                    <!-- 显示默认图标 -->
                    <td style="font-size:large; text-align:left;width:400px; height:89px; color:White;">
                        <div align="left" class="style1 style2">                          上海市民政局办公自动化</div>
                    </td>
                    <td style="height: 89px" valign="top">
                        <table height="70" cellspacing="0" cellpadding="0" width="500" border="0">
                            <tbody>
                                <tr>
                                    <td height="50">
                                       <table cellspacing="0" cellpadding="0" align="right" border="0">
                                            <tbody>
                                                <tr>
                                                    <td valign="center" align="middle" width="75">
                                                        <img style="cursor: hand" onclick="javascript:GoTable();" height="50" alt="返回首页"
                                                            src="images/index_05.gif" width="75" border="0"></td>
                                                    <td valign="center" align="middle" width="48">
                                                        <img style="cursor: hand" onclick="javascript:alert('欢迎使用！');" height="50" alt="显示帮助/隐藏帮助"
                                                            src="images/index_06.gif" width="48" border="0"></td>
                                                    <td valign="center" align="middle" width="58">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/index_07.gif"/></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="small" style="color:White;" align="right">
                                        现在时刻：<b><span id="time_area" style="color:White;"></span></b>&nbsp;&nbsp;</td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
                        </ext:ContentPanel>
                    </Items>
                </ext:Region>
                <%--      左   菜单       --%>
                <ext:Region ID="Region2" runat="server" Position="Left" ShowHeader="true" Split="true"
                    EnableSplitTip="true" Title="管理目录" Width="200px" CollapseMode="Mini" EnableCollapse="false"
                    Icon="Outline" Layout="Fit">
                    <Items>
                        <ext:Tree runat="server" ID="treeMenu" ShowHeader="false" ShowBorder="false" AutoScroll="true"
                            EnableArrows="true">
                            <Mappings>
                                <ext:XmlAttributeMapping From="title" To="Text" />
                                <ext:XmlAttributeMapping From="url" To="NavigateUrl" />
                                <ext:XmlAttributeMapping From="description" To="ToolTip" />
                                <ext:XmlAttributeMapping From="iconUrl" To="IconUrl" />
                            </Mappings>
                        </ext:Tree>
                    </Items>
                </ext:Region>
                <%--      中   内容      --%>
                <ext:Region ID="Region3" runat="server" Position="Center" ShowHeader="false" Title="Center Region"
                    Layout="Fit">
                    <Items>
                        <ext:TabStrip ID="mainTabStrip" runat="server" ActiveTabIndex="0" ShowBorder="True"
                            EnableTabCloseMenu="true">
                            <Tabs>
                                <ext:Tab ID="Tab1" runat="server" BodyPadding="0px" EnableBackgroundColor="true"
                                    Layout="Fit" Title="Home" Icon="House">
                                    <Items>
                                        <ext:ContentPanel ID="ContentPanel2" runat="server" ShowHeader="false" ShowBorder="false">
                                            &nbsp;<div align="center"><table border="0"  cellpadding="0" width="100%" style=" width:1000px; height:1000px; background-color:#C6DAF3;"	cellspacing="0">
		<tr>
		  <td align="center" valign="top" background="images/main_17.gif">

				<table width="95%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td>
							<img src="images/main_24.gif" width="97" height="11"/>
						</td>
					</tr>
				</table>
				<div align="left"><br>
				    <table width="95%" border="0" cellspacing="0" cellpadding="0">
					  <tr>
						  <td width="5">
							  <img src="images/main_11.gif" width="5" height="5">
						  </td>
						  <td background="images/main_12.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
						  <td width="5">
							  <img src="images/main_14.gif" width="5" height="5"/>
						  </td>
					  </tr>
					  <tr>
						  <td background="images/main_19.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
						  <td align="center" class="td01">
							  <table width="95%" border="0" cellspacing="0" cellpadding="0">
								  <tr>
									  <td height="25" bgcolor="#F7F7F7">
										  <img src="images/main_28.gif" width="9" height="9">
										  <strong>待办事宜</strong>
									  </td>
									  <td width="35" align="right">
										  <a href="bpms/undo.htm" target="mainFrame"><img 	src="images/main_53.gif" 
                                              width="35" border="0" style="height: 10px">
										  </a>
									  </td>
								  </tr>
								  <tr>
									  <td height="1" class="td05">
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
									  <td class="td05">
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
								  </tr>
								  <tr>
									  <td height="5">
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
									  <td>
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
								  </tr>
							  </table>
							  <table width="95%" border="0" cellspacing="0" cellpadding="0">
								  <tr>
									  <td width="120">
										  <img src="images/info_24.gif" width="104" height="76"/>
									  </td>
									  <td>
										  <table width="100%" border="0" cellspacing="0" cellpadding="0">
											  <tr>
												  <td width="15">
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													   <a href="MeetingManager/MeetingExamine.aspx"
														target="_blank">李某 提交请假待审批办理时间 2010-03-15</a>
														
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="MeetingManager/MeetingExamine.aspx"
														target="_blank">张三 提交请假待审批 办理时间 2010-03-30</a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16"/>
												  </td>
												  <td valign="top">
													  <a>张三 提交课题借款待审批 办理时间 2010-03-30</a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16"/>
												  </td>
												  <td valign="top" class="td08">
													  <a>张三 提交医疗借款待审批办理时间 2010-03-30</a>
												  </td>
											  </tr>
										  </table>
									  </td>
								  </tr>
							  </table>
							  <br>
						  </td>
						  <td background="images/main_21.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
					  </tr>
					  <tr>
						  <td>
							  <img  width="5" height="5"/>
						  </td>
						  <td background="images/main_35.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
						  <td>
							  <img src="images/main_36.gif" width="5" height="5"/>
						  </td>
					  </tr>
				    </table>
				    <br>
				    <table width="95%" border="0" cellspacing="0" cellpadding="0">
					  <tr>
						  <td width="5">
							  <img src="images/main_11.gif" width="5" height="5"/>
						  </td>
						  <td background="images/main_12.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
						  <td width="5">
							  <img src="images/main_14.gif" width="5" height="5"/>
						  </td>
					  </tr>
					  <tr>
						  <td background="images/main_19.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
						  <td align="center" class="td01">
							  <table width="95%" border="0" cellspacing="0" cellpadding="0">
								  <tr>
									  <td height="25">
										  <img src="images/main_28.gif" width="9" height="9"
											align="absmiddle">
										  <strong>提醒信息</strong>
									  </td>
									  <td width="35" align="right">
										  <a href="Calendar/CalenderDetails.aspx" mainFrame"><img
												src="images/main_53.gif" width="35" height="9" border="0"/>
									  </td>
								  </tr>
								  <tr>
									  <td height="1" class="td05">
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
									  <td class="td05">
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
								  </tr>
								  <tr>
									  <td height="5">
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
									  <td>
										  <img src="images/spacer.gif" width="1" height="1"/>
									  </td>
								  </tr>
							  </table>
							  <table width="95%" border="0" cellspacing="0" cellpadding="0">
								  <tr>
									  <td width="120">
										  <img src="images/info_46.gif" width="104" height="76"/>
									  </td>
									  <td>
										  <table width="100%" border="0" cellspacing="0" cellpadding="0">
											  <tr>
												  <td width="15">
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="Calendar/CalenderDetails.aspx"target="_blank">刘岳
														  提交新闻申报以通过时间 2005-10-15 </a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="Calendar/CalenderDetails.aspx"target="_blank">张三
														  提交新闻申报未通过时间 2005-09-30 </a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="Calendar/CalenderDetails.aspx"target="_blank">张三
														  提交请假申请退回时间 2005-09-30 </a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="Calendar/CalenderDetails.aspx" target="_blank">张三
														  提交撤消请假通过时间 2005-09-30 </a>
												  </td>
											  </tr>
										  </table>
									  </td>
								  </tr>
							  </table>
							  <br>
						  </td>
						  <td background="images/main_21.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
					  </tr>
					  <tr>
						  <td>
							  <img src="images/main_34.gif" width="5" height="5"/>
						  </td>
						  <td background="images/main_35.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
						  <td>
							  <img src="images/main_36.gif" width="5" height="5"/>
						  </td>
					  </tr>
				    </table>
				    <br>
				    <table width="95%" border="0" cellspacing="0" cellpadding="0">
					  <tr>
						  <td width="5">
							  <img src="images/main_11.gif" width="5" height="5"/>
						  </td>
						  <td background="images/main_12.gif">
							  <img src="images/spacer.gif" width="1" height="1">
						  </td>
						  <td width="5">
							  <img src="images/main_14.gif" width="5" height="5"/>
						  </td>
					  </tr>
					  <tr>
						  <td background="images/main_19.gif">
							  <img src="images/spacer.gif" width="1" height="1"/>
						  </td>
						  <td align="center" class="td01">
							  <table width="95%" border="0" cellspacing="0" cellpadding="0">
								  <tr>
									  <td height="25">
										  <img src="images/main_28.gif" width="9" height="9"
											align="absmiddle">
										  <strong>在线消息</strong>
									  </td>
									  <td width="35" align="right">
										  <a href="message/message.htm"><img
												src="images/main_53.gif" width="35" height="9" border="0">
										  </a>
									  </td>
								  </tr>
								  <tr>
									  <td height="1" class="td05">
										  <img src="images/spacer.gif" width="1" height="1">
									  </td>
									  <td class="td05">
										  <img src="images/spacer.gif" width="1" height="1">
									  </td>
								  </tr>
								  <tr>
									  <td height="5">
										  <img src="images/spacer.gif" width="1" height="1">
									  </td>
									  <td>
										  <img src="images/spacer.gif" width="1" height="1">
									  </td>
								  </tr>
							  </table>
							  <table width="95%" border="0" cellspacing="0" cellpadding="0">
								  <tr>
									  <td width="120">
										  <img src="images/info_62.gif" width="104" height="76">
									  </td>
									  <td>
										  <table width="100%" border="0" cellspacing="0" cellpadding="0">
											  <tr>
												  <td width="15">
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="#">请归还2004-12-20日借阅的李月、王云峰、吴宏、张华的档案</a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="#">请及时处理李丽、欧阳小强、刘小军、施晓华的培训申请</a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="#">借阅的图书资料已超过归还日期，请及时归还</a>
												  </td>
											  </tr>
											  <tr>
												  <td>
													  <img src="images/index_57.gif" width="15" height="16">
												  </td>
												  <td valign="top" class="td08">
													  <a href="#">2004-12-23 下午在407举行人力资源部年度考核大会，请准时参加</a>
												  </td>
											  </tr>
										  </table>
									  </td>
								  </tr>
							  </table>
							  <br>
						  </td>
						  <td background="images/main_21.gif">
							  <img src="images/spacer.gif" width="1" height="1">
						  </td>
					  </tr>
					  <tr>
						  <td>
							  <img src="images/main_34.gif" width="5" height="5">
						  </td>
						  <td background="images/main_35.gif">
							  <img src="images/spacer.gif" width="1" height="1">
						  </td>
						  <td>
							  <img src="images/main_36.gif" width="5" height="5">
						  </td>
					  </tr>
				    </table>
				    <br>
	        </div></td>
			<td width="1" valign="top" background="images/main_41.gif">
				<img src="images/spacer.gif" width="1" height="1"/>
			</td>
			<td width="190" align="center" valign="top"
				background="images/main_17.gif">
				<br>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td height="25">
							<img src="images/main_30.gif" width="9" height="9"
								align="absmiddle"/>
							<strong>个人信息</strong>
						</td>
					</tr>
				</table>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td width="5">
							<img src="images/main_65.gif" width="5" height="5"/>
						</td>
						<td background="images/main_66.gif">
							<img src="images/spacer.gif" width="1" height="1"/>
						</td>
						<td width="5">
							<img src="images/main_69.gif" width="5" height="5"/>
						</td>
					</tr>
					<tr>
						<td background="images/main_70.gif">
							<img src="images/spacer.gif" width="1" height="1">
						</td>
						<td class="td06">
							<table width="100%" border="0" cellspacing="4" cellpadding="0">
								<tr>
									<td>
										王小小 先生，您好！
										<br>
										欢迎登录电子所务系统
										<br>
										<br>
										上次登录时间为：
										<br>
										<span class="F01">2006-02-20 14:20:35</span>
										<br>
										这是您第18次登录本系统
									</td>
								</tr>
							</table>
						</td>
						<td background="images/main_72.gif">
							<img src="images/spacer.gif" width="1" height="1"/>
						</td>
					</tr>
					<tr>
						<td>
							<img src="images/main_80.gif" width="5" height="5"/>
						</td>
						<td background="images/main_81.gif">
							<img src="images/spacer.gif" width="1" height="1"/>
						</td>
						<td>
							<img src="images/main_82.gif" width="5" height="5"/>
						</td>
					</tr>
				</table>
				<br>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td height="25">
							<img src="images/main_61.gif" width="9" height="9"
								align="absmiddle"/>
							<strong>日历</strong>
						</td>
					</tr>
					<tr>
						<td>
							<table border="0" cellspacing="1" cellpadding="0"
								bgcolor="#CCCCCC">
								<tr>
									<td bgcolor="#FFFFFF">
										<script language="JavaScript">
<!-- Begin
var now = new Date();
var month_array = new Array("一月","二月","三月","四月","五月","六月","七月","八月","九月","十月","十一月","十二月");
document.write("<form name=date_list><table bgcolor=white border=0><tr><td>");
document.write("<select name=month onchange=change_month(this.options.selectedIndex)>");
for(i=0;i<month_array.length;i++)
{
 if (now.getMonth() != i)
 {document.write ("<option value="+i+">"+month_array[i]);}
 else
 {document.write ("<option value="+i+" selected>"+month_array[i]);}

}
document.write("</select>");
document.write("</td><td>");
document.write ("<select name=year onchange=change_year(this.options[this.options.selectedIndex])>");
for(i=1950;i<3000;i++)
{
 if (now.getYear() != i)
 {document.write("<option value="+i+">"+i);}
 else
 {document.write("<option value="+i+" selected>"+i);}
}
document.write("</select></td></tr><tr><td colspan=2><center>");

document.write("<table bgcolor=white border=0 cellspacing = 1 cellpading = 0 width=100%><tr bgcolor=666666 align=center>");
document.write("<td heigh=25 width=19 class=F02>M</td><td width=19 class=F02>T</td><td width=19 class=F02>W</td><td width=19 class=F02>T</td><td width=19 class=F02>F</td><td width=19 class=F03>S</td><td width=19 class=F03>S</td>");
document.write("</tr><tr>");
for(j=0;j<6;j++)
{
 for(i=0;i<7;i++)
 {
   document.write("<td bgcolor=EFEFEF align=center id=d"+i+"r"+j+"></td>")
 }
 document.write("</tr>");
}

document.write("</table>");

document.write("</center></from></td></tr></table>");

var show_date = new Date();

function set_cal(show_date)
{
begin_day = new Date (show_date.getYear(),show_date.getMonth(),1);
begin_day_date = begin_day.getDay();
end_day = new Date (show_date.getYear(),show_date.getMonth()+1,1);
count_day = (end_day - begin_day)/1000/60/60/24;
input_table(begin_day_date,count_day);
}
set_cal(show_date);

function input_table(begin,count)
{
init();
j=0;
if (begin!=0){i=begin-1;}else{i=6}
for (c=1;c<count+1;c++)
{
 colum_name = eval("d"+i+"r"+j);
 if ((now.getDate() == c)&&(show_date.getMonth() == now.getMonth())&&(show_date.getYear() == now.getYear())) {colum_name.style.backgroundColor = "FF7700";colum_name.style.color = "white";};
 colum_name.innerText =  c;
 i++;
 if (i==7){i=0;j++;}
}
}

function init()
{
for(j=0;j<6;j++)
{
 for(i=0;i<7;i++)
 {
 colum_name = eval("d"+i+"r"+j);
 colum_name.innerText =  " ";
 colum_name.style.backgroundColor ="";
 colum_name.style.color ="";
 }
}
}

function change_month(sel_month)
{
show_date = new Date(show_date.getYear(),sel_month,1);
set_cal(show_date);
}

function change_year(sel_year)
{
sel_year = sel_year.value;
show_date = new Date(sel_year,show_date.getMonth(),1);
set_cal(show_date);
}
//  End -->
          </script>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<br>
				<br>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td height="1" background="images/main_57.gif">
							<img src="images/spacer.gif" width="1" height="1">
						</td>
					</tr>
				</table>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td width="50" height="50">
							<img src="images/main_53.gif" width="36" height="36">
						</td>
						<td>
							<a href="javascript:addExampleTab('AddressManager/Userlist.aspx')" target="main">个人通讯录</a>
							<br>
							<img src="images/main_50.gif" width="43" height="9">
						</td>
					</tr>
				</table>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td height="1" background="images/main_57.gif">
							<img src="images/spacer.gif" width="1" height="1">
						</td>
					</tr>
				</table>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td width="50" height="50">
							<img src="images/icon_38.gif" width="36" height="36">
						</td>
						<td>
							<a href="PowerManager/User/UpdateUser.aspx" target="main">个人设置</a>
							<br>
							<img src="images/main_50.gif" width="43" height="9">
						</td>
					</tr>
				</table>
				<table width="163" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td height="1" background="images/main_57.gif">
							<img src="images/spacer.gif" width="1" height="1">
						</td>
					</tr>
				</table>
			</td>
		</tr>
</table></div>
                                        </ext:ContentPanel>
                                    </Items>
                                </ext:Tab>
                            </Tabs>
                        </ext:TabStrip>
                    </Items>
                </ext:Region>
            </Regions>
        </ext:RegionPanel>
    </div>
    <br />
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Web.sitemap"></asp:XmlDataSource>
    </form>

    <script type="text/javascript">
// 显示服务器的当前时间

        function onReady() {
            var treeMenu = Ext.getCmp('<%= treeMenu.ClientID %>');

            // Click expand toolbar button.
            var btnExpandAll = Ext.getCmp('<%= btnExpandAll.ClientID %>');
            btnExpandAll.on('click', function() {
                treeMenu.expandAll();
            });

            // Click collapse toolbar button.
            var btnCollapseAll = Ext.getCmp('<%= btnCollapseAll.ClientID %>');
            btnCollapseAll.on('click', function() {
                treeMenu.collapseAll();
            });


            function addExampleTab(node) {
                var href = node.attributes.href;
                // Add a dynamic tab (With toolbar).
                var mainTabStrip = Ext.getCmp('<%= mainTabStrip.ClientID %>');
                var tabID = 'dynamic_added_tab' + node.id.replace('__', '-');
                mainTabStrip.addTab({
                    'id': tabID,
                    'url': href,
                    'title': node.parentNode.text + ' -> ' + node.text,
                    'closable': true,
                    'bodyStyle': 'padding:5px;'
                });
            }
        
            // Click the tree node.使用树控件时控制单击节点跳转的页面在main主页面打开，而不是重新开启一个窗口
            treeMenu.on('click', function(node, event) {
                if (node.isLeaf()) {
                    var href = node.attributes.href;
                    // Modify the location of current url.
                    window.location.href = '#' + href;

                    addExampleTab(node);

                    // Don't response to this tree node's default behavior. 
                    event.stopEvent();
                }
            });

            (function pageFirstLoad() {
                var currentHash = window.location.hash.substr(1);
                var level1Nodes = treeMenu.getRootNode().childNodes;
                for (var i = 0; i < level1Nodes.length; i++) {
                    var level2Nodes = level1Nodes[i].childNodes;
                    for (var j = 0; j < level2Nodes.length; j++) {
                        var currentNode = level2Nodes[j];
                        if (currentNode.attributes.href === currentHash) {
                            level1Nodes[i].expand();
                            // We must retrieve this node again, because currentNode doesn't has parentNode property.
                            var foundNode = treeMenu.getNodeById(currentNode.id);
                            foundNode.select();
                            addExampleTab(foundNode);
                            return;
                        }
                    }
                }
            })();

        }
        //单击控件时控制单击节点跳转的页面在main主页面打开，而不是重新开启一个窗口
            function addTestTab(href,titles) {
                // Add a dynamic tab (With toolbar).
                var mainTabStrip = Ext.getCmp('<%= mainTabStrip.ClientID %>');
                var tabID = 'dynamic_added_tab' + href ;
                   mainTabStrip.addTab({
                    'id': tabID,
                    'url': href,
                    'title': titles,
                    'closable': true,
                    'bodyStyle': 'padding:5px;'
                });
            
            }

    </script>

</body>
</html>
