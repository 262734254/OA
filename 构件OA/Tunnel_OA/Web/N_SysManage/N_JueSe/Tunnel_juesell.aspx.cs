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

public partial class SystemManage_Tunnel_juesell : System.Web.UI.Page
{
    public static string jid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty( Request.QueryString["id"]))
            {
                jid = Request.QueryString["id"].ToString();
                Tunnel.Model.Tunnel_jiaose tjj = new Tunnel.Model.Tunnel_jiaose();
                Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
                tjj = tj.GetModel(Convert.ToInt64(jid));
                txtName.Text = tjj.j_name;
                txtfl.Text = tjj.j_flag;
            }
            else {
                Tunnel.Common.Message.Show("非法访问", "tunnel_jueseguanli.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("tunnel_jueseguanli.aspx");
    }
}
