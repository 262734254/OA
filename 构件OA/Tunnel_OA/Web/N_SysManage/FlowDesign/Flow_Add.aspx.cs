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

public partial class N_SysManage_FlowDesign_Flow_Add : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_bum bt = new Tunnel.BLL.Tunnel_bum();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.dropbind();
        }
    }

    void dropbind()
    {
        DataSet ds = bt.GetList("b_hid=0");
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem list = new ListItem();
                list.Text = dr["b_name"].ToString();
                list.Value = dr["b_id"].ToString();
                DropDownList2.Items.Add(list);
                getsonlist(dr["b_id"].ToString(), "--");
            }
        }
    }
    void getsonlist(string hid, string space)
    {
        DataSet ds = bt.GetList("b_hid=" + hid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ListItem list = new ListItem();
                list.Text = space + dr["b_name"].ToString();
                list.Value = dr["b_id"].ToString();
                DropDownList2.Items.Add(list);
                getsonlist(dr["b_id"].ToString(), space + "----");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_flow mt = new Tunnel.Model.Tunnel_flow();
        Tunnel.BLL.Tunnel_flow bt = new Tunnel.BLL.Tunnel_flow();
        mt.f_sort = int.Parse(DropDownList1.SelectedValue);
        mt.f_name = TextBox1.Text.Trim();
        mt.f_isfile = int.Parse(RadioButtonList1.SelectedValue);
        mt.f_bum = int.Parse(DropDownList2.SelectedValue);
        mt.f_depict = TextBox2.Text.Trim();
        mt.f_form = int.Parse(DropDownList4.SelectedValue);
        mt.f_state = int.Parse(RadioButtonList2.SelectedValue);
        mt.f_stype = 0;// int.Parse(RadioButtonList3.SelectedValue);
        bt.Add(mt);
        Tunnel.Common.Message.ShowAndReLoad("添加成功！", "Tunnel_LiuList.aspx?id=" + mt.f_sort);
    }
}
