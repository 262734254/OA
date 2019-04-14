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

public partial class ResourceManager_ApplyStockInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucPager.onLoadPageIndexChaning += new _Controls_Pager.MyDele(ucPager_onLoadPageIndexChaning);
        if (!IsPostBack)
        {
            UserInfo user = new UserInfo();
            if (Session["user"] != null)
            {
                user = (UserInfo)Session["user"];
                this.txtUser.Text = ((UserInfo)Session["user"]).Name; //"单哥！HOW ARE YOU?";
            }
            else
            {
                Response.Redirect("../login.aspx");
                return;
            }
            int id = Convert.ToInt32(this.Request.QueryString["id"]);
            StockApplication stock = StockApplicationManager.Get(id);
            this.txtSAID.Text = stock.SAID.ToString();
            this.txtUser.Text = stock.User.Name;
            this.txtTime.Value = stock.SATime;
            this.txtNeedCharge.Text = stock.NeedCharge.ToString();
            this.txtCause.Text = stock.SACause;
            this.txtMark.Text = stock.SARemark;
            this.txtIsExamine.Text = stock.IsExamine;
            ucPager_onLoadPageIndexChaning(ucPager.PageIndex);
        }
    }

    void ucPager_onLoadPageIndexChaning(int pageIndex)
    {
        PagedDataSource page = new PagedDataSource();
        page.DataSource = ApplicationResourceManager.GetAllApplicationResource(2, Convert.ToInt32(Request.QueryString["id"]));
        ucPager.DataCount = page.Count;
        page.AllowPaging = true;
        page.PageSize = 5;
        page.CurrentPageIndex = pageIndex;
        ucPager.PageCount = page.PageCount;
        gvBorrowResource.DataSourceID = null;
        gvBorrowResource.DataSource = page;
        gvBorrowResource.DataBind();
    }
    protected void btnAuditing_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("Auditing.aspx?type=资源采购 && id={0}", this.Request.QueryString["id"]));
    }
    //protected void btnEdit_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(string.Format("UpdateApplyStock.aspx?id={0}", this.Request.QueryString["id"]));
    //}
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("ApplyStockList.aspx?id={0}", this.Request.QueryString["id"]));
    }
}
