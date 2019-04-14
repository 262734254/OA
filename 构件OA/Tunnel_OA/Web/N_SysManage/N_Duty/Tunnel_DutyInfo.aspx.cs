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

public partial class SystemManage_Tunnel_DutyInfo : System.Web.UI.Page
{
    public static string did = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                did = Request.QueryString["id"].ToString();
                Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
                Tunnel.Model.Tunnel_duty tdd = new Tunnel.Model.Tunnel_duty();
                tdd = td.GetModel(Convert.ToInt64(did));
                Label1.Text = tdd.d_name;
                Label2.Text = tdd.d_depict;

                Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
                Tunnel.Model.Tunnel_bum tbb = new Tunnel.Model.Tunnel_bum();
                List<Tunnel.Model.Tunnel_bum> tbList = new List<Tunnel.Model.Tunnel_bum>();
                tbList = tb.GetModelList("b_id=" + tdd.d_flag + "");
                if (tbList.Count > 0)
                {
                    tbb = tbList[0];
                    Label3.Text = tbb.b_name;
                }
            }

        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("tunnel_dutylist.aspx");
    }
}
