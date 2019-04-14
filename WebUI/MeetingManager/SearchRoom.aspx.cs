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
public partial class MeetingManager_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 根据会议室查询该会议室的使用情况
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRoomName_SelectedIndexChanged(object sender, EventArgs e)
    {
        RoomInfo room = RoomInfoManager.SearchRoomInfoById(Convert.ToInt32(ddlRoomName.SelectedValue));
        
        string roomName = ddlRoomName.SelectedItem.Value;
        lblRoomName.Text = roomName;
        lblRemark.Text = room.RomeCondition;
        dlRoomArrage.DataSourceID = null;
        dlRoomArrage.DataSource = RoomArrageManager.SearchRoomArrageStateByRoomName(roomName);
        if (dlRoomArrage.DataSource==null)
        {
            lblRoomState.Text = "空闲中..";

        }
        else
        {
            lblRoomState.Text = "占用中..";
        }
        dlRoomArrage.DataBind();
    }
   
}
