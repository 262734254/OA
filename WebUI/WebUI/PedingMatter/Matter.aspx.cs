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
using BLL.Matter;
using Model;

public partial class OfficeHelp_LeaveMessage_ShowMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Pager1.onLoadPageIndexChaning += new _Controls_Pager.MyDele(Pager1_onLoadPageIndexChaning);
        if (!IsPostBack)
        {
            Pager1_onLoadPageIndexChaning(Pager1.PageIndex);

          
        }

    }

    void Pager1_onLoadPageIndexChaning(int pageIndex)
    {
        Bind();
    }
    private void Bind()
    {
        try
        {
            PagedDataSource pds = new PagedDataSource();
            pds.AllowPaging = true;
            pds.DataSource = ExamineManager.SearchPending(ddlState.SelectedValue, ddlType.SelectedItem.Text);
            Pager1.DataCount = pds.Count;
            pds.CurrentPageIndex = Pager1.PageIndex;
            pds.PageSize = 5;
            Pager1.PageCount = pds.PageCount;
            gvPending.DataSourceID = null;
            gvPending.DataSource = pds;
            gvPending.DataBind();
        }
        catch (Exception)
        {

            return;
        }

    }
    /// <summary>
    /// 根据状态和类型查询待办事项
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Pager1.PageIndex = 0;
        Bind();
    }
    protected void gvPending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType==DataControlRowType.DataRow)
        {
            LinkButton lblState = e.Row.FindControl("lblState") as LinkButton;
            if (lblState.Text=="已办" || lblState.Text=="终结")
            {
                LinkButton lblEnd = e.Row.FindControl("lblEnd") as LinkButton;
                lblState.Enabled = false;
                lblEnd.Enabled = false;
            }
        }
    }
    /// <summary>
    /// 点击按钮激发事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvPending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
          int id = Convert.ToInt32(e.CommandArgument);
          
          LinkButton lblState =e.CommandSource as LinkButton;
          Label lblType = lblState.Parent.Parent.FindControl("lblType") as Label;

        //办理
        if (e.CommandName=="State")
        {
            if (lblType.Text=="会议申请")
            {
                Response.Redirect("~/MeetingManager/MeetingExamine.aspx?id=" + id.ToString());
            }
            else if(lblType.Text=="用车申请")
            {
                Response.Redirect("~/CarManager/ByapplyCaparticular.aspx?op=2&id="+id.ToString());
            }
            else if (lblType.Text == "资源借用")
            {
                Response.Redirect("~/ResourceManager/ApplyBorrowInfo.aspx?id=" + id.ToString());
            }
            else if (lblType.Text=="资源采购")
            {
                Response.Redirect("~/ResourceManager/ApplyStockInfo.aspx?id=" + id.ToString());
            }
            else if (lblType.Text=="任务申请")
            {
                Response.Redirect("~/TaskManager/UpdateAssignTask.aspx?Id=" + id.ToString());
            }

        }
        else  //终结
        {
            try
            {
                ExamineManager.ModifyApplicationById(lblType.Text, id);
                Page.ClientScript.RegisterStartupScript(this.GetType(),"",string.Format("<script>alert('{0}终结成功')</script>",lblType.Text));
                Bind();

            }
            catch (Exception)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("<script>alert('{0}终结失败')</script>", lblType.Text));

            }

        }
    }
   
}
