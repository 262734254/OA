<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Matter.aspx.cs" Inherits="OfficeHelp_LeaveMessage_ShowMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>待办事宜列表</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet" />
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #C6DAF3">
        <!---留言消息-->
        <div class="title1">
            <h3>
                待办事宜</h3>
        </div>
        <fieldset style="border: 1px solid #CCCCCC; text-align: center; padding-left: 25px;
            width: 90%">
            <br />
            <div style="height: 31px; width: 745px;">
                按办理状态：<select id="Select4" class="SmallStatic" name="D4">
                    <option selected="selected">待办</option>
                    <option>已办</option>
                    <option>受理中</option>
                </select>
                按申请类型：<select id="Select1" class="SmallStatic" name="D4">
                    <option selected="selected">用车申请</option>
                    <option>会议申请信息</option>
                    <option>车辆采购申请</option>
                    <option>资源借用申请</option>
                    <option>资源采购申请</option>
                    <option>资源借用申请</option>
                </select>
                <input id="btnExit" type="button" value="查询" class="BigButton" onclick="history.go(-1);" /></div>
            <div>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </fieldset>
        <table style="width: 750px; height: 176px; margin-top: 0px;" cellpadding="0" cellspacing="0">
            <tr align="center" class="TableHeader">
                <td>
                    主题
                </td>
                <td>
                    申请人
                </td>
                <td>
                    申请时间
                </td>
                <td>
                    申请类型
                </td>
                <td>
                    状态</td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    会议申请
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/MeetingManager/MeetingExamine.aspx">待办</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    会议申请
                </td>
                <td>
                   <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/MeetingManager/MeetingExamine.aspx">待办</asp:LinkButton>
                    &nbsp;
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    资源借用申请
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Enabled="false">办理中</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    资源采购申请
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton3_Click" Enabled="false">办理中</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    车辆使用申请
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton3_Click" Enabled="false">办理中</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    车辆采购申请
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/CarManager/GouCheShenPi.aspx">办理中</asp:LinkButton>
                    &nbsp;
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    数据绑定
                </td>
                <td>
                    任务执行进展申请
                </td>
                <td>
                   <asp:LinkButton ID="LinkButton7" runat="server" 
                        PostBackUrl="~/TaskManager/AssignTask.aspx">待办</asp:LinkButton>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    共有<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    记录&nbsp;&nbsp; |&nbsp;&nbsp; 共有<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
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
