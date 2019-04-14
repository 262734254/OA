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

using BLL.Power;
using Model;

public partial class PowerManager_Role_power : System.Web.UI.Page
{
    RolePowerManager rolePowerManager = new RolePowerManager();


    IList<Power> listPower = null;//保存集合

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
            //显示角色详细
            Role role = rolePowerManager.SelectRoleByRoleId(roleId);
            txtRoleMame.Value = role.RoleName;
            txtRoleDecription.Text = role.Description;

            //获取所有该角色的所有权限
            listPower = rolePowerManager.SelectPowersByRoleId(roleId);

        }
    }


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
}
