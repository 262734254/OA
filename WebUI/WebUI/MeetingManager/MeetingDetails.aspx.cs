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
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using BLL.Meeting;
using Model;

public partial class Meeting_MyMeetingInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["MSID"]==null)
            {
                Response.Redirect("SelMeeting.aspx");
            }
            //获得要查看的会议纪要的id
            int id = Convert.ToInt32(Request.QueryString["MSID"]);
            MeetingSummary meetingSummary = MeetingSummaryManager.GetMeetingSummaryById(id);
            lblRoomName.Text = meetingSummary.MeetingTitle;
            txtBeginTime.Value = meetingSummary.BeginTime.ToString();
            txtEndTime.Value = meetingSummary.EndTime.ToString();
            txtMeetingContent.Value = meetingSummary.MeetingContent;
            txtMissingPeople.Value = meetingSummary.MissingPeople;
            txtCompere.Value = meetingSummary.Compere;
            txtVisitor.Value = meetingSummary.Visitor;

        }
    }
}
