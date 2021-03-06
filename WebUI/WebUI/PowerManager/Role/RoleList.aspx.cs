﻿using System;
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
using Common;


public partial class Default8 : System.Web.UI.Page
{

    RolePowerManager rolePowerManager = new RolePowerManager();


    protected void Page_Load(object sender, EventArgs e)
    {
        Pager5.onLoadPageIndexChaning += new _Controls_Pager.MyDele(Pager5_onLoadPageIndexChaning);

        if (!IsPostBack)
        {

            Pager5_onLoadPageIndexChaning(Pager5.PageIndex);
        }

    }

    void Pager5_onLoadPageIndexChaning(int pageIndex)
    {

        DatatoBind(pageIndex);
    }

    static int pageCount = 0;//总页数
    static int dataCount = 0;//总记录数
    /// <summary>
    /// 绑定数据
    /// </summary>
    /// <param name="?"></param>
    private void DatatoBind(int pageIndex)
    {

        gvShowData.DataSourceID = null;
        gvShowData.DataSource = rolePowerManager.selectRolesByRoleName(txtRoleName.Text, pageIndex, CommHelper.GetPageCount, "", out pageCount, out dataCount);
        gvShowData.DataBind();
        Pager5.PageCount = pageCount;
        Pager5.DataCount = dataCount;
        Pager5.PageIndex = pageIndex;

    }


    /// <summary>
    /// 判断是否被选择
    /// </summary>
    private bool ShowCheckBox()
    {
        bool flag = false;

        for (int i = 0; i < gvShowData.Rows.Count; i++)
        {
            CheckBox ckBox = gvShowData.Rows[i].Cells[0].FindControl("ckCheck") as CheckBox;
            if (ckBox.Checked == true)
            {
                flag = true;
                break;
            }
        }
        return flag;
    }


    /// <summary>
    /// 遍历checkbox 如果选中则以字符串形式组合'1,2,4,5'
    /// </summary>
    private string GetCheckBoxStrings()
    {

         string str = "";

        for (int i = 0; i < gvShowData.Rows.Count; i++)
        {
            CheckBox ckBox = gvShowData.Rows[i].Cells[0].FindControl("ckCheck") as CheckBox;
            HiddenField hid=  gvShowData.Rows[i].Cells[0].FindControl("hiddenRoleId") as HiddenField;
            
            if (ckBox.Checked == true)
            {
                str += hid.Value + ","; //cb.TabIndex保存编号
            }
        }
   
        //删除最后一个逗号
        str = str.Substring(0, str.LastIndexOf(',') );
        // Console.WriteLine(str);
        return str;
    }




    protected void btnDelte(object sender, EventArgs e)
    {
        if (!ShowCheckBox())
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请先选择要删除的角色！');", true);
            return;
        }
        string strRoleIds = GetCheckBoxStrings();
        string str = rolePowerManager.DeleteRoleByRoleIds(strRoleIds);

        if (str.ToLower() == "y")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色批量删除成功！');location.href='RoleList.aspx'", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('角色批量删除失败！角色下有员工或角色已有权限！');", true);
        }
    }



    protected void btnSelect_Click(object sender, EventArgs e)
    {
        DatatoBind(0);
    }
    protected void gvShowData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int roleId = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "AU")
        {
            Response.Redirect("power.aspx?roleId=" + roleId);
        }
        else if (e.CommandName == "MO")
        {
            Response.Redirect("updateRole.aspx?roleId=" + roleId);
        }
        else if (e.CommandName == "DE")
        {
            string str = rolePowerManager.DeleteRoleByRoleIds(roleId.ToString());
            if (str.ToLower() == "y")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除角色成功！');location.href='RoleList.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除角色失败！角色下有员工！');", true);
            }
        }
    }


}
