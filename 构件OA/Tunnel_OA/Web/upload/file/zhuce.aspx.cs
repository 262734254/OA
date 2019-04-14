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

public partial class zhuce : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql = "insert into [user](user_login,user_password,user_name,user_sex,user_tel,user_mail,user_Question,user_ask,user_regtime) values('" + username.Text.Trim() + "','" + password.Text.Trim() + "','" + name.Text.Trim() + "','" + Request.Form["sex"] + "','" + tel.Text.Trim() + "','" + mail.Text.Trim() + "','" + Request.Form["Question"] + "','" + ask.Text.Trim() + "',getDate())";
        int i = dbClass.ExecuteSql(sql);
        if (i > 0) {
            kbFunction.to_url("注册成功!", "index.aspx");
        }
    }
}
