<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="Chat_List.aspx.cs" Inherits="N_Chat_Chat_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../javascript/getChat.js" type="text/javascript"></script>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField runat="server" ID="userid" />
    <div id="Chatlist">
    </div>
    </form>
</body>
</html>
