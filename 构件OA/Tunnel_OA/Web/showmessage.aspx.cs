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

public partial class showmessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params["mid"]))
            {
                DataSet ds = Tunnel.Data.DbHelperSQL.Query("select * from tunnel_Remind where m_isread=0 and m_id=" + Request.Params["mid"]);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = ds.Tables[0].Rows[0]["m_title"].ToString();
                    url.Value = ds.Tables[0].Rows[0]["m_url"].ToString();
                }
            }
        }
    }
    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        Tunnel.Data.DbHelperSQL.ExecuteSql("update tunnel_Remind set m_isread=1 where m_id=" + Request.Params["mid"]);
        Response.Write("<script>window.close();</script>");
    }
}
