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

[assembly: log4net.Config.DOMConfigurator(ConfigFile = "web.config", Watch = true)]
public partial class _Default : System.Web.UI.Page
{
    TaskManager taskManager = new TaskManager();
    Task t = new Task();

    private static log4net.ILog log = log4net.LogManager.GetLogger("我的日志记录");

    protected void Page_Load(object sender, EventArgs e)
    {

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
        t.Tasktype = ddlSteps.SelectedItem.Text;
        t.Vindicator = this.ddlAddPower.SelectedItem.Text;
        t.Work = this.txtUserfulWork.Text;
        t.Year = Convert.ToInt32(ddlYears.SelectedValue);
        t.Status = "保存";
        //定义上传的文件的路径
        string path = Server.MapPath("~/images/Upload/" + System.IO.Path.GetFileName(fileUpload.PostedFile.FileName).ToLower());

        if (!String.IsNullOrEmpty(System.IO.Path.GetFileName(fileUpload.PostedFile.FileName)))
        {
            //保存路径到数据库中
            t.Path = "~/images/Upload/" + System.IO.Path.GetFileName(fileUpload.PostedFile.FileName).ToLower();

            //保存上传的文件
            fileUpload.SaveAs(path);
        }
        else
        {
            t.Path = "";

        }


        int num = taskManager.SendTask(t);
        if (num > 0)
        {
            log.Info("保存任务成功！");//信息
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存成功！');", true);
        }

        else
        {
            log.Warn("保存任务失败！");//信息
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存失败！');", true);
        }




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
            log.Error("完成时间格式不正确！");//信息
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('完成时间格式不正确！');", true);
            return;
        }

     

        t.Title = this.txtTitle.Text;
        //验证是否存在相同任务 否则不能发送
        string sttttring=TaskManager.CheckSendTaskTitle(t.Title.Trim());
        if (sttttring.ToLower() == "y")
        {
            log.Error("任务标题不能重复！");//信息
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('任务标题不能重复！');", true);
            return;
        }


        t.Branch = this.ddlweihuMan.Text;
        t.Domain = this.txtLingyu.Text;
        t.dutyDepart = this.ddlLeader.Text;
        t.Extrleader = this.ddlweihuMan.Text;
        t.filishTime = Convert.ToDateTime(this.txFDate.Text.Trim());
        t.Money = Convert.ToDecimal(this.txtMoney.Text.Trim());
        t.Mumber = Convert.ToInt32(this.txtTargeCode.Text.Trim());
        t.Principal = this.ddlLeaderMan.Text;
        t.Remarks = this.txtMarks.Text;
        t.targetTask = this.txtTraget.Text;
        t.Tasktype = ddlSteps.Text;
        t.Vindicator = this.ddlAddPower.Text;
        t.Work = this.txtUserfulWork.Text;
        t.Year = Convert.ToInt32(ddlYears.SelectedValue);
        t.Status = "未执行";

        //定义上传的文件的路径
        string path = Server.MapPath("~/images/Upload/" + System.IO.Path.GetFileName(fileUpload.PostedFile.FileName).ToLower());

        if (!String.IsNullOrEmpty(System.IO.Path.GetFileName(fileUpload.PostedFile.FileName)))
        {
            //保存路径到数据库中
            t.Path = "~/images/Upload/" + System.IO.Path.GetFileName(fileUpload.PostedFile.FileName).ToLower();

            //保存上传的文件
            fileUpload.SaveAs(path);
        }
        else
        {
            t.Path = "";

        }


        int num = taskManager.SendTask(t);
        if (num > 0)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发送成功！');", true);

        else

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('发送失败！');", true);









        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('已经发送给相关部门执行！');", true);

    }

    protected void btnCanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TaskManager/SearchTask.aspx");
    }
}
