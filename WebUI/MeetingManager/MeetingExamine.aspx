<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeetingExamine.aspx.cs" Inherits="MeetingManager_MeetingExamine" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会议审批</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>
        <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
            height: 511px;
        }
            .style5
            {
                height: 89px;
            }
            .style6
            {
                height: 42px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 506px; width: 100%" class="style4">
        <table cellpadding="2" cellspacing="1" border="0" class="" style="font: menu; height: 488px;
            width: 100%;">
            <tr>
                <td align="left" class="title1">
                    <h3>您正在对&nbsp;&nbsp;--张三--&nbsp;&nbsp;的会议申请进行审批</h3>
                </td>
            </tr>
            <tr><td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
  
</table>
<br>
<table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td class="td_page"><div align="right">
    </div></td>
  </tr>
</table><br>
<table width="95%" border="0" align="center" cellpadding="0" cellspacing="0" class="table01">
   <tr>
     <td width="15%" height="30" class="td_02"><div align="center">主办部门</div></td>
     <td width="35%" class="td_02"><input name="textfield" type="text" class="input" style="width:90% " value="人事部" readonly="true"></td>
	 <td class="td_02" width="15%"><div align="center">会议类型</div></td>
	 <td width="34%" class="td_02"><input name="textfield" type="text" class="input" style="width:90% " value="一般会议" readonly="true">	</td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会议名称</div></td>
     <td colspan="3" class="td_02"><input name="textfield" type="text" class="input" style="width:70% " value="人事部会议" readonly="true"></td>
   </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">主&nbsp;&nbsp;持&nbsp;&nbsp;人</div></td>
     <td colspan="3" class="td_02"><input name="textfield" type="text" class="input" value="王五" style="width:70% " readonly="true"></td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会议纪要人</div></td>
     <td colspan="3" class="td_02"><input name="textfield" type="text" class="input" value="小王" style="width:70% " readonly="true"></td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">开始时间</div></td>
     <td colspan="3" class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="40%"><input name="textfield" type="text" class="input" value="2010-4-10 10:15" style="width:80% " readonly="true"></td>
          <td width="18%"><div align="center">结束时间</div></td>
          <td><input name="textfield" type="text" class="input" style="width:80% " value="2010-4-10 12:00" readonly="true"></td>
        </tr>
      </table>
      </td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会&nbsp;&nbsp;议&nbsp;&nbsp;室</div></td>
     <td colspan="3" class="td_02"><input name="textfield" type="text" class="input" value="会议室一" style="width:60% " readonly="true"></td>
   </tr>
   <tr>
     <td class="style5"><div align="center">与会人员</div></td>
     <td colspan="3" class="style5">
	 <table width="100%"  border="0" cellspacing="0" cellpadding="0">
       <tr>
         <td width="80%"><textarea name="textfield" rows="5" class="box" style="width:95% " readonly="true">小王,小猪,王五
		 </textarea></td>
         <td valign="bottom">参与人数<input type="text" class="buttonface02" style="width:30% " value="30" readonly="true"></td>
       </tr>
     </table></td>
	 
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会议内容概要</div></td>
     <td colspan="3" class="td_02"><textarea name="textfield" rows="5" class="box" style="width:85% " readonly="true">召开会议</textarea></td>
   </tr>
	
   </table>
<br>
 <table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
     <td height="32" class="td_page">     <div align="center">
       <input name="Submit2" type="submit" class="BigButton" onclick="~/PedngMatter/Auditing.aspx" value=" 审 批 ">&nbsp;         
          <input name="Submit22" type="submit"  class="BigButton" value=" 重新修改 ">        
          &nbsp;        
          <input name="Submit" type="reset"  class="BigButton" value="  不同意  ">      
          <br>
     </div></td></tr>
 </table>
            </td></tr>
            </table>
    </div>
    </form>
</body>
</html>
