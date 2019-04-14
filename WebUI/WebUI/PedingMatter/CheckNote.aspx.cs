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
        try
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ExamineManager.SearchExamineByType(ddlTyep.SelectedItem.Text);
            Pager1.DataCount = pds.Count;
            pds.AllowPaging = true;
            pds.PageSize = 5;
            // if (pageIndex == Pager1.PageCount)
            //{
            //  pageIndex--;
            //}
            pds.CurrentPageIndex = pageIndex;
            Pager1.PageCount = pds.PageCount;

            gvExamine.DataSourceID = null;
            gvExamine.DataSource = pds;
            gvExamine.DataBind();
        }
        catch (Exception)
        {

            return;
        }
    }
    
    protected void gvExamine_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id =Convert.ToInt32(e.CommandArgument);
        try
        {
            ExamineManager.DeleteEXamine(id);
            this.ClientScript.RegisterStartupScript(this.GetType(),"","alert('删除成功！')",true);
            Pager1_onLoadPageIndexChaning(Pager1.PageIndex);
        }
        catch (Exception)
        {

            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！')", true);
            return;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Pager1.PageIndex=0;
        Pager1_onLoadPageIndexChaning(Pager1.PageIndex);
    }
}
