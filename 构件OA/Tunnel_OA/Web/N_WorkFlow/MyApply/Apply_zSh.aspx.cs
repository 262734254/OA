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

public partial class N_WorkFlow_MyApply_Apply_zSh : System.Web.UI.Page
{
    /// <summary>
    /// 是否允许上传附件
    /// </summary>
    public bool isuploads = true;

    public string formfile = "";
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
            mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
            mf = bf.GetModel(mtb.b_sort);
            mtf = tf.GetModel(mf.f_form);
            Label1.Text = fc.From_Content(mtf.f_content, mtb.b_content, true);//取得替换后的表单数据
            Label4.Text = mtb.b_title + " (" + mtb.b_time + ")";
            formfile = Tunnel.Common.GetValue.getFile(mtb.b_file);
            if (mf.f_isfile.ToString() == "1") isuploads = false;
            Repeater1.DataSource = bts.GetList("s_lid=" + mf.f_id);
            Repeater1.DataBind();
        }
        catch {
            Tunnel.Common.Message.back("不正确的ID"); return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Tunnel.Model.Tunnel_menber tm = ul.GetUserBean(ul.LoginID);
            mtb = btb.GetModel(int.Parse(Request.Params["bid"]));
            //下一步骤ID
            string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_id", "s_lid=" + mtb.b_sort + " and s_num=1");
            string curruser = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_lid=" + mtb.b_sort + " and s_num=1");
            //如果流程没有预设步骤
            if ("".Equals(currbid))
            {
                Tunnel.Common.Message.back("本流程未预设步骤,请与管理员联系!"); return;
            }
            //将当前步骤存入数据库表:Tunnel_exam
            Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
            Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
            mte.e_bid = 0;
            mte.e_endtime = DateTime.Now;
            mte.e_gid = Convert.ToInt32(mtb.b_id);
            mte.e_user = ul.LoginID;
            mte.e_time = DateTime.Now;
            mte.e_nextbuser = "";
            mte.e_nextbid = Convert.ToInt32(currbid);
            bte.Add(mte);
            if (!string.IsNullOrEmpty(curruser))
            {
                Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
                Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
                string[] users = curruser.Split(',');
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
                        tr.m_bid = Convert.ToInt32(currbid);
                        tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                        tr.m_isread = 0;
                        long messge = br.Add(tr);
                    }
                }
            }
            Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_BUMF SET B_STATE=2 WHERE B_ID=" + mtb.b_id);//改变公文状态
            Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=0 and m_typeid=" + mtb.b_id);//删除待办事项
            Tunnel.Common.Message.Show("操作成功,审核通过!", "Apply_SP.aspx");
        }
        catch
        {
            Tunnel.Common.Message.back("流程审核错误,请与管理员联系!");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        mtb = btb.GetModel(int.Parse(Request.Params["bid"]));

        #region 消息提示
        Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
        Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
        tr.m_title = mtb.b_title + "<font color=red>(审核没有通过)</font>";
        tr.m_url = "N_WorkFlow/MyApply/Apply_Edit.aspx?Bid=" + mtb.b_id+"&Flow="+mtb.b_sort;
        tr.m_touser = Convert.ToInt32(mtb.b_user);
        tr.m_time = DateTime.Now;
        tr.m_type = 1;
        tr.m_typeid = Convert.ToInt32(mtb.b_id);
        tr.m_bid = -1;
        tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
        tr.m_isread = 0;
        long messge = br.Add(tr);
        #endregion

        Tunnel.Data.DbHelperSQL.ExecuteSql("UPDATE TUNNEL_BUMF SET B_STATE=-1 WHERE B_ID=" + mtb.b_id);//改变公文状态
        Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=0 and m_typeid=" + mtb.b_id);//删除待办事项
        Tunnel.Common.Message.Show("操作成功,审核不通过!", "Apply_SP.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Apply_SP.aspx");
    }

    public string ShowCurr(string name, string id)
    {
        return name + "→";
    }
}
