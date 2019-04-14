using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_Calendar_CalendarInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                Tunnel.BLL.Tunnel_workplan tw = new Tunnel.BLL.Tunnel_workplan();
                Tunnel.Model.Tunnel_workplan tww = tw.GetModel(int.Parse(Request.QueryString["id"].ToString()));
                Label1.Text = tww.w_title;
                Label2.Text = tww.w_starttime.ToString();
                Label4.Text = tww.w_content;
                if (tww.w_endtime.ToString() == "1800-01-01 0:00:00")
                {
                    Label3.Text = "不提醒";
                }
                else
                {
                    Label3.Text = tww.w_endtime.ToString();
                }
            }else
                Response.Redirect("Default.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
