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
using System.Collections.Generic;

public partial class SystemManage_Tunnel_DutyUpd : System.Web.UI.Page
{
    public static string did = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                DropBind();
                if (string.IsNullOrEmpty(Request.QueryString["updid"]))
                {
                    Tunnel.Common.Message.Show("非法访问！", "tunnel_dutylist.aspx");
                }
                else
                {
                    did = Request.QueryString["updid"].ToString();
                    Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
                    Tunnel.Model.Tunnel_duty tdd = new Tunnel.Model.Tunnel_duty();
                    tdd = td.GetModel(Convert.ToInt64(did));
                    txtName.Text = tdd.d_name;
                    txtName2.Text = tdd.d_depict;
                    Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
                    if (tb.GetModelList("b_id=" + tdd.d_flag + "").Count > 0)
                    {
                        DropDownList1.Items.FindByValue(tdd.d_flag).Selected = true;
                    }
                }
            }

    }

    public void upd()
    {
        Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
        Tunnel.Model.Tunnel_duty tdd = new Tunnel.Model.Tunnel_duty();
        tdd.d_id =Convert.ToInt64(did);
        tdd.d_name = txtName.Text;
        tdd.d_depict = txtName2.Text;
        tdd.d_flag = DropDownList1.SelectedValue;
        td.Update(tdd);
    }

    public void DropBind()
    {
        Tunnel.BLL.Tunnel_bum td = new Tunnel.BLL.Tunnel_bum();
        List<Tunnel.Model.Tunnel_bum> tdlist = new List<Tunnel.Model.Tunnel_bum>();
        tdlist = td.GetModelList("1=1");
        for (int i = 0; i < tdlist.Count; i++)
        {
            DropDownList1.Items.Add(new ListItem(tdlist[i].b_name, tdlist[i].b_id.ToString()));
        } DropDownList1.Items.Insert(0, new ListItem("请选择","0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        upd();
        Tunnel.Common.Message.Show("修改成功！", "tunnel_dutylist.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("tunnel_dutylist.aspx");
    }
}
