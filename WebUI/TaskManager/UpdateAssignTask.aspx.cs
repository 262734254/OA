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

public partial class _Default333 : System.Web.UI.Page
{

    //实例化业务层
    TaskManager taskManager = new TaskManager();
    Task t = new Task();

    protected void Page_Load(object sender, EventArgs e)
    {
        int Id = 11;
        //try
        //{

        //    Id = int.Parse(Request.QueryString["Id"].ToString());

        //}
        //catch (Exception)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('没有找到任务编号！');", true);
        //    return;


        //}
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
        ddlweihuMan.DataSource = UserInfoManager.GetAllUser();
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
        this.txtMoney.Text = t.Money.ToString().Substring(0, t.Money.ToString().IndexOf('.'));
        this.txtMoney0.Text = t.Money.ToString().Substring(0, t.Money.ToString().IndexOf('.'));

        this.txtTargeCode.Text = t.Mumber.ToString();
        this.ddlLeaderMan.SelectedItem.Text = t.Principal.ToString();

        this.txtMarks.Text = t.Remarks;
        this.txtTraget.Text = t.targetTask;
        ddlSteps.SelectedItem.Text = t.Tasktype;
        this.ddlAddPower.SelectedItem.Text = t.Vindicator;
        this.txtUserfulWork.Text = t.Work;
        ddlYears.SelectedValue = t.Year.ToString();

        this.lblId.Text = Id.ToString();
        if (t.Path.Trim() == "")
            hkdown.Enabled = false;
        else
            hkdown.NavigateUrl = t.Path;

        // taegtMoney.Text = t.Money.ToString();
    }


    //取得日期月份
    public static string SubstrGetMonth(Object context)
    {
        return Convert.ToDateTime(context).Month.ToString();

    }
    //简化当前金额
    public static string SubShotMoney(Object context)
    {
        return Convert.ToDecimal(context).ToString("c");

    }
    //简化金额二
    public static string SubMoneyZro(Object context)
    {
        return Convert.ToDecimal(context) == 0 ? "0" : context.ToString();

    }


    //简化金额三
    public static string SubMoneyToShot(Object context)
    {
        string str = "";
        if (Convert.ToDecimal(context) != 0)
            str = context.ToString().Substring(0, context.ToString().IndexOf("."));
        else
            str = "0";
        return str;
    }


  
    protected void btnCanel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TaskManager/SearchTask.aspx");
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/TaskManager/SearchTask.aspx");
    }
   

   
    private int GetMonth(string month)
    {
        return Convert.ToInt32(month);
    }

    private double GetMoney(string money)
    {
        return Convert.ToDouble(money);
    }

    protected void btnSubCheck_Click(object sender, EventArgs e)
    {
        double sum = 0;
        try
        {
            if (gvShowDetail.Rows.Count > 0)
            {
                for (int i = 0; i < gvShowDetail.Rows.Count; i++)
                {

                    double Nowmoney = Convert.ToDouble((gvShowDetail.Rows[i].Cells[4].FindControl("txtMoneyOne") as TextBox).Text);
                    sum += Nowmoney;
                    if (Convert.ToDouble(txtMoney.Text.Trim()) > 10 * sum)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('实际完成金额过大！');", true);
                    }
                }
            }

        }
        catch (Exception)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('实际金额只能是数字！');", true);
            return;
        }





        int num = 0;
        Stage s = null;

        if (gvShowDetail.Rows.Count > 0)
        {
            for (int i = 0; i < gvShowDetail.Rows.Count; i++)
            {
                s = new Stage();
                // s.sId = Convert.ToInt32(gvShowDetail.DataKeys[0].Value);
                s.sId = Convert.ToInt32(Convert.ToInt32((gvShowDetail.Rows[i].Cells[1].FindControl("hidSid") as HiddenField).Value));
                // s.sId = Convert.ToInt32(gvShowDetail.Rows[i].Cells[0].Text.Trim());//设置visible=flase获取不到 使用模板列放个hidden控件

                s.Nowmoney = Convert.ToDecimal((gvShowDetail.Rows[i].Cells[4].FindControl("txtMoneyOne") as TextBox).Text);
                s.Description = (gvShowDetail.Rows[i].Cells[5].FindControl("txtDescript") as TextBox).Text;
                s.Problems = (gvShowDetail.Rows[i].Cells[6].FindControl("txtProblems") as TextBox).Text;

                num += taskManager.UpdateAlltheStage(s);


            }
        }

        if (num == gvShowDetail.Rows.Count)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('提交成功！等待审批');", true);
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('提交失败！');", true);





    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //提交审核
        int stageId=Convert.ToInt32(lblId.Text.Trim());

        Response.Redirect("~/PedingMatter/Auditing.aspx?RequisitionID=" + stageId + "&RequisitionType=任务下达");

    }



}
