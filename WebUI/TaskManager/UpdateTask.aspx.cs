using System;
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
using BLL.Target;
using BLL.Power;

public partial class _Default : System.Web.UI.Page 
{
    //实例化业务层
    TaskManager taskManager = new TaskManager();
    Task t = new Task();

     

    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 0;
        try
        { 
           

             Id = int.Parse(Request.QueryString["Id"].ToString());
                   
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('没有找到任务编号！');", true);
            return;
     
            
        }

        //先给Page_load再加载页面绑定的ddl数据
        ddlLeader.DataSourceID = null;
        ddlLeader.DataSource = taskManager.GetAllDepartment();
        ddlLeader.DataTextField = "DepartmentName";
        ddlLeader.DataValueField = "id";
        ddlLeader.DataBind();

        ddlFenguanLeder.DataSourceID = null;
        ddlFenguanLeder.DataSource = taskManager.GetAllTaskLeaders();
        ddlFenguanLeder.DataTextField = "name";
        ddlFenguanLeder.DataValueField = "uid";
        ddlLeader.DataBind();


        ddlLeaderMan.DataSourceID = null;
        ddlLeaderMan.DataSource = taskManager.GetAllTaskLeaders();
        ddlLeaderMan.DataTextField = "name";
        ddlLeaderMan.DataValueField = "uid";
        ddlLeaderMan.DataBind();


        ddlPutDepart.DataSourceID = null;
        ddlPutDepart.DataSource = taskManager.GetAllDepartment();
        ddlPutDepart.DataTextField = "DepartmentName";
        ddlPutDepart.DataValueField = "id";
        ddlPutDepart.DataBind();


        ddlweihuMan.DataSourceID = null;
        ddlweihuMan.DataSource=UserInfoManager.GetAllUser();
        ddlweihuMan.DataTextField = "name";
        ddlweihuMan.DataValueField = "uid";
        ddlweihuMan.DataBind();
      
        //ddlweihuMan.DataSource = taskManager.GetAllUsersByDepartmentId();





        t = taskManager.GetTaskByTaskId(Id);
        this.txtTitle.Text = t.Title;
        this.ddlweihuMan.SelectedItem.Text = t.Branch;
        this.txtLingyu.Text = t.Domain;
        this.ddlLeader.SelectedItem.Text = t.dutyDepart;
        this.ddlFenguanLeder.SelectedItem.Text = t.Extrleader;
        this.txFDate.Text = t.filishTime.ToShortDateString();
        this.txtMoney.Text = t.Money.ToString().Substring(0,t.Money.ToString().IndexOf('.'));
        
        this.txtTargeCode.Text = t.Mumber.ToString();
        this.ddlLeaderMan.SelectedItem.Text = t.Principal.ToString();
      
        this.txtMarks.Text = t.Remarks;
        this.txtTraget.Text = t.targetTask;
        ddlSteps.SelectedItem.Text = t.Tasktype;
        this.ddlAddPower.SelectedItem.Text = t.Vindicator;
        this.txtUserfulWork.Text = t.Work;
        ddlYears.SelectedValue = t.Year.ToString();
        

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToDateTime(this.txFDate.Text);
        }
        catch (Exception)
        {
            
              Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('完成时间格式不正确！');", true);
              return;
        }


        t.Title = this.txtTitle.Text;
        t.Branch = this.ddlweihuMan.SelectedItem.Text;
        t.Domain = this.txtLingyu.Text;
        t.dutyDepart = this.ddlLeader.SelectedItem.Text;
        t.Extrleader = this.ddlweihuMan.SelectedItem.Text;
        t.filishTime = Convert.ToDateTime(this.txFDate.Text.Trim());
        t.Money = Convert.ToDecimal(this.txtMoney.Text.Trim());
        t.Mumber = Convert.ToInt32(this.txtTargeCode.Text.Trim());
        t.Principal = this.ddlLeaderMan.SelectedItem.Text;
        t.Remarks = this.txtMarks.Text;
        t.targetTask = this.txtTraget.Text;
        t.Tasktype = ddlSteps.Text;
        t.Vindicator = this.ddlAddPower.SelectedItem.Text;
        t.Work = this.txtUserfulWork.Text;
        t.Year = Convert.ToInt32(ddlYears.SelectedValue);
        t.Status = "未执行";

        //定义上传的文件的路径
        string path = Server.MapPath("~/images/Upload/" + System.IO.Path.GetFileName(fuAddUpload.PostedFile.FileName).ToLower());

        if (!String.IsNullOrEmpty(System.IO.Path.GetFileName(fuAddUpload.PostedFile.FileName)))
        {
            //保存路径到数据库中
            t.Path = "~/images/Upload/" + System.IO.Path.GetFileName(fuAddUpload.PostedFile.FileName).ToLower();

            //保存上传的文件
            fuAddUpload.SaveAs(path);
        }
        else
        {
            t.Path = "";

        }


        int num=taskManager.UpdateTask(t);
        if (num > 0)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功！');", true);
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败！');", true);

   
          Response.Redirect("~/TaskManager/SearchTask.aspx");
  
    
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            Convert.ToDateTime(this.txFDate.Text);
        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('完成时间格式不正确！');", true);
            return;
        }


        t.Title = this.txtTitle.Text;
        //验证是否存在相同任务 否则不能发送
        string sttttring = TaskManager.CheckSendTaskTitle(t.Title.Trim());
        if (sttttring.ToLower() == "y")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('任务标题不能重复！');", true);
            return;
        }


        t.Branch = this.ddlweihuMan.SelectedItem.Text;
        t.Domain = this.txtLingyu.Text;
        t.dutyDepart = this.ddlLeader.SelectedItem.Text;
        t.Extrleader = this.ddlFenguanLeder.SelectedItem.Text;
        t.filishTime = Convert.ToDateTime(this.txFDate.Text.Trim());
        t.Money = Convert.ToDecimal(this.txtMoney.Text.Trim());
        t.Mumber = Convert.ToInt32(this.txtTargeCode.Text.Trim());
        t.Principal = this.ddlLeaderMan.SelectedItem.Text;
        t.Remarks = this.txtMarks.Text;
        t.targetTask = this.txtTraget.Text;
        t.Tasktype = ddlSteps.SelectedItem.Text;
        t.Vindicator = this.ddlAddPower.SelectedItem.Text;
        t.Work = this.txtUserfulWork.Text;
        t.Year = Convert.ToInt32(ddlYears.SelectedValue);

        t.Status = "正在进行";

        //定义上传的文件的路径
        string path = Server.MapPath("~/images/Upload/" + System.IO.Path.GetFileName(fuAddUpload.PostedFile.FileName).ToLower());

        if (!String.IsNullOrEmpty(System.IO.Path.GetFileName(fuAddUpload.PostedFile.FileName)))
        {
            //保存路径到数据库中
            t.Path = "~/images/Upload/" + System.IO.Path.GetFileName(fuAddUpload.PostedFile.FileName).ToLower();

            //保存上传的文件
            fuAddUpload.SaveAs(path);
        }
        else
        {
            t.Path = "";

        }


        int num = taskManager.SendTask(t);
        if (num > 0)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功！');", true);
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存失败！');", true);


    

        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已经发送给相关部门执行！');", true);
     
    }

    protected void btnCanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TaskManager/SearchTask.aspx");
    }
}
