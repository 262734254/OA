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
using BLL.Car;
using Model;
public partial class CarManager_Davnotelist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       ucpage.onPageIndexChanging += new CarManager_MyPage.myDele(ucpage_onPageIndexChanging);
        if (!IsPostBack)
        {
            ucpage.PageIndex = 0;
            ucpage_onPageIndexChanging(ucpage.PageIndex);

            //this.gvDavnote.DataSource = CarDavnoteManager.SelectDavnoteDark(txtMark.Text, ddlDept.SelectedValue, ddlType.SelectedValue);

            //this.gvDavnote.DataBind();
        }
    }

    void ucpage_onPageIndexChanging(int pageIndex)
    {
        string mark = txtMark.Text.ToString();
        string typeid = ddlType.SelectedValue.ToString();
        string dept = ddlDept.SelectedValue.ToString();
        gvDavnote.DataSourceID = null;
        IList<Car_Davnote> list = CarDavnoteManager.SelectDavnoteDark(txtMark.Text, ddlType.SelectedValue, ddlDept.SelectedValue);
        if (list.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('无记录！');", true);
            return;
        }
        PagedDataSource page = new PagedDataSource();
        page.AllowPaging = true;
        page.DataSource = list;// CarDavnoteManager.SelectDavnoteDark(txtMark.Text, ddlDept.SelectedValue, ddlType.SelectedValue);
        page.PageSize = 5;
        ucpage.PageCount = page.PageCount;
        page.CurrentPageIndex = pageIndex;
        gvDavnote.DataSource = page;
        gvDavnote.DataBind();
        ucpage.SetButtonEnable();
       
    }
/// <summary>
/// 查询
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    protected void btnSelect_Click(object sender, EventArgs e)
    {
       
        ucpage.PageIndex=0;
        ucpage_onPageIndexChanging(ucpage.PageIndex);

        

    }
    /// <summary>
    /// 查询
    /// </summary>
    private void Bind()
    {
        //string mark = txtMark.Text.ToString();
        //string typeid = ddlType.SelectedValue.ToString();
        //string dept = ddlDept.SelectedValue.ToString();
        //gvDavnote.DataSourceID = null;
        //IList<Car_Davnote> list = CarDavnoteManager.SelectDavnoteDark(txtMark.Text, ddlType.SelectedValue, ddlDept.SelectedValue);
        //if (list.Count == 0)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('无记录！');", true);
        //    return;
        //}
        //ucpage.PageIndex = 0;
        //ucpage_onPageIndexChanging(ucpage.PageIndex);
        //gvDavnote.DataSource = list;

        //gvDavnote.DataBind();

    }
    protected void gvDavnote_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label lblDavMark = e.Row.FindControl("lblDavMark") as Label;
            string davMark = lblDavMark.Text;
                 string state= CarsManager.SelectState(davMark);
                 if (state == "未出车")
                 {
                     LinkButton lbReturn = e.Row.FindControl("lbBack") as LinkButton;
                     lbReturn.Enabled = false;
                

                 }
                 if (state == "已出车")
                 {
                     CheckBox check = e.Row.FindControl("chSelect") as CheckBox;
                     LinkButton lbldelede = e.Row.FindControl("lbDel") as LinkButton;
                     lbldelede.Enabled = false;
                     check.Enabled = false;

                 }
               

                //设置行颜色   
                e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ff9900'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

        }
    }

    /// <summary>
    /// 删除方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        CheckBox chckbx = null;
        LinkButton lkbtnDelete = null;
        string Id = "";
        for (int i = 0; i < this.gvDavnote.Rows.Count; i++)
        {
            chckbx = this.gvDavnote.Rows[i].FindControl("chSelect") as CheckBox;
            lkbtnDelete = this.gvDavnote.Rows[i].FindControl("lbDel") as LinkButton;
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
               
               
                    CarDavnoteManager.DeleteDavnote(Id);
                    Bind();
                
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
    /// <summary>
    /// 详细
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lkXianXi_Click(object sender, EventArgs e)
    {
        LinkButton lk = (LinkButton)sender;
        int id = Convert.ToInt32(lk.CommandArgument);
        Response.Redirect("~/CarManager/Davnote.aspx?op=2&id=" + id);
    }


    protected void gvDavnote_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            try
            {
         
                    int num = CarDavnoteManager.DeleteDavnote(Id);

                    if (num > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');", true);
                    }
                    Bind();
                
            }

            catch
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
                return;
            }
        }

    }
    protected void lnkhuiche_Click(object sender, EventArgs e)
    {
        LinkButton lk = (LinkButton)sender;
        int id = Convert.ToInt32(lk.CommandArgument);
        Response.Redirect("~/CarManager/Enter.aspx?op=1&id=" + id);
    }
}
