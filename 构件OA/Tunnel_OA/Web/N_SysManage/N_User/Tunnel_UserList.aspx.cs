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

public partial class SystemManage_Tunnel_UserList : System.Web.UI.Page
{
    public int BumID = 0;

    public string SearchWhere = string.Empty;
    public string word = string.Empty;

    public int cuttentPage;

    private int pageSize = 28;

    private Tunnel.BLL.Tunnel_menber tbll = new Tunnel.BLL.Tunnel_menber();

    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
    public static Tunnel.BLL.Tunnel_xjbType xjb = new Tunnel.BLL.Tunnel_xjbType();
    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static string uid = string.Empty;
    public static Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    public static Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
    public static Tunnel.BLL.Tunnel_uyingshe tu = new Tunnel.BLL.Tunnel_uyingshe();
    public static Tunnel.Model.Tunnel_uyingshe tuu = new Tunnel.Model.Tunnel_uyingshe();

    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["delid"]))
            {
                uid = Request.QueryString["delid"].ToString();
                if (uid != "1")
                {

                    if (ul.LoginID.ToString() != uid)
                    {
                        if (tm.Exists(Convert.ToInt32(uid)))
                        {
                            tm.Delete(Convert.ToInt64(uid));
                            if (tu.GetModelList("uy_uid='" + uid + "'").Count != 0)
                            {
                                tu.Delete(tu.GetModelList("uy_uid='" + uid + "'")[0].uy_id);
                            }
                            Tunnel.Common.Message.Show("删除成功","tunnel_userlist.aspx");
                        }
                        else
                        {
                            Tunnel.Common.Message.Show("该用户有过重要操作记录！请勿删除！");
                        }
                    }
                    else
                    {
                        Tunnel.Common.Message.Show("不能删除自己！");
                    }
                }
                else
                {
                    Tunnel.Common.Message.Show("不能删除初始管理员");
                }

            }
            //if (ul.LoginID != 1)
            if ("系统管理员" != ul.JiaoSe(ul.LoginID))
            {
                Tunnel.Model.Tunnel_menber tmm = new Tunnel_menber();
                tmm = tbll.GetModel(ul.LoginID);
                if (!string.IsNullOrEmpty(tmm.m_bum.ToString()))
                {
                    BumID = tmm.m_bum;
                }

                TextBox1.Text = word;
                SearchWhere = "  (m_birth like '%" + word + "%' or " +
        "  m_idcard like '%" + word + "%' or " +
        "  m_login like '%" + word + "%' or " +
        "  m_mail like '%" + word + "%' or " +
        "  m_mobile like '%" + word + "%' or " +
        "  m_name like '%" + word + "%') and m_bum = " + BumID + " ";
                PageBind();

            }
            else
            {

                TextBox1.Text = word;
                SearchWhere = "  m_birth like '%" + word + "%' or " +
        "  m_idcard like '%" + word + "%' or " +
        "  m_login like '%" + word + "%' or " +
        "  m_mail like '%" + word + "%' or " +
        "  m_mobile like '%" + word + "%' or " +
        "  m_name like '%" + word + "%'";
                PageBind();

            }
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
        pb.ProcedureName = "pagination1";
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
        GridView1.DataSource = modelList;
        GridView1.DataBind();

        if ("系统管理员" != ul.JiaoSe(ul.LoginID))
        {
            foreach (RepeaterItem item in GridView1.Items)
            {
                item.FindControl("czId").Visible = false;
                item.FindControl("UNczId").Visible = true;
            }
        }
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
        word = TextBox1.Text;
        //if (ul.LoginID != 1)
        if ("系统管理员" != ul.JiaoSe(ul.LoginID))
        {
            SearchWhere = "  (m_birth like '%" + word + "%' or " +
                "  m_idcard like '%" + word + "%' or " +
                "  m_login like '%" + word + "%' or " +
                "  m_mail like '%" + word + "%' or " +
                "  m_mobile like '%" + word + "%' or " +
                "  m_name like '%" + word + "%' ) and m_bum = " + BumID + " ";
        }
        else
        {
            SearchWhere = "  m_birth like '%" + word + "%' or " +
    "  m_idcard like '%" + word + "%' or " +
    "  m_login like '%" + word + "%' or " +
    "  m_mail like '%" + word + "%' or " +
    "  m_mobile like '%" + word + "%' or " +
    "  m_name like '%" + word + "%' ";
        }
        PageBind();
    }
}
