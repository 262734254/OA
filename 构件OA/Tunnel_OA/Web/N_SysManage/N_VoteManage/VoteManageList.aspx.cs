using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tunnel.Model;

public partial class Vote_VoteManageList : System.Web.UI.Page
{
    public int cuttentPage;

    private int pageSize = 28;

    private Tunnel.BLL.Tunnel_Vote tbll = new Tunnel.BLL.Tunnel_Vote();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = 0;
            int top = 0;
            int state = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
            if (!string.IsNullOrEmpty(Request.QueryString["top"]))
            {
                top = Convert.ToInt32(Request.QueryString["top"].ToString());
                Top(id, top);
                Response.Redirect("votemanagelist.aspx");
            }
            if (!string.IsNullOrEmpty(Request.QueryString["state"]))
            {
                state = Convert.ToInt32(Request.QueryString["state"].ToString());
                State(id, state);
                Response.Redirect("votemanagelist.aspx");
            }
            PageBind();
        }
    }

    public void Top(int id, int top)
    {
        Tunnel.Model.Tunnel_Vote tvv = new Tunnel_Vote();
        tvv = tbll.GetModel(id);
        tvv.vote_top = tvv.vote_top == 0 ? 1 : 0;
        tbll.Update(tvv);
    }
    public void State(int id, int state)
    {
        Tunnel.Model.Tunnel_Vote tvv = new Tunnel_Vote();
        tvv = tbll.GetModel(id);
        tvv.vote_state = tvv.vote_state == 0 ? 1 : 0;
        tbll.Update(tvv);
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

    public static string GetBum(object o)
    {
        string temp = "所有用户";
        if (!string.IsNullOrEmpty(Convert.ToString(o)))
        {
            temp = o.ToString().Split('|')[1];
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
            pb.StrWhere = "vote_userId = " + ul.LoginID + "";
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
    public void Del(int id)
    {
        Tunnel.BLL.Tunnel_Vote tv = new Tunnel.BLL.Tunnel_Vote();

        Tunnel.BLL.Tunnel_VoteRe tvr = new Tunnel.BLL.Tunnel_VoteRe();
        List<Tunnel.Model.Tunnel_VoteRe> tvrList = tvr.GetModelList("vate_voteId=" + id + "");
        foreach (Tunnel.Model.Tunnel_VoteRe item in tvrList)
        {
            tvr.Delete(item.vote_Id);
        }
        Tunnel.BLL.Tunnel_Votei tvi = new Tunnel.BLL.Tunnel_Votei();
        List<Tunnel.Model.Tunnel_Votei> tviList = tvi.GetModelList("ivote_voteId=" + id + "");
        foreach (Tunnel.Model.Tunnel_Votei item in tviList)
        {
            tvi.Delete(item.ivote_Id);
        }
        tv.Delete(id);

        Tunnel.BLL.Tunnel_Remind tr = new Tunnel.BLL.Tunnel_Remind();
        Tunnel.Model.Tunnel_Remind trr = new Tunnel.Model.Tunnel_Remind();
        List<Tunnel.Model.Tunnel_Remind> trList = new List<Tunnel.Model.Tunnel_Remind>();
        trList = tr.GetModelList("m_type=4 and m_typeid=" + id + "");
        foreach (Tunnel.Model.Tunnel_Remind item in trList)
        {
            tr.Delete(item.m_typeid);
        }            
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            string a = ((CheckBox)item.FindControl("CheckBox1")).ToolTip.ToString();
            if (((CheckBox)item.FindControl("CheckBox1")).Checked)
            {
                Del(Convert.ToInt32(a.ToString()));
            }
        }
        PageBind();
    }
}
