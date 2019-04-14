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

public partial class N_SysManage_FormDesign_Form_Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params["delid"]))
            {
                string id = Request.Params["delid"];
                Tunnel.BLL.Tunnel_form bf = new Tunnel.BLL.Tunnel_form();
                Tunnel.BLL.Tunnel_formtype btf = new Tunnel.BLL.Tunnel_formtype();
                bf.Delete(int.Parse(Tunnel.Data.DESEncrypt.Decrypt(id)));
                btf.Delete(int.Parse(Tunnel.Data.DESEncrypt.Decrypt(id)));
                Tunnel.Common.Message.ShowAndReLoad("删除成功!", "Tunnel_FromList.aspx?id=" + Request.Params["id"]);
            }
            this.RepeaterBind("");
        }
    }

    void RepeaterBind(string where)
    {
        Tunnel.BLL.Tunnel_form bform = new Tunnel.BLL.Tunnel_form();
        DataSet ds = bform.GetList(where);
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    public string GetClass(string cid)
    {
        if (!string.IsNullOrEmpty(cid))
        {
            return Tunnel.Common.GetValue.getDataValue("Tunnel_flowclass", "fc_name", "fc_id=" + cid);
        }
        else
        {
            return "";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string cid = DropDownList2.SelectedValue;
        string where = "f_lcid=" + cid;
        if (!string.IsNullOrEmpty(TextBox1.Text.Trim()))
            where+= " and f_name like '%" + TextBox1.Text.Trim() + "%'";
        this.RepeaterBind(where);
    }
}
