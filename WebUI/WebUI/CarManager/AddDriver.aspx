<%@ Page Language="C#"  ValidateRequest="false" AutoEventWireup="true" CodeFile="AddDriver.aspx.cs" Inherits="CarManager_AddDriver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>驾驶员添加页面</title>
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
            width: 367px;
        }
        </style>
    </head>
<body>
    <form id="form1" runat="server">
     <div>
        <table class="style1">
            <tr>
                <td  align="center" class="title1">
      <h3>驾驶员信息添加</h3>
     </td>
            </tr>
            <tr>
                <td align="center" valign="top">
    <table style="height: 263px; width: 398px;">
     <tr align="center">
      <td class="style2">
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          姓 名：<asp:TextBox ID="txtName" class="inputs" runat="server" Width="122px" 
              MaxLength="6"></asp:TextBox>
          <asp:RequiredFieldValidator ID="rfvName" runat="server" 
              ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
      </td>
      <td>
          &nbsp;</td>
     </tr>
     <tr align="center">
      <td class="style2">
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 年 龄：<asp:TextBox ID="txtAge" class="inputs" 
              runat="server" Width="122px" 
              MaxLength="2"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
              ControlToValidate="txtAge" ErrorMessage="年龄不能为空">*</asp:RequiredFieldValidator>
      </td>
&nbsp;</td>
     </tr>
     <tr>
     <td colspan="2" align="center">
         性 别：<asp:RadioButton ID="rdoMan" class="inputs" runat="server" 
                        Text="男" GroupName="a" Checked="True" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="rdoGril" class="inputs" runat="server" Text="女" 
                        GroupName="a" />
                                    &nbsp;&nbsp;&nbsp;</td> 
     </tr>
     <tr>
      <td colspan="2" align="center">
          地 址：<asp:TextBox ID="txtAddRess" class="inputs" runat="server" Width="122px" 
              MaxLength="20"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
              ErrorMessage="*" ControlToValidate="txtAddRess"></asp:RequiredFieldValidator>
      </td>
     </tr>
     <tr>
      <td colspan="2" align="center">
          电 话：<asp:TextBox ID="txtPhone" class="inputs" runat="server" Width="122px" 
              MaxLength="15"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
              ErrorMessage="*" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
      </td>
     </tr>
     <tr>
      <td colspan="2" align="center">
          状态：<asp:TextBox ID="txtState" class="inputs" runat="server" Width="122px" 
              Enabled="False">未出车</asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
              ControlToValidate="txtState" ErrorMessage="*"></asp:RequiredFieldValidator>
      </td>
     </tr>
     <tr>
      <td colspan="2" align="center">
          <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="确   定" 
              onclick="btnSubmit_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返  回"  PostBackUrl="~/CarManager/driverInfo.aspx" 
              onclick="btnReset_Click" CausesValidation="False"  />
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
