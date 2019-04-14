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

public partial class grzm_RecycleMessage : System.Web.UI.Page
{
    public int cuttentPage;

    private int pageSize = 30;
    private bool delState;
    private Tunnel.BLL.Tunnel_mail mbll = new Tunnel.BLL.Tunnel_mail();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PageBind();
    }
    //批量删除操作
    protected void btnDel_Click(object sender, EventArgs e)
    {

        System.Web.UI.HtmlControls.HtmlInputCheckBox CBoxDelete;

        foreach (RepeaterItem rtitem in this.Repeater1.Items)
        {
            CBoxDelete = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rtitem.FindControl("cb1");
            LinkButton lik = (LinkButton)rtitem.FindControl("LinkButton1");
            if (CBoxDelete.Checked && lik.Enabled)
            {
                string id = ((HtmlInputHidden)rtitem.FindControl("SelectCode")).Value;
                int Id = Convert.ToInt32(lik.CommandArgument);
                int num = 0;
                mbll.Delete(Id, ul.LoginID, Tunnel.Common.Common.GetIp(), ref num);
                Tunnel.BLL.Tunnel_Remind rd = new Tunnel.BLL.Tunnel_Remind();
                string strsql = "";
                strsql = "delete [Tunnel_Remind] where m_typeid=" + Id;
                int reulst = Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
                cuttentPage = MTCPager1.PageIndex;
                delState = true;

                if (!string.IsNullOrEmpty(lik.CommandName))
                {
                    if (num == 1)
                    {
                        string filePaht = Request.PhysicalApplicationPath + lik.CommandName;
                        if (System.IO.File.Exists(filePaht))
                            System.IO.File.Delete(filePaht);
                    }
                }
            }
        }
        PageBind();
    }


    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_mail";
        pb.FldName = "m_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;


        pb.StrWhere = " (m_sort=1 and m_main = 1 and m_from =" + ul.LoginID + " ) or (m_sort=1 and m_main = 0 and m_to =" + ul.LoginID + ")";
        int count = 0;
        pb.DoCount = 1;
        mbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_mail> modelList = new List<Tunnel.Model.Tunnel_mail>();
        modelList = mbll.GetList(pb, ref count);//获取分页结果


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
        int num = 0;
        mbll.Delete(Id, ul.LoginID, Tunnel.Common.Common.GetIp(), ref num);
        Tunnel.BLL.Tunnel_Remind rd = new Tunnel.BLL.Tunnel_Remind();
        string strsql = "";
        strsql = "delete [Tunnel_Remind] where m_typeid=" + Id;
        int reulst=Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
        cuttentPage = MTCPager1.PageIndex;
        delState = true;
        PageBind();

        if (!string.IsNullOrEmpty(e.CommandName))
        {
            if (num == 1)
            {
                string filePaht = Request.PhysicalApplicationPath + e.CommandName;
                if (System.IO.File.Exists(filePaht))
                    System.IO.File.Delete(filePaht);
            }
        }
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
