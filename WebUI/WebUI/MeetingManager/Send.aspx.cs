using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using BLL.Power;
using Model;
using System.Collections.Generic;
public partial class Send : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
  
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedItem.Text == "请选择")
        {
            return;
        }
        else
        {
            dept.Items.Clear();
            //根据部门ID查询所有员工
            IList<UserInfo> list = UserInfoManager.GetAllUsersByDepartmentId(Convert.ToInt32(ddlDepartment.SelectedValue));

            for (int i = 0; i < list.Count; i++)
            {
              
                UserInfo userInfo = list[i];
                dept.Items.Add(new ListItem(userInfo.Name, userInfo.Name));
                
            }
            dept.DataBind();
        }
    }
}
