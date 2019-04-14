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

public partial class N_News_N_Standard_N_StandardAdd : System.Web.UI.Page
{
    #region 声明成员变量
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
    #endregion

    #region 加载事件
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    #endregion

    #region 添加事件
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获得所需参数
        string strTitle = tb_Title.Text.Trim();
        HttpPostedFile hpf = file1.PostedFile;
        if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
        {
            Response.Write("<script>alert('附件大小不能大于10MB');</script>");
            return;
        }
        else
            CreateMdAndFilePaht(hpf);

        //写入数据库
        Tunnel.BLL.Tunnel_Standard rbll = new Tunnel.BLL.Tunnel_Standard();
        Tunnel.Model.Tunnel_Standard model = new Tunnel.Model.Tunnel_Standard();
        model.S_File = filePaht;
        model.S_Title = strTitle;
        model.S_Name = "";
        model.CreateDate = DateTime.Now;
        model.CreateUser = ul.LoginID;

        if (ul.GetUserBean(ul.LoginID) != null)
        {
            buMId = (int)ul.GetUserBean(ul.LoginID).m_id;

        }
        model.S_bum = buMId;
        int relt1 = -1;
        relt1 = rbll.Add(model);
        string str = "上传文件";
        string url = "N_Standard_Manage.aspx";
        if (relt1 > 0)
            str += "成功！";
        else
            str += "失败！";
        MessageBox(str, url);
    } 
    #endregion

    #region 页面跳转方法
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
    #endregion

    #region 创建文件及路径参数
    /// <summary>
    ///  创建文件及路径参数
    /// </summary>
    public void CreateMdAndFilePaht(HttpPostedFile hpf)
    {
        string upPaht = "upload";
        string createPaht = "\\Standard";
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
    #endregion

}
