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
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void gvUserList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        int uId = Convert.ToInt32(e.CommandArgument);
        if (cmd == "Ed")
        {
            Response.Redirect("~/PowerManager/User/UpdateUser.aspx?UID=" + uId);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //IList<UserInfo> list = UserInfoManager.SelectUserInfoByAll();
    }
   
}
