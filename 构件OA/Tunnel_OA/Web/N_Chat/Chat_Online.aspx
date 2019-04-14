<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat_Online.aspx.cs" Inherits="N_Chat_Chat_Online" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../javascript/getOnline.js" type="text/javascript"></script>
    <script type="text/javascript">
    function to_qiao(uid,uname){
//        parent.sendFrame.document.getElementById("DropDownList1").options.length=0;
//        parent.sendFrame.document.getElementById("DropDownList1")..add(new Option('所有人',0,false,false));
          //parent.sendFrame.document.getElementById("DropDownList1").options.add(new Option(uname,uid,false,true));   
          parent.sendFrame.document.getElementById("DropDownList1").value=uid;  
          parent.sendFrame.document.getElementById("currid").value=uid;
          parent.sendFrame.document.getElementById("oncurrid").value="";    
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="32" align="center" style="border-bottom:1px #6f97b1 solid">共 <span style="color:Red"><asp:Label ID="Label1" runat="server"></asp:Label></span> 人 </td>
      </tr>
      <tr>
        <td align="center" id="Online">&nbsp;</td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
