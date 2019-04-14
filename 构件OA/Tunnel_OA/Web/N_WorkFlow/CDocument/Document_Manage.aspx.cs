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
using System.IO;

public partial class N_WorkFlow_CDocument_Document_Manage : System.Web.UI.Page
{
    public int cuttentPage;
    private string where = "";
    private int pageSize = 20;
    private bool delState;
    private Tunnel.BLL.Tunnel_Cfile rbll = new Tunnel.BLL.Tunnel_Cfile();
    private Tunnel.BLL.Tunnel_CView cview = new Tunnel.BLL.Tunnel_CView();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PageBind(this.where);
    }

    public void PageBind(string where)
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_Cfile";
        pb.FldName = "f_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        pb.StrWhere = where;
        if (ul.LoginID > 1 && ul.JiaoSe(ul.LoginID) != "系统管理员")
        {
            if(!string.IsNullOrEmpty(where))
                pb.StrWhere += " and f_user = " + ul.LoginID;
            else
                pb.StrWhere += " f_user = " + ul.LoginID;
        }
        int count = 0;
        pb.DoCount = 1;
        rbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_Cfile> modelList = new List<Tunnel.Model.Tunnel_Cfile>();
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
        PageBind(this.where);
    }

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        rbll.Delete(Id);
        cview.Delete(Id);
        cuttentPage = MTCPager1.PageIndex;
        delState = true;
        PageBind(this.where);
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

    /// <summary>
    /// 显示分类
    /// </summary>
    /// <param name="Id">分类Id</param>
    /// <returns></returns>
    public string ShowSort(string UserId)
    {
        switch (UserId) { 
            case "1":
                return "外部来文";
            case "2":
                return "普通文件";
            case "3":
                return "其它文件";
            default: return "";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.where = " f_title like '%"+TextBox1.Text.Trim()+"%'";
        if (DropDownList1.SelectedValue != "0") {
            this.where += " and f_type=" + DropDownList1.SelectedValue;
        }
        PageBind(this.where);
    }

    int i = 0;
    public string getFile(string filelist)
    {

        string filecontent = "";
        if (filelist != "")
        {
            string[] filearr = filelist.Split(',');
            foreach (string file in filearr)
            {
                if (file != "")
                {
                    i++;
                    filecontent += Tunnel.Common.GetValue.getfu(file, "edit", i);
                }
            }
            return filecontent;
        }
        else
        {
            return "&nbsp;";
        }

    }
}
