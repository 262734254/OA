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
using Model;
using BLL.Power;

public partial class UserList : System.Web.UI.Page
{
    RolePowerManager rolePowerManager = new RolePowerManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }


   


    /// <summary>
    /// 判断是否被选择
    /// </summary>
    private bool ShowCheckBox()
    {
        bool flag = false;

        for (int i = 0; i < gvUserList.Rows.Count; i++)
        {
            CheckBox ckBox = gvUserList.Rows[i].Cells[0].FindControl("cklish1") as CheckBox;
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

        for (int i = 0; i < gvUserList.Rows.Count; i++)
        {
            CheckBox ckBox = gvUserList.Rows[i].Cells[0].FindControl("cklish1") as CheckBox;
            HiddenField hid = gvUserList.Rows[i].Cells[0].FindControl("hfUId") as HiddenField;

            if (ckBox.Checked == true)
            {
                str += hid.Value + ","; //cb.TabIndex保存编号
            }
        }

     
        return str;
    }



    protected void gvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        int uId = Convert.ToInt32(e.CommandArgument);
        if (cmd == "Ed")
        {
            Response.Redirect("UpdateUser.aspx?UID=" + uId);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //IList<UserInfo> list = UserInfoManager.SelectUserInfoByAll();
    }

    protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)//排除非数据行
        {

            HiddenField hf = e.Row.Cells[0].FindControl("hfUId") as HiddenField;

            DropDownList drop = e.Row.Cells[6].FindControl("dropRole") as DropDownList;

            drop.DataSource = rolePowerManager.SelectAllRolesByUserID(Convert.ToInt32(hf.Value));
            drop.DataTextField = "RoleName";
            drop.DataValueField = "roleId";
            drop.DataBind();
        }


    }

    private string GetPoweIdes()
    {
        string str = "";
        //遍历phholder中的CheckBoxList
        foreach (Control ct in phholder.Controls)
        {
            CheckBoxList cb = (CheckBoxList)ct.FindControl("chkRoles");

                foreach (ListItem item in cb.Items)
                {
                    if (item.Selected == true)
                    {
                        str += item.Value + ","; //cb.TabIndex保存编号
                    }

                }
         
        }

        //删除最后一个逗号
         //str = str.Substring(0, str.LastIndexOf(','));
        // Console.WriteLine(str);
        return str;

    }


    protected void btnDeliver_Click(object sender, EventArgs e)
    {
        if (ShowCheckBox() == true)
        {

            string strUserIds = GetCheckBoxStrings();
            string rolIdes=GetPoweIdes();
            int num=rolePowerManager.GiveUserMananyRolesByUserIds(strUserIds, rolIdes);
            if (num > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('授角色成功！');location.href='UserList.aspx'", true);

            }
            else

            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('授角色失败！');", true);
                return;

            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请选择用户！');", true);
            return;


        }
    }
}
