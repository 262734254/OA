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
    /// 科室信息实体
    /// </summary>
    Tunnel.Model.Tunnel_index tmt = new Tunnel.Model.Tunnel_index();
    Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
    Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
    Tunnel.BLL.Tunnel_step ts = new Tunnel.BLL.Tunnel_step();
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
            mtb = btb.GetModel(int.Parse(Request.Params["bid"]));

            mf = bf.GetModel(mtb.b_sort);
            mtf = tf.GetModel(mf.f_form);
            if (mtf == null)
            {
                Tunnel.Common.Message.back("表单不存在或已删除,请与管理员联系"); return;
            }
            Label1.Text = fc.From_Content(mtf.f_content, mtb.b_content, true);//取得替换后的表单数据
            Label4.Text = mtb.b_title + " (" + mtb.b_time + ")";
            Label5.Text = "<font color=red>(注：红色代表当前执行步骤,<font color=green>绿色代表已经审批通过</font>)</font>";
            formfile = Tunnel.Common.GetValue.getFile(mtb.b_file);
            if (mf.f_isfile.ToString() == "1") isuploads = false;
            if (mf.f_state.ToString() == "0" && mf.f_sort != 18) { scontent = "<font color='green'>审核→</font>"; } else { scontent = ""; }
            Repeater1.DataSource = bts.GetList("s_lid=" + mf.f_id);
            Repeater1.DataBind();
            Button4.Visible = false;
            Button5.Visible = false;
            string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbid", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
            if ("".Equals(currbid) || "0".Equals(currbid))
            {
                currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num=1");
            }
            mts = bts.GetModel(Convert.ToInt32(currbid));
            if (mts.s_isbak == 1)
            {
                Button5.Visible = true;
                Button1.Visible = false;
                Button2.Visible = false;
                spPassword.Enabled = false;
                spPassword.TextMode = TextBoxMode.SingleLine;
                spPassword.Text = "不需填写审批密码";
            }
        }
        catch
        {
            Tunnel.Common.Message.back("不正确的ID"); return;
        }
    }
    /// <summary>
    /// 显示当前步骤
    /// </summary>
    /// <param name="name">步骤名称</param>
    /// <param name="id">步骤ID</param>
    /// <returns></returns>
    public string ShowCurr(string name, string id)
    {
        //下一步骤ID
        string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbid", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
        if ("".Equals(currbid))
        {
            mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
            currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " order by s_num asc");
        }
        mts = bts.GetModel(Convert.ToInt32(currbid));
        if (mts != null)
        {
            if (long.Parse(id) == mts.s_id)
            {
                return "<font color='red'>" + name + "</font>→";
            }
            else if (Convert.ToInt32(mts.s_id) > Convert.ToInt32(id))
            {
                return "<font color='green'>" + name + "</font>→";
            }
            else
            {
                return name + "→";
            }
        }
        else
        {
            return name + "→";
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
                string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbid", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
                if ("".Equals(currbid) || "0".Equals(currbid))
                {
                    currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num=1");
                }
                mts = bts.GetModel(Convert.ToInt32(currbid));
                int cunum = mts.s_num;
                bool iscshened = true;
                int sum = bts.GetCount("s_lid=" + mtb.b_sort);
                string curruser = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_id=" + mts.s_id);
                if (!string.IsNullOrEmpty(curruser))
                {
                    string[] users = curruser.Split(',');
                    foreach (string user in users)
                    {
                        if (!string.IsNullOrEmpty(user))
                        {
                            if (user == ul.LoginID.ToString())
                            {
                                iscshened = false;
                            }
                        }
                    }
                }
                if (!iscshened || ul.JiaoSe(ul.LoginID) == "系统管理员")
                {
                    //将当前步骤存入数据库表:Tunnel_exam
                    Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
                    Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
                    mte.e_bid = Convert.ToInt32(mts.s_id);
                    mte.e_endtime = DateTime.Now;
                    mte.e_gid = Convert.ToInt32(Request.Params["bid"]);
                    mte.e_user = ul.LoginID;
                    string lastendtime = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_endtime", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
                    if (!string.IsNullOrEmpty(lastendtime))
                    {
                        mte.e_time = Convert.ToDateTime(lastendtime);//取得上一步的最后执行时间
                    }
                    else
                    {
                        mte.e_time = mtb.b_time;
                    }
                    //如果为最后一步则结束流程
                    if (cunum == sum)
                    {
                        mte.e_nextbid = 0;
                        string pid = Tunnel.Common.GetValue.getDataValue("Tunnel_flow", "f_sort", "f_id=" + mtb.b_sort);
                        //插入到公司发文
                        if ("18".Equals(pid))
                        {
                            tmt.Title = mtb.b_title;
                            tmt.TypeId = 5;
                            tmt.HtmlSource = fc.From_Content(mtb.b_formcontent, mtb.b_content, true);//取得替换后的表单数据
                            tmt.UserId = mtb.b_user;
                            Tunnel.BLL.Tunnel_information bllf = new Tunnel.BLL.Tunnel_information();
                            int relt = -1;
                            relt = bllf.Add(tmt);
                        }
                        Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_BUMF SET B_STATE=3 WHERE B_ID=" + Request.Params["bid"]);
                        Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=" + currbid + " and m_typeid=" + mtb.b_id);//删除待办事项
                        Tunnel.Common.Message.Show("流程结束成功!", "Apply_Sp.aspx");
                    }
                    else
                    {
                        string currs = "";
                        if (!"".Equals(currbid) || !"0".Equals(currbid))
                        {
                            string nid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num>" + mts.s_num + " order by s_num asc");
                            currs = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_lid=" + mtb.b_sort + " and s_num>" + mts.s_num + " order by s_num asc");
                            if (string.IsNullOrEmpty(nid))
                            {
                                nid = "0";
                            }
                            mte.e_nextbid = long.Parse(nid);
                        }
                        else
                        {
                            mte.e_nextbid = 0;
                        }
                        if (!string.IsNullOrEmpty(currs))
                        {
                            Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
                            Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
                            string[] users = currs.Split(',');
                            foreach (string user in users)
                            {
                                if (!string.IsNullOrEmpty(user))
                                {
                                    tr.m_title = mtb.b_title + "<font color=red>(待审批)</font>";
                                    tr.m_url = "N_WorkFlow/MyApply/Apply_zSp.aspx?bid=" + mtb.b_id;
                                    tr.m_touser = Convert.ToInt32(user);
                                    tr.m_time = DateTime.Now;
                                    tr.m_type = 1;
                                    tr.m_typeid = Convert.ToInt32(mtb.b_id);
                                    tr.m_bid = Convert.ToInt32(mte.e_nextbid);
                                    tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                                    tr.m_isread = 0;
                                    long messge = br.Add(tr);
                                }
                            }
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
                        string count = Tunnel.Common.GetValue.getDataValue("Tunnel_Advice", "count(*)", "a_bid=" + mf.f_id + " and a_gid=" + Request.Params["bid"]);
                        if (int.Parse(count) > 0)
                        {
                            ta.Update(ma);
                        }
                        else
                        {
                            ta.Add(ma);
                        }
                    }
                    Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=" + currbid + " and m_typeid=" + mtb.b_id);//删除待办事项
                    Tunnel.Common.Message.Show("操作成功!", "Apply_Sp.aspx");
                }
                else
                {
                    Tunnel.Common.Message.back("此流程己审批通过,请勿重复审批!"); return;
                }
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
            mf = bf.GetModel(mtb.b_sort);
            if (mtb.b_state == 3)
            {
                Tunnel.Common.Message.back("此公文己审批结束,请勿重复审批!"); return;
            }
            else
            {
                string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbid", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
                if ("".Equals(currbid) || "0".Equals(currbid))
                {
                    currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num=1");
                }
                mts = bts.GetModel(Convert.ToInt32(currbid));
                bool iscshened = true;
                int sum = bts.GetCount("s_lid=" + mtb.b_sort);
                string curruser = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_id=" + mts.s_id);
                if (!string.IsNullOrEmpty(curruser))
                {
                    string[] users = curruser.Split(',');
                    foreach (string user in users)
                    {
                        if (!string.IsNullOrEmpty(user))
                        {
                            if (user == ul.LoginID.ToString())
                            {
                                iscshened = false;
                            }
                        }
                    }
                }
                if (!iscshened || ul.JiaoSe(ul.LoginID) == "系统管理员")
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
                    string flowtype = Tunnel.Common.GetValue.getDataValue("Tunnel_flow", "f_sort", "f_id=" + mtb.b_sort);
                    if ("18".Equals(flowtype))
                    {
                        tr.m_url = "N_WorkFlow/ODocument/Document_Edit.aspx?Bid=" + mtb.b_id;

                    }
                    else
                    {
                        tr.m_url = "N_WorkFlow/MyApply/Apply_Edit.aspx?Bid=" + mtb.b_id + "&Flow=" + mtb.b_sort;
                    }
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
                        ma.a_bid = Convert.ToInt32(mts.s_id);
                        ma.a_gid = Convert.ToInt32(mtb.b_id);
                        ma.a_time = DateTime.Now;
                        ma.a_user = ul.LoginID;
                        string count = Tunnel.Common.GetValue.getDataValue("Tunnel_Advice", "count(*)", "a_bid=" + mf.f_id + " and a_gid=" + mtb.b_id);
                        if (int.Parse(count) > 0)
                        {
                            ta.Update(ma);
                        }
                        else
                        {
                            ta.Add(ma);
                        }
                    }
                    Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=" + currbid + " and m_typeid=" + mtb.b_id);//删除待办事项
                    Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_BUMF SET B_STATE=0 WHERE B_ID=" + mtb.b_id);//改变公文状态
                    Tunnel.Common.Message.Show("操作成功!", "Apply_Sp.aspx");
                }
                else
                {
                    Tunnel.Common.Message.back("此流程己审批通过,请勿重复审批!"); return;
                }
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Apply_Sp.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
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
            string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbid", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
            if ("".Equals(currbid) || "0".Equals(currbid))
            {
                currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num=1");
            }
            mts = bts.GetModel(Convert.ToInt32(currbid));
            int cunum = mts.s_num;
            bool iscshened = true;
            int sum = bts.GetCount("s_lid=" + mtb.b_sort);
            string curruser = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_id=" + mts.s_id);
            if (!string.IsNullOrEmpty(curruser))
            {
                string[] users = curruser.Split(',');
                foreach (string user in users)
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        if (user == ul.LoginID.ToString())
                        {
                            iscshened = false;
                        }
                    }
                }
            }
            if (!iscshened || ul.JiaoSe(ul.LoginID) == "系统管理员")
            {
                //将当前步骤存入数据库表:Tunnel_exam
                Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
                Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
                mte.e_bid = Convert.ToInt32(mts.s_id);
                mte.e_endtime = DateTime.Now;
                mte.e_gid = Convert.ToInt32(Request.Params["bid"]);
                mte.e_user = ul.LoginID;
                string lastendtime = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_endtime", "e_gid=" + Request.Params["bid"] + " order by e_id desc");
                if (!string.IsNullOrEmpty(lastendtime))
                {
                    mte.e_time = Convert.ToDateTime(lastendtime);//取得上一步的最后执行时间
                }
                else
                {
                    mte.e_time = mtb.b_time;
                }
                //如果为最后一步则结束流程
                if (cunum == sum)
                {
                    mte.e_nextbid = 0;
                    string pid = Tunnel.Common.GetValue.getDataValue("Tunnel_flow", "f_sort", "f_id=" + mtb.b_sort);
                    //插入到公司发文
                    if ("18".Equals(pid))
                    {
                        tmt.Title = mtb.b_title;
                        tmt.TypeId = 5;
                        tmt.HtmlSource = fc.From_Content(mtb.b_formcontent, mtb.b_content, true);//取得替换后的表单数据
                        tmt.UserId = mtb.b_user;
                        Tunnel.BLL.Tunnel_information bllf = new Tunnel.BLL.Tunnel_information();
                        int relt = -1;
                        relt = bllf.Add(tmt);
                    }
                    Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_BUMF SET B_STATE=3 WHERE B_ID=" + Request.Params["bid"]);
                    Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=" + currbid + " and m_typeid=" + mtb.b_id);//删除待办事项
                    Tunnel.Common.Message.Show("流程结束成功!", "Apply_Sp.aspx");
                }
                else
                {
                    string currs = "";
                    if (!"".Equals(currbid) || !"0".Equals(currbid))
                    {
                        string nid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num>" + mts.s_num + " order by s_num asc");
                        currs = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_lid=" + mtb.b_sort + " and s_num>" + mts.s_num + " order by s_num asc");
                        if (string.IsNullOrEmpty(nid))
                        {
                            nid = "0";
                        }
                        mte.e_nextbid = long.Parse(nid);
                    }
                    else
                    {
                        mte.e_nextbid = 0;
                    }
                    if (!string.IsNullOrEmpty(currs))
                    {
                        Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
                        Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
                        string[] users = currs.Split(',');
                        foreach (string user in users)
                        {
                            if (!string.IsNullOrEmpty(user))
                            {
                                tr.m_title = mtb.b_title + "<font color=red>(待审批)</font>";
                                tr.m_url = "N_WorkFlow/MyApply/Apply_zSp.aspx?bid=" + mtb.b_id;
                                tr.m_touser = Convert.ToInt32(user);
                                tr.m_time = DateTime.Now;
                                tr.m_type = 1;
                                tr.m_typeid = Convert.ToInt32(mtb.b_id);
                                tr.m_bid = Convert.ToInt32(mte.e_nextbid);
                                tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                                tr.m_isread = 0;
                                long messge = br.Add(tr);
                            }
                        }
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
                    string count = Tunnel.Common.GetValue.getDataValue("Tunnel_Advice", "count(*)", "a_bid=" + mf.f_id + " and a_gid=" + Request.Params["bid"]);
                    if (int.Parse(count) > 0)
                    {
                        ta.Update(ma);
                    }
                    else
                    {
                        ta.Add(ma);
                    }
                }
                Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=" + currbid + " and m_typeid=" + mtb.b_id);//删除待办事项
                Tunnel.Common.Message.Show("操作成功!", "Apply_Sp.aspx");
            }
            else
            {
                Tunnel.Common.Message.back("此流程己审批通过,请勿重复审批!"); return;
            }
        }
    }

    void bindflow()
    {
        string bWhere = "";
        mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
        mf = bf.GetModel(mtb.b_sort);
        if (mf.f_sort == 18) bWhere = " and e_bid<>0"; else bWhere = "";
        Page.Title = mtb.b_title;
        DataSet ds = bte.GetList("e_gid=" + mtb.b_id + bWhere + " order by e_id asc");
        StringBuilder text = new StringBuilder();
        StringBuilder texttop = new StringBuilder();
        texttop.Append("<tr>");
        texttop.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>1</font>步</td>");
        texttop.Append("<td align=\"left\" style=\"height: 30px; width: 20%\">&nbsp;&nbsp;发起</td>");
        texttop.Append("<td align=\"left\" style=\"height: 30%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getUname(mtb.b_user.ToString()) + "</strong> [<font color=Green>发起</font>]");
        texttop.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发起于：" + mtb.b_time.ToString() + "</td>");
        texttop.Append("<td align=\"left\" style=\"height: 30px; width: 40%\">&nbsp;<td>");
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
                    text.Append("<td align=\"left\" style=\"height: 30px; width: 20%\">&nbsp;&nbsp;审核</td>");
                    text.Append("<td align=\"left\" style=\"height: 30%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getallUname(suser) + " 主办</strong> [<font color=blue>审核中</font>]");
                    text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + mtb.b_time.ToString() + "</td>");
                    text.Append("<td align=\"left\" style=\"height: 30px; width: 40%\">&nbsp;&nbsp;</td>");
                    text.Append("</tr> ");
                }
                else
                {
                    text.Append("<tr>");
                    text.Append("<td align=\"center\" colspan='4' style=\"height: 30px; width: 10%;color:red\">没有设置审核人,请与管理员联系!</td>");
                    text.Append("</tr> ");
                }
            }
            else
            {
                text.Append("<tr>");
                text.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>2</font>步</td>");
                text.Append("<td align=\"left\" style=\"height: 30px; width: 20%\">&nbsp;&nbsp;审核</td>");
                text.Append("<td align=\"left\" style=\"height: 30%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + getUname(mtb.b_suser.ToString()) + " 主办</strong> [<font color=blue>审核中</font>]");
                text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + mtb.b_time.ToString() + "</td>");
                text.Append("<td align=\"left\" style=\"height: 30px; width: 40%\">&nbsp;&nbsp;</td>");
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
                    nextnum = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_num", "s_id=" + mts.s_id);
                    nextname = getname(mts.s_id.ToString());
                    nextuser = getallUname(mts.s_zid.ToString());
                }
                else
                {
                    nextname = "步骤不存在或已删除";
                    nextuser = nextnum = "无";
                }
                text.Append("<tr>");
                text.Append("<td align=\"center\" style=\"height: 30px; width: 10%;\">第<font color=red>" + (currnum + (bWhere == "" ? 2 : 1)) + "</font>步</td>");
                text.Append("<td align=\"left\" style=\"height: 30px; width: 20%\">&nbsp;&nbsp;" + "序号" + nextnum + "：" + nextname + "</td>");
                text.Append("<td align=\"left\" style=\"height: 30%\">&nbsp;&nbsp;<strong style=\"color:Red\">" + nextuser + " 主办</strong> [<font color=blue>办理中</font>]");
                text.Append("<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开始于：" + currtime + "</td>");
                text.Append("<td align=\"left\" style=\"height: 30px; width: 40%\">&nbsp;&nbsp;</td>");
                text.Append("</tr> ");
                nextb = text.ToString();
            }
        }
        toptb = texttop.ToString();
        Repeater2.DataSource = ds;
        Repeater2.DataBind();
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

    public string GetAtive(string bid, string gid)
    {
        string advice = "&nbsp;";
        Tunnel.BLL.Tunnel_Advice bta = new Tunnel.BLL.Tunnel_Advice();
        if (!string.IsNullOrEmpty(bid) && !string.IsNullOrEmpty(gid))
        {
            if (bid != "0" && gid != "0")
            {
                DataSet ds = bta.GetList("a_gid=" + gid + " and a_bid=" + bid);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    advice = ds.Tables[0].Rows[0]["a_content"].ToString();
                }
            }
        }
        return advice;
    }
}