<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationMeeting.aspx.cs"
    Inherits="MeetingManager_UpdOrAddMeetingRomeOrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加会议申请及会场安排 信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript">

</script>
<SCRIPT language=JavaScript type=text/JavaScript>
function GetDate (nText)
{
	reVal = window.showModalDialog ("../time.htm", '',
		"status:no;center:yes;scroll:no;resizable:no;help:no;dialogWidth:255px;dialogHeight:260px");
	if (reVal != null)
	{
		if (nText == 1)
			document.getElementById("beginTime").value = reVal;
		if (nText == 2)
			document.getElementById("endTime").value = reVal;
	}
}
function zuijia()
{
	var  str = confirm("确定追加吗？");
	if(str == true)
	{
		alert("追加成功！");
	}
	else
	{
		alert("取消追加！");
	}
}
function windowOpen(theURL,winName,features,width,hight,scrollbars,top,left) 
{
  var parameter="top="+top+",left="+left+",width="+width+",height="+hight;
  if(scrollbars=="no")
 {parameter+=",scrollbars=no";}
  else
 {parameter+=",scrollbars=yes";}
  window.open(theURL,winName,parameter);
}
function addPerson()
{
	var arr=new Array();
	arr = window.showModalDialog("MailSend.aspx","new","dialogHeight:400px;dialogWidth:800px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	var person=new Array();
	for(var i=0;i<document.getElementById("selectPerson").options.length;i++)
	{
		person[i]=document.getElementById("selectPerson").options[i].value;
	}
	if(person.length==0)
	{
		for(var i=0;i<arr.length;i++)
		{
			document.getElementById("selectPerson").options.add(new Option(arr[i],arr[i]));
		}
	}
	else
	{
		for(var j=0;j<arr.length;j++)
		{	
			if(!jsSelectIsExitItem(person,arr[j]))
			{
				document.getElementById("selectPerson").options.add(new Option(arr[j],arr[j]));
			}
		}
	}
}
function jsSelectIsExitItem(objSelect, objItemValue) {           
    var isExit = false;           
    for (var i = 0; i < objSelect.length; i++) {           
        if (objSelect[i] == objItemValue) {           
            isExit = true;           
            break;           
        }           
    }           
    return isExit;           
}
function deletePerson() {           
    var length = document.getElementById("selectPerson").options.length - 1;       
    for(var i = length; i >= 0; i--){       
        if(document.getElementById("selectPerson")[i].selected == true){       
            document.getElementById("selectPerson").options[i] = null;       
        }       
    }       
}
function addCompere()
{
	var name = window.showModalDialog("Send.aspx","new","dialogHeight:420px;dialogWidth:500px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	if(name==null || name=="")
	{
		alert('请重新选择！');
		document.getElementById("compere").value="";
	}
	else{
		document.getElementById("compere").value=name;
	}
}
function addSummary()
{
	var name = window.showModalDialog("Send.aspx","new","dialogHeight:420px;dialogWidth:500px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	if(name==null || name=="")
	{
		alert('请重新选择！');
		document.getElementById("summary").value="";
	}
	else{
		document.getElementById("summary").value=name;
	}
}

</SCRIPT>
    <style type="text/css">
        body
        {
            font-size: 9pt; /* 字体大小                  */
            font-family: Verdana; /* 字体名称                  */
        }
        input.BigButton
        {
            border: 1px solid #666666;
            font-size: 12px;
            background-image: url('../css/6/images/button_bg.gif');
            background-color: #ffffff;
        }
        #Select1
        {
            width: 123px;
        }
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        #Select2
        {
            width: 123px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style4" width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
        <tr>
            <td class="title1" align="center">
                <h3>
                    会议申请单</h3>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 442px">
            
                <br />
<br>
<table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="td_page"><div align="right">
        <input name="Submit2" type="button" class="BigButton" value="查看会议室" onclick="location.href='SearchRoom.aspx'"/>
        <input name="Submit" type="button" class="BigButton" value="  返回  " onclick="location.href='ApplictionMeetingList.aspx'" />
    </div></td>
  </tr>
</table><br>
<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="table01">
   <tr>
     <td width="15%" height="30" ><div align="center">主办部门</div></td>
     <td width="35%" align="left"><select name="select2" class="input" style="width:90% ">
       <option value="1" selected>---请选择---</option>
       <option value="2">人事部</option>
       <option value="3">工程部</option>
     </select></td>
	 <td  width="15%"><div align="center">会议类型</div></td>
	 <td width="34%" ><select name="select3" class="input" style="width:87% ">
	   <option value="0" selected>---请选择---</option>
	   <option value="1">一般会议</option>
	   <option value="2">紧急会议</option>
          </select>
	</td>
    </tr>
   <tr>
     <td height="30" ><div align="center">会议名称</div></td>
     <td colspan="3" align="left"><input name="textfield" type="text" class="input" style="width:95% "></td>
   </tr>
   <tr>
     <td height="30" ><div align="center">主&nbsp;&nbsp;持&nbsp;&nbsp;人</div></td>
     <td colspan="3" align="left"><input name="compere" id="compere" type="text" class="input" style="width:86% " readonly="true">
      <input name="Submit" type="button" class="BigButton"value="请选择" onclick="addCompere()"></td>
    </tr>
   <tr>
     <td height="30" ><div align="center">会议纪要人</div></td>
     <td colspan="3" align="left" ><input name="summary" id="summary" type="text" class="input" style="width:86% " readonly="true">
      <input name="Submit" type="button" class="BigButton" value="请选择" onClick="addSummary()"></td>
    </tr>
   <tr>
     <td height="30" ><div align="center">开始时间</div></td>
     <td colspan="3" align="left"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="40%"><input name="beginTime" id="beginTime" type="text" class="input" value="2008-10-10" size="15" maxlength="12" readonly="true">
            <img src="../../images/search.gif" width="21" height="20" align="absmiddle" onClick="GetDate(1)">
            <select name="select" class="input2">
              <option value="1">01</option>
              <option value="2">02</option>
              <option value="3">03</option>
              <option value="4">04</option>
              <option value="5">05</option>
              <option value="6">06</option>
              <option value="7">07</option>
              <option value="8" selected>08</option>
              <option value="9">09</option>
              <option value="10">10</option>
              <option value="11">11</option>
              <option value="12">12</option>
              <option value="13">13</option>
              <option value="14">14</option>
              <option value="15">15</option>
              <option value="16">16</option>
              <option value="17">17</option>
              <option value="18">18</option>
              <option value="19">19</option>
              <option value="20">20</option>
              <option value="21">21</option>
              <option value="22">22</option>
              <option value="23">23</option>
              <option value="24">24</option>
            </select>
点
<select name="select" class="input2">
  <option value="0" selected>00</option>
  <option value="15">15</option>
  <option value="30">30</option>
  <option value="45">45</option>
</select>
分 </td>
          <td width="18%"><div align="center">结束时间</div></td>
          <td><input name="endTime" id="endTime" type="text" class="input" value="2008-10-10" size="15" maxlength="12" readonly="true">
            <img src="../../images/search.gif" width="21" height="20" align="absmiddle" onClick="GetDate(2)">
            <select name="select" class="input2">
              <option value="1">01</option>
              <option value="2">02</option>
              <option value="3">03</option>
              <option value="4">04</option>
              <option value="5">05</option>
              <option value="6">06</option>
              <option value="7">07</option>
              <option value="8">08</option>
              <option value="9">09</option>
              <option value="10" selected>10</option>
              <option value="11">11</option>
              <option value="12">12</option>
              <option value="13">13</option>
              <option value="14">14</option>
              <option value="15">15</option>
              <option value="16">16</option>
              <option value="17">17</option>
              <option value="18">18</option>
              <option value="19">19</option>
              <option value="20">20</option>
              <option value="21">21</option>
              <option value="22">22</option>
              <option value="23">23</option>
              <option value="24">24</option>
            </select>
点
<select name="select" class="input2">
  <option value="0" selected>00</option>
  <option value="15">15</option>
  <option value="30">30</option>
  <option value="45">45</option>
</select>
分</td>
        </tr>
      </table></td>
    </tr>
   <tr>
     <td height="30" ><div align="center">会&nbsp;&nbsp;议&nbsp;&nbsp;室</div></td>
     <td colspan="3" align="left"><select name="select2" class="input" style="width:95% ">
       <option value="0" selected>全部</option>
       <option value="1">会议室1</option>
       <option value="2">会议室2</option>
          </select></td>
   </tr>
   <tr>
     <td height="30" ><div align="center">与会人员</div></td>
     <td colspan="3" >
	 <table width="100%"  border="0" cellspacing="0" cellpadding="0">
       <tr>
         <td width="80%" align="left"><select id="selectPerson" size="5" multiple class="box" style="width:60% ">
         </select>
           <input name="Submit3" type="button" class="BigButton" value=" 清除 " onClick="deletePerson(this)">
           <input name="Submit" type="button" class="BigButton" value="添加与会人员" class="BigButton" onclick="addPerson()"></td>
         <td valign="bottom">参与人数<input type="text" style="width:30% "  value=""></td>
       </tr>
     </table></td>
	 
    </tr>
   <tr>
     <td height="30" ><div align="center">会议内容概要</div></td>
     <td colspan="3" align="left" ><textarea name="textfield" rows="5" class="box" style="width:95% "></textarea></td>
   </tr>
	
   <tr>
     <td height="56" ><div align="center">领导意见</div></td>
     <td colspan="3"  align="left"><textarea name="textfield" rows="2" class="box" style="width:55% " readonly="true"></textarea>	 </td>
    </tr>
 </table>
<br>
 <table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
     <td class="td_page">     <div align="center">
       &nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="保 存" 
             PostBackUrl="~/MeetingManager/ApplictionMeetingList.aspx" class="BigButton"/>
                            &nbsp;
                            <input id="btnExit0" type="button" value="重 置" 
             onclick="history.go(-1);" class="BigButton" /></div></td></tr>
 </table>
            
            </td>
        </tr>
    </table>
    
    
    </form>
</body>
</html>
