using System;
using System.Collections.Generic;
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

public partial class RolesUserControl : System.Web.UI.UserControl
{
    RolePowerManager rolePowerManager = new RolePowerManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayRoleMen();
        }

    }

    protected void DisplayRoleMen()
    {
        //得到所有的父节点的信息 
        IList<Role> list = rolePowerManager.SelectAllRoles();
  

        //将子节点循环追加到CheckBoxList控件中
        foreach (Role p in list)
        {
            //实例化一个CheckBoxList控件的集合项
            ListItem item = new ListItem();
            item.Text = p.RoleName;
            item.Value = p.roleId.ToString();

            //追加到CheckBoxList中
            chkRoles.Items.Add(item);

        }
    }


}
