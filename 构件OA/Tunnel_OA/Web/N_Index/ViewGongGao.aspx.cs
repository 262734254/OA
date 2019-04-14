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
using System.Collections.Generic;
using Tunnel.Model;
using System.Xml;

public partial class N_Index_ViewGongGao : System.Web.UI.Page
{
    public string fujian;
    public string htmlSource;
    public string i_title;
    public string i_user;
    public string i_time;
    public string i_content;
    public int Id;
    public string imageName;
    public int TypeId;
    private Tunnel.BLL.Tunnel_information tbll = new Tunnel.BLL.Tunnel_information();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public int userId;
    public string str;
    private int cuttentPage;
    private int typeId = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["typeId"]))
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        WriteSiteMap(typeId);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = ul.LoginID;
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!string.IsNullOrEmpty(Request.QueryString["TypeId"]))
            TypeId = Convert.ToInt32(Request.QueryString["TypeId"]);
        if (!IsPostBack)
        {
            PageBind();
            PlBind();
        }
    }
    /// <summary>
    /// 文章列表 文章浏览 公告栏 新闻栏
    /// </summary>
    /// <param name="num"></param>
    public void WriteSiteMap(int num)
    {
        Master.FindControl("Panel1").Visible = false;
        System.Web.UI.HtmlControls.HtmlGenericControl div = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("Panel2");
        string str = div.InnerHtml;
        div.Visible = true;
        Style sty = new Style();
        div.Style.Add(HtmlTextWriterStyle.Display, "''");
            Tunnel.Model.Tunnel_SelType model = new Tunnel_SelType();
            Tunnel.BLL.SelType stBll;
            Tunnel.BLL.Tunnel_bum tbBll = new Tunnel.BLL.Tunnel_bum();
            string temp = "";
            switch (typeId)
            {
                case 1:
                    temp = "公司公告";
                    model.BumName = "";
                    typeId = -1;
                    break;
                case 0:
                    temp = "公司新闻";
                    model.BumName = "";
                    break;
                case -1:
                    temp = "公司公告";
                    model.BumName = "";
                    typeId = -1;
                    break;
            }
            div.InnerHtml = "<font class='titlfontson'><span><a title='首页' href='/Index.aspx'>首页</a></span>"
                + "<span> &gt; </span>"
                + "<span><a title='" + temp + "' href='/N_Index/DataTypeList.aspx?typeid=" + typeId + "'>" + temp + "</a></span>"
                + "<span> &gt; </span>"
                + "<span>详细信息</span>"
                + "</font>";
    }
    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        if (Id == 0)
            return;
        Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
        model = tbll.GetModel(Id, ul.LoginID, Tunnel.Common.Common.GetIp());
        i_title = model.i_title;
        i_user = ShowUserName(model.i_user.ToString());
        i_time = model.i_time.ToString();
        i_content = model.i_content;
        if (!string.IsNullOrEmpty(model.i_files))
            fujian = "<a href='../" + model.i_files + "' style='color: blue' >点击下载附件</a>";
        //if (model.i_files != null && model.i_files != "")
        //{ 
        //    i_content+="<img src='/"+model.i_files+"'>";
        //}
        imageName = Id + ".jpg";
        string temp = Request.PhysicalApplicationPath + "upload/UpGongGaoImage/" + Id + ".jpg";
        if (System.IO.File.Exists(temp) == false)
        {
            imageName = Id + ".gif";
            temp = Request.PhysicalApplicationPath + "upload/UpGongGaoImage/" + Id + ".gif";
            if (System.IO.File.Exists(temp) == false)
                str = "none";
            else
                str = "";
        }
        else
            str = "";
    }

    public void PlBind()
    {
        List<Tunnel.Model.Tunnel_viewTable> modelList = new List<Tunnel.Model.Tunnel_viewTable>();
        PageBase pb = new PageBase();
        pb.TblName = "ViewTable";
        pb.FldName = "id";
        pb.ProcedureName = "pagination";
        pb.PageSize = 10;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        pb.StrWhere = " TypeId=" + TypeId + " and ObjId =" + Id;
        int count = 0;
        pb.DoCount = 1;
        tbll.GetList(pb, ref count); //获取总条数
        pb.DoCount = 0;
        modelList = tbll.GetList2(pb, ref count);
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
        MTCPager1.PageSize = 10;
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
        PlBind();
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
    /// 快速标记
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {
        AddDate("已读", 0);
    }
    /// <summary>
    /// 评论
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Click(object sender, EventArgs e)
    {
        AddDate(btTitle.Text.Trim(), 1);
    }

    public void AddDate(string content, int num)
    {
        string mess = string.Empty;
        if (num == 1)
            mess = "发布成功!";
        else
            mess = "标记成功!";
        Tunnel.Model.Tunnel_viewTable model = new Tunnel.Model.Tunnel_viewTable();
        model.TypeId = TypeId;
        model.ObjId = Id;
        model.UserId = ul.LoginID;
        model.Content = content;
        int relt = -1;
        relt = tbll.Add(model);
        if (relt > 0)
            Tunnel.Common.Message.Show(mess, "ViewGongGao.aspx?Id=" + Id + "&TypeId=" + TypeId + "&lanmuId=" + Request["lanmuId"]);
    }
}
