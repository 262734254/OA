<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Flow_UserSelect.aspx.cs" Inherits="SystemManage_BaseData_Flow_UserSelect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title><%=title %></title>
</head>
<frameset rows="*,32" cols="*" frameborder="no" border="0" framespacing="0">
  <frameset rows="*" cols="188,*" framespacing="0" frameborder="yes" border="0">
    <frame src="Flow_SelectLeft.aspx?to_id=<%=Request.Params["to_id"] %>&to_name=<%=Request.Params["to_name"] %>&type=<%=Request.Params["type"]%>&Competence=<%=Request.Params["Competence"] %>" name="mainFrame" id="mainFrame" />
    <frame src="Flow_SelectRight.aspx" id="right1" name="rightFrame" scrolling="No" noresize="noresize" id="rightFrame" />
  </frameset>
  <frame src="Flow_SelectFoot.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" />
</frameset>
<noframes><body>
</body></noframes>
</html>
