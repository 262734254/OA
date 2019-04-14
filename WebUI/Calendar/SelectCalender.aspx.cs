using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using MyOkFlow.BLL;
using System.Collections.Generic;
//using MyOkFlow.Model;

public partial class SelectCalender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    string NowTime = Request.QueryString["NowTime"].ToString();//点击的时间
        //    DateTime Time = Convert.ToDateTime(Request.QueryString["Time"]);//重复时的时间
        //    int calid = Convert.ToInt32(Request.QueryString["List"]);//点击的那一列值
        //    if (!NowTime.Equals("null"))
        //    {
        //        List<Calendars> to = Session["Calendar"] as List<Calendars>;//将需要重复的数据存入session中
        //        List<Calendars> shi = new List<Calendars>();
        //        //判断时间是否相同
        //        for (int i = 0; i < to.Count; i++)
        //        {
        //            //当时间相同时，则将数据循环添加到shi的List中
        //            if (NowTime.Equals(to[i].CalTime.ToShortDateString()))
        //            {
        //                shi.Add(to[i]);
        //            }
        //        }
        //        //绑定分页
        //        PagedDataSource pds = new PagedDataSource();
        //        AspNetPager2.RecordCount = shi.Count;
        //        pds.DataSource = shi;
        //        pds.AllowPaging = true;
        //        pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
        //        pds.PageSize = AspNetPager2.PageSize;
        //        GridView2.DataSourceID = null;
        //        this.GridView2.DataSource = pds;
        //        this.GridView2.DataBind();

        //        //绑定数据
        //        //GridView2.DataSourceID = null;
        //        //GridView2.DataSource = shi;
        //        //GridView2.DataBind();
        //        //Bind1(cal, cal.CalTime.ToString());
        //    }
        //    else
        //    {
        //        Calendars cal = new Calendars();
        //        GridView2.DataSourceID = null;
        //        Bind1(cal, Time.ToString());
        //    }
        //}
    }
    //删除
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    ImageButton ig = e.Row.FindControl("ImageDelete") as ImageButton;
        //    ig.Attributes.Add("onclick", "return confirm('您确定要删除吗？');");
        //}
    }
    //删除数据
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "dele")
        //{
        //    //有权，往下执行
        //    if (SysFunManage.checkUserHasPopedom((Session["CurUser"] as UserInfo).UserId, "日程管理", "delete"))
        //    {
        //        //删除工作日程
        //        int calendarID = Convert.ToInt32(e.CommandArgument.ToString());
        //        bool flag = CalendarManager.DeleteCalendar(calendarID);
        //        if (flag)
        //        {
        //            Response.Write("<script>alert('删除成功！');location.href='MyCalender.aspx';</script>");
        //            //增加操作日志
        //            UserInfo user = (UserInfo)Session["CurUser"];
        //            string operateName = user.LoginID;
        //            DateTime operateTime = Convert.ToDateTime(DateTime.Now.ToString());
        //            string operateType = user.LoginID + "删除了日程管理";
        //            LogManage.AddSystemLog(operateName, operateTime, operateType);
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('删除失败！');</script>");
        //        }
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您无权执行此操作!');</script>");
        //    }
        //}
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        //Calendars cal = new Calendars();
        //Bind1(cal, Request.QueryString["Time"].ToString());
    }
    //绑定分页
    //private void Bind1(Calendars cal, string Time)
    //{
    //    //获得用户登录的ID
    //    //UserInfo user = Session["CurUser"] as UserInfo;
    //    //int userid = user.UserId;
    //    //List<Calendars> list = CalendarManager.GetCalendarByUserId(userid, Time);
    //    //if (cal.CalendarID != 0)
    //    //{
    //    //    list.Add(cal);
    //    //}

    //    //this.GridView2.DataSource = list;
    //    //this.GridView2.DataBind();

    //    //PagedDataSource pds = new PagedDataSource();
    //    //AspNetPager2.RecordCount = list.Count;
    //    //pds.DataSource = list;
    //    //pds.AllowPaging = true;
    //    //pds.CurrentPageIndex = AspNetPager2.CurrentPageIndex - 1;
    //    //pds.PageSize = AspNetPager2.PageSize;
    //    //this.GridView2.DataSource = pds;
    //    //this.GridView2.DataBind();
    //}
}
