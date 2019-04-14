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

public partial class N_SysManage_FlowDesign_Flow_Manage : System.Web.UI.Page
{
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.Params["delid"]))
            {
                string id = Request.Params["delid"];
                Tunnel.BLL.Tunnel_flow bf = new Tunnel.BLL.Tunnel_flow();
                bf.Delete(int.Parse(Tunnel.Data.DESEncrypt.Decrypt(id)));
                Tunnel.Common.Message.Show("删除成功!");
            }
            RepeaterBind("");
        }
    }

    void RepeaterBind(string where)
    {
        Tunnel.BLL.Tunnel_flow bflow = new Tunnel.BLL.Tunnel_flow();
        string bwhere="";
        ul.UsbnLogin = tm.GetModel(ul.LoginID);
        if (ul.JiaoSe(ul.LoginID) != "系统管理员")
        {
            if(string.IsNullOrEmpty(where))
                bwhere = "f_bum=" + ul.UsbnLogin.m_bum;
            else
                bwhere = " and f_bum=" + ul.UsbnLogin.m_bum;
        }
        else
        {
            bwhere = "";
        }
        where += bwhere;
        DataSet ds = bflow.GetList(where);
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
        string where = "f_sort=" + cid;
        if (!string.IsNullOrEmpty(TextBox1.Text.Trim()))
            where += " and f_name like '%" + TextBox1.Text.Trim() + "%'";
        this.RepeaterBind(where);
    }
}
