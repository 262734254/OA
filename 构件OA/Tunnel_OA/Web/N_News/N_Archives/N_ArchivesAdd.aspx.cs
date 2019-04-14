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

public partial class profile_profileAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListBind();
        }
    }

    public void ListBind()
    {
        DropDownList1.Items.Clear();      
        for (int i = -13; i <=-1; i++)
        {
            DropDownList1.Items.Add(new ListItem(DateTime.Now.AddYears(i).Year.ToString(), DateTime.Now.AddYears(i).Year.ToString()));
        }
        DropDownList1.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
        for (int i = 1; i <= 9; i++)
        {
            DropDownList1.Items.Add(new ListItem(DateTime.Now.AddYears(i).Year.ToString(),DateTime.Now.AddYears(i).Year.ToString()));
            
        }
        DropDownList1.Items.FindByValue(DateTime.Now.Year.ToString()).Selected = true;
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tunnel.BLL.Tunnel_Profile pf = new Tunnel.BLL.Tunnel_Profile();
        Tunnel.Model.Tunnel_Profile pff = new Tunnel.Model.Tunnel_Profile();
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        if (pf.GetModelList("p_bum='" + DropDownList2.SelectedValue + "' and p_filetype='" + DropDownList3.SelectedValue + "' and p_name='" + TextBox1.Text + "' and p_year='" + DropDownList1.SelectedValue + "'").Count > 0)
        {
            Tunnel.Common.Message.Show("此文件已经存在，请重新命名！");
        }
        else
        {
            pff.p_bum=DropDownList2.SelectedValue;
            pff.p_filetype=DropDownList3.SelectedValue;
            pff.p_name=TextBox1.Text;
            pff.p_uid=Convert.ToInt32(ul.LoginID);
            pff.p_year=Convert.ToInt32(DropDownList1.SelectedValue);
            if (pf.Add(pff) > 0)
            {
                Tunnel.Common.Message.Show("提交成功！");
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','公司事务>>档案管理>>新增档案。标题：" + pff.p_name + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
            
        }
    }
}
