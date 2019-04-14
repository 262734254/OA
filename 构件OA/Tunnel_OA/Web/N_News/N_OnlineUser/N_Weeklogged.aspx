<%@ Page Language="C#" AutoEventWireup="true" CodeFile="N_Weeklogged.aspx.cs" Inherits="N_News_N_OnlineUser_N_Weeklogged" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>一周未登录用户</title>
    <link href="../../css/Css.css" rel="stylesheet" type="text/css" />
    <%@ Register Assembly="Tunnel.BLL" Namespace="OurControl" TagPrefix="cc1" %>
    
 
    <style type="text/css">
        .style1
        {
        }
        </style>
    
 
</head>
<body>
    <form id="form1" style="width:95%" runat="server">
    <div>
<table border="0" align="center" width="60%" cellspacing="0" cellpadding="3" class="small">
  <tr>
    <td class="style1" align="center"><span class="big3"> &nbsp;一周未登录用户
        </span></td>
  </tr>
</table>

  <table align="center" width="60%" border="1" cellpadding="0" cellspacing="0" bordercolordark="#FFFFFF" >
    <tr class="TableHeader">
    
            <td nowrap height="30" align="center" bgcolor="#f6f6f6" >序号</td>
      <td nowrap height="30" align="center" bgcolor="#f6f6f6">
          <b>用户姓名</b></td>
        <td align="center" bgcolor="#f6f6f6" height="30" nowrap="nowrap">
            <b>在线时间</b>(分)</td>
        <td align="center" bgcolor="#f6f6f6" height="30" nowrap="nowrap">
            <b>最后登录时间</b></td>
    </tr>
      <asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
        <tr class="TableLine1" style='color:<%#GetFontColor(Eval("m_id")) %>' onmouseover="this.style.backgroundColor='#F2F2F2';" onmouseout="this.style.backgroundColor='';">
        <td  align="center" ><%#username() %></td>
          <td align="center" height="25">&nbsp;<%#Eval("m_name") %></td>
          <td align="center">&nbsp;<%#convertTime(Eval("m_counttime").ToString())%></td>
          <td align="center">&nbsp;<%#Eval("m_onlinetime","{0:yyyy-MM-dd HH:mm:ss}")%></td>
        </tr>
      </ItemTemplate>
      </asp:Repeater>    
</table>

    </div>
    
    </form>
       
</body>
</html>
