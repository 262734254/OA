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

public partial class ResourceManager_ResourceList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnNewApplyBrrow_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResourceInfo.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string name = this.txtName.Text.Trim();
        int typeid = Convert.ToInt32(this.ddlType.SelectedValue);
        int state = Convert.ToInt32(this.ddlState.SelectedValue);
        this.gvResourceList.DataSourceID = null;
        this.gvResourceList.DataSource = ResourceInfoManager.GetAllResourceInfo(name, typeid, state);
        this.gvResourceList.DataBind();
    }
    protected void gvResourceList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            int val = ResourceInfoManager.Delete(Convert.ToInt32(e.CommandArgument));
            if (val != 0)
            {
                this.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功')</script>");
                gvResourceList.DataBind();
            }
        }
    }
    protected void gvResourceList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnDel = e.Row.FindControl("lnkbtnDel") as LinkButton;
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
        gvResourceList.DataBind();
    }
}
