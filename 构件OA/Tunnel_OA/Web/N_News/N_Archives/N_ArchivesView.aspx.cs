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

public partial class profile_ProfileInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string a = "0";
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                a = Request.QueryString["id"].ToString();
            }
            Tunnel.BLL.Tunnel_Profile pf = new Tunnel.BLL.Tunnel_Profile();
            Tunnel.Model.Tunnel_Profile pff = new Tunnel.Model.Tunnel_Profile();
            pff = pf.GetModel(IsNum(a));
            if(pff!=null)
            {
                Label1.Text = pff.p_name;
                Label2.Text = pff.p_year.ToString();
                Label3.Text = pff.p_bum;
                Label4.Text = pff.p_filetype;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("profilelist.aspx");
    }
    public int IsNum(string num)
    {
        int a = 0;
        try
        {
            a = Convert.ToInt32(num);
        }
        catch (Exception)
        {

        }
        return a;
    }
}
