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
using Tunnel.Model;
using System.Collections.Generic;

public partial class Common_ManageFile : System.Web.UI.Page
{
    public int cuttentPage;

    private int pageSize =28;
    private bool delState;
    private Tunnel.BLL.Tunnel_file rbll = new Tunnel.BLL.Tunnel_file();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
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

        if (ul.LoginID > 1 && ul.JiaoSe(ul.LoginID) != "系统管理员")
            pb.StrWhere = " f_user = " + ul.LoginID;
        int count = 0;
        pb.DoCount = 1;
        rbll.GetList(pb, ref count); //获取总条数
        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_file> modelList = new List<Tunnel.Model.Tunnel_file>();
        modelList = rbll.GetList(pb, ref count);//获取分页结果


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
    /// 对功能按钮的功能控制
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lb2 = (LinkButton)e.Item.FindControl("LinkButton2");
        LinkButton lb3 = (LinkButton)e.Item.FindControl("LinkButton3");
        Tunnel_file model = e.Item.DataItem as Tunnel_file;
        if (model.f_sort == 0)
            lb3.Enabled = false;
        else
            lb2.Enabled = false;

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
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        rbll.Delete(Id, ul.LoginID, Tunnel.Common.Common.GetIp());
        cuttentPage = MTCPager1.PageIndex;
        delState = true;
        PageBind();
        string filePaht = Request.PhysicalApplicationPath + e.CommandName;
        if (System.IO.File.Exists(filePaht))
            System.IO.File.Delete(filePaht);
    }

    /// <summary>
    /// 文件共享给所有用户
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        int typeId = Convert.ToInt32(e.CommandName);
        Tunnel.Model.Tunnel_file model = new Tunnel_file();
        model.f_id = Id;
        model.f_sort = typeId;
        model.f_Type = 1;
        model.f_Ip = Tunnel.Common.Common.GetIp();
        model.f_user = ul.LoginID;
        int relt = rbll.Update(model);
        Tunnel.Common.Message.Show("操作成功", "FShaRing_Manage.aspx");
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
