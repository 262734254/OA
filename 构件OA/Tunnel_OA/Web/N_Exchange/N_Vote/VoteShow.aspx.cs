using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tunnel.Model;

public partial class Vote_VoteShow : System.Web.UI.Page
{
    Tunnel.Model.Tunnel_Vote tvv = new Tunnel.Model.Tunnel_Vote();
    Tunnel.BLL.Tunnel_Vote tv = new Tunnel.BLL.Tunnel_Vote();
    Tunnel.BLL.Tunnel_Votei tvi = new Tunnel.BLL.Tunnel_Votei();
    Tunnel.Model.Tunnel_Votei tvii = new Tunnel.Model.Tunnel_Votei();
    List<Tunnel.Model.Tunnel_Votei> tviiList = new List<Tunnel.Model.Tunnel_Votei>();

    public static float allCount = 0f;

    public int cuttentPage;

    private int pageSize = 20;

    public static string voteTitle = string.Empty;

    public static string voteMark = string.Empty;

    private Tunnel.BLL.Tunnel_VoteRe tbll = new Tunnel.BLL.Tunnel_VoteRe();

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
    static int voteId = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                voteId = Convert.ToInt32(Request.QueryString["id"].ToString());
                Tunnel.BLL.Tunnel_Vote t = new Tunnel.BLL.Tunnel_Vote();
                Tunnel.Model.Tunnel_Vote tt = new Tunnel.Model.Tunnel_Vote();
                Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
                tt = t.GetModel(voteId);
                voteTitle = tt.vote_Title;
                voteMark = tt.vote_mark;
                PageBind();
            }
        }
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

    public static float GetBai(object o, int count)
    {
        if (((Convert.ToSingle(o.ToString()) / allCount) * count).ToString() == "非数字")
            return 0;
        else
            return Convert.ToInt32((Convert.ToSingle(o.ToString()) / allCount) * count);
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        allCount = 0f;

        tvv = tv.GetModel(voteId);
        if (tvv != null)
        {
            tviiList = tvi.GetModelList("ivote_voteId = " + voteId + "");
            if (tviiList.Count > 0)
            {
                foreach (Tunnel.Model.Tunnel_Votei item in tviiList)
                {
                    allCount += Convert.ToInt32(item.ivote_Count.ToString());
                }
                Repeater1.DataSource = tviiList;
                Repeater1.DataBind();
            }
        }


        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_VoteRe";
        pb.FldName = "vote_Id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        pb.StrWhere = "vate_voteId=" + voteId + "";
        pb.OrderName = "vate_Date";
        pb.OrderType = 1;
        int count = 0;
        List<Tunnel.Model.Tunnel_VoteRe> modelList = new List<Tunnel.Model.Tunnel_VoteRe>();
        modelList = tbll.GetList(pb, ref count);//获取分页结果
        pb.DoCount = 1;
        tbll.GetList(pb, ref count); //获取总条数

        //数据绑定
        Repeater2.DataSource = modelList;
        Repeater2.DataBind();

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_VoteRe tvr = new Tunnel_VoteRe();
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        tvr.vate_userId = ul.LoginID;
        tvr.vate_voteId = voteId;
        tvr.vate_Date = DateTime.Now;
        tvr.vote_Message = Server.HtmlEncode(TextBox1.Text);
        if (tbll.Add(tvr) > 0)
        {
            PageBind();
            Tunnel.Common.Message.Show("留言成功");
        }
    }
}
