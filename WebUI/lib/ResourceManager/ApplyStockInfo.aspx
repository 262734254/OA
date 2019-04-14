<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyStockInfo.aspx.cs" Inherits="ResourceManager_ApplyStockInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购申请详情页面</title>
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
        .style2
        {
            width: 320px;
        }
        .style3
        {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="background-color: #C6DAF3">
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        采购申请详情</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td align="left" class="style2">
                                申 请 人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" ReadOnly="True" Width="120px">数据绑定</asp:TextBox>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;采购时间：<input id="txtTime" name="txFDate" type="text"
                                    value="数据绑定" style="border: 1px solid #99ccff; width: 120px; height: 17px;" runat="server"
                                    onclick="showcalendar(event, this);" readonly="readonly" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                所需费用：<asp:TextBox ID="txtFunds" runat="server" class="inputs" ReadOnly="True" Width="120px">数据绑定</asp:TextBox>
                            </td>
                            <td align="left">
                                是否通过审批：<asp:TextBox ID="txtFunds0" runat="server" class="inputs" ReadOnly="True"
                                    Width="120px">数据绑定</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                采购原因：<asp:TextBox ID="txtCause" runat="server" class="inputs" Height="90px" TextMode="MultiLine"
                                    Width="333px" ReadOnly="True">数据绑定</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="90px" TextMode="MultiLine" Width="333px" ReadOnly="True">数据绑定</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left">
                                采购资源
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <table width="98%">
                                    <tr align="center" class="TableHeader">
                                        <td class="style3">
                                            资源类型
                                        </td>
                                        <td>
                                            资源名称
                                        </td>
                                        <td>
                                            采购规格
                                        </td>
                                        <td>
                                            采购数量
                                        </td>
                                        <td>
                                            单价
                                        </td>
                                        <td>
                                            供应商名称
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td class="style3">
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
                                    </tr>
                                    <tr align="center">
                                        <td class="style3">
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
                                    </tr>
                                    <tr align="center">
                                        <td class="style3">
                                            <asp:Label ID="Label1" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label14" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Text="数据绑定"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnAuditing" runat="server" class="BigButton" Text="审   批" OnClick="btnAuditing_Click" />
                                <asp:Button ID="btnEdit" runat="server" class="BigButton" Text="修   改" OnClick="btnEdit_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click" />
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
