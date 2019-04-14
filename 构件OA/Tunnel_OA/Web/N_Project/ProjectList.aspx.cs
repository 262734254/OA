using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class N_Project_View : System.Web.UI.Page
{
    /// <summary>
    /// 序号
    /// </summary>
    public static int i =1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            i = 1;
            this.Bind();
        }
    }

    private void Bind()
    {
        DataSet ds = new DataSet();
        List<Tunnel.Model.Tunnel_bum> ListTbModel = new List<Tunnel.Model.Tunnel_bum>();
        Tunnel.BLL.Tunnel_bum tbBll = new Tunnel.BLL.Tunnel_bum();
        ListTbModel = tbBll.GetModelList("");
        foreach (Tunnel.Model.Tunnel_bum tbModel in ListTbModel)
        {
            if (tbModel.b_projectid != 0)
            {
                Tunnel.Data.AllProJectDataBase allData = new Tunnel.Data.AllProJectDataBase("001");//Convert.ToInt32(tbModel.b_id));
                DataTable dt = new DataTable();
                dt = allData.GetAllTableList("Violation_Menber", "1=1", "order by Vio_Date Desc");
                ds.Tables.Add(dt.Copy());
            }
        }
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource =ds.Tables[0].DefaultView;//设置数据源(DataTable类型)
        pds.AllowPaging = true;
        //每页显示的行数
        //pds.PageSize = 12;
        AspNetPager1.RecordCount = pds.Count;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        if (e.NewPageIndex == 1)
        {
            i = 1;
        }
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        this.Bind();
    }
    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {

    }
}
