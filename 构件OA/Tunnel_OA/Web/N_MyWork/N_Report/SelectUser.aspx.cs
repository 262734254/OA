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
using System.Web.UI.MobileControls;

public partial class grzm_SelectUser : System.Web.UI.Page
{
    //public int cuttentPage;

    //private int pageSize = 2;

    private Tunnel.BLL.Tunnel_menber tbll = new Tunnel.BLL.Tunnel_menber();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //PageBind();
            BuMenBind();
        }
    }
    #region 旧方法
    ///// <summary>
    ///// 翻页
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    //{
    //    cuttentPage = MTCPager1.PageIndex;
    //    PageBind();
    //}

    ///// <summary>
    ///// 页面数据绑定
    ///// </summary>
    //public void PageBind()
    //{
    //    PageBase pb = new PageBase();
    //    pb.TblName = "Tunnel_menber";
    //    pb.FldName = "m_id";
    //    pb.ProcedureName = "pagination";
    //    pb.PageSize = pageSize;
    //    if (cuttentPage == 0)
    //        cuttentPage = pb.PageIndex;
    //    pb.PageIndex = cuttentPage;
    //    int count = 0;
    //    List<Tunnel.Model.Tunnel_menber> modelList = new List<Tunnel.Model.Tunnel_menber>();
    //    modelList = tbll.GetList(pb, ref count);//获取分页结果
    //    pb.DoCount = 1;
    //    tbll.GetList(pb, ref count); //获取总条数

    //    //数据绑定
    //    Repeater1.DataSource = modelList;
    //    Repeater1.DataBind();

    //    //数据分页
    //    MTCPager1.PageSize = pageSize;
    //    MTCPager1.RecordCount = count;
    //    MTCPager1.PageIndex = cuttentPage;
    //    if (count <= pb.PageSize)
    //        MTCPager1.Visible = false;
    //    else
    //        MTCPager1.Visible = true;
    //}
    #endregion

    public void BuMenBind()
    {
        Tunnel.BLL.Tunnel_bum bbll = new Tunnel.BLL.Tunnel_bum();
        List<Tunnel.Model.Tunnel_bum> modelList = new List<Tunnel_bum>();
        modelList = bbll.GetModelList("");
        Tunnel.Model.Tunnel_bum model = new Tunnel_bum();
        model.b_id = 0;
        model.b_name = "未分组";
        modelList.Add(model);
        Repeater2.DataSource = modelList;
        Repeater2.DataBind();
    }

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater rptSub = (Repeater)e.Item.FindControl("Repeater3");
        Tunnel.Model.Tunnel_bum model = (e.Item.DataItem as Tunnel.Model.Tunnel_bum);

        Tunnel.BLL.Tunnel_menber userBll = new Tunnel.BLL.Tunnel_menber();
        List<Tunnel.Model.Tunnel_menber> userModelList = new List<Tunnel_menber>();
        if (Convert.ToInt32(model.b_id) == 0 )
            userModelList = userBll.GetModelList(" m_bum = 0 " );
        else
            userModelList = userBll.GetModelList(" m_bum =  " + model.b_id);

        rptSub.DataSource = userModelList;
        rptSub.DataBind();
    }
}
 