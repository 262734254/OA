<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceDetails.aspx.cs"
    Inherits="ResourceDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>资源详情信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
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
                        资源详情信息</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="height: 422px; width: 537px;">
                        <tr align="left">
                            <td>
                                资源名称：<asp:Label ID="lblResourceName" class="inputs" runat="server" ReadOnly="True"
                                    Width="120px"></asp:Label>
                            </td>
                            <td>
                                资源数量：<asp:Label ID="lblNumber" class="inputs" runat="server" ReadOnly="True"
                                    Width="120px"></asp:Label>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                资源单价：<asp:Label ID="lblPrice" class="inputs" runat="server" ReadOnly="True"
                                    Width="120px"></asp:Label>
                            </td>
                            <td>
                                购买时间：<asp:Label ID="lblInTime" class="inputs" runat="server" 
                                    ReadOnly="True" Width="120px"></asp:Label>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                供 应 商 ：<asp:Label ID="lblProvider" class="inputs" runat="server" ReadOnly="True"
                                    Width="120px"></asp:Label>
                            </td>
                            <td>
                                资源类型：<asp:Label ID="lblResourceType" class="inputs" runat="server" 
                                    ReadOnly="True" Width="120px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                资源规格：<asp:Label ID="lblSpec" class="inputs" runat="server" ReadOnly="True"
                                    Width="120px"></asp:Label>
                            </td>
                            <td align="left">
                                资源状态：<asp:Label ID="lblState" class="inputs" runat="server" ReadOnly="True" 
                                    Width="120px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                资 料 室 ：<asp:Label ID="lblResourceStore" class="inputs" runat="server" ReadOnly="True" 
                                    Width="120px"></asp:Label></td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" class="style3">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtRemark" class="inputs"
                                    runat="server" Height="108px" TextMode="MultiLine" Width="416px" 
                                    ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnEdit" runat="server" class="BigButton" Text="修   改" 
                                    OnClick="btnEdit_Click" ToolTip="更新" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" CausesValidation="False"
                                    OnClick="btnReset_Click" />
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
