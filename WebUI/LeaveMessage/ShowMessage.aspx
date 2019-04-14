<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowMessage.aspx.cs" Inherits="OfficeHelp_LeaveMessage_ShowMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消息列表</title>
   <link href="../css/public.css" type="text/css" rel="stylesheet"/> 
    <link href="../css/6/style.css" type="text/css" rel="Stylesheet" />  
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 37px;
        }
        .style3
        {
            height: 36px;
        }
        .style4
        {
            height: 42px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #C6DAF3">
        <!---留言消息-->
        <div class="title1">
            <h3>
                消息列表</h3>
        </div>
        <fieldset style="border: 1px solid #CCCCCC; text-align: center; padding-left: 25px;
            width: 90%">
            <br />
            <div style="height: 18px">
                按消息状态：<select id="Select4" class="SmallStatic" name="D4">
                                <option selected="selected">已读消息</option>
                                <option>未读消息</option>
                            </select>
                            按消息类型：<select id="Select1" class="SmallStatic" name="D4">
                                <option selected="selected">留言消息</option>
                                <option>会议申请信息</option>
                                <option>消息通知</option>
                                <option>通知反馈</option>
                                <option>留言回复</option>
                            </select>
            </div>
            <br />
            <div>
                按时间：<input type="radio" value="" />今日&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="radio" value="" />本周&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="radio" value="" />本月&nbsp;&nbsp;&nbsp;&nbsp;
                <input id="btnExit" type="button" value="查询" class="BigButton" onclick="history.go(-1);" />
            </div>
        </fieldset>
        <table style="width:750px; height:176px; margin-top: 0px;" cellpadding="0" 
            cellspacing="0">
            <tr align="center" class="TableHeader">
                <td class="style1">
                    主题
                </td>
                <td class="style1">
                    发送人
                </td>
                <td class="style1">
                    时间
                </td>
                <td class="style1">
                    类型
                </td>
                <td class="style1">
                    查看
                </td>
                <td class="style1">
                    删除
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td class="style2">
                    数据绑定
                </td>
                <td class="style2">
                    数据绑定
                </td>
                <td class="style2">
                    数据绑定
                </td>
                <td class="style2">
                    会议通知
                </td>
                <td class="style2">
                    <a href="MeetingInform.aspx">查看</a>
                </td>
                <td class="style2">
                                <asp:LinkButton ID="lnkBtnDel" runat="server" OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td class="style3">
                    数据绑定
                </td>
                <td class="style3">
                    数据绑定
                </td>
                <td class="style3">
                    数据绑定
                </td>
                <td class="style3">
                    留言
                </td>
                <td class="style3">
                    <a href="MessageDetails.aspx">查看</a>
                </td>
                <td class="style3">
                                <asp:LinkButton ID="lnkBtnDel0" runat="server" 
                        OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td class="style4">
                    数据绑定
                </td>
                <td class="style4">
                    数据绑定
                </td>
                <td class="style4">
                    数据绑定
                </td>
                <td class="style4">
                    通知反馈
                </td>
                <td class="style4">
                    <a href="FeedBackDetails.aspx">查看</a>
                </td>
                <td class="style4">
                                <asp:LinkButton ID="lnkBtnDel1" runat="server" 
                        OnClientClick="return confirm('确定要删除？')">删除</asp:LinkButton>
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
