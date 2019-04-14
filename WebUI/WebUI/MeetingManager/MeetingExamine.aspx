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
            </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 506px; width: 100%" class="style4">
        <table cellpadding="2" cellspacing="1" border="0" class="" style="font: menu; height: 488px;
            width: 100%;">
            <tr>
                <td align="left" class="title1">
                    <h3>您正在对&nbsp;&nbsp;--<asp:Label ID="lblName" runat="server" ></asp:Label>--&nbsp;&nbsp;的会议申请进行审批</h3>
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
     <td width="35%" class="td_02"><input name="textfield" type="text" id="txtDepartment" runat="server" class="input" style="width:90% "  readonly="true"></td>
	 <td class="td_02" width="15%"><div align="center">会议类型</div></td>
	 <td width="34%" class="td_02"><input name="textfield" type="text" class="input" id="txtMeetType" runat="server"  style="width:90% "  readonly="true">	</td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会议名称</div></td>
     <td colspan="3" class="td_02"><input name="textfield" type="text" class="input" id="txtRoomName" runat="server" style="width:70% " readonly="true"></td>
   </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">主&nbsp;&nbsp;持&nbsp;&nbsp;人</div></td>
     <td colspan="3" class="td_02">
         <asp:TextBox ID="txtCompere" runat="server" CssClass="input" style="width:70% " readonly="true"></asp:TextBox></td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会议纪要人</div></td>
     <td colspan="3" class="td_02"><input name="textfield" id="txtMeetingSummary"  runat="server" type="text" class="input" style="width:70% " readonly="true"/></td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">开始时间</div></td>
     <td colspan="3" class="td_02"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="40%"><input name="textfield" id="txtBeginTime" runat="server" type="text" class="input" style="width:80% " readonly="true"></td>
          <td width="18%"><div align="center">结束时间</div></td>
          <td><input name="textfield" type="text" id="txtEndTime" runat="server" class="input" style="width:80% "  readonly="true"></td>
        </tr>
      </table>
      </td>
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会&nbsp;&nbsp;议&nbsp;&nbsp;室</div></td>
     <td colspan="3" class="td_02"><input name="textfield" id="txtMeetName" runat="server" type="text" class="input" style="width:60% " readonly="true"></td>
   </tr>
   <tr>
     <td class="style5"><div align="center">与会人员</div></td>
     <td colspan="3" class="style5">
	 <table width="100%"  border="0" cellspacing="0" cellpadding="0">
       <tr>
         <td width="80%"><textarea name="textfield" runat="server" id="txtWithinEnlistMan" rows="5" class="box" style="width:95% " readonly="true">
		 </textarea></td>
         <td valign="bottom">参与人数<input type="text" id="txtMeetNumber" runat="server" class="buttonface02" style="width:30% " readonly="true"></td>
       </tr>
     </table></td>
	 
    </tr>
   <tr>
     <td height="30" class="td_02"><div align="center">会议内容概要</div></td>
     <td colspan="3" class="td_02"><textarea name="textfield" runat="server" id="txtMeetContent" rows="5" class="box" style="width:85% " readonly="true"></textarea></td>
   </tr>
	
   </table>
<br>
 <table width="95%"  border="0" align="center" cellpadding="0" cellspacing="0">
   <tr>
     <td height="32" class="td_page">     <div align="center">
         <asp:Button ID="btnSubmit" runat="server" Text="审 批" CssClass="BigButton" 
             onclick="btnSubmit_Click" />
&nbsp;&nbsp;        
          &nbsp;        
         <asp:Button ID="btnNo" runat="server" Text="不同意" CssClass="BigButton" 
             onclick="btnNo_Click" />   
          <br>
     </div></td></tr>
 </table>
            </td></tr>
            </table>
    </div>
    </form>
</body>
</html>
