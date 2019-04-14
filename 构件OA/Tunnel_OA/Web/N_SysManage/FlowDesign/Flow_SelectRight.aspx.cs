using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SystemManage_BaseData_Flow_SelectLeft : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    public Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ShowInit();
        }
    }

    void ShowInit()
    {
        List<Tunnel.Model.Tunnel_menber> listCount = new List<Tunnel.Model.Tunnel_menber>();
        DataSet ds = null;
        if ("bum" == Request.Params["act"])
        {
            ds = new DataSet();
            ds = tm.GetList("m_bum=" + Request.Params["idh"]);
        }
        else if ("jiao" == Request.Params["act"])
        {
            ds = new DataSet();
            ds = tm.GetList("m_jiao=" + Request.Params["idh"]);
        }
        else if ("xian" == Request.Params["act"])
        {
            string xjb = null==Request.QueryString["idh"] ? "" : Request.QueryString["idh"].ToString().Trim();
            if (xjb!="")
            {
                List<Tunnel.Model.Tunnel_menber> list = tm.GetModelList("1=1");
                
                foreach (Tunnel.Model.Tunnel_menber ilist in list)
                {
                    if (ilist.m_xjb.ToString().Trim() != "")
                    {
                        string[] strXJB = ilist.m_xjb.Split(new Char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < strXJB.Length; i++)
                        {
                            if (xjb == strXJB[i])
                            {
                                listCount.Add(ilist);
                                break;
                            }
                        }
                    }
                }
                
        
            }
     
        }
        else if ("search" == Request.Params["act"])
        {
            ds = new DataSet();
            if ("" != Request.Params["idh"])
            {
                ds = tm.GetList("m_name like '%" + Request.Params["idh"] + "%' or m_login like '" + Request.Params["idh"] + "%'");
            }
            else
            {
                ds = null;
            }
        }
        else
        {
            ds = new DataSet();
            ds = null;
        }
        if ("xian" == Request.Params["act"])
        {
            Repeater1.DataSource = listCount;
            Repeater1.DataBind();
        }
        else
        {
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }
    /// <summary>
    ///有审批权限的人
    /// </summary>
    /// <param name="mid"></param>
    /// <returns></returns>
    public string getShow(string mid)
    {
        if (!string.IsNullOrEmpty(Request.Params["Competence"]))
        {
            if ("sp".Equals(Request.Params["Competence"]))
            {
                if (!Tunnel.BLL.Permission.IfHasPrimision(mid, "流程审批", "我的工作", false))
                {
                    return "style='display:none'";
                }
                else
                {
                    return "";
                }
            }
            else if ("sh".Equals(Request.Params["Competence"]))
            {
                if (!Tunnel.BLL.Permission.IfHasPrimision(mid, "流程审核", "我的工作", false))
                {
                    return "style='display:none'";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }
}
