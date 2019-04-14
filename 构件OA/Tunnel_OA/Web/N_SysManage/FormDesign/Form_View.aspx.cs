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

public partial class SystemManage_BaseData_Tunnel_FromView : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_form tf = new Tunnel.BLL.Tunnel_form();
    Tunnel.Model.Tunnel_form mf = new Tunnel.Model.Tunnel_form();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            mf = tf.GetModel(int.Parse(Request.Params["form_id"]));
            if (null != mf)
            {
                Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
                Label1.Text = fc.From_Content(mf.f_content, "", false);
                Page.Title = mf.f_name;
            }
        }
    }
}
