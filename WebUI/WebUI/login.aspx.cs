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
public partial class CarManager_logins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('已登录');window.location='indexs.aspx'</script>");
        }
    }


    /// <summary>
    /// 登录验证
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        UserInfo user = null;
        string message = string.Empty;
        if (UserInfoManager.Login(txtUsername.Text, txtPassword.Text, out user, out message))
        {
            Session["user"] = user;
           
            //保存登录信息
            Response.Cookies["LoginTime"].Value = DateTime.Now.ToString(); 
          
            if (Application["Count"]==null)
            {
                Application["Count"] = "1";
            }
            else
            {
                int count=Convert.ToInt32(Application["Count"]);
                count++;
                Application["Count"] = count.ToString();
            }
            
         
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.location='indexs.aspx'</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", string.Format("<script>alert('{0}')</script>", message), true);
            return;

        }
    }
}
