using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Model;
using BLL.WorkHelper;
using DAL;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    //IList<Calendar> calendar = new List<Model.Calendar>();
    protected void calSchedule_DayRender(object sender, DayRenderEventArgs e)
    {
        UserInfo user = Session["user"] as UserInfo;
        CalendarDay calday = ((DayRenderEventArgs)e).Day;



        //获得用户登录的ID
        //UserInfo user = Session["user"] as UserInfo;
        //int userid = user.UserId;
        //int uid = user.UID;

        //CalendarDay d = ((DayRenderEventArgs)e).Day;

        //TableCell c = ((DayRenderEventArgs)e).Cell;

        //if (d.IsOtherMonth)
        //{
        //    c.Controls.Clear();
        //}
        //else
        //{
        //    try
        //    {
        //        //每个日期上面都显示新增图片
        //        HyperLink hl = new HyperLink();
        //        hl.ImageUrl = "../image/add_small.gif";
        //        hl.ToolTip = "新增个人日程";
        //        hl.NavigateUrl = "AddCalender.aspx?reurl=MyCalendar.aspx&day=" + d.Date.ToShortDateString();

        //        Label lbl = new Label();
        //        HyperLink h2 = new HyperLink();

        //        List<Calendars> list = CalendarManager.GetCalendarByUserId(userid, "");

        //        int Time = Convert.ToInt32(d.Date.ToString("yyyyMMdd"));
        //        int calCount = 0;
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            //如果当前日期有日程则显示
        //            int fw = Convert.ToInt32(list[i].CalTime.ToString("yyyyMMdd"));
        //            if (Time == fw)
        //            {
        //                calCount++;
        //                h2.Text = "<br/><br />查看日程";
        //                h2.NavigateUrl = "SelectCalender.aspx?Time=" + d.Date.ToShortDateString() + "&userid=" + userid
        //                            + "&NowTime=null" + "" + "&List=0";
        //            }
        //            //如果重复则重复显示
        //            if (list[i].IsOrNoRepeat.Equals("重复"))
        //            {
        //                if (list[i].RepeatType == "按日重复")
        //                {
        //                    if (Time > fw)
        //                    {
        //                        calCount++;
        //                        list[i].CalTime = d.Date + list[i].CalTime.TimeOfDay;
        //                        calendars.Add(list[i]);
        //                        Session["Calendar"] = calendars;
        //                        h2.Text = "<br/><br />查看日程";
        //                        h2.NavigateUrl = "SelectCalender.aspx?Time=" + list[i].CalTime.ToShortDateString() + "&userid=" + userid
        //                                     + "&NowTime=" + d.Date.ToShortDateString() + "&List=" + list[i].CalendarID;
        //                    }
        //                }
        //                if (list[i].RepeatType == "按周重复")
        //                {
        //                    if (Time > fw)
        //                    {
        //                        string s = d.Date.DayOfWeek.ToString();
        //                        string n = list[i].CalTime.DayOfWeek.ToString();
        //                        if (s.Equals(n))
        //                        {
        //                            calCount++;
        //                            list[i].CalTime = d.Date + list[i].CalTime.TimeOfDay;
        //                            calendars.Add(list[i]);
        //                            Session["Calendar"] = calendars;
        //                            h2.Text = "<br/><br />查看日程";
        //                            h2.NavigateUrl = "SelectCalender.aspx?Time=" + list[i].CalTime.ToShortDateString() + "&userid=" + userid
        //                                     + "&NowTime=" + d.Date.ToShortDateString() + "&List=" + list[i].CalendarID;
        //                        }
        //                    }
        //                }
        //            }
        //            lbl.Text = "<br/><br />今天有" + calCount + "个日程";
        //        }

        //        c.Controls.Add(hl);
        //        if (calCount > 0)
        //        {
        //            c.Controls.Add(lbl);
        //        }
        //        c.Controls.Add(h2);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.ToString());
        //    }
        //}
    }
}
