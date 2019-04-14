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
using System.Text;

public partial class SystemManage_Tunnel_FromDesign : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_form tf = new Tunnel.BLL.Tunnel_form();
    Tunnel.Model.Tunnel_form mf = new Tunnel.Model.Tunnel_form();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            mf = tf.GetModel(int.Parse(Request.Params["form_id"]));
            FORM_CONTENT.Value =mf.f_content;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        mf.f_content =FORM_CONTENT.Value;
        mf.f_id = int.Parse(Request.Params["form_id"]);
        tf.Update(mf);
        Tunnel.Common.Message.Show("保存成功!");
        
    }
}
