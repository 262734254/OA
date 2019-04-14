<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CallBack.aspx.cs" Inherits="CallBack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>回收记录录入页面</title>
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
            height: 123px;
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
                        资源回收录入</h3>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <table style="height: 289px; width: 525px;">
                        <tr align="left">
                            <td>
                                资源名称：<asp:TextBox ID="txtResourceName" class="inputs" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="资源名称不能为空" ControlToValidate="txtResourceName">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                资源规格：<asp:TextBox ID="txtResourceSpec" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtResourceSpec"
                                    ErrorMessage="资源规格不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                回收数量：<asp:TextBox ID="txtCallBackNum" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCallBackNum"
                                    ErrorMessage="回收数量不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                回收时间：<input type="text" onclick="showcalendar(event, this);" id="txtStartTime" runat="server"
                                    style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid; width:120px;" />
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtStartTime" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" class="style3">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="81px" TextMode="MultiLine" Width="387px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMark"
                                    ErrorMessage="备注不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="确   定" class="BigButton" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="重   置" class="BigButton" />
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
