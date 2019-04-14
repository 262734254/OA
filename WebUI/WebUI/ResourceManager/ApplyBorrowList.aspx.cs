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

public partial class ResourceManager_ApplyBorrowList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucpage.onLoadPageIndexChaning += new _Controls_Pager.MyDele(ucpage_onLoadPageIndexChaning);
        if (!IsPostBack)
            ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
       // BorrowBind(0, 0, "");
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
        int baid = 0;
        int batype = 0;
        string batime = "";
        if (txtBAID.Text != "")
        {
            try
            {
                baid = Convert.ToInt32(txtBAID.Text.Trim());
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入数字')</script>");
                return;
            }
        }
        if (txtBATime.Value != "")
            batime = txtBATime.Value.Trim();
        batype = Convert.ToInt32(ddlBAType.SelectedValue);
        this.hfLoginId.Value = user.UID.ToString();
        PagedDataSource page = new PagedDataSource();
        page.DataSource = BorrowApplicationManager.SearchBorrowApplication(baid, batype, batime, user.UID);
        ucpage.DataCount = page.Count;
        page.AllowPaging = true;
        page.PageSize = 10;
        page.CurrentPageIndex = pageIndex;
        ucpage.PageCount = page.PageCount;
        gvBorrowApplicationList.DataSourceID = null;
        gvBorrowApplicationList.DataSource = page;
        gvBorrowApplicationList.DataBind();
    }
    protected void btnNewApplyBrrow_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplyBorrow.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] ids = new int[gvBorrowApplicationList.Rows.Count];
        for (int a = 0; a < gvBorrowApplicationList.Rows.Count; a++)
        {
            if ((gvBorrowApplicationList.Rows[a].FindControl("cbCheck") as CheckBox).Checked)
            {
                ids[a] = Convert.ToInt32(gvBorrowApplicationList.Rows[a].Cells[1].Text.Trim());
            }
        }
        foreach (int baid in ids)
        {
            if (baid != 0)
            {
                BorrowApplicationManager.DeleteById(baid);
            }
        }
        ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
    }

    private void BorrowBind(int baid, int batype, string batime)
    {
        ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
    }
    protected void gvBorrowApplicationList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            int val = BorrowApplicationManager.DeleteById(Convert.ToInt32(e.CommandArgument));
            if (val != 0)
            {
                this.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功')</script>");
                ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
            }
        }
    }
    protected void gvBorrowApplicationList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnDel = e.Row.FindControl("lbDel") as LinkButton;
            lnkbtnDel.Attributes.Add("OnClick", "return confirm('确定要删除么?')");
        }
    }
}
