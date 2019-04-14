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
            Style sty = new Style();
            div.Style.Add(HtmlTextWriterStyle.Display, "''");
            Tunnel.Model.Tunnel_SelType model = new Tunnel.Model.Tunnel_SelType();
            Tunnel.BLL.SelType stBll;
            Tunnel.BLL.Tunnel_bum tbBll = new Tunnel.BLL.Tunnel_bum();
            string temp = "项目经理部";
            div.InnerHtml = "<font class='titlfontson'><span><a title='首页' href='/Index.aspx'>首页</a></span>"
                + "<span> &gt; </span>"
                + "<span><a title='" + temp + "-" + tbBll.GetModel(Convert.ToInt32(Request.QueryString["bum_id"])).b_name + "' href='/N_Index/xjb2.aspx?bum_id=" + Request.QueryString["bum_id"] + "'>" + temp + "-" + tbBll.GetModel(Convert.ToInt32(Request.QueryString["bum_id"])).b_name + "</a></span>"
                + "</font>";
            string strsql = "select * from tunnel_newstype where TypeID=" + Request.QueryString["typeid"];
            DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
            if (das.Tables[0].Rows.Count > 0)
            {
                div.InnerHtml += "<span> &gt; </span>"
                    + "<font class='titlefontson'><span>" + das.Tables[0].Rows[0]["TypeName"] + "</span></font>";
            }
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
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //string strsql = "select * from tunnel_xjbtype  where typeid=@typeid and parentid=@parentid";
        //RepeaterItem item = (RepeaterItem)e.Item;
        //SqlDataSource sou = (SqlDataSource)item.FindControl("SqlDataSource2");
        //sou.SelectCommand = strsql;
    }
    public string height(object o)
    {
        return (206 - (Convert.ToInt32(o) * 25)).ToString();
    }
}
