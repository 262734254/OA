using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tunnel.Model;

public partial class Vote_VoteList : System.Web.UI.Page
{

    public int cuttentPage;

    private int pageSize = 20;

    private Tunnel.BLL.Tunnel_Vote tbll = new Tunnel.BLL.Tunnel_Vote();

    public string strWhere = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageBind();
        }
    }


    public static string GetName(object o)
    {
        string temp = "";
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        if (!string.IsNullOrEmpty(Convert.ToString(o)))
        {
            Tunnel.Model.Tunnel_menber tmm = tm.GetModel(Convert.ToInt64(o.ToString()));
            if (tmm != null)
                temp = tmm.m_name;
        }
        return temp;
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
        pb.TblName = "Tunnel_Vote";
        pb.FldName = "vote_Id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        if (ul.LoginID == 1)
            pb.StrWhere = "";
        else
        {
            Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
            Tunnel.Model.Tunnel_menber tmm = new Tunnel_menber();
            tmm = tm.GetModel(Convert.ToInt64(ul.LoginID));
            if (!string.IsNullOrEmpty(Convert.ToString(tmm.m_bum)))
                pb.StrWhere = "(vote_bumGroup like '%" + tmm.m_bum + "%' or vote_bumgroup = '|' or vote_bumgroup ='') and (getdate()>vote_startDate and getdate()<vote_endDate) and vote_state=0";
            else
                pb.StrWhere = "(vote_bumGroup like '%adfadfadfadfadfa%' or vote_bumgroup = '|' or vote_bumgroup ='') and (getdate()>vote_startDate and getdate()<vote_endDate) and vote_state=0";
        }
        int count = 0;
        List<Tunnel.Model.Tunnel_Vote> modelList = new List<Tunnel.Model.Tunnel_Vote>();
        modelList = tbll.GetList(pb, ref count);//获取分页结果
        pb.DoCount = 1;
        tbll.GetList(pb, ref count); //获取总条数

        //数据绑定
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();

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
