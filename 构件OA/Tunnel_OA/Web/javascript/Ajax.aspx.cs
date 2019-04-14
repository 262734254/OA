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

public partial class javascript_Ajax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(Request.Params["UserId"]))
        {
            Response.Write(this.Offline());
            Response.End();
        }
        if (!string.IsNullOrEmpty(Request.Params["spwd"]))
        {
            Response.Write(this.ExitsSpwd(Request.Params["spwd"]));
            Response.End();
        }
        if (!string.IsNullOrEmpty(Request.Params["planId"]))
        {
            Response.Write(this.DelWeekPlan(Request.Params["planId"]));
            Response.End();
        }
    }

    private int Offline()
    {
        Tunnel.Common.GetValue.OffLine(int.Parse(Request.Params["UserID"]));
        return 1;
    }

    private int ExitsSpwd(string spd)
    {
        Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        ul.UsbnLogin = bm.GetModel(ul.LoginID);
        if (ul.UsbnLogin.m_spassword.Equals(Tunnel.Data.DESEncrypt.Encrypt(spd)))
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private int DelWeekPlan(string planid)
    {
        try
        {
            Tunnel.BLL.Tunnel_weekplan bw = new Tunnel.BLL.Tunnel_weekplan();
            bw.Delete(Convert.ToInt32(planid));
            return 1;
        }
        catch
        {
            return 0;
        }
    }
}
