using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yzap : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = PageBind();
        }
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public string PageBind()
    {
        string htmlSource = string.Empty;
        Tunnel.BLL.Tunnel_Index tbll = new Tunnel.BLL.Tunnel_Index();
        Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
        List<Tunnel.Model.Tunnel_index> txList = tbll.GetModelList("id=(select max(id) from tunnel_index where typeid=42 and del=0)");
        if (txList.Count > 0)
        {
            model = txList[0];
            htmlSource = model.HtmlSource.ToLower();
            if (!string.IsNullOrEmpty(model.Files))
                htmlSource += "<br /><a href='../" + model.Files + "' style='color: blue' >点击下载附件</a>";
            return htmlSource;
        }
        else
        {
            return "暂无一周安排";
        }

    }
}
