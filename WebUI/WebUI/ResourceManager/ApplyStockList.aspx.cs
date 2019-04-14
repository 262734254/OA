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

public partial class ResourceManager_ApplyStockList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucpage.onLoadPageIndexChaning += new _Controls_Pager.MyDele(ucpage_onLoadPageIndexChaning);
        if (!IsPostBack)
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
        hfLoginId.Value = user.UID.ToString();
        PagedDataSource page = new PagedDataSource();
        page.DataSource = StockApplicationManager.SearchStockApplication(Convert.ToInt32(txtSAID.Text.Trim() == "" ? "0" : txtSAID.Text.Trim()), txtSATime.Value.Trim(), user.UID);
        ucpage.DataCount = page.Count;
        page.AllowPaging = true;
        page.PageSize = 10;
        page.CurrentPageIndex = pageIndex;
        ucpage.PageCount = page.PageCount;
        gvStockApplicationList.DataSourceID = null;
        gvStockApplicationList.DataSource = page;
        gvStockApplicationList.DataBind();
    }

    protected void btnNewApplyStock_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplyStock.aspx");
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int said = 0;
        string satime = "";
        if (txtSAID.Text != "")
        {
            try
            {
                said = Convert.ToInt32(txtSAID.Text.Trim());
            }
            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入数字')</script>");
                return;
            }
        }
        if (txtSATime.Value != "")
            satime = txtSATime.Value.Trim();
        BorrowBind(said, satime);
        ucpage_onLoadPageIndexChaning(ucpage.PageIndex);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] ids = new int[gvStockApplicationList.Rows.Count];
        for (int a = 0; a < gvStockApplicationList.Rows.Count; a++)
        {
            if ((gvStockApplicationList.Rows[a].FindControl("cbCheck") as CheckBox).Checked)
            {
                ids[a] = Convert.ToInt32(gvStockApplicationList.Rows[a].Cells[1].Text.Trim());
            }
        }
        foreach (int said in ids)
        {
            if (said != 0)
            {
                StockApplicationManager.DeleteById(said);
            }
        }
        BorrowBind(0, "");
    }

    private void BorrowBind(int said , string satime)
    {
        UserInfo user = new UserInfo();
        if (Session["user"] != null)
            user = (UserInfo)Session["user"];
        gvStockApplicationList.DataSourceID = null;
        gvStockApplicationList.DataSource = StockApplicationManager.SearchStockApplication(said, satime, user.UID);
        gvStockApplicationList.DataBind();
    }

    protected void gvStockApplicationList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            int val = StockApplicationManager.DeleteById(Convert.ToInt32(e.CommandArgument));
            if (val != 0)
            {
                this.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功')</script>");
                BorrowBind(0, "");
            }
        }
    }
    protected void gvStockApplicationList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnDel = e.Row.FindControl("lbDel") as LinkButton;
            lnkbtnDel.Attributes.Add("OnClick", "return confirm('确定要删除么?')");
        }
    }
}
