<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Right.ascx.cs" Inherits="N_UserContrl_Right" %>
<style type="text/css">
    table
    {
        font-size: 12px;
    }
    .STYLE1
    {
        color:Red;
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
    }
    .STYLE9
    {
        font-size: 12px;
    }
    .STYLE10
    {
        color:White;
        font-weight: bold;
        font-size: 12px;
        vertical-align: middle;
    }
       .STYLE20
    {
        color:red;
        font-weight: bold;
        font-size: 12px;
        vertical-align: middle;
    }
    .STYLE13
    {
        font-size: 12px;
        color: #000000;
    }
    .STYLE15
    {
        color: #666666;
        font-size: 15px;
        font-weight: bolder;
    }
    .star
    {
        position: absolute;
        z-index: 3;
        width: 38px;
        margin: -15px 0 0 53px;
    }
    .td
    {
        background-image: url('/images/bt11-r.gif');
    }
    body
    {
        margin-left: 0px;
        margin-top: 0px;
        margin-right: 0px;
        margin-bottom: 0px;
        font-size: 12px;
        background-color: #f2f3f4;
    }
</style>
<table width="1000" height="1026" border="0" cellpadding="0" cellspacing="0" style="width: 165px;
    height: 1026px;"  class="table" >
    <tr>
        <td width="1000" valign="top" id="star">
            <table width="200" border="0" cellspacing="0" cellpadding="0" valign="top"
                id="search1" style="background-image: url(/images/xb.gif)">
                <tr>
                    <td height="25" colspan="2" class="td" >
                        &nbsp;&nbsp;<span class="STYLE10">喜报</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <a href="/N_MyWork/N_Star/XiBao.aspx" target="_blank"><img src="/image/icon5_1.gif"  /></a>
                    </td> 
               </tr>
               
                <tr  style="display:inline">
                    <td  style="display:inline" width="165" height="160" style="background-image: url(/images/xb.gif)" ><%--background="/<%=img %>"--%>
                   <br />
                   <marquee direction="left" scrollamount="2" style="display:inline">
                        <%=Title %>
                  <%-- <a href="/N_Right/XiBao.aspx?id=<%=mxId %>" ><font  color="#003300" size="4"><center> <%=Title %>  </center></font></a>--%>
                  </marquee>
                    </td>
                </tr>
               
               </td> 
       </tr>
            </table>
            <table width="200" border="0" width="200" cellspacing="0" cellpadding="0" valign="top"
                id="bir">
                <tr>
                    <td height="25" colspan="2" class="td">
                        &nbsp;&nbsp;<span class="STYLE10">生日祝福</span>
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle" bgcolor="#FFFFFF" style="border: 1px #a6bac5 solid;
                        border-top: none;">
                        <table width="99%" height="105" border="0" cellpadding="0" cellspacing="0" style="background-image: url(/images/DGjm_07.gif);
                            background-repeat: repeat-x;">
                            <tr>
                                <td width="42%" height="103" valign="bottom">
                                    <img src="/images/zhufuimg.gif" width="76" height="73" />
                                </td>
                                <td width="58%">
                                    <table width="100%" height="45" border="0" cellpadding="0" cellspacing="0" id="birthdaytable">
                                        <tr>
                                            <td height="30" align="center">
                                                <span class="STYLE1">
                                                    <%=showShengRi() %></span>
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
            </table>
            <table width="200" border="0" cellspacing="0" cellpadding="0" valign="top" id="search">
                <tr>
                    <td height="25" colspan="2" class="td">
                        &nbsp;&nbsp;<span class="STYLE10">快捷导航</span>
                    </td>
                </tr>
                <td colspan="2" height="15">
                </td>
    <tr>
        <td height="20">
            &nbsp; &nbsp;<font size="1">●</font>&nbsp;&nbsp;&nbsp;
        </td>
        <td height="20" valign="bottom">
            <a href="/yzap.aspx" target="_blank"><span class="STYLE13" css="STYLE13">分公司一周安排<%=PageBind()%></span></a>
        </td>
    </tr>
    <tr>
        <td height="20">
            &nbsp; &nbsp;<font size="1">●</font>&nbsp;&nbsp;
        </td>
        <td height="20" valign="bottom">
            <a href="/N_News/N_Tel/N_TelList.aspx" target="_blank"><span class="STYLE13">通信录</span></a>
        </td>
    </tr>
    
 <%--   <tr>
        <td height="20">
            &nbsp; &nbsp;<font size="1">●</font>&nbsp;&nbsp;
        </td>
        <td height="20" valign="bottom">
            <a href="/N_News/OutMessage/NowMessage.aspx" target="_blank"><span class="STYLE13">外出留言</span></a>
        </td>
    </tr>--%>
