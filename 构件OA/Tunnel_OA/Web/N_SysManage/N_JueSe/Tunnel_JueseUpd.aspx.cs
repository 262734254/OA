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

public partial class SystemManage_Tunnel_JueseUpd : System.Web.UI.Page
{

    public static string jid = string.Empty;
    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static  Tunnel.Model.Tunnel_jiaose tjj = new Tunnel.Model.Tunnel_jiaose();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["updid"]))
            {
                jid = Request.QueryString["updid"].ToString();
                tjj = tj.GetModel(Convert.ToInt64(jid));
                txtName.Text = tjj.j_name;               
                txtfl.Text = tjj.j_flag;
            }
            else
            {
                Tunnel.Common.Message.Show("非法访问", "tunnel_jueseguanli.aspx");
            }
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        tjj.j_id = Convert.ToInt64(jid);
        tjj.j_name = txtName.Text;        
        tjj.j_flag = txtfl.Text;
        tj.Update(tjj);
        Tunnel.Common.Message.Show("更新成功", "tunnel_jueseguanli.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("tunnel_jueseguanli.aspx");
    }
}
