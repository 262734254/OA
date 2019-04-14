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
        gvRoomInfo.DataSourceID = null;
        gvRoomInfo.DataSource = RoomInfoManager.GetAllRoomInfo(txtRoomName.Text);
        gvRoomInfo.DataBind();
    }
}
