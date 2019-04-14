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
using Tunnel.BLL;
using Tunnel.Model;

public partial class N_News_N_EntryByTheDepartmentOf_N_XJBTypeAdd : System.Web.UI.Page
{
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
    private Tunnel.BLL.Tunnel_xjbType xjbTypeBLL;
    private Tunnel.BLL.Tunnel_xjbType m_xjbTypeBLL
    {
        get
        {
            if (null == xjbTypeBLL)
                xjbTypeBLL = new Tunnel.BLL.Tunnel_xjbType();
            return xjbTypeBLL;
        }
    }
    private Tunnel.Model.Tunnel_xjbType xjbTypeModel;
    private Tunnel.Model.Tunnel_xjbType m_xjbTypeModel
    {
        get
        {
            if (null == xjbTypeModel)
                xjbTypeModel = new Tunnel.Model.Tunnel_xjbType();
            return xjbTypeModel;
        }
        set
        {
            xjbTypeModel = value;
        }
    }
    
    public int cuttentPage;
    private int pageSize = 10;
    private bool delState;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitPage();
        }
    }

    #region 保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtname.Text.Trim() == "")
        {
            Tunnel.Common.Message.back("请输入项经部名称");
            return;
        }
        
        m_xjbTypeModel.Typename = txtname.Text.Trim();
        m_xjbTypeModel.Parentid = 0;
        m_xjbTypeModel.Typeid = 0;
        m_xjbTypeModel.Url = "/N_Index/xjb.aspx";
        if (cboxDate.Checked)
        {
            m_xjbTypeModel.IsStop = "Y";
        }
        else
        {
            m_xjbTypeModel.IsStop = "N";
        }
        m_xjbTypeModel.UserID = m_UserLogin.LoginID;
        if (ViewState["STATE"].ToString().Trim() == "U")
        {
            m_xjbTypeModel.Id = int.Parse(hidValue.Value.Trim());
            if (m_xjbTypeBLL.Update(m_xjbTypeModel) > 0)
            {
                //Tunnel.Common.Message.back("保存成功");
                InitPage();
            }
        }
        else
        {
            if (m_xjbTypeBLL.Add(m_xjbTypeModel) > 0)
            {
                //Tunnel.Common.Message.back("保存成功");
                InitPage();
            }
        }
    }
    #endregion

    #region 初始页面
    private void InitPage()
    {
        txtname.Text = "";
        ddlStop.SelectedIndex = -1;
        cboxDate.Checked = false;
        BindGrid();
        ViewState["STATE"] = "N";
        if (m_UserLogin.JiaoSe(m_UserLogin.LoginID).Trim().Equals("系统管理员"))
            Button1.Enabled = true;
        else
            Button1.Enabled = false;
    }
    #endregion

    #region BindGrid
    private void BindGrid()
    {
        string strWhere = "1=1";
        if (txtTitle.Text.Trim() != "")
        {
            strWhere += string.Format(" AND typename='{0}'", txtTitle.Text.Trim());
        }
        if (ddlStop.SelectedIndex == 1)
        {
            strWhere += " AND IsStop='Y'";
        }
        else if (ddlStop.SelectedIndex == 2)
        {
            strWhere += " AND IsStop='N'";
        }

        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_xjbType";
        pb.FldName = "id";
        pb.ProcedureName = "pagination";
        pb.StrWhere = strWhere;
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        
        int count = 0;
        pb.DoCount = 1;

        m_xjbTypeBLL.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        if (delState == true && pageSize == count)
        {
            cuttentPage = cuttentPage - 1;
            pb.PageIndex = cuttentPage;
        }

        List<Tunnel.Model.Tunnel_xjbType> modelList = new List<Tunnel.Model.Tunnel_xjbType>();
        modelList = m_xjbTypeBLL.GetList(pb, ref count);//获取分页结果

        dgdXJBType.DataSource = modelList;
        dgdXJBType.DataBind();
        dgdXJBType.SelectedIndex = -1;
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
        BindGrid();
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

    protected void dgdXJBType_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType==ListItemType.SelectedItem)
        {
            if (e.Item.Cells[2].Text.Trim() == "Y")
                e.Item.Cells[2].Text = "是";
            else
                e.Item.Cells[2].Text = "否";
            e.Item.Cells[3].Text = GetUserName(e.Item.Cells[3].Text.Trim());
        }
    }
    protected void dgdXJBType_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if ("Select".Equals(e.CommandName))
            {
                txtname.Text = e.Item.Cells[1].Text.Trim();
                if (e.Item.Cells[2].Text.Trim() == "是")
                {
                    cboxDate.Checked = true;
                }
                else
                {
                    cboxDate.Checked = false;
                }
                hidValue.Value = e.Item.Cells[0].Text.Trim();
                ViewState["STATE"] = "U";
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
    protected void btnCanel_Click(object sender, EventArgs e)
    {
        InitPage();
    }
}
