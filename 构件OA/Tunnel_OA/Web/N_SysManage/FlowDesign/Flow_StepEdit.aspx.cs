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

public partial class N_SysManage_FlowDesign_Flow_StepEdit : System.Web.UI.Page
{
    Tunnel.Model.Tunnel_step ms = new Tunnel.Model.Tunnel_step();
    Tunnel.BLL.Tunnel_step bs = new Tunnel.BLL.Tunnel_step();
    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ShowInfo();
        }
    }

    void ShowInfo()
    {
        ms = bs.GetModel(int.Parse(Request.Params["zid"]));
        TextBox1.Text = ms.s_num.ToString();
        TextBox2.Text = ms.s_name;
        TextBox3.Text = UserNameList(ms.s_zid);
        m_value.Value = ms.s_zid;
        TextBox4.Text = ms.s_depict;
        RadioButtonList1.SelectedValue = ms.s_ishui.ToString();
        RadioButtonList3.SelectedValue = ms.s_isbak.ToString();
    }

    protected string UserNameList(string Idlist)
    {
        if (!"".Equals(Idlist))
        {
            Idlist = Idlist.Substring(0, Idlist.Length - 1);
            DataSet ds = tm.GetList("m_id in (" + Idlist + ")");
            string NameList = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    NameList += dr["m_name"] + ",";
                }
            }
            return NameList;
        }
        else
        {
            return "";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ms.s_num = Convert.ToInt32(TextBox1.Text);
        ms.s_name = TextBox2.Text.Trim();
        ms.s_depict = TextBox4.Text;
        ms.s_lid = int.Parse(Request.Params["bid"]);
        ms.s_id = int.Parse(Request.Params["zid"]);
        ms.s_ishui = int.Parse(RadioButtonList1.SelectedValue);
        ms.s_isbak = int.Parse(RadioButtonList3.SelectedValue);
        ms.s_zid = m_value.Value;
        bs.Update(ms);
        Tunnel.Common.Message.Show("修改成功!", "Flow_Step.aspx?bid=" + Request.Params["bid"]);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Flow_Step.aspx?bid=" + Request.Params["bid"]);
    }
}