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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tunnel.Model;

public partial class UserSearch_Tunnel_UserSearch : System.Web.UI.Page
{
    public static string SearchWhere = string.Empty;

    public int cuttentPage;

    private int pageSize = 20;

    private Tunnel.BLL.Tunnel_menber tbll = new Tunnel.BLL.Tunnel_menber();
    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
    public static Tunnel.BLL.Tunnel_xjbType xjb = new Tunnel.BLL.Tunnel_xjbType();
    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageBind(); 
        }
    }
    public string rtunMail(string mail)
    {
        return Server.UrlEncode(mail);
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
    public string retDuty(object obj)
    {
        string a = "";
        if (td.GetModelList("d_id=" + obj.ToString() + "").Count != 0)
        {

            a = td.GetModel(Convert.ToInt64(obj)).d_name;
        }
        return a;
    }
    public string retXJB(object obj)
    {
        string a = "";
        if (null != obj && obj.ToString().Trim() != "")
        {
            List<Tunnel_xjbType> xjblist = xjb.GetModelList("id in (" + obj.ToString().Trim().Replace("|", ",") + ")");
            if (null != xjblist && xjblist.Count > 0)
            {
                foreach (Tunnel_xjbType list in xjblist)
                    a += list.Typename + ",";
            }
            if (a.Trim() != "")
                a = a.Trim().Substring(0, a.Trim().Length - 1);
        }
        return a;
    }
    public string retJue(object obj)
    {
        string a = "";
        if (tj.GetModelList("j_id=" + obj.ToString() + "").Count != 0)
        {

            a = tj.GetModel(Convert.ToInt64(obj)).j_name;
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
            pb.TblName = "Tunnel_menber";
            pb.FldName = "m_id";
            pb.ProcedureName = "pagination";
            pb.PageSize = pageSize;
            if (cuttentPage == 0)
                cuttentPage = pb.PageIndex;
            pb.PageIndex = cuttentPage;
            pb.StrWhere = SearchWhere;
            int count = 0;
            List<Tunnel.Model.Tunnel_menber> modelList = new List<Tunnel.Model.Tunnel_menber>();
            modelList = tbll.GetList(pb, ref count);//获取分页结果
            pb.DoCount = 1;
            tbll.GetList(pb, ref count); //获取总条数

            //数据绑定
            GridViewE.DataSource = modelList;
            GridViewE.DataBind();

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
        string word = " ";
        word = TextBox1.Text;
        SearchWhere = "  m_birth like '%" + word + "%' or " +
            "  m_idcard like '%" + word + "%' or " +
            "  m_login like '%" + word + "%' or " +
            "  m_mail like '%" + word + "%' or " +
            "  m_mobile like '%" + word + "%' or " +
            "  m_name like '%" + word + "%' ";
        PageBind();
    }
}
