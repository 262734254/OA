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
using BLL.WorkHelper;
using DAL;
public partial class OfficeHelp_LeaveMessage_MeetingInfo : System.Web.UI.Page
{
    static int typeId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["TypeId"].ToString()))
            {
                typeId = Convert.ToInt32(Request.QueryString["TypeId"]);
                Bind();
            }
        }
    }
    private void Bind()
    {
        LeaveWord leaveWord = LeaveWordManager.GetLeaveWordById(typeId);
        this.txtTitle.Text = leaveWord.MsgTitle;
        this.txtStartTime.Text =Convert.ToString(leaveWord.MeetingBeginTime);
        this.txtMeetingAddr.Text = leaveWord.MeetingAddr;
        this.txtReceiverUser.Text =Convert.ToString(leaveWord.ReceiverUser.Name);
        this.txtChargeMan.Text = leaveWord.ChargeMan;
        this.dropMeetingType.SelectedValue = leaveWord.MeetingType;
        this.txtRemark.Text = leaveWord.Remark;
    }
    protected void btnFeedback_Click(object sender, EventArgs e)
    {
        Response.Redirect("FeedBackDetails.aspx?TypeId=" + typeId + "&&typeTitle=反馈");
    }
}
