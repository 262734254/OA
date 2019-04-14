<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat_Top.aspx.cs" Inherits="N_Chat_Chat_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
function qiehuan(num){
	for(var i=1;i<=2;i++){
		if(num==i){
			document.getElementById("icon"+i).className="showicon";
		}else{
			document.getElementById("icon"+i).className="showicons";
		}
	}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border:1px #6f97b1 solid">
  <tr>
    <td width="10" bgcolor="#f6f6f6">&nbsp;</td>
    <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" ><a href="Chat_Center.aspx" class="a" target="newFrame">
    <div style="width:73; height:27px; cursor:pointer; text-indent:20px">聊天室</div>
    </a></td>
    <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" ><a href="Chat_Record.aspx" class="a" target="newFrame">
    <div style="width:73; height:27px;cursor:pointer;">聊天记录</div>
    </a></td>
    <td bgcolor="#f6f6f6">&nbsp;</td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
