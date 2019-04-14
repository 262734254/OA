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

public partial class N_SysManage_FormDesign_Form_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.BLL.Tunnel_bum bt = new Tunnel.BLL.Tunnel_bum();
        Tunnel.BLL.Tunnel_form tf = new Tunnel.BLL.Tunnel_form();
        Tunnel.Model.Tunnel_form mf = new Tunnel.Model.Tunnel_form();
        Tunnel.BLL.Tunnel_formtype btf = new Tunnel.BLL.Tunnel_formtype();
        Tunnel.Model.Tunnel_formtype bmf = new Tunnel.Model.Tunnel_formtype();
        mf.f_name = TextBox1.Text.Trim();
        mf.f_lcid = int.Parse(DropDownList2.SelectedValue);
        mf.f_bum = 0;
        mf.f_user = 1;
        mf.f_date = DateTime.Now;
        int i = tf.Name_Add(mf);
        if (i > 0)
        {
            bmf.Form_id = i;
            bmf.Form_name = TextBox1.Text.Trim();
            bmf.Item_max = 0;
            btf.Add(bmf);
            Tunnel.Common.Message.Show("保存成功!");
        }
    }
}
