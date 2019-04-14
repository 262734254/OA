using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class N_MyWork_N_Star_StarManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageBind();
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                Del(Convert.ToInt32(Request["id"]));
                Response.Redirect("StarManage.aspx");
            }
        }
    }

    public void Del(int d)
    {
        Tunnel.BLL.Tunnel_MingXing tmx = new Tunnel.BLL.Tunnel_MingXing();
        if (File.Exists(Server.MapPath(tmx.GetModel(d).m_img)))
        {
            File.Delete(Server.MapPath(tmx.GetModel(d).m_img));
        }
        tmx.Delete(d);

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            string a = ((TextBox)item.FindControl("TextBox1")).Text;
            if (((CheckBox)item.FindControl("CheckBox1")).Checked)
            {
                Del(Convert.ToInt32(a.ToString()));
            }
        }
        PageBind();
    }
}
