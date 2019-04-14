<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeetingDetails.aspx.cs" Inherits="Meeting_MyMeetingInfo" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看会议纪要详情</title>

    <script language="javascript" src="../js/calendar.js" type="text/javascript">

</script>

    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .style4
        {
            width: 100%;
            background-color: #C6DAF3;
            height: 511px;
        }
        .style5
        {
            height: 55px;
        }
        .style6
        {
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div style="text-align: center" class="style4">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td height="30" colspan="3" class="title1">
                    <h3>
                        会议纪要详细信息</h3>
                </td>
            </tr>
        </table>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
            <tr>
                <td style="height: 25px">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="80%" cellpadding="2" cellspacing="1" border="0" class="px12" style="font: menu">
                        <tr>
                            <td align="right" class="style1">
                                标题：
                            </td>
                            <td align="left" style="height: 14px">
                                <asp:Label ID="lblRoomName" runat="server" Text="我的地盘我做主"></asp:Label>
                            </td>
                        <tr>
                            <td align="right" class="style2">
                                开始时间：
                            </td>
                            <td align="left" style="height: 24px">
                                <input readonly="readonly" name="startDate8" id="txtBeginTime" 
                                    value="2009-09-09" style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style3">
                                结束时间：
                            </td>
                            <td align="left" style="height: 2px">
                                <input readonly="readonly" name="startDate9" id="txtEndTime" value="2003-09-09" style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                主持人：
                            </td>
                            <td align="left">
                                <input readonly="readonly" name="startDate5" id="txtCompere" value="李伟豪" style="border-right: #99ccff 1px solid;
                                    border-top: #99ccff 1px solid; border-left: #99ccff 1px solid; border-bottom: #99ccff 1px solid"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style9">
                                会议类型：
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlMeetingType" runat="server" class="inputs">
                                    <asp:ListItem>普通会议</asp:ListItem>
                                    <asp:ListItem>紧急会议</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style3">
                                参与者：
                            </td>
                            <td align="left" style="height: 2px">
                                <textarea name="txtVisitor" id="txtVisitor" class="TxCss" style="height: 130px; width: 380px;
                                    border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid;" runat="server" readonly="readOnly" cols="20"
                                    rows="1" onclick="return txDes0_onclick()">陈单玲、李程、周伟、王康、黄璜、朱元当</textarea>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style3">
                                缺席者：
                            </td>
                            <td align="left" style="height: 2px">
                                <textarea name="txDes1" id="txtMissingPeople" class="TxCss" style="height: 130px; width: 380px;
                                    border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid;" runat="server" readonly="readOnly" cols="20"
                                    rows="1">陈单玲</textarea>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style5">
                                会议内容：
                            </td>
                            <td align="left" class="style6">
                                <textarea name="txDes" id="txtMeetingContent" class="TxCss" style="height: 130px; width: 380px;
                                    border-right: #99ccff 1px solid; border-top: #99ccff 1px solid; border-left: #99ccff 1px solid;
                                    border-bottom: #99ccff 1px solid;" runat="server" readonly="readOnly">通知。本周六下午召开小组会议，请大家准备好！</textarea>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 25px" align="center">
                                &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
                                <input id="btnReturn" type="button" value="返　回" class="BigButton" onclick="history.go(-1);" />
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
