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

    protected void btnAddNewRole_Click(object sender, EventArgs e)
    {

        Role role = new Role();
        role.Description = txtDecription.Text;
        role.RoleName = txtRoleName.Text;

        string str = rolePowerManager.AddRole(role);

        if (str.ToLower() == "yes")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色成功！');", true);

        }
        else if (str.ToLower() == "no")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色失败！');", true);

        }

        Response.Redirect("~/PowerManager/Role/RoleList.aspx");
    }
}
