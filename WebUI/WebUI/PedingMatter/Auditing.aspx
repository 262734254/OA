<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Auditing.aspx.cs" Inherits="ResourceManager_Auditing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>申请审核</title>
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
                        申请审批</h3>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="height: 373px">
                        <tr align="left">
                            <td class="style2">
                                审批类型：<asp:TextBox ID="txtType" class="inputs" runat="server" 
                                    Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtType"
                                    ErrorMessage="审批类型不能为空">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                申请单号：<asp:TextBox ID="txtApplicationId" class="inputs" runat="server" 
                                    Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApplicationId"
                                    ErrorMessage="申请单号不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="style2">
                                审&nbsp; 批 人：<asp:TextBox ID="txtRequestMan" class="inputs" runat="server" 
                                    Enabled="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRequestMan"
                                    ErrorMessage="审批人不能为空">*</asp:RequiredFieldValidator>
                                
                            </td>
                            <td align="left">
                                审批时间：<input id="txtTime" name="txFDate" type="text" value="" style="border: 1px solid #99ccff;
                                    width: 120px; height: 17px;" runat="server"   readonly="readonly" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                是否通过：<asp:RadioButtonList ID="rdoAccess" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True">未过</asp:ListItem>
                                    <asp:ListItem>通过</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                审批意见：<asp:TextBox ID="txtCause" runat="server" class="inputs" Height="90px" TextMode="MultiLine"
                                    Width="333px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCause"
                                    ErrorMessage="审批意见不能为空">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：<asp:TextBox ID="txtMark" class="inputs" runat="server"
                                    Height="90px" TextMode="MultiLine" Width="333px"></asp:TextBox>
                               
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSubmit" runat="server" class="BigButton" Text="确   定" OnClick="btnSubmit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              
                                 <input id="btnExit" type="button" value="返　回" class="BigButton" onclick="history.go(-1);" />
                            </td>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
