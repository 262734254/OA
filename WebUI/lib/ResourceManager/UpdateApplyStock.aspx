<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateApplyStock.aspx.cs"
    Inherits="StockApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>采购申请修改页面</title>
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
            width: 327px;
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
                        采购申请修改</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="height: 373px">
                        <tr align="left">
                            <td class="style2">
                                申请单号：<asp:TextBox ID="txtResourceName" class="inputs" runat="server">数据绑定</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtResourceName"
                                    ErrorMessage="资源名称不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                申 请 人 ：<asp:TextBox ID="txtStockNorm" class="inputs" runat="server">数据绑定</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtStockNorm"
                                    ErrorMessage="采购规格不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                所需费用：<asp:TextBox ID="txtFunds" runat="server" class="inputs">数据绑定</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFunds"
                                    ErrorMessage="所需费用不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                采购时间：<input id="txtTime" name="txFDate" type="text" value="数据绑定" style="border: 1px solid #99ccff;
                                    width: 120px; height: 17px;" runat="server" 
                                    onclick="showcalendar(event, this);" /><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                采购原因：<asp:TextBox ID="txtCause" runat="server" class="inputs" Height="90px" TextMode="MultiLine"
                                    Width="333px">数据绑定</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCause"
                                    ErrorMessage="采购原因不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="90px" TextMode="MultiLine" Width="333px">数据绑定</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMark"
                                    ErrorMessage="备注不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2" align="left">
                                添加采购资源</th>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <table>
                                    <tr>
                                        <th>
                                            资源类型 
                                        </th>
                                        <th>
                                            资源名称 
                                        </th>
                                        <th>
                                            采购规格 
                                        </th>
                                        <th>
                                            采购数量 
                                        </th>
                                        <th>
                                            单价 
                                        </th>
                                        <th>
                                            供应商名称 
                                        </th>
                                        <th>
                                            操作 
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <asp:Label ID="Label2" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label3" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label4" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label5" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label6" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label7" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th align="center">
                                            <asp:Button ID="Button4" runat="server" class="BigButton" Text="修改" />
                                        &nbsp;<asp:Button ID="Button2" runat="server" class="BigButton" Text="删除" />
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <asp:Label ID="Label8" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label9" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label10" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label11" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label12" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label13" runat="server" Text="数据绑定"></asp:Label>
                                        </th>
                                        <th align="center">
                                            <asp:Button ID="Button5" runat="server" class="BigButton" Text="修改" />
                                        &nbsp;<asp:Button ID="Button3" runat="server" class="BigButton" Text="删除" />
                                        </th>
                                    </tr>
                                    <tr>
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
                                            <asp:TextBox ID="TextBox1" runat="server">数据绑定</asp:TextBox>
                                        </td>
                                        <td>
                                            数据绑定 
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList3" runat="server">
                                                <asp:ListItem>数据绑定</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="Button1" runat="server" class="BigButton" Text="确定"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSave" runat="server" class="BigButton" Text="保   存" 
                                    onclick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="取   消" 
                                    onclick="btnReset_Click" CausesValidation="False" />
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
