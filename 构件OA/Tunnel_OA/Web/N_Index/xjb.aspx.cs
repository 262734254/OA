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
using System.Xml;
using System.Text;

public partial class N_Index_xjb : System.Web.UI.Page
{
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public int Bum = 0;
    public string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["bum_id"]))
            Bum = Convert.ToInt32(Request.QueryString["bum_id"]);
        if (!IsPostBack)
        {
        }
    }
    private void BindMenu(Menu menus, int typeId)
    {

        string strsql = "select * from tunnel_xjbtype where typeid=" + typeId + " and parentid=0";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das != null)
        {
            if (das.Tables.Count > 0)
            {
                foreach (DataRow rows in das.Tables[0].Rows)
                {
                    MenuItem item = new MenuItem();
                    item.Text = "<img src='/image/file1.gif' />&nbsp" + rows["typename"].ToString();
                    item.Value = rows["id"].ToString();
                    item.NavigateUrl = "/N_Index/DataTypeListXJB.aspx?typeId=" + typeId + "&lanmuId=1&bum_id=" + Bum + "&sectype=" + rows["id"].ToString();
                    item = childitems(item, typeId);
                    menus.Items.Add(item);
                }
            }
        }
    }
    private MenuItem childitems(MenuItem item, int typeId)
    {
        string strsql = "select * from tunnel_xjbtype where typeid=" + typeId + " and parentid=" + item.Value;
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das != null)
        {
            if (das.Tables.Count > 0)
            {
                if (das.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in das.Tables[0].Rows)
                    {
                        MenuItem item2 = new MenuItem();
                        item2.Text = "<img src='/image/file1.gif' />&nbsp" + rows["typename"].ToString();
                        item2.Value = rows["id"].ToString();
                        item2.NavigateUrl = "/N_Index/DataTypeListXJB.aspx?typeId=" + typeId + "&lanmuId=1&bum_id=" + Bum + "&sectype=" + rows["id"].ToString();
                        item2 = childitems(item2, typeId);
                        item.ChildItems.Add(item2);
                    }
                }
            }
        }
        return item;
    }
    public string title(object str)
    {
        return Tunnel.Common.Common.SubStr(str, 26);
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        WriteSiteMap();
    }
    /// <summary>
    /// 文章列表 文章浏览 公告栏 新闻栏
    /// </summary>
    /// <param name="num"></param>
    public void WriteSiteMap()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["bum_id"]))
        {
            Master.FindControl("Panel1").Visible = false;
            System.Web.UI.HtmlControls.HtmlGenericControl div = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Panel2");
            string str = div.InnerHtml;
            div.Visible = true;
            //Style sty = new Style();
            div.Style.Add(HtmlTextWriterStyle.Display, "''");
            //Tunnel.Model.Tunnel_SelType model = new Tunnel.Model.Tunnel_SelType();
            //Tunnel.BLL.SelType stBll;
            //Tunnel.BLL.Tunnel_bum tbBll = new Tunnel.BLL.Tunnel_bum();
            //string temp = "项目经理部";
            //div.InnerHtml = "<div id='divxjb' style='float:left;height:100%;' width=''><font class='titlfontson'><a title='首页' href='/Index.aspx'>首页</a>"
            //    + " &gt; "
            //    + "" + temp + "-" + tbBll.GetModel(Convert.ToInt32(Request.QueryString["bum_id"])).b_name + ""
            //    + "</font></div>";
            //string strsql = "select a.* from tunnel_reportmodel a,tunnel_reportmodel b where a.re_id in (b.re_parentid) and a.re_parentid=0 group by a.re_id,a.re_name,a.re_num,a.re_parentid";
            //DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
            //StringBuilder strhtml = new StringBuilder();
            //strhtml.Append("<div id='sondiv' style='padding-top:6px;float:left;height:100%;'>");
            //strhtml.Append("");
            //if (das.Tables[0].Rows.Count > 0)
            //{
            //    foreach (DataRow rows in das.Tables[0].Rows)
            //    {
            //        string strtemp = "&nbsp;&nbsp;<a href='/N_Index/xjbmenu.aspx?bum_id=" + Request.QueryString["bum_id"] + "&re_id=" + rows["re_id"].ToString() + "'>" + rows["re_name"].ToString() + "</a>&nbsp;&nbsp;|";
            //        strhtml.Append(strtemp);
            //        //strhtml.Append("afsdfasdf");
            //    }
            //}
            //strhtml.Append("</div>");
            //Panel3.InnerHtml += strhtml.ToString();


            string bum_id = null == Request.QueryString["bum_id"] ? "" : Request.QueryString["bum_id"].ToString().Trim();
            Tunnel.Model.Tunnel_xjbType xjbType = new Tunnel.BLL.Tunnel_xjbType().GetModel(Convert.ToInt32(Request.QueryString["bum_id"]));
            div.InnerHtml = "<font class='titlfontson'><span><a title='首页' href='/Index.aspx'>首页</a></span>"
                + "<span> &gt; </span>"
                + "<span><a title='厂（基地）项经部' href='/N_Index/xjb.aspx?bum_id=" + bum_id + "'>厂（基地）项经部</a></span>"
                + "<span> &gt; </span>"
                + "<span><a title='" + xjbType.Typename.Trim() + "' href='/N_Index/xjb.aspx?bum_id=" + bum_id + "'>" + xjbType.Typename.Trim() + "</a></span>"
                + "</font>";

        }
    }

    public string shownew(object o)
    {
        if (o != null)
        {
            string date = o.ToString().Split(' ')[0].ToString();
            if (Tunnel.BLL.Systemtime.GetThisWeekDate().Contains(date))
            {
                return "<sup>new!</sup>";
            }
            else
            {
                return " ";
            }
        }
        return " ";
    }
}
