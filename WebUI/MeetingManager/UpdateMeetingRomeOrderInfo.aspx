<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateMeetingRomeOrderInfo.aspx.cs"
    Inherits="MeetingManager_UpdateMeetingRomeOrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改会场安排信息</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-size: 9pt; /* 字体大小                  */
            font-family: Verdana; /* 字体名称                  */
        }
        input.BigButton
        {
            border: 1px solid #666666;
            font-size: 12px;
            background-image: url(  '../css/6/images/button_bg.gif' );
            height: 20px;
            background-color: #ffffff;
        }
        #Select1
        {
            width: 89px;
        }
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="SelMeetingRomeOrderInfo.aspx">
    <div class="style4">
        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td class="title1">
                    <h3>
                        修改会场预定信息</h3>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 442px">
                    <table width="80%" cellpadding="2" cellspacing="1" border="0" style="font: menu;
                        height: 449px;">
                        <tr>
                            <td align="right" style="height: 14px; width: 93px;">
                                会场名称：
                            </td>
                            <td align="left" style="height: 14px">
                                <asp:TextBox ID="txtTitle" runat="server" Style="border-right: #99ccff 1px solid;border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                    Width="180px">第一会议室</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 24px">
                                开始时间：
                            </td>
                            <td align="left" style="height: 24px">
                                <input id="txtStartTime" name="txFDate1" type="text"  onclick="showcalendar(event, this);" style="width: 180px;
                                    height: 17px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" value="2009-03-04 10:00:00"
                                    runat="server" size="20" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        runat="server" ErrorMessage="*" ControlToValidate="txtStartTime"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtStartTime"
                                    ControlToValidate="txtEndTime" ErrorMessage="会议开始时间应在当前时间之前" Operator="LessThan"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                结束时间：
                            </td>
                            <td align="left" style="height: 2px">
                                <input id="txtEndTime" name="txFDate" type="text" value="2009-05-04 10:00:00" onclick="showcalendar(event, this);"
                                    style="width: 180px; height: 17px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                    border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server" /><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtEndTime"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtEndTime"
                                    ControlToValidate="txtStartTime" ErrorMessage="结束时间应在开始时间之后" Operator="GreaterThan"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                会议负责人：
                            </td>
                            <td align="left" style="height: 2px">
                                <asp:TextBox ID="txtCharger" runat="server" Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                    Width="180px">陈单玲</asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtCharger"></asp:RequiredFieldValidator>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                会议类型：
                            </td>
                            <td align="left" style="height: 2px">
                                <asp:DropDownList ID="droType0" runat="server" Style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                    Height="16px" Width="90px">
                                    <asp:ListItem Selected="True">营销会议</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                会场状态：
                            </td>
                            <td align="left" style="height: 2px">
                                <select id="Select1" name="D1">
                                    <option selected="selected">使用中</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 93px; height: 2px">
                                &nbsp;紧急程度：
                            </td>
                            <td align="left" style="height: 2px">
                                <input type="radio" id="rdoInstancy" checked />紧急&nbsp;&nbsp;
                                <input type="radio" id="rdoCommon" />一般
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" style="width: 93px">
                                内容：
                            </td>
                            <td align="left">
                                <textarea name="txDes" rows="2" cols="20" id="txDes" style="height: 100px; width: 450px;
                                    border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid;" runat="server">周日要加班啦！赴项目，加油</textarea>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="txDes"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 25px" align="center">
                                <asp:Button ID="Button2" runat="server" Text="保  存" PostBackUrl="~/MeetingManager/SelMeetingRomeOrderInfo.aspx" CssClass="BigButton"/>
                                &nbsp;
                                &nbsp;&nbsp;
                                <input id="btnExit" type="button" value="返  回" onclick="history.go(-1);" class="BigButton" />
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
