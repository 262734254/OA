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

public partial class N_Exchange_N_ExternalMail_N_MailManage : System.Web.UI.Page
{
    public int cuttentPage;

    private int pageSize = 28;
    private bool delState;
    private Tunnel.BLL.Tunnel_report rbll = new Tunnel.BLL.Tunnel_report();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PageBind();
    }

    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_report";
        pb.FldName = "r_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;

        if (ul.LoginID > 1 && ul.JiaoSe(ul.LoginID) != "系统管理员")
            pb.StrWhere = " r_user = " + ul.LoginID;
        int count = 0;
        pb.DoCount = 1;
        rbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_report> modelList = new List<Tunnel.Model.Tunnel_report>();
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
