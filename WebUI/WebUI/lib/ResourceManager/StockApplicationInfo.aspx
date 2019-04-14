<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockApplicationInfo.aspx.cs"
    Inherits="ResourceManager_StockApplicationInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请资源详情</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 100%;
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
                <td>
                    <table class="style1">
                        <tr>
                            <td align="center" class="title1">
                                <h3>
                                    申请资源详情</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="width: 545px">
                                    <tr align="left">
                                        <td>
                                            资源名称：<asp:TextBox ID="txtApplyNum0" class="inputs" runat="server" 
                                                Width="120px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            资源规格：<input type="text" onclick="showcalendar(event, this);" 
                                                id="txtStartTime" runat="server"
                                                style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                                border-bottom: #99ccff 1px solid" readonly="readonly" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 量：<asp:TextBox ID="txtStatus" class="inputs" runat="server"
                                                Width="120px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td>
                                            单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 价：<asp:TextBox ID="txtUser" class="inputs" runat="server"
                                                Width="120px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            供 应 商 ：<asp:TextBox ID="txtUser0" class="inputs" runat="server" Width="120px" 
                                                Height="18px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="2" class="style2" align="center">
                                            备&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtMark" class="inputs" runat="server" Height="59px"
                                                TextMode="MultiLine" Width="330px" ReadOnly="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click" />
                                        </td>
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
