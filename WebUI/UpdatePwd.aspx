<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePwd.aspx.cs" Inherits="UpdatePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>修改密码</title>
   <link href="css/6/style.css" rel="Stylesheet" type="text/css" />
    <link href="css/public.css" type="text/css" rel="stylesheet" />
    
       
    <style type="text/css">
        .style1
        {
            width: 100px;
        }
    </style>
    
       
</head>
<body style="text-align: left;background-color:#C6DAF3;">
    <form id="form1" runat="server">
        <table  style="width: 100%">
            <tr class="title1" >
                <td  class="title1" align="center">
                   <h3> 修改密码</h3></td>
            </tr>
        </table>
        <table align="center" style="width: 467px; height: 185px">
                <tr>
                    <td nowrap="nowrap" align="center" class="style1">
                        旧密码：</td>
                    <td nowrap="nowrap" class="style4">
                        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                            ErrorMessage="*"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="center" class="style1">
                        新密码：</td>
                    <td>
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                            ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="center" class="style1">
                        确认密码：</td>
                    <td nowrap="nowrap" style="text-align: left">
                        <asp:TextBox ID="txtReNewPassword" runat="server" TextMode="Password" Style="border-right: #99ccff 1px solid;
                                        border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtReNewPassword"
                            ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword"
                            ControlToValidate="txtReNewPassword" ErrorMessage="二次输入的密码不相同，请重新输入！！" Display="Dynamic"></asp:CompareValidator></td>
                </tr>
                <tr>
                    <td align="center" colspan="2" nowrap="nowrap" style="height: 26px">
                        <asp:Button ID="Button1" runat="server" CssClass="BigButton" Text="确   认" 
                            PostBackUrl="~/indexs.aspx" />
                        &nbsp; &nbsp;
                        &nbsp;
                        <asp:Button ID="Button2" runat="server" class="BigButton" Text="重   填" />&nbsp; &nbsp;
                        &nbsp;
                         <input  name="Submit"  onclick="javascript:history.go(-1);"
                                    type="button" class="BigButton" value="  取 消  " />
                    </td>
                </tr>
                </table>
    </form>
</body>
</html>

