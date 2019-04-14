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
using Tunnel.Model;
using System.Collections.Generic;

public partial class N_News_N_Standard_N_Standard_Manage : System.Web.UI.Page
{
    #region 申明成员变量
    public int cuttentPage;
    private string where = "";
    private int pageSize = 20;
    private bool delState;
    private Tunnel.BLL.Tunnel_Standard rbll = new Tunnel.BLL.Tunnel_Standard();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin(); 
    #endregion

    #region 加载事件
    protected void Page_Load(object sender, EventArgs e)
    {

        this.where = " S_Title like '%" + txtTitle.Text.Trim() + "%'";
        if (!IsPostBack)
            PageBind(this.where);
    } 
    #endregion

    #region 分页事件
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        PageBind(this.where);
    } 
    #endregion
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    #region 获取用户的姓名
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
    #endregion

    #region 删除事件
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        rbll.Delete(Id);
        cuttentPage = MTCPager1.PageIndex;
        delState = true;
        PageBind(this.where);
        string filePaht = Request.PhysicalApplicationPath + e.CommandName;//获取根目录下面的物理路径
        if (System.IO.File.Exists(filePaht))
            System.IO.File.Delete(filePaht);
    } 
    #endregion

    #region 显示文件的类型
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
    #endregion

    #region 绑定信息
    public void PageBind(string where)
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_Standard";
        pb.FldName = "Id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        pb.StrWhere = where;
        if (ul.LoginID > 1 && ul.JiaoSe(ul.LoginID) != "系统管理员")
            pb.StrWhere = " CreateUser = " + ul.LoginID;
        int count = 0;
        pb.DoCount = 1;
        rbll.GetList(pb, ref count);
        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_Standard> modelList = new List<Tunnel.Model.Tunnel_Standard>();
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
    #endregion

    protected void ImgSelect_Click(object sender, ImageClickEventArgs e)
    {
        PageBind(this.where);
    }
}
