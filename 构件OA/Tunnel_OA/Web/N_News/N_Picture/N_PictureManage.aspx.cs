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
using System.IO;

public partial class PicManage_ImageList : System.Web.UI.Page
{
    private int cuttentPage;
    private int pageSize = 24;
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private Tunnel.BLL.Tunnel_Img ti = new Tunnel.BLL.Tunnel_Img();
    private Tunnel.Model.Tunnel_Img tii = new Tunnel.Model.Tunnel_Img();
    static int theEncoding = 0;
    public string name = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            theEncoding = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                name = Request.QueryString["name"].ToString();
            }
            PageBind();
        }
    }
    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_Img";
        pb.FldName = "i_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        if (ul.LoginID == 1 || ul.JiaoSe(ul.LoginID) == "系统管理员" || ul.JiaoSe(ul.LoginID) == "总经理")
        {
            theEncoding = 1;
            pb.StrWhere = "1=1 and  i_name like '%" + name + "%' ";
        }
        else
        {
            pb.StrWhere = "1=1 and  i_name like '%" + name + "%' and i_user=" + ul.LoginID;
        }
        int count = 0;
        pb.DoCount = 1;
        ti.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        if (false)
        {

            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_Img> modelList = new List<Tunnel.Model.Tunnel_Img>();
        modelList = ti.GetList(pb, ref count);//获取分页结果

        //数据绑定
        DataList1.DataSource = modelList;
        DataList1.DataBind();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        name = TextBox1.Text.Trim();
        PageBind();
    }
    public string BindEncoding(object i_user)
    {
        int id = Convert.ToInt32(i_user);
        if (theEncoding == 1)
            return "display;";
        else
        {
            if (id == ul.LoginID)
                return "display;";
            else
                return "display:none";
        }
    }
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {

        int Id = Convert.ToInt32(e.CommandName);
        Tunnel.BLL.Tunnel_Img ti = new Tunnel.BLL.Tunnel_Img();
        Tunnel.Model.Tunnel_Img tii = new Tunnel.Model.Tunnel_Img();
        tii = ti.GetModel(Convert.ToInt32(Id));
        try
        {
            File.Delete(Server.MapPath("image\\") + tii.i_uri);
            File.Delete(Server.MapPath("image\\_") + tii.i_uri);
        }
        catch (Exception ex)
        {
            Tunnel.Common.Message.Show(ex.Message);
        }
        ti.Delete(Convert.ToInt32(Id));
        Tunnel.Common.Message.Show("删除成功！");
        string strsql = "";
        strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','信息发布>>图片管理>>删除图片。标题：" + tii.i_name + "','" + Tunnel.Common.Common.GetIp() + "',2)";
        Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
        PageBind();
    }
}
