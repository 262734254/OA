<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  CodeFile="ApplicationMeeting.aspx.cs"
    Inherits="MeetingManager_AddMeetingRomeOrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加会议申请及会场安排 信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript">

</script>
<SCRIPT language=JavaScript type=text/JavaScript>

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
	//返回一个object对象
	arr = window.showModalDialog("MailSend.aspx","new","dialogHeight:500px;dialogWidth:800px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	//alert(arr);
	var person=new Array();
	//将所有已存在的与会人员获取到person中
	for(var i=0;i<document.getElementById("selectPerson").options.length;i++)
	{
		person[i]=document.getElementById("selectPerson").options[i].value;
	}
	//判断与会人员是否存在，如果为空，将获取的与会人员添加到ListBox列表中
	if(person.length==0)
	{
		for(var i=0;i<arr.length;i++)
		{
			document.getElementById("selectPerson").options.add(new Option(arr[i],arr[i]));
		}
	}
	else  //如果存在与会人员，遍历获取到的array对象
	{
		for(var j=0;j<arr.length;j++)
		{	
			if(!jsSelectIsExitItem(person,arr[j]))  //判断返回的对象中是否已存在，存在，不重复添加
			{
				document.getElementById("selectPerson").options.add(new Option(arr[j],arr[j]));
			}
		}
	}
	document.getElementById("txtMeetNumber").value=document.getElementById("selectPerson").options.length;
	
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
   	document.getElementById("txtMeetNumber").value=document.getElementById("selectPerson").options.length;
      
}
function addCompere()
{
	var name = window.showModalDialog("Send.aspx","new","dialogHeight:420px;dialogWidth:500px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	if(name==null || name=="")
	{
		alert('请重新选择！');
		document.getElementById("txtcompere").value="";
	}
	else{
		document.getElementById("txtcompere").value=name;
	}
}
function SearchMeeting()
{
	window.open("SearchRoom.aspx","new");
	
}
function addSummary()
{
	var name = window.showModalDialog("Send.aspx","new","dialogHeight:420px;dialogWidth:500px;edge:Raised;center:Yes;help:No;resizable:no;status:no;");
	if(name==null || name=="")
	{
		alert('请重新选择！');
		document.getElementById("txtsummary").value="";
	}
	else{
		document.getElementById("txtsummary").value=name;
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
                    <asp:Label ID="lblTitle" style="font-weight:bold;" runat="server" Text="" CssClass="title1"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 442px">
            
                <br />
<br>
<table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="td_page"><div align="right">
        <input name="Submit2" type="button" class="BigButton" value="查看会议室" onclick="SearchMeeting()"/>
        <input name="Submit" type="button" class="BigButton" value="  返回  " onclick="location.href='ApplictionMeetingList.aspx'" />
    </div></td>
  </tr>
</table><br>
<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="table01">
   <tr>
     <td width="15%" height="30" ><div align="center">主办部门</div></td>
     <td width="35%" align="left">
      
         <asp:DropDownList ID="ddlDepartment"  style="width:90% " CssClass="input" 
             runat="server" AppendDataBoundItems="True" DataSourceID="odsAllDepartment" 
             DataTextField="Departmentname" DataValueField="Id">
         <asp:ListItem Value="0">请选择</asp:ListItem>
         </asp:DropDownList>
         <asp:ObjectDataSource ID="odsAllDepartment" runat="server" 
             SelectMethod="GetAllDepartment" TypeName="BLL.Power.DepartmentManager">
         </asp:ObjectDataSource>
     </td>
	 <td  width="15%"><div align="center">会议类型</div></td>
	 <td width="34%" >
         <asp:DropDownList ID="ddlInstancyDegree" runat="server" Height="16px" CssClass="inputs" style="width:87% " >
             <asp:ListItem Value="0">--请选择--</asp:ListItem>
             <asp:ListItem>一般会议</asp:ListItem>
             <asp:ListItem>紧急会议</asp:ListItem>
         </asp:DropDownList>
	</td>
    </tr>
   <tr>
     <td height="30" ><div align="center">会议名称</div></td>
     <td colspan="3" align="left">
         <asp:TextBox ID="txtMeetTitle" CssClass="input" style="width:95% "  runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
             ControlToValidate="txtMeetTitle" ErrorMessage="会议名称不为空">*</asp:RequiredFieldValidator>
                            </td>
   </tr>
   <tr>
     <td height="30" ><div align="center">主&nbsp;&nbsp;持&nbsp;&nbsp;人</div></td>
     <td colspan="3" align="left">
         <asp:TextBox ID="txtcompere" style="width:86% " ReadOnly="true" CssClass="input"  runat="server"></asp:TextBox>&nbsp;<input name="Submit" type="button" class="BigButton"value="请选择" onclick="addCompere()"><asp:RequiredFieldValidator 
             ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcompere">*</asp:RequiredFieldValidator>
                            </td>
    </tr>
   <tr>
     <td height="30" ><div align="center">会议纪要人</div></td>
     <td colspan="3" align="left" >         <asp:TextBox ID="txtsummary" ReadOnly="true" style="width:86% " CssClass="input"  runat="server"></asp:TextBox>
      <input name="Submit" type="button" class="BigButton" value="请选择" onClick="addSummary()"><asp:RequiredFieldValidator 
             ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsummary">*</asp:RequiredFieldValidator>
                            </td>
    </tr>
   <tr>
     <td height="30" ><div align="center">开始时间</div></td>
     <td colspan="3" align="left"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="40%"><input name="beginTime" id="txtbeginTime" onclick="showcalendar(event, this);" type="text" class="input"  size="15" maxlength="12" runat="server">
            <img src="../../images/search.gif" width="21" height="20" align="absmiddle" >
            <select name="select" id="sHours" class="input2" runat="server">
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
<select name="select" class="input2" runat="server" id="sSecond">
  <option value="0" selected>00</option>
  <option value="15">15</option>
  <option value="30">30</option>
  <option value="45">45</option>
</select>
分  
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                  ControlToValidate="txtbeginTime">*</asp:RequiredFieldValidator>
                                        </td>
          <td width="18%"><div align="center">结束时间</div></td>
          <td><input name="endTime" id="txtendTime" type="text" onclick="showcalendar(event, this);" class="input" size="15" maxlength="12" runat="server">
            <img src="../../images/search.gif" width="21" height="20" align="absmiddle" >
            <select name="select" class="input2" id="sHourse2" runat="server">
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
<select name="select" class="input2" runat="server" id="sSecond2">
  <option value="0" selected>00</option>
  <option value="15">15</option>
  <option value="30">30</option>
  <option value="45">45</option>
</select>
分<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                  ControlToValidate="txtendTime">*</asp:RequiredFieldValidator>
                                        </td>
        </tr>
      </table></td>
    </tr>
   <tr>
     <td height="30" ><div align="center">会&nbsp;&nbsp;议&nbsp;&nbsp;室</div></td>
     <td colspan="3" align="left">
         <br />
        <asp:DropDownList ID="ddlRoomName"  style="width:95%; height: 13px;" 
           runat="server" DataSourceID="odsAllRoomName" 
            DataTextField="RoomName" DataValueField="RID">
        <asp:ListItem>请选择</asp:ListItem>
        </asp:DropDownList>
         <br />
        <asp:ObjectDataSource ID="odsAllRoomName" runat="server" 
            SelectMethod="GetAllRoomInfo" TypeName="BLL.Meeting.RoomInfoManager">
            
        </asp:ObjectDataSource>
                            </td>
   </tr>
   <tr>
     <td height="30" ><div align="center">与会人员</div></td>
     <td colspan="3" >
	 <table width="100%"  border="0" cellspacing="0" cellpadding="0">
       <tr>
         <td width="80%" align="left"><select id="selectPerson" runat="server" size="5" multiple class="box" style="width:60% ">
         </select>
           <input name="Submit3" type="button" class="BigButton" value=" 清除 " onClick="deletePerson(this)">
           <input name="Submit" type="button" class="BigButton" value="添加与会人员" class="BigButton" onclick="addPerson()"></td>
         <td valign="bottom">参与人数<input type="text" style="width:30% " id="txtMeetNumber" runat="server"  value="" readonly="readonly"/></td>
       </tr>
     </table></td>
	 
    </tr>
   <tr>
     <td height="30" ><div align="center">会议内容概要</div></td>
     <td colspan="3" align="left" ><textarea name="textfield" id="txtContent" rows="5" class="box" style="width:95% " runat="server"></textarea></td>
   </tr>
	
   </table>
<br>
 <table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
     <td class="td_page">     <div align="center">
       &nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" Text="保 存" 
            
             class="BigButton" onclick="btnSave_Click"/>
                            &nbsp;
                            <input id="btnExit" type="button" value="重 置" 
             onclick="history.go(-1);" class="BigButton" /></div></td></tr>
 </table>
            
            </td>
        </tr>
    </table>
    
    
    </form>
</body>
</html>

