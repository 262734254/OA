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

public partial class N_SysManage_FlowClass_FlowClass_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_flowclass mf = new Tunnel.Model.Tunnel_flowclass();
        Tunnel.BLL.Tunnel_flowclass bf = new Tunnel.BLL.Tunnel_flowclass();
        mf.fc_name = TextBox1.Text.Trim();
        mf.Fc_desin = TextBox2.Text;
        if (bf.Add(mf) > 0)
        {
            Tunnel.Common.Message.Show("添加成功!");
        }
    }
}
