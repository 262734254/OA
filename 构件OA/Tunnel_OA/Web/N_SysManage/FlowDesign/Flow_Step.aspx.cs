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

public partial class N_SysManage_FlowDesign_Flow_Step : System.Web.UI.Page
{
    public int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                string id = Request.Params["id"];
                Tunnel.BLL.Tunnel_step bf = new Tunnel.BLL.Tunnel_step();
                bf.Delete(int.Parse(id));
                Tunnel.Common.Message.Show("删除成功!");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Flow_StepAdd.aspx?bid=" + Request.Params["bid"]);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Flow_Manage.aspx");
    }
}
