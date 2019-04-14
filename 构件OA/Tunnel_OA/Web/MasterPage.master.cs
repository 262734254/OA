using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string UserNum;
    public string uid;
    public string userbum;
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public int onLineUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<CacheItems> cList = new List<CacheItems>();
        cList.Clear();
        IDictionaryEnumerator dic = Cache.GetEnumerator();
        while (dic.MoveNext())
        {
            if (dic.Value.GetType().ToString() == "Tunnel.Model.Tunnel_menber")
                cList.Add(new CacheItems(dic.Key.ToString(), dic.Value.GetType().ToString()));
        }
        onLineUser = cList.Count;
        //string aaa=Cache["TunnelLogin-CacheKey-409"].ToString();
        //string strsql = "select count(m_id) as onlineuser from tunnel_menber where m_online = 1";
        //DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        //onLineUser = Convert.ToInt32(das.Tables[0].Rows[0]["onlineuser"]);
        if (!IsPostBack)
        {
            PageBind();
            uid = ul.LoginID.ToString();
            if (ul.LoginID > 0)
            {
                Tunnel.Model.Tunnel_menber model = ul.GetUserBean(ul.LoginID);
                Tunnel.BLL.Tunnel_bum bm = new Tunnel.BLL.Tunnel_bum();
                if (model != null)
                {
                    userbum = model.m_login + " | ";
                }
                if (model != null && model.m_bum > 0)
                {
                    if (bm.GetModel(model.m_bum) != null)
                    {
                        userbum += bm.GetModel(model.m_bum).b_name;
                    }
                }
                else
                {
                    userbum += "部门未分组";
                }
            }
            Label1.ToolTip = userbum;
        }
    }

    public class CacheItems
    {
        public CacheItems(string key, string type)
        {
            this.CacheKey = key;
            this.CacheType = type;
        }

        private string cacheKey = string.Empty;

        public string CacheKey
        {
            get { return cacheKey; }
            set { cacheKey = value; }
        }
        private string cacheType = string.Empty;

        public string CacheType
        {
            get { return cacheType; }
            set { cacheType = value; }
        }

    }

    public void PageBind()
    {
        Tunnel.Model.Tunnel_menber model = GetUserInfo();
        if (model != null)
        {
            // Label1.Text = model.m_login + " [" + model.m_name + "]";
            Label1.Text = model.m_name;
        }
        //else
        //    Response.Write("<script>window.parent.location.href='Default.aspx?ReturnUrl=err'</script>");
    }

    public Tunnel.Model.Tunnel_menber GetUserInfo()
    {
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
        if (ul.LoginID > 0)
            model = ul.GetUserBean(ul.LoginID);
        return model;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        ul.RemoveCache(ul.LoginID);
        Response.Write("<script>window.parent.location.href='Default.aspx'</script>");
        Response.End();
    }
}
