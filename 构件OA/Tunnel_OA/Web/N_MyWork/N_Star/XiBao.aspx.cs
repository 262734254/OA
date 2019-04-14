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
using System.IO;
using System.Collections.Generic;
public partial class N_MyWork_N_Star_XiBao : System.Web.UI.Page
{
       protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            PageBind();
            
        }
    }

    public void PageBind()
    {
        Tunnel.BLL.Tunnel_MingXing tmx = new Tunnel.BLL.Tunnel_MingXing();
        Tunnel.Model.Tunnel_MingXing tmxx = new Tunnel.Model.Tunnel_MingXing();
        List<Tunnel.Model.Tunnel_MingXing> tmxxList = new List<Tunnel.Model.Tunnel_MingXing>();
        tmxxList = tmx.GetModelList("1=1 order by m_id desc");
        Repeater1.DataSource = tmxxList;
        Repeater1.DataBind();

    }

    public string ShowName(object o)
    {
        string a = string.Empty;
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
        tmm = tm.GetModel(Convert.ToInt64(o.ToString()));
        if (tmm != null)
        {
            a = tmm.m_name;
        }
        return a;
    }
    
}
