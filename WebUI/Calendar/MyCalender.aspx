<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyCalender.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的日程安排</title>

    <script language="javascript" src="../js/calendar.js" type="text/javascript"></script>

    <link href="../css/6/style.css" rel="Stylesheet" type="text/css" />
    <link href="../css/style.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        </style>

    <script language="javascript" type="text/javascript"> 
        function display_front()
        {
           var front=document.getElementById("front");
           if(!front)
              return;
           if(front.style.display=='')
              front.style.display='none';
           else
              front.style.display='';
        }
        function set_view()
        {
            var view=document.CLD.VIEW.value;
        }
    </script>
     <style type="text/css">
         .style4
        {
            width: 100%; background-color:#C6DAF3;
        }
    </style>
</head>
<body>
    <form id="CLD" action="" method="post" runat="server">
    <div class="TableHeader1"></div>
    
    <table>
       <tr>
           <td><br />
       <a href="AddCalender.aspx">新建日程<br /></a></td>
           
       </tr>
       
       <tr>
        <td><a href="SelectCalender.aspx">查看已经新建的日程<br /></a></td>
       </tr>
    </table>

    <asp:Calendar ID="calSchedule" runat="server" BackColor="Transparent" BorderColor="#999999"
        ShowGridLines="True" PrevMonthText="&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;<img src=../images/left_arrow.gif alt=上一月 border=0 />上一月"
        NextMonthText="下一月<img src=../images/right_arrow.gif alt=下一月 border=0 />&amp;nbsp;&amp;nbsp;&amp;nbsp;&amp;nbsp;"
        BorderStyle="None" DayNameFormat="Full" OnDayRender="calSchedule_DayRender" Font-Size="XX-Small"
        Height="462px" Width="100%">
        <TodayDayStyle BorderWidth="2px" BorderStyle="Solid" BorderColor="CornflowerBlue"
            BackColor="#F0F0E8"></TodayDayStyle>
        <DayStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" Height="50px">
        </DayStyle>
        <NextPrevStyle ForeColor="#223399" CssClass="td"></NextPrevStyle>
        <DayHeaderStyle Font-Size="13px" Height="10px" BackColor="#F0F0E8"></DayHeaderStyle>
        <TitleStyle CssClass="" Height="10px"></TitleStyle>
        <WeekendDayStyle ForeColor="Red"></WeekendDayStyle>
        <OtherMonthDayStyle ForeColor="Gray" />
    </asp:Calendar>
    </form>
</body>
</html>
