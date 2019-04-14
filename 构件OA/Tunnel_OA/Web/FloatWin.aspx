<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FloatWin.aspx.cs" Inherits="FloatWin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <script src="javascript/js.js" type="text/javascript"></script>
    <title>浮动图片</title> 
</head>
<body>
<div id="img1" style="Z-INDEX: 100; LEFT: 2px; WIDTH: 81px; POSITION: absolute; TOP: 43px; HEIGHT: 93px;
 visibility: visible;">
 <div style="width:48px; height:15px; float:left; size:10px" id="div_title" ><%=Title %></div> 
 <div style="width:32px; height:15px; float:right; size:10px" id="div_close" onclick="return close()">关闭</div> 
 <img src="image/piao.jpg" width="80" height="80" border="0" alt=""/>
 </div>
<div align="center"> 
</div>
</body>
</html>
