using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using Tunnel.BLL;
using Tunnel.Model;

public partial class N_Produce_Produce_Manage : System.Web.UI.Page
{
    #region 内部变量

    #region m_UserLogin
    Tunnel.BLL.UserLogin userLogin;
    Tunnel.BLL.UserLogin m_UserLogin
    {
        get
        {
            if (null == userLogin)
                userLogin = new Tunnel.BLL.UserLogin();
            return userLogin;
        }
    }
    #endregion
    #region m_ProduceBLL
    private Tunnel.BLL.Tunnel_Produce produceBLL;
    private Tunnel.BLL.Tunnel_Produce m_ProduceBLL
    {
        get
        {
            if (null == produceBLL)
                produceBLL = new Tunnel.BLL.Tunnel_Produce();
            return produceBLL;
        }
    }
    #endregion


    public int cuttentPage;
    private int pageSize = 30;
    private bool delState;

    string proType = "";
    string proItem = "";

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        proType = null == Request.QueryString["type"] ? "" : Request.QueryString["type"].ToString().Trim();
        proItem = null == Request.QueryString["name"] ? "" : Request.QueryString["name"].ToString().Trim();
        if (!IsPostBack)
        {
            BindDataGrid();
        }
    }
    #endregion

    #region 绑定Grid
    private void BindDataGrid()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_Produce";
        pb.FldName = "ProID";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;

        string strWhere = "";
        if (m_UserLogin.JiaoSe(m_UserLogin.LoginID).Trim().Equals("系统管理员"))
            strWhere = "ProState='N'";
        else
            strWhere = string.Format("ProState='N' AND CreateUser={0} AND ProType='{1}'",m_UserLogin.LoginID, proType);
        if (txtTitle.Text.Trim() != "")
        {
            strWhere = string.Format("{0} AND ProTitle='{1}'",strWhere, txtTitle.Text.Trim());
        }
        if (txtStarDate.Text.Trim() != "" && txtEndDate.Text.Trim() != "")
        {
            strWhere = string.Format("{0} AND CreateDate BETWEEN '{1}' AND '{2}'", strWhere, txtStarDate.Text.Trim(), txtEndDate.Text.Trim());
        }
        if (txtStarDate.Text.Trim()!="" && txtEndDate.Text.Trim()=="")
        {
            strWhere = string.Format("{0} AND CreateDate>='{1}'", strWhere, txtStarDate.Text.Trim());
        }
        if (txtStarDate.Text.Trim()=="" && txtEndDate.Text.Trim()!="")
        {
            strWhere = string.Format("{0} AND CreateDate<='{1}'", strWhere, txtEndDate.Text.Trim());
        }

        pb.StrWhere = strWhere;

        int count = 0;
        pb.DoCount = 1;
        m_ProduceBLL.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_Produce> modelList = new List<Tunnel.Model.Tunnel_Produce>();
        modelList = m_ProduceBLL.GetList(pb, ref count);//获取分页结果


        //DataSet ds = m_ProduceBLL.GetProduceData(proType, strWhere);
        //PagedDataSource pds = new PagedDataSource();
        //pds.DataSource = ds.Tables[0].DefaultView;//设置数据源(DataTable类型)
        //pds.AllowPaging = true;
        ////每页显示的行数
        ////pds.PageSize = 10;
        //AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
        //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.PageSize = AspNetPager1.PageSize;

        dgdPro.DataSource = modelList;
        dgdPro.DataBind();

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

    #region 翻页
    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        BindDataGrid();
    }
    #endregion

    #region 查询
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BindDataGrid();
    }
    #endregion

    #region 获得用户名
    private string GetUserName(string uid)
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

    #region Grid事件
    protected void dgdPro_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if ("Down".Equals(e.CommandName))
            {
                string strHead = e.Item.Cells[2].Text.Trim();
                strHead = Server.UrlEncode(e.Item.Cells[2].Text.Trim());
                strHead = strHead.Replace("+", "%20");
                Response.Clear();
                //Response.ContentType = "application/ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + strHead);
                Response.Charset = "gb2312";
                string filePath = "";   //物理路径
                filePath = Server.MapPath(Request.ApplicationPath + e.Item.Cells[5].Text.Trim() + e.Item.Cells[2].Text.Trim());
                FileStream myFile = File.OpenRead(filePath); //读取文件进入FileStream
                byte[] fileCont = new byte[myFile.Length];
                myFile.Read(fileCont, 0, (int)myFile.Length);  //将文件流中的内容转成byte数组
                Response.BinaryWrite(fileCont);
                myFile.Close();
                Response.End();
            }
            if ("Select".Equals(e.CommandName))
            {
                Response.Redirect(string.Format("Produce_Add.aspx?type={0}&name={1}&proID={2}", proType, proItem, e.Item.Cells[0].Text.Trim()));
            }
            if ("Delete".Equals(e.CommandName))
            {
                if (m_ProduceBLL.Delete(int.Parse(e.Item.Cells[0].Text.Trim()),m_UserLogin.LoginID) > 0)
                {
                    Tunnel.Common.Message.back("删除成功");
                    //BindDataGrid();
                    Response.Redirect("Produce_Manage.aspx?type=" + proType + "&name=" + Server.UrlEncode(Request.QueryString["name"].ToString().Trim()));
                }
                else
                {
                    Tunnel.Common.Message.back("删除失败");
                }
            }
        }
    }
    #endregion

    

    #region Grid项绑定事件
    protected void dgdPro_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //e.Item.Cells[2].Text = string.Format("<a href='/{0}{1}'>{1}</a>", e.Item.Cells[5].Text.Trim(), e.Item.Cells[2].Text.Trim());
            if (e.Item.Cells[2].Text.Trim()!="" && e.Item.Cells[2].Text.Trim()!="&nbsp;")
                e.Item.Cells[2].Text = GetFile(e.Item.Cells[5].Text.Trim() ,e.Item.Cells[2].Text.Trim());
            e.Item.Cells[3].Text = GetUserName(e.Item.Cells[3].Text.Trim());
            if (e.Item.Cells[4].Text.Trim()!="")
                e.Item.Cells[4].Text = Convert.ToDateTime(e.Item.Cells[4].Text.Trim()).ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
    #endregion

    #region 获得附件
    int i = 0;
    private string GetFile(string fileurl,string filelist)
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
                    filecontent += Tunnel.Common.GetValue.getfu(fileurl+file, "down", i);
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
}
