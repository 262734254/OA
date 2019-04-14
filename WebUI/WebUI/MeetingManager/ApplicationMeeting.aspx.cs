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
public partial class MeetingManager_AddMeetingRomeOrderInfo : System.Web.UI.Page
{
    static int mid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDepartment.DataSourceID = null;
            ddlDepartment.DataSource = DepartmentManager.GetAllDepartment();
            ddlDepartment.DataBind();

            ddlRoomName.DataSourceID = null;
            ddlRoomName.DataSource = RoomInfoManager.GetAllRoomInfo();
            ddlRoomName.DataBind();

            //判断MID是否为空，不为空则是修改，为空则是添加会议申请
            if (Request.QueryString["MID"] != null)
            {
                lblTitle.Text = "会议修改";
                mid = Convert.ToInt32(Request.QueryString["MID"]);
                MeetingApplication mApplication = MeetingApplicationManager.GetMeetingApplicationById(mid);
                txtMeetTitle.Text = mApplication.MeetTitle;
                txtsummary.Text = mApplication.MeetingSummary;
                txtcompere.Text = mApplication.Compere;
                txtContent.Value = mApplication.MeetContent;
                txtbeginTime.Value = mApplication.BeginTime.ToShortDateString();
                txtendTime.Value = mApplication.EndTime.ToShortDateString();
                selectPerson.Items.Add(new ListItem(mApplication.WithinEnlistMan,mApplication.WithinEnlistMan));//与会人员
                ddlDepartment.SelectedValue = mApplication.DepartmentID.Id.ToString();
                ddlInstancyDegree.SelectedItem.Text = mApplication.InstancyDegree;  //紧急程度
                ddlRoomName.SelectedItem.Text = ddlRoomName.Items.FindByText(mApplication.RoomInfo.RoomName).Text;
                txtMeetNumber.Value = mApplication.MeetNumber.ToString();
            }
            else
            {
                lblTitle.Text = "新增会议";
            }
            
        }
    }
    /// <summary>
    /// 修改/添加会议申请 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        MeetingApplication meetApplication = new MeetingApplication();
        meetApplication.RoomInfo.RID = Convert.ToInt32(ddlRoomName.SelectedValue);
        meetApplication.MeetTitle = txtMeetTitle.Text;
        meetApplication.MeetContent =Server.HtmlDecode( txtContent.Value);
        meetApplication.MeetingSummary = txtsummary.Text;
        meetApplication.MeetNumber = int.Parse(txtMeetNumber.Value);
        meetApplication.InstancyDegree = ddlInstancyDegree.SelectedItem.Text;
        meetApplication.MeetType = txtMeetTitle.Text;
        meetApplication.BeginTime = Convert.ToDateTime(txtbeginTime.Value + " " + sHours.Value + ":" + sSecond.Value);
        meetApplication.EndTime = Convert.ToDateTime(txtendTime.Value + " " + sHourse2.Value + ":" + sSecond2.Value); 
        meetApplication.Compere = txtcompere.Text;
        meetApplication.DepartmentID.Id = Convert.ToInt32(ddlDepartment.SelectedValue);
        meetApplication.WithinEnlistMan = "admin";  //与会人员
        meetApplication.ApplicationTime = DateTime.Now;
        meetApplication.State = "未召开";
        meetApplication.RoomInfo.RID = Convert.ToInt32(ddlRoomName.SelectedValue);

        UserInfo user = Session["user"] as UserInfo;
        meetApplication.ApplicationMan = "admin";//申请人为当前登录用户
        meetApplication.ApplicationTime = DateTime.Now;


        //为修改
        if (mid>0)
        {
            try
            {
                meetApplication.MID = mid;
                //调用方法更新会议申请单
                MeetingApplicationManager.UpdateMeetintApplication(meetApplication);
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新成功');window.location='ApplictionMeetingList.aspx'</script>");

            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(),"","alert('更新失败')",true);
                return;
            }

        }
        else    //为添加会议申请及会场安排信息
        {
           

            RoomArrage roomArrage = new RoomArrage();
            roomArrage.BeginTime = Convert.ToDateTime(txtbeginTime.Value + " " + sHours.Value + ":" + sSecond.Value); //开始时间
            roomArrage.EndTime =Convert.ToDateTime(txtendTime.Value+" "+sHourse2.Value+":"+sSecond2.Value);   //结束时间
            roomArrage.ChargeMan = "admin";   //会议负责人
            roomArrage.InstancyDegree = ddlInstancyDegree.SelectedItem.Text;
            roomArrage.MeetingType = txtMeetTitle.Text;//会议类型
            roomArrage.RomeState = "占用中";//会场状态
            roomArrage.RoomName = ddlRoomName.SelectedItem.Text;//会场名称
            roomArrage.Remark = txtContent.Value;

            try
            {
                //新增会议申请
                MeetingApplicationManager.AddMeetingApplication(meetApplication);
                //新增会场安排信息
                RoomArrageManager.AddRoomArrage(roomArrage);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('新增成功');window.location='ApplictionMeetingList.aspx'</script>");

            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('新增失败')",true);
                return;
            }



        }
    }
}
