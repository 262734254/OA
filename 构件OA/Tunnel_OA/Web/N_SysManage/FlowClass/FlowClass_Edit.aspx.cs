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

public partial class N_SysManage_FlowClass_FlowClass_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.Params["id"]))
                {
                    string id = Request.Params["id"];
                    ShowInfo(int.Parse(Tunnel.Data.DESEncrypt.Decrypt(id)));
                }
            }
            catch {
                Tunnel.Common.Message.back("不正确的ID!");
            }
        }
    }

    private void ShowInfo(int fc_id)
    {
        Tunnel.BLL.Tunnel_flowclass bll = new Tunnel.BLL.Tunnel_flowclass();
        Tunnel.Model.Tunnel_flowclass model = bll.GetModel(fc_id);
        this.TextBox1.Text = model.fc_name;
        this.TextBox2.Text = model.Fc_desin;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_flowclass mf = new Tunnel.Model.Tunnel_flowclass();
        Tunnel.BLL.Tunnel_flowclass bf = new Tunnel.BLL.Tunnel_flowclass();
        mf.fc_id = int.Parse(Tunnel.Data.DESEncrypt.Decrypt(Request.Params["id"]));
        mf.fc_name = TextBox1.Text.Trim();
        mf.Fc_desin = TextBox2.Text;
        bf.Update(mf);
        Tunnel.Common.Message.Show("修改成功!", "FlowClass_Manage.aspx");
    }
}
