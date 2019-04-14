<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelMeetingRomeOrderInfo.aspx.cs"
    Inherits="MeetingManager_MyMeetingRome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会议室预定信息</title>
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 167px;
            width: 90%;
        }
        .style4
        {
            width: 100%; 
            background-color:#C6DAF3;
        }
        .style5
        {
            width: 79px;
        }
        .style6
        {
            width: 645px;
        }
        .style7
        {
            height: 163px;
        }
        </style>
        <script type="text/javascript">
        function selAll(obj)
        {
            var items=document.getElementsByTagName("input");
            for(var i=0;i<items.length;i++)
            {
                if(items[i]!=null&&items[i].type=="checkbox")
                {
                    items[i].checked=obj.checked;
                }
            }
        }
    </script>
</head>
<body>
    <form id="Form2" runat="server" method="post" name="form1">
    <div class="style4">
    <table class="title1">
        <tr>
            <td class="style6">
                <span class="big3">
                    &nbsp;会议室定制记录</span>
            </td>
            <td>
                <a href="SelMeetingRome.aspx">预定会议室</a></td>
        </tr>
    </table>
    <br />
    <fieldset style="border: 1px solid #CCCCCC; text-align: center;">

            会议室名称：<input type="text" name="meetingName" style="border: 1px solid #99ccff; width: 134px;"
                size="34" id="Text1" runat="server" />&nbsp;&nbsp;&nbsp;开始时间：从<input type="text" name="beginTime" style="border: 1px solid #99ccff; width: 136px;"
                size="34" id="Text2" runat="server"  onclick="showcalendar(event, this);" />&nbsp;&nbsp;到&nbsp;
            <input type="text" name="endTime" style="border: 1px solid #99ccff; width: 146px;"
                size="34" id="Text3" runat="server" onclick="showcalendar(event, this);" />
            <input id="btnExit" type="button" value="查询" class="BigButton" />
    </fieldset>
    <br />
    <br />
     <table width="100%">
        <tr>
            <td>
                <input id="btnDelAll" type="button" value="删除" runat="server" class="BigButton" /><br />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1" cellpadding="0" cellspacing="0">
                    <tr align="center" class="TableHeader">
                        <td class="style5">
                            全选<input type="checkbox" onclick="selAll(this)" /></td>
                        <td>
                            序号</td>
                        <td>
                            开始时间</td>
                        <td>
                            结束时间</td>
                        <td>
                            会议类型</td>
                        <td>
                            <a href="UpdateMeetingRomeOrderInfo.aspx">修改</a></td>
                        <td>
                            删除</td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td class="style5">
                            <input type="checkbox" onclick="selAll(this)" /></td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UpdateMeetingRomeOrderInfo.aspx">修改</a></td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton></td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td class="style5">
                            <input type="checkbox" onclick="selAll(this)" /></td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UpdateMeetingRomeOrderInfo.aspx">修改</a></td>
                        <td>
                            <asp:LinkButton ID="LinkButton2" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton></td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td class="style5">
                            <input type="checkbox" onclick="selAll(this)" /></td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UpdateMeetingRomeOrderInfo.aspx">修改</a></td>
                        <td>
                            <asp:LinkButton ID="LinkButton3" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton></td>
                    </tr>
                    <tr align="center" class="TableContent">
                        <td class="style5">
                            <input type="checkbox" onclick="selAll(this)" /></td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            数据绑定</td>
                        <td>
                            <a href="UpdateMeetingRomeOrderInfo.aspx">修改</a></td>
                        <td>
                          <asp:LinkButton ID="LinkButton4" runat="server" 
                        OnClientClick="return confirm('确定要删除？')" >删除</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style7" valign="top">
                    共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" 
                    Text="Label"></asp:Label>
                页&nbsp; |&nbsp;&nbsp;
                <asp:LinkButton ID="lnkfirst" runat="server">首页</asp:LinkButton>
&nbsp;
                <asp:LinkButton ID="lnkprev" runat="server">上一页</asp:LinkButton>
&nbsp;
                <asp:LinkButton ID="lnknext" runat="server">下一页</asp:LinkButton>
&nbsp;&nbsp;
                <asp:LinkButton ID="lnklast" runat="server">尾页</asp:LinkButton>
                    </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
