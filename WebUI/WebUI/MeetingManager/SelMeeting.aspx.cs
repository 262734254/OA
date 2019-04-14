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
        Pager1.onLoadPageIndexChaning += new _Controls_Pager.MyDele(Pager1_onLoadPageIndexChaning);
        if (!IsPostBack)
        {
            Pager1_onLoadPageIndexChaning(Pager1.PageIndex);
        }
    }

    void Pager1_onLoadPageIndexChaning(int pageIndex)
    {
        Bind();
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
            Page.ClientScript.RegisterStartupScript(this.GetType(),"","<script>alert('删除成功')</script>");
            Bind();
        }
            //查看详情
        else if (name=="Det")
        {
            Response.Redirect("MeetingDetails.aspx?MSID="+e.CommandArgument.ToString());
        }
    }


    private void Bind()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = MeetingSummaryManager.SearchMeetingSummary(txtRoomName.Value, txtBeginTime.Value, txtEndTime.Value);
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.CurrentPageIndex = Pager1.PageIndex;
        Pager1.PageCount = pds.PageCount;
        Pager1.DataCount = pds.Count;

        gvMeetingSummary.DataSourceID = null;
        //根据会议名称，开始时间和结束时间查询会议纪要信息
        gvMeetingSummary.DataSource =pds;
        gvMeetingSummary.DataBind();
    }
    /// <summary>
    ///  删除选中项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelAll_Click(object sender, EventArgs e)
    {
        string ids = string.Empty;
        for (int i = 0; i < gvMeetingSummary.Rows.Count; i++)
        {
            CheckBox cbSel = this.gvMeetingSummary.Rows[i].FindControl("cbAllCb") as CheckBox;
            if (cbSel.Checked==true)
            {
                HiddenField hfMSID=this.gvMeetingSummary.Rows[i].FindControl("hfMSID") as HiddenField;
                ids += hfMSID.Value + ",";
            }
        }
        if (ids.Length>0)
        {
            ids = ids.Substring(0, ids.Length - 1);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择要删除的项!')</script>");
            return;
        }
        MeetingSummaryManager.DelMeetingSummary(ids);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功')</script>");
        Bind();
    }
    /// <summary>
    /// 查询会议纪要
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Pager1.PageIndex = 0;
        Bind();
    }
}
