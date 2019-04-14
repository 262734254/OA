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

public partial class N_SysManage_FlowClass_FlowClass_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                string id = Request.Params["id"];
                Tunnel.BLL.Tunnel_flowclass bf = new Tunnel.BLL.Tunnel_flowclass();
                int deid = int.Parse(Tunnel.Data.DESEncrypt.Decrypt(id));
                if (deid == 18)
                {
                    Tunnel.Common.Message.back("公文为系统默认分类,不能删除!");
                }
                else
                {
                    bf.Delete(deid);
                    Tunnel.Common.Message.Show("删除成功!");
                }
            }
        }
    }
}
