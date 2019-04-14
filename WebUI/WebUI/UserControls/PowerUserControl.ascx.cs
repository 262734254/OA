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
using System.Collections;

public partial class PowerControl : System.Web.UI.UserControl
{
    RolePowerManager rolePowerManager = new RolePowerManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //显示角色权限菜单
            DisplayRoleRightMen();



        }

    }

    protected void DisplayRoleRightMen()
    {
        if (hidParentMenu.Value != "" && hidRoleId.Value != "")
        {
            //得到父节点的Id 即模块Id
            int nodeId = int.Parse(hidParentMenu.Value);

            //根据父节点(模块Id)得到对应的所有子节点信息
            IList<Power> list = rolePowerManager.GetPowerNodeInfoByConditions("", nodeId);


            int roleId = Convert.ToInt32(hidRoleId.Value);
            //根据角色ID和父节点Id获得所拥有的权限
            IList<Power> list2 = rolePowerManager.SelectPowersByRoleId(roleId);

            ArrayList arrRoleChindNodes = new ArrayList();

            foreach (Power p in list2)
            {
                arrRoleChindNodes.Add(p.PowerId.ToString());
            }




            //将子节点循环追加到CheckBoxList控件中
            foreach (Power p in list)
            {
                //实例化一个CheckBoxList控件的集合项
                ListItem item = new ListItem();
                item.Text = p.PowerName;
                item.Value = p.PowerId.ToString();

                //判断权限并选中
                if (arrRoleChindNodes.Contains(item.Value))
                {
                    item.Selected = true;
                }

                //追加到CheckBoxList中
                chklstChildMenu.Items.Add(item);

            }
        }


    }
}
