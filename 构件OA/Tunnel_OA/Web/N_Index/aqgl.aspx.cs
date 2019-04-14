using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Tunnel.DAL;

public partial class N_Index_aqgl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(SiteMap_SiteMapResolve);
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }


    protected void Page_Init(object sender, EventArgs e)
    {
        //Master.FindControl("SiteMapPath1").Visible = false;
        //WriteSiteMap();
    }

    //SiteMapNode SiteMap_SiteMapResolve(object sender, SiteMapResolveEventArgs e)
    //{
    //    SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
    //    SiteMapNode modifyNode = currentNode;
    //    modifyNode.Url = "http://www.aaa.net";
    //    modifyNode.Title = "aaaa";

    //    //if ( (modifyNode = modifyNode.ParentNode) != null)  
    //    //{  
    //    //    modifyNode.Url = "http://www.aaa.net";  
    //    //    modifyNode.Title = "aaa";  
    //    //}  

    //    return currentNode;
    //}
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
            xnChild.Attributes[0].Value = "N_Index/aqgl.aspx";
            xnChild.Attributes[1].Value = "安全管理部";
            xnChild.Attributes[2].Value = "安全管理部";

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
}
