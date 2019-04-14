<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationMeetingDetail.aspx.cs" Inherits="MeetingManager_ApplicationMeetingDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会议申请单详情页面</title>
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <link href="../css/public.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript"></script>

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
    <form id="form1" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center" class="style4">
        <tr>
            <td style="height: 25px" class="title1" align="center">
                <h3>
                    会议申请单详情</h3>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 270px">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                    <tr>
                        <td class="td_page">
                            <div align="right">
                                <input  name="Submit" onclick="location.href='ApplictionMeetingList.aspx'" 
                                    type="button" class="BigButton" value="  返 回  " />
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
                <table align="center" border="0" cellpadding="0" cellspacing="0" 
                    class="table01" width="95%">
                    <tr>
                        <td class="td_02" height="30" width="15%">
                            <div align="center">
                                主办部门</div>
                        </td>
                        <td class="td_02" width="35%">
                            人事部</td>
                        <td class="td_02" width="15%">
                            <div align="center">
                                会议类型</div>
                        </td>
                        <td class="td_02" width="35%">
                            一般会议</td>
                    </tr>
                    <tr>
                        <td class="td_02" height="30">
                            <div align="center">
                                会议名称</div>
                        </td>
                        <td class="td_02">
                            会议1</td>
                        <td class="td_02">
                            <div align="center">
                                会议室</div>
                        </td>
                        <td class="td_02">
                            会议室1</td>
                    </tr>
                    <tr>
                        <td class="td_02" height="30">
                            <div align="center">
                                主持人</div>
                        </td>
                        <td class="td_02">
                            xxx</td>
                        <td class="td_02">
                            <div align="center">
                                纪要人</div>
                        </td>
                        <td class="td_02">
                            xxx</td>
                    </tr>
                    <tr>
                        <td class="td_02" height="30">
                            <div align="center">
                                开始时间</div>
                        </td>
                        <td class="td_02">
                            2008-10-10 08:00
                        </td>
                        <td class="td_02">
                            <div align="center">
                                结束时间</div>
                        </td>
                        <td class="td_02">
                            2008-10-10 10:00
                        </td>
                    </tr>
                    <tr>
                        <td class="td_02" height="30">
                            <div align="center">
                                与会人员</div>
                        </td>
                        <td class="td_02" colspan="3">
                            xxx、yyy、ddd、aaa</td>
                    </tr>
                    <tr>
                        <td class="td_02" height="30">
                            <div align="center">
                                会议内容概要</div>
                        </td>
                        <td class="td_02" colspan="3">
                            xxx</td>
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
