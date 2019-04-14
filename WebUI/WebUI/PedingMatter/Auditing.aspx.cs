using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Model;
using BLL.Matter;
using BLL.Target;
using BLL.WorkHelper;
using BLL.Meeting;
using BLL.Power;
using BLL.Car;
using BLL.Resource;
using System.Collections.Generic;
public partial class ResourceManager_Auditing : System.Web.UI.Page
{

    static UserInfo user = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            user = Session["user"] as UserInfo;
            if (user == null)
            {
                Response.Redirect("../login.aspx");
                return;
            }
            

            try
            {
                txtType.Text = Request.QueryString["type"].ToString();
                txtApplicationId.Text = Request.QueryString["id"].ToString();

            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核类型和审核编号获取不到！');", true);
                return;
            }

            txtRequestMan.Text = user.Name;
            txtTime.Value = DateTime.Now.ToShortDateString();


           
            //txtResourceName.Text = requisitionType;
            //txtStockNorm.Text = requisitionID.ToString();
            ////UserInfo userinfo = (UserInfo)Session["currentUser"];
            ////txtQuantity.Text = userinfo.Name;
            ////lblUID.Text = userinfo.UID;
            //txtQuantity.Text = "张三";
            //lblUID.Text = "1";
            //txtTime.Value = System.DateTime.Now.ToShortDateString();


        }


    }
    /// <summary>
    /// 添加审批记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Examine em = new Examine();
        em.RequisitionID = Convert.ToInt32(txtApplicationId.Text);
        em.RequisitionType = txtType.Text;
        em.ExamineUID.UID = Convert.ToInt32(((UserInfo)Session["user"]).UID);
        em.ExamineIdea = this.txtCause.Text;
        em.EndTime = Convert.ToDateTime(txtTime.Value);
        em.IsApproved = rdoAccess.SelectedValue == "未过" ? "未过" : "通过";

        //不管是否通过，都在审批记录表中添加一条审批记录
        if (ExamineManager.AddExamine(em) > 0)
        {
            //判断审批是否通过,
            if (rdoAccess.SelectedValue=="通过")
            {
                if (txtType.Text == "会议申请")
                {
                    try
                    {
                        MeetingApplication ma = MeetingApplicationManager.GetMeetingApplicationById(Convert.ToInt32(txtApplicationId.Text));
                        //获取所有与会人员，
                        string applicationMan = ma.WithinEnlistMan;

                        LeaveWord lw = new LeaveWord();
                        lw.MsgTitle = ma.MeetTitle;        //会议标题
                        lw.MsgContent = ma.MeetContent;   //会议内容
                        lw.MsgSendTime = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //发送时间
                        lw.MsgState = "未读";
                        lw.MsgTypeId.Id = 1;  //1代表会议申请
                        lw.SenderUser = user;  //发送者
                        lw.MeetingBeginTime = ma.BeginTime;     //开会时间
                        lw.MeetingAddr = ma.RoomInfo.RomeAddr;   //会议地点
                        lw.ChargeMan = ma.Compere;  //会议负责人
                        lw.MeetingType = ma.MeetType;

                        //用“，”号分割与会人员
                        string[] array = applicationMan.Split(new char[] { ',' });
                        for (int i = 0; i < array.Length; i++)
                        {
                            int uid = UserInfoManager.GetLeaveIDByMName(array[i]);
                            lw.ReceiverUser.UID = uid;
                            int flag = LeaveWordManager.AddLeaveWord(lw);
                        }
                        //更新会议申请的状态
                        MeetingApplicationManager.ModifyMeetingState(Convert.ToInt32(txtApplicationId.Text),"已办");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已审核！');location.href='CheckNote.aspx'", true);
                    }
                    catch (Exception)
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核失败！');", true);
                        return;
                    }

                }
                else if (txtType.Text == "用车申请")
                {
                    try
                    {
                        //更新用车申请状态
                        int flag = CarByapplyManager.UpadteByapplySate(Convert.ToInt32(txtApplicationId.Text), "已办");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已审核！');location.href='CheckNote.aspx'", true);
                    }
                    catch (Exception)
                    {

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核失败！');", true);
                        return;

                    }

                }
             
            }
            else   //不通过，终结申请
            {
                if (txtType.Text=="会议申请")
                {
                    MeetingApplicationManager.ModifyMeetingState(Convert.ToInt32(txtApplicationId.Text), "终结");
                }
                else if (txtType.Text == "用车申请")
                {
                    //终结用车申请
                    int flag = CarByapplyManager.UpadteByapplySate(Convert.ToInt32(txtApplicationId.Text), "终结");
                }
                

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已终结！');window.location='Matter.aspx'</script>", true);
                
               
            }



            if (txtType.Text == "任务申请") //根据实际完成金额更新任务总体完成进度
            {
                try
                {
                    if (em.IsApproved == "通过")
                    {


                        TaskManager.UpdateTaskNowStatus(Convert.ToInt32(txtApplicationId.Text));//更新任务状态
                        //更新任务的完成比例
                        TaskManager.UpdateTaskFinshStatus(Convert.ToInt32(txtApplicationId.Text));

                        //更新申请单状态为通过
                        new RolePowerManager().UpdatePaddingStatus("已办", Convert.ToInt32(txtApplicationId.Text.Trim()));
                    }
                    else
                    {
                        //更新申请单状态为终结
                        new RolePowerManager().UpdatePaddingStatus("终结", Convert.ToInt32(txtApplicationId.Text.Trim()));
                    
                    }
                }
                catch (Exception)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新任务状态失败！');", true);
                    return;

                }
            }
            if (txtType.Text == "资源采购")
            {
                StockApplication stock = StockApplicationManager.Get((int)em.RequisitionID);
                if (em.IsApproved == "通过")
                {
                    stock.IsExamine = "已办";
                    IList<ApplicationResourseInfo> items= ApplicationResourceManager.GetAllApplicationResource(2, stock.SAID);
                    foreach (ApplicationResourseInfo item in items)
                    {
                        item.Resource.Number += item.Number;
                        ResourceInfoManager.UpdateResourceInfo(item.Resource);
                    }
                }
                else
                {
                    stock.IsExamine = "终结";
                }
                StockApplicationManager.Update(stock);
            }
            else if (txtType.Text == "资源借用")
            {
                BorrowApplication borrow = BorrowApplicationManager.Get((int)em.RequisitionID);
                if (em.IsApproved == "通过")
                {
                    borrow.IsExamine = "已办";
                    IList<ApplicationResourseInfo> items = ApplicationResourceManager.GetAllApplicationResource(1, borrow.BAID);
                    foreach (ApplicationResourseInfo item in items)
                    {
                        item.Resource.Number -= item.Number;
                        ResourceInfoManager.UpdateResourceInfo(item.Resource);
                    }
                }
                else
                    borrow.IsExamine = "终结";
                BorrowApplicationManager.Update(borrow);
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已审核！');location.href='CheckNote.aspx'", true);
            // Response.Redirect("");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核失败！');", true);

        }


    }





}
