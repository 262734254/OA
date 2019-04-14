using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_MyWork_N_Report_Index : System.Web.UI.Page
{
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        IfShow();
    }
    public void IfShow()
    {
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核管理", "统计报表", false))
        {
            Response.Redirect("ExamineAdd.aspx");
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核打分", "统计报表", false))
        {
            Response.Redirect("Rate.aspx");
        }
        Response.Redirect("PK_ProjectManager.aspx");
    }
}
