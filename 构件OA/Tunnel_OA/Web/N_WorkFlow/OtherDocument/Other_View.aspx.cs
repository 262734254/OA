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

public partial class Workflow_Tunnel_WordView : System.Web.UI.Page
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
    public string formfile = "";
    public string formdvice = "";
    public int i = 0;
    public bool isliu = false;
    public bool isend = false;
    public string nextb = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Bind();
        }
    }

    void Bind()
    {
        try
        {
            string suser = "";
            mtb = btb.GetModel(int.Parse(Tunnel.Data.DESEncrypt.Decrypt(Request.Params["lid"])));
            Label1.Text = mtb.b_content;//取得替换后的表单数据
            formfile = getFile(mtb.b_file);//附件
            formdvice = getAdvice(mtb.b_id.ToString());//意见
            Page.Title=Label2.Text = mtb.b_title;
            DataSet ds = bte.GetList("e_gid=" + mtb.b_id + " and e_user<>0 order by e_id asc");
            if (mtb.b_state == 3) { nextb = ""; isend = true; }
            else
            {
                if (mtb.b_state > 0)
                {
                    string curruser = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbuser", "e_gid=" + mtb.b_id + " order by e_id desc");
                    string currtime = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_time", "e_gid=" + mtb.b_id + " order by e_id desc");
                    int currnum = Convert.ToInt32(Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "count(*)", "e_user<>0 and e_gid=" + mtb.b_id));
                    StringBuilder text = new StringBuilder();
                    text.Append("<tr>");
                    text.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>" + (currnum+1) + "</font>步</td>");
                    text.Append("<td align=\"left\" style=\"height: 30px; width: 30%\">&nbsp;&nbsp;审批</td>");
                    text.Append("<td align=\"left\" style=\"height: 50%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getallUname(curruser) + " 主办</strong> [<font color=blue>办理中</font>]");
                    text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + currtime + "</td>");
                    text.Append("</tr> ");
                    nextb = text.ToString();
                }
            }
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
            if (ds.Tables[0].Rows.Count > 0 || nextb != "")
            {
                isliu = true;
            }
        }
        catch
        {
            Tunnel.Common.Message.back("无效参数");
        }
    }
    /// <summary>
    /// 附件列表
    /// </summary>
    /// <param name="filelist"></param>
    /// <returns></returns>
    public string getFile(string filelist)
    {
        int i = 0;
        string filecontent = "";
        if (filelist != "")
        {
            string[] filearr = filelist.Split(',');
            foreach (string file in filearr)
            {
                if (file != "")
                {
                    i++;
                    filecontent += Tunnel.Common.GetValue.getfu(file, "", i);
                }
            }
            return filecontent;
        }
        else
        {
            return "无附件";
        }

    }

    /// <summary>
    /// 当前步骤审批状态
    /// </summary>
    /// <param name="bid">步骤ID</param>
    /// <param name="nid">下一步骤ID</param>
    /// <returns></returns>
    public string getNum(string bid, string nid)
    {
        if (!"".Equals(bid) && !"".Equals(nid))
        {
            if ("0".Equals(bid) && "0".Equals(nid))
            {
                return "<font color=red>审批不通过,返回至发起人</font>";
            }
            else if ("0".Equals(bid))
            {
                return "<font color=green>审批通过</font>";
            }
            else
            {
                return "审核";
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
                return "<font color=green>已办理,同意</font>";
            }
            else
            {
                return "<font color=green>办理中</font>";
            }
        }
        else
        {
            return "";
        }
    }
    /// <summary>
    /// 返回步骤名称
    /// </summary>
    /// <param name="bid">步骤ID</param>
    /// <returns></returns>
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
    /// <summary>
    /// 返回用户名
    /// </summary>
    /// <param name="uid">用户Id</param>
    /// <returns></returns>
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
    /// 返回意见列表
    /// </summary>
    /// <param name="gid">公文ID</param>
    /// <returns></returns>
    public string getAdvice(string gid)
    {
        string list = "";
        Tunnel.BLL.Tunnel_Advice bta = new Tunnel.BLL.Tunnel_Advice();
        DataSet ds = bta.GetList("a_gid=" + gid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int ifd = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    ifd++;
                    string username = Tunnel.Common.GetValue.getDataValue("Tunnel_menber", "m_name", "m_id=" + dr["a_user"]);
                    list += "<tr><td align=\"left\" colspan=\"2\" rowspan=\"1\" style=\"height: 30px; width: 662px;padding-left:5px\">第 " + ifd + " 步 <font color=blue>" + username + "</font> ：<br/>" + dr["a_content"].ToString() + " " + dr["a_time"].ToString() + "</td></tr>";
                }
                catch {
                    list += "";
                }
            }
            return list;
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
                unamelist += dr["m_name"].ToString()+",";
            }
            unamelist = unamelist.Substring(0, unamelist.Length - 1);
        }
        return unamelist;
    }
}