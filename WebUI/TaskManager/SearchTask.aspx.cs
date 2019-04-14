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
using BLL.Target;
using Model;
using Common;

public partial class Default2 : System.Web.UI.Page
{
    TaskManager taskManager = new TaskManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        Pager2.onLoadPageIndexChaning += new _Controls_Pager.MyDele(Pager2_onLoadPageIndexChaning);

        if (!IsPostBack)
        {
           
            Pager2_onLoadPageIndexChaning(Pager2.PageIndex);
        }

    }


    /// <summary>
    /// 实现委托事件
    /// </summary>
    /// <param name="pageIndex"></param>
    void Pager2_onLoadPageIndexChaning(int pageIndex)
    {
        DataBind(pageIndex);
    }


    /// <summary>
    /// 利用PagedDataSource做数据源绑定数据分页
    /// </summary>
    /// <param name="pageIndex"></param>
    private void DataBind(int pageIndex)
    {
        PagedDataSource pds = new PagedDataSource();
        pds.AllowPaging = true;
        pds.PageSize = CommHelper.GetPageCount;
        IList<Task> list = taskManager.SelectTaskByConditions(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddlStatus.SelectedValue, ddlFile.SelectedValue);
        pds.DataSource = list;
        pds.CurrentPageIndex = pageIndex;  //取得当前页索引
        Pager2.DataCount = list.Count;//获取记录数 并赋值    
        Pager2.PageCount = pds.PageCount;
       
        GVShowTask.DataSourceID = null;
        GVShowTask.DataSource = pds;
        GVShowTask.DataBind();
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        DataBind(0);
    }


    protected void GVShowTask_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "SE")
        {

            Response.Redirect("TaskDetails.aspx?Id=" + id);

        }
        else if (e.CommandName == "UP")
        {

            Response.Redirect("UpdateTask.aspx?Id=" + id);
        }
    }





    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //设置行颜色
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");

        }
    }
}
