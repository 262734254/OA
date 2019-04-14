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
using Tunnel.Model;
using Tunnel.BLL;

public partial class N_Message_MessageManage : System.Web.UI.Page
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
    #region m_MessageMode
    private Tunnel.Model.Tunnel_Message messageModel;
    private Tunnel.Model.Tunnel_Message m_MessageModel
    {
        get
        {
            if (null == messageModel)
                messageModel = new Tunnel.Model.Tunnel_Message();
            return messageModel;
        }
    }
    #endregion
    #region m_MessageBLL
    private Tunnel.BLL.Tunnel_Message messageBLL;
    private Tunnel.BLL.Tunnel_Message m_MessageBLL
    {
        get
        {
            if (null == messageBLL)
                messageBLL = new Tunnel.BLL.Tunnel_Message();
            return messageBLL;
        }
    }
    #endregion

    public int cuttentPage;
    private int pageSize = 10;
    private bool delState;

    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
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
        pb.TblName = "Tunnel_Message";
        pb.FldName = "MesID";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;

        string strWhere = "";
        if (txtTitle.Text.Trim() != "")
        {
            strWhere = string.Format("MesTitle='{0}'", txtTitle.Text.Trim());
        }
        if (txtStarDate.Text.Trim() != "" && txtEndDate.Text.Trim() != "")
        {
            strWhere = "" == strWhere ? string.Format("MesDate BETWEEN '{0}' AND '{1}'", txtStarDate.Text.Trim(), txtEndDate.Text.Trim()) : string.Format("{0} AND MesDate BETWEEN '{1}' AND '{2}'", strWhere, txtStarDate.Text.Trim(), txtEndDate.Text.Trim());
        }
        if (txtStarDate.Text.Trim() != "" && txtEndDate.Text.Trim() == "")
        {
            strWhere = "" == strWhere ? string.Format("MesDate>='{0}'", txtStarDate.Text.Trim()) : string.Format("{0} AND MesDate>='{1}'", strWhere, txtStarDate.Text.Trim());
        }
        if (txtStarDate.Text.Trim() == "" && txtEndDate.Text.Trim() != "")
        {
            strWhere = "" == strWhere ? string.Format("MesDate<='{0}'", txtEndDate.Text.Trim()) : string.Format("{0} AND MesDate<='{1}'", strWhere, txtEndDate.Text.Trim());
        }
        strWhere = "" == strWhere ? "1=1 AND (DelDate IS NULL OR DelDate='')" : strWhere + " AND (DelDate IS NULL OR DelDate='')";

        pb.StrWhere = strWhere;

        int count = 0;
        pb.DoCount = 1;
        m_MessageBLL.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }
        List<Tunnel.Model.Tunnel_Message> modelList = new List<Tunnel.Model.Tunnel_Message>();
        modelList = m_MessageBLL.GetList(pb, ref count);//获取分页结果

        //DataSet ds = m_MessageBLL.GetMessageData(m_UserLogin.LoginID, strWhere);
        //PagedDataSource pds = new PagedDataSource();
        //pds.DataSource = ds.Tables[0].DefaultView;//设置数据源(DataTable类型)
        //pds.AllowPaging = true;
        ////每页显示的行数
        ////pds.PageSize = 12;
        //AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
        //pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //pds.PageSize = AspNetPager1.PageSize;

        dgdMes.DataSource = modelList;
        dgdMes.DataBind();

        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }
    #endregion

    #region 查询
    protected void ibtnQuery_Click(object sender, ImageClickEventArgs e)
    {
        BindDataGrid();
    }
    #endregion

    #region Grid项绑定事件
    protected void dgdMes_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string content = e.Item.Cells[2].Text.Trim();
            e.Item.Cells[2].Text = content.Length > 10 ? content.Substring(0, 10)+"..." : content;
            e.Item.Cells[2].ToolTip = content;
            if (m_UserLogin.LoginID.ToString().Trim() != e.Item.Cells[4].Text.ToString())
            {
                e.Item.Cells[5].Enabled = false;
                e.Item.Cells[6].Enabled = false;
            }
            else
            {
                e.Item.Cells[5].Enabled = true;
                e.Item.Cells[5].Enabled = true;
            }
            e.Item.Cells[4].Text = GetUserName(e.Item.Cells[4].Text.Trim());
        }
    }
    #endregion

    #region Grid事件
    protected void dgdMes_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if ("Select".Equals(e.CommandName))
            {
                Response.Redirect("MessageAdd.aspx?mesID=" + e.Item.Cells[0].Text.Trim());
            }
            if ("Delete".Equals(e.CommandName))
            {
                if (m_MessageBLL.Delete(int.Parse(e.Item.Cells[0].Text.Trim())) > 0)
                {
                    Tunnel.Common.Message.back("已成功删除");
                    BindDataGrid();
                    return;
                }
            }
        }
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
}
