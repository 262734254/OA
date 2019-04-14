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

public partial class N_WorkFlow_VDocument_Document_Out : System.Web.UI.Page
{
    public int cuttentPage;
    private string where = "";
    private int pageSize = 20;
    private bool delState;
    private Tunnel.BLL.Tunnel_Cfile rbll = new Tunnel.BLL.Tunnel_Cfile();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PageBind(this.where);
    }

    public void PageBind(string where)
    {
        try
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

            if (!string.IsNullOrEmpty(where))
                pb.StrWhere += "and f_type=" + int.Parse(Request.Params["fid"]);
            else
                pb.StrWhere += " f_type=" + int.Parse(Request.Params["fid"]);
            int count = 0;
            pb.DoCount = 1;
            rbll.GetList(pb, ul.LoginID, ref count); //获取总条数

            pb.DoCount = 0;
            if (delState == true && pageSize == count)
            {
                cuttentPage = cuttentPage - 1;
                pb.PageIndex = cuttentPage;
            }
            List<Tunnel.Model.Tunnel_Cfile> modelList = new List<Tunnel.Model.Tunnel_Cfile>();
            modelList = rbll.GetList(pb, ul.LoginID, ref count);//获取分页结果


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
        catch {
            Tunnel.Common.Message.back("不正确的ID"); return;
        }
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

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.where = " f_title like '%" + TextBox1.Text.Trim() + "%'";
        PageBind(this.where);
    }

    int i = 0;
    public string getFile(string filelist)
    {

        string filecontent = "";
        if (!string.IsNullOrEmpty(filelist))
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
}
