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
using System.Xml;
using System.IO;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

public partial class N_News_N_News_N_NewAdd : System.Web.UI.Page
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
    public Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private Tunnel.BLL.Tunnel_information bll = new Tunnel.BLL.Tunnel_information();
    private int TypeId = 0;
    public string titleName = "发布新闻";
    private string url = "N_NewManage.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Text = titleName;
        if (!IsPostBack)
        {
            BindDrop1();
        }
    }

    private void BindDrop1()
    {
        DropDownList1.Items.Clear();
        string strsql = " select m_name,m_id from tunnel_menber where m_id in "
                + " (select uy_uid as m_id from Tunnel_uyingshe where uy_list like '%|49|%') "
                + " and m_jiao <> 143 and m_id <> 1";
       //string strsql = "select m_name,m_id from tunnel_menber where  m_jiao <> 143 and m_id <> 1";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        foreach (DataRow rows in das.Tables[0].Rows)
        {
            ListItem item = new ListItem();
            item.Text = rows["m_name"].ToString();
            item.Value = rows["m_id"].ToString();
            DropDownList1.Items.Add(item);
        }
        DropDownList1.Items.Insert(0, new ListItem("--请选择审核人--", "0"));
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
            File.Delete(fileDirectory);
            hpf.SaveAs(fileDirectory);
        }
        else
        {
            filePaht = string.Empty;
        }
    }
    /// <summary>
    /// 发布公告
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
        model.i_title = tb_Title.Text;
        model.i_content = FCKeditor.Value;
        model.i_sort = TypeId; // 0是新闻 1公告
        model.i_user = ul.LoginID;
        model.i_hit = 0;
        model.i_time = DateTime.Now;
        model.i_Ip = Tunnel.Common.Common.GetIp();
        model.i_audituser = Convert.ToInt32(DropDownList1.SelectedValue);
        model.i_audittime = "";
        model.i_auditmark = "";
        HttpPostedFile hpf = file1.PostedFile;
        if (!hpf.FileName.Equals(""))
        {
            string fileContentType = hpf.ContentType;
            if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
            {
                Response.Write("<script>alert('附件大小不能大于10MB');</script>");

                return;
            }
            else
                CreateMdAndFilePaht(hpf);
        }
        else
            filePaht = "";
        model.i_files = filePaht; //infofiles

        int relt = -1;
        string str = titleName;
        relt = bll.Add(model);
        //-------添加消息提示--------
        Tunnel.Model.Tunnel_Remind remindmodel = new Tunnel.Model.Tunnel_Remind();
        remindmodel.m_isread = 0;
        remindmodel.m_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        remindmodel.m_title ="有新闻需要您审核<font color=red>（待审核）</font>";
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
   

}
