﻿using System;
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

public partial class N_Index_gbbg : System.Web.UI.Page
{
    private int cuttentPage;
    private int pageSize = 8;
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();

    public Tunnel.BLL.Tunnel_anpai mbll = new Tunnel.BLL.Tunnel_anpai();

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
                indexBLL = new Tunnel.BLL.Tunnel_Index();
            return indexBLL;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //AnpaiBind();
            // LoadSource();
            PageBind();
        }
    }
    private void PageBind()
    {
        Bindxmlx();
        Bindjhqkschzb();
        Bindgcxmkhhzb();
        Bindqzgzlhzb();
        Bindscxshzb();
        Bindzjszjhhzb();
        Bindgxjsqk();
        BindKSDT();
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
    private void BindKSDT()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=155";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater15.DataSource = das;
            Repeater15.DataBind();
            Repeater15.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=155 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater16.DataSource = das2;
            Repeater16.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=155 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater16.DataSource = das2;
            Repeater16.DataBind();
            Repeater16.Visible = true;
            Repeater15.Visible = false;
        }
    }
    /// <summary>
    /// 项目立项
    /// </summary>
    private void Bindxmlx()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=19";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater8.DataSource = das;
            Repeater8.DataBind();
            Repeater8.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=19 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater1.DataSource = das2;
            Repeater1.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=19 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater1.DataSource = das2;
            Repeater1.DataBind();
            Repeater1.Visible = true;
            Repeater8.Visible = false;
        }
    }
    /// <summary>
    /// 计划、生产情况汇总表
    /// </summary>
    private void Bindjhqkschzb()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=20";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater9.DataSource = das;
            Repeater9.DataBind();
            Repeater9.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=20 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater2.DataSource = das2;
            Repeater2.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=20 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater2.DataSource = das2;
            Repeater2.DataBind();
            Repeater2.Visible = true;
            Repeater9.Visible = false;
        }
    }
    /// <summary>
    /// 工程项目考核汇总表 
    /// </summary>
    private void Bindgcxmkhhzb()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=21";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater10.DataSource = das;
            Repeater10.DataBind();
            Repeater10.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=21 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater3.DataSource = das2;
            Repeater3.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=21 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater3.DataSource = das2;
            Repeater3.DataBind();
            Repeater3.Visible = true;
            Repeater10.Visible = false;
        }
    }
    /// <summary>
    /// 签证工作量汇总表
    /// </summary>
    private void Bindqzgzlhzb()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=22";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater11.DataSource = das;
            Repeater11.DataBind();
            Repeater11.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=22 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater4.DataSource = das2;
            Repeater4.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=22 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater4.DataSource = das2;
            Repeater4.DataBind();
            Repeater4.Visible = true;
            Repeater11.Visible = false;
        }
    }
    /// <summary>
    /// 资金收支计划汇总表
    /// </summary>
    private void Bindzjszjhhzb()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=23";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater12.DataSource = das;
            Repeater12.DataBind();
            Repeater12.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=23 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater5.DataSource = das2;
            Repeater5.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=23 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater5.DataSource = das2;
            Repeater5.DataBind();
            Repeater5.Visible = true;
            Repeater12.Visible = false;
        }
    }
    /// <summary>
    /// 产值销售汇总表
    /// </summary>
    private void Bindscxshzb()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=24";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater13.DataSource = das;
            Repeater13.DataBind();
            Repeater13.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=24 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater6.DataSource = das2;
            Repeater6.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=24 and del=0 and IsDel=0 order by setdate desc";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater6.DataSource = das2;
            Repeater6.DataBind();
            Repeater6.Visible = true;
            Repeater13.Visible = false;
        }

    }
    /// <summary>
    /// 工程结算情况
    /// </summary>
    private void Bindgxjsqk()
    {
        string strsql = "select * from tunnel_newstype where IsDel=0 and parentid=25";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        if (das.Tables[0].Rows.Count > 0)
        {
            Repeater14.DataSource = das;
            Repeater14.DataBind();
            Repeater14.Visible = true;
            string strsql2 = "select top " + gettop(8 - das.Tables[0].Rows.Count) + " * from tunnel_index where typeid=25 and del=0 and IsDel=0 order by setdate desc ";
            DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
            Repeater7.DataSource = das2;
            Repeater7.DataBind();
        }
        else
        {
            string strsql2 = "select top 8 * from tunnel_index where typeid=25 and del=0 and IsDel=0 order by setdate desc";
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
        string strsql2 = "select top 8 * from tunnel_index where typeid=161 and del=0 and IsDel=0 order by setdate desc";
        DataSet das2 = Tunnel.Data.DbHelperSQL.Query(strsql2);
        Repeater18.DataSource = das2;
        Repeater18.DataBind();
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
            xnChild.Attributes[0].Value = "N_Index/gbbg.aspx";
            xnChild.Attributes[1].Value = "贯标办公室";
            xnChild.Attributes[2].Value = "贯标办公室";

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

    private void LoadSource()
    {
        int count = 0;

        DataSet ds1 = m_IndexBLL.GetList("[typeId]=19 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
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
        DataSet ds2 = m_IndexBLL.GetList("[typeId]=20 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
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
        DataSet ds3 = m_IndexBLL.GetList("[typeId]=21 and del=0 and bum_ba=0 ORDER BY [setDate] DESC");
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
        DataSet ds4 = m_IndexBLL.GetList("[typeId]=22 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
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

        count = 0;
        DataSet ds5 = m_IndexBLL.GetList("[typeId]=23 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dt5 = ds5.Tables[0].Clone();
        for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == ds5.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dt5.Rows.Add(ds5.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != ds5.Tables[0].Rows[i]["readUser"] && ds5.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = ds5.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dt5.Rows.Add(ds5.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
        Repeater5.DataSource = dt5;
        Repeater5.DataBind();

        count = 0;
        DataSet ds6 = m_IndexBLL.GetList("[typeId]=24 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dt6 = ds6.Tables[0].Clone();
        for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == ds6.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dt6.Rows.Add(ds6.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != ds6.Tables[0].Rows[i]["readUser"] && ds6.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = ds6.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dt6.Rows.Add(ds6.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
        Repeater6.DataSource = dt6;
        Repeater6.DataBind();

        count = 0;
        DataSet ds7 = m_IndexBLL.GetList("[typeId]=25 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dt7 = ds7.Tables[0].Clone();
        for (int i = 0; i < ds6.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == ds7.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dt7.Rows.Add(ds7.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != ds7.Tables[0].Rows[i]["readUser"] && ds7.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = ds7.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dt7.Rows.Add(ds7.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
        Repeater7.DataSource = dt7;
        Repeater7.DataBind();
    }

    public string GetLink(object id, string typeid, string lanmuId, object title, object userID, object readUser)
    {
        string link = "";
        int len = 0;
        if (title.ToString().Trim().Length > 36)
            len = 36;
        else
            len = title.ToString().Trim().Length;

        if (readUser.ToString().Trim() == "" || int.Parse(userID.ToString().Trim()) == m_UserLogin.LoginID || "系统管理员"==m_UserLogin.JiaoSe(m_UserLogin.LoginID))
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
