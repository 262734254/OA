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
using System.IO;

public partial class N_Exchange_N_Message_N_MessageSend : System.Web.UI.Page
{
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
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private string strToIds;
    private int Id;
    int classid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!string.IsNullOrEmpty(Request.QueryString["classId"]))
            classid = Convert.ToInt32(Request.QueryString["classId"]);
        if (!IsPostBack)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            if (Id > 0)
            {
                if (classid == 1)
                {
                    PageBind(Id);
                }
                else
                {
                    PageBind2(Id);
                }
            }
            else
            {
                Button4.Visible = true;
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
        string createPaht = "\\Messge";
        string fileSaveMd = createPaht + ul.LoginID + "\\";
        fileDirectory = Request.PhysicalApplicationPath + upPaht + createPaht;
        if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
        {
            fileDirectory = fileDirectory + fileSaveMd;
            if (Tunnel.Common.Common.CreateMd(fileDirectory) == 0)
            {
                upDbFilePaht = upPaht + createPaht + fileSaveMd;
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
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
            hpf.SaveAs(fileDirectory);
        }
        else
        {
            if (classid == 2)
            {
                Tunnel.Model.Tunnel_mail model = new Tunnel.Model.Tunnel_mail();
                Tunnel.BLL.Tunnel_mail mbll = new Tunnel.BLL.Tunnel_mail();
                model = mbll.GetModel(Convert.ToInt64(Id));
                if (model.m_file.Trim().Equals(""))
                    filePaht = string.Empty;
                else
                {
                    filePaht = upDbFilePaht + fileName + model.m_file.Substring(model.m_file.LastIndexOf('.'));
                    File.Copy(Request.PhysicalApplicationPath + model.m_file, fileDirectory + fileName + model.m_file.Substring(model.m_file.LastIndexOf('.')));
                }
            }
            else
                filePaht = string.Empty;
        }
    }

    /// <summary>
    /// 发送邮件并保存到服务器
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获得所需参数
        string strTo = tb_toname.Text.Trim();
        strToIds = id_toValue.Value.Trim();
        string strTitle = tb_Title.Text.Trim();
        string strContent = tb_content.Text.Trim().Replace("\r\n", @"<br \>").Replace("原信息内容：", "");
        HttpPostedFile hpf = file1.PostedFile;
        if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
        {
            Response.Write("<script>alert('附件大小不能大于10MB');</script>");

            return;
        }
        else
            CreateMdAndFilePaht(hpf);

        //写入数据库    

        Tunnel.BLL.Tunnel_mail rbll = new Tunnel.BLL.Tunnel_mail();
        Tunnel.Model.Tunnel_mail model = new Tunnel.Model.Tunnel_mail();
        model.m_title = strTitle;
        model.m_content = strContent;
        model.m_file = filePaht;
        model.m_time = DateTime.Now;
        model.m_from = ul.LoginID;
        model.m_sort = 0; // 0未删除、1删除
        model.m_state = 0; // 0未读、1已读
        model.m_Ip = Tunnel.Common.Common.GetIp();
        if (strToIds.LastIndexOf(',') > 0)
        {
            strToIds = strToIds.Remove(strToIds.LastIndexOf(','), 1);
        }
        string[] arr = strToIds.Split(',');
        int relt1 = -1;
        foreach (string s in arr)
        {
            bool state = true;
            for (int i = 1; i <= 2; i++)
            {
                if (i == 1)
                {
                    model.m_Main = 1; //标记是自己发的
                    model.m_to = Convert.ToInt32(s);
                    relt1 = rbll.Add(model);
                }
                else
                {
                    model.m_Main = 0; //标记是发给别人的
                    model.m_to = Convert.ToInt32(s);
                    relt1 = rbll.Add(model);
                    //-------添加消息提示--------
                    Tunnel.Model.Tunnel_Remind remindmodel = new Tunnel.Model.Tunnel_Remind();
                    remindmodel.m_isread = 0;
                    remindmodel.m_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    remindmodel.m_title = "新的站内消息，发件人：" + ul.getUserModel(model.m_from).m_name + "。时间：" + DateTime.Now + "<font color=red>（未读）</font>";
                    remindmodel.m_touser = model.m_to;
                    remindmodel.m_url = "N_Exchange/N_Message/N_MessageView.aspx?Id=" + relt1;
                    remindmodel.m_type = 2;
                    remindmodel.m_typeid = relt1;
                    remindmodel.m_callTime = Convert.ToDateTime("1800-01-01");
                    Tunnel.BLL.Tunnel_Remind rd = new Tunnel.BLL.Tunnel_Remind();
                    rd.Add(remindmodel);
                }
                if (relt1 == 0)
                {
                    state = false;
                    break;
                }
            }
            if (state == false)
                break;
        }

        string str = "站内信息发送";
        string url = "N_MessageOld.aspx";
        if (relt1 > 0)
            str += "成功！";
        else
            str += "失败！";

        MessageBox(str, url);
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
    private void PageBind(int mailId)
    {
        Tunnel.BLL.Tunnel_mail mail = new Tunnel.BLL.Tunnel_mail();
        Tunnel.Model.Tunnel_mail model = new Tunnel.Model.Tunnel_mail();
        model = mail.GetModel(mailId);
        tb_Title.Text = "回复：" + model.m_title;
        tb_content.Text = "原信息内容：\n" + model.m_content.Replace(@"<br \>", "\n") + "\n" + model.m_time.ToString() + "\n-------------------------------\n";
        Tunnel.BLL.Tunnel_menber menb = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber mmol = new Tunnel.Model.Tunnel_menber();
        mmol = menb.GetModel(model.m_from);
        tb_toname.Text = mmol.m_name + ",";
        id_toValue.Value = model.m_from.ToString() + ",";
        string priv_name = mmol.m_name;
        long priv_id = mmol.m_id;
        char d = '"';
        td_tomail.InnerHtml = priv_name + "<IMG id=" + priv_name + priv_id + " onclick=" + "'" + "removeimg(" + d + priv_name + d + "," + d + priv_id + d + ");" + "'" + " src=" + d + "../../image/remove.png" + d + ">,";
    }
    private void PageBind2(int mailId)
    {
        Tunnel.BLL.Tunnel_mail mail = new Tunnel.BLL.Tunnel_mail();
        Tunnel.Model.Tunnel_mail model = new Tunnel.Model.Tunnel_mail();
        model = mail.GetModel(mailId);
        tb_Title.Text = "转发：" + model.m_title;
        tb_content.Text = "原信息内容：\n" + model.m_content.Replace(@"<br \>", "\n") + "\n" + model.m_time.ToString() + "\n-------------------------------\n";
        if (!model.m_file.Trim().Equals(""))
        {
            Label1.Text += model.m_file.Substring(model.m_file.LastIndexOf('\\'));
            Label1.Visible = true;
            Label2.Visible = true;
        }
    }
}
