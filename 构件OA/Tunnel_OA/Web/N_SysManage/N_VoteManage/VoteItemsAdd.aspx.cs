using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vote_VoteItemsAdd : System.Web.UI.Page
{
    public static int tempId = -1;
    Tunnel.BLL.Tunnel_Votei tvi = new Tunnel.BLL.Tunnel_Votei();
    Tunnel.Model.Tunnel_Votei tvii = new Tunnel.Model.Tunnel_Votei();
    List<Tunnel.Model.Tunnel_Votei> tviList = new List<Tunnel.Model.Tunnel_Votei>();

    public static string voteTitle = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                tempId = Convert.ToInt32(Request.QueryString["id"].ToString());
                Tunnel.BLL.Tunnel_Vote tv = new Tunnel.BLL.Tunnel_Vote();
                voteTitle = tv.GetModel(tempId).vote_Title; 
            }
        }
    }

    public static string GetName(object o)
    {
        string[] temp = null;
        string temp1 = string.Empty;
        if (!string.IsNullOrEmpty(Convert.ToString(o)))
        {
            temp = o.ToString().Split(',');
            foreach (string item in temp)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
                    Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
                    tmm = tm.GetModel(Convert.ToInt64(item.ToString()));
                    temp1 += tmm.m_name + ",";
                }
            }
        }

        return temp1;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewVote.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        tvii = new Tunnel.Model.Tunnel_Votei();
        tvii.ivote_voteId =Convert.ToInt32(tempId);
        tvii.ivote_Title = TextBox1.Text;
        tvii.ivote_Count = 0;
        tvi.Add(tvii);
        TextBox1.Text = "";
        GridView1.DataBind();
    }
}
