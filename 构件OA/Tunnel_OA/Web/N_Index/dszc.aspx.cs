using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using Tunnel.BLL;

public partial class N_Index_dszc : System.Web.UI.Page
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
    private Tunnel.BLL.Tunnel_Index indexBLL;
    private Tunnel.BLL.Tunnel_Index m_IndexBLL
    {
        get
        {
            if (null == indexBLL)
                indexBLL = new Tunnel_Index();
            return indexBLL;
        }
    }
    private Tunnel.BLL.Tunnel_InfoType infoTypeBLL;
    private Tunnel.BLL.Tunnel_InfoType m_InfoType
    {
        get
        {
            if (null == infoTypeBLL)
                infoTypeBLL = new Tunnel_InfoType();
            return infoTypeBLL;
        }
    }

    Tunnel.BLL.SelType st = new Tunnel.BLL.SelType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadSource();

        }
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        //WriteSiteMap();
        PageBind();
    }

    private void PageBind()
    {
        Bindsysgz();
        Bindgcxx();
        Bindksdt();
        Bindgbgz();
        Bindjldt();
        Bindglgl();
        aqgl();
        BindHT();
        BindSG();
    }
    /// <summary>
    /// 实验室工作
    /// </summary>
    private void Bindsysgz()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=14";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater8.DataSource = das;
            Repeater8.DataBind();
            Repeater8.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=14 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater3.DataSource = das2;
            Repeater3.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=14 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater3.DataSource = das2;
            Repeater3.DataBind();
            Repeater3.Visible = true;
            Repeater8.Visible = false;
        }
    }
    private int gettop(int i)
    {
        if (i >= 0)
            return i;
        else
            return i;
    }
    /// <summary>
    /// 工程信息
    /// </summary>
    private void Bindgcxx()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=13";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater9.DataSource = das;
            Repeater9.DataBind();
            Repeater9.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=13 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater2.DataSource = das2;
            Repeater2.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=13 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater2.DataSource = das2;
            Repeater2.DataBind();
            Repeater2.Visible = true;
            Repeater9.Visible = false;
        }
    }
    /// <summary>
    /// 科室动态
    /// </summary>
    private void Bindksdt()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=12";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater10.DataSource = das;
            Repeater10.DataBind();
            Repeater10.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=12 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater1.DataSource = das2;
            Repeater1.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=12 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater1.DataSource = das2;
            Repeater1.DataBind();
            Repeater1.Visible = true;
            Repeater10.Visible = false;
        }
    }
    /// <summary>
    /// 贯标工作
    /// </summary>
    private void Bindgbgz()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=15";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater11.DataSource = das;
            Repeater11.DataBind();
            Repeater11.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=15 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater4.DataSource = das2;
            Repeater4.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=15  and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater4.DataSource = das2;
            Repeater4.DataBind();
            Repeater4.Visible = true;
            Repeater11.Visible = false;
        }
    }
    /// <summary>
    /// 计量动态
    /// </summary>
    private void Bindjldt()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=16";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater12.DataSource = das;
            Repeater12.DataBind();
            Repeater12.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=16 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater5.DataSource = das2;
            Repeater5.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=16 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater5.DataSource = das2;
            Repeater5.DataBind();
            Repeater5.Visible = true;
            Repeater12.Visible = false;
        }
    }
    /// <summary>
    /// 质量管理
    /// </summary>
    private void Bindglgl()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=17";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater13.DataSource = das;
            Repeater13.DataBind();
            Repeater13.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=17 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater6.DataSource = das2;
            Repeater6.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=17 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater6.DataSource = das2;
            Repeater6.DataBind();
            Repeater6.Visible = true;
            Repeater13.Visible = false;
        }
    }
    /// <summary>
    /// 安全管理
    /// </summary>
    private void aqgl()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=18";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater14.DataSource = das;
            Repeater14.DataBind();
            Repeater14.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=18 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater7.DataSource = das2;
            Repeater7.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=18 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater7.DataSource = das2;
            Repeater7.DataBind();
            Repeater7.Visible = true;
            Repeater14.Visible = false;
        }
    }

    /// <summary>
    /// 合同管理
    /// </summary>
    private void BindHT()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=154";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater15.DataSource = das;
            Repeater15.DataBind();
            Repeater15.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=154 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater16.DataSource = das2;
            Repeater16.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=154 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater16.DataSource = das2;
            Repeater16.DataBind();
            Repeater16.Visible = true;
            Repeater15.Visible = false;
        }
    }

    /// <summary>
    /// 安全施工
    /// </summary>
    private void BindSG()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=153";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            rptSGH.DataSource = das;
            rptSGH.DataBind();
            rptSGH.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=153 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            rptSGI.DataSource = das2;
            rptSGI.DataBind();
        }
        else
        {
            string strsql2 = "select * from tunnel_index where typeid=153 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            rptSGI.DataSource = das2;
            rptSGI.DataBind();
            rptSGI.Visible = true;
            rptSGH.Visible = false;
        }
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
            xnChild.Attributes[0].Value = "N_Index/dszc.aspx";
            xnChild.Attributes[1].Value = "鼎順咨询";
            xnChild.Attributes[2].Value = "鼎順咨询";

        }
        xdoc.Save(redFile);
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

    //private void LoadSource()
    //{
    //    int count = 0;

    //    DataSet ds1 = m_IndexBLL.GetList("[typeId]=12 and del=0 ORDER BY [setDate] DESC");
    //    DataTable dt1 = ds1.Tables[0].Clone();
    //    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
    //    {
    //        if (count >= 8)
    //            break;

    //        if (m_UserLogin.LoginID.ToString().Trim() == ds1.Tables[0].Rows[i]["userId"].ToString().Trim())
    //        {
    //            dt1.Rows.Add(ds1.Tables[0].Rows[i].ItemArray);
    //            count++;
    //            continue;
    //        }
    //        if (null != ds1.Tables[0].Rows[i]["readUser"] && ds1.Tables[0].Rows[i]["readUser"] != DBNull.Value)
    //        {
    //            string[] str = ds1.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //            for (int j = 0; j < str.Length; j++)
    //            {
    //                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
    //                {
    //                    dt1.Rows.Add(ds1.Tables[0].Rows[i].ItemArray);
    //                    count++;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    Repeater1.DataSource = dt1;
    //    Repeater1.DataBind();

    //    count = 0;
    //    DataSet ds2 = m_IndexBLL.GetList("[typeId]=13 and del=0 ORDER BY [setDate] DESC");
    //    DataTable dt2 = ds2.Tables[0].Clone();
    //    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
    //    {
    //        if (count >= 8)
    //            break;
    //        if (m_UserLogin.LoginID.ToString().Trim() == ds2.Tables[0].Rows[i]["userId"].ToString().Trim())
    //        {
    //            dt2.Rows.Add(ds2.Tables[0].Rows[i].ItemArray);
    //            count++;
    //            continue;
    //        }
    //        if (null != ds2.Tables[0].Rows[i]["readUser"] && ds2.Tables[0].Rows[i]["readUser"] != DBNull.Value)
    //        {
    //            string[] str = ds2.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //            for (int j = 0; j < str.Length; j++)
    //            {
    //                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
    //                {
    //                    dt2.Rows.Add(ds2.Tables[0].Rows[i].ItemArray);
    //                    count++;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    Repeater2.DataSource = dt2;
    //    Repeater2.DataBind();

    //    List<Tunnel.Model.Tunnel_SelType> listSH1 = st.GetModelList("ParentID=14");
    //    if (listSH1.Count > 0)
    //    {
    //        dgdYSHead.DataSource = listSH1;
    //        dgdYSHead.DataBind();
    //    }
    //    //DataSet dsa = m_IndexBLL.GetList("[typeId]=44 and [del]=0 ORDER BY [setDate] DESC");
    //    //dgdYSHead.DataSource = dsa;
    //    //dgdYSHead.DataBind();

    //    count = 0;
    //    DataSet ds3 = m_IndexBLL.GetList("[typeId]=14 and [del]=0 ORDER BY [setDate] DESC");
    //    DataTable dt3 = ds3.Tables[0].Clone();
    //    for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
    //    {
    //        if (count >= 8)
    //            break;

    //        if (m_UserLogin.LoginID.ToString().Trim() == ds3.Tables[0].Rows[i]["userId"].ToString().Trim())
    //        {
    //            dt3.Rows.Add(ds3.Tables[0].Rows[i].ItemArray);
    //            count++;
    //            continue;
    //        }
    //        if (null != ds3.Tables[0].Rows[i]["readUser"] && ds3.Tables[0].Rows[i]["readUser"] != DBNull.Value)
    //        {
    //            string[] str = ds3.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //            for (int j = 0; j < str.Length; j++)
    //            {
    //                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
    //                {
    //                    dt3.Rows.Add(ds3.Tables[0].Rows[i].ItemArray);
    //                    count++;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    Repeater3.DataSource = dt3;
    //    Repeater3.DataBind();
    //    //List<Tunnel.Model.Tunnel_SelType> listSH = st.GetModelList("[ParentID]=14");
    //    //dgdYSHead.DataSource = dt3;
    //    //dgdYSHead.DataBind();


    //    List<Tunnel.Model.Tunnel_SelType> listSH4 = st.GetModelList("ParentID=15");
    //    if (listSH4.Count > 0)
    //    {
    //        DataGrid1.DataSource = listSH4;
    //        DataGrid1.DataBind();
    //    }
    //    //List<Tunnel.Model.Tunnel_SelType> listSH44 = st.GetModelList("TypeID=50");
    //    //if (listSH4.Count > 0)
    //    //{
    //    //    Repeater4.DataSource = listSH4;
    //    //    Repeater4.DataBind();
    //    //}

    //    count = 0;
    //    DataSet ds4 = m_IndexBLL.GetList("[typeId]=15 and [del]=0 ORDER BY [setDate] DESC");
    //    DataTable dt4 = ds4.Tables[0].Clone();
    //    for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
    //    {
    //        if (count >= 8)
    //            break;
    //        if (m_UserLogin.LoginID.ToString().Trim() == ds4.Tables[0].Rows[i]["userId"].ToString().Trim())
    //        {
    //            dt4.Rows.Add(ds4.Tables[0].Rows[i].ItemArray);
    //            count++;
    //            continue;
    //        }
    //        if (null != ds4.Tables[0].Rows[i]["readUser"] && ds4.Tables[0].Rows[i]["readUser"] != DBNull.Value)
    //        {
    //            string[] str = ds4.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //            for (int j = 0; j < str.Length; j++)
    //            {
    //                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
    //                {
    //                    dt4.Rows.Add(ds4.Tables[0].Rows[i].ItemArray);
    //                    count++;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    Repeater4.DataSource = dt4;
    //    Repeater4.DataBind();

    //    List<Tunnel.Model.Tunnel_SelType> listSH5 = st.GetModelList("ParentID=16");
    //    if (listSH5.Count > 0)
    //    {
    //        DataGrid1.DataSource = listSH5;
    //        DataGrid1.DataBind();
    //    }
    //    count = 0;
    //    DataSet ds5 = m_IndexBLL.GetList("[typeId]=16 and del=0 ORDER BY [setDate] DESC");
    //    DataTable dt5 = ds5.Tables[0].Clone();
    //    for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
    //    {
    //        if (count >= 8)
    //            break;
    //        if (m_UserLogin.LoginID.ToString().Trim() == ds5.Tables[0].Rows[i]["userId"].ToString().Trim())
    //        {
    //            dt5.Rows.Add(ds5.Tables[0].Rows[i].ItemArray);
    //            count++;
    //            continue;
    //        }
    //        if (null != ds5.Tables[0].Rows[i]["readUser"] && ds5.Tables[0].Rows[i]["readUser"] != DBNull.Value)
    //        {
    //            string[] str = ds5.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //            for (int j = 0; j < str.Length; j++)
    //            {
    //                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
    //                {
    //                    dt5.Rows.Add(ds5.Tables[0].Rows[i].ItemArray);
    //                    count++;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    Repeater5.DataSource = dt5;
    //    Repeater5.DataBind();

    //    count = 0;
    //    DataSet ds6 = m_IndexBLL.GetList("[typeId]=17 and del=0 ORDER BY [setDate] DESC");
    //    DataTable dt6 = ds6.Tables[0].Clone();
    //    for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
    //    {
    //        if (count >= 8)
    //            break;
    //        if (m_UserLogin.LoginID.ToString().Trim() == ds6.Tables[0].Rows[i]["userId"].ToString().Trim())
    //        {
    //            dt6.Rows.Add(ds6.Tables[0].Rows[i].ItemArray);
    //            count++;
    //            continue;
    //        }
    //        if (null != ds6.Tables[0].Rows[i]["readUser"] && ds6.Tables[0].Rows[i]["readUser"] != DBNull.Value)
    //        {
    //            string[] str = ds6.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //            for (int j = 0; j < str.Length; j++)
    //            {
    //                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
    //                {
    //                    dt6.Rows.Add(ds6.Tables[0].Rows[i].ItemArray);
    //                    count++;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    Repeater6.DataSource = dt6;
    //    Repeater6.DataBind();

    //    count = 0;
    //    DataSet ds7 = m_IndexBLL.GetList("[typeId]=18 and del=0 ORDER BY [setDate] DESC");
    //    DataTable dt7 = ds7.Tables[0].Clone();
    //    for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
    //    {
    //        if (count >= 8)
    //            break;
    //        if (m_UserLogin.LoginID.ToString().Trim() == ds7.Tables[0].Rows[i]["userId"].ToString().Trim())
    //        {
    //            dt7.Rows.Add(ds7.Tables[0].Rows[i].ItemArray);
    //            count++;
    //            continue;
    //        }
    //        if (null != ds7.Tables[0].Rows[i]["readUser"] && ds7.Tables[0].Rows[i]["readUser"] != DBNull.Value)
    //        {
    //            string[] str = ds7.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    //            for (int j = 0; j < str.Length; j++)
    //            {
    //                if (m_UserLogin.LoginID.ToString().Trim() == str[j])
    //                {
    //                    dt7.Rows.Add(ds7.Tables[0].Rows[i].ItemArray);
    //                    count++;
    //                    break;
    //                }
    //            }
    //        }
    //    }
    //    Repeater7.DataSource = dt7;
    //    Repeater7.DataBind();
    //}
    protected void dgdYSHead_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            string id = ((Label)e.Item.Cells[0].FindControl("lblTypeID")).Text.Trim();
            DataGrid dgdItem = e.Item.Cells[0].FindControl("dgdYSItem") as DataGrid;

            List<Tunnel.Model.Tunnel_SelType> item = st.GetModelList(string.Format("ParentID={0} AND ParentID<>0", id));
            if (item.Count > 0)
            {
                dgdItem.DataSource = item;
            }
            else
            {
                dgdItem.DataSource = null;
            }
            dgdItem.DataBind();
        }
    }
    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            string id = ((Label)e.Item.Cells[0].FindControl("lblTypeID")).Text.Trim();
            DataGrid dgdItem = e.Item.Cells[0].FindControl("dgdYSItem") as DataGrid;

            List<Tunnel.Model.Tunnel_SelType> item = st.GetModelList(string.Format("ParentID={0} AND ParentID<>0", id));
            if (item.Count > 0)
            {
                dgdItem.DataSource = item;
            }
            else
            {
                dgdItem.DataSource = null;
            }
            dgdItem.DataBind();
        }
    }

    public string GetLink(object id, string typeid, string lanmuId, object title,object userID,object readUser)
    {
        string link = "";
        int len = 0;
        if (title.ToString().Trim().Length > 36)
            len = 36;
        else
            len = title.ToString().Trim().Length;

        if (readUser.ToString().Trim() == "" || int.Parse(userID.ToString().Trim())==m_UserLogin.LoginID || "系统管理员"==m_UserLogin.JiaoSe(m_UserLogin.LoginID))
        {
            link = string.Format("<a href='{0}?id={1}&TypeId={2}&lanmuId={3}' title='{4}'>{5}</a>", "ViewIndex.aspx", id.ToString().Trim(), typeid, lanmuId, title.ToString().Trim(), title.ToString().Trim().Substring(0, len)); 
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
                link = string.Format("<a href='{0}?id={1}&TypeId={2}&lanmuId={3}' title='{4}'>{5}</a>", "ViewIndex.aspx", id.ToString().Trim(), typeid, lanmuId, title.ToString().Trim(), title.ToString().Trim().Substring(0, len)); 
            else
                link = string.Format("<a href='#' onclick='return false;' title='{0}'>{1}</a>", title.ToString().Trim(), title.ToString().Trim().Substring(0, len)); 
        }
        return link;
    }
}
