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
using Model;
using BLL.Meeting;
using BLL.Power;
public partial class Meeting_AddMeeting : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    //显示所有的部门
    protected void ddlDepartmentType_DataBound(object sender, EventArgs e)
    {
        
        ddlDepartmentType.DataSourceID = null;
        ddlDepartmentType.DataSource = DepartmentManager.GetAllDepartment();
        ddlDepartmentType.DataTextField = "Departmentname";
        ddlDepartmentType.DataValueField = "Id";
        ddlDepartmentType.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {

        
        //判断缺席人中是否含有出席人
            //参与者
            string otherman = txtOtherMan.Text;
            // 缺席者
            string absentman = txtMissingPeople.Value;
            //判断缺席者是否存在参与者中
            if (otherman.Contains(absentman))
            {
                Response.Write("<script>alert('此缺席人在参与者中已存在！');</script>");
                return;
            }


            //获得用户登录的ID
            UserInfo user = Session["user"] as UserInfo;
            MeetingSummary meeting = new MeetingSummary();

            meeting.MeetingTitle = txtTitle.Text;//会议主题
            meeting.MeetingContent = txtMeetingContent.Value;//会议内容
            meeting.BeginTime = Convert.ToDateTime(txtStartTime.Value);//开始时间 
            meeting.EndTime = Convert.ToDateTime(txtEndTime.Value);//结束时间
            meeting.MissingPeople = txtMissingPeople.Value;   //缺席人员
            meeting.Compere = txtOtherMan.Text;//参与 者
            meeting.ChargeMan = user.Name;  //负责人，就是会议纪要人，也就是登录用户

          
            
            //进行添加操作
            try
            {
                MeetingSummaryManager.AddMeetingSummary(meeting);
                Response.Write("<script>alert('添加成功！');location.href='SelMeeting.aspx';</script>");
            }
            catch (Exception)
            {

                Response.Write("<script>alert('添加失败！');</script>");
            }
        }
         
    }
    //根据选择的部门动态加载该部门下的所有员工 
    protected void ddlDepartmentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //当部门的选中项改变时，人员也相对应的改变
            int departId = Convert.ToInt32(ddlDepartmentType.SelectedValue);
            ddlCompere.DataSourceID = null;
            ddlCompere.DataSource = UserInfoManager.GetAllUsersByDepartmentId(departId);
            ddlCompere.DataTextField = "Name";
            ddlCompere.DataValueField = "UID";
            ddlCompere.DataBind();
    }
}
