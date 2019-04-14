<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Time.aspx.cs" Inherits="Time" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="1000">
        </asp:Timer>
    
    </div>
    </form>
</body>
</html>
