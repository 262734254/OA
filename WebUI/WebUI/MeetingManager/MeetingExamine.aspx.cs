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
using BLL.Matter;
using BLL.Meeting;
using Model;

public partial class MeetingManager_MeetingExamine : System.Web.UI.Page
{
    static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"]!=null)
            {
                
                id = Convert.ToInt32(Request.QueryString["id"]);
                MeetingApplication meeting = MeetingApplicationManager.GetMeetingApplicationById(id);
                txtRoomName.Value = meeting.MeetTitle;
                txtCompere.Text = meeting.Compere;
                txtMeetContent.Value = meeting.MeetContent;
                txtBeginTime.Value = meeting.BeginTime.ToString();
                txtEndTime.Value = meeting.EndTime.ToString();
                txtMeetNumber.Value = meeting.MeetNumber.ToString();
                txtMeetType.Value = meeting.MeetType;
                txtMeetingSummary.Value = meeting.MeetingSummary;
                txtDepartment.Value = meeting.DepartmentID.Departmentname;
                txtMeetName.Value = meeting.RoomInfo.RoomName;
                txtWithinEnlistMan.Value = meeting.WithinEnlistMan;

                lblName.Text = meeting.ApplicationMan;
               
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //审批
        Response.Redirect("~/PedingMatter/Auditing.aspx?type=会议申请&id="+id);
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        try
        {
            ExamineManager.ModifyApplicationById("会议申请", id);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('会议申请终结成功');window.location='../PedingMatter/Matter.aspx'</script>");
           

        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('会议申请终结失败')</script>");

        }
    }
}
