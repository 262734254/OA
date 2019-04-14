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
    Tunnel.BLL.UserLogin userLogin;
    Tunnel.BLL.UserLogin m_UserLogin
    {
        get
        {
            if (null == userLogin)
                userLogin = new Tunnel.BLL.UserLogin();
            return userLogin;
        }
    }

    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }
    private static int typeId;
    private Tunnel.BLL.Tunnel_information mbll = new Tunnel.BLL.Tunnel_information();
    private Tunnel.BLL.Tunnel_Index tunnel_Index = new Tunnel.BLL.Tunnel_Index();
    public int cuttentPage;
    private int pageSize = 5;
    public string str;
    public int TypeId = 0;
    private int lanmuId = 0;
    private string temp = string.Empty;
    private int parentid = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["typeId"]))
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["lanmuId"]))
            lanmuId = Convert.ToInt32(Request.QueryString["lanmuId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["parentid"]))
            parentid = Convert.ToInt32(Request.QueryString["parentid"]);
        WriteSiteMap(typeId);
        TypeId = typeId;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["typeId"]))
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["lanmuId"]))
            lanmuId = Convert.ToInt32(Request.QueryString["lanmuId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["parentid"]))
            parentid = Convert.ToInt32(Request.QueryString["parentid"]);
        WriteSiteMap(typeId);
        TypeId = typeId;

        if (!IsPostBack)
        {
            if (1 < typeId)
            {
                string strsql2 = "select * from tunnel_newstype where IsDel=0 and parentid=" + TypeId;
                if (parentid > 0)
                    strsql2 = "select * from tunnel_newstype where IsDel=0 and parentid=" + parentid;

                DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
                if (das2.Tables[0].Rows.Count > 0)
                {
                    Repeater3.DataSource = das2;
                    Repeater3.DataBind();
                }
            }

            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            ListBind();

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
        Style sty = new Style();
        div.Style.Add(HtmlTextWriterStyle.Display, "''");
        Tunnel.Model.Tunnel_SelType model = new Tunnel_SelType();
        Tunnel.BLL.SelType stBll;
        string temp = "";
        if (typeId < 1)
        {
            switch (typeId)
            {
                case -1:
                    temp = "公司公告";
                    model.BumName = "";
                    break;
                case 0:
                    temp = "公司新闻";
                    model.BumName = "";
                    break;
            }
            div.InnerHtml = "<font class='titlfontson'><span><a title='首页' href='/Index.aspx'>首页</a></span>"
                + "<span> &gt; </span>"
                + "<span>" + temp + "</span>"
                + "</font>";
        }
        else
        {
            stBll = new Tunnel.BLL.SelType();
            model = stBll.GetModel(typeId);
            if (model != null)
            {
                temp = model.TypeName;

            }
            div.InnerHtml = "<font class='titlfontson'><span><a title='首页' href='/Index.aspx'>首页</a></span>"
                + "<span> &gt; </span>"
                + "<span><a title='" + model.BumName + "' href='/" + model.Url + "'>" + model.BumName + "</a></span>"
                + "<span> &gt; </span>"
                + "<span>" + temp + "</span>"
                + "</font>";
        }
    }

    public void PageBind1()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_information";
        pb.FldName = "i_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        string where = " i_sort =" + typeId;
        if (typeId == 0)
            where += " and i_hit=1 ";
        string key = "";
        if (where.Length > 0)
        {
            key += " and i_Title like '%" + TextBox1.Text + "%'";
        }
        else
        {
            key += " 1=1 and i_Title like '%" + TextBox1.Text + "%'";
        }
        where += key;
        pb.StrWhere = where + " and i_del=0";
        mbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
        modelList = mbll.GetList(pb, ref count);//获取分页结果


        //数据绑定
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();

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
        pb.TblName = "Tunnel_Index";
        pb.FldName = "id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        string where = " typeid =" + Convert.ToInt32(Request.QueryString["typeId"]);
        string key = "";
        if (where.Length > 0)
        {
            key += " and Title like '%" + TextBox1.Text + "%'";
        }
        else
        {
            key += " 1=1 and Title like '%" + TextBox1.Text + "%'";
        }
        where += key;
        pb.StrWhere = where + " and del=0 AND IsDel=0";

        List<Tunnel.Model.Tunnel_index> modelList = new List<Tunnel.Model.Tunnel_index>();
        List<Tunnel.Model.Tunnel_index> modelLists = new List<Tunnel.Model.Tunnel_index>();

        mbll.GetList3(pb, ref count); ;//获取分页结果

        pb.DoCount = 0;
        if (pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }

        modelList = mbll.GetList3(pb, ref count);
        //for (int i = 0; i < modelList.Count; i++)
        //{
        //    Tunnel.Model.Tunnel_index mode = (Tunnel.Model.Tunnel_index)(modelList[i]);
        //    if (m_UserLogin.LoginID.ToString().Trim() == mode.UserId.ToString().Trim())
        //    {
        //        modelLists.Add(mode);
        //        continue;
        //    }
        //    if (null != mode.ReadUser && mode.ReadUser != "")
        //    {
        //        string[] str = mode.ReadUser.ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        for (int j = 0; j < str.Length; j++)
        //        {
        //            if (m_UserLogin.LoginID.ToString().Trim() == str[j])
        //            {
        //                modelLists.Add(mode);
        //                break;
        //            }
        //        }
        //    }
        //}

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

        ListBind();
        //if (typeId > 1)
        //{
        //    PageBind2();
        //}
        //else
        //{
        //    PageBind1();
        //}
    }

    public string FormatDate(string str)
    {
        if (!string.IsNullOrEmpty(str))
            str = Convert.ToDateTime(str).ToString("yyyy-MM-dd").ToString();
        return str;
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        ListBind();
    }

    private void ListBind()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["typeId"]))
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        if (typeId > 0)
        {
            PageBind2();
            Tunnel.BLL.SelType ts = new Tunnel.BLL.SelType();
            str = ts.GetModel(typeId).TypeName;
        }
        else
        {
            switch (typeId)
            {
                case 0:
                    str = "新闻列表";
                    typeId = 0;
                    TypeId = 0;
                    break;
                case -1:
                    str = "公告列表";
                    typeId = 1;
                    TypeId = -1;
                    break;
            }
            PageBind1();
        }
    }

    private void PageBind11()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_Index";
        pb.FldName = "id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        string strWhere = string.Format("typeId={0} AND del=0 AND IsDel=0", typeId);
        if (TextBox1.Text.Trim() != "")
            strWhere += string.Format(" AND title='{0}'", TextBox1.Text.Trim());

        pb.StrWhere = strWhere;
        mbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_index> modelList = new List<Tunnel.Model.Tunnel_index>();
        modelList = mbll.GetList3(pb, ref count);//获取分页结果

        //List<Tunnel.Model.Tunnel_index> modelLists = new List<Tunnel.Model.Tunnel_index>();
        //for (int i = 0; i < modelList.Count; i++)
        //{
        //    Tunnel.Model.Tunnel_index mode = (Tunnel.Model.Tunnel_index)(modelList[i]);
        //    if (m_UserLogin.LoginID.ToString().Trim() == mode.UserId.ToString().Trim())
        //    {
        //        modelLists.Add(mode);
        //        continue;
        //    }
        //    if (null != mode.ReadUser && mode.ReadUser != "")
        //    {
        //        string[] str = mode.ReadUser.ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        for (int j = 0; j < str.Length; j++)
        //        {
        //            if (m_UserLogin.LoginID.ToString().Trim() == str[j])
        //            {
        //                modelLists.Add(mode);
        //                break;
        //            }
        //        }
        //    }
        //}
        //count = modelLists.Count;
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
    private void PageBind22()
    {
        string strWhere = string.Format("typeId={0} AND del=0 AND IsDel=0", typeId);
        if (TextBox1.Text.Trim() != "")
            strWhere += string.Format(" AND title='{0}'", TextBox1.Text.Trim());

        DataSet ds = tunnel_Index.GetList(strWhere);
        //DataTable dt = ds.Tables[0].Clone();
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    if (m_UserLogin.LoginID.ToString().Trim() == ds.Tables[0].Rows[i]["userId"].ToString().Trim())
        //    {
        //        dt.Rows.Add(ds.Tables[0].Rows[i].ItemArray);
        //        break;
        //    }
        //    if (null != ds.Tables[0].Rows[i]["readUser"] && ds.Tables[0].Rows[i]["readUser"] != DBNull.Value)
        //    {
        //        string[] str = ds.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        for (int j = 0; j < str.Length; j++)
        //        {
        //            if (m_UserLogin.LoginID.ToString().Trim() == str[j])
        //            {
        //                dt.Rows.Add(ds.Tables[0].Rows[i].ItemArray);
        //                break;
        //            }
        //        }
        //    }
        //}

        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables[0].DefaultView;//设置数据源(DataTable类型)
        pds.AllowPaging = true;
        //每页显示的行数
        //pds.PageSize = 12;
        //AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
        //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.PageSize = AspNetPager1.PageSize;

        Repeater2.DataSource = ds;
        Repeater2.DataBind();
    }

    public string GetLink(object id, int typeid, object title, object userID, object readUser)
    {
        string link = "";
        int len = 0;
        if (title.ToString().Trim().Length > 100)
            len = 100;
        else
            len = title.ToString().Trim().Length;

        if (null==readUser || readUser.ToString().Trim() == "" || (null!=userID && int.Parse(userID.ToString().Trim()) == m_UserLogin.LoginID) || "系统管理员"==m_UserLogin.JiaoSe(m_UserLogin.LoginID))
        {
            link = string.Format("<a href='{0}?id={1}&TypeId={2}' title='{3}'>{4}</a>", "ViewIndex.aspx", id.ToString().Trim(), typeid, title.ToString().Trim(), title.ToString().Trim().Substring(0, len));
        }
        else if (readUser.ToString().Trim() != "")
        {
            bool isFlag = false;
            string[] str = readUser.ToString().Trim().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < str.Length; j++)
            {
                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                {
                    isFlag = true;
                    break;
                }
            }
            if (isFlag)
                link = string.Format("<a href='{0}?id={1}&TypeId={2}' title='{3}'>{4}</a>", "ViewIndex.aspx", id.ToString().Trim(), typeid, title.ToString().Trim(), title.ToString().Trim().Substring(0, len));
            else
                link = string.Format("<a href='#' onclick='return false;' title='{0}'>{1}</a>", title.ToString().Trim(), title.ToString().Trim().Substring(0, len));
        }
        else
            link = string.Format("<a href='#' onclick='return false;' title='{0}'>{1}</a>", title.ToString().Trim(), title.ToString().Trim().Substring(0, len));
        return link;
    }
}
