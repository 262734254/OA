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

public partial class MeetingManager_UpdateMeetingRomeInfo : System.Web.UI.Page
{
    static int RoomId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //判断会场ID是否为空，为空则跳转到会场列表页面
            if (Request.QueryString["RoomId"]==null)
            {
                Response.Redirect("SelMeetingRome.aspx");
            }
            else
            {
                //绑定会场信息
                RoomId = Convert.ToInt32(Request.QueryString["RoomId"]);
                RoomInfo roomInfo=RoomInfoManager.SearchRoomInfoById(RoomId);
                txtRomeName.Value = roomInfo.RoomName;
                txtContainNum.Value = roomInfo.ContainNum.ToString();
                txtEquip.Text = roomInfo.Equip;
                txtAddress.Value = roomInfo.RomeAddr;
                txtRomeCondition.Text = roomInfo.RomeCondition;
            }
        }
    }
    /// <summary>
    /// 提交修改的会场信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            RoomInfo room = new RoomInfo();
            room.RID = RoomId;
            room.RoomName = txtRomeName.Value;
            room.RomeAddr = txtAddress.Value;
            room.RomeCondition = txtRomeCondition.Text;
            room.Equip = txtEquip.Text;
            room.ContainNum = Convert.ToInt32(txtContainNum.Value);

            //调用业务逻辑层方法修改会场信息
            RoomInfoManager.ModifyRoomInfo(room);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改会场信息成功');window.location.href='SelMeetingRome.aspx';</script>");

        }
    }
}
