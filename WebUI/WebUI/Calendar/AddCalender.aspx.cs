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
//using MyOkFlow.Model;
//using MyOkFlow.BLL;
using Model;
using BLL.WorkHelper;
using BLL.Power;
public partial class AddCalender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //获得用户选择的日期
        //    string d = Request.QueryString["day"].ToString();
        //    //初始化办理时间
        //    if (d.Equals("100"))
        //    {
        //        txtTime.Value = "";
        //    }
        //    else
        //    {
        //        string now = DateTime.Now.TimeOfDay.ToString();
        //        DateTime xin = Convert.ToDateTime(d + " " + now);
        //        txtTime.Value = xin.ToString("yyyy-MM-dd HH:mm:ss");
        //    }
        //}
    }
    //根据用户输入的ID，查询数据
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        //获得用户ID
        //UserInfo user = Session["CurUser"] as UserInfo;
        ////获得用户输入的信息
        //Calendars cal = new Calendars();
        //cal.UserID = user;
        //cal.Summary = txtSummary.Value;
        //cal.Contents = txDes.Value;
        //cal.CalTime = Convert.ToDateTime(txtTime.Value);
        //cal.RemindTime = Convert.ToDateTime(txtJackTime.Value);
        //cal.CalType = droType.SelectedValue;
        //if (RadioIs.Checked)
        //{
        //    cal.IsOrNoRepeat = "重复";
        //    if (RadioButton1.Checked)
        //    {
        //        cal.RepeatType = "按日重复";
        //    }
        //    else
        //    {
        //        cal.RepeatType = "按周重复";
        //    }
        //}
        //else
        //{
        //    cal.IsOrNoRepeat = "不重复";
        //    cal.RepeatType = "null";
        //}
        ////有权，往下执行
        //if (SysFunManage.checkUserHasPopedom((Session["CurUser"] as UserInfo).UserId, "日程管理", "add"))
        //{
        //    //添加工作日程
        //    int flag = CalendarManager.AddCalendar(cal);
        //    if (flag > 0)
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');location.href='MyCalender.aspx';</script>");
        //        //增加操作日志
        //        UserInfo users = (UserInfo)Session["CurUser"];
        //        string operateName = users.LoginID;
        //        DateTime operateTime = Convert.ToDateTime(DateTime.Now.ToString());
        //        string operateType = users.LoginID + "添加了日程管理";
        //        LogManage.AddSystemLog(operateName, operateTime, operateType);
        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
        //    }
        //}
        //else
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您无权执行此操作!');</script>");
        //}
    }
    //当点击是时，面板显示出来
    protected void RadioIs_CheckedChanged(object sender, EventArgs e)
    {
        //if (RadioIs.Checked)
        //{
        //    this.Panel1.Visible = true;
        //}
    }
    protected void RadioNo_CheckedChanged(object sender, EventArgs e)
    {
        //if (RadioNo.Checked)
        //{
        //    this.Panel1.Visible = false;
        //}
    }

    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        UserInfo user = Session["user"] as UserInfo;
        Model.Calendar calendar = new Model.Calendar();
        calendar.UId.UID = user.UID;
        calendar.CalTheme = txtTitle.Text.Trim();
        calendar.CalContent = txDes.Value;
        calendar.TransactTime = Convert.ToDateTime(txtTime.Value);
        calendar.RemaindTime = Convert.ToDateTime(txtJackTime.Value.Trim() + " " + txtHour.Text.Trim() + ":" + txtSecond.Text.Trim());

        calendar.CalType = droType.SelectedValue;
        calendar.Repeat = rdoRepeat.SelectedValue;

        int flag = CalendarManager.AddCalendar(calendar);
        if (flag > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');location.href='SelectCalender.aspx';</script>");
            //增加操作日志
            //UserInfo users = (UserInfo)Session["CurUser"];
            //string operateName = users.LoginID;
            //DateTime operateTime = Convert.ToDateTime(DateTime.Now.ToString());
            //string operateType = users.LoginID + "添加了日程管理";
            //LogManage.AddSystemLog(operateName, operateTime, operateType);
            Response.Redirect("SelectCalender.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
        }
    }
}
