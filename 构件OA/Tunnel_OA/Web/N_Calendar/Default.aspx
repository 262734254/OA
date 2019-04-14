<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"CodeFile="Default.aspx.cs" Inherits="N_Calendar_Default" %>

<asp:content runat="server" id="content1" contentplaceholderid="Header"> </asp:content>
<asp:content runat="server" id="content2" contentplaceholderid="ContentPlaceHolder1">

    <script language="javascript">
        function show(obj) {
            for (var i = 0; i < document.getElementsByName("remove").length; i++) {
                if (document.getElementById("img" + i) != null)
                    document.getElementById("img" + i).style.display = "none";
            }
            var tmpObj = document.getElementById(obj);
            tmpObj.style.display = "";
        }
    </script>


        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0" style="border: 1px #6f97b1 solid">
        <tr>
            <td width="10" bgcolor="#f6f6f6">
                &nbsp;
            </td>
            <td width="74" id="icon1" valign="bottom" bgcolor="#f6f6f6" class="showicon" >
                <a href="Default.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        日程提示</div>
                </a>
            </td>
            <td width="74" id="icon2" valign="bottom" bgcolor="#f6f6f6" class="showicons" >
                <a href="CalendarAdd.aspx" class="a" >
                    <div style="width: 73; height: 27px; cursor: pointer;">
                        新建日程</div>
                </a>
            </td>            
            <td bgcolor="#f6f6f6">
                &nbsp;
            </td>
        </tr>
    </table>
        <asp:Calendar ID="calSchedule" runat="server" OnDayRender="calSchedule_DayRender"
            BorderStyle="none" ShowGridLines="True" PrevMonthText="上一月" NextMonthText="下一月"
            DayNameFormat="Full" BorderColor="#999999" BackColor="transparent" Height="350"
            Width="100%" FirstDayOfWeek="Monday">
            <TodayDayStyle BackColor="Transparent" BorderStyle="Solid" BorderWidth="2px" BorderColor="CornflowerBlue">
            </TodayDayStyle>
            <DayStyle HorizontalAlign="Left" Font-Bold="True" VerticalAlign="Top"></DayStyle>
            <WeekendDayStyle ForeColor="Red"></WeekendDayStyle>
            <NextPrevStyle ForeColor="#223999"></NextPrevStyle>
            <DayHeaderStyle BackColor="#BFE6F9" Height="10px"></DayHeaderStyle>
            <TitleStyle BackColor="#66CCFF" Height="10px"></TitleStyle>
        </asp:Calendar>
</asp:content>
