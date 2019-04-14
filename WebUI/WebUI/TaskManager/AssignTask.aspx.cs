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
using System.Collections.Generic;
using Model;
using BLL.Target;
using BLL.Power;

public partial class _Default : System.Web.UI.Page
{

    //实例化业务层
    TaskManager taskManager = new TaskManager();
    Task t = new Task();
    static int Id;

   

    protected void Page_Load(object sender, EventArgs e)
    {
          
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
        this.txtMoney0.Text = t.Money.ToString().Substring(0, t.Money.ToString().IndexOf('.'));

        this.txtMoney.Text = t.Money.ToString().Substring(0, t.Money.ToString().IndexOf('.'));
        this.txtTargeCode.Text = t.Mumber.ToString();
        this.ddlLeaderMan.SelectedItem.Text = t.Principal.ToString();

        this.txtMarks.Text = t.Remarks;
        this.txtTraget.Text = t.targetTask;
        ddlSteps.SelectedItem.Text = t.Tasktype;
        this.ddlAddPower.SelectedItem.Text = t.Vindicator;
        this.txtUserfulWork.Text = t.Work;
        ddlYears.SelectedValue = t.Year.ToString();

        this.Label1.Text = Id.ToString();
        hkdown.NavigateUrl = t.Path;

    }








    private int GetMonth(string month)
    {
        return Convert.ToInt32(month);
    }

    private double GetMoney(string money)
    {
        return Convert.ToDouble(money);
    }

