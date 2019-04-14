<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyBorrowInfo.aspx.cs"
    Inherits="ResourceManager_ApplyBorrowInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源借用申请详情</title>
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
        .style4
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
                <td>
                    <table class="style1">
                        <tr>
                            <td align="center" class="title1">
                                <h3>
                                    资源借用申请详情</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table style="width: 545px">
                                    <tr align="left">
                                        <td>
                                            申请单号：<asp:TextBox ID="txtApplyNum0" class="inputs" runat="server" Width="120px" ReadOnly="True">数据绑定</asp:TextBox>
                                        </td>
                                        <td>
                                            申请时间：<input type="text" onclick="showcalendar(event, this);" id="txtStartTime" runat="server"
                                                style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                                border-bottom: #99ccff 1px solid; width:120px;" readonly="readonly" value="数据绑定" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            紧急程度：<asp:TextBox ID="txtStatus" class="inputs" runat="server" Width="120px" ReadOnly="True">数据绑定</asp:TextBox>
                                        </td>
                                        <td>
                                            借 用 人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120px" ReadOnly="True">数据绑定</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td>
                                            是否审批：<asp:TextBox ID="txtUser0" class="inputs" runat="server" Width="120px" ReadOnly="True">数据绑定</asp:TextBox>
                                        </td>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td colspan="2" class="style2" align="center">
                                            备&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtMark" class="inputs" runat="server" Height="59px"
                                                TextMode="MultiLine" Width="330px" ReadOnly="True">数据绑定</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="title2" align="left">
                                            <h5>
                                                借用资源列表</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table style="width: 100%" cellpadding="0" cellspacing="0">
                                                <tr align="center" class="TableHeader">
                                                    <td class="style4">
                                                        序号
                                                    </td>
                                                    <td class="style4">
                                                        资源名称
                                                    </td>
                                                    <td class="style4">
                                                        资源类型
                                                    </td>
                                                    <td class="style4">
                                                        资源数量
                                                    </td>
                                                    <td class="style4">
                                                        购买时间
                                                    </td>
                                                    <td class="style4">
                                                        资源状态
                                                    </td>
                                                    <td class="style4">
                                                        资源规格
                                                    </td>
                                                </tr>
                                                <tr align="center" class="TableContent">
                                                    <td class="style4">
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                </tr>
                                                <tr align="center" class="TableContent">
                                                    <td class="style4">
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                </tr>
                                                <tr align="center" class="TableContent">
                                                    <td class="style4">
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                </tr>
                                                <tr align="center" class="TableContent">
                                                    <td class="style4">
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                </tr>
                                                <tr align="center" class="TableContent">
                                                    <td class="style4">
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                    <td>
                                                        数据绑定
                                                    </td>
                                                </tr>
                                                </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnAuditing" runat="server" class="BigButton" OnClick="btnAuditing_Click"
                                                Text="审   批" />
                                            <asp:Button ID="btnEdit" runat="server" class="BigButton" Text="修   改" OnClick="btnEdit_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
