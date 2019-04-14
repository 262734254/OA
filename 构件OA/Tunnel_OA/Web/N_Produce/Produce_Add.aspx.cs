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

public partial class N_Produce_Produce_Add : System.Web.UI.Page
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
    #region m_ProduceModel
    private Tunnel.Model.Tunnel_Produce produceModel;
    private Tunnel.Model.Tunnel_Produce m_ProduceModel
    {
        get
        {
            if (null == produceModel)
                produceModel = new Tunnel.Model.Tunnel_Produce();
            return produceModel;
        }
        set
        {
            produceModel = value;
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

    string proType = "";
    string strProID = "";
    protected string strFiles = "";
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        proType = null == Request.QueryString["type"] ? "" : Request.QueryString["type"].ToString().Trim();
        
        if (!IsPostBack)
        {
            strProID = null == Request.QueryString["proID"] ? "" : Request.QueryString["proID"].ToString().Trim();
            if (strProID != "")
            {
                ViewState["STATE"] = "U";
                LoadSource();
            }
            else
            {
                lblFJ.Visible = false;
                ViewState["STATE"] = "N";
            }
        }
    }
    #endregion

    private void LoadSource()
    {
        m_ProduceModel = m_ProduceBLL.GetProduceModel(int.Parse(strProID));
        hidProID.Value = m_ProduceModel.ProID.ToString().Trim();
        tb_Title.Text = m_ProduceModel.ProTitle;

        if ("" != m_ProduceModel.ProName.Trim())
        {
            hidFiles.Value = m_ProduceModel.ProName + ",";
            lblFJ.Visible = true;
            string[] filelist = m_ProduceModel.ProName.Split(',');
            int i = 1;
            foreach (string list in filelist)
            {
                strFiles += "<span><img src=\"../../image/attach.png\">" + list + "<img style='cursor:hand' onclick=\"delF(this,'" +  list + "'," + i + ")\" alt='删除附件' src=\"../../image/remove.png\">;</span>";
                i++;
            }
        }
        else
        {
            strFiles = "";
            lblFJ.Visible = false;
        }
    }

    #region 保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ViewState["STATE"].ToString() == "N" && "".Equals(HiddenField1.Value.Trim()))
        {
            Tunnel.Common.Message.back("请选择附件");
            return;
        }
        System.Web.HttpFileCollection uploadFiles = Request.Files;
        System.Web.HttpPostedFile theFile;
        for (int i = 0; i < uploadFiles.Count; i++)
        {
            theFile = uploadFiles[i];
            if (Convert.ToDouble(theFile.ContentLength) / 1024 / 1024 > 10)
            {
                Tunnel.Common.Message.back("附件大小不能大于10MB");
                return;
            }
            else
                continue;
        }
        //上传附件并新增数据
        if (Add(UpFiles()))
        {
            Response.Redirect("Produce_Manage.aspx?type=" + proType + "&name=" + Server.UrlEncode(Request.QueryString["name"].ToString().Trim()));
        }
        else
        {
            Tunnel.Common.Message.back("附件上传失败");
            return;
        }

        //string[] strFile = HiddenField1.Value.Trim().Split(new Char[]{','},StringSplitOptions.RemoveEmptyEntries);
        //for (int i = 0; i < strFile.Length; i++)
        //{
        //    if (UpFiles(m_ProduceModel))
        //    {
        //        if (Add())
        //        {
        //            Response.Redirect("Produce_Manage.aspx?type="+proType+"&name"+Request.QueryString["name"].ToString().Trim());
        //        }
        //        else
        //        {
        //            Tunnel.Common.Message.back("附件上传失败");
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        Tunnel.Common.Message.back("附件上传失败");
        //        return;
        //    }
        //}
    }
    #endregion

    #region 上传附件
    private string UpFiles()
    {
        string strFiles = "";
        bool isFlag = false;
        try
        {
            string uploadpath = string.Format(Server.MapPath("../upload/Produce/{0}/"), proType);
            System.Web.HttpFileCollection uploadFiles = Request.Files;
            System.Web.HttpPostedFile theFile;
            
            
            //for (int i = 0; i < uploadFiles.Count; i++)
            //{
            //    theFile = uploadFiles[i];
            //    isFlag = false;
            //    string fileName = theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
            //    if (fileName != "")
            //    {
            //        if (i > 0)
            //        {
            //            string[] str = strFiles.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //            for (int j = 0; j < i; j++)
            //            {
            //                if (fileName == str[j])
            //                {
            //                    isFlag = true;
            //                    break;
            //                }
            //            }
            //        }
            //        if (isFlag)
            //            continue;

            //        theFile.SaveAs(string.Format("{0}{1}", uploadpath, fileName));
            //        strFiles += fileName + ",";
            //    }
            //}


            if (uploadFiles.Count>0 && HiddenField1.Value.Trim() != "")
            {
                theFile = uploadFiles[0];
                string[] strHidFile = HiddenField1.Value.Trim().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strHidFile.Length; i++)
                {
                    string fileName = strHidFile[i].Substring(strHidFile[i].LastIndexOf('\\') + 1);
                    theFile.SaveAs(string.Format("{0}{1}", uploadpath, fileName));
                    strFiles += fileName + ",";
                }
            }
            if (hidFiles.Value.Trim()!="")
                strFiles += hidFiles.Value.Trim();
            strFiles = strFiles.Substring(0, strFiles.Trim().Length - 1);
        }
        catch
        {
            strFiles = "";
        }
        return strFiles;
    }
    #endregion

    #region 新增数据
    private bool Add(string proName)
    {
        bool isFlag = true;
        try
        {
            m_ProduceModel.ProType = proType.Trim();
            m_ProduceModel.ProTitle = tb_Title.Text.Trim();
            m_ProduceModel.ProName = proName;
            m_ProduceModel.ProSrc = string.Format("upload\\Produce\\{0}\\", proType).Trim();
            m_ProduceModel.CreateDate = DateTime.Now;
            m_ProduceModel.CreateUser = m_UserLogin.LoginID;
            m_ProduceModel.ProState = "N";

            if (ViewState["STATE"].ToString() == "N")
            {
                if (m_ProduceBLL.Add(m_ProduceModel) <= 0)
                    isFlag = false;
            }
            else
            {
                m_ProduceModel.ProID = int.Parse(hidProID.Value.Trim());
                m_ProduceModel.ModiDate = DateTime.Now;
                m_ProduceModel.ModiUser = m_UserLogin.LoginID;

                if (m_ProduceBLL.Update(m_ProduceModel) <= 0)
                    isFlag = false;
            }
        }
        catch
        {
            isFlag = false;
        }
        //System.Web.HttpFileCollection uploadFiles = Request.Files;
        //System.Web.HttpPostedFile theFile;

        //for (int i = 0; i < uploadFiles.Count; i++)
        //{
        //    theFile = uploadFiles[i];
        //    string fileName = theFile.FileName.Substring(theFile.FileName.LastIndexOf('\\') + 1);
        //    if (fileName != "")
        //    {
        //        m_ProduceModel.ProType = proType.Trim();
        //        m_ProduceModel.ProTitle = tb_Title.Text.Trim();
        //        m_ProduceModel.ProName = fileName.Trim();
        //        m_ProduceModel.ProSrc = string.Format("upload\\Produce\\{0}\\", proType).Trim();
        //        m_ProduceModel.CreateDate = DateTime.Now;
        //        m_ProduceModel.CreateUser = m_UserLogin.LoginID;
        //        m_ProduceModel.ProState = "N";

        //        if (m_ProduceBLL.Add(m_ProduceModel) <= 0)
        //            return false;
        //    }
        //}
        return isFlag;
    }
    #endregion
}
