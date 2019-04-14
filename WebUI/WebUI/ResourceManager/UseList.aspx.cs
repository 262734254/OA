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
using System.Collections.Generic;


public partial class BorrowList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucPager.onLoadPageIndexChaning += new _Controls_Pager.MyDele(ucPager_onLoadPageIndexChaning);
        if (!IsPostBack)
        {
            UserInfo user = new UserInfo();
            if (Session["user"] == null)
            {
                Response.Redirect("../login.aspx");
                return;
            }
            ucPager_onLoadPageIndexChaning(ucPager.PageIndex);
        }
    }

    void ucPager_onLoadPageIndexChaning(int pageIndex)
    {
        PagedDataSource page = new PagedDataSource();
        page.DataSource = ApplicationResourceManager.SearchByResourceNameAndBorrowType(txtName.Text.Trim(), Convert.ToInt32(ddlType.SelectedValue));
        ucPager.DataCount = page.Count;
        page.AllowPaging = true;
        page.PageSize = 10;
        page.CurrentPageIndex = pageIndex;
        ucPager.PageCount = page.PageCount;
        gvUseList.DataSourceID = null;
        gvUseList.DataSource = page;
        gvUseList.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ucPager_onLoadPageIndexChaning(ucPager.PageIndex);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] baids = new int[gvUseList.Rows.Count];
        int[] riids=new int[gvUseList.Rows.Count];
        for (int a = 0; a < gvUseList.Rows.Count; a++)
        {
            if ((gvUseList.Rows[a].FindControl("cbCheck") as CheckBox).Checked)
            {
                baids[a] = Convert.ToInt32((gvUseList.Rows[a].FindControl("lblBAID") as Label).Text.Trim());
                riids[a]=Convert.ToInt32((gvUseList.Rows[a].FindControl("lblRIID") as Label).Text.Trim());
            }
        }
        for (int i = 0; i < baids.Length; i++)
        {
            if (baids[i] != 0 && riids[i] != 0)
            {
                ApplicationResourceManager.Delete(baids[i], 1, riids[i]);
                IList<ApplicationResourseInfo> items = ApplicationResourceManager.GetAllApplicationResource(1, baids[i]);
                if (items.Count == 0 || items == null)
                {
                    BorrowApplicationManager.DeleteById(baids[i]);
                }
            }
        }
        ucPager_onLoadPageIndexChaning(ucPager.PageIndex);
    }
}
