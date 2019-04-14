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


public partial class SystemManage_KaoHe_Tunnel_ItemsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IfShow();
    }
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public void IfShow()
    {
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核管理", "统计报表", false))
        {
            xinzengkaohe.Disabled = true;
            xinzengkaohe.HRef = "";
            guanligongcheng.Disabled = true;
            guanligongcheng.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核打分", "统计报表", false))
        {
            kaohedafen.Disabled = true;
            kaohedafen.HRef = "";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tunnel.BLL.Tunnel_items ti = new Tunnel.BLL.Tunnel_items();
        Tunnel.Model.Tunnel_items tii = new Tunnel.Model.Tunnel_items();
        tii.i_name = txtItems.Text.Trim();
        tii.year = TextBox1.Text;
        tii.moon = TextBox2.Text;
         
        if (ti.GetModelList("1=1 and i_name = '"+tii.i_name+"' and year = '"+tii.year+"' and moon = '"+tii.moon+"'").Count==0)
        {
            if (ti.Add(tii) > 0)
                Tunnel.Common.Message.Show("添加工程项目成功！");
            else
                Tunnel.Common.Message.Show("添加工程项目失败！");
        }
        else
        {
            Tunnel.Common.Message.Show("本月存在该项目！");
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExamineAdd.aspx");
    }
}
