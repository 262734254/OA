using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tunnel.Model;
using System.Collections.Generic;

public partial class SystemManage_Tunnel_DutyList : System.Web.UI.Page
{
    public static string did = string.Empty;
    public static Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
    public static Tunnel.Model.Tunnel_duty tdd = new Tunnel.Model.Tunnel_duty();
    public static Tunnel.BLL.Tunnel_dyingshe tdy = new Tunnel.BLL.Tunnel_dyingshe();
    public static Tunnel.Model.Tunnel_dyingshe tdyy = new Tunnel.Model.Tunnel_dyingshe();
    public int cuttentPage;

    private int pageSize = 33;

    private Tunnel.BLL.Tunnel_duty tbll = new Tunnel.BLL.Tunnel_duty();

    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["delid"]))
            {
                did = Request.QueryString["delid"].ToString();
                Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
                td.Delete(Convert.ToInt64(did));
                if (tdy.GetModelList("dy_did='" + did + "'").Count != 0)
                {
                    tdy.Delete(Convert.ToInt32(tdy.GetModelList("dy_did='" + did + "'")[0].dy_id));
                }
                Tunnel.Common.Message.Show("删除成功！", "tunnel_dutylist.aspx");
            }
            PageBind();
        }
    }


    public string retBum(object obj)
    {
        string a = "";
        if (tb.GetModelList("b_id=" + obj.ToString() + "").Count != 0)
        {

            a = tb.GetModel(Convert.ToInt64(obj)).b_name;
        }
        return a;
    }

    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        PageBind();
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_duty";
        pb.FldName = "d_flag";
        pb.OrderType = 1;
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        List<Tunnel.Model.Tunnel_duty> modelList = new List<Tunnel.Model.Tunnel_duty>();
        modelList = tbll.GetList(pb, ref count);//获取分页结果
        pb.DoCount = 1;
        tbll.GetList(pb, ref count); //获取总条数


        //数据绑定
        GridView1.DataSource = modelList;
        GridView1.DataBind();

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }
}
