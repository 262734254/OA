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
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Drawing;


public partial class N_News_N_Departments_N_ShiYanAdd : System.Web.UI.Page
{
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    Tunnel.BLL.SelType st = new Tunnel.BLL.SelType();
    Tunnel.Model.Tunnel_SelType most = new Tunnel.Model.Tunnel_SelType();
    List<Tunnel.Model.Tunnel_SelType> mostList = new List<Tunnel.Model.Tunnel_SelType>();
    List<Tunnel.Model.Tunnel_menber> meb = new List<Tunnel.Model.Tunnel_menber>();
    string typeid = "0";

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

    private static int titleId = 0;
    private static int indexId = 0;
    public string pagetitlestr = "科室信息发布";
    //绑定DropDownList方法
    protected void DdpBind()
    {
        //this.DropDownList1.DataSource = most;
        //this.DropDownList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            titleId = 0;
            //this.Label1.Visible = false;
            //根据登录者ID判断是否存在于某部门

            //如果是管理员登陆，则可查看所有列表信息

            if (ul.LoginID == 1 || "系统管理员" == ul.JiaoSe(ul.LoginID))
            {
                //mostList = st.GetModelList("1=1 and bumname not in ('党工团','项目经理部') order by bumname desc");
                mostList = st.GetModelList("1=1 order by bumname desc");
                //若系统管理员也属于某部门
            }
            else
            {
                //若此用户不在任何部门里，则无操作
                if (tm.GetModel(ul.LoginID).m_bum == 0)
                {
                    //this.Label1.Visible = true;
                }
                else
                {
                    //若是用户登录，则根据其所属部门得出相应列表信息

                    // 根据登陆ID 找到 member表里对应的m_bum部门ID，然后再找出部门名称                

                    most.BumID = tm.GetModel(ul.LoginID).m_bum.ToString().Trim();
                    most.BumName = tb.GetModel(long.Parse(most.BumID.ToString())).b_name;
                    // st.GetModelList("BumName=" + most.BumName);
                    mostList = st.GetModelList("BumName='" + most.BumName + "' or bumname in ('科室信息','总工室')");
                }
            }

            if (!string.IsNullOrEmpty(Request.QueryString["pagetitle"]))
            {
                titleId = Convert.ToInt32(Request.QueryString["pagetitle"]);
                if (titleId == 1)
                {
                    pagetitlestr = "科室信息修改";
                }
                indexId = 0;
                indexId = Convert.ToInt32(Request.QueryString["indexId"]);
                PageBind(indexId);
            }
        }
    }

    private void PageBind(int indexId)
    {
        Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
        Tunnel.BLL.Tunnel_Index index = new Tunnel.BLL.Tunnel_Index();
        model = index.GetModel(indexId);
        tb_Title.Text = model.Title;
        //DropDownList1.SelectedValue = model.TypeId.ToString();
        FCKeditor.Value = model.Content;
        if (!model.Files.Equals(""))
        {
            Label3.Visible = false;
            Label2.Visible = true;
            Label4.Visible = true;
            Label2.Text = "<br/>附件名：" + model.Files.Substring(model.Files.LastIndexOf("\\") + 1);
            Label3.Text = model.Files;
        }
        else
        {
            Label3.Visible = false;
            Label2.Visible = false;
            Label4.Visible = false;
        }
        if (model.ReadUser.Trim() != "")
        {
            lblUserID.Text = model.ReadUser.Trim();
            string[] strUser = lblUserID.Text.Trim().Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            lblUser.Text = "浏览人：";
            for (int i = 0; i < strUser.Length; i++)
            {
                lblUser.Text += ShowUserName(strUser[i]) + ",";
            }
            lblUser.Text = lblUser.Text.Trim().Substring(0, lblUser.Text.Trim().Length - 1);
            lblUser.Visible = true;
            lblUserMes.Visible = true;
        }
        else
        {
            lblUser.Visible = false;
            lblUserMes.Visible = false;
        }
        //tb_toname.Text = model.ReadUser.Trim();
    }



    //添加至信息表
    protected void Button1_Click(object sender, EventArgs e)
    {
        string titleId = null == Request.QueryString["id"] ? "" : Request.QueryString["id"].ToString().Trim();
        string typeid = null == Request.QueryString["parentID"] ? "" : Request.QueryString["parentID"].ToString().Trim();
        if (titleId != "" && typeid!="")
        {
            string title = this.tb_Title.Text.Trim();
            
            string htmlsourcce = this.FCKeditor.Value; // Request.Form["content1"];  //this.FCKeditor.Value;
            string imagepaht = stringFormat(From_Content(htmlsourcce)).Trim();
            string content = FCKeditor.Value;//Request.Form["content1"]; //FreeTextBox1.HtmlStrippedText;
            int userid = ul.LoginID;
            if (!string.IsNullOrEmpty(imagepaht))
            {
                if (imagepaht.Substring(0, 1) == "/")
                    imagepaht = imagepaht.Substring(1, imagepaht.Length - 1);
                imagepaht = imagepaht.Replace("src=/sdoa/", "");
            }

            Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
            model.Id = indexId;
            model.Title = title;
            model.TypeId = int.Parse(typeid);
            model.HtmlSource = htmlsourcce;
            model.ImagePaht = imagepaht;
            model.Content = content;
            model.UserId = userid;
            if (id_toValue.Value.Trim() != "")
                model.ReadUser = id_toValue.Value.Trim();
            else
                model.ReadUser = lblUserID.Text.Trim();

            HttpPostedFile hpf = file1.PostedFile;
            if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
            {
                Response.Write("<script>alert('附件大小不能大于10MB');</script>");

                return;
            }
            else
                CreateMdAndFilePaht(hpf);
            if (filePaht.Equals(""))
                model.Files = Label3.Text;
            else
                model.Files = filePaht; //infofiles


            //string str = titleName;

            Tunnel.BLL.Tunnel_information bllf = new Tunnel.BLL.Tunnel_information();
            Tunnel.BLL.Tunnel_Index index = new Tunnel.BLL.Tunnel_Index();
            int relt = -1;
            relt = index.Update(model);
            if (relt > 0)
            {
                Tunnel.Common.Message.Show("修改成功！", "N_ShiYanManage.aspx");
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','公司事务>>科室信息>>修改科室信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
            else
                Tunnel.Common.Message.Show("修改失败！", "N_ShiYanManage.aspx");
                
        }
        else
        {
            string title = this.tb_Title.Text.Trim();
            //int typeid = Convert.ToInt32(this.DropDownList1.SelectedValue);
            string htmlsourcce = this.FCKeditor.Value; // Request.Form["content1"];  //this.FCKeditor.Value;
            string imagepaht = stringFormat(From_Content(htmlsourcce)).Trim();
            string content = FCKeditor.Value;//Request.Form["content1"]; //FreeTextBox1.HtmlStrippedText;
            int userid = ul.LoginID;
            if (!string.IsNullOrEmpty(imagepaht))
            {
                if (imagepaht.Substring(0, 1) == "/")
                    imagepaht = imagepaht.Substring(1, imagepaht.Length - 1);
                imagepaht = imagepaht.Replace("src=/sdoa/", "");
            }

            Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
            model.Title = title;
            model.TypeId = int.Parse(typeid);
            model.HtmlSource = htmlsourcce;
            model.ImagePaht = imagepaht;
            model.Content = content;
            model.UserId = userid;
            model.ReadUser = id_toValue.Value.Trim();
            HttpPostedFile hpf = file1.PostedFile;
            if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
            {
                Response.Write("<script>alert('附件大小不能大于10MB');</script>");
                return;
            }
            else
                CreateMdAndFilePaht(hpf);
            model.Files = filePaht; //infofiles


            //string str = titleName;

            Tunnel.BLL.Tunnel_information bllf = new Tunnel.BLL.Tunnel_information();
            int relt = -1;
            relt = bllf.Add(model);
            if (relt > 0)
            {
                Tunnel.Common.Message.Show("增加成功！", "N_ShiYanManage.aspx");
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','公司事务>>科室信息>>修改科室信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
            else
                Tunnel.Common.Message.Show("增加失败！", "N_ShiYanManage.aspx");
                
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
        string fileSaveMd = createPaht + ul.LoginID + "\\";
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

    #region 显示用户真实姓名
    /// <summary>
    /// 显示用户真实姓名
    /// </summary>
    /// <param name="Id">用户Id</param>
    /// <returns></returns>
    private string ShowUserName(string UserId)
    {
        Tunnel.BLL.Tunnel_menber mbll = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
        model = mbll.GetModel(Convert.ToInt64(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.m_name;
        return strTemp;
    }
    #endregion
}