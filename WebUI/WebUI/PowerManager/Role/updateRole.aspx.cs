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
using BLL.Power;
using Model;


public partial class Default7 : System.Web.UI.Page
{
    RolePowerManager rolePowerManager = new RolePowerManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int roleId = 1;
            try
            {

                roleId = int.Parse(Request.QueryString["roleId"].ToString());

            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('没有找到角色编号！');", true);
                return;


            }

            Role role = rolePowerManager.SelectRoleByRoleId(roleId);
            txtRoleName.Text = Server.HtmlDecode(role.RoleName);
            txtRemark.Text = Server.HtmlDecode(role.Description);
            lblRoleId.Text = role.roleId.ToString();
            hidepartId.Value = role.Department.Id.ToString();

        }


    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleList.aspx");
    }
    protected void btnSure_Click(object sender, EventArgs e)
    {
        Role role = new Role();
        role.RoleName = Server.HtmlEncode(txtRoleName.Text.Trim());
        role.Description = Server.HtmlEncode(txtRemark.Text.Trim());
        role.roleId = Convert.ToInt32(lblRoleId.Text.Trim());
        role.Department.Id = Convert.ToInt32(hidepartId.Value);
        string str = rolePowerManager.UpdateRole(role);

        if (str.ToLower() == "y")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新角色成功！');location.href='RoleList.aspx'", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新角色失败！');", true);
            return;
        }
    }
}
