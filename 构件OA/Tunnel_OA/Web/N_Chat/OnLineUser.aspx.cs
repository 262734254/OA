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

public partial class N_Chat_OnLineUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSource();
        }
    }

    public void BindSource()
    {
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
        string sid = null==Request.QueryString["uid"] ? "" : Request.QueryString["uid"].ToString().Trim();
        
        if (sid != "")
        {
            sid = sid.Substring(0, sid.Length - 1);
            DataSet ds = tm.GetList(string.Format("m_id in ({0})", sid));
            cbListUser.DataSource = ds;
            cbListUser.DataTextField = "m_name";
            cbListUser.DataValueField = "m_id";
            cbListUser.DataBind();
        }
    }
}
