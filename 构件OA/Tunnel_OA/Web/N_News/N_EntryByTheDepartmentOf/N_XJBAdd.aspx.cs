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

public partial class N_News_N_Departments_N_KeshiAdd : System.Web.UI.Page
{
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    Tunnel.BLL.SelType st = new Tunnel.BLL.SelType();
    Tunnel.Model.Tunnel_SelType most = new Tunnel.Model.Tunnel_SelType();
    List<Tunnel.Model.Tunnel_SelType> mostList = new List<Tunnel.Model.Tunnel_SelType>();
    List<Tunnel.Model.Tunnel_menber> meb = new List<Tunnel.Model.Tunnel_menber>();
    Tunnel.BLL.Tunnel_xjbType xjb = new Tunnel.BLL.Tunnel_xjbType();
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
    public string pagetitlestr = "项经部信息发布";
    //绑定DropDownList方法
    protected void DdpBind()
    {
        this.DropDownList1.DataSource = most;
        this.DropDownList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            titleId = 0;
            this.Label1.Visible = false;
            //根据登录者ID判断是否存在于某部门

            //如果是管理员登陆，则可查看所有列表信息

            mostList = st.GetModelList("1=1 and BumName = '项目经理部' order by bumname desc");
            //若系统管理员也属于某部门

            if (tm.GetModel(ul.LoginID).m_bum != 0)
            {
                for (int t = 0; t < mostList.Count; t++)
                {
                    DropDownList1.Items.Add(new ListItem(mostList[t].TypeName + "(" + mostList[t].BumName + ")", mostList[t].TypeID.ToString()));
                }
                DropDownList1.Items.Insert(0, new ListItem("-请选择-", "0"));


                if (ul.LoginID == 1 || "系统管理员" == ul.JiaoSe(ul.LoginID))
                {

                }
                else
                    ddlquanxianbind();
            }
            else
            {
            }






            //if (ul.LoginID == 1 || "系统管理员" == ul.JiaoSe(ul.LoginID))
            //{

            //}
            //else
            //{
            //若此用户不在任何部门里，则无操作
            if (tm.GetModel(ul.LoginID).m_bum == 0)
            {
                this.Label1.Visible = true;
            }
            else
            {
                //若是用户登录，则根据其所属部门得出相应列表信息

                // 根据登陆ID 找到 member表里对应的m_bum部门ID，然后再找出部门名称                

                //most.BumID = tm.GetModel(ul.LoginID).m_bum;
                //most.BumName = tb.GetModel(long.Parse(most.BumID.ToString())).b_name;
                //// st.GetModelList("BumName=" + most.BumName);
                //mostList = st.GetModelList("BumName='" + most.BumName + "'");

                //for (int j = 0; j < mostList.Count; j++)
                //{
                //    DropDownList1.Items.Add(new ListItem(mostList[j].TypeName + "(" + mostList[j].BumName + ")", mostList[j].TypeID.ToString()));
                //}
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add(new ListItem("请选择类型", "-1"));


            }
            //}

            if (!string.IsNullOrEmpty(Request.QueryString["pagetitle"]))
            {
                titleId = Convert.ToInt32(Request.QueryString["pagetitle"]);
                if (titleId == 1)
                {
                    pagetitlestr = "项经部信息修改";
                }
                indexId = 0;
                indexId = Convert.ToInt32(Request.QueryString["indexId"]);
                PageBind(indexId);
            }
        }
    }

    private void ddlquanxianbind()
    {
        List<ListItem> list = new List<ListItem>();

        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "工程概况", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("工程概况(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "进度管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("进度管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "党团工作", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("党团工作(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "技术管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("技术管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "人事与经济管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("人事与经济管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "信息宣传", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("信息宣传(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "信息宣传", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("信息宣传(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "质量管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("质量管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "安全管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("安全管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "设备管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("设备管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "材料管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("材料管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "测量管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("测量管理(项目经理部)");
            list.Add(li);
        }
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "用电管理", "项经部", false))
        {
            ListItem li = DropDownList1.Items.FindByText("用电管理(项目经理部)");
            list.Add(li);
        }
        DropDownList1.Items.Clear();
        foreach (ListItem item in list)
        {
            DropDownList1.Items.Add(item);
        }
        DropDownList1.Items.Insert(0, new ListItem("-请选择-", "0"));
    }

    private void PageBind(int indexId)
    {
        Tunnel.Model.Tunnel_InfoXJB model = new Tunnel.Model.Tunnel_InfoXJB();
        Tunnel.BLL.Tunnel_InfoXJB index = new Tunnel.BLL.Tunnel_InfoXJB();
        model = index.GetModel(indexId);
        tb_Title.Text = model.Title;
        DropDownList1.SelectedValue = model.TypeId.ToString();
        Binddroplist(model.TypeId);
        DropDownList2.SelectedValue = model.Sectype.ToString();
        FCKeditor.Value = model.Content; if (!model.Files.Equals(""))
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
    }



    //添加至信息表
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (titleId == 1)
        {
            if (!"0".Equals(Request.Form["DropDownList1"]))
            {
                string title = this.tb_Title.Text.Trim();
                int typeid = Convert.ToInt32(this.DropDownList1.SelectedValue);
                int sectype = Convert.ToInt32(DropDownList2.SelectedValue);
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

                Tunnel.Model.Tunnel_InfoXJB model = new Tunnel.Model.Tunnel_InfoXJB();
                model.Id = indexId;
                model.Title = title;
                model.TypeId = typeid;
                model.HtmlSource = htmlsourcce;
                model.ImagePaht = imagepaht;
                model.Content = content;
                model.UserId = userid;
                model.Sectype = sectype;
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
                Tunnel.BLL.Tunnel_InfoXJB index = new Tunnel.BLL.Tunnel_InfoXJB();
                int relt = -1;
                relt = index.Update(model);
                if (relt > 0)
                {
                    Tunnel.Common.Message.Show("修改成功！", "N_XJBManage.aspx");
                    string strsql = "";
                    strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>修改项经部信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                    Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
                }
                else
                    Tunnel.Common.Message.Show("修改失败！", "N_XJBManage.aspx");

                // MessageBox(str, url);
            }
            else
            {
                Tunnel.Common.Message.Show("请选择子栏目!");
            }
        }
        else
        {
            if (!"0".Equals(Request.Form["DropDownList1"]))
            {
                string title = this.tb_Title.Text.Trim();
                int typeid = Convert.ToInt32(this.DropDownList1.SelectedValue);
                int sectype = Convert.ToInt32(DropDownList2.SelectedValue);
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

                Tunnel.Model.Tunnel_InfoXJB model = new Tunnel.Model.Tunnel_InfoXJB();
                model.Title = title;
                model.TypeId = typeid;
                model.HtmlSource = htmlsourcce;
                model.ImagePaht = imagepaht;
                model.Content = content;
                model.UserId = userid;
                model.Bum_bz = ul.getUserModel(ul.LoginID).m_bum;
                model.Sectype = sectype;
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

                Tunnel.BLL.Tunnel_InfoXJB bllf = new Tunnel.BLL.Tunnel_InfoXJB();
                int relt = -1;
                relt = bllf.Add(model);
                if (relt > 0)
                {
                    Tunnel.Common.Message.Show("增加成功！", "N_XJBManage.aspx");
                    string strsql = "";
                    strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>发布项经部信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',1)";
                    Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
                }
                else
                    Tunnel.Common.Message.Show("增加失败！", "N_XJBManage.aspx");

                // MessageBox(str, url);
            }
            else
            {
                Tunnel.Common.Message.Show("请选择子栏目!");
            }
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int typeid = Convert.ToInt32(DropDownList1.SelectedValue);
        Binddroplist(typeid);
        //Tunnel.Common.Message.Show(DropDownList1.SelectedValue);
    }
    private void Binddroplist(int typeid)
    {
        List<Tunnel.Model.Tunnel_xjbType> xjblist = new List<Tunnel.Model.Tunnel_xjbType>();
        xjblist = xjb.GetModelList(" typeid=" + typeid);
        if (xjblist != null)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("请选择类型", "-1"));
            foreach (Tunnel.Model.Tunnel_xjbType xjbmodel in xjblist)
            {
                DropDownList2.Items.Add(new ListItem(xjbmodel.Typename, xjbmodel.Id.ToString()));
            }
        }
        else
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add(new ListItem("--无子栏目--", "0"));
        }
    }
}
