<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateMeeting.aspx.cs" Inherits="MeetingManager_UpdateMeeting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改会议纪要</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" rel="Stylesheet" />

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="MeetingList.aspx">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center" class="style4">
        <tr>
            <td style="height: 25px" class="title1">
                <h3>
                    修改会议纪要</h3>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 442px">
                <table width="80%" cellpadding="2" cellspacing="1" border="0" style="font: menu">
                    <tr>
                        <td align="right" style="height: 14px; width: 93px;">
                            标题：
                        </td>
                        <td align="left" style="height: 14px">
                            <asp:TextBox ID="txtTitle" runat="server" Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid">会议通知</asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 93px; height: 24px">
                            开始时间：
                        </td>
                        <td align="left" style="height: 24px">
                            <asp:TextBox ID="txtStartTime" runat="server" onclick="showcalendar(event, this);"
                                Style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                border-bottom: #99ccff 1px solid">2010-05-02</asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="txtStartTime"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtEndTime"
                                ControlToValidate="txtStartTime" ErrorMessage="会议开始时间应在当前时间之前" Operator="LessThan"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 93px; height: 2px">
                            结束时间：
                        </td>
                        <td align="left" style="height: 2px">
                            <asp:TextBox ID="txtEndTime" runat="server" onclick="showcalendar(event, this);"
                                Style="border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                border-bottom: #99ccff 1px solid">2010-05-03</asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="txtEndTime"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtStartTime"
                                ControlToValidate="txtEndTime" ErrorMessage="结束时间应在开始时间之后" Operator="GreaterThan"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 93px; height: 2px">
                            参与者：
                        </td>
                        <td align="left" style="height: 2px">
                            <input id="txtVisitor" runat="server" name="txtOtherMan" style="border: 1px solid #99ccff;
                                width: 355px; height: 67px;" type="text" value="陈单玲、李程、王康、周伟" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                                    runat="server" ErrorMessage="*" ControlToValidate="txtOtherMan"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 93px; height: 2px">
                            缺席者：
                        </td>
                        <td align="left" style="height: 2px">
                            <input id="txtMissingPeople" runat="server" class="TxCss" name="txtabsentMan"
                                style="border: 1px solid #99ccff; width: 354px; height: 68px;" type="text" value="黄璜、朱元当" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 93px; height: 2px">
                            &nbsp;主持人：
                        </td>
                        <td align="left" style="height: 2px">
                            <asp:DropDownList ID="ddlDepartMent" runat="server" Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                Height="16px" Width="90px">
                                <asp:ListItem Selected="True">人事部</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:DropDownList ID="ddlCompere" runat="server" Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                Height="16px" Width="90px">
                                <asp:ListItem Selected="True">老张</asp:ListItem>
                                <asp:ListItem>紧急会议</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 93px; height: 2px">
                            会议类型：
                        </td>
                        <td align="left" style="height: 2px">
                            <asp:DropDownList ID="ddlMeetingType" runat="server" Style="border-right: #99ccff 1px solid;
                                border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                Height="16px" Width="90px">
                                <asp:ListItem Selected="True">普通会议</asp:ListItem>
                                <asp:ListItem>紧急会议</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" style="width: 93px">
                            内容：
                        </td>
                        <td align="left">
                            <textarea name="txtMeetintContent" rows="2" cols="20" id="txtMeetintContent" class="TxCss" style="height: 100px;
                                width: 450px; border-right: #99ccff 1px solid; border-top: #99ccff 1px solid;
                                border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid;" runat="server">IT行业的飞速发展带给我们许多惊喜</textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ControlToValidate="txDes"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 25px" align="center">
                            &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="保   存" 
                                CssClass="BigButton" onclick="btnSubmit_Click" />
                            &nbsp;&nbsp;
                            <input id="btnExit" type="button" value="返　回" onclick="history.go(-1);" class="BigButton" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div>
    </div>
    </form>
</body>
</html>
