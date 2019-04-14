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
using BLL.Matter;
using BLL.Target;

public partial class ResourceManager_Auditing : System.Web.UI.Page
{


    static string requisitionType = "";
    static int requisitionID = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                requisitionType = Request.QueryString["RequisitionType"].ToString();
                requisitionID = int.Parse(Request.QueryString["RequisitionID"].ToString());
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('审核类型和审核编号获取不到！');", true);
                return;
            }

            txtResourceName.Text = requisitionType;
            txtStockNorm.Text = requisitionID.ToString();
            //UserInfo userinfo = (UserInfo)Session["currentUser"];
            //txtQuantity.Text = userinfo.Name;
            //lblUID.Text = userinfo.UID;
            txtQuantity.Text = "张三";
            lblUID.Text = "1";
            txtTime.Value = System.DateTime.Now.ToShortDateString();


        }


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Examine em = new Examine();
        em.RequisitionID = requisitionID;
        em.RequisitionType = requisitionType;
        em.ExamineUID = Convert.ToInt32(lblUID.Text.Trim());
        em.ExamineIdea = this.txtCause.Text;
        em.EndTime = Convert.ToDateTime(txtTime.Value);
        em.IsApproved = rdoAccess.SelectedValue == "未过" ? "未过" : "通过";

        if (ExamineManager.AddExamine(em) > 0)
        {
            //根据实际完成金额更新任务总体完成进度
            if (requisitionType == "任务下达")
            {
                try
                {
                    TaskManager.UpdateTaskNowStatus(requisitionID);//更新任务状态
                    //更新任务的完成比例
                    TaskManager.UpdateTaskFinshStatus(requisitionID);
                }
                catch (Exception)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新任务状态失败！');", true);
                    return;

                }
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
