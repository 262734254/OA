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

using BLL.Resource;
using Model;

public partial class ResourceManager_ResourceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucpage.onLoadPageIndexChaning += new _Controls_Pager.MyDele(ucpage_onLoadPageIndexChaning);
        if(!IsPostBack)
            ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
    }

    void ucpage_onLoadPageIndexChaning(int pageIndex)
    {
        UserInfo user = new UserInfo();
        if (Session["user"] != null)
        {
            user = (UserInfo)Session["user"];
        }
        else
        {
            Response.Redirect("../login.aspx");
            return;
        }
        //hfLoginId.Value = user.UID.ToString();
        PagedDataSource page = new PagedDataSource();
        page.DataSource = ResourceInfoManager.GetAllResourceInfo(txtName.Text.Trim(), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddlState.SelectedValue));
        ucpage.DataCount = page.Count;
        page.AllowPaging = true;
        page.PageSize = 10;
        page.CurrentPageIndex = pageIndex;
        ucpage.PageCount = page.PageCount;
        gvResourceList.DataSourceID = null;
        gvResourceList.DataSource = page;
        gvResourceList.DataBind();
    }
    protected void btnNewApplyBrrow_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResourceInfo.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
    }
    protected void gvResourceList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            int val = ResourceInfoManager.Delete(Convert.ToInt32(e.CommandArgument));
            if (val != 0)
            {
                this.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功')</script>");
                ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
            }
        }
    }
    protected void gvResourceList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnDel = e.Row.FindControl("lbDel") as LinkButton;
            lnkbtnDel.Attributes.Add("OnClick", "return confirm('确定要删除么?')");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] ids = new int[gvResourceList.Rows.Count];
        for (int a = 0; a < gvResourceList.Rows.Count; a++)
        {
            if ((gvResourceList.Rows[a].FindControl("cbCheck") as CheckBox).Checked)
            {
                ids[a] = Convert.ToInt32(gvResourceList.Rows[a].Cells[0].Text.Trim());
            }
        }
        foreach (int riid in ids)
        {
            if (riid != 0)
            {
                ResourceInfoManager.Delete(riid);
            }
        }
        ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
    }
}
