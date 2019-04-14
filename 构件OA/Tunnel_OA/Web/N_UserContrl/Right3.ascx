<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Right2.ascx.cs" Inherits="N_UserContrl_Right" %>
<style type="text/css">
    <!
    -- table
    {
        font-size: 12px;
    }
    .STYLE1
    {
        color: #FFFFFF;
        font-weight: bold;
        font-size: 14px;
    }
    .STYLE2
    {
        color: #666666;
        font-weight: bold;
        font-size: 18px;
    }
    .STYLE3
    {
        color: #666666;
    }
    img
    {
        border: 0px;
    }
    .STYLE4
    {
        color: #666666;
        font-weight: bold;
        font-size: 14px;
    }
    .STYLE5
    {
        color: #39AAFF;
        font-weight: bold;
        font-size: 16px;
    }
    .STYLE8
    {
        font-size: 12px;
        color: #39AAFF;
    }
    .STYLE9
    {
        color: #999999;
        font-size: 12px;
    }
    .STYLE10
    {
        color: #347EA0;
        font-weight: bold;
        font-size: 15px;
    }
    .STYLE13
    {
        font-size: 12px;
        color: #9D9E9D;
    }
    .STYLE15
    {
        color: #666666;
        font-size: 15px;
        font-weight: bold;
    }
    .star
    {
        position: absolute;
        z-index: 3;
        width: 38px;
        margin: -15px 0 0 53px;
    }
    -- ></style>
