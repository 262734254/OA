using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tunnel.Model;
using System.Xml;
using System.Data;

public partial class N_Index_DataTypeList2 : System.Web.UI.Page
{
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }
    private static int typeId;
    private Tunnel.BLL.Tunnel_InfoXJB mbll = new Tunnel.BLL.Tunnel_InfoXJB();
    public int cuttentPage;
    private int pageSize = 15;
    public string str;
    public int TypeId = 0;
    private int bum_id = 0;
    private int lanmuId = 0;
    private string temp = string.Empty;
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public int sectype = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["typeId"]))
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["lanmuId"]))
            lanmuId = Convert.ToInt32(Request.QueryString["lanmuId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["bum_id"]))
            bum_id = Convert.ToInt32(Request.QueryString["bum_id"]);
        if (!string.IsNullOrEmpty(Request.QueryString["sectype"]))
            sectype = Convert.ToInt32(Request.QueryString["sectype"]);
        WriteSiteMap(typeId);
        TypeId = typeId;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            //ListBind();
            PageBind1();
        }
    }



    /// <summary>
    /// 文章列表 文章浏览 公告栏 新闻栏
    /// </summary>
    /// <param name="num"></param>
    public void WriteSiteMap(int num)
    {
        Master.FindControl("Panel1").Visible = false;
        System.Web.UI.HtmlControls.HtmlGenericControl div = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Panel2");
        string str = div.InnerHtml;
        div.Visible = true;
        //Style sty = new Style();
        div.Style.Add(HtmlTextWriterStyle.Display, "''");
        //Tunnel.Model.Tunnel_SelType model = new Tunnel_SelType();
        //Tunnel.BLL.SelType stBll;
        //Tunnel.BLL.Tunnel_bum tbBll = new Tunnel.BLL.Tunnel_bum();
        //string temp = "";

        //stBll = new Tunnel.BLL.SelType();
        //model = stBll.GetModel(typeId);
        //if (model != null)
        //{
        //    temp = model.TypeName;

        //}
        //div.InnerHtml = "<font class='titlfontson'><span><a title='首页' href='/Index.aspx'>首页</a></span>"
        //    + "<span> &gt; </span>"
        //    + "<span><a title='" + model.BumName + "-" + tbBll.GetModel(bum_id).b_name + "' href='/" + model.Url + "?bum_id=" + bum_id + "'>" + model.BumName + "-" + tbBll.GetModel(bum_id).b_name + "</a></span>"
        //    + "<span> &gt; </span>"
        //    + "<span>" + temp + "</span>"
        //    + "</font>";
        string temp = "";
        if (typeId == 1)
            temp = "生产日志";
        else if (typeId == 2)
            temp = "基地动态";

        Tunnel.Model.Tunnel_xjbType xjbType = new Tunnel.BLL.Tunnel_xjbType().GetModel(bum_id);
        div.InnerHtml = "<font class='titlfontson'><span><a title='首页' href='/Index.aspx'>首页</a></span>"
            + "<span> &gt; </span>"
            + "<span><a title='厂（基地）项经部' href='/N_Index/xjb.aspx?bum_id=" + bum_id + "'>厂（基地）项经部</a></span>"
            + "<span> &gt; </span>"
            + "<span><a title='" + xjbType.Typename.Trim() + "' href='/N_Index/xjb.aspx?bum_id=" + bum_id + "'>" + xjbType.Typename.Trim() + "</a></span>"
            + "<span> &gt; </span>"
            + "<span>" + temp + "</span>"
            + "</font>";
    }
    public void PageBind1()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_InfoXJB";
        pb.FldName = "id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        string where = " typeid =" + typeId + " and sectype=" + sectype;
        string key = "";
        if (where.Length > 0)
        {
            key += " and Title like '%" + TextBox1.Text + "%'";
        }
        else
        {
            key += " 1=1 and Title like '%" + TextBox1.Text + "%'";
        }
        //key += " and bum_bz= " + Request.QueryString["bum_id"].ToString();
        where += key;
        pb.StrWhere = where + " and del=0";
        mbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_InfoXJB> modelList = new List<Tunnel.Model.Tunnel_InfoXJB>();

        mbll.GetList(pb, ref count);//获取分页结果
        modelList = mbll.GetList3(pb, ref count);

        //数据绑定
        Repeater2.DataSource = modelList;
        Repeater2.DataBind();

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }

    public void PageBind2()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_InfoXJB";
        pb.FldName = "id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        string where = " typeid =" + typeId + " and sectype=" + sectype;
        string key = "";
        if (where.Length > 0)
        {
            key += " and Title like '%" + TextBox1.Text + "%'";
        }
        else
        {
            key += " 1=1 and Title like '%" + TextBox1.Text + "%'";
        }
        key += " and bum_bz= " + Request.QueryString["bum_id"].ToString();
        where += key;
        pb.StrWhere = where + " and del=0";

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_InfoXJB> modelList = new List<Tunnel.Model.Tunnel_InfoXJB>();
        modelList = mbll.GetList3(pb, ref count);//获取分页结果


        //数据绑定
        Repeater2.DataSource = modelList;
        Repeater2.DataBind();

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }

    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        //if (typeId > 1)
        //{
        //    PageBind2();
        //}
        //else
        //{
        //    PageBind1();
        //}
        PageBind1();
    }

    public string FormatDate(string str)
    {
        if (!string.IsNullOrEmpty(str))
            str = Convert.ToDateTime(str).ToString("yyyy-MM-dd").ToString();
        return str;
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        //ListBind();
        PageBind1();
    }

    private void ListBind()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["typeId"]))
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        if (sectype == 0)
        {
            PageBind1();
        }
        else
        {
            PageBind2();
            Tunnel.BLL.SelType ts = new Tunnel.BLL.SelType();
            str = ts.GetModel(typeId).TypeName;
        }
    }
}
