using System;
using System.Collections.Generic;
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
using BLL.Meeting;
using Model;
public partial class MeetingManager_SelMeetingRome : System.Web.UI.Page
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
    private void Bind()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = RoomInfoManager.GetAllRoomInfo(txtRoomName.Text);
        pds.AllowPaging = true;
        pds.PageSize = 5;
        pds.CurrentPageIndex = Pager1.PageIndex;
        Pager1.PageCount = pds.PageCount;
        Pager1.DataCount = pds.Count;

        gvRoomInfo.DataSourceID = null;
        gvRoomInfo.DataSource = pds;
        gvRoomInfo.DataBind();
    }




    /// <summary>
    /// GridView内生成事件时激发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvRoomInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //判断是修改还是删除
        if (e.CommandName=="Up")
        {
            Response.Redirect("UpdateMeetingRomeInfo.aspx?RoomId="+e.CommandArgument);
        }
        else
        {
            //删除
            RoomInfoManager.DeleteRoomInfo(e.CommandArgument.ToString());
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！')");
            return;
        }
    }
    /// <summary>
    /// 根据会议室名称查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchRoom_Click(object sender, EventArgs e)
    {
        Pager1.PageIndex = 0;
        Bind();
    }
    protected void gvRoomInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            Label lblMeetName = e.Row.FindControl("lblMeetName") as Label;

            //根据会议室名称查询该会议室是否有安排信息，如果有不能修改和删除
            IList<RoomArrage> list = RoomArrageManager.SearchRoomArrageStateByRoomName(lblMeetName.Text);
            if (list.Count>0)
            {
                LinkButton lblUpdate = e.Row.FindControl("lbUp") as LinkButton;
                lblUpdate.Visible = false;
                LinkButton lblDel = e.Row.FindControl("lbDel") as LinkButton;
                lblDel.Visible = false;
            }
        }
    }
   

    
}
