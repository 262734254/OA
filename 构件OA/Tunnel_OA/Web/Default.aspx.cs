using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;


public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Response.Write("<script>location.href('http://www.stec-oa.com')</script>");
        if (!Page.IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            {
                StringBuilder errorText = new StringBuilder();
                errorText.Append("<html>");
                errorText.Append("<head><title>提示信息</title>");
                errorText.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"css/error.css\">");
                errorText.Append("<script type=\"text/javascript\" src=\"javascript/errorjs.js\"></script>");
                errorText.Append("<script>window.onload=function(){timer=setTimeout(\"window.location.href='Default.aspx'\", 5); }</script>");
                errorText.Append("</head><body>");
                errorText.Append("<div class='box_border'>");
                errorText.Append("<h1>提示信息</h1>");
                errorText.Append("<p> <font style=\"font-family:'宋体'\">在线时间超时，为了您的账号安全，请重新登录!</font> <br/>");
                errorText.Append("<a href=\"Default.aspx\" >[重新登录]</a> <a href=\"#javascript:close;\" onclick=\"javascript:window.close();\">[关闭窗口]</a></p></div>");
                errorText.Append("</body></html>");
                Response.Write(errorText.ToString());
                Response.End();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string user = username.Value.Trim();
            string pass = password.Value.Trim();

            int userId = 0;
            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
            ul.UserLoginCheck(user, Tunnel.Data.DESEncrypt.Encrypt(pass), Tunnel.Common.Common.GetIp(), ref userId);
            if (userId > 0)
            {
                Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
                Tunnel.Common.GetValue.OnLine(userId);
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Write("<script>alert('账号或密码错误！');location.href='default.aspx';</script>");
                Response.End();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}
