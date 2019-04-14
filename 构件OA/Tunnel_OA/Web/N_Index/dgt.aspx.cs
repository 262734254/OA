using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using Tunnel.BLL;

public partial class N_Index_zgh : System.Web.UI.Page
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
            LoadSource();
        }
    }
    private void LoadSource()
    {
        int count = 0;
        //SELECT top 8 * FROM [Tunnel_Index] WHERE ([typeId] = @typeId) and del=0 ORDER BY [setDate] DESC
        DataSet dsDJ = m_IndexBLL.GetList("[typeId]=1 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        /*
        DataTable dtDJ = dsDJ.Tables[0].Clone();
        for (int i = 0; i < dsDJ.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == dsDJ.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtDJ.Rows.Add(dsDJ.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsDJ.Tables[0].Rows[i]["readUser"] && dsDJ.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsDJ.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtDJ.Rows.Add(dsDJ.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/

        count = 0;
        DataSet dsGH = m_IndexBLL.GetList("[typeId]=2 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        /*
        DataTable dtGH = dsDJ.Tables[0].Clone();
        for (int i = 0; i < dsGH.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == dsGH.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtGH.Rows.Add(dsGH.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsGH.Tables[0].Rows[i]["readUser"] && dsGH.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsGH.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtGH.Rows.Add(dsGH.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/
        
        count = 0;
        DataSet dsTW = m_IndexBLL.GetList("[typeId]=3 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        /*
        DataTable dtTW = dsTW.Tables[0].Clone();
        for (int i = 0; i < dsTW.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;

            if (m_UserLogin.LoginID.ToString().Trim() == dsTW.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtTW.Rows.Add(dsTW.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsTW.Tables[0].Rows[i]["readUser"] && dsTW.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsTW.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtTW.Rows.Add(dsTW.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/

        count = 0;
        DataSet dsRC = m_IndexBLL.GetList("[typeId]=4 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        
        /*
        DataTable dtRC = dsRC.Tables[0].Clone();
        for (int i = 0; i < dsRC.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;

            if (m_UserLogin.LoginID.ToString().Trim() == dsRC.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtRC.Rows.Add(dsRC.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsRC.Tables[0].Rows[i]["readUser"] && dsRC.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsRC.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtRC.Rows.Add(dsRC.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/

        //count = 0;
        //DataSet dsSG = m_IndexBLL.GetList("[typeId]=153 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        //DataTable dtSG = dsSG.Tables[0].Clone();
        //for (int i = 0; i < dsSG.Tables[0].Rows.Count; i++)
        //{
        //    if (count >= 8)
        //        break;

        //    if (m_UserLogin.LoginID.ToString().Trim() == dsRC.Tables[0].Rows[i]["userId"].ToString().Trim())
        //    {
        //        dtSG.Rows.Add(dsSG.Tables[0].Rows[i].ItemArray);
        //        count++;
        //        continue;
        //    }
        //    if (null != dsSG.Tables[0].Rows[i]["readUser"] && dsSG.Tables[0].Rows[i]["readUser"] != DBNull.Value)
        //    {
        //        string[] str = dsSG.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        for (int j = 0; j < str.Length; j++)
        //        {
        //            if (m_UserLogin.LoginID.ToString().Trim() == str[j])
        //            {
        //                dtSG.Rows.Add(dsSG.Tables[0].Rows[i].ItemArray);
        //                count++;
        //                break;
        //            }
        //        }
        //    }
        //}

        rptDJ.DataSource = dsDJ;
        rptDJ.DataBind();
        rptGH.DataSource = dsGH;
        rptGH.DataBind();
        rptTW.DataSource = dsTW;
        rptTW.DataBind();
        rptRC.DataSource = dsRC;
        rptRC.DataBind();
        //rptSG.DataSource = dtSG;
        //rptSG.DataBind();
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
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
            xnChild.Attributes[0].Value = "N_Index/dgt.aspx";
            xnChild.Attributes[1].Value = "党工团";
            xnChild.Attributes[2].Value = "党工团";

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


    private void BindDataGrid()
    {
        string strID = null == Request.QueryString["id"] ? "" : Request.QueryString["id"].ToString().Trim();
        DataSet ds = m_IndexBLL.GetNewsHead(strID);
        //dgdHead.DataSource = ds;
        //dgdHead.DataBind();
    }
}
