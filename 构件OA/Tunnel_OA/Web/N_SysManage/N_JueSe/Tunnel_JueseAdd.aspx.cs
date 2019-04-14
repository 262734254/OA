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
using Tunnel.Model;

public partial class SystemManage_Tunnel_JueseAdd : System.Web.UI.Page
{

   public static  Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static Tunnel.Model.Tunnel_jiaose tji = new Tunnel.Model.Tunnel_jiaose();
    public static Tunnel.BLL.Tunnel_yingshe ty = new Tunnel.BLL.Tunnel_yingshe();
    public static Tunnel.Model.Tunnel_yingshe tyy = new Tunnel_yingshe();
    protected void Page_Load(object sender, EventArgs e)
    {
 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        tji.j_name = txtName.Text.Trim();
        tji.j_flag = txtfl.Text;

        if (tj.GetModelList("j_name='" + tji.j_name+"'").Count == 0)
        {
            int i = tj.Add(tji);
            if (i > 0)
            {
                tyy.y_jsid = i;
                ty.Add(tyy);
                Tunnel.Common.Message.Show("保存成功");
            }
        }
        else
        {
            Tunnel.Common.Message.Show("该角色已存在", "tunnel_jueseguanli.aspx");
        }

    }
}
