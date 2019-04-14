using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using Tunnel.BLL;

public partial class N_Index_jyjh : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadSource();
            PageBind();
        }
    }
    private void PageBind()
    {
        Bindksdt();
        Bindcljgdt();
        Bindfccltjbb();
        Bindclcghggysml();
        BindHT();
    }

    private int gettop(int i)
    {
        if (i >= 0)
            return i;
        else
            return i;
    }
    /// <summary>
    /// 科室动态
    /// </summary>
    private void Bindksdt()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=32";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater5.DataSource = das;
            Repeater5.DataBind();
            Repeater5.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=32 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater1.DataSource = das2;
            Repeater1.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=32 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater1.DataSource = das2;
            Repeater1.DataBind();
            Repeater1.Visible = true;
            Repeater5.Visible = false;
        }
    }
    /// <summary>
    /// 材料价格动态
    /// </summary>
    private void Bindcljgdt()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=33";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater6.DataSource = das;
            Repeater6.DataBind();
            Repeater6.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=33 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater2.DataSource = das2;
            Repeater2.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=33 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater2.DataSource = das2;
            Repeater2.DataBind();
            Repeater2.Visible = true;
            Repeater6.Visible = false;
        }
    }
    /// <summary>
    /// 分厂材料统计报表
    /// </summary>
    private void Bindfccltjbb()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=34";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater7.DataSource = das;
            Repeater7.DataBind();
            Repeater7.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=34 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater3.DataSource = das2;
            Repeater3.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=34 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater3.DataSource = das2;
            Repeater3.DataBind();
            Repeater3.Visible = true;
            Repeater7.Visible = false;
        }
    }
    /// <summary>
    /// 材料采购合格供应商名录
    /// </summary>
    private void Bindclcghggysml()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=35";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater8.DataSource = das;
            Repeater8.DataBind();
            Repeater8.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=35 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater4.DataSource = das2;
            Repeater4.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=35 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater4.DataSource = das2;
            Repeater4.DataBind();
            Repeater4.Visible = true;
            Repeater8.Visible = false;
        }
    }
    /// <summary>
    /// 材料合同管理
    /// </summary>
    private void BindHT()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=158";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater9.DataSource = das;
            Repeater9.DataBind();
            Repeater9.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=158 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater10.DataSource = das2;
            Repeater10.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=158 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater10.DataSource = das2;
            Repeater10.DataBind();
            Repeater10.Visible = true;
            Repeater9.Visible = false;
        }
    }

    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
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
            xnChild.Attributes[0].Value = "N_Index/jyjh.aspx";
            xnChild.Attributes[1].Value = "经营计划部";
            xnChild.Attributes[2].Value = "经营计划部";

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
    protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    private void LoadSource()
    {
        int count = 0;

        DataSet ds1 = m_IndexBLL.GetList("[typeId]=32 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dt1 = ds1.Tables[0].Clone();
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == ds1.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dt1.Rows.Add(ds1.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != ds1.Tables[0].Rows[i]["readUser"] && ds1.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = ds1.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dt1.Rows.Add(ds1.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
        Repeater1.DataSource = dt1;
        Repeater1.DataBind();

        count = 0;
        DataSet ds2 = m_IndexBLL.GetList("[typeId]=33 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dt2 = ds2.Tables[0].Clone();
        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == ds2.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dt2.Rows.Add(ds2.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != ds2.Tables[0].Rows[i]["readUser"] && ds2.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = ds2.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dt2.Rows.Add(ds2.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
        Repeater2.DataSource = dt2;
        Repeater2.DataBind();

        count = 0;
        DataSet ds3 = m_IndexBLL.GetList("[typeId]=34 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dt3 = ds3.Tables[0].Clone();
        for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == ds3.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dt3.Rows.Add(ds3.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != ds3.Tables[0].Rows[i]["readUser"] && ds3.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = ds3.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dt3.Rows.Add(ds3.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
        Repeater3.DataSource = dt3;
        Repeater3.DataBind();

        count = 0;
        DataSet ds4 = m_IndexBLL.GetList("[typeId]=35 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dt4 = ds4.Tables[0].Clone();
        for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == ds4.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dt4.Rows.Add(ds4.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != ds4.Tables[0].Rows[i]["readUser"] && ds4.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = ds4.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dt4.Rows.Add(ds4.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
        Repeater4.DataSource = dt4;
        Repeater4.DataBind();
    }

    public string GetLink(object id, string typeid, string lanmuId, object title, object userID, object readUser)
    {
        string link = "";
        int len = 0;
        if (title.ToString().Trim().Length > 36)
            len = 36;
        else
            len = title.ToString().Trim().Length;

        if (readUser.ToString().Trim() == "" || int.Parse(userID.ToString().Trim()) == m_UserLogin.LoginID || "系统管理员" == m_UserLogin.JiaoSe(m_UserLogin.LoginID))
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
