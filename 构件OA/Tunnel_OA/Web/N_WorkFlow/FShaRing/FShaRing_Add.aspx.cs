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
using System.IO;

public partial class Common_CreateFile : System.Web.UI.Page
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
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    /// <summary>
    /// 部门ID
    /// </summary>
    private int buMId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    /// <summary>
    ///  创建文件及路径参数
    /// </summary>
    public void CreateMdAndFilePaht(HttpPostedFile hpf)
    {
        //string wordMd = Request.PhysicalApplicationPath.Replace(HttpRuntime.AppDomainAppVirtualPath.Replace("/", "") + "\\", "");
        string upPaht = "upload";
        string createPaht = "\\Share";
        string fileSaveMd = createPaht + ul.LoginID + "\\";
        fileDirectory = Request.PhysicalApplicationPath + upPaht + createPaht;
        if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
        {
            fileDirectory = fileDirectory + fileSaveMd;
            if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
            {
                upDbFilePaht = upPaht + createPaht + fileSaveMd;
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
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
            fileuploaddiv.Visible = true;
            hpf.SaveAs(fileDirectory);
        }
        else
        {
            filePaht = string.Empty;
        }
    }

    /// <summary>
    /// 上传文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获得所需参数
        string strTitle = tb_Title.Text.Trim();
        HttpPostedFile hpf = file1.PostedFile;
        string strContent = tb_content.Text.Trim();
        if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
        {
            Response.Write("<script>alert('附件大小不能大于10MB');</script>");

            return;
        }
        else
            CreateMdAndFilePaht(hpf);

        //写入数据库
        Tunnel.BLL.Tunnel_file rbll = new Tunnel.BLL.Tunnel_file();
        Tunnel.Model.Tunnel_file model = new Tunnel.Model.Tunnel_file();
        model.f_title = strTitle;
        model.f_size = hpf.ContentLength.ToString();
        model.f_file = filePaht;
        model.f_addtime = DateTime.Now;
        model.f_Content = strContent;
        model.f_sort = 0;
        model.f_user = ul.LoginID;
        model.f_Ip = Tunnel.Common.Common.GetIp();
        if (ul.GetUserBean(ul.LoginID) != null)
        {
            buMId = (int)ul.GetUserBean(ul.LoginID).m_id;

        }
        model.f_Bum = buMId;

        int relt1 = -1;
        relt1 = rbll.Add(model);

        string str = "上传文件";
        string url = "FShaRing_Manage.aspx";
        if (relt1 > 0)
            str += "成功！";
        else
            str += "失败！";
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
        //Response.Write("<script>fileupload(2);</script>");
        Response.Write(strTemp);
        Response.End();
    }

}
