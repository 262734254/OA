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
        .style5
        {
            width: 100%;
        }
        .style6
        {
            width: 122px;
        }
        .style7
        {
            width: 275px;
        }
        .style8
        {
            width: 165px;
        }
        #form1
        {
            height: 388px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" cellpadding="0" height="100%" cellspacing="0" border="0" align="center" class="style4">
        <tr>
            <td style="height: 25px" class="title1" align="center">
                <h3>
                    会议申请单详情</h3>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" >
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                    <tr>
                        <td class="td_page" valign="top">
                            <div align="right">
                                <input  name="Submit" onclick="location.href='ApplictionMeetingList.aspx'" 
                                    type="button" class="BigButton" value="  返 回  " />
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                    DataSourceID="odsApplicationDetail" Height="16px" Width="745px">
                    <Fields>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table class="style5" >
                                    <tr>
                                        <td class="style6">
                                            主办部门</td>
                                        <td class="style7">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("DepartmentID.Departmentname") %>'></asp:Label>
                                        </td>
                                        <td class="style8">
                                            会议类型</td>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("MeetType") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style6">
                                            会议名称</td>
                                        <td class="style7">
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("MeetTitle") %>'></asp:Label>
                                        </td>
                                        <td class="style8">
                                            会议室</td>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("RoomInfo.RoomName") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style6">
                                            主持人</td>
                                        <td class="style7">
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Compere") %>'></asp:Label>
                                        </td>
                                        <td class="style8">
                                            纪要人</td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("MeetingSummary") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style6">
                                            开始时间</td>
                                        <td class="style7">
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("BeginTime") %>'></asp:Label>
                                        </td>
                                        <td class="style8">
                                            结束时间</td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("EndTime") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style6">
                                            与会人员</td>
                                        <td colspan="3">
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("WithinEnlistMan") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style6">
                                            会议内容概要</td>
                                        <td colspan="3">
                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("MeetContent") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
                <asp:ObjectDataSource ID="odsApplicationDetail" runat="server" 
                    SelectMethod="GetMeetingApplicationById" 
                    TypeName="BLL.Meeting.MeetingApplicationManager">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="MSID" QueryStringField="MID" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
