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

public partial class N_WorkFlow_ODocument_Document_Edit : System.Web.UI.Page
{
    /// <summary>
    /// 是否允许上传附件
    /// </summary>
    public bool isuploads = true;
    public string hfilelist = "";
    /// <summary>
    /// 用户类
    /// </summary>
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    /// <summary>
    /// 表单类
    /// </summary>
    Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
    /// <summary>
    /// 步骤业务
    /// </summary>
    Tunnel.BLL.Tunnel_step bs = new Tunnel.BLL.Tunnel_step();
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
            return "→完成";
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Bind();
    }

    void Bind()
    {
        mtb = btb.GetModel(Convert.ToInt32(Request.Params["bid"]));
        mf = bf.GetModel(mtb.b_sort);
        mtf = tf.GetModel(mf.f_form);
        if (mtf == null)
        {
            Tunnel.Common.Message.back("表单不存在或已删除,请与管理员联系"); return;
        }
        Label1.Text = fc.From_Content(mtf.f_content,mtb.b_content, false);//取得替换后的表单数据
        TextBox1.Text = mtb.b_title;
        hfile.Value = mtb.b_file;
        if (!"".Equals(mtb.b_file))
        {
            string[] filelist = mtb.b_file.Split(',');
            foreach (string list in filelist) {
                string flist = list.Substring(list.LastIndexOf('/') + 1, list.Length - list.LastIndexOf('/') - 1);
                hfilelist += "<span><img src=\"../../image/attach.png\">" + flist + "<img style='cursor:hand' onclick=\"del(this,'" + list + "')\" alt='删除附件' src=\"../../image/remove.png\">;</span>";
            }
        }
        if (mf.f_isfile.ToString() == "1") isuploads = false;
        Repeater1.DataSource = bs.GetList("s_lid=" + mf.f_id);
        Repeater1.DataBind();
        if (Repeater1.Items.Count <= 0) { Label2.Text = "本公文未设置流程,将不能保存!"; HiddenField2.Value = "0"; } else { Label2.Text = ""; HiddenField2.Value = "1"; }
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
            this.sava();
            Tunnel.Model.Tunnel_menber tm = ul.GetUserBean(ul.LoginID);
            mtb = btb.GetModel(Convert.ToInt32(Request.Params["bid"]));
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
            mte.e_nextbid = Convert.ToInt32(currbid);
            bte.Add(mte);

            Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
            Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
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
            Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE TUNNEL_REMIND WHERE m_type=1 and m_bid=-1 and m_typeid=" + mtb.b_id);//删除待办事项
            Tunnel.Common.Message.Show("操作成功!", "Document_Add.aspx");
        }
        catch
        {
            Tunnel.Common.Message.back("流程错误,请与管理员联系!");
        }
    }

    /// <summary>
    /// 保存表单
    /// </summary>
    /// <returns></returns>
    private void sava()
    {
        mtb = btb.GetModel(Convert.ToInt32(Request.Params["bid"]));
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
        mtb.b_title = TextBox1.Text.Trim();
        mtb.b_state = 2;
        btb.Update(mtb);
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
