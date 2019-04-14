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

public partial class Common_ViewNewsAnnouncement : System.Web.UI.Page
{
    private int Id;
    private Tunnel.BLL.Tunnel_information tbll = new Tunnel.BLL.Tunnel_information();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private int cuttentPage;
    private int TypeId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!string.IsNullOrEmpty(Request.QueryString["TypeId"]))
            TypeId = Convert.ToInt32(Request.QueryString["TypeId"]);
        PageBind();
        PlBind();
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        if (Id == 0)
            return;
        Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
        List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
        model = tbll.GetModel(Id, ul.LoginID, Tunnel.Common.Common.GetIp());
        modelList.Add(model);
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
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
        Repeater2.DataSource = modelList;
        Repeater2.DataBind();
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
        model.TypeId = TypeId;
        model.ObjId = Id;
        model.UserId = ul.LoginID;
        model.Content = content;
        int relt = -1;
        relt = tbll.Add(model);
        if (relt > 0)
            Tunnel.Common.Message.Show(mess, "N_NewView.aspx?Id=" + Id + "&TypeId=" + TypeId);
    }
}
