<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateCalender.aspx.cs" Inherits="Calendar_UpdateCalender" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改日程</title>
<link href="../css/6/style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript">
    </script>
    <style type="text/css">
         .style4
        {
            width: 100%; background-color:#C6DAF3;
            height: 511px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center" class="style4">
        <table width="750px;" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td class="title1">
                    <h3>
                        修改工作日程</h3>
                </td>
            </tr>
            <tr>
                <td style="height: 25px">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="750px;" cellpadding="2" cellspacing="1" border="0" style="font: menu">
                        <tr>
                            <td align="right" style="height: 14px; width: 93px;">
                                日程主题：</td>
                            <td align="left" style="height: 14px">
                                <asp:TextBox ID="txtTitle" ReadOnly="true" runat="server" 
                                    Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid" 
                                    Width="180px">下午开会</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 14px; width: 93px;">
                                办理时间：
                            </td>
                            <td align="left" style="height: 14px">
                                <input id="txtTime" name="txFDate" type="text" value="2010-12-11" style="width: 180px;
                                    height: 17px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server"
                                     onClick="showcalendar(event, this);" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 24px">
                                提醒时间：
                            </td>
                            <td align="left" style="height: 24px">
                                <input id="txtJackTime" name="txFDate" type="text" value="2010-12-10"
                                 onClick="showcalendar(event, this);"
                                    style="width: 180px; height: 17px; border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;"
                                    runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtJackTime"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtTime"
                                    ControlToValidate="txtJackTime" ErrorMessage="提醒的时间应该比办理时间早" Operator="LessThan"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                是否重复：
                            </td>
                            <td align="left" style="height: 2px">
                                <asp:RadioButton ID="RadioIs" runat="server" AutoPostBack="True" GroupName="radioR"
                                     Text="是" />
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                <asp:RadioButton ID="RadioNo" runat="server" AutoPostBack="True" Checked="True" GroupName="radioR"
                                     Text="否" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                类型：
                            </td>
                            <td align="left" style="height: 2px">
                                <asp:DropDownList ID="droType" runat="server" Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">
                                    <asp:ListItem>工作</asp:ListItem>
                                    <asp:ListItem>私人</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" style="width: 93px">
                                详细：
                            </td>
                            <td align="left">
                                <textarea name="txDes" rows="2" cols="20" id="txDes" style="height: 100px;
                                    width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server">天天向上</textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="txDes"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 25px" align="center">
                                &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="保　存" 
                                    CssClass="BigButton" PostBackUrl="~/Calendar/SelectCalender.aspx" />
                                &nbsp;&nbsp;
                                <input id="btnExit" type="button" class="BigButton" value="返　回" onclick="history.go(-1);" />
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
