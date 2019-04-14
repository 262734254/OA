using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MessageList : System.Web.UI.Page
{
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            Tunnel.BLL.Tunnel_Remind tr = new Tunnel.BLL.Tunnel_Remind();
            Repeater5.DataSource = tr.GetList("m_type<>2 and m_type<>3 and m_touser=" + ul.LoginID);
            Repeater5.DataBind();
            Label1.Text = Repeater5.Items.Count.ToString();
        }
    }
}
