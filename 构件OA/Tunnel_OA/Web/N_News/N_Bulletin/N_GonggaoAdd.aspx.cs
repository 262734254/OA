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

public partial class N_News_N_GonggaoAdd : System.Web.UI.Page
{
    /// <summary>
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
    private int TypeId = 1;
    public string titleName = "发布公告";
    private string url = "N_GonggaoManage.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Text = titleName;
    }
    /// <summary>
    /// 发布公告
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpPostedFile hpf = file1.PostedFile;
        if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
        {
            Response.Write("<script>alert('附件大小不能大于10MB');</script>");

            return;
        }
        else
            CreateMdAndFilePaht(hpf);
        Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
        model.i_title = tb_Title.Text;
        model.i_content = FCKeditor.Value;
        model.i_sort = TypeId; // 0是新闻 1公告
        model.i_user = ul.LoginID;
        model.i_time = DateTime.Now;
        model.i_auditmark = "";
        model.i_audittime = "";
        model.i_audituser = 0;
        model.i_files = filePaht;
        model.i_Ip = Tunnel.Common.Common.GetIp();

        int relt = -1;
        string str = titleName;


        relt = bll.Add(model);
        if (relt > 0)
            str += "成功！";
        else
            str += "失败！";

        // UpImange(relt);

        MessageBox(str, url);
    }
    /// <summary>
    ///  创建文件及路径参数
    /// </summary>
    public void CreateMdAndFilePaht(HttpPostedFile hpf)
    {
        //string wordMd = Request.PhysicalApplicationPath.Replace(HttpRuntime.AppDomainAppVirtualPath.Replace("/", "") + "\\", "");
        string upPaht = "upload";
        string createPaht = "\\Bulletin";
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
            //fileuploaddiv.Visible = true;
            hpf.SaveAs(fileDirectory);
        }
        else
        {
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
}
