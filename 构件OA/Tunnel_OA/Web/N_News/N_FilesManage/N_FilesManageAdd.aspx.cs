using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class N_News_N_FilesManage_N_FilesManageAdd : System.Web.UI.Page
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
    string strFID = "";
    string strType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strFID = null == Request.QueryString["fid"] ? "" : Request.QueryString["fid"].ToString().Trim();
        strType = null == Request.QueryString["type"] ? "" : Request.QueryString["type"].ToString().Trim();
        if (!IsPostBack)
        {
            if (strFID == "")
            {
                ViewState["STATE"] = "N";
            }
            else
            {
                ViewState["STATE"] = "U";
                LoadSource();
            }

            if (m_UserLogin.JiaoSe(m_UserLogin.LoginID) != "系统管理员" && m_UserLogin.LoginID != 14 && m_UserLogin.LoginID != 122)
            {
                Button1.Enabled = false;
            }
        }
    }

    private void LoadSource()
    {
        if (strFID != "")
        {
            m_FilesManageModel = m_FilesManageBLL.GetFilesManageModel(int.Parse(strFID));
            tb_Title.Text = m_FilesManageModel.F_Title;
            FCKeditor.Value = m_FilesManageModel.F_Content;
            if (m_FilesManageModel.F_Name.Trim() != "")
            {
                lblUrl.Text = m_FilesManageModel.F_URL + m_FilesManageModel.F_Name;
                lblFiles.Text = "附件：" + m_FilesManageModel.F_Name;
                lblMes.Visible = true;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ViewState["STATE"].ToString().Trim() == "N")
        {
            HttpPostedFile hpf = file1.PostedFile;
            if (hpf.FileName.Trim() == "")
            {
                Tunnel.Common.Message.back("请选择附件");
                return;
            }
            m_FilesManageModel.F_Type = strType;
            m_FilesManageModel.F_Title = tb_Title.Text.Trim();
            m_FilesManageModel.F_Content = FCKeditor.Value.Trim();
            m_FilesManageModel.F_URL = string.Format("upload\\FilesManage\\{0}\\",strType);
            m_FilesManageModel.F_CreateUser = m_UserLogin.LoginID;
            m_FilesManageModel.F_CreateDate = DateTime.Now;
            
            m_FilesManageModel.F_Name = hpf.FileName;
            hpf.SaveAs(string.Format("{0}{1}{2}", Request.PhysicalApplicationPath, m_FilesManageModel.F_URL, m_FilesManageModel.F_Name));
            if (m_FilesManageBLL.Add(m_FilesManageModel) > 0)
            {
                Tunnel.Common.Message.Show("新增成功", "N_FilesManageManage.aspx?type=" + strType + "&name=" + Request.QueryString["name"].ToString());
            }
            else
            {
                Tunnel.Common.Message.back("新增失败");
                return;
            }
        }
        else
        {
            m_FilesManageModel = m_FilesManageBLL.GetFilesManageModel(int.Parse(strFID));
            m_FilesManageModel.F_Title = tb_Title.Text.Trim();
            m_FilesManageModel.F_Content = FCKeditor.Value.Trim();
            HttpPostedFile hpf = file1.PostedFile;
            if (hpf.FileName.Trim() != "")
            {
                m_FilesManageModel.F_Name = hpf.FileName;
            }
            else
            {
                m_FilesManageModel.F_Name = lblFiles.Text.Trim();
            }
            m_FilesManageModel.F_URL = string.Format("upload\\FilesManage\\{0}\\",strType);
            m_FilesManageModel.F_ModiUser = m_UserLogin.LoginID;
            m_FilesManageModel.F_ModiDate = DateTime.Now;
            File.Delete(Request.PhysicalApplicationPath + lblUrl.Text.Trim());
            hpf.SaveAs(string.Format("{0}{1}{2}", Request.PhysicalApplicationPath, m_FilesManageModel.F_URL, m_FilesManageModel.F_Name));
            if (m_FilesManageBLL.Update(m_FilesManageModel) > 0)
            {
                Tunnel.Common.Message.Show("修改成功", "N_FilesManageManage.aspx?type="+strType+"&name="+Request.QueryString["name"].ToString());
            }
            else
            {
                Tunnel.Common.Message.back("修改失败");
                return;
            }
        }
    }
}
