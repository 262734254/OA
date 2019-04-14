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

public partial class SystemManage_Tunnel_DutyAdd : System.Web.UI.Page
{
    public static Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
    public static Tunnel.Model.Tunnel_duty tdd = new Tunnel.Model.Tunnel_duty();
    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.Model.Tunnel_bum tbb = new Tunnel.Model.Tunnel_bum();
    public static List<Tunnel.Model.Tunnel_bum> blist = new List<Tunnel.Model.Tunnel_bum>();
    public static Tunnel.BLL.Tunnel_dyingshe tdy = new Tunnel.BLL.Tunnel_dyingshe();
    public static Tunnel.Model.Tunnel_dyingshe tdyy = new Tunnel.Model.Tunnel_dyingshe();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dropBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (AddDuty())
        {
            Tunnel.Common.Message.Show("添加成功");
        }
        else
        {
            Tunnel.Common.Message.Show("同机构存在同名");
        }
    }

    public bool AddDuty()
    {
        bool b = true;
        tdd.d_name = txtName.Text.Trim();
        tdd.d_depict = txtName2.Text;
        tdd.d_flag = DropDownList1.SelectedValue;

        if (td.GetModelList("d_name = '"+tdd.d_name+"' and d_flag='"+tdd.d_flag+"'").Count ==0)
        {
           int a = td.Add(tdd);
           tdyy.dy_did = a.ToString();
            tdy.Add(tdyy);
        }
        else
        {
            b = false;
        }
        return b;
        
    }

    public void dropBind()
    {
      blist =  tb.GetModelList("1=1");
      for (int i = 0; i < blist.Count; i++)
      {
          DropDownList1.Items.Add(new ListItem(blist[i].b_name,blist[i].b_id.ToString()));
      }
      DropDownList1.Items.Insert(0, new ListItem("请选择","0"));
    }

}
