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

public partial class Time : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        // 更新数据库中最新时间 每一分钟刷新一次与服务器交互信息 并且与任务时间比较 如果达到了任务执行时间 则播放mp3音乐
        // ScriptManager.RegisterStartupScript(this,this.GetType(),"","window.showModalDialog('Default.aspx');",true);
        Response.Redirect("~/Default7.aspx");
    }
}
