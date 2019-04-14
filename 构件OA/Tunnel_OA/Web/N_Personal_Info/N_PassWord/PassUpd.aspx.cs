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


public partial class Dachie_UserUpd : System.Web.UI.Page
{
    public static Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    public Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
    public static Tunnel.BLL.Tunnel_uyingshe tu = new Tunnel.BLL.Tunnel_uyingshe();
    public static Tunnel.Model.Tunnel_uyingshe tuu = new Tunnel.Model.Tunnel_uyingshe();
    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static Tunnel.Model.Tunnel_jiaose tjj = new Tunnel_jiaose();
    public static List<Tunnel_bum> blist = new List<Tunnel_bum>();
    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.Model.Tunnel_bum tbb = new Tunnel_bum();
    public static List<Tunnel_duty> dlist = new List<Tunnel_duty>();
    public static Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
    public static Tunnel.Model.Tunnel_duty tdd = new Tunnel_duty();
    public static List<Tunnel_jiaose> jlist = new List<Tunnel_jiaose>();


    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            tmm = tm.GetModel(Convert.ToInt64(ul.LoginID));
            bind();

        }
    }


    public void bind()
    {
        Label1.Text = tm.GetModel(ul.LoginID).m_login;
        if (!string.IsNullOrEmpty(tmm.m_password))
            HiddenField1.Value = Tunnel.Data.DESEncrypt.Decrypt(tmm.m_password);
    }

    public bool Save()
    {
        bool b = false;
        try
        {
            tmm = tm.GetModel(Convert.ToInt64(ul.LoginID));
            tmm.m_id = Convert.ToInt64(ul.LoginID);
            tmm.m_password = Tunnel.Data.DESEncrypt.Encrypt(TextBox3.Text.Trim());
            tm.Update(tmm);
            b = true;
        }
        catch (Exception)
        {
            b = false;
            throw;
        }
        return b;

    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Save())
        {
            Tunnel.Common.Message.Show("更新成功");
        }
        else
        {
            Tunnel.Common.Message.Show("更新失败");
        }
    }
}
