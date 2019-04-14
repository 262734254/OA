<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplictionMeetingList.aspx.cs"
    Inherits="MeetingManager_ApplictionMeetingList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会议申请列表</title>
    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <link href="../css/public.css" type="text/css" rel="stylesheet" />

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
            background-color: #C6DAF3;
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
            width: 804px;
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
                    <span class="title1">&nbsp;<h3>
                        会议列表</h3>
                    </span>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <fieldset style="border: 1px solid #CCCCCC; text-align: center;">
            会议名称：<input name="textfield" type="text">&nbsp;主办部门：<asp:DropDownList ID="DropDownList2" class="inputs" runat="server">
                <asp:ListItem>人事部</asp:ListItem>
                <asp:ListItem>工程部</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <input id="btnExit" type="button" value="查询" class="BigButton" />
        </fieldset>
        <br />
        <br />
        <table width="100%">
            <tr>
                <td class="style7">
                    &nbsp;
                </td>
                <td>
                    <input name="Submit" type="button" class="BigButton" value="召开会议" onclick="location.href='ApplicationMeeting.aspx'">  </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table class="style1" cellpadding="0" cellspacing="0">
                        <tr align="center" class="TableHeader">
                            <td class="style5">
                                全选
                                <td class="style5">
                                    会议名称<td>
                                        会议室
                                    </td>
                                    <td>
                                        主办部门
                                    </td>
                                    <td>
                                        开始时间
                                    </td>
                                    <td>
                                        结束时间
                                    </td>
                                    <td>
                                        状态
                                    </td>
                                    <td>
                                        详情</td>
                                    <td>
                                        <a href="#">修改</a>
                                    </td>
                                    <td>
                                        <a href="#" onclick="javascript:return confirm('确认要删除吗？')">删除</a>
                                    </td>
                                </td>
                        </tr>
                        <tr align="center" class="TableContent">
                            <td class="style5">
                                <input type="checkbox" onclick="selAll(this)" />
                            </td>
                            <td class="style5">
                                人事部会议
                            </td>
                            <td>
                                会议室1
                            </td>
                            <td>
                                人事部
                            </td>
                            <td>
                                2010-05-06
                            </td>
                            <td>
                                2010-05-06
                            </td>
                            <td>
                                未召开
                            </td>
                            <td>
                                <a href="ApplicationMeetingDetail.aspx">详情</a></td>
                            <td>
                                <a href="MeetingExamine.aspx">修改</a>
                            </td>
                            <td>
                                <a href="#" onclick="javascript:return confirm('确认要删除吗？')">删除</a>
                            </td>
                        </tr>
                        <tr align="center" class="TableContent">
                            <td class="style5">
                                <input type="checkbox" onclick="selAll(this)" />
                            </td>
                            <td class="style5">
                                人事部会议
                            </td>
                            <td>
                                会议室3
                            </td>
                            <td>
                                人事部
                            </td>
                            <td>
                                2010-05-06
                            </td>
                            <td>
                                2010-05-06
                            </td>
                            <td>
                                已召开
                            </td>
                            <td>
                                <a href="ApplicationMeetingDetail.aspx">详情</a></td>
                            <td>
                                <a href="MeetingExamine.aspx">修改</a>
                            </td>
                            <td>
                                <a href="#" onclick="javascript:return confirm('确认要删除吗？')">删除</a>
                            </td>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td class="style5">
                    <input type="checkbox" onclick="selAll(this)" />
                </td>
                <td class="style5">
                    会议2
                </td>
                <td>
                    会议室2
                </td>
                <td>
                    工程部
                </td>
                <td>
                    2010-05-06
                </td>
                <td>
                    2010-05-06
                </td>
                <td>
                    未召开
                </td>
                <td>
                                <a href="ApplicationMeetingDetail.aspx">详情</a></td>
                <td>
                     <a href="MeetingExamine.aspx">修改</a>
                </td>
                <td>
                    <a href="#" onclick="javascript:return confirm('确认要删除吗？')">删除</a>
                </td>
            </tr>
            <tr align="center" class="TableContent">
                <td class="style5">
                    <input type="checkbox" onclick="selAll(this)" />
                </td>
                <td class="style5">
                    会议3
                </td>
                <td>
                    会议室1
                </td>
                <td>
                    工程部
                </td>
                <td>
                    2010-05-06
                </td>
                <td>
                    2010-05-06
                </td>
                <td>
                    未召开
                </td>
                <td>
                                <a href="ApplicationMeetingDetail.aspx">详情</a></td>
                <td>
                    <a href="MeetingExamine.aspx">修改</a>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            </table> </td> </tr>
            <tr>
                <td colspan="2">
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
