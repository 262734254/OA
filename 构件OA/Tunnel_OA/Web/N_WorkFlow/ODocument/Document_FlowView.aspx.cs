using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Workflow_Tunnel_FlowView : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_form tf = new Tunnel.BLL.Tunnel_form();
    Tunnel.Model.Tunnel_form mtf = new Tunnel.Model.Tunnel_form();
    Tunnel.BLL.Tunnel_flow bf = new Tunnel.BLL.Tunnel_flow();
    Tunnel.Model.Tunnel_flow mf = new Tunnel.Model.Tunnel_flow();
    Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
    Tunnel.BLL.Tunnel_bumf btb = new Tunnel.BLL.Tunnel_bumf();
    Tunnel.Model.Tunnel_bumf mtb = new Tunnel.Model.Tunnel_bumf();
    Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
    Tunnel.BLL.Tunnel_step ts = new Tunnel.BLL.Tunnel_step();
    Tunnel.Model.Tunnel_step mts = new Tunnel.Model.Tunnel_step();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
    public bool isend = false;
    public string nextb = "";
    public string toptb = "";
    public int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string bWhere = "";
            mtb = btb.GetModel(int.Parse(Request.Params["lid"]));
            mf = bf.GetModel(mtb.b_sort);
            if (mf.f_sort == 18) bWhere = " and e_bid<>0"; else bWhere = "";
            Page.Title = mtb.b_title;
            DataSet ds = bte.GetList("e_gid=" + mtb.b_id + bWhere + " order by e_id asc");
            StringBuilder text = new StringBuilder();
            StringBuilder texttop = new StringBuilder();
            texttop.Append("<tr>");
            texttop.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>1</font>步</td>");
            texttop.Append("<td align=\"left\" style=\"height: 30px; width: 30%\">&nbsp;&nbsp;发起</td>");
            texttop.Append("<td align=\"left\" style=\"height: 50%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getUname(mtb.b_user.ToString()) + "</strong> [<font color=Green>发起</font>]");
            texttop.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发起于：" + mtb.b_time.ToString() + "</td>");
            texttop.Append("</tr> ");
            if (mtb.b_state == 3) { nextb = ""; isend = true; }
            else if (mtb.b_state == 1)
            {
                string suser = "";
                if (mtb.b_suser == 0)
                {
                    ul.UsbnLogin = bm.GetModel(mtb.b_user);
                    DataSet dss = new DataSet();
                    dss = bm.GetList("m_bum=" + ul.UsbnLogin.m_bum);
                    foreach (DataRow dr in dss.Tables[0].Rows)
                    {
                        if (Tunnel.BLL.Permission.IfHasPrimision(dr["m_id"].ToString(), "流程审核", "我的工作", false))
                        {
                            suser += dr["m_id"].ToString() + ",";
                        }
                    }
                    if (!string.IsNullOrEmpty(suser))
                    {
                        text.Append("<tr>");
                        text.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>2</font>步</td>");
                        text.Append("<td align=\"left\" style=\"height: 30px; width: 30%\">&nbsp;&nbsp;审核</td>");
                        text.Append("<td align=\"left\" style=\"height: 50%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getallUname(suser) + " 主办</strong> [<font color=blue>审核中</font>]");
                        text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + mtb.b_time.ToString() + "</td>");
                        text.Append("</tr> ");
                    }
                    else
                    {
                        text.Append("<tr>");
                        text.Append("<td align=\"center\" colspan='3' style=\"height: 30px; width: 10%;color:red\">没有设置审核人,请与管理员联系!</td>");
                        text.Append("</tr> ");
                    }
                }
                else
                {
                    text.Append("<tr>");
                    text.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>2</font>步</td>");
                    text.Append("<td align=\"left\" style=\"height: 30px; width: 30%\">&nbsp;&nbsp;审核</td>");
                    text.Append("<td align=\"left\" style=\"height: 50%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getUname(mtb.b_suser.ToString()) + " 主办</strong> [<font color=blue>审核中</font>]");
                    text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + mtb.b_time.ToString() + "</td>");
                    text.Append("</tr> ");
                }
                nextb = text.ToString();
            }
            else
            {
                if (mtb.b_state > 0)
                {
                    string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbid", "e_gid=" + mtb.b_id + " order by e_id desc");
                    string currtime = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_time", "e_gid=" + mtb.b_id + " order by e_id desc");
                    int currnum = Convert.ToInt32(Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "count(*)", "e_gid=" + mtb.b_id));
                    if ("".Equals(currbid) || "0".Equals(currbid))
                    {
                        currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num=1");
                    }
                    mts = ts.GetModel(Convert.ToInt32(currbid));
                    string nextnum = "";
                    string nextname = "";
                    string nextuser = "";
                    if (mts != null)
                    {
                        nextnum=Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_num", "s_id=" + mts.s_id);
                        nextname = getname(mts.s_id.ToString());
                        nextuser = getallUname(mts.s_zid.ToString());
                    }
                    else {
                        nextname = "步骤不存在或已删除";
                        nextuser = nextnum = "无";
                    }
                    text.Append("<tr>");
                    text.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>" +(currnum+(bWhere==""?2:1))+ "</font>步</td>");
                    text.Append("<td align=\"left\" style=\"height: 30px; width: 30%\">&nbsp;&nbsp;" + "序号" + nextnum + "：" + nextname+ "</td>");
                    text.Append("<td align=\"left\" style=\"height: 50%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + nextuser + " 主办</strong> [<font color=blue>办理中</font>]");
                    text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + currtime + "</td>");
                    text.Append("</tr> ");
                    nextb = text.ToString();
                }
            }
            toptb = texttop.ToString();
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }

    public string getNum(string bid,string nid)
    {
        if (!"".Equals(bid) && !"".Equals(nid))
        {
            if ("0".Equals(bid) && "0".Equals(nid))
            {
                return "<font color=red>审批不通过,返回至发起人</font>";
            }
            else if ("0".Equals(bid))
            {
                return "<font color=green>审核通过</font>";
            }
            else
            {
                return "序号" + Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_num", "s_id=" + bid) + "：";
            }
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 当前步骤审批状态
    /// </summary>
    /// <param name="bid">步骤ID</param>
    /// <param name="nid">下一步骤ID</param>
    /// <returns></returns>
    public string getNum(string bid, string nid, int num)
    {
        if (!"".Equals(bid) && !"".Equals(nid))
        {
            if ("0".Equals(bid) && "0".Equals(nid))
            {
                return "<font color=green>已办理,</font><font color=red>不同意</font>";
            }
            else if ("0".Equals(bid))
            {
                return "<font color=green>同意</font>";
            }
            else
            {
                string b_st = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_isbak", "s_id=" + bid);
                if ("1".Equals(b_st))
                {
                    return "<font color=green>已执行</font>";
                }
                else
                {
                    return "<font color=green>已办理,同意</font>";
                }
            }
        }
        else
        {
            return "";
        }
    }

    public string getname(string bid)
    {
        if (!"".Equals(bid))
        {
            return Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_name", "s_id=" + bid);
        }
        else
        {
            return "";
        }
    }

    public string getUname(string uid)
    {
        if (!"".Equals(uid))
        {
            return Tunnel.Common.GetValue.getDataValue("Tunnel_menber", "m_name", "m_id=" + uid);
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// 办理中的用户
    /// </summary>
    /// <param name="ulist">用户ID列表</param>
    /// <returns></returns>
    private string getallUname(string ulist)
    {
        ulist = ulist.Substring(0, ulist.Length - 1);
        string unamelist = "";
        Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
        DataSet ds = bm.GetList("m_id in(" + ulist + ")");
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                unamelist += dr["m_name"].ToString() + ",";
            }
            unamelist = unamelist.Substring(0, unamelist.Length - 1);
        }
        return unamelist;
    }

}
