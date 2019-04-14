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
using Tunnel.Model;

public partial class SystemManage_Tunnel_Userinfo : System.Web.UI.Page
{

    public static string uid = string.Empty;
    public static Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    public static Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
    public static Tunnel.BLL.Tunnel_uyingshe tu = new Tunnel.BLL.Tunnel_uyingshe();
    public static Tunnel.Model.Tunnel_uyingshe tuu = new Tunnel.Model.Tunnel_uyingshe();
    Tunnel.BLL.SelType st = new Tunnel.BLL.SelType();
    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static Tunnel.Model.Tunnel_jiaose tjj = new Tunnel_jiaose();
    public static List<Tunnel_bum> blist = new List<Tunnel_bum>();
    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.Model.Tunnel_bum tbb = new Tunnel_bum();
    public static List<Tunnel_duty> dlist = new List<Tunnel_duty>();
    public static Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
    public static Tunnel.Model.Tunnel_duty tdd = new Tunnel_duty();
    public static Tunnel.BLL.Tunnel_xjbType xjbB = new Tunnel.BLL.Tunnel_xjbType();
    public static List<Tunnel_jiaose> jlist = new List<Tunnel_jiaose>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                uid = Request.QueryString["id"].ToString();
                tmm = tm.GetModel(int.Parse(uid));
                bind();
            }
            else {
                Tunnel.Common.Message.Show("非法访问","tunnel_userlist.aspx");
            }
        }
        

    }

    public void bind()
    {        
        txtIdKard.Text = tmm.m_idcard;

        if (tj.GetModelList("j_id="+tmm.m_jiao+"").Count != 0)
        {
            txtjuese.Text = tj.GetModel(Convert.ToInt64(tmm.m_jiao)).j_name;
        }
        if (tb.GetModelList("b_id=" + tmm.m_bum + "").Count != 0)
        {
            txtbumen.Text = tb.GetModel(Convert.ToInt64(tmm.m_bum)).b_name;
        }
        if (td.GetModelList("d_id=" + tmm.m_duty + "").Count != 0)
        {
            txtZhiwu.Text = td.GetModel(Convert.ToInt64(tmm.m_duty)).d_name;
        }
        if (tmm.m_xjb.ToString().Trim()!="")
        {
            List<Tunnel_xjbType> xjbList = xjbB.GetModelList(string.Format("id in ({0})", tmm.m_xjb.Replace("|", ",")));
            foreach (Tunnel.Model.Tunnel_xjbType item in xjbList)
            {
                txtXJB.Text += item.Typename + ",";
            }
            if (txtXJB.Text.Trim() != "")
                txtXJB.Text = txtXJB.Text.Trim().Substring(0, txtXJB.Text.Trim().Length - 1);
        }
        if (tmm.m_KSID.ToString().Trim() != "")
        {
            List<Tunnel_SelType> ksList = st.GetModelList(string.Format("KSID in ({0})", tmm.m_KSID));
            string ks = "";
            foreach (Tunnel_SelType item in ksList)
            {
                if (ks == item.KSID.ToString())
                {
                    continue;
                }
                else
                {
                    lblKS.Text += item.TypeName + ",";
                    ks = item.KSID.ToString();
                }
            }
        }
        txtMail.Text = tmm.m_mail;
        txtName.Text = tmm.m_name;
        txtState.Text = tmm.m_state == 1 ? "锁定" : "开启";
        txtTel.Text = tmm.m_mobile;
        txtUserName.Text = tmm.m_login;
        txtBirth.Text = tmm.m_birth.ToShortDateString() == "1800-1-1" ? "" : tmm.m_birth.ToShortDateString();
        
    }
}
