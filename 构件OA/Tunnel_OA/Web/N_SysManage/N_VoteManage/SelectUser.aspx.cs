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
using System.Web.UI.MobileControls;

public partial class grzm_SelectUser : System.Web.UI.Page
{

    private Tunnel.BLL.Tunnel_menber tbll = new Tunnel.BLL.Tunnel_menber();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BuMenBind();
        }
    }


    public void BuMenBind()
    {
        Tunnel.BLL.Tunnel_bum bbll = new Tunnel.BLL.Tunnel_bum();
        List<Tunnel.Model.Tunnel_bum> modelList = new List<Tunnel_bum>();
        modelList = bbll.GetModelList("");
        Repeater2.DataSource = modelList;
        Repeater2.DataBind();
    }
}
 