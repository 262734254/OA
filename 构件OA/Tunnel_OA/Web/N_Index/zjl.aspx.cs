using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using Tunnel.BLL;

public partial class N_Index_zjl : System.Web.UI.Page
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
            xnChild.Attributes[0].Value = "N_Index/zjl.aspx";
            xnChild.Attributes[1].Value = "总经理办公室";
            xnChild.Attributes[2].Value = "总经理办公室";

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

    private void LoadSource()
    {
        int count = 0;

        DataSet dsDT = m_IndexBLL.GetList("[typeId]=8 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dtDT = dsDT.Tables[0].Clone();
        /*
        for (int i = 0; i < dsDT.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == dsDT.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtDT.Rows.Add(dsDT.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsDT.Tables[0].Rows[i]["readUser"] && dsDT.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsDT.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtDT.Rows.Add(dsDT.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/
        Repeater1.DataSource = dtDT;
        Repeater1.DataBind();

        count = 0;
        DataSet dsWX = m_IndexBLL.GetList("[typeId]=9 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dtWX = dsWX.Tables[0].Clone();
        /*
        for (int i = 0; i < dsWX.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == dsWX.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtWX.Rows.Add(dsWX.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsWX.Tables[0].Rows[i]["readUser"] && dsWX.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsWX.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtWX.Rows.Add(dsWX.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/
        Repeater2.DataSource = dtWX;
        Repeater2.DataBind();

        count = 0;
        DataSet dsBZ = m_IndexBLL.GetList("[typeId]=10 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dtBZ = dsBZ.Tables[0].Clone();
        /*
        for (int i = 0; i < dsBZ.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == dsBZ.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtBZ.Rows.Add(dsBZ.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsBZ.Tables[0].Rows[i]["readUser"] && dsBZ.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsBZ.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtBZ.Rows.Add(dsBZ.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/
        Repeater3.DataSource = dtBZ;
        Repeater3.DataBind();

        count = 0;
        DataSet dsXC = m_IndexBLL.GetList("[typeId]=11 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dtXC = dsXC.Tables[0].Clone();
        /*
        for (int i = 0; i < dsBZ.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == dsXC.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtXC.Rows.Add(dsXC.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsXC.Tables[0].Rows[i]["readUser"] && dsXC.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsXC.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtXC.Rows.Add(dsXC.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }*/
        Repeater4.DataSource = dtXC;
        Repeater4.DataBind();

        count = 0;
        DataSet dsHT = m_IndexBLL.GetList("[typeId]=162 and del=0 and IsDel=0 ORDER BY [setDate] DESC");
        DataTable dtHT = dsXC.Tables[0].Clone();
        /*
        for (int i = 0; i < dsHT.Tables[0].Rows.Count; i++)
        {
            if (count >= 8)
                break;
            if (m_UserLogin.LoginID.ToString().Trim() == dsHT.Tables[0].Rows[i]["userId"].ToString().Trim())
            {
                dtHT.Rows.Add(dsHT.Tables[0].Rows[i].ItemArray);
                count++;
                continue;
            }
            if (null != dsHT.Tables[0].Rows[i]["readUser"] && dsHT.Tables[0].Rows[i]["readUser"] != DBNull.Value)
            {
                string[] str = dsHT.Tables[0].Rows[i]["readUser"].ToString().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < str.Length; j++)
                {
                    if (m_UserLogin.LoginID.ToString().Trim() == str[j])
                    {
                        dtHT.Rows.Add(dsHT.Tables[0].Rows[i].ItemArray);
                        count++;
                        break;
                    }
                }
            }
        }
         */
        Repeater5.DataSource = dtHT;
        Repeater5.DataBind();
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
