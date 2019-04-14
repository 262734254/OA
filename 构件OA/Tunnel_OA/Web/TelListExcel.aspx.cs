using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class TelListExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        GridViewE.DataSource = tm.GetModelList("1=1");
        GridViewE.DataBind();

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        this.GridViewE.RenderControl(hw);

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        GridViewE.Page.EnableViewState = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"txl.xls");
        Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=UTF8\"><title> adsf</title></head><body><table><tr><td> 帐号</td><td>姓名</td><td>电话</td><td>电子邮件</td></tr>");
        Response.Write(sw.ToString());
        Response.Write("</table></body></html>");
        Response.End();
 

    }
}
