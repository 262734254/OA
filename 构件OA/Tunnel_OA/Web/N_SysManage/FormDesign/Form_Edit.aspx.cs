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

public partial class N_SysManage_FormDesign_Form_Edit : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_bum bt = new Tunnel.BLL.Tunnel_bum();
    Tunnel.BLL.Tunnel_form bf = new Tunnel.BLL.Tunnel_form();
    Tunnel.Model.Tunnel_form mf = new Tunnel.Model.Tunnel_form();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ShowEdit();
        }
    }

    protected void ShowEdit()
    {
        mf = bf.GetModel(int.Parse(Request.Params["id"]));
        TextBox1.Text = mf.f_name;
        //DropDownList2.SelectedValue = mf.f_lcid.ToString();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        mf.f_bum = 0;
        mf.f_lcid = int.Parse(DropDownList2.SelectedValue);
        mf.f_name = TextBox1.Text.Trim();
        mf.f_id = int.Parse(Request.Params["id"]);
        bf.Update_Name(mf);
        Tunnel.Common.Message.Show("修改成功!","Form_Manage.aspx");
    }
}
