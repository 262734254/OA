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
using Tunnel.BLL;

public partial class N_Message_N_MessageAdd : System.Web.UI.Page
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
        set
        {
            messageModel = value;
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

    string strMesID;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        strMesID = null == Request.QueryString["mesID"] ? "" : Request.QueryString["mesID"].ToString().Trim();
        if (!IsPostBack)
        {
            InitPage();
        }
    }
    #endregion

    #region 初始页面
    private void InitPage()
    {
        if (strMesID != "")
        {
            m_MessageModel = m_MessageBLL.GetMessageModel(int.Parse(strMesID));
            txtTitle.Text = m_MessageModel.MesTitle;
            txtContent.Text = m_MessageModel.MesContent;
            ViewState["STATE"] = "U";   //操作状态： N（新增）,U（修改）
        }
        else
        {
            txtTitle.Text = "";
            txtContent.Text = "";
            ViewState["STATE"] = "N";
        }
    }
    #endregion

    #region 保存
    protected void btnSave_Click(object sender, EventArgs e)
    {
        m_MessageModel.MesTitle = txtTitle.Text.Trim();
        m_MessageModel.MesContent = txtContent.Text.Trim();
        
        m_MessageModel.MesUser = m_UserLogin.LoginID;
        //新增时
        if ("N".Equals(ViewState["STATE"].ToString().Trim()))
        {
            m_MessageModel.MesDate = DateTime.Now;

            if (m_MessageBLL.Add(m_MessageModel) > 0)
            {
                Response.Redirect("MessageManage.aspx");
            }
            else
            {
                Tunnel.Common.Message.back("发布失败");
                return;
            }
        }
        else       //修改
        {
            m_MessageModel.MesID = int.Parse(strMesID);
            m_MessageModel.ModiDate = DateTime.Now;

            if (m_MessageBLL.Update(m_MessageModel) > 0)
            {
                Response.Redirect("MessageManage.aspx");
            }
            else
            {
                Tunnel.Common.Message.back("修改失败");
                return;
            }
        }
    }
    #endregion
}
