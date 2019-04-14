<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat_Record.aspx.cs" Inherits="N_Chat_Chat_Record" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-left:1px #6f97b1 solid;border-right:1px #6f97b1 solid">
  
  <tr>
    <td width="17%" valign="top" style="padding-left:5px;padding-right:5px; padding-top:10px;border-bottom:1px #6f97b1 solid">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="#ffffff" 
            BorderColor="#6589a1" BorderWidth="1px" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="#000000" Height="173px" 
            ShowGridLines="True" Width="186px" Font-Bold="True" onselectionchanged="Calendar1_SelectionChanged">
            <SelectedDayStyle BackColor="#095d93" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TodayDayStyle BackColor="Red" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#cccccc" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <DayHeaderStyle BackColor="#ffffff" Font-Bold="True" Height="1px" />
            <TitleStyle BackColor="#fdfdfd" Font-Bold="True" Font-Size="9pt" 
                ForeColor="#5f6472" />
        </asp:Calendar>
      </td>
    <td width="83%" height="238" valign="top" style="padding-left:10px; padding-top:10px;border-left:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid">
    <asp:DataList ID="DataList1" runat="server" Width="100%">
        <ItemTemplate>
        <div style="font-size:14px; overflow:visible;<%#GetQiao(Eval("Chat_State").ToString(),Eval("Chat_UserID").ToString(),Eval("Chat_ToUserID").ToString())%>"><img src="images/84.gif" />&nbsp;<%#GetuserName(Eval("Chat_UserName").ToString(),Eval("Chat_UserID").ToString())%> <%#gettoUser(Eval("Chat_ToUserID").ToString(), Eval("Chat_state").ToString())%>说：<%#Eval("Chat_content")%> <span style="color:#999">[<%#Eval("Chat_Date") %>]</span></div>
        </ItemTemplate>
        </asp:DataList>
        &nbsp;
    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
