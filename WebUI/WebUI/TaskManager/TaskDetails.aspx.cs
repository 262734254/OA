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
using BLL.Target;

public partial class PowerManager_Role_power : System.Web.UI.Page
{
    //实例化业务层
    TaskManager taskManager = new TaskManager();

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
        Task t = taskManager.GetTaskByTaskId(Id);
       
        this.txtProtected.Text = t.Branch;
      
        this.txtContolPart.Text = t.dutyDepart;
        this.txtTwo.Text = t.Extrleader;
       
       
        this.txtProtectMan.Text = t.Principal.ToString();
        this.txtAllTotlals.Text = t.Remarks;
       
        ddlSteps.Text = t.Tasktype;
        this.txtProtected.Text = t.Vindicator;
        this.txtContolPart0.Text = t.Work;
        ddlDateTime.SelectedValue = t.Year.ToString();
        txtField.Text = t.Domain;
        string s=t.Status;
        if (s == "已经完成")
        {
            rdoOver.Checked = true;
        }
        else if (s == "正在进行")
        {
            rdoProcess.Checked = true;      
        }
        else if (s == "存在困难")
        {
            rdoHard.Checked = true;
        }
        else 
        {
            rdoNotStart.Checked = true;
        }

      
       


    }
}
