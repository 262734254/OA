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
using BLL.Meeting;
using BLL.Power;
using Model;
public partial class MeetingManager_ApplictionMeetingList : System.Web.UI.Page
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
    /// 根据会议名称和主办部门查询会议列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Pager1.PageIndex = 0;
        Bind();
    }

    private void Bind()
    {
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = MeetingApplicationManager.SearchMeetingApplication(txtRoomName.Value, Convert.ToInt32(ddlDepartment.SelectedValue));
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
        string type = e.CommandName;
        //更新操作
        if (type=="Up")
        {
            Response.Redirect("ApplicationMeeting.aspx?MID=" + e.CommandArgument);
        }
       
        else if (type=="Del")   //查看详情
        {
            Response.Redirect("ApplicationMeetingDetail.aspx?MID="+e.CommandArgument);
        }
        else if (type=="De")    //删除操作
        {
            try
            {
                MeetingApplicationManager.DelMeetingApplication(Convert.ToInt32(e.CommandArgument));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除会议成功！')</script>");
                Bind();
            

            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除会议失败！')'</script>");
                return;
            }
        }
        
    }

    protected void gvRoomInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            Label lblState = e.Row.FindControl("lblState") as Label;
            if (lblState.Text == "未召开" || lblState.Text == "受理中")
            {
                LinkButton lblUpdate = e.Row.FindControl("lbUp") as LinkButton;
                lblUpdate.Visible = false;
                LinkButton lblDel = e.Row.FindControl("lbDel") as LinkButton;
                lblDel.Visible = false;
                ////如果未审批通过的，隐藏“发布通知”按钮
                //LinkButton lblSendWord = e.Row.FindControl("hlSendWord") as LinkButton;
                //lblSendWord.Visible = false;
            }
          
        }
      
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplicationMeeting.aspx");
    }
}
