using System;
using System.Collections.Generic;
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
using BLL.Car;

public partial class CarManager_carslist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucpage.onPageIndexChanging += new CarManager_MyPage.myDele(ucpage_onPageIndexChanging);
       
        if (!IsPostBack)
        {
            ucpage_onPageIndexChanging(ucpage.PageIndex);
            //this.gvCars.DataSource = CarsManager.SelectCarsDark(txtDept.Text,drlCarType.SelectedValue,drlCarStae.SelectedValue);
            //this.gvCars.DataBind();
        }
    }
                        
    void ucpage_onPageIndexChanging(int pageIndex)
    {
        string mark = txtDept.Text.ToString();
        string typeid = drlCarType.SelectedValue.ToString();
        string state = drlCarStae.SelectedValue.ToString();

        gvCars.DataSourceID = null;
        IList<Car_Cars> list = CarsManager.SelectCarsDark(txtDept.Text, drlCarType.SelectedValue, drlCarStae.SelectedValue);
        if (list.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('无记录！');", true);

        }
        PagedDataSource page = new PagedDataSource();
        page.AllowPaging = true;
        page.DataSource = list;// CarsManager.SelectCarsDark(txtDept.Text, drlCarType.SelectedValue, drlCarStae.SelectedValue);
        page.PageSize = 5;
        ucpage.PageCount = page.PageCount;

        page.CurrentPageIndex = pageIndex;

        gvCars.DataSource = page;
        ucpage.SetButtonEnable();
        gvCars.DataBind();
    }


    protected void lkXianXi_Click(object sender, EventArgs e)
    {
        LinkButton lk = (LinkButton)sender;
        int id = Convert.ToInt32(lk.CommandArgument);
        Response.Redirect("~/CarManager/newCars.aspx?op=2&id=" + id);
    }

 
   
    /// <summary>
    /// 删除车辆
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        CheckBox chckbx = null;
        LinkButton lkbtnDelete = null;
        string Id = "";
        for (int i = 0; i < this.gvCars.Rows.Count; i++)
        {
            chckbx = this.gvCars.Rows[i].FindControl("chSelect") as CheckBox;
            lkbtnDelete = this.gvCars.Rows[i].FindControl("lbDel") as LinkButton;
            if (chckbx.Checked)
            {
                string Id1 = lkbtnDelete.CommandArgument.ToString();
                Id += Id1 + ",";
            }
        }
        if (Id != "")
        {
            try
            {
                Id = Id.Substring(0, Id.Length - 1);
                Car_Cars cars = CarsManager.GetAllCarsById(Convert.ToInt32(Id));

                if (cars.State == "已出车" || cars.State == "维修")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('此车不是未出车状态不可删除！');", true);
                }
                else
                {
                    CarsManager.DcseteCars(Id);
                    gvCars.DataSourceID = null;
                    gvCars.DataSource =CarsManager.SelectCarsDark(txtDept.Text,drlCarType.SelectedValue,drlCarStae.SelectedValue);
                    gvCars.DataBind();
                }
            }
            catch
            {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
                return;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请选择要删除的项！');", true);
        }
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        //string mark = txtDept.Text.ToString();
        //string typeid = drlCarType.SelectedValue.ToString();
        //string state = drlCarStae.SelectedValue.ToString();

        //gvCars.DataSourceID = null;
        //IList<Car_Cars> list = CarsManager.SelectCarsDark(txtDept.Text, drlCarType.SelectedValue, drlCarStae.SelectedValue);
        //if (list.Count == 0)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('无记录！');", true);

        //}
        ucpage.PageIndex = 0;
       ucpage_onPageIndexChanging(ucpage.PageIndex);
        //gvCars.DataSource = list;
        //gvCars.DataBind();
        
    }
   
    protected void lkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lk = (LinkButton)sender;
        int id = Convert.ToInt32(lk.CommandArgument);
        Response.Redirect("~/CarManager/newCars.aspx?op=3&id=" + id);
    }
    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCars_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string cmd = e.CommandName;//获取命令名称
        //int Id = Convert.ToInt32(e.CommandArgument);//获取命令参数  
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            try
            {
                Car_Cars cars = CarsManager.GetAllCarsById(Convert.ToInt32( Id));
                         
                if (cars.State == "已出车" || cars.State == "维修")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('此车不是未出车状态不可删除！');", true);
                }
                else
                { 
                int num = CarsManager.DcseteCars(Id);

                if (num > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');", true);
                }
                
                ucpage.PageIndex = 0;
                ucpage_onPageIndexChanging(ucpage.PageIndex);
                //gvCars.DataSourceID = null;
                //gvCars.DataSource = odsCars;
                //gvCars.DataBind();
                }

            }
            catch
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
                return;
            }

        }
        else if (e.CommandName== "weixiou")
        {
            try
            {
                string Id = e.CommandArgument.ToString();
                Car_Cars cars = CarsManager.GetAllCarsById(Convert.ToInt32(Id));
                
               int num= CarsManager.UpadteCarsByIdSate(Convert.ToInt32(Id));
               if (num > 0)
               {
                   Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功！');", true);
               }
                ucpage.PageIndex = 0;
                ucpage_onPageIndexChanging(ucpage.PageIndex);
            }
            catch
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('维修失败！');", true);
            }
        }
    }
    /// <summary>
    /// 光棒效果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvCars_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField CarId = e.Row.FindControl("lblWei") as HiddenField;

            Car_Cars cars = CarsManager.GetAllCarsById(Convert.ToInt32(CarId.Value));

            if (cars.State == "已出车"||cars.State=="维修")
            {
                LinkButton lbReturn = e.Row.FindControl("lbSend") as LinkButton;
                LinkButton lndel = e.Row.FindControl("lbDel") as LinkButton;
                lbReturn.Enabled = false;
                lndel.Enabled = false;

            }
            //设置行颜色   
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ff9900'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

        }
    }

    protected void lnkdel_Click(object sender, EventArgs e)
    {
        
    }
    protected void lbWeiXiou_Click(object sender, EventArgs e)
    {
    
    }
}