</table>
<table width="200" border="0" cellspacing="0" cellpadding="0" valign="top" id="Table2">
    <tr>
        <td width="32">
            &nbsp;
        </td>
        <td width="133">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td height="25" colspan="2" class="td" valign="bottom">
            &nbsp;&nbsp;<span class="STYLE10">外出留言</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp; &nbsp;<a href="/N_News/OutMessage/NowMessage.aspx" target="_blank"><img src="/image/icon5_1.gif" /></a>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="3" style="height: 140px">
            <asp:Repeater ID="GridViewE" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <table width="165" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="20" style="width: 30px">
                                &nbsp;<font size="1">●</font>&nbsp;
                            </td>
                            <td height="20" align="left" valign="bottom">
                               <a href="/N_News/OutMessage/QingJia.aspx?id=<%#Eval("MesID")%>">
                                    <%#GetUserName(Eval("MesUser").ToString())%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("MesDate", "{0:MM-dd}")%>
                                    </a>
                                
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                
                
                
                SelectCommand="select top 7  * from Tunnel_Message where DelDate is null and datediff(dd,MesDate,GETDATE())=0  order by MesDate Desc">
            </asp:SqlDataSource>
        </td>
    </tr>
</table>
<table width="200" border="0" cellspacing="0" cellpadding="0" valign="top" id="Table3">
    <tr>
        <td width="32">
            &nbsp;
        </td>
        <td width="133">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td height="25" colspan="2" class="td" valign="bottom">
            &nbsp;&nbsp;<span class="STYLE10">登录排行榜</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp; &nbsp;<a href="/N_News/N_OnlineUser/N_OnlineUser.aspx" target="_blank"><img src="/image/icon5_1.gif" /></a>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="3" style="height: 140px">
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">
                <ItemTemplate>
                    <table width="165" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="20" style="width: 30px">
                                &nbsp;<font size="1">●</font>&nbsp;
                            </td>
                            <td height="20" align="left" valign="bottom">
                                  
                                  <%#Eval("m_name") %>        
                            </td>
                          <%--  <td><%#convertTime(Eval("m_counttime").ToString())%></td>--%>
                            
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
             <a href="/N_News/N_OnlineUser/N_Weeklogged.aspx" target="_blank"> <span class="STYLE20">一周未登录用户</span></a>         
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"   
                SelectCommand="select top 5 m_id,m_name,m_online,m_onlinetime,m_counttime 
from Tunnel_menber where m_counttime&gt;=0 AND m_name!='管理员'order by m_counttime desc">
            </asp:SqlDataSource>
        </td>
    </tr>
</table>
<table width="200" border="0" cellspacing="0" cellpadding="0" valign="top" id="Table1">
    <tr>
        <td width="32">
            &nbsp;
        </td>
        <td width="133">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td height="25" colspan="2" class="td" valign="bottom">
            &nbsp;&nbsp;<span class="STYLE10">日程提示</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp; &nbsp;<a href="/N_Calendar/default.aspx" target="_blank"><img src="/images/01-g2_07.gif" /></a>
        </td>
    </tr>
    <tr>
        <td valign="top" colspan="3" style="height: 140px">
            <asp:Repeater ID="Repeat2" runat="server" DataSourceID="SqlData2">
                <ItemTemplate>
                    <table width="165" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="20" style="width: 30px">
                                &nbsp;<font size="1">●</font>&nbsp;
                            </td>
                            <td height="20" align="left" valign="bottom">
                                <a href="#" onclick="ShowMenu('/N_Calendar/CalendarInfo.aspx?id=<%#Eval("w_id") %>')">
                                    <%#showTitle(Eval("w_title"),Eval("w_starttime"))%>&nbsp;&nbsp;<%#Eval("w_starttime", "{0:MM-dd}")%>
                                </a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlData2" runat="server" ConnectionString="<%$ ConnectionStrings:SD_OAConnectionString %>"
                SelectCommand="SELECT top 7 ROW_NUMBER()Over(ORDER BY w_id) as row,[w_id], [w_title], [w_content], [w_starttime], [w_endtime], [w_depict], [w_user] FROM [Tunnel_workplan] WHERE ([w_user] = @w_user) and ([w_starttime]>getDate()) ORDER BY [w_starttime]">
                <SelectParameters>
                    <asp:ControlParameter ControlID="HiddenField1" DefaultValue="0" Name="w_user" PropertyName="Value"
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
</table>
</td> </tr> </table>
<asp:HiddenField ID="HiddenField1" runat="server" />
<map name="Map" id="Map">
    <area shape="rect" coords="132,6,156,26" onclick="ShowMenu('/N_Calendar/default.aspx')"
        href="#" />
</map>
