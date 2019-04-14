<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BorrowInfo.aspx.cs" Inherits="ResourceManager_ApplicationResource" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资源借用录入</title>
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
            width: 100%;
            height: 122px;
            background-color: #C6DAF3;
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
                        资源借用录入</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="height: 337px">
                        <tr align="left">
                            <td>
                                资源名称：<asp:TextBox ID="txtResourceName" class="inputs" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="资源名称不能为空" ControlToValidate="txtResourceName">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                资源规格：<asp:TextBox ID="txtResourceName0" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="资源名称不能为空"
                                    ControlToValidate="txtResourceName">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                借用数量：<asp:TextBox ID="txtResourceName1" class="inputs" runat="server" Width="120px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="资源名称不能为空"
                                    ControlToValidate="txtResourceName">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                借用时间：<input type="text" onclick="showcalendar(event, this);" id="txtStartTime" runat="server"
                                    style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid; width:120px;" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                        runat="server" ErrorMessage="*" ControlToValidate="txtStartTime" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                归还时间：<input type="text" onclick="showcalendar(event, this);" id="Text1" runat="server"
                                    style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid; width:120px;" /><asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                        runat="server" ErrorMessage="*" ControlToValidate="txtStartTime" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                借&nbsp; 用&nbsp;人：<asp:TextBox ID="txtUser" class="inputs" runat="server" Width="120px"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator7" runat="server" ErrorMessage="使用人不能为空" ControlToValidate="txtUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style3">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：<asp:TextBox ID="txtResourceName5" class="inputs"
                                    runat="server" Height="108px" TextMode="MultiLine" Width="416px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="提   交" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" class="BigButton" Text="取   消" />
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
