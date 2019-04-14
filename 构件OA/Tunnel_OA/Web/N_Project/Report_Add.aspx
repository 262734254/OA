<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Add.aspx.cs" Inherits="N_Project_Report_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .PanelStyle{ margin:5px; margin-left:0px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table border="0" width="98%" align="center" cellspacing="0" cellpadding="0" style="border:1px #6f97b1 solid">
<tr>
<td valign="top">
<table id="title" width="100%" border="0" cellspacing="0" cellpadding="0">
     <tr>
      <td>
	    <table width="100%" border="0" cellspacing="0" cellpadding="0" >
  <tr>
    <td><table width="100%" border="0" cellpadding="0" cellspacing="0" >
      <tr>
        <td height="30" width="80"  bgcolor="#f6f6f6" align="center" >排 序 号：</td>
        <td bgcolor="#f6f6f6">
            <asp:TextBox ID="txtNum" runat="server" Width="44px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvNum" runat="server" 
                ControlToValidate="txtNum" ErrorMessage="请输入排序号"></asp:RequiredFieldValidator>
                                                                                    </td>
      </tr>
      <tr>
        <td height="30" align="center" >模版名称：</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                ControlToValidate="txtName" ErrorMessage="请输入模版名称"></asp:RequiredFieldValidator>
                                                                                    </td>
      </tr>
      <tr>
        <td height="30"  bgcolor="#f6f6f6" align="center" >模版分类：</td>
        <td bgcolor="#f6f6f6">
            <asp:DropDownList ID="ddlType" runat="server" Width="206px"></asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td height="30"  bgcolor="#ffffff" align="center" >模版类型：</td>
        <td bgcolor="#ffffff">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="0">台账</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">单据或卡片</asp:ListItem>
            </asp:RadioButtonList>
          </td>
      </tr>
      <tr>
        <td height="30"  bgcolor="#ffffff" align="center" >是否审核：</td>
        <td bgcolor="#ffffff">
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:RadioButtonList>
          </td>
      </tr>
      <tr>
        <td height="30"  bgcolor="#f6f6f6" align="center" >&nbsp;模版状态：</td>
        <td bgcolor="#f6f6f6">
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Selected="True">启用</asp:ListItem>
                <asp:ListItem Value="1">停用</asp:ListItem>
            </asp:RadioButtonList>
                                                                                    </td>
      </tr>
      </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="border-top:1px #6f97b1 solid;border-bottom:1px #6f97b1 solid; border-left:0px #6f97b1 solid; border-right:0px #6f97b1 solid">
      <tr>
        <td width="68" height="30" align="center" bgcolor="#e6f7ff" >&nbsp;</td>
        <td width="796" height="30" align="center" bgcolor="#e6f7ff" >
            <asp:Button ID="btnAdd" runat="server" Text="提 交" CssClass="button" 
                onclick="btnAdd_Click" Height="23px" 
                />
          &nbsp;<asp:Button ID="btnReset" runat="server" Text="重 置" CssClass="button" 
                onclick="btnAdd_Click" Height="23px" 
                />
         </td>
      </tr>
    </table></td>
  </tr>
</table>
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
