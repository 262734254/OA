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

public partial class N_SysManage_FlowDesign_Flow_Edit : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_bum bt = new Tunnel.BLL.Tunnel_bum();
    Tunnel.BLL.Tunnel_form btf = new Tunnel.BLL.Tunnel_form();
    Tunnel.BLL.Tunnel_flowclass tfc = new Tunnel.BLL.Tunnel_flowclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.dropbind();
            this.editbind();
        }
    }

    /// <summary>
    /// 流程修改数据显示
    /// </summary>
    void editbind()
    {
        try
        {
            Tunnel.BLL.Tunnel_flow bf = new Tunnel.BLL.Tunnel_flow();
            Tunnel.Model.Tunnel_flow mf = new Tunnel.Model.Tunnel_flow();
            mf = bf.GetModel(int.Parse(Request.Params["editid"]));
            if (mf.f_sort != 0 && tfc.Exists(mf.f_sort))
                DropDownList1.SelectedValue = mf.f_sort.ToString();
            if (mf.f_bum != 0 && bt.Exists(mf.f_bum))
                DropDownList2.SelectedValue = mf.f_bum.ToString();
            if (mf.f_form != 0 && btf.Exists(mf.f_form))
                DropDownList4.SelectedValue = mf.f_form.ToString();
            TextBox1.Text = mf.f_name;
            TextBox2.Text = mf.f_depict;
            RadioButtonList1.SelectedValue = mf.f_isfile.ToString();
            RadioButtonList2.SelectedValue = mf.f_state.ToString();
            //RadioButtonList3.SelectedValue = mf.f_stype.ToString();
        }
        catch {
            Tunnel.Common.Message.back("不正确的ID!");
        }
    }

    #region 无限级部门分类

    /// <summary>
    /// 调用顶级分类
    /// </summary>
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
    /// <summary>
    /// 调用子类
    /// </summary>
    /// <param name="hid">上级ID</param>
    /// <param name="space">间隔符</param>
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
    #endregion

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
        mt.f_stype = 0;//int.Parse(RadioButtonList3.SelectedValue);
        mt.f_id = int.Parse(Request.Params["editid"]);
        bt.Update(mt);
        Tunnel.Common.Message.Show("修改成功！", "Flow_Manage.aspx");
    }
}