<table id="01" width="166" height="1026" border="0" cellpadding="0" cellspacing="0"
    style="background-image: url('/images/cakeG.jpg'); background-repeat: no-repeat;
    width: 165px; height: 1026px;">
    <tr>
        <td width="166" valign="top" id="star">
            <table width="166" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="23" colspan="2" valign="bottom">
                        &nbsp;&nbsp;&nbsp;&nbsp;<span class="STYLE1"> 明星员工</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5">
                    </td>
                </tr>
                <tr>
                    <td width="97" rowspan="4">
                        &nbsp;&nbsp;&nbsp;&nbsp
                        <div class="star">
                            <img src="/images/star.gif" /></div>
                        <img src='/<%=img %>' width="70" height="97" border="0" />
                    </td>
                    <td width="69" height="32" align="center" valign="bottom">
                        <span class="STYLE2">
                            <%=name %></span>
                    </td>
                </tr>
                <tr>
                    <td height="42" align="center" valign="bottom">
                        <span class="STYLE3">
                            <br />
                            <%=bum %>
                            <asp:Label ID="Label2" runat="server" Visible="false" Text="Label"></asp:Label></span>
                    </td>
                </tr>
                <tr>
                    <td height="5px">
                    </td>
                </tr>
                <tr>
                    <td height="50" align="center" valign="top">
                        &nbsp;<a style="cursor: hand" onclick="javascript:window.open('/N_Right/MingXing.aspx?id=<%=mxId %>', '明星员工', 'height=517, width=565,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')"><img
                            src="/images/xiangxi.gif" /></a>
                    </td>
                </tr>
            </table>
            <table width="165" border="0" cellspacing="0" cellpadding="0" valign="top" id="bir">
                <tr>
                    <td width="17" height="53">
                        &nbsp;
                    </td>
                    <td width="136" height="" align="right" valign="bottom">
                        <br />
                        <span class="STYLE4">
                            <%=showShengRi()%></span>
                    </td>
                    <td width="12" height="103" align="right" valign="bottom">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table width="165" style="height: 220px" border="0" cellspacing="0" cellpadding="0"
                valign="top" id="list">
                <tr>
                    <td width="30" height="80">
                        &nbsp;
                    </td>
                    <td width="99" height="80" valign="bottom">
                        <span class="STYLE5">日程提示 </span>
                    </td>
                    <td width="36" height="80" valign="bottom">
                        &nbsp;<a href="/N_Calendar/default.aspx"><img src="/images/01-g2_07.gif" /></a>
                    </td>
                </tr>
                <tr>
                    <td valign="top" colspan="3" style="height: 140px">
                        <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">
                            <ItemTemplate>
                                <table width="165" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" style="width: 30px">
                                            &nbsp;
                                        </td>
                                        <td height="20" align="left" valign="bottom">
                                            <span class='<%# getclass(Eval("row")) %>' onclick="ShowMenu('/N_Calendar/CalendarInfo.aspx?id=<%#Eval("w_id") %>')">
                                                <%#showTitle(Eval("w_title"),Eval("w_starttime"))%></span>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                            SelectCommand="SELECT top 7 ROW_NUMBER()Over(ORDER BY w_id) as row,[w_id], [w_title], [w_content], [w_starttime], [w_endtime], [w_depict], [w_user] FROM [Tunnel_workplan] WHERE ([w_user] = @w_user) and ([w_starttime]>getDate()) ORDER BY [w_starttime]">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="HiddenField1" DefaultValue="0" Name="w_user" PropertyName="Value"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            <table width="165" border="0" cellspacing="0" cellpadding="0" valign="top" id="search">
                <tr>
                    <td width="32">
                        &nbsp;
                    </td>
                    <td width="133">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="38" colspan="2">
                        &nbsp;&nbsp;<span class="STYLE10">快捷导航</span>
                    </td>
                </tr>
                <tr>
                    <td height="15">
                        &nbsp;
                    </td>
                    <td height="15" valign="bottom">
                        <a href="/N_News/N_OnlineUser/N_OnlineUser.aspx" target="_blank"><span  class="STYLE13">登陆排行榜</span></a>
                    </td>
                </tr>
                <tr>
                    <td height="20">
                        &nbsp;
                    </td>
                    <td height="20" valign="bottom">
                        <a href="/N_MyWork/N_Report/xjb.aspx" target="_blank"><span class="STYLE13">项经部排名</span></a>
                    </td>
                </tr>
                <tr>
                    <td height="20">
                        &nbsp;
                    </td>
                    <td height="20" valign="bottom">
                        <a href="/N_News/N_Tel/N_TelList.aspx" target="_blank"><span class="STYLE13">通讯录</span></a>
                    </td>
                </tr>
                <tr>
                    <td height="20">
                        &nbsp;
                    </td>
                    <td height="20" valign="bottom">
                        <a href="/yzap.aspx" target="_blank"><span class="STYLE13">分公司一周安排<%=PageBind()%></span></a>
                    </td>
                </tr>
            </table>
            <table width="165" border="0" cellspacing="3" cellpadding="0" valign="top" id="culture">
                <tr>
                    <td height="33" valign="bottom">
                        &nbsp;<span class="STYLE15">企业文化</span>
                    </td>
                </tr>
                <tr>
                    <td align="center" height="2" valign="top">
                        <img src="/images/01-g2_11.gif" />
                    </td>
                </tr>
                <tr>
                    <td height="45" align="center" valign="bottom">
                            <img src="/images/01-g2_15.gif" />
                    </td>
                </tr>
                <tr>
                    <td height="45" align="center" valign="middle">
                            <img src="/images/01-g2_17.gif" />
                    </td>
                </tr>
                <tr>
                    <td height="45" align="center" valign="middle">
                            <img src="/images/01-g2_19.gif" />
                    </td>
                </tr>
                <tr>
                    <td height="45" align="center" valign="middle">
         
                            <img src="/images/01-g2_21.gif" />
                    </td>
                </tr>
                <tr>
                    <td height="45" align="center" valign="middle">
                        <a style="cursor:hand" onclick="javascript:window.open('/showjzg.aspx', '盾构公司价值观群', 'height=270, width=390,toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')"  >
                            <img src="/images/01-g2_23.gif" /></a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<asp:HiddenField ID="HiddenField1" runat="server" />
<map name="Map" id="Map">
    <area shape="rect" coords="132,6,156,26" onclick="ShowMenu('/N_Calendar/default.aspx')"
        href="#" />
</map>
