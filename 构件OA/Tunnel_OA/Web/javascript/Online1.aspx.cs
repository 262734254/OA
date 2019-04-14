using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Collections.Generic;

public partial class javascript_Online : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(getOnline());
        Response.End();
    }
    public string getOnline()
    {
        StringBuilder userlist = new StringBuilder();
        List<CacheItems> cList = new List<CacheItems>();
        cList.Clear();
        IDictionaryEnumerator dic = Cache.GetEnumerator();
        while (dic.MoveNext())
        {
            if (dic.Value.GetType().ToString() == "Tunnel.Model.Tunnel_menber")
            {
                userlist.Append(ShowName(dic.Key, 0) + "," + ShowName(dic.Key, 2)+",");
            }
        }
        return userlist.ToString();
    }

    public string ShowName(object o, int i)
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
                case 0:
                    temp = tmm.m_id.ToString();
                    break;
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