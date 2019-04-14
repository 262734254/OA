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
using System.Collections;
using BLL.Power;
using Model;

public partial class PowerManager_Role_power : System.Web.UI.Page
{
    RolePowerManager rolePowerManager = new RolePowerManager();

    /// <summary>
    /// 页面预初始化
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPreInit(EventArgs e)
    {

        //动态生成显示所有的权限列表  并将该角色所拥有的权限动态勾选
        DisplayRoleRightInfo(roleId);

        base.OnPreInit(e);//对于动态添加的用户控件 在Page_Load之前加载好用户控件 不然找不到控件
    }


    static int roleId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            roleId = 1;
            try
            {

                roleId = int.Parse(Request.QueryString["roleId"].ToString());

            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('没有找到角色编号！');", true);
                return;


            }
            //显示角色详细
            Role role = rolePowerManager.SelectRoleByRoleId(roleId);
            txtRoleMame.Value = role.RoleName;
            txtRoleDecription.Text = role.Description;



        }
    }





    protected void DisplayRoleRightInfo(int roleId)
    {
        //得到所有的父节点的信息 
        IList<Power> list = rolePowerManager.GetPowerNodeInfoByConditions("paranet", 0);


        //根据父节点得到对应子节点，把父节点生成用户控件 然后循环插入到PaleHolder容器中
        foreach (Power power in list)
        {
            //得到父节点Id
            string nodeId = power.PowerId.ToString();

            //得到父节点名称
            string displayName = power.PowerName;


            ///实例化用户控件
            PowerControl powerControl = (PowerControl)LoadControl(@"~/UserControls/PowerUserControl.ascx");

            //找到隐藏控件 存储父节点Id
            HiddenField hidParentMenu = (HiddenField)powerControl.FindControl("hidParentMenu");
            hidParentMenu.Value = nodeId;

            //找到用户控件的checkBox
            CheckBox chkParenMenu = (CheckBox)powerControl.FindControl("chkPararentMenu");
            Label lblModelName = (Label)powerControl.FindControl("lblParentName");
            //显示父菜单的名称
            //chkParenMenu.Text = displayName;
            lblModelName.Text = displayName;
            //保存角色Id
            HiddenField hidRoleId = (HiddenField)powerControl.FindControl("hidRoleId");
            hidRoleId.Value = roleId.ToString();

            //根据角色Id获取其所拥有的权限
            IList<Power> list2 = rolePowerManager.SelectPowersByRoleId(roleId);

            //循环将该角色拥有的父节点添加到角色权限数值
            ArrayList arrRoleParentNodes = new ArrayList();

            foreach (Power p in list2)
            {
                arrRoleParentNodes.Add(p.prarentId);
            }


            //如果权限中存在模块 则选中父节点
            if (arrRoleParentNodes.Contains(nodeId))
            {
                chkParenMenu.Checked = true;
            }


            //把父节点生成的用户控件追加到PlaceHolder容器中
            phRoleDistribute.Controls.Add(powerControl);




        }



    }


    #region MyRegion

    /// <summary>
    /// 判断是否选中权限
    /// </summary>
    private bool ShowCheckBox()
    {
        bool flag = false;

        //遍历checkBox
        foreach (Control ct in form1.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
            {

                CheckBox cb = (CheckBox)ct;
                if (cb.Checked == true)
                {
                    flag = true;
                }
            }
        }
        return flag;
    }


    #endregion
    #region MyRegion

    /// <summary>
    /// 遍历checkbox 如果选中则以字符串形式组合'1,2,4,5'
    /// </summary>
    private string GetCheckBoxStrings()
    {
        //string str = "123,23,13,";
        string str = "";
        //遍历checkBox
        foreach (Control ct in form1.Controls)
        {
            if (ct.GetType().ToString().Equals("System.Web.UI.WebControls.CheckBox"))
            {
                CheckBox cb = (CheckBox)ct;
                if (cb.Checked == true)
                {
                    str += cb.TabIndex + ","; //cb.TabIndex保存编号
                }
            }

        }
        //删除最后一个逗号
        str = str.Substring(0, str.LastIndexOf(',') - 1);
        // Console.WriteLine(str);
        return str;
    }

    #endregion

    protected void lbndeletPower_Click1(object sender, EventArgs e)
    {

        if (!ShowCheckBox())
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请先选择要删除的权限！');", true);
            return;
        }

        string strIds = GetCheckBoxStrings();//获取选中的id字串

        int num = rolePowerManager.DeletePowers(strIds);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除权限成功！');", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除权限失败！');", true);

        }



    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        ForSerrch();



    }

    private void ForSerrch()
    {
         

        int num = 0;

        //删除该角色所有权限
        rolePowerManager.DeletePowersByRoleId(roleId);

        //遍历每个用户控件
        foreach (Control ct in phRoleDistribute.Controls)
        {
         
            HiddenField hidParent = (HiddenField)ct.FindControl("hidParentMenu");

            CheckBoxList chklist = (CheckBoxList)ct.FindControl("chklstChildMenu");
            foreach (ListItem item in chklist.Items)
            {
                if (item.Selected == true)
                {
               
                        num += rolePowerManager.AddRolePower(roleId, Convert.ToInt32(item.Value));
                   
                }

            }


        }

        if (num > 0)
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('授权成功！');location.href='RoleList.aspx'", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('授权失败！');", true);


        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RoleList.aspx");

    }
}
