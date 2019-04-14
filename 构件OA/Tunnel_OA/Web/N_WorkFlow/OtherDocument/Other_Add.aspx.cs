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

public partial class N_WorkFlow_OtherDocument_Other_Add : System.Web.UI.Page
{
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_bumf btb = new Tunnel.BLL.Tunnel_bumf();
    Tunnel.Model.Tunnel_bumf mtb = new Tunnel.Model.Tunnel_bumf();
    protected void Page_Load(object sender, EventArgs e)
    {

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
            string curruser = m_value.Value;
            //将当前步骤存入数据库表:Tunnel_exam
            Tunnel.BLL.Tunnel_exam bte = new Tunnel.BLL.Tunnel_exam();
            Tunnel.Model.Tunnel_exam mte = new Tunnel.Model.Tunnel_exam();
            Tunnel.Model.Tunnel_Remind tr = new Tunnel.Model.Tunnel_Remind();
            Tunnel.BLL.Tunnel_Remind br = new Tunnel.BLL.Tunnel_Remind();
            mte.e_bid = 0;
            mte.e_endtime = DateTime.Now;
            mte.e_gid = this.sava();
            mte.e_user =0;
            mte.e_time = DateTime.Now;
            mte.e_nextbuser = curruser;
            mte.e_nextbid =1;
            bte.Add(mte);
            string[] users = curruser.Split(',');
            foreach (string user in users)
            {
                if (!string.IsNullOrEmpty(user))
                {
                    tr.m_title = TextBox1.Text.Trim() + "<font color=red>(待审批)</font>";
                    tr.m_url = "N_WorkFlow/OtherDocument/Other_zSp.aspx?bid=" + mte.e_gid;
                    tr.m_touser = Convert.ToInt32(user);
                    tr.m_time = DateTime.Now;
                    tr.m_type = 1;
                    tr.m_typeid = mte.e_gid;
                    tr.m_bid = 1;
                    tr.m_callTime = Convert.ToDateTime("1800-1-1 00:00:00");
                    tr.m_isread = 0;
                    long messge = br.Add(tr);
                }
            }

            Tunnel.Common.Message.Show("提交成功!");
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
        mtb.b_content = FCKeditor1.Value;
        mtb.b_datefield = "";
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
        mtb.b_time = DateTime.Now;
        mtb.b_user = ul.LoginID;
        mtb.b_formcontent = "";
        mtb.b_sort = 0;
        mtb.b_state = 2;
        mtb.b_suser = 0;
        mtb.b_stype = 1;
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
