﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateResourceStore.aspx.cs"
    Inherits="ResourceManager_ResourceStoreManager_UpdateResourceStore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改资料室信息</title>
    <link href="../../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../../js/calendar.js" type="text/javascript"> </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 450px;
            background-color: #C6DAF3;
        }
        .style2
        {
            height: 90px;
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
                        修改资料室信息</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr align="left">
                            <td>
                                资料室名称：<asp:TextBox ID="txtResourceName" class="inputs" runat="server" Width="120px"></asp:TextBox>
                            </td>
                            <td>
                                部门名称：<asp:TextBox ID="TextBox1" class="inputs" runat="server"
                                    Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                管&nbsp;&nbsp; 理&nbsp;&nbsp; 员：<asp:TextBox ID="txtApplyNum" class="inputs"
                                    runat="server" Width="120px"></asp:TextBox>
                            </td>
                            <td>
                                库&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 存：<asp:TextBox ID="TextBox2" class="inputs" runat="server"
                                    Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2" class="style2">
                                备&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtMark" class="inputs" runat="server" Height="59px"
                                    TextMode="MultiLine" Width="330px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="保   存" 
                                    onclick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="取   消" 
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
