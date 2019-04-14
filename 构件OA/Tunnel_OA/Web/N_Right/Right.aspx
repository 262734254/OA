<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Right.aspx.cs" Inherits="N_Right_Right" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>无标题文档</title>
    <link href="../css/Css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .STYLE1
        {
            color: #FF0000;
            font-size: 18px;
            font-weight: bold;
        }
        .STYLE2
        {
            color: #38699d;
            font-size: 24px;
            font-weight: bold;
        }
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form runat="server" id="form1">
    <table width="160" border="0" cellpadding="0" cellspacing="0" style="border: 1px #ccccc solid">
        <tr>
            <td width="50%" align="center" valign="top">
                <table width="98%" id="listtable" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="26" id="listtablemenu" style="background: url(../images/bt1.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="87%" align="left">
                                        &nbsp;本月明星员工
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="143" valign="top" bgcolor="#FFFFFF">
                            <table width="100%" height="143" border="0" cellpadding="0" cellspacing="0" style="background-image: url(../images/DGjm_03.gif);
                                background-repeat: repeat-x;">
                                <tr>
                                    <td width="50%" height="143" align="center" valign="top">
                                        <table width="93" height="101" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="92" height="117" colspan="2" align="center" valign="middle" style="background: url(../images/rr_01.gif) no-repeat">
                                                    <img src='<%=img %>' width="83" height="106" border="0" style="cursor: hand" onclick="javascript:window.open('MingXing.aspx?id=<%=mxId %>', '明星员工', 'height=517, width=565,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25" align="center">
                                                    <asp:Label ID="lblcontent" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="50%" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="birthdaytable">
                                            <tr>
                                                <td height="30" colspan="2" align="center">
                                                    <img src="../images/photo_01.gif" width="13" height="18" /><%=name %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="41%" height="30" align="center">
                                                    部门：
                                                </td>
                                                <td width="59%" height="30" align="left">
                                                    <%=bum %>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30" align="center">
                                                    职务：
                                                </td>
                                                <td height="30" align="left">
                                                    <%=duty %>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="26" id="listtablemenuc" style="background: url(../images/bt1.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="87%" align="left">
                                        &nbsp;生日祝福
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" bgcolor="#FFFFFF">
                            <table width="99%" height="105" border="0" cellpadding="0" cellspacing="0" style="background-image: url(../images/DGjm_07.gif);
                                background-repeat: repeat-x;">
                                <tr>
                                    <td width="42%" height="103" valign="bottom">
                                        <img src="../images/zhufuimg.gif" width="86" height="83" />
                                    </td>
                                    <td width="58%">
                                        <table width="100%" height="45" border="0" cellpadding="0" cellspacing="0" id="birthdaytable">
                                            <tr>
                                                <td height="30" align="center">
                                                    <span class="STYLE1">
                                                        <%=showShengRi()%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span class="STYLE2">生日快乐</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="26" id="listtablemenuc" style="background: url(../images/bt1.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="87%" align="left">
                                        &nbsp;快捷导航
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="middle" bgcolor="#FFFFFF">
                            <table width="99%" border="0" cellpadding="0" cellspacing="0" style="background: url(../images/DGjm_11.gif) repeat-x">
                                <tr>
                                    <td width="58%">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="11%" height="19" align="center" style="font-size: 12px; font-weight: bold">
                                                    ·
                                                </td>
                                                <td width="89%" align="left">
                                                    <a href="../N_News/N_OnlineUser/N_OnlineUser.aspx" target="_blank">登陆排行榜</a>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="11%" height="19" align="center" style="font-size: 12px; font-weight: bold">
                                                    ·
                                                </td>
                                                <td width="89%" align="left">
                                                    <a href="../N_MyWork/N_Report/PK_ProjectManager.aspx" target="_blank">项经部排名</a>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="11%" height="19" align="center" style="font-size: 12px; font-weight: bold">
                                                    ·
                                                </td>
                                                <td width="89%" align="left">
                                                    <a href="../N_News/N_Tel/N_TelList.aspx" target="_blank">通讯录</a>
                                                </td>
                                            </tr>
                                        </table>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="11%" height="19" align="center" style="font-size: 12px; font-weight: bold">
                                                    ·
                                                </td>
                                                <td width="89%" align="left">
                                                    <a href="../N_Index/DataTypeList.aspx?typeId=30&lanmuId=0" target="mainFrame">分公司一周安排</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="26" id="listtablemenuc" style="background: url(../images/bt1.gif) repeat-x">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="82%" align="left">
                                        &nbsp;日程提示
                                    </td>
                                    <td width="18%" align="left">
                                        <a href="../N_Calendar/Calendar.html" target="mainFrame">
                                            <img src="../images/date_01.gif" border="0" width="14px" height="14px"></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top" bgcolor="#FFFFFF" height="119" style="background: url(../images/DGjm_15.gif) repeat-x">
                            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
                                <ItemTemplate>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="11%" height="20" align="center" style="font-size: 12px; font-weight: bold">
                                                ·
                                            </td>
                                            <td width="65%" align="left">
                                                <a style="color: Black" href='../N_Calendar/CalendarInfo.aspx?id=<%#Eval("w_id") %>'
                                                    target="mainFrame">
                                                    <%#showTitle(Eval("w_title"),Eval("w_starttime"))%></a>
                                            </td>
                                            <td width="24%" align="left">
                                                <%#Eval("w_starttime","{0:MM-dd}")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                                SelectCommand="SELECT top 10 [w_id], [w_title], [w_content], [w_starttime], [w_endtime], [w_depict], [w_user] FROM [Tunnel_workplan] WHERE ([w_user] = @w_user) ORDER BY [w_starttime]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="HiddenField1" DefaultValue="0" Name="w_user" PropertyName="Value"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    </form>
</body>
</html>
