using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

public partial class N_WorkFlow_MyApply_Apply_zSp : System.Web.UI.Page
{
    /// <summary>
    /// 是否允许上传附件
    /// </summary>
    public bool isuploads = true;

    public string formfile = "";

    public string scontent = "";
    /// <summary>
    /// 用户类
    /// </summary>
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    /// <summary>
    /// 表单类
    /// </summary>
    Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
    /// <summary>
    /// 流程业务
    /// </summary>
    Tunnel.BLL.Tunnel_flow bf = new Tunnel.BLL.Tunnel_flow();
    /// <summary>
    /// 公文业务
    /// </summary>
    Tunnel.BLL.Tunnel_bumf btb = new Tunnel.BLL.Tunnel_bumf();
    /// <summary>
    /// 表单业务
    /// </summary>
    Tunnel.BLL.Tunnel_form tf = new Tunnel.BLL.Tunnel_form();
    /// <summary>
    /// 表单实体
    /// </summary>
    Tunnel.Model.Tunnel_form mtf = new Tunnel.Model.Tunnel_form();
    /// <summary>
    /// 流程实体
    /// </summary>
    Tunnel.Model.Tunnel_flow mf = new Tunnel.Model.Tunnel_flow();
    /// <summary>
    /// 公文实体
    /// </summary>
    Tunnel.Model.Tunnel_bumf mtb = new Tunnel.Model.Tunnel_bumf();
    /// <summary>
    /// 步骤实体
    /// </summary>
    Tunnel.Model.Tunnel_step mts = new Tunnel.Model.Tunnel_step();
    /// <summary>
    /// 步骤业务
    /// </summary>
    Tunnel.BLL.Tunnel_step bts = new Tunnel.BLL.Tunnel_step();
    /// <summary>
    /// 步骤执行业务
    /// </summary>
    Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
    /// <summary>
    /// 用户业务
    /// </summary>
    Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
    /// <summary>
    /// 是否已结束
    /// </summary>
    public bool isend = false;
    public string nextb = "";
    public string toptb = "";
    public int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Bind();
            this.bindflow();
        }
    }

    void Bind()
    {
        try
        {
            if (!string.IsNullOrEmpty(Request.Params["bid"]))
            {
                mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
                Label1.Text = mtb.b_content;
                Label4.Text = mtb.b_title + " (" + mtb.b_time + ")";
                Button4.Visible = true;
                formfile = Tunnel.Common.GetValue.getFile(mtb.b_file);
            }
            else
            {
                Tunnel.Common.Message.back("不正确的ID"); return;
            }
        }
        catch
        {
            Tunnel.Common.Message.back("不正确的ID"); return;
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_menber tm = ul.GetUserBean(ul.LoginID);
        if (!Tunnel.Data.DESEncrypt.Encrypt(spPassword.Text.Trim()).Equals(tm.m_spassword))
        {
            Tunnel.Common.Message.back("审批密码错误"); return;
        }
        else
        {
            //这里为存储当前步骤
            mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
            mf = bf.GetModel(mtb.b_sort);
            if (mtb.b_state == 3)
            {
                Tunnel.Common.Message.back("此流程己审批结束,请勿重复审批!"); return;
            }
            else
            {
                //将当前步骤存入数据库表:Tunnel_exam
                Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
                Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
                mte.e_bid = 0;
                mte.e_endtime = DateTime.Now;
                mte.e_gid = Convert.ToInt32(Request.Params["bid"]);
                mte.e_user = ul.LoginID;
                mte.e_nextbuser = m_value.Value;
                string lastendtime = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_endtime", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
                if (!string.IsNullOrEmpty(lastendtime))
                {
                    mte.e_time = Convert.ToDateTime(lastendtime);//取得上一步的最后执行时间
                }
                else
                {
                    mte.e_time = mtb.b_time;
                }
                mte.e_nextbid = 1;

                Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
                Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
                string[] users = m_value.Value.Split(',');
                foreach (string user in users)
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        tr.m_title = mtb.b_title + "<font color=red>(待审批)</font>";
                        tr.m_url = "N_WorkFlow/OtherDocument/Other_zSp.aspx?bid=" + Request.Params["bid"];
                        tr.m_touser = Convert.ToInt32(user);
                        tr.m_time = DateTime.Now;
                        tr.m_type = 1;
                        tr.m_typeid = Convert.ToInt32(mtb.b_id);
                        tr.m_bid = 1;
                        tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                        tr.m_isread = 0;
                        long messge = br.Add(tr);
                    }
                }

                bte.Add(mte);
                string contents = FCKeditor1.Value;
                //添加审批意见
                if (!string.IsNullOrEmpty(contents))
                {
                    Tunnel.BLL.Tunnel_Advice ta = new Tunnel.BLL.Tunnel_Advice();
                    Tunnel.Model.Tunnel_Advice ma = new Tunnel.Model.Tunnel_Advice();
                    ma.a_content = contents;
                    ma.a_bid = Convert.ToInt32(mts.s_id);
                    ma.a_gid = Convert.ToInt32(mtb.b_id);
                    ma.a_time = DateTime.Now;
                    ma.a_user = ul.LoginID;
                    string count = Tunnel.Common.GetValue.getDataValue("Tunnel_Advice", "count(*)", "a_bid=1024 and a_gid=" + Request.Params["bid"]);
                    ta.Add(ma);
                }
                Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=1 and m_touser="+ul.LoginID+" and m_typeid=" + mtb.b_id);//删除待办事项

                Tunnel.Common.Message.Show("操作成功!", "../MyApply/Apply_Sp.aspx");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_menber tm = ul.GetUserBean(ul.LoginID);
        if (!Tunnel.Data.DESEncrypt.Encrypt(spPassword.Text.Trim()).Equals(tm.m_spassword))
        {
            Tunnel.Common.Message.back("审批密码错误"); return;
        }
        else
        {
            //这里为存储当前步骤
            mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
            if (mtb.b_state == 3)
            {
                Tunnel.Common.Message.back("此公文己审批结束,请勿重复审批!"); return;
            }
            else
            {
                //将当前步骤存入数据库表:Tunnel_exam
                Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
                Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
                mte.e_bid = 0;
                mte.e_endtime = DateTime.Now;
                mte.e_gid = Convert.ToInt32(Request.Params["bid"]);
                mte.e_user = ul.LoginID;
                string lastendtime = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_endtime", "e_gid=" + mtb.b_id + " order by e_id desc");
                if (!string.IsNullOrEmpty(lastendtime))
                {
                    mte.e_time = Convert.ToDateTime(lastendtime);//取得上一步的最后执行时间
                }
                else
                {
                    mte.e_time = mtb.b_time;
                }
                mte.e_nextbid = 0;
                bte.Add(mte);

                #region 消息提示
                Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
                Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
                tr.m_title = mtb.b_title + "<font color=red>(审批没有通过)</font>";
                tr.m_url = "N_WorkFlow/OtherDocument/Other_Edit.aspx?bid=" + Request.Params["bid"];
                tr.m_touser = Convert.ToInt32(mtb.b_user);
                tr.m_time = DateTime.Now;
                tr.m_type = 1;
                tr.m_typeid = Convert.ToInt32(mtb.b_id);
                tr.m_bid = -1;
                tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                tr.m_isread = 0;
                long messge = br.Add(tr);
                #endregion

                string contents = FCKeditor1.Value;
                //添加审批意见
                if (!string.IsNullOrEmpty(contents))
                {
                    Tunnel.BLL.Tunnel_Advice ta = new Tunnel.BLL.Tunnel_Advice();
                    Tunnel.Model.Tunnel_Advice ma = new Tunnel.Model.Tunnel_Advice();
                    ma.a_content = contents;
                    ma.a_bid = 1024;//1024代表是其它申请 没有步骤ID的 
                    ma.a_gid = Convert.ToInt32(mtb.b_id);
                    ma.a_time = DateTime.Now;
                    ma.a_user = ul.LoginID;
                    string count = Tunnel.Common.GetValue.getDataValue("Tunnel_Advice", "count(*)", "a_bid=1024 and a_gid=" + mtb.b_id);
                    ta.Add(ma);
                }
                Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_BUMF SET B_STATE=0 WHERE B_ID=" + mtb.b_id);//改变公文状态
                Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=1 and m_touser=" + ul.LoginID + " and m_typeid=" + mtb.b_id);//删除待办事项
                Tunnel.Common.Message.Show("操作成功!", "../MyApply/Apply_Sp.aspx");
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MyApply/Apply_Sp.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_menber tm = ul.GetUserBean(ul.LoginID);
        if (!Tunnel.Data.DESEncrypt.Encrypt(spPassword.Text.Trim()).Equals(tm.m_spassword))
        {
            Tunnel.Common.Message.back("审批密码错误"); return;
        }
        else
        {
            //这里为存储当前步骤
            mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
            mf = bf.GetModel(mtb.b_sort);
            if (mtb.b_state == 3)
            {
                Tunnel.Common.Message.back("此流程己审批结束,请勿重复审批!"); return;
            }
            else
            {
                //将当前步骤存入数据库表:Tunnel_exam
                Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
                Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
                mte.e_bid = 0;
                mte.e_endtime = DateTime.Now;
                mte.e_gid = Convert.ToInt32(Request.Params["bid"]);
                mte.e_user = ul.LoginID;
                mte.e_nextbuser = m_value.Value;
                string lastendtime = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_endtime", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
                if (!string.IsNullOrEmpty(lastendtime))
                {
                    mte.e_time = Convert.ToDateTime(lastendtime);//取得上一步的最后执行时间
                }
                else
                {
                    mte.e_time = mtb.b_time;
                }
                mte.e_nextbid = 1;
                bte.Add(mte);
                string contents = FCKeditor1.Value;
                //添加审批意见
                if (!string.IsNullOrEmpty(contents))
                {
                    Tunnel.BLL.Tunnel_Advice ta = new Tunnel.BLL.Tunnel_Advice();
                    Tunnel.Model.Tunnel_Advice ma = new Tunnel.Model.Tunnel_Advice();
                    ma.a_content = contents;
                    ma.a_bid = Convert.ToInt32(mts.s_id);
                    ma.a_gid = Convert.ToInt32(mtb.b_id);
                    ma.a_time = DateTime.Now;
                    ma.a_user = ul.LoginID;
                    string count = Tunnel.Common.GetValue.getDataValue("Tunnel_Advice", "count(*)", "a_bid=1024 and a_gid=" + Request.Params["bid"]);
                    ta.Add(ma);
                }
                Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_BUMF SET B_STATE=3 WHERE B_ID=" + Request.Params["bid"]);//改变公文状态
                Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=1 and m_touser=" + ul.LoginID + " and m_typeid=" + mtb.b_id);//删除待办事项
                Tunnel.Common.Message.Show("流程结束成功!", "../MyApply/Apply_Sp.aspx");
            }
        }
    }

    void bindflow()
    {
        string suser = "";
        mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
        Page.Title = mtb.b_title;
        DataSet ds = bte.GetList("e_gid=" + mtb.b_id + " and e_user<>0 order by e_id asc");
        StringBuilder texttop = new StringBuilder();
        texttop.Append("<tr>");
        texttop.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>1</font>步</td>");
        texttop.Append("<td align=\"left\" style=\"height: 30px; width: 30%\">&nbsp;&nbsp;发起</td>");
        texttop.Append("<td align=\"left\" style=\"height: 50%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getUname(mtb.b_user.ToString()) + "</strong> [<font color=Green>发起</font>]");
        texttop.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发起于：" + mtb.b_time.ToString() + "</td>");
        texttop.Append("<td align=\"left\" style=\"height: 30px; width: 40%\">&nbsp;&nbsp;</td>");
        texttop.Append("</tr> ");
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
                text.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>" + (currnum + 2) + "</font>步</td>");
                text.Append("<td align=\"left\" style=\"height: 30px; width: 30%\">&nbsp;&nbsp;审批</td>");
                text.Append("<td align=\"left\" style=\"height: 50%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getallUname(curruser) + " 主办</strong> [<font color=blue>办理中</font>]");
                text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + currtime + "</td>");
                text.Append("<td align=\"left\" style=\"height: 30px; width: 40%\">&nbsp;&nbsp;</td>");
                text.Append("</tr> ");
                nextb = text.ToString();
            }
        }
        toptb = texttop.ToString();
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

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
                return "审批";
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
        if (!string.IsNullOrEmpty(ulist))
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
        else
        {
            return "";
        }
    }

    public string GetAtive(string uid, string gid)
    {
        string advice = "&nbsp;";
        Tunnel.BLL.Tunnel_Advice bta = new Tunnel.BLL.Tunnel_Advice();
        if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(gid))
        {
            if (uid != "0" && gid != "0")
            {
                DataSet ds = bta.GetList("a_gid=" + gid + " and a_user=" + uid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    advice = ds.Tables[0].Rows[0]["a_content"].ToString();
                }
            }
        }
        return advice;
    }
}