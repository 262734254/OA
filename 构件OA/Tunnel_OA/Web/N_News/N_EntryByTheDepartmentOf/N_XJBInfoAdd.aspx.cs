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
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

using Tunnel.BLL;

public partial class N_News_N_EntryByTheDepartmentOf_N_XJBInfoAdd : System.Web.UI.Page
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
    private Tunnel.BLL.Tunnel_InfoXJB infoXJBBLL;
    private Tunnel.BLL.Tunnel_InfoXJB m_InfoXJBBLL
    {
        get
        {
            if (null == infoXJBBLL)
                infoXJBBLL = new Tunnel.BLL.Tunnel_InfoXJB();
            return infoXJBBLL;
        }
    }
    private Tunnel.Model.Tunnel_InfoXJB infoXJBModel;
    private Tunnel.Model.Tunnel_InfoXJB m_InfoXJBModel
    {
        get
        {
            if (null == infoXJBModel)
                infoXJBModel = new Tunnel.Model.Tunnel_InfoXJB();
            return infoXJBModel;
        }
        set
        {
            infoXJBModel = value;
        }
    }

    /// <summary>
    /// 文件目录绝对路径
    /// </summary>
    private string fileDirectory;
    /// <summary>
    /// 相对路径
    /// </summary>
    private string upDbFilePaht;
    /// <summary>
    /// 文件路径
    /// </summary>
    private string filePaht;
    private string fileName;
    string id = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        id = null == Request.QueryString["id"] ? "" : Request.QueryString["id"].ToString().Trim();
        if (!IsPostBack)
        {
            BindDropDown();
            InitPage();
        }
    }

    private void InitPage()
    {
        if (id != "")
        {
            m_InfoXJBModel = m_InfoXJBBLL.GetModel(int.Parse(id));
            tb_Title.Text = m_InfoXJBModel.Title;
            ddlXJBType.SelectedIndex = -1;
            ddlXJBType.Items.FindByValue(m_InfoXJBModel.TypeId.ToString().Trim()).Selected = true;
            FCKeditor.Value = m_InfoXJBModel.Content;
            if (!m_InfoXJBModel.Files.Equals(""))
            {
                Label3.Visible = false;
                Label2.Visible = true;
                Label4.Visible = true;
                Label2.Text = "<br/>附件名：" + m_InfoXJBModel.Files.Substring(m_InfoXJBModel.Files.LastIndexOf("\\") + 1);
                Label3.Text = m_InfoXJBModel.Files;
            }
            else
            {
                Label3.Visible = false;
                Label2.Visible = false;
                Label4.Visible = false;
            }
            ViewState["STATE"] = "U";
        }
        else
        {
            ViewState["STATE"] = "N";
        }
    }

    private void BindDropDown()
    {
        DataSet ds = null;
        string xjb = m_UserLogin.getUserModel(m_UserLogin.LoginID).m_xjb.Replace("|",",");
        ddlXJBType.Items.Clear();
        if (m_UserLogin.JiaoSe(m_UserLogin.LoginID).Trim().Equals("系统管理员"))
            ds = m_xjbTypeBLL.GetList("IsStop='N'");
        else if (xjb != "")
        {
            ds = m_xjbTypeBLL.GetList(string.Format("id in ({0}) AND IsStop='N'", xjb));
        }
        if (null != ds && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlXJBType.DataSource = ds;
            ddlXJBType.DataTextField = "typename";
            ddlXJBType.DataValueField = "id";
            ddlXJBType.DataBind();
        }
        ddlXJBType.Items.Insert(0, new ListItem("请选择", ""));
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlXJBType.SelectedIndex <= 0)
        {
            Response.Write("<script>alert('请选择类型');</script>");
            return;
        }
        if (ViewState["STATE"].ToString().Trim()=="U")
        {
            string title = this.tb_Title.Text.Trim();
            int typeid = Convert.ToInt32(ddlXJBType.SelectedValue);
            int sectype = Convert.ToInt32(ddlXJBItem.SelectedValue);
            string htmlsourcce = this.FCKeditor.Value; // Request.Form["content1"];  //this.FCKeditor.Value;
            string imagepaht = stringFormat(From_Content(htmlsourcce)).Trim();
            string content = FCKeditor.Value;//Request.Form["content1"]; //FreeTextBox1.HtmlStrippedText;
            int userid = m_UserLogin.LoginID;
            if (!string.IsNullOrEmpty(imagepaht))
            {
                if (imagepaht.Substring(0, 1) == "/")
                    imagepaht = imagepaht.Substring(1, imagepaht.Length - 1);
                imagepaht = imagepaht.Replace("src=/sdoa/", "");
            }

            m_InfoXJBModel.Id = int.Parse(id);
            m_InfoXJBModel.Title = title;
            m_InfoXJBModel.TypeId = typeid;
            m_InfoXJBModel.HtmlSource = htmlsourcce;
            m_InfoXJBModel.ImagePaht = imagepaht;
            m_InfoXJBModel.Content = content;
            m_InfoXJBModel.ModiUser = userid;
            m_InfoXJBModel.ModiDate = DateTime.Now;
            m_InfoXJBModel.Sectype = sectype;
            HttpPostedFile hpf = file1.PostedFile;
            if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
            {
                Response.Write("<script>alert('附件大小不能大于10MB');</script>");

                return;
            }
            else
                CreateMdAndFilePaht(hpf);
            if (filePaht.Equals(""))
                m_InfoXJBModel.Files = Label3.Text;
            else
                m_InfoXJBModel.Files = filePaht; //infofiles


            //string str = titleName;
            
            int relt = -1;
            relt = m_InfoXJBBLL.Update(m_InfoXJBModel);
            if (relt > 0)
            {
                Tunnel.Common.Message.Show("修改成功！", "N_XJBInfoManage.aspx");
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + m_UserLogin.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>修改项经部信息。标题：" + m_InfoXJBModel.Title + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
            else
                Tunnel.Common.Message.Show("修改失败！", "N_XJBInfoManage.aspx");

            // MessageBox(str, url);
        }
        else
        {
            string title = this.tb_Title.Text.Trim();
            int typeid = Convert.ToInt32(ddlXJBType.SelectedValue);
            int sectype = Convert.ToInt32(ddlXJBItem.SelectedValue);
            string htmlsourcce = this.FCKeditor.Value; // Request.Form["content1"];  //this.FCKeditor.Value;
            string imagepaht = stringFormat(From_Content(htmlsourcce)).Trim();
            string content = FCKeditor.Value;//Request.Form["content1"]; //FreeTextBox1.HtmlStrippedText;
            int userid = m_UserLogin.LoginID;
            if (!string.IsNullOrEmpty(imagepaht))
            {
                if (imagepaht.Substring(0, 1) == "/")
                    imagepaht = imagepaht.Substring(1, imagepaht.Length - 1);
                imagepaht = imagepaht.Replace("src=/sdoa/", "");
            }

            Tunnel.Model.Tunnel_InfoXJB model = new Tunnel.Model.Tunnel_InfoXJB();
            m_InfoXJBModel.Title = title;
            m_InfoXJBModel.TypeId = typeid;
            m_InfoXJBModel.HtmlSource = htmlsourcce;
            m_InfoXJBModel.ImagePaht = imagepaht;
            m_InfoXJBModel.Content = content;
            m_InfoXJBModel.UserId = userid;
            m_InfoXJBModel.Bum_bz = m_UserLogin.getUserModel(m_UserLogin.LoginID).m_bum;
            m_InfoXJBModel.Sectype = sectype;
            HttpPostedFile hpf = file1.PostedFile;
            if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
            {
                Response.Write("<script>alert('附件大小不能大于10MB');</script>");

                return;
            }
            else
                CreateMdAndFilePaht(hpf);
            m_InfoXJBModel.Files = filePaht; //infofiles


            //string str = titleName;

            int relt = -1;
            relt = m_InfoXJBBLL.Add(m_InfoXJBModel);
            if (relt > 0)
            {
                Tunnel.Common.Message.Show("增加成功！", "N_XJBInfoManage.aspx");
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + m_UserLogin.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>发布项经部信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
            else
                Tunnel.Common.Message.Show("增加失败！", "N_XJBInfoManage.aspx");

            // MessageBox(str, url);
        }
    }

    /// <summary>
    ///  创建文件及路径参数
    /// </summary>
    public void CreateMdAndFilePaht(HttpPostedFile hpf)
    {
        //string wordMd = Request.PhysicalApplicationPath.Replace(HttpRuntime.AppDomainAppVirtualPath.Replace("/", "") + "\\", "");
        string upPaht = "upload";
        string createPaht = "\\infofiles";
        string fileSaveMd = createPaht + m_UserLogin.LoginID + "\\";
        fileDirectory = Request.PhysicalApplicationPath + upPaht + createPaht;
        if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
        {
            fileDirectory = fileDirectory + fileSaveMd;
            if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
            {
                upDbFilePaht = upPaht + createPaht + fileSaveMd;
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                //fileName = DateTime.Now.ToFileTime().ToString();
            }
        }
        if (hpf.ContentLength > 0)
        {
            if (!string.IsNullOrEmpty(hpf.FileName))
                fileName = fileName + System.IO.Path.GetExtension(hpf.FileName);
            else
                fileName = fileName + hpf.ContentType;
            filePaht = upDbFilePaht + fileName;
            fileDirectory = fileDirectory + fileName;
            File.Delete(Request.PhysicalApplicationPath + Label3.Text);
            hpf.SaveAs(fileDirectory);
        }
        else
        {
            filePaht = string.Empty;
        }
    }

    /// <summary>
    /// 取得图片信息
    /// </summary>
    /// <param name="htmlcontent"></param>
    /// <returns></returns>
    public string From_Content(string htmlcontent)
    {
        string str = string.Empty;
        string content = htmlcontent.Replace("\n", "").ToLower();
        content = content.Replace("\r", "");
        content = content.Replace("\t", "");
        string input_tag = @"(<img)((.|\n)*?)(>)";
        MatchCollection mx = Regex.Matches(content, input_tag);
        foreach (Match match in mx)
        {
            if (Regex.IsMatch(match.Value, @"(<img)((.|\n)*?)(>)"))
            {
                if (string.IsNullOrEmpty(str))
                    str = match.Value;
                else
                    str = match.Value + "|" + str;
            }
        }
        return str;
    }



    public string stringFormat(string html)
    {
        string temp = string.Empty;
        try
        {

            if (string.IsNullOrEmpty(html))
                return temp;
            string[] arr = html.Split('|');
            foreach (string s in arr)
            {
                string[] imgy = s.Split(' ');
                //int stratNum =s.IndexOf("src");
                //int endNum = s.IndexOf("border");
                if (imgy.Length > 2)
                    temp = imgy[3];
                if (!string.IsNullOrEmpty(temp))
                    temp = temp.Split('=')[1].Replace('"', ' ').ToLower().Replace("/web", "").Replace("sdoa/", "");
                //if (string.IsNullOrEmpty(temp))
                //    temp = s.Substring(stratNum, (endNum - stratNum)).Replace("\"", "").Replace("src=/web", "");
                //else
                //    temp = s.Substring(stratNum, (endNum - stratNum)).Replace("\"", "").Replace("src=/web", "") + "|" + temp;
            }
        }
        catch
        {

        }
        return temp;
    }

    public void MessageBox(string str, string url)
    {
        string strTemp = string.Empty;
        strTemp = "<script>";
        if (!string.IsNullOrEmpty(str))
            strTemp += "alert('" + str + "');";
        if (!string.IsNullOrEmpty(url))
            strTemp += "window.location.href='" + url + "'";
        strTemp += "</script>";
        Response.Write(strTemp);
        Response.End();
    }
}
