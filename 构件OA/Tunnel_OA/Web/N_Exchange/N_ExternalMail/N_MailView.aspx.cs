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
using System.Collections.Generic;

public partial class N_Exchange_N_ExternalMail_N_MailView : System.Web.UI.Page
{
    private int Id;
    private Tunnel.BLL.Tunnel_report tbll = new Tunnel.BLL.Tunnel_report();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        PageBind();
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        if (Id == 0)
            return;
        Tunnel.Model.Tunnel_report model = new Tunnel.Model.Tunnel_report();
        List<Tunnel.Model.Tunnel_report> modelList = new List<Tunnel.Model.Tunnel_report>();
        model = tbll.GetModel(Id);
        modelList.Add(model);
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
    }

    /// <summary>
    /// 显示用户真实姓名
    /// </summary>
    /// <param name="Id">用户Id</param>
    /// <returns></returns>
    public string ShowUserName(string UserId)
    {
        Tunnel.BLL.Tunnel_menber mbll = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
        model = mbll.GetModel(Convert.ToInt64(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.m_name;
        return strTemp;
    }

}
