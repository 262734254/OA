using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Model;
using BLL.Power;


public partial class Default6 : System.Web.UI.Page
{

    RolePowerManager rolePowerManager = new RolePowerManager();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("power.aspx");
    }


    protected void btnAddPower_Click1(object sender, EventArgs e)
    {
        Power power = new Power();
        power.Description = Server.HtmlEncode(txtRemark.Text.Trim());
        power.PowerName =Server.HtmlEncode( txtRoleName.Text.Trim());
        power.prarentId = Convert.ToInt32(ddlTypes.SelectedValue);
        power.URL = txtPageURL.Text.Trim();
        string strName = rolePowerManager.AddPower(power);
        if (Convert.ToInt32(strName) > 0)
        {
            txtRemark.Text = "";
            txtRoleName.Text = "";
            txtPageURL.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加权限成功！');", true);
        }
        else
        {
         
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加权限失败！');", true);

        }

    }
}
