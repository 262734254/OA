using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Model;
using BLL.Meeting;
public partial class MeetingManager_UpdateMeeting : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["MSID"] == null)
            {
                Response.Redirect("SelMeeting.aspx");
            }
            //获得要查看的会议纪要的id
            int id = Convert.ToInt32(Request.QueryString["MSID"]);
            MeetingSummary meetingSummary = MeetingSummaryManager.GetMeetingSummaryById(id);

            txtTitle.Text = meetingSummary.MeetingTitle;

            txtStartTime.Text = meetingSummary.BeginTime.ToString();
            txtEndTime.Text = meetingSummary.EndTime.ToString();
            txtMeetintContent.Value = meetingSummary.MeetingContent;
            txtMissingPeople.Value = meetingSummary.MissingPeople;
            ddlCompere.SelectedItem.Value = meetingSummary.Compere;
            txtVisitor.Value= meetingSummary.Visitor;
        }
    }
    /// <summary>
    /// 修改会议纪要
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(Request.QueryString["MSID"]);
            MeetingSummary meetingSummary = new MeetingSummary();
            meetingSummary.Visitor = txtVisitor.Value;
            meetingSummary.MSID = id;
            meetingSummary.MissingPeople = txtMissingPeople.Value;
            meetingSummary.MeetingTitle = txtTitle.Text;
            meetingSummary.BeginTime = Convert.ToDateTime(txtStartTime.Text);
            meetingSummary.EndTime = Convert.ToDateTime(txtEndTime.Text);
            meetingSummary.Compere = ddlCompere.SelectedItem.Value;
            UserInfo user = null;
            //负责人为当前登录用户
            if (Session["user"] != null)
            {
                user = Session["user"] as UserInfo;
            }
            meetingSummary.ChargeMan = user.Name;
            meetingSummary.MeetingContent = txtMeetintContent.Value;

            //调用更新方法 更新会议纪要信息
            MeetingSummaryManager.UpdateMeetingSummary(meetingSummary);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新会议纪要成功');window.location='SelMeeting.aspx'</script>");
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(),"","<script>alert('更新会议纪要失败')</script>");
            return;
        }
    }
}
