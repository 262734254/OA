using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class TelListExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strsql = "select m_login,m_name,m_mobile,m_mail,m_idcard,"
            + " isnull(c.j_name,'') as m_jiao,"
            + " isnull(b.b_name,'') as m_bum,"
            + " isnull(d.d_name,'') as m_duty,"
            + " m_birth "
            + " from tunnel_menber a"
            + " left join tunnel_bum b on a.m_bum=b.b_id"
            + " left join tunnel_jiaose c on a.m_jiao=c.j_id"
            + " left join Tunnel_duty d on a.m_duty=d.d_id";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        GridViewE.DataSource = das;
        GridViewE.DataBind();

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        this.GridViewE.RenderControl(hw);

        Response.Clear();
        Response.ContentType = "application/vnd.ms-excel";
        Response.Charset = "";
        GridViewE.Page.EnableViewState = true;
        Response.AppendHeader("Content-Disposition", "attachment;filename=\"user.xls");
        Response.Write("<html><head><meta http-equiv=Content-Type content=\"text/html; charset=UTF8\"><title> adsf</title></head><body>");
        Response.Write("<table><tr><td> 帐号</td><td>姓名</td><td>电话</td><td>电子邮件</td><td>身份证号</td><td>角色</td><td>部门</td><td>职务</td><td>生日</td></tr>");
        Response.Write(sw.ToString());
        Response.Write("</table>");
        Response.Write("</body></html>");
        Response.End();
 

    }
}
