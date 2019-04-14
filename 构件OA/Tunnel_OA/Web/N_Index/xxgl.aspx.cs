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
using Tunnel.Model;
using System.Collections.Generic;
using System.Xml;

public partial class N_Index_xxgl : System.Web.UI.Page
{
    private int cuttentPage;
    private int pageSize = 8;
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();

    public Tunnel.BLL.Tunnel_anpai mbll = new Tunnel.BLL.Tunnel_anpai();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //年份从1997至2019
            for (int i = 1997; i <= 2019; i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString();
                li.Value = i.ToString();
                this.DropDownList1.Items.Add(li);
            } DropDownList1.Items.Insert(0, new ListItem("请选择", "请选择"));
            AnpaiBind();
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        //WriteSiteMap();
    }
    /// <summary>
    /// 文章列表 文章浏览 公告栏 新闻栏
    /// </summary>
    /// <param name="num"></param>
    public void WriteSiteMap()
    {
        string redFile = Server.MapPath("../") + "Web.sitemap";
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(redFile);
        XmlNodeList xnl = xdoc.SelectNodes("/");
        XmlNode xnChild = null;
        foreach (XmlNode xn in xnl)
        {

            xnChild = xn.ChildNodes[1].ChildNodes[0].ChildNodes[0];
            xnChild.Attributes[0].Value = "N_Index/xxgl.aspx";
            xnChild.Attributes[1].Value = "信息管理中心";
            xnChild.Attributes[2].Value = "信息管理中心";

        }
        xdoc.Save(redFile);
    }

    public string title(object str)
    {
        return Tunnel.Common.Common.SubStr(str, 36);
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }
    public void AnpaiBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_anpai";
        pb.FldName = "a_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        pb.StrWhere = " a_date between '" + DateTime.Today + "' and '" + DateTime.Today.AddDays(7) + "' ";
        int count = 0;
        pb.DoCount = 1;
        mbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_anpai> modelList = new List<Tunnel.Model.Tunnel_anpai>();
        modelList = mbll.GetList(pb, ref count);//获取分页结果

        //数据绑定
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
    protected void lkb1_Click(object sender, EventArgs e)
    {

    }
    protected void lkb1_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("../N_News/N_Archives/N_ArchivesManage.aspx?id=5&name=" + TextBox1.Text + "&year=" + DropDownList1.SelectedValue + "&bum=" + DropDownList2.SelectedValue + "&type=" + DropDownList3.SelectedValue + "");
    }
    protected void lkb2_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("../N_News/N_Picture/N_PictureManage.aspx?id=6&name=" + TextBox2.Text + "");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../N_News/N_Archives/N_ArchivesManage.aspx?id=5&name=" + TextBox1.Text + "&year=" + DropDownList1.SelectedValue + "&bum=" + DropDownList2.SelectedValue + "&type=" + DropDownList3.SelectedValue + "");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../N_News/N_Picture/N_PictureManage.aspx?id=6&name=" + TextBox2.Text + "");
    }
}
