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

public partial class N_News_N_FilesManage_N_FilesManageManage : System.Web.UI.Page
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
    #region m_FilesManageBLL
    private Tunnel.BLL.Tunnel_FilesManage filesManageBLL;
    private Tunnel.BLL.Tunnel_FilesManage m_FilesManageBLL
    {
        get
        {
            if (null == filesManageBLL)
            {
                filesManageBLL = new Tunnel.BLL.Tunnel_FilesManage();
            }
            return filesManageBLL;
        }
    }
    #endregion
    #region m_FilesManageModel
    private Tunnel.Model.Tunnel_FilesManage filesManageModel;
    private Tunnel.Model.Tunnel_FilesManage m_FilesManageModel
    {
        get
        {
            if (null == filesManageModel)
                filesManageModel = new Tunnel.Model.Tunnel_FilesManage();
            return filesManageModel;
        }
        set
        {
            filesManageModel = value;
        }
    }
    #endregion

    public int cuttentPage;
    private int pageSize = 15;
    string strType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strType = null == Request.QueryString["type"] ? "" : Request.QueryString["type"].ToString().Trim();
        if (!IsPostBack)
        {
            BindDataSource();
        }
    }

    private void BindDataSource()
    {
        string where = " F_DelUser=0 AND F_Type='" + strType + "'";
        if (txtTitle.Text.Trim() != "")
        {
            where = "Title like '%" + txtTitle.Text.Trim() + "%' AND F_DelUser=0 AND F_Type='" + strType + "'";
        }
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_FilesManage";
        pb.FldName = "F_ID";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;
        pb.StrWhere = where;

        m_FilesManageBLL.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_FilesManage> modelList = new List<Tunnel.Model.Tunnel_FilesManage>();
        modelList = m_FilesManageBLL.GetList(pb, ref count);//获取分页结果


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

        if (m_UserLogin.JiaoSe(m_UserLogin.LoginID) != "系统管理员" && m_UserLogin.LoginID != 14 && m_UserLogin.LoginID != 122)
        {
            btnDel.Enabled = false;
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
        BindDataSource();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        BindDataSource();
    }

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandName);
        int relt = -1;
        cuttentPage = MTCPager1.PageIndex;
        Tunnel_FilesManage model = m_FilesManageBLL.GetFilesManageModel(Id);
        //DelPricAndRider(Id);
        relt = m_FilesManageBLL.Delete(Id, m_UserLogin.LoginID);
        if (relt > 0)
        {
            Tunnel.Common.Message.Show("删除成功");
            string strsql = "";
            strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + m_UserLogin.LoginID + ",'" + DateTime.Now + "','删除档案管理。标题：" + model.F_Title + "','" + Tunnel.Common.Common.GetIp() + "',2)";
            Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
        }
        else
            Tunnel.Common.Message.Show("删除失败");
        BindDataSource();
    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandName);
        Response.Redirect("N_FilesManageAdd.aspx?type=" + strType + "&name=" + Request.QueryString["name"].ToString() + "&fid=" + Id + "");
    }

    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
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

    #region 获得附件
    public string GetFile(string file)
    {
        if (file != "")
        {
            return Tunnel.Common.GetValue.getfu(file, "down", 1);
        }
        else
        {
            return "&nbsp;";
        }
    }
    #endregion
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (m_UserLogin.JiaoSe(m_UserLogin.LoginID)!="系统管理员" && m_UserLogin.LoginID != 14 && m_UserLogin.LoginID!=122)
        {
            System.Web.UI.HtmlControls.HtmlInputCheckBox CBoxDelete;
            LinkButton lb = (LinkButton)e.Item.FindControl("LinkButton1");
            LinkButton lb2 = (LinkButton)e.Item.FindControl("LinkButton2");
            CBoxDelete = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("cb1");

            if (Convert.ToInt32(lb.CommandArgument.ToString()) != m_UserLogin.LoginID && m_UserLogin.JiaoSe(m_UserLogin.LoginID) != "系统管理员")
            {
                lb.Enabled = false;
                CBoxDelete.EnableViewState = false;
                lb.ToolTip = "不允许删除他人发布的信息";
                lb2.Enabled = false;
                lb2.ToolTip = "不允许修改他人发布的信息";
            }
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlInputCheckBox CBoxDelete;

        foreach (RepeaterItem rtitem in this.Repeater1.Items)
        {
            CBoxDelete = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rtitem.FindControl("cb1");

            if (CBoxDelete.Checked)
            {
                string id = ((HtmlInputHidden)rtitem.FindControl("SelectCode")).Value;
                Tunnel_FilesManage model = m_FilesManageBLL.GetFilesManageModel(int.Parse(id));
                //DelPricAndRider(Convert.ToInt32(model.Id));
                m_FilesManageBLL.Delete(int.Parse(id), m_UserLogin.LoginID);
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + m_UserLogin.LoginID + ",'" + DateTime.Now + "','档案管理。标题：" + model.F_Title + "','" + Tunnel.Common.Common.GetIp() + "',2)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
        }
        BindDataSource();
    }
}
