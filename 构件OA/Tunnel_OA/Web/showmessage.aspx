<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Showmessage.aspx.cs" Inherits="showmessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消息提示</title>
    <link href="css/Css.css" rel="stylesheet" type="text/css" />
    <script src="javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function tourl(m_id){
            $.get("javascript/updatemessage.ashx?mid=" + m_id,null,null);
            window.opener.location=document.getElementById("url").value;
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<bgsound src="css/message.wav" loop="1">
<div style=" border-color:#6f97b1; border-style:solid;width:390px; height:90px; text-align:center;">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td height="30" align="center" style="border-bottom:1px #6f97b1 solid">您有新待办事项</td>
    </tr>
    <tr>
      <td height="30" align="center" style="border-bottom:1px #6f97b1 solid">
          <a href="#" onclick="tourl('<%=Request.Params["mid"] %>')"><asp:Label runat="server" ID="Label1"></asp:Label></a>
          <asp:HiddenField runat="server" ID="url" />
      </td>
    </tr>
    <tr>
      <td height="30" align="center"><asp:Button runat="server" Text="我知道了" 
              CssClass="button" onclick="Unnamed2_Click" /></td>
    </tr>
  </table>
</div>
    </form>
</body>
</html>
