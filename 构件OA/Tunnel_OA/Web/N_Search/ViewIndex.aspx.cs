using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Tunnel.Model;
using System.Xml;

public partial class N_Index_ViewIndex : System.Web.UI.Page
{
    private Tunnel.BLL.Tunnel_information tbll = new Tunnel.BLL.Tunnel_information();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public int userId;
    private int typeId;
    public string title;
    public string setDate;
    public string content;
    public string[] image;
    public string htmlSource;
    public string str = string.Empty;
    private int cuttentPage;
    public string[] ids;
    public int Id;
    public string fujian;
    private int lanmuId;
    private int bum_id = 0;
    protected void Page_Init(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["typeId"]))
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["lanmuId"]))
            lanmuId = Convert.ToInt32(Request.QueryString["lanmuId"]);
        if (!string.IsNullOrEmpty(Request.QueryString["bum_id"]))
            bum_id = Convert.ToInt32(Request.QueryString["bum_id"]);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            PlBind();
            PageBind();
        }
    }
   
    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
        model = tbll.GetModel(Convert.ToInt64(Id));
        title = model.Title;
        content = model.Content;
        setDate = model.SetDate;
        htmlSource = model.HtmlSource;
        userId = model.UserId;
        if (!string.IsNullOrEmpty(model.Files))
            fujian = "<a href='../" + model.Files + "' style='color: blue' >点击下载附件</a>";
    }

    /// <summary>
    /// 取得图片信息
    /// </summary>
    /// <param name="htmlcontent"></param>
    /// <returns></returns>
    public string From_Content(string htmlcontent)
    {
        string str = string.Empty;
        string content = htmlcontent.Replace("\n", "").ToLower();
        content = content.Replace("\r", "");
        content = content.Replace("\t", "");
        string input_tag = @"(<img)((.|\n)*?)(>)";
        MatchCollection mx = Regex.Matches(content, input_tag);
        foreach (Match match in mx)
        {
            if (Regex.IsMatch(match.Value, @"(<img)((.|\n)*?)(>)"))
            {
                if (string.IsNullOrEmpty(str))
                    str = match.Value;
                else
                    str = match.Value + "|" + str;
            }
        }
        return str;
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
        int newTypeId = Convert.ToInt32(typeId.ToString()) + 2;
        pb.StrWhere = " TypeId=" + newTypeId + " and ObjId =" + Id;
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

        model.TypeId = typeId + 2;
        model.ObjId = Id;
        model.UserId = ul.LoginID;
        model.Content = content;
        int relt = -1;
        relt = tbll.Add(model);
        if (relt > 0)
            Tunnel.Common.Message.Show(mess, "ViewIndex.aspx?Id=" + Id + "&TypeId=" + typeId);
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
}
