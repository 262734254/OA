using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Model;
using BLL.Car;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL.Power;

public partial class shenlist : System.Web.UI.Page
{
    public static int Id;
    public static UserInfo user;
    protected void Page_Load(object sender, EventArgs e)
    {
       ucpage.onPageIndexChanging += new CarManager_MyPage.myDele(ucpage_onPageIndexChanging);
        if (!IsPostBack)
        {


            if (Session["user"] != null)
            {

                user = (UserInfo)Session["user"];
                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('您必须先登录！');window.location='../login.aspx'", true);
                return;
            }
           
            txtDept.Text = user.Name;
            ucpage_onPageIndexChanging(ucpage.PageIndex); 
        }

    }

    void ucpage_onPageIndexChanging(int pageIndex)
    {
        string ByMan = txtDept.Text.ToString();
        string typeid = drlCarType.SelectedValue.ToString();
        string state = drlCarStae.SelectedValue.ToString();
        gvByappyl.DataSourceID = null;
        IList<Car_Byapply> list = CarByapplyManager.usp_CarSelectByappy(txtDept.Text, drlCarType.SelectedValue, drlCarStae.SelectedValue);
        if (list.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('你没有申请记录请重新申请！');", true);

        }
        PagedDataSource page = new PagedDataSource();
        page.AllowPaging = true;
        page.DataSource = list;//CarByapplyManager.usp_CarSelectByappy(txtDept.Text, drlCarType.SelectedValue, drlCarStae.SelectedValue);
        page.PageSize = 5;
        ucpage.PageCount = page.PageCount;
        page.CurrentPageIndex = pageIndex;
        gvByappyl.DataSource = page;
        ucpage.SetButtonEnable();
        gvByappyl.DataBind();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        ucpage.PageIndex = 0;
        ucpage_onPageIndexChanging(ucpage.PageIndex);
        
        //gvByappyl.DataSource = list;
        //gvByappyl.DataBind();
    }
    protected void lkXianXi_Click(object sender, EventArgs e)
    {
        LinkButton lk = (LinkButton)sender;
        int id = Convert.ToInt32(lk.CommandArgument);
        Response.Redirect("~/CarManager/ByapplyCaparticular.aspx?op=1&id=" + id);
    }
    protected void lkShenPi_Click(object sender, EventArgs e)
    {
        LinkButton lk = (LinkButton)sender;
        int id = Convert.ToInt32(lk.CommandArgument);
        Response.Redirect("~/CarManager/AddDavnote.aspx?op=2&id=" + id);
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {   
    }
    protected void gvByappyl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField ByappyId = e.Row.FindControl("lblByappyId") as HiddenField;

            Car_Byapply cars = CarByapplyManager.GetAllCarsByappyById(Convert.ToInt32(ByappyId.Value));

            if (cars.State == "待办")
            {
                LinkButton lbReturn = e.Row.FindControl("lbSend") as LinkButton;
                LinkButton lndel = e.Row.FindControl("lbDel") as LinkButton;
                lbReturn.Enabled = false;
                lndel.Enabled = false;

            }
            if (cars.State == "终结")
            {
                LinkButton lbReturn = e.Row.FindControl("lbSend") as LinkButton;
                lbReturn.Enabled = false;
            }

            //设置行颜色   
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ff9900'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

        }
         


         


    }
    protected void gvByappyl_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            try
            {

                Car_Byapply cars = CarByapplyManager.GetAllCarsByappyById(Convert.ToInt32(Id));


                if (cars.State == "待办")
                {
                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('此车还未审批，不能删除！');", true);
                }
                else
                {
                    int num = CarByapplyManager.DeleteByapply(Id);

                    if (num > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');", true);
                    }
                    gvByappyl.DataSourceID = null;
                    gvByappyl.DataSource = odsbyappy;
                    gvByappyl.DataBind();
                }
            }

            catch
            {


                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
                return;
            }
        }
    }
}
