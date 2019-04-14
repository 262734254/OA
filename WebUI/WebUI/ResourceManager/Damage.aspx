<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Damage.aspx.cs" Inherits="Damage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>损坏记录录入页面</title>
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
            height: 129px;
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
                        资源损坏录入</h3>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <table style="height: 447px; width: 521px">
                        <tr>
                            <td align="left">
                                借用单号：<asp:TextBox ID="txtBorrowNo" class="inputs" runat="server" Width="120px" AutoPostBack="True"
                                    OnTextChanged="txtBorrowNo_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvBorrowNo" runat="server" ControlToValidate="txtBorrowNo"
                                    ErrorMessage="借用单号不能为空">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revBorrowNo" runat="server" Display="Dynamic"
                                    ErrorMessage="请输入数字" ValidationExpression="^[0-9]*[1-9][0-9]*$" ControlToValidate="txtBorrowNo">*</asp:RegularExpressionValidator>
                            </td>
                            <td align="left">
                                资源名称：<asp:DropDownList ID="ddlName" runat="server" DataTextField="RIName" DataValueField="RIID"
                                    Width="120px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                损坏数量：<asp:TextBox ID="txtPreNum" class="inputs" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="rfvPreNum" runat="server" ErrorMessage="损坏数量不能为空" ControlToValidate="txtPreNum">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPreNum" runat="server" Display="Dynamic" ErrorMessage="请输入数字"
                                    ValidationExpression="^[0-9]*[1-9][0-9]*$" ControlToValidate="txtPreNum">*</asp:RegularExpressionValidator>
                            </td>
                            <td align="left">
                                损坏程度：<asp:TextBox ID="txtGrade" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvGrade" runat="server" ErrorMessage="损坏程度不能为空"
                                    ControlToValidate="txtGrade">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                损坏时间：<input type="text" onclick="showcalendar(event, this);" id="txtDrawTime" runat="server"
                                    style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid; width: 120px;" readonly="readonly" /><asp:RequiredFieldValidator
                                        ID="rfvDrawTime" runat="server" ErrorMessage="*" ControlToValidate="txtDrawTime"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left">
                                损&nbsp;坏&nbsp;人 ：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120px"
                                    ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUser"
                                    ErrorMessage="损坏人不能为空">*</asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hfUID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                损坏原因：<asp:TextBox ID="txtCause" class="inputs" runat="server" Width="329px" Height="67px"
                                    TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCause" runat="server" ControlToValidate="txtCause"
                                    ErrorMessage="损坏原因不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" class="style3">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtRemark" class="inputs"
                                    runat="server" Height="82px" TextMode="MultiLine" Width="325px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="确   定" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="返   回" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <asp:ValidationSummary ID="vsDamage" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </form>
</body>
</html>
