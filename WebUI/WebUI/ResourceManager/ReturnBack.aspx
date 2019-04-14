<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnBack.aspx.cs" Inherits="Return" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>归还记录录入页面</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td align="center" class="title1">
                    <h3>
                        资源归还录入</h3>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <table style="height: 274px">
                        <tr align="left">
                            <td>
                                借用单号：<asp:TextBox ID="txtBorrowNo" class="inputs" runat="server" Width="120px" AutoPostBack="True"
                                    OnTextChanged="txtBorrowNo_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvBorrowNo" runat="server" ErrorMessage="借用单号不能为空"
                                    ControlToValidate="txtBorrowNo">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                资源名称：<asp:DropDownList ID="ddlName" runat="server" DataTextField="RIName" DataValueField="RIID"
                                    Width="120px">
                                    <asp:ListItem Selected="True" Value="0">--请选择--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                归还数量：<asp:TextBox ID="txtRebackNum" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRebackNum" runat="server" ControlToValidate="txtRebackNum"
                                    ErrorMessage="归还数量不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                归还时间：<input id="txtTime" name="txFDate" type="text" value="" style="width: 120px;
                                    height: 17px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server"
                                    onclick="showcalendar(event, this);" readonly="readonly" /><asp:RequiredFieldValidator
                                        ID="rfvTime" runat="server" ErrorMessage="*" ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                归&nbsp; 还&nbsp;人：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUser"
                                    ErrorMessage="使用人不能为空">*</asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hfUID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs"
                                    runat="server" Height="96px" TextMode="MultiLine" Width="439px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMark"
                                    ErrorMessage="备注不能为空">*</asp:RequiredFieldValidator>
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
    <asp:ValidationSummary ID="vsReturnBack" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
