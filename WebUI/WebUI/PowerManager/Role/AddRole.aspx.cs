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
        if (!IsPostBack)
        {
            
          
        }
    }

    protected void btnAddNewRole_Click(object sender, EventArgs e)
    {
       
        Role role = new Role();
        role.Description = Server.HtmlEncode(txtDecription.Text.Trim());
        role.RoleName =Server.HtmlEncode(txtRoleName.Text.Trim());
        role.Department.Id = Convert.ToInt32(ddlDepartMent.SelectedValue);
        

        string str = rolePowerManager.AddRole(role);

        if (str.ToLower() == "y")
        {
            txtDecription.Text = "";
            txtRoleName.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色成功！');location.href='RoleList.aspx'", true);

        }
        else if (str.ToLower() == "n")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加角色失败！该部门该角色已经存在');", true);

        }

       
    }

   
}
