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
using Model;

public partial class MeetingManager_AddMeetingRome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 添加会议室
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
	    {
            RoomInfo roomInfo = new RoomInfo();
            roomInfo.RoomName = txtRomeName.Value;
            roomInfo.ContainNum = Convert.ToInt32(txtContainNum.Value);
            roomInfo.Equip = txtEquip.Text;
            roomInfo.RomeAddr = txtAddress.Value;
            roomInfo.RomeCondition = txtRomeCondition.Text;

            //调用业务逻辑层添加会议室
            RoomInfoManager.AddRoomInfo(roomInfo);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加会场成功');location.href='SelMeetingRome.aspx';</script>",true);
	    }
       
    }
}
