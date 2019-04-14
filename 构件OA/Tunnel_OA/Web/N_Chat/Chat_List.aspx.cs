using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class N_Chat_Chat_List : System.Web.UI.Page
{
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        userid.Value = ul.LoginID.ToString();
        //if (!Page.IsPostBack)
        //{
        //    this.Bind();
        //}
    }
    //public void Bind()
    //{
    //    try
    //    {
    //        Tunnel.BLL.Tunnel_Chat btc = new Tunnel.BLL.Tunnel_Chat();
    //        DataSet ds = btc.GetList("CONVERT(datetime, SUBSTRING(CONVERT(varchar, Chat_Date), 0, 11))='" + DateTime.Now.ToShortDateString() + "' order by Chat_date asc");
    //        DataList1.DataSource = ds;
    //        DataList1.DataBind();
    //    }
    //    catch
    //    {
    //        return;
    //    }
    //}

    ///// <summary>
    ///// 显示对谁说
    ///// </summary>
    ///// <param name="toid"></param>
    ///// <param name="state"></param>
    ///// <returns></returns>
    //public string gettoUser(string toid, string state)
    //{
    //    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    //    ul.UsbnLogin = ul.getUserModel(Convert.ToInt32(toid));
    //    if (state == "1")
    //    {
    //        return "对 <span style='color:green'>" + ul.UsbnLogin.m_name + "</span> ";
    //    }
    //    else if (state == "2")
    //    {
    //        if (ul.LoginID.ToString().Equals(toid))
    //        {
    //            return "对 <span style='color:red'>你</span> 悄悄的";

    //        }
    //        else
    //        {
    //            return "对 <span style='color:red'>" + ul.UsbnLogin.m_name + "</span> 悄悄的";
    //        }
    //    }
    //    else
    //    {
    //        return "";
    //    }
    //}
    ///// <summary>
    ///// 显示悄悄话
    ///// </summary>
    ///// <param name="state">状态</param>
    ///// <param name="uid">发布人</param>
    ///// <param name="toUid">接收人</param>
    ///// <returns></returns>
    //public string GetQiao(string state, string uid, string toUid)
    //{
    //    string style = "";
    //    if ("1".Equals(state))
    //    {
    //        style = "";
    //    }
    //    else if (state == "2")
    //    {
    //        if (ul.LoginID.ToString().Equals(uid) || ul.LoginID.ToString().Equals(toUid))
    //        {
    //            style = "";
    //        }
    //        else
    //        {
    //            style = "display:none";
    //        }
    //    }
    //    else
    //    {
    //        style = "";
    //    }
    //    return style;
    //}

    ///// <summary>
    ///// 显示谁说的
    ///// </summary>
    ///// <param name="username"></param>
    ///// <returns></returns>
    //public string GetuserName(string username, string uid)
    //{
    //    if (ul.LoginID.ToString().Equals(uid))
    //    {
    //        return "<font style=\"color:blue\">你</font>";
    //    }
    //    else
    //    {
    //        return "<font style=\"color:black\">" + username + "</font>";
    //    }
    //}
}
