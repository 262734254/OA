<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat_Center.aspx.cs" Inherits="N_Chat_Chat_Center" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
  <frameset rows="*" cols="*,120" framespacing="0" frameborder="no" border="0">
    <frameset rows="*,150" cols="*" framespacing="0" frameborder="no" border="1">
    <frame src="Chat_List.aspx" name="mainFrame" id="mainFrame" title="mainFrame" bordercolor="#000000" frameborder="1"/>
    <frame src="Chat_Bottom.aspx" name="sendFrame" scrolling="Yes" noresize="noresize" id="sendFrame" title="sendFrame" />
  </frameset>
    <frame src="Chat_Online.aspx" name="rightFrame" scrolling="Yes" noresize="noresize" id="rightFrame" title="rightFrame" />
  </frameset>
<noframes><body>
</body>
</noframes>
</html>
