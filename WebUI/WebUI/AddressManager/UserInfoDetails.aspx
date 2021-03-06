﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfoDetails.aspx.cs" Inherits="AddressManager_UserInfoDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户信息详情</title>
<link href="../css/public.css" type="text/css" rel="stylesheet"/>
      <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
    <style type="text/css">
        .style1
        {
             width: 100%; background-color:#C6DAF3;
            height: 450px;
        }
        .style2
        {
            height: 123px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                 <td align="center" class="title1">
                  <h3>用户信息详情</h3></td>
            </tr>
            <tr>
                <td align="center">
    
        <table style="height: 392px">
           
            <tr>
                <td>
                    姓&nbsp;&nbsp; 名：<asp:TextBox ID="TextBox1" ReadOnly="true" class="inputs" runat="server">肯德罗夫斯基</asp:TextBox>
                </td>
                <td>
                    年&nbsp;&nbsp;&nbsp; 龄 ：<asp:TextBox ID="TextBox2" ReadOnly="true" class="inputs" runat="server">32</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    QQ 号：<asp:TextBox ID="TextBox3" ReadOnly="true" class="inputs" runat="server">333336655</asp:TextBox>
                </td>
                <td>
                    性别：<asp:RadioButton ID="RadioButton1" ReadOnly="true" runat="server" Text="男" Checked="true" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="女" />
                &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    手机号：<asp:TextBox ID="TextBox5" ReadOnly="true" class="inputs" runat="server">116541</asp:TextBox>
                </td>
                <td>
                    座 机 号 ：<asp:TextBox ID="TextBox4" ReadOnly="true" class="inputs" runat="server">98465132</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email ：<asp:TextBox ID="TextBox6" ReadOnly="true" class="inputs" runat="server">65132@sdf.com</asp:TextBox>
                </td>
                <td>
                    身份证号：<asp:TextBox ID="TextBox8" ReadOnly="true" class="inputs" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    M S N：<asp:TextBox ID="TextBox7" ReadOnly="true" class="inputs" runat="server">16132132joijlk</asp:TextBox>
                </td>
                <td>
                    所属部门：<asp:DropDownList ID="DropDownList1" class="inputs" runat="server">
                    <asp:ListItem Selected="True">市场部</asp:ListItem>
                    <asp:ListItem>人事部</asp:ListItem>
                    </asp:DropDownList>
                &nbsp; 选择组：<asp:DropDownList ID="DropDownList2" class="inputs" runat="server">
                <asp:ListItem Selected="True">开发组</asp:ListItem>
                <asp:ListItem>组织组</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    地&nbsp; 址 ：<asp:TextBox ID="TextBox9" ReadOnly="true" class="inputs" runat="server" 
                        Width="424px">jasdlfjdfs</asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td colspan="2" class="style2">
                    备注：<asp:TextBox ID="TextBox10" runat="server" class="inputs" Height="100px" 
                        TextMode="MultiLine" Width="438px">wertaefasedfaer</asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" class="BigButton" 
                        CausesValidation="false"  PostBackUrl="~/AddressManager/Userlist.aspx" 
                        Text="返   回" />
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
