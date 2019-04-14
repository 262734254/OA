<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chat_Bottom.aspx.cs" EnableEventValidation="false" Inherits="N_Chat_Chat_Bottom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />

    <script src="../javascript/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="../javascript/getOnline1.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="currid" runat="server" />
        <asp:HiddenField ID="oncurrid" runat="server" />
<table width="100%" height="25" border="0" cellpadding="0" cellspacing="0" bgcolor="#e6f7ff" style="border:1px #6f97b1 solid">
        <tr>
          <td width="50" height="30" align="right">对象：</td>
          <td><asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="0">所有人</asp:ListItem>
        </asp:DropDownList>
        <label>
        &nbsp;悄悄话
        <asp:CheckBox ID="CheckBox1" runat="server" />
        &nbsp;
         此选项可以提示对方有聊天记录 
&nbsp;</label></td>
        </tr>
        <tr>
          <td height="30" align="right">内容：</td>
          <td><asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" MaxLength="200" 
            Width="396px" Height="69px"></asp:TextBox>
              <asp:Button ID="Button1" runat="server"
            onclick="Button1_Click" Text="发送" 
            OnClientClick="return viewText()" CssClass="button" /></td>
        </tr>
      </table>
    </div>
    </form>
</body>
</html>
