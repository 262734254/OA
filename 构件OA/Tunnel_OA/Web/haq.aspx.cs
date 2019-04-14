using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class haq : System.Web.UI.Page
{

    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    protected void Page_Load(object sender, EventArgs e)
    {
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        if (ul.LoginID != 1)
        {
            Response.Write("禁止访问！");
            Response.End();
        }
        if (!IsPostBack)
        {
            Repeater1.DataSource = tm.GetModelList("1=1");
            Repeater1.DataBind();
        }
    }

    public string jm(object o)
    {
        if (!string.IsNullOrEmpty(o.ToString()))
            return Tunnel.Data.DESEncrypt.Decrypt(o.ToString());
        else
            return "空";
    }

    /// <summary>
    /// 修改登录密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        int count = 0;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if ((item.FindControl("CheckBox1") as CheckBox).Checked)
            {
                int userId = Convert.ToInt32((item.FindControl("CheckBox1") as CheckBox).ToolTip);
                Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
                tmm = tm.GetModel(userId);
                tmm.m_password = Tunnel.Data.DESEncrypt.Encrypt(TextBox1.Text.Trim());
                tm.Update(tmm);
                count++;
            }
        }
        Repeater1.DataSource = tm.GetModelList("1=1");
        Repeater1.DataBind();
        Tunnel.Common.Message.Show("成功更改了" + count + "个用户的密码！");
    }
    /// <summary>
    /// 修改审批密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        int count = 0;
        foreach (RepeaterItem item in Repeater1.Items)
        {
            if ((item.FindControl("CheckBox1") as CheckBox).Checked)
            {
                int userId = Convert.ToInt32((item.FindControl("CheckBox1") as CheckBox).ToolTip);
                Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
                tmm = tm.GetModel(userId);
                tmm.m_spassword = Tunnel.Data.DESEncrypt.Encrypt(TextBox2.Text.Trim());
                tm.Update(tmm);
                count++;
            }
        }
        Repeater1.DataSource = tm.GetModelList("1=1");
        Repeater1.DataBind();
        Tunnel.Common.Message.Show("成功更改了" + count + "个用户的审批密码！");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Repeater1.DataSource = tm.GetModelList("m_login like '%" + searchtext.Text.Trim() + "%' or m_name like '%" + searchtext.Text.Trim() + "%'");
        Repeater1.DataBind();
    }
}
