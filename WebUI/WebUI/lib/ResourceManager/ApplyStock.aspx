<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplyStock.aspx.cs" Inherits="StockApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购申请录入页面</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>

    <style type="text/css">
        .style1
        {
            width: 100%;
            background-color: #C6DAF3;
        }
        .style2
        {
            width: 327px;
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
                        采购申请</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr align="left">
                            <td class="style2">
                                申 请 人 ：<asp:TextBox ID="txtResourceName" class="inputs" runat="server" Width="120"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtResourceName"
                                    ErrorMessage="资源名称不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                采购规格：<asp:TextBox ID="txtStockNorm" class="inputs" runat="server" Width="120"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStockNorm"
                                    ErrorMessage="采购规格不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                所需费用：<asp:TextBox ID="txtFunds" runat="server" class="inputs" Width="120"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFunds"
                                    ErrorMessage="所需费用不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                采购时间：<input id="txtTime" name="txFDate" type="text" value="" style="border: 1px solid #99ccff;
                                    width: 120px; height: 17px;" runat="server" onclick="showcalendar(event, this);" /><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                采购原因：<asp:TextBox ID="txtCause" runat="server" class="inputs" Height="90px" TextMode="MultiLine"
                                    Width="333px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCause"
                                    ErrorMessage="采购原因不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="90px" TextMode="MultiLine" Width="333px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMark"
                                    ErrorMessage="备注不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left">
                                采购资源
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
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
                                        <td>
                                            操作
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
                                        <td>
                                            <asp:Button ID="Button2" runat="server" class="BigButton" Text="删除" />
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
                                        <td>
                                            <asp:Button ID="Button3" runat="server" class="BigButton" Text="删除" />
                                        </td>
                                    </tr>
                                    <tr align="center">
                                        <td>
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
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="确   定" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click"
                                    CausesValidation="False" />
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
