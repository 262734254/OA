<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat.aspx.cs" Inherits="N_Chat_Chat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<frameset rows="34,*" cols="*" framespacing="0" frameborder="no" border="0">
  <frame src="Chat_Top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frame src="Chat_Center.aspx" name="newFrame" id="newFrame" title="newFrame" />
</frameset>
<noframes>
<body>
    <form id="form1" runat="server">
    <div>

    </div>
    </form>
</body></noframes>
</html>
