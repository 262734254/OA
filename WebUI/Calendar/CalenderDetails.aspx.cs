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
//using MyOkFlow.Model;
public partial class Calendar_MattersCalender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //获得要查看的日程的ID
        //    int calendarid = Convert.ToInt32(Request.QueryString["calendarid"]);
        //    //通过日程ID虚的获得需要待办的日程的数据
        //    Calendars cal = CalendarManager.GetCalendarByCalendarID(calendarid);
        //    txFDate.Text = cal.CalTime.ToString();
        //    txtRemind.Text = cal.RemindTime.ToString();
        //    txDes.Value = cal.Contents;
        //    txName.Value = cal.Summary;
        //    dropType.SelectedValue = cal.CalType;
        //    if (cal.IsOrNoRepeat == "重复")
        //    {
        //        RadioIs.Checked = true;
        //        RadioNo.Checked = false;
        //        this.Panel1.Visible = true;
        //    }
        //    else
        //    {
        //        RadioNo.Checked = true;
        //        RadioIs.Checked = false;
        //        this.Panel1.Visible = false;
        //    }
        //}
    }
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
    protected void btnBan_Click(object sender, EventArgs e)
    {
        //获得要查看的日程的ID
        //int calendarid = Convert.ToInt32(Request.QueryString["calendarid"]);
        //string url = "../Calendar/MattersCalender.aspx?calendarid=" + calendarid;
        //Matters mat = new Matters();
        //mat.MState = "已办";
        //mat.Url = url;
        //mat.TansactTime = DateTime.Now.ToString();
        //mat.IsOrNoPass = "通过";
        //mat.ReasonNo = "";
        ////根据URL来改变事宜状态
        //bool flag = MattersManager.updateMattersAppByUrl(mat, "yes");
        //if (flag)
        //{
        //    Response.Write("<script>alert('办理成功！');location.href='../Matters/PendingMatters.aspx?id=1';</script>");
        //}
        //else
        //{
        //    Response.Write("<script>alert('办理失败！');</script>");
        //}
    }
}