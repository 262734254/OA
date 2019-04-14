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
using Model;
using BLL.Resource;

public partial class StockApply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucPager.onLoadPageIndexChaning += new _Controls_Pager.MyDele(ucPager_onLoadPageIndexChaning);
        if (!IsPostBack)
        {
            //ApplicationResources.GetItems.Clear();
            UserInfo user = new UserInfo();
            if (Session["user"] != null)
            {
                user = (UserInfo)Session["user"];
                this.txtUser.Text = user.Name; //"单哥！HOW ARE YOU?";
            }
            else
            {
                Response.Redirect("../login.aspx");
                return;
            }
            ucPager_onLoadPageIndexChaning(ucPager.PageIndex);
        }
    }

    void ucPager_onLoadPageIndexChaning(int pageIndex)
    {
        gvSelectedResouce.DataBind();
        PagedDataSource page = new PagedDataSource();
        if (ApplicationResources.GetItems.Count != 0)
        {
            page.DataSource = ApplicationResources.GetItems.Values;
        }
        ucPager.DataCount = page.Count;
        page.AllowPaging = true;
        page.PageSize = 5;
        page.CurrentPageIndex = pageIndex;
        ucPager.PageCount = page.PageCount;
        gvSelectedResouce.DataSourceID = null;
        gvSelectedResouce.DataSource = page;
        gvSelectedResouce.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            UserInfo user = new UserInfo();
            if (Session["user"] != null)
                user = (UserInfo)Session["user"];
            else
            {
                Response.Redirect("../login.aspx");
                return;
            }
            if (ApplicationResources.GetItems.Count == 0)
            {
                this.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('你还没有选择资源！')</script>");
                return;
            }
            else
            {
                StockApplication stock = new StockApplication();
                stock.User.UID = user.UID;
                stock.SATime = this.txtSATime.Value.Trim();
                stock.NeedCharge = Convert.ToDouble(this.txtNeedCharge.Text.Trim());
                stock.SACause = this.txtSACause.Text.Trim();
                stock.SARemark = this.txtMark.Text.Trim();
                stock.IsExamine = "待办";
                //borrow.User.UID = ((UserInfo)Session["user"]).UID/*1*/;
                //borrow.BATime = this.txtBorrowTime.Value.Trim();
                //borrow.BAType = Convert.ToInt32(this.ddlType.SelectedValue);
                //borrow.ExigentGrade = this.txtExigentGrade.Text.Trim();
                //borrow.BARemark = this.txtMark.Text.Trim();
                //borrow.IsExamine = "未审批";
                int id = StockApplicationManager.Add(stock);
                stock.SAID = id;
                Hashtable list = ApplicationResources.GetItems;
                foreach (int str in list.Keys)
                {
                    ApplicationResourseInfo item = (ApplicationResourseInfo)list[str];
                    item.Stock = stock;
                    ApplicationResourceManager.add(item);
                }
                list.Clear();
                Response.Redirect("ApplyStockList.aspx");
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ApplicationResources.GetItems.Clear();
        Response.Redirect("ApplyStockList.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("SelectResource.aspx");
    }
    protected void gvSelectedResource_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = int.Parse((gvSelectedResouce.Rows[e.RowIndex].Cells[0].FindControl("hidId") as HiddenField).Value);
        ApplicationResources.RemoveItem(id);
        ucPager_onLoadPageIndexChaning(ucPager.PageIndex);
    }

   
}
