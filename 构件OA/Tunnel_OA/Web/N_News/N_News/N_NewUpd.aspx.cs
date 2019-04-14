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
using System.IO;
using System.Collections.Generic;
using System.Drawing;

public partial class N_News_N_Bulletin_N_GonggaoUpd : System.Web.UI.Page
{
    /// <summary>
    /// 文件目录绝对路径
    /// </summary>
    private string fileDirectory;
    /// <summary>
    /// 相对路径
    /// </summary>
    private string upDbFilePaht;
    /// <summary>
    /// 文件路径
    /// </summary>
    private string filePaht;
    private string fileName;
    private string filenames;
    public Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private Tunnel.BLL.Tunnel_information bll = new Tunnel.BLL.Tunnel_information();
    private int TypeId = 0;
    public string titleName = "修改新闻";
    private string url = "N_NewManage.aspx";
    private string i_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        RadioButton1.Enabled = true;
        RadioButton2.Enabled = true;
        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            i_id = Request.QueryString["id"].ToString();
        if (!IsPostBack)
        {
            Button1.Text = titleName;
            if (TypeId == 1)
            {
                RadioButton1.Checked = true;
            }
            else
            {
                RadioButton2.Checked = true;
            }
            
            Tunnel.Model.Tunnel_information information = new Tunnel.Model.Tunnel_information();
            information = bll.GetModel(i_id);
            tb_Title.Text = information.i_title;
            FreeTextBox1.Value = information.i_content;
            if (!information.i_files.Equals(""))
            {
                Label3.Visible = false;
                Label2.Visible = true;
                Label4.Visible = true;
                if (information.i_files.Equals(""))
                    Label2.Text = "<br/>附件名：" + information.i_files.Substring(information.i_files.LastIndexOf("\\") + 1);
                else
                    Label2.Text = "<br/>附件名：" + information.i_files.Substring(information.i_files.LastIndexOf("\\") + 1);
                Label3.Text = information.i_files;
            }
            else
            {
                Label3.Visible = false;
                Label2.Visible = false;
                Label4.Visible = false;
            }
            information = bll.GetModel(i_id);
            tb_Title.Text = information.i_title;
            FreeTextBox1.Value = information.i_content;
            if (ul.LoginID != 1 && ul.JiaoSe(ul.LoginID) != "系统管理员")
            {
                RadioButton1.Enabled = false;
                RadioButton2.Enabled = false;
            }
        }
    }
    /// <summary>
    ///  创建文件及路径参数
    /// </summary>
    public void CreateMdAndFilePaht(HttpPostedFile hpf)
    {
        //string wordMd = Request.PhysicalApplicationPath.Replace(HttpRuntime.AppDomainAppVirtualPath.Replace("/", "") + "\\", "");
        string upPaht = "upload";
        string createPaht = "\\Newsfiles";
        string fileSaveMd = createPaht + ul.LoginID + "\\";
        fileDirectory = Request.PhysicalApplicationPath + upPaht + createPaht;
        if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
        {
            fileDirectory = fileDirectory + fileSaveMd;
            if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
            {
                upDbFilePaht = upPaht + createPaht + fileSaveMd;
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                //fileName = DateTime.Now.ToFileTime().ToString();
            }
        }
        if (hpf.ContentLength > 0)
        {
            if (!string.IsNullOrEmpty(hpf.FileName))
                fileName = fileName + System.IO.Path.GetExtension(hpf.FileName);
            else
                fileName = fileName + hpf.ContentType;
            filePaht = upDbFilePaht + fileName;
            fileDirectory = fileDirectory + fileName;
            filenames = hpf.FileName;
            if (filenames.IndexOf("\\") > 0)
                filenames = filenames.Substring(filenames.LastIndexOf("\\") + 1);

            if (File.Exists(Request.PhysicalApplicationPath + Label3.Text))
                File.Delete(Request.PhysicalApplicationPath + Label3.Text);
            hpf.SaveAs(fileDirectory);
        }
        else
        {
            filenames = string.Empty;
            filePaht = string.Empty;
        }
    }
    public void MessageBox(string str, string url)
    {
        string strTemp = string.Empty;
        strTemp = "<script>";
        if (!string.IsNullOrEmpty(str))
            strTemp += "alert('" + str + "');";
        if (!string.IsNullOrEmpty(url))
            strTemp += "window.location.href='" + url + "'";
        strTemp += "</script>";
        Response.Write(strTemp);
        Response.End();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
        model.i_title = tb_Title.Text;
        model.i_content = FreeTextBox1.Value;
        if (RadioButton1.Checked)
        {
            TypeId = 1;
        }
        else
        {
            TypeId = 0;
        }
        model.i_sort = TypeId; // 0是新闻 1公告
        model.i_user = ul.LoginID;
        model.i_time = DateTime.Now;
        model.i_hit = 0;
        model.i_Ip = Tunnel.Common.Common.GetIp();
        model.i_id = Convert.ToInt32(i_id);
        HttpPostedFile hpf = file1.PostedFile;
        if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
        {
            Response.Write("<script>alert('附件大小不能大于10MB');</script>");

            return;
        }
        else
            CreateMdAndFilePaht(hpf);
        if (filePaht.Equals(""))
            model.i_files = Label3.Text;
        else
            model.i_files = filePaht; //infofiles
        if (filenames.Equals(""))
            model.i_files = Label3.Text.Replace("<br/>附件名：", "");
        else
            model.i_files = filePaht;
        int relt = -1;
        string str = titleName;

        relt = bll.Update(model);
        string strsql2 = "delete tunnel_remind where m_typeid=" + model.i_id.ToString() + " and m_type=4";
        Tunnel.Data.DbHelperSQL.ExecuteSql(strsql2);
        //-------添加消息提示--------
        Tunnel.Model.Tunnel_Remind remindmodel = new Tunnel.Model.Tunnel_Remind();
        remindmodel.m_isread = 0;
        remindmodel.m_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        remindmodel.m_title = "有新闻需要您审核<font color=red>（待审核）</font>";
        remindmodel.m_touser = model.i_audituser;
        remindmodel.m_url = "N_News/N_News/N_NewSh.aspx?Id=" + relt;
        remindmodel.m_type = 4;
        remindmodel.m_typeid = relt;
        remindmodel.m_callTime = Convert.ToDateTime("1800-01-01");
        Tunnel.BLL.Tunnel_Remind rd = new Tunnel.BLL.Tunnel_Remind();
        rd.Add(remindmodel);



        if (relt > 0)
            str += "成功！";
        else
            str += "失败！";

        // UpImange(relt);

        MessageBox(str, url);
    }
}
