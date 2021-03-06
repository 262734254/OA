﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyBorrow.aspx.cs" Inherits="ApplyBorrow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>借用申请录入页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"> </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 450px;
            background-color: #C6DAF3;
        }
        .style2
        {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        资源借用申请</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="">
                        <tr align="left">
                            <td>
                                借&nbsp;用&nbsp;人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator4" runat="server" ErrorMessage="使用人不能为空" ControlToValidate="txtUser">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                申请类型：<asp:TextBox ID="txtType" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="使用人不能为空"
                                    ControlToValidate="txtType">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                借用时间：<input type="text" onclick="showcalendar(event, this);" id="txtStartTime" runat="server"
                                    style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    width: 120px; border-bottom: #99ccff 1px solid" /><asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                        runat="server" ErrorMessage="*" ControlToValidate="txtStartTime" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                紧急程度：<asp:TextBox ID="txtStatus" class="inputs" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="紧急程度不能为空" ControlToValidate="txtStatus">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2" class="style2">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="59px" TextMode="MultiLine" Width="330px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" runat="server" ErrorMessage="备注不能为空" ControlToValidate="txtMark">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="center">
                            <th colspan="2" align="left">
                                借用资源
                            </th>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr align="center" class="TableHeader">
                                        <td class="style2">
                                            资源类型
                                        </td>
                                        <td>
                                            资源名称
                                        </td>
                                        <td>
                                            资源规格
                                        </td>
                                        <td>
                                            借用数量
                                        </td>
                                        <td>
                                            单价
                                        </td>
                                        <td>
                                            供应商名称
                                        </td>
                                        <td>
                                            操作
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td class="style2">
                                            <asp:Label ID="Label2" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" class="BigButton" Text="删除" />
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td class="style2">
                                            <asp:Label ID="Label8" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button3" runat="server" class="BigButton" Text="删除" />
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td class="style2">
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                                <asp:ListItem>数据绑定</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                                <asp:ListItem>数据绑定</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            数据绑定
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList3" runat="server">
                                                <asp:ListItem>数据绑定</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" class="BigButton" Text="添加" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="提   交" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="取   消" 
                                    OnClick="btnReset_Click" CausesValidation="False" />
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
