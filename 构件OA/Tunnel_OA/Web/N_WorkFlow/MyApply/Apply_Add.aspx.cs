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

public partial class N_WorkFlow_MyApply_Apply_Add : System.Web.UI.Page
{
    public bool isuploads = true;
    public string scontent = "";
    public bool issheng = true;
    private bool isshen = true;
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
    Tunnel.BLL.Tunnel_step bs = new Tunnel.BLL.Tunnel_step();
    Tunnel.BLL.Tunnel_flow bf = new Tunnel.BLL.Tunnel_flow();
    Tunnel.BLL.Tunnel_bumf btb = new Tunnel.BLL.Tunnel_bumf();
    Tunnel.BLL.Tunnel_form tf = new Tunnel.BLL.Tunnel_form();
    Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
    Tunnel.Model.Tunnel_form mtf = new Tunnel.Model.Tunnel_form();
    Tunnel.Model.Tunnel_flow mf = new Tunnel.Model.Tunnel_flow();
    Tunnel.Model.Tunnel_bumf mtb = new Tunnel.Model.Tunnel_bumf();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Bind();
        }
    }

    /// <summary>
    /// 获取下一步骤序号
    /// </summary>
    /// <param name="step">当前步骤序号</param>
    /// <returns>下一步骤序号</returns>
    public string getNext(string step)
    {
        int count = bs.GetCount("s_lid=" + Request.Params["Flow"]);
        if (int.Parse(step) < count)
            return "→";
        else
            return "→完成";

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Bind();
    }

    void Bind()
    {
        try
        {
            mf = bf.GetModel(int.Parse(Request.Params["Flow"]));
            mtf = tf.GetModel(mf.f_form);
            if (mtf == null)
            {
                Tunnel.Common.Message.back("表单不存在或已删除,请与管理员联系"); return; return;
            }
            Label1.Text = fc.From_Content(mtf.f_content, "", false);//取得替换后的表单数据
            ul.UsbnLogin = ul.getUserModel(ul.LoginID);
            string bumname = Tunnel.Common.GetValue.getDataValue("Tunnel_bum", "b_name", "b_id=" + ul.UsbnLogin.m_bum);
            TextBox1.Text = bumname + mf.f_name;
            if (mf.f_isfile.ToString() == "1") isuploads = false;
            if (mf.f_state.ToString() == "0") { scontent = "审核→"; issheng = true; isshen = true; } else { scontent = ""; issheng = false; isshen = false; }
            Repeater1.DataSource = bs.GetList("s_lid=" + mf.f_id);
            Repeater1.DataBind();
            if (Repeater1.Items.Count <= 0) { Label2.Text = "本申请未设置流程,将不能保存!"; HiddenField2.Value = "0"; } else { Label2.Text = ""; HiddenField2.Value = "1"; }
        }
        catch {
            Tunnel.Common.Message.back("不正确的ID"); return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            System.Web.HttpFileCollection uploadFiles = Request.Files;
            System.Web.HttpPostedFile theFile;
            for (int i = 0; i < uploadFiles.Count; i++)
            {
                theFile = uploadFiles[i];
                if (Convert.ToDouble(theFile.ContentLength) / 1024 / 1024 > 10)
                {
                    Tunnel.Common.Message.back("附件大小不能大于10MB");
                    return;
                }
                else
                    continue;
            }
            Tunnel.Model.Tunnel_menber tm = ul.GetUserBean(ul.LoginID);
            //下一步骤ID
            string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + Request.Params["Flow"] + " and s_num=1");
            string curruser = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_lid=" + Request.Params["Flow"] + " and s_num=1");
            //如果流程没有预设步骤
            if ("".Equals(currbid))
            {
                Tunnel.Common.Message.back("本流程未预设步骤,请与管理员联系!"); return;
            }
            Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
            Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
            mf = bf.GetModel(int.Parse(Request.Params["Flow"]));
            if (mf.f_state.ToString() == "0") { isshen = true; } else { isshen = false; }
            if (!isshen)
            {
                //将当前步骤存入数据库表:Tunnel_exam
                Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
                Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
                mte.e_bid = 0;
                mte.e_endtime = DateTime.Now;
                mte.e_gid = this.sava();
                mte.e_user = ul.LoginID;
                mte.e_time = DateTime.Now;
                mte.e_nextbid = Convert.ToInt32(currbid);
                bte.Add(mte);
                string[] users = curruser.Split(',');
                foreach (string user in users)
                {
                    if (!string.IsNullOrEmpty(user))
                    {
                        tr.m_title = TextBox1.Text.Trim() + "<font color=red>(待审批)</font>";
                        tr.m_url = "N_WorkFlow/MyApply/Apply_zSp.aspx?bid=" + mte.e_gid;
                        tr.m_touser = Convert.ToInt32(user);
                        tr.m_time = DateTime.Now;
                        tr.m_type = 1;
                        tr.m_typeid = mte.e_gid;
                        tr.m_bid = Convert.ToInt32(currbid);
                        tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                        tr.m_isread = 0;
                        long messge = br.Add(tr);
                    }
                }
            }
            else
            {
                int s = this.sava();
                ul.UsbnLogin = bm.GetModel(ul.LoginID);
                DataSet dss = bm.GetList("m_bum=" + ul.UsbnLogin.m_bum);
                string userlist = "";
                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    if (Tunnel.BLL.Permission.IfHasPrimision(dr["m_id"].ToString(), "流程审核", "我的工作", false))
                    {
                        userlist = dr["m_id"].ToString();
                    }
                }
                tr.m_title = TextBox1.Text.Trim() + "<font color=red>(待审核)</font>";
                tr.m_url = "N_WorkFlow/MyApply/Apply_zSh.aspx?bid=" + s;
                tr.m_touser = (RadioButtonList3.SelectedValue == "1" ? int.Parse(m_value.Value) : Convert.ToInt32(userlist));
                tr.m_time = DateTime.Now;
                tr.m_type = 1;
                tr.m_typeid = s;
                tr.m_bid = 0;
                tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                tr.m_isread = 0;
                long messge = br.Add(tr);
            }
            Tunnel.Common.Message.Show("提交成功!", "Apply_Add.aspx?Flow=" + Request.Params["Flow"]);
        }
        catch
        {
            Tunnel.Common.Message.back("流程错误,请与管理员联系!");
        }
    }

    private int sava()
    {
        ArrayList list = new ArrayList();
        string datalist = "";
        string datafield = "";
        System.Collections.Specialized.NameObjectCollectionBase.KeysCollection keys = Request.Params.Keys;//取得所有Request的Key值
        for (int i = 0; i < keys.Count; i++)
        {
            //过滤其它Request的Key值留以DATA_开头的Key
            if (keys[i].ToString().IndexOf("DATA_") >= 0)
            {
                list.Add(keys[i].ToString());//将key值存入数组
                datafield += keys[i].ToString() + ",";//将key值存入字符串
            }
        }
        //获取表单提交过来的值
        for (int j = 0; j < list.Count; j++)
        {
            datalist += Request.Form[list[j].ToString()] + "<@Sep@>";//值用<@Sep@>隔开以便存入数据库
        }
        mtb.b_content = datalist;
        if (!string.IsNullOrEmpty(datafield))
        {
            datafield = datafield.Substring(0, datafield.Length - 1);//去掉最后的的','
        }
        mtb.b_datefield = datafield;
        if (!"".Equals(this.SaveFiles()))
        {
            if (null != Request.Form["hfile"] && !"".Equals(Request.Form["hfile"]))
            {
                mtb.b_file = Request.Form["hfile"] + "," + this.SaveFiles();//批量附件上传
            }
            else
            {
                mtb.b_file = this.SaveFiles();//批量附件上传
            }
        }
        else
        {
            if (null != Request.Form["hfile"] && !"".Equals(Request.Form["hfile"]))
            {
                mtb.b_file = Request.Form["hfile"];
            }
            else
            {
                mtb.b_file = "";
            }
        }
        mf = bf.GetModel(int.Parse(Request.Params["Flow"]));
        mtb.b_title = TextBox1.Text.Trim();
        mtb.b_time = DateTime.Now;
        mtb.b_user = ul.LoginID;
        mtf = tf.GetModel(mf.f_form);
        mtb.b_formcontent = mtf.f_content;
        mtb.b_sort = int.Parse(Request.Params["Flow"]);
        mtb.b_state = (mf.f_state == 0 ? 1 : 2);
        mtb.b_suser = (RadioButtonList3.SelectedValue == "1" ? int.Parse(m_value.Value) : 0);
        return btb.Add(mtb);
    }

    /// <summary>
    /// 批量附件上传
    /// </summary>
    /// <returns></returns>
    private string SaveFiles()
    {
        string filelist = "";
        string uploadpath = Server.MapPath("../../upload/file");
        System.Web.HttpFileCollection uploadFiles = Request.Files;
        System.Web.HttpPostedFile theFile;
        for (int i = 0; i < uploadFiles.Count; i++)
        {
            theFile = uploadFiles[i];
            string filename = theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
            string dataname = "upload/file/" + filename;
            if (filename != "")
            {
                theFile.SaveAs(uploadpath + "/" + filename);
                filelist += dataname + ",";
            }
        }
        if (filelist.Length > 0)
        {
            filelist = filelist.Substring(0, filelist.Length - 1);//去掉最后的的','
        }
        return filelist;
    }
}
