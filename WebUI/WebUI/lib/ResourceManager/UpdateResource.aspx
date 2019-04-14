﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateResource.aspx.cs" Inherits="ResourceManager_UpdateResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资源修改</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 450px;
            background-color: #C6DAF3;
        }
        .style3
        {
            height: 153px;
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
                        资源修改</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="height: 422px; width: 537px;">
                        <tr align="left">
                            <td>
                                资源名称：<asp:TextBox ID="txtResourceName" class="inputs" runat="server" Width="120px">数据绑定</asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtResourceName"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                资源数量：<asp:TextBox ID="txtResourceName0" class="inputs" runat="server" Width="120px">数据绑定</asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                资源单价：<asp:TextBox ID="txtResourceName1" class="inputs" runat="server" Width="120px">数据绑定</asp:TextBox>
                            </td>
                            <td>
                                购买时间：<input id="txtTime" name="txFDate" type="text" value="数据绑定" style="width: 120px; height: 17px;
                                    border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid;" runat="server" 
                                    onclick="showcalendar(event, this);" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                购买地点：<asp:TextBox ID="txtResourceName3" class="inputs" runat="server" Width="120px">数据绑定</asp:TextBox>
                            </td>
                            <td>
                                资源类型：<asp:DropDownList ID="DropDownList2" class="inputs" runat="server">
                                    <asp:ListItem>数据绑定</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                资源规格：<asp:TextBox ID="txtResourceName4" class="inputs" runat="server" Width="120px">数据绑定</asp:TextBox>
                            </td>
                            <td align="left">
                                资源状态：<asp:DropDownList ID="DropDownList3" class="inputs" runat="server">
                                    <asp:ListItem>数据绑定</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" class="style3">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtResourceName5" class="inputs"
                                    runat="server" Height="108px" TextMode="MultiLine" Width="416px">数据绑定</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="保   存" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" 
                                    onclick="btnReset_Click" />
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
