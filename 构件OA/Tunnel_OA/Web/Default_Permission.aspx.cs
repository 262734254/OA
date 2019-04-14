using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default_Permission : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_quanxian tq = new Tunnel.BLL.Tunnel_quanxian();
    Tunnel.Model.Tunnel_quanxian tqq = new Tunnel.Model.Tunnel_quanxian();
    List<Tunnel.Model.Tunnel_quanxian> tqList = new List<Tunnel.Model.Tunnel_quanxian>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tqList = tq.GetModelList("1=1");

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string a = string.Empty;
            string b = string.Empty;
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    a += item.Text + "<br />";
                    b += item.Value + "|";
                }
            }

            if (b.Length > 0)
            {
                b = b.Substring(0, b.Length - 1);
                a = a.Substring(0, a.Length - 6);
            }
            string path = MapPath("~/dp.txt");
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            System.IO.File.AppendAllText(path, b);
            
            Tunnel.Common.Message.Show("设置初始权限成功!" + System.IO.File.ReadAllText(path));
        }
        catch (Exception ex)
        {
            Response.Write("错误信息:" + ex.Message);
        }

    }
}
