using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class N_Project_Re_Manage : System.Web.UI.Page
{
   public static int i = 0;
    private readonly Tunnel.BLL.Tunnel_ModelType reportManage = new Tunnel.BLL.Tunnel_ModelType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    private void Bind()
    {
      
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = reportManage.GetAllNode(-1);
        pds.AllowPaging = true;
      
        AspNetPager1.RecordCount = pds.Count;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        rpModelType.DataSource = pds;
        rpModelType.DataBind();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        if (e.NewPageIndex==1)
        {
            i = 0;
        }
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        this.Bind();
    }
    /// <summary>
    /// 根据模板类别和模板名称查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        Bind();
    }
    protected void rpModelType_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //删除操作
        if (e.CommandName=="De")
        {
           
        }
    }
}
