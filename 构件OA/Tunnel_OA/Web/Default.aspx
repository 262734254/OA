<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<html xmlns="http://www.w3.org/1999/xhtml"><style>
.td { line-height: 24px;}
.input1 { height: 18px; width: 138px;}
</style>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>构件公司办公管理系统</title>
    <link rel="stylesheet" type="text/css" href="css/StyleSheetLogin.css">

    <script src="javascript/Command.js" type="text/javascript"></script>
    <script>
        function init() {
            document.getElementById("username").focus();
            document.getElementById("username").value = "";
        }
        function yjhkk() {
            if (document.getElementById("username").value == "") {
                alert('请输入用户名称！');
                document.getElementById("username").focus();
                return false;
            }
            if (document.getElementById("password").value == "") {
                alert('请输入密码！');
                document.getElementById("password").focus();
                return false;
            }
        }
        function SetCookie(name, value)//两个参数，一个是cookie的名子，一个是值
        {
            var Days = 30; //此 cookie 将被保存 30 天
            var exp = new Date();    //new Date("December 31, 9998");
            exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
            document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
        }
        function getCookie(name)//取cookies函数        
        {
            var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
            if (arr != null) return unescape(arr[2]); return null;

        }
        function delCookie(name)//删除cookie
        {
            var exp = new Date();
            exp.setTime(exp.getTime() - 1);
            var cval = getCookie(name);
            if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
        }
    </script>
<style type="text/css">
<!--
img{ border:0px;}
body,td,th {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 12px;
}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.STYLE4 {
	font-size: 18px;
	font-weight: bold;
	color: #404040;
	line-height:30px
}
.STYLE5 {color: #FFFFFF}
.STYLE6 {font-family: Verdana, Arial, Helvetica, sans-serif}
.td1{
   font-size:16px; vertical-align:middle;}
}
-->
</style>
</head>
<body id="Body1" runat="server">
    <form id="form1" runat="server">
     <center><script>delCookie("num")</script>
<table id="Table1" width="1024" height="679" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="3">
			<img src="images/login_01.gif" width="343" height="134" alt=""></td>
		<td colspan="4">
			<img src="images/login_02.gif" width="511" height="134" alt=""></td>
		<td>
			<img src="images/login_03.gif" width="170" height="134" alt=""></td>
	</tr>
	<tr>
		<td colspan="3" rowspan="2">
			<img src="images/login_04.gif" width="343" height="154" alt=""></td>
		<td>
			<img src="images/login_05.gif" width="461" height="78" alt=""></td>
			<td colspan="2" style="background-image:url(images/login_06.gif);width:43px;height:78px; background-repeat:no-repeat;">
		<table width="100%" height="78" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="38">&nbsp;</td>
  </tr>
  <tr>
    <td align="center" valign="middle">
	<!--
	 <a href="#" style="cursor:pointer;"><img src="images/czatn.gif" alt="重置" /></a>
	   <label>
      <input type="reset" name="login " value="" style="background-image:url(images/czatn.gif); background-repeat:no-repeat; width:14px; height:14px;">
      </label>
	  -->
	  </td>
  </tr>
</table>
</td>
		<td colspan="2" rowspan="6">
			<img src="images/login_07.gif" width="177" height="450" alt=""></td>
	</tr>
	<tr>
		<td colspan="3">
			<img src="images/login_08.gif" width="504" height="76" alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images/login_09.gif" width="170" height="1" alt=""></td>
		<td colspan="5">
			<img src="images/login_10.gif" width="677" height="1" alt=""></td>
	</tr>
	<tr>
		<td colspan="2" rowspan="3">
			<img src="images/login_11.gif" width="173" height="295" alt=""></td>
				<td colspan="4" style="background-image:url(images/login_12.gif);width:674px;height:148px; background-repeat:no-repeat;"><table width="100%" height="133" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="26%" height="19">&nbsp;</td>
            <td width="53%">&nbsp;</td>
            <td width="21%">&nbsp;</td>
          </tr>
          <tr>
            <td height="56" align="right"><span class="STYLE4">用户名:</span>&nbsp;&nbsp;</td>
            <td align="left"  class="td1" height="50px">&nbsp;<input type="text" name="uname" style="width:295px;height:35px; background-image:url(images/dlk.gif); background-repeat:no-repeat; border:0px;line-height:40px;padding:0px 5px 5px 10px;" size="45" maxlength="20" id="username" runat="server"></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td align="right"><span class="STYLE4">密&nbsp;&nbsp; 码:</span>&nbsp;&nbsp;</td>
            <td align="left" class="td1">&nbsp;<input type="password" name="uname" style="width:295px;height:35px; background-image:url(images/dlk.gif); background-repeat:no-repeat; border:0px; font-size:14px; vertical-align:middle;line-height:40px;padding:0px 5px 5px 10px;" size="45" maxlength="20" id="password" runat="server"></td>
            <td>&nbsp;</td>
          </tr>
        </table>			</td>
	</tr>
	<tr>
				<td colspan="4" style="background-image:url(images/login_13.gif);width:674px;height:51px; background-repeat:no-repeat;">
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="67%" height="41">&nbsp;</td>
	<td width="15%" align="left">&nbsp;<asp:ImageButton ID="ImageButton1" ImageUrl="images/loginatn2.gif" runat="server" OnClick="Button1_Click" OnClientClick="return yjhkk();"/></td>
    <td width="18%" align="left">&nbsp;<input type="reset" name="cancel" value=" " 
            style="border-style: none; border-color: inherit; border-width: 0px; background-image: url('images/czatn2.gif');
                                                                width: 94px; height: 29px; ">
	<!--
      <label>
      <input type="submit" name="login " value="" style="background-image:url(images/loginatn.gif); background-repeat:no-repeat; width:115px; height:29px;">
      </label>
	  -->   </td>
  </tr>
</table>
</td>
	</tr>
	<tr>
		<td colspan="4">
			<img src="images/login_14.gif" width="674" height="96" alt=""></td>
	</tr>
	<tr>
		<td colspan="2">
			<img src="images/login_15.gif" width="173" height="94" alt=""></td>
			<td colspan="3" style="background-image:url(images/login_16.gif);width:673px;height:94px; background-repeat:no-repeat;"><table width="100%" height="65" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="18%">&nbsp;</td>
            <td width="82%">&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><span class="STYLE5">Copyright © 上海构件公司 2009 All rights reserved 
                沪ICP备10200561号</span></td>
          </tr>
        </table>
		</td>
		<td colspan="3">
			<img src="images/login_17.gif" width="178" height="94" alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images/分隔符.gif" width="170" height="1" alt=""></td>
		<td>
			<img src="images/分隔符.gif" width="3" height="1" alt=""></td>
		<td>
			<img src="images/分隔符.gif" width="170" height="1" alt=""></td>
		<td>
			<img src="images/分隔符.gif" width="461" height="1" alt=""></td>
		<td>
			<img src="images/分隔符.gif" width="42" height="1" alt=""></td>
		<td>
			<img src="images/分隔符.gif" width="1" height="1" alt=""></td>
		<td>
			<img src="images/分隔符.gif" width="7" height="1" alt=""></td>
		<td>
			<img src="images/分隔符.gif" width="170" height="1" alt=""></td>
	</tr>
</table>
</center>
    </form>
</body>
</html>
