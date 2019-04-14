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
using Tunnel.BLL;
using System.IO;
using Tunnel.Model;
using System.Collections.Generic;
public partial class N_News_N_Performance_N_ManagFactory : System.Web.UI.Page
{
    #region 声明变量
    public int cuttentPage;
    private string where = "";
    private int pageSize = 20;
    private bool delState;
    private Tunnel.Model.Tunnel_Performance motel = new Tunnel.Model.Tunnel_Performance();
    private Tunnel.BLL.Tunnel_Performance rbll = new Tunnel.BLL.Tunnel_Performance();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    #endregion

    #region 加载事件
    protected void Page_Load(object sender, EventArgs e)
    {
        this.where = " Title like '%" + txtTitle.Text.Trim() + "%' AND Type = 1";

        PageBind(this.where);
    }
    #endregion

    #region 数据绑定
    public void PageBind(string where)
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_Performance";
        pb.FldName = "Id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        pb.StrWhere = where;
        if (ul.LoginID > 1 && ul.JiaoSe(ul.LoginID) != "系统管理员")
        {
            if (!string.IsNullOrEmpty(where))
                pb.StrWhere += " and CreateUser = " + ul.LoginID;
            else
                pb.StrWhere += " CreateUser = " + ul.LoginID;
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
        List<Tunnel.Model.Tunnel_Performance> modelList = new List<Tunnel.Model.Tunnel_Performance>();
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

    #region 查找事件
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        PageBind(this.where);

    }
    #endregion

    #region 获取登录用户的姓名
    public string GetUserName(string uid)
    {

        if (!string.IsNullOrEmpty(uid))
        {
            return Tunnel.Common.GetValue.getDataValue("Tunnel_menber", "m_name", "m_id=" + uid);
        }
        else
        {
            return "";

        }
    }
    #endregion

    #region 获取附件
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
                    filecontent += Tunnel.Common.GetValue.getfu(file, "", i);
                }
            }
            return filecontent;
        }
        else
        {
            return "&nbsp;";
        }

    }
    #endregion

    #region 删除事件
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandArgument);
        rbll.Delete(Id);
        cuttentPage = MTCPager1.PageIndex;
        delState = true;
        PageBind(this.where);
        string[] file = e.CommandName.Split(',');
        for (int i = 0; i < file.Length; i++)
        {
            file[i] = Request.PhysicalApplicationPath + file[i];
        }
        for (int i = 0; i < file.Length; i++)
        {
            if(System.IO.File.Exists(file[i]))
            System.IO.File.Delete(file[i]);
        }
        
    }
    #endregion
    #region 分页事件
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        PageBind(this.where);
    }
    #endregion
}
