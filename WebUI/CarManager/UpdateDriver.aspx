<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateDriver.aspx.cs" Inherits="CarManager_UpdateDriver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改驾驶员信息页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />   
    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
        .style1
        {
           width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
        .style2
        {
            width: 393px;
        }
        </style>
    </head>
<body>
    <form id="form1" runat="server">
     <div>
        <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>驾驶员信息修改</h3>
     </td>
            </tr>
            <tr>
                <td align="center" valign="top">
    <table style="height: 307px">
     <tr align="center">
      <td class="style2">
          姓 名：<asp:TextBox ID="txtName" class="inputs" runat="server" Width="122px">张三</asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
              ControlToValidate="txtName" ErrorMessage="姓名不能为空">*</asp:RequiredFieldValidator>
      </td>
      <td>
          &nbsp;</td>
     </tr>
     <tr align="center">
      <td class="style2">
          年 龄：<asp:TextBox ID="txtAge" class="inputs" runat="server" Width="122px">18</asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
              ControlToValidate="txtAge" ErrorMessage="年龄不能为空">*</asp:RequiredFieldValidator>
      </td>
      <td>
          &nbsp;</td>
     </tr>
     <tr>
     <td colspan="2" align="center">
         性 别：<asp:CheckBox ID="checkSex" runat="server" Checked="True" Text="男" />
         <asp:CheckBox ID="checkGirl" runat="server" Text="女" />
      </td> 
     </tr>
     <tr>
      <td colspan="2" align="center">
          地 址：<asp:TextBox ID="txtAddRess" class="inputs" runat="server" Width="122px">岳阳</asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
              ErrorMessage="*" ControlToValidate="txtAddRess"></asp:RequiredFieldValidator>
      </td>
     </tr>
     <tr>
      <td colspan="2" align="center">
          电 话：<asp:TextBox ID="txtPhone" class="inputs" runat="server" Width="122px">13888888888</asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
              ErrorMessage="*" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
      </td>
     </tr>
     <tr>
      <td colspan="2" align="center">
          <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="确   定" 
              onclick="btnSubmit_Click" PostBackUrl="~/CarManager/driverInfo.aspx"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnReset" runat="server" class="BigButton" Text="重   置" 
              onclick="btnReset_Click"  />
      </td>
     </tr>
    </table>
     </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