    protected void btnJustDo_Click(object sender, EventArgs e)
    {
        //if (GetMonth(ddlStart1.SelectedValue) > GetMonth(ddlOver1.SelectedValue) ||
        //    GetMonth(ddlOver1.SelectedValue) > GetMonth(ddlStart2.SelectedValue) ||
        //   GetMonth(ddlStart2.SelectedValue) > GetMonth(ddlOver2.SelectedValue) ||
        //   GetMonth(ddlOver2.SelectedValue) > GetMonth(ddlStart3.SelectedValue) ||
        //    GetMonth(ddlStart3.SelectedValue) > GetMonth(ddlOver3.SelectedValue) ||
        //    GetMonth(ddlOver3.SelectedValue) > GetMonth(ddlStart4.SelectedValue) ||
        //    GetMonth(ddlStart4.SelectedValue) > GetMonth(ddlOver4.SelectedValue) ||
        //    GetMonth(ddlOver4.SelectedValue) > GetMonth(ddlStart5.SelectedValue) ||
        //    GetMonth(ddlStart5.SelectedValue) > GetMonth(ddlOver5.SelectedValue) ||
        //    GetMonth(ddlOver5.SelectedValue) > GetMonth(ddlStart6.SelectedValue) ||
        //     GetMonth(ddlStart6.SelectedValue) > GetMonth(ddlOver6.SelectedValue)
        //   )
        //{

        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('阶段时间分配不正确！请重新分配！');", true);
        //    return;
        //}



        double targwtMoney = GetMoney(txtMoney.Text);


        //第六阶段

        if (txtPreMoneyOne.Text != "" && txtPreMoneyTwo.Text.Trim() != "" &&
          txtProMoneyThree.Text.Trim() != "" && txtPreMoneyFour.Text.Trim() != "" &&
          txtPreMoneyFive.Text.Trim() != "" && txtPreMoneySix.Text.Trim() != "")
        {

            if (GetMonth(ddlStart1.SelectedValue) > GetMonth(ddlOver1.SelectedValue) ||
                GetMonth(ddlOver1.SelectedValue) > GetMonth(ddlStart2.SelectedValue) ||
          GetMonth(ddlStart2.SelectedValue) > GetMonth(ddlOver2.SelectedValue) ||
          GetMonth(ddlOver2.SelectedValue) > GetMonth(ddlStart3.SelectedValue) ||
            GetMonth(ddlStart3.SelectedValue) > GetMonth(ddlOver3.SelectedValue) ||
             GetMonth(ddlOver3.SelectedValue) > GetMonth(ddlStart4.SelectedValue) ||
            GetMonth(ddlStart4.SelectedValue) > GetMonth(ddlOver4.SelectedValue) ||
            GetMonth(ddlOver4.SelectedValue) > GetMonth(ddlStart5.SelectedValue) ||
             GetMonth(ddlStart5.SelectedValue) > GetMonth(ddlOver5.SelectedValue) ||
             GetMonth(ddlOver5.SelectedValue) > GetMonth(ddlStart6.SelectedValue) ||
              GetMonth(ddlStart6.SelectedValue) > GetMonth(ddlOver6.SelectedValue)
            )
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('阶段时间分配不正确！请重新分配！');", true);
                return;
            }

            double sum = GetMoney(txtPreMoneyOne.Text.Trim()) + GetMoney(txtPreMoneyTwo.Text.Trim()) +
            GetMoney(txtProMoneyThree.Text.Trim()) + GetMoney(txtPreMoneyFour.Text.Trim()) +
           GetMoney(txtPreMoneyFive.Text.Trim()) + GetMoney(txtPreMoneySix.Text.Trim());
            if (sum > targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的总金额不能超过目标金额！');", true);
                return;
            }

            if (sum != targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的金额之和必须等于目标金额！');", true);
                return;
            }


            ////添加到任务中 6
            Stage s = new Stage();

            s.Description = txtDescript6.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver6.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneySix.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneySix.Text.Trim());
            s.Problems = txtProblems7.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart6.SelectedValue + "-" + "1"));
            s.StepName = lblStep6.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            int stageId = taskManager.SendTasksStageToExec(s);

            //5
            s = new Stage();
            s.Description = txtDescript5.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver5.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyFive.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyFive.Text.Trim());
            s.Problems = txtProblems5.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart5.SelectedValue + "-" + "1"));
            s.StepName = lblStep5.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //4
            s = new Stage();
            s.Description = txtDescript4.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver4.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyFour.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyFour.Text.Trim());
            s.Problems = txtProblems4.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart4.SelectedValue + "-" + "1"));
            s.StepName = lblStep4.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //3
            s = new Stage();
            s.Description = txtDescript3.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver3.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyThree.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtProMoneyThree.Text.Trim());
            s.Problems = txtProblems3.Text.Trim();
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart3.SelectedValue + "-" + "1"));
            s.StepName = lblStep3.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //2
            s = new Stage();
            s.Description = txtDescript2.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver2.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyTwo.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyTwo.Text.Trim());
            s.Problems = txtProblems2.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart2.SelectedValue + "-" + "1"));
            s.StepName = lblStep2.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //1
            s = new Stage();
            s.Description = txtDescript1.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver1.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyOne.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyOne.Text.Trim());
            s.Problems = txtProblems1.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart1.SelectedValue + "-" + "1"));
            s.StepName = lblStep1.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);


            if (stageId > 0)
            {
                //更改任务状态为执行中 正在进行
                int num = taskManager.UpdateStageStatus(Id, "正在进行");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达成功！');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达失败！');", true);
            }


        }


        //第五阶段

        if (txtPreMoneyOne.Text != "" && txtPreMoneyTwo.Text.Trim() != "" &&
         txtProMoneyThree.Text.Trim() != "" && txtPreMoneyFour.Text.Trim() != "" &&
         txtPreMoneyFive.Text.Trim() != "" && txtPreMoneySix.Text.Trim() == "")
        {

            if (GetMonth(ddlStart1.SelectedValue) > GetMonth(ddlOver1.SelectedValue) ||
                GetMonth(ddlOver1.SelectedValue) > GetMonth(ddlStart2.SelectedValue) ||
          GetMonth(ddlStart2.SelectedValue) > GetMonth(ddlOver2.SelectedValue) ||
          GetMonth(ddlOver2.SelectedValue) > GetMonth(ddlStart3.SelectedValue) ||
            GetMonth(ddlStart3.SelectedValue) > GetMonth(ddlOver3.SelectedValue) ||
             GetMonth(ddlOver3.SelectedValue) > GetMonth(ddlStart4.SelectedValue) ||
            GetMonth(ddlStart4.SelectedValue) > GetMonth(ddlOver4.SelectedValue) ||
            GetMonth(ddlOver4.SelectedValue) > GetMonth(ddlStart5.SelectedValue) ||
            GetMonth(ddlStart5.SelectedValue) > GetMonth(ddlOver5.SelectedValue)
           )
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('阶段时间分配不正确！请重新分配！');", true);
                return;
            }


            double aa = Convert.ToDouble(txtPreMoneyOne.Text.Trim()) + Convert.ToDouble(txtPreMoneyTwo.Text.Trim()) +
          Convert.ToDouble(txtProMoneyThree.Text.Trim()) + Convert.ToDouble(txtPreMoneyFour.Text.Trim()) +
         Convert.ToDouble(txtPreMoneyFive.Text.Trim());
            if (aa > targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的总金额不能超过目标金额！');", true);
                return;
            }
            if (aa != targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的金额之和必须等于目标金额！');", true);
                return;
            }

            ////添加到任务中 5
            Stage s = new Stage();

            s.Description = txtDescript5.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver5.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyFive.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyFive.Text.Trim());
            s.Problems = txtProblems5.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart5.SelectedValue + "-" + "1"));
            s.StepName = lblStep5.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            int stageId = taskManager.SendTasksStageToExec(s);

            //4
            s = new Stage();
            s.Description = txtDescript4.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver4.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyFour.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyFour.Text.Trim());
            s.Problems = txtProblems4.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart4.SelectedValue + "-" + "1"));
            s.StepName = lblStep4.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //3
            s = new Stage();
            s.Description = txtDescript3.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver3.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyThree.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtProMoneyThree.Text.Trim());
            s.Problems = txtProblems3.Text.Trim();
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart3.SelectedValue + "-" + "1"));
            s.StepName = lblStep3.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //2
            s = new Stage();
            s.Description = txtDescript2.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver2.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyTwo.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyTwo.Text.Trim());
            s.Problems = txtProblems2.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart2.SelectedValue + "-" + "1"));
            s.StepName = lblStep2.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //1
            s = new Stage();
            s.Description = txtDescript1.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver1.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyOne.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyOne.Text.Trim());
            s.Problems = txtProblems1.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart1.SelectedValue + "-" + "1"));
            s.StepName = lblStep1.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);




            if (stageId > 0)
            {
                //更改任务状态为执行中 正在进行
                int num = taskManager.UpdateStageStatus(Id, "正在进行");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达成功！');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达失败！');", true);
            }

        }

        //第四阶段

        if (txtPreMoneyOne.Text != "" && txtPreMoneyTwo.Text.Trim() != "" &&
         txtProMoneyThree.Text.Trim() != "" && txtPreMoneyFour.Text.Trim() != "" &&
         txtPreMoneyFive.Text.Trim() == "" && txtPreMoneySix.Text.Trim() == "")
        {

            if (GetMonth(ddlStart1.SelectedValue) > GetMonth(ddlOver1.SelectedValue) ||
                  GetMonth(ddlOver1.SelectedValue) > GetMonth(ddlStart2.SelectedValue) ||
            GetMonth(ddlStart2.SelectedValue) > GetMonth(ddlOver2.SelectedValue) ||
            GetMonth(ddlOver2.SelectedValue) > GetMonth(ddlStart3.SelectedValue) ||
              GetMonth(ddlStart3.SelectedValue) > GetMonth(ddlOver3.SelectedValue) ||
               GetMonth(ddlOver3.SelectedValue) > GetMonth(ddlStart4.SelectedValue) ||
              GetMonth(ddlStart4.SelectedValue) > GetMonth(ddlOver4.SelectedValue)

             )
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('阶段时间分配不正确！请重新分配！');", true);
                return;
            }

            double sum = GetMoney(txtPreMoneyOne.Text.Trim()) + GetMoney(txtPreMoneyTwo.Text.Trim()) +
            GetMoney(txtProMoneyThree.Text.Trim()) + GetMoney(txtPreMoneyFour.Text.Trim());
            if (sum > targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的总金额不能超过目标金额！');", true);
                return;
            }
            if (sum != targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的金额之和必须等于目标金额！');", true);
                return;
            }


            ////添加到任务中 4
            Stage s = new Stage();

            s.Description = txtDescript4.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver4.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyFour.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyFour.Text.Trim());
            s.Problems = txtProblems4.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart4.SelectedValue + "-" + "1"));
            s.StepName = lblStep4.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            int stageId = taskManager.SendTasksStageToExec(s);

            //3
            s = new Stage();
            s.Description = txtDescript3.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver3.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyThree.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtProMoneyThree.Text.Trim());
            s.Problems = txtProblems3.Text.Trim();
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart3.SelectedValue + "-" + "1"));
            s.StepName = lblStep3.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //2
            s = new Stage();
            s.Description = txtDescript2.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver2.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyTwo.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyTwo.Text.Trim());
            s.Problems = txtProblems2.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart2.SelectedValue + "-" + "1"));
            s.StepName = lblStep2.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //1
            s = new Stage();
            s.Description = txtDescript1.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver1.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyOne.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyOne.Text.Trim());
            s.Problems = txtProblems1.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart1.SelectedValue + "-" + "1"));
            s.StepName = lblStep1.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);



            if (stageId > 0)
            {
                //更改任务状态为执行中 正在进行
                int num = taskManager.UpdateStageStatus(Id, "正在进行");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达成功！');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达失败！');", true);
            }

        }


        //第三阶段

        if (txtPreMoneyOne.Text != "" && txtPreMoneyTwo.Text.Trim() != "" &&
          txtProMoneyThree.Text.Trim() != "" && txtPreMoneyFour.Text.Trim() == "" &&
          txtPreMoneyFive.Text.Trim() == "" && txtPreMoneySix.Text.Trim() == "")
        {
            if (GetMonth(ddlStart1.SelectedValue) > GetMonth(ddlOver1.SelectedValue) ||
                GetMonth(ddlOver1.SelectedValue) > GetMonth(ddlStart2.SelectedValue) ||
          GetMonth(ddlStart2.SelectedValue) > GetMonth(ddlOver2.SelectedValue) ||
          GetMonth(ddlOver2.SelectedValue) > GetMonth(ddlStart3.SelectedValue) ||
           GetMonth(ddlStart3.SelectedValue) > GetMonth(ddlOver3.SelectedValue)

          )
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('阶段时间分配不正确！请重新分配！');", true);
                return;
            }


            double sum = GetMoney(txtPreMoneyOne.Text.Trim()) + GetMoney(txtPreMoneyTwo.Text.Trim()) +
            GetMoney(txtProMoneyThree.Text.Trim());
            if (sum > targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的总金额不能超过目标金额！');", true);
                return;
            }
            if (sum != targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的金额之和必须等于目标金额！');", true);
                return;
            }



            ////添加到任务中 3
            Stage s = new Stage();

            s.Description = txtDescript3.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver3.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyThree.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtProMoneyThree.Text.Trim());
            s.Problems = txtProblems3.Text.Trim();
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart3.SelectedValue + "-" + "1"));
            s.StepName = lblStep3.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            int stageId = taskManager.SendTasksStageToExec(s);


            //2
            s = new Stage();
            s.Description = txtDescript2.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver2.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyTwo.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyTwo.Text.Trim());
            s.Problems = txtProblems2.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart2.SelectedValue + "-" + "1"));
            s.StepName = lblStep2.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            //1
            s = new Stage();
            s.Description = txtDescript1.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver1.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyOne.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyOne.Text.Trim());
            s.Problems = txtProblems1.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart1.SelectedValue + "-" + "1"));
            s.StepName = lblStep1.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);



            if (stageId > 0)
            {
                //更改任务状态为执行中 正在进行
                int num = taskManager.UpdateStageStatus(Id, "正在进行");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达成功！');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达失败！');", true);
            }

        }

        //第二阶段

        if (txtPreMoneyOne.Text != "" && txtPreMoneyTwo.Text.Trim() != "" &&
          txtProMoneyThree.Text.Trim() == "" && txtPreMoneyFour.Text.Trim() == "" &&
          txtPreMoneyFive.Text.Trim() == "" && txtPreMoneySix.Text.Trim() == "")
        {

            if (GetMonth(ddlStart1.SelectedValue) > GetMonth(ddlOver1.SelectedValue) ||
                GetMonth(ddlOver1.SelectedValue) > GetMonth(ddlStart2.SelectedValue) ||
           GetMonth(ddlStart2.SelectedValue) > GetMonth(ddlOver2.SelectedValue)
           )
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('阶段时间分配不正确！请重新分配！');", true);
                return;
            }

            double sum = GetMoney(txtPreMoneyOne.Text.Trim()) + GetMoney(txtPreMoneyTwo.Text.Trim());
            if (sum > targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的总金额不能超过目标金额！');", true);
                return;
            }
            if (sum != targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的金额之和必须等于目标金额！');", true);
                return;
            }

            ////添加到任务中 2
            Stage s = new Stage();

            s.Description = txtDescript2.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver2.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyTwo.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyTwo.Text.Trim());
            s.Problems = txtProblems2.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart2.SelectedValue + "-" + "1"));
            s.StepName = lblStep2.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            int stageId = taskManager.SendTasksStageToExec(s);

            //1
            s = new Stage();
            s.Description = txtDescript1.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver1.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyOne.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyOne.Text.Trim());
            s.Problems = txtProblems1.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart1.SelectedValue + "-" + "1"));
            s.StepName = lblStep1.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            stageId = taskManager.SendTasksStageToExec(s);

            if (stageId > 0)
            {
                //更改任务状态为执行中 正在进行
                int num = taskManager.UpdateStageStatus(Id, "正在进行");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达成功！');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达失败！');", true);
            }

        }


        //阶段一
        if (txtPreMoneyOne.Text != "" && txtPreMoneyTwo.Text.Trim() == "" &&
            txtProMoneyThree.Text.Trim() == "" && txtPreMoneyFour.Text.Trim() == "" &&
            txtPreMoneyFive.Text.Trim() == "" && txtPreMoneySix.Text.Trim() == "")
        {
            if (GetMonth(ddlStart1.SelectedValue) > GetMonth(ddlOver1.SelectedValue))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('阶段时间分配不正确！请重新分配！');", true);
                return;
            }
            double sum = GetMoney(txtPreMoneyOne.Text.Trim());

            if (sum != targwtMoney)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('计划完成的金额之和必须等于目标金额！');", true);
                return;
            }

            ////添加到任务中
            Stage s = new Stage();


            s.Description = txtDescript1.Text;
            s.filishTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlOver1.SelectedValue + "-" + "1"));
            s.Nowmoney = Convert.ToDecimal(txtMoneyOne.Text.Trim());
            s.Premoney = Convert.ToDecimal(txtPreMoneyOne.Text.Trim());
            s.Problems = txtProblems1.Text;
            s.startTime = Convert.ToDateTime((Convert.ToDateTime(txFDate.Text.Trim()).Year.ToString() + "-" +
                ddlStart1.SelectedValue + "-" + "1"));
            s.StepName = lblStep1.Text;
            s.taskId = Convert.ToInt32(this.Label1.Text.Trim());
            int stageId = taskManager.SendTasksStageToExec(s);



            if (stageId > 0)
            {
                //更改任务状态为执行中 正在进行
                int num = taskManager.UpdateStageStatus(Id, "正在进行");

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达成功！');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('下达失败！');", true);


            }
        }


        Response.Redirect("~/TaskManager/SearchTask.aspx");

    }

    static IList<Stage> taskListtt = new List<Stage>();

    protected void lnkAddStep_Click(object sender, EventArgs e)
    {
        string str = "";
        IList<Model.Stage> listStage = taskManager.GetStageListDataShow();
        
        for (int i = 0; i < gvStepShow.Rows.Count; i++)
        {

            int num = gvStepShow.Rows.Count;
            switch (num)
            {
                case 0:
                    str = "第一阶段";
                    break;
                case 1:
                    str = "第二阶段";
                    break;
                case 2:
                    str = "第三阶段";
                    break;
                case 3:
                    str = "第四阶段";
                    break;
                case 4:
                    str = "第五阶段";
                    break;
                case 5:
                    str = "第六阶段";
                    break;
                case 6:
                    str = "第七阶段";
                    break;
                case 7:
                    str = "第八阶段";
                    break;
                case 8:
                    str = "第九阶段";
                    break;
                case 9:
                    str = "第十阶段";
                    break;
                case 10:
                    str = "第十一阶段";
                    break;
                case 11:
                    str = "第十二阶段";
                    break;
            }
        }

        Stage s = new Stage();
        s.StepName = str;
       

        for (int i = 0; i < taskListtt.Count; i++)
        {
            Stage st=(Stage)taskListtt[i];
            foreach (Stage ss in listStage)
            {
                if (ss != st)
                {
                    taskListtt.Add(ss);
                }
            }
          
        }
        taskListtt.Add(s);

        this.gvStepShow.DataSourceID = null;
        gvStepShow.DataSource = taskListtt;
        gvStepShow.DataBind();

    }





    //删除一个阶段
    protected void lnkAddStep0_Click(object sender, EventArgs e)
    {
        IList<Model.Stage> listStage = taskManager.GetStageListDataShow();
      
        if (gvStepShow.Rows.Count > 0)
        {
            int num = gvStepShow.Rows.Count;

            switch (num)
            {
                case 1:
                    listStage.RemoveAt(0);
                    break;
                case 2:
                    listStage.RemoveAt(1);
                    break;
                case 3:
                    listStage.RemoveAt(2);
                    break;
                case 4:
                    listStage.RemoveAt(3);
                    break;
                case 5:
                    listStage.RemoveAt(4);
                    break;
                case 6:
                    listStage.RemoveAt(5);
                    break;

                case 7:
                    listStage.RemoveAt(6);
                    break;
                case 8:
                    listStage.RemoveAt(7);
                    break;
                case 9:
                    listStage.RemoveAt(8);
                    break;
                case 10:
                    listStage.RemoveAt(9);
                    break;
                case 11:
                    listStage.RemoveAt(10);
                    break;
                case 12:
                    listStage.RemoveAt(11);
                    break;
            }
        }

        this.gvStepShow.DataSourceID = null;
        gvStepShow.DataSource = listStage;
        gvStepShow.DataBind();



    }
}
