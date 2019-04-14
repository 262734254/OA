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
using System.Collections.Generic;
using Tunnel.Model;

public partial class Common_ShareFile : System.Web.UI.Page
{
    public int cuttentPage;

    private int pageSize = 28;

    private Tunnel.BLL.Tunnel_file rbll = new Tunnel.BLL.Tunnel_file();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PageBind();
    }

    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_file";
        pb.FldName = "f_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;

        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        pb.StrWhere = "( f_sort = 1)  or  (Charindex(',',f_juser," + ul.LoginID + ") > 0 )";
        int count = 0;

        List<Tunnel.Model.Tunnel_file> modelList = new List<Tunnel.Model.Tunnel_file>();
        modelList = rbll.GetList(pb, ref count);//获取分页结果

        pb.DoCount = 1;
        rbll.GetList(pb, ref count); //获取总条数


        //数据绑定
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }

    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        PageBind();
    }

    /// <summary>
    /// 显示用户真实姓名
    /// </summary>
    /// <param name="Id">用户Id</param>
    /// <returns></returns>
    public string ShowUserName(string UserId)
    {
        Tunnel.BLL.Tunnel_menber mbll = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
        model = mbll.GetModel(Convert.ToInt64(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.m_name;
        return strTemp;
    }

    /// <summary>
    /// 显示文件大小
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string ShowFileSize(string str)
    {
        string temp = string.Empty;
        if (!string.IsNullOrEmpty(str))
        {
            int num = Convert.ToInt32(str);
            if (num / 1024 > 0)
            {
                temp = Convert.ToString(num / 1024);
                if (num % 1024 > 0)
                    temp = Convert.ToString(Convert.ToInt32(temp) + 1);
            }
            else
            {
                temp = Convert.ToString(1);
            }
        }
        return temp;
    }

    /// <summary>
    /// 显示文件类型
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string FileTypeName(string str)
    {
        string temp = string.Empty;
        if (string.IsNullOrEmpty(str))
            return "";
        switch (str.ToLower())
        {
            case ".txt":
                temp = "文本文件";
                break;
            case ".doc":
                temp = "Office Word";
                break;
            case ".docx":
                temp = "Office Word";
                break;
            case ".xls":
                temp = "Office xls";
                break;
            case ".xlsx":
                temp = "Office xls";
                break;
            case ".ppt":
                temp = "Office 演示文稿";
                break;
            case ".pptx":
                temp = "Office 演示文稿";
                break;
            case ".jpg":
                temp = "图片文件";
                break;
            case ".gif":
                temp = "图片文件";
                break;
            case ".zip":
                temp = "压缩包";
                break;
            case ".rar":
                temp = "压缩包";
                break;
            case ".lnk":
                temp = "快捷方式";
                break;
            case ".dll":
                temp = "系统文件";
                break;
            case ".inf":
                temp = "安装信息";
                break;
            case ".exe":
                temp = "可执行文件";
                break;
            case ".bat":
                temp = "可执行文件";
                break;
            case ".xml":
                temp = "XML文件";
                break;
            case ".htm":
                temp = "网页文件";
                break;
            case ".html":
                temp = "网页文件";
                break;
            case ".iso":
                temp = "镜像文件";
                break;
            default:
                temp = "未能识别";
                break;
        }
        return temp;
    }
}
