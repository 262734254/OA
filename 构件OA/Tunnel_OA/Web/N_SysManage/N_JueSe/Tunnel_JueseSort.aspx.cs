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

public partial class N_SysManage_N_JueSe_Tunnel_JueseSort : System.Web.UI.Page
{
    private Tunnel.BLL.Tunnel_jiaose tbll = new Tunnel.BLL.Tunnel_jiaose();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }

    private void BindList()
    {
        DataSet ds = tbll.GetList("1=1 ORDER BY JSSort Desc");
        lbxJS.DataSource = ds;
        lbxJS.DataTextField = "j_name";
        lbxJS.DataValueField = "j_id";
        lbxJS.DataBind();
    }
    
    protected void btnFirst_Click(object sender, EventArgs e)
    {
        int index = lbxJS.SelectedIndex;
        if (index<=0)
        {
            return;
        }
        else
        {
            string value = lbxJS.SelectedValue;
            string text = lbxJS.SelectedItem.Text.Trim();
            lbxJS.Items[index].Text = lbxJS.Items[0].Text;
            lbxJS.Items[index].Value = lbxJS.Items[0].Value;
            lbxJS.Items[0].Text = text;
            lbxJS.Items[0].Value = value;
            lbxJS.Items[index].Selected = false;
            lbxJS.Items[0].Selected = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int index = lbxJS.SelectedIndex;
        if (index <= 0)
        {
            return;
        }
        else
        {
            string value = lbxJS.SelectedValue;
            string text = lbxJS.SelectedItem.Text.Trim();
            lbxJS.Items[index].Text = lbxJS.Items[index-1].Text;
            lbxJS.Items[index].Value = lbxJS.Items[index-1].Value;
            lbxJS.Items[index-1].Text = text;
            lbxJS.Items[index-1].Value = value;
            lbxJS.Items[index].Selected = false;
            lbxJS.Items[index - 1].Selected = true;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        int index = lbxJS.SelectedIndex;
        if (index >= lbxJS.Items.Count || index<0)
        {
            return;
        }
        else
        {
            string value = lbxJS.SelectedValue;
            string text = lbxJS.SelectedItem.Text.Trim();
            lbxJS.Items[index].Text = lbxJS.Items[index + 1].Text;
            lbxJS.Items[index].Value = lbxJS.Items[index + 1].Value;
            lbxJS.Items[index+1].Text = text;
            lbxJS.Items[index+1].Value = value;
            lbxJS.Items[index].Selected = false;
            lbxJS.Items[index + 1].Selected = true;
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        int index = lbxJS.SelectedIndex;
        if (index >= lbxJS.Items.Count || index<0)
        {
            return;
        }
        else
        {
            string value = lbxJS.SelectedValue;
            string text = lbxJS.SelectedItem.Text.Trim();
            lbxJS.Items[index].Text = lbxJS.Items[index].Text;
            lbxJS.Items[index].Value = lbxJS.Items[index].Value;
            lbxJS.Items[lbxJS.Items.Count-1].Text = text;
            lbxJS.Items[lbxJS.Items.Count - 1].Value = value;
            lbxJS.Items[index].Selected = false;
            lbxJS.Items[lbxJS.Items.Count - 1].Selected = true;
        }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int cout = lbxJS.Items.Count;
        for (int i = 0; i < cout; i++)
        {
            if (tbll.UpdateJS(int.Parse(lbxJS.Items[i].Value.Trim()), cout-i)<=0)
            {
                Tunnel.Common.Message.Show("保存失败");
                return;
            }
        }
        Tunnel.Common.Message.Show("保存成功", "tunnel_jueseguanli.aspx");
    }
}
