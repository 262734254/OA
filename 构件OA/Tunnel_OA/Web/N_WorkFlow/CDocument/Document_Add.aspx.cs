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

public partial class N_WorkFlow_CDocument_Document_Add : System.Web.UI.Page
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
        string createPaht = "/Share";
        string fileSaveMd = createPaht + ul.LoginID + "/";
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
        try
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

            Tunnel.BLL.Tunnel_Cfile tc = new Tunnel.BLL.Tunnel_Cfile();
            Tunnel.BLL.Tunnel_CView tv = new Tunnel.BLL.Tunnel_CView();
            Tunnel.Model.Tunnel_Cfile mc = new Tunnel.Model.Tunnel_Cfile();
            Tunnel.Model.Tunnel_CView mv = new Tunnel.Model.Tunnel_CView();
            mc.f_title = tb_Title.Text.Trim();
            mc.f_type = Convert.ToInt32(DropDownList1.SelectedValue);
            mc.f_date = DateTime.Now;
            mc.f_content = tb_content.Value;
            mc.f_file = filePaht;
            mc.f_user = ul.LoginID;
            if (!string.IsNullOrEmpty(first_value.Value))
            {
                mc.f_first = Convert.ToInt32(first_value.Value);
            }
            else
            {
                mc.f_first = 0;
            }
            string userlist = m_value.Value;
            mc.f_other = userlist;
            int s = tc.Add(mc);
            if (!string.IsNullOrEmpty(first_value.Value))
            {
                mv.c_fid = s;
                mv.c_read = 0;
                mv.c_uid = Convert.ToInt32(first_value.Value);
                mv.c_content = "";
                tv.Add(mv);
            }
            string[] users = userlist.Split(',');
            foreach (string user in users)
            {
                if (!string.IsNullOrEmpty(user))
                {
                    mv.c_fid = s;
                    mv.c_read = 0;
                    mv.c_uid = Convert.ToInt32(user);
                    mv.c_content = "";
                    tv.Add(mv);
                }
            }
            Tunnel.Common.Message.Show("保存成功");
        }
        catch {
            Tunnel.Common.Message.back("系统故障，请与管理员联系");
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
        Response.Write("<script>fileupload(2);</script>");
        Response.Write(strTemp);
        Response.End();
    }

}
