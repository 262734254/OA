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
using System.Collections.Generic;

using Model;
using BLL.Meeting;

public partial class Meeting_MeetingList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }


    /// <summary>
    /// GridView生成事件时激发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvMeetingSummary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string name = e.CommandName;
       
        //更新
        if (name=="Up")
        {
            Response.Redirect("UpdateMeeting.aspx?MSID="+e.CommandArgument.ToString());
        }
         //删除
        else if (name=="Del")
        {
            MeetingSummaryManager.DelMeetingSummary(e.CommandArgument.ToString());
        }
            //查看详情
        else if (name=="Det")
        {
            Response.Redirect("MeetingDetails.aspx?MSID="+e.CommandArgument.ToString());
        }
    }
    /// <summary>
    /// 查询会议纪要
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_TextChanged(object sender, EventArgs e)
    {
        gvMeetingSummary.DataSourceID = null;
        //根据会议名称，开始时间和结束时间查询会议纪要信息
        gvMeetingSummary.DataSource = MeetingSummaryManager.SearchMeetingSummary(txtRoomName.Value, txtBeginTime.Value, txtEndTime.Value);
        gvMeetingSummary.DataBind();
    }
}
