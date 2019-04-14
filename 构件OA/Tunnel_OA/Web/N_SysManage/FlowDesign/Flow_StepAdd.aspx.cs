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

public partial class N_SysManage_FlowDesign_Flow_StepAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string num = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_num", "s_lid=" + Request.Params["bid"] + " order by s_num desc");
            int nextnum = 1;
            if (!"".Equals(num))
                TextBox1.Text = (nextnum + int.Parse(num)).ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_step ms = new Tunnel.Model.Tunnel_step();
        Tunnel.BLL.Tunnel_step bs = new Tunnel.BLL.Tunnel_step();
        ms.s_num = Convert.ToInt32(TextBox1.Text);
        ms.s_name = TextBox2.Text.Trim();
        ms.s_depict = TextBox4.Text;
        ms.s_lid = int.Parse(Request.Params["bid"]);
        ms.s_ishui = int.Parse(RadioButtonList1.SelectedValue);
        ms.s_isbak = int.Parse(RadioButtonList3.SelectedValue);
        ms.s_zid = m_value.Value;
        bs.Add(ms);
        Tunnel.Common.Message.Show("保存成功!","Flow_Step.aspx?bid=" + Request.Params["bid"]);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Flow_Step.aspx?bid=" + Request.Params["bid"]);
    }
}
