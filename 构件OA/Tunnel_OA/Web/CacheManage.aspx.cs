using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class CacheManage : System.Web.UI.Page
{

    List<CacheItems> cList = new List<CacheItems>();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (ul.LoginID != 1 && "系统管理员" != ul.JiaoSe(ul.LoginID))
        //{
        //    Response.Write("禁止访问!");
        //    Response.End();
        //}
        if (!IsPostBack)
        {
            HyperLink1.NavigateUrl = "cachemanage.aspx";
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                string str = Request["id"].ToString();
                if (str == "all")
                {
                    IDictionaryEnumerator dic = Cache.GetEnumerator();
                    while (dic.MoveNext())
                    {
                        Cache.Remove(dic.Key.ToString());
                    }
                    Bind();
                    Response.Redirect("cachemanage.aspx");
                }
                else
                {
                    Cache.Remove(str);
                    Bind();
                    Response.Redirect("cachemanage.aspx");
                }

            }
            Bind();
        }
    }

    void Bind()
    {
        cList.Clear();
        IDictionaryEnumerator dic = Cache.GetEnumerator();
        while (dic.MoveNext())
        {
            if (dic.Value.GetType().ToString() == "Tunnel.Model.Tunnel_menber")
                cList.Add(new CacheItems(dic.Key.ToString(), dic.Value.GetType().ToString()));
        }
        Label1.Text =string.Format("总在线人数:{0}",cList.Count.ToString());       

        GridView1.DataSource = cList;
        GridView1.DataBind();
    }

    public string ShowName(object o,int i)
    {
        string temp = string.Empty;
        string uid = o.ToString().Split('-')[2].ToString();
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
        tmm = tm.GetModel(Convert.ToInt64(uid));
        if (tmm != null)
        {
            switch (i)
            {
                case 1:
                    temp = tmm.m_login;
                    break;
                case 2:
                    temp = tmm.m_name;
                    break;
                case 3:
                    temp = Tunnel.Data.DESEncrypt.Decrypt(tmm.m_password);
                    break;                
                default:
                    break;
            }
            
        }
        return temp;
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
}
