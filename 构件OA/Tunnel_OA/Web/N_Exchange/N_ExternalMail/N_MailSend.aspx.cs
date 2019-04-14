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
using Tunnel.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class N_Exchange_N_ExternalMail_N_MailSend : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["mail"]))
            tb_Email.Text = Request.QueryString["mail"].Trim();
        if (!IsPostBack)
        {
            BindLinkman();
        }
    }

    private void BindLinkman()
    {
        lbxlinkman.Items.Clear();
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        DataSet das = new DataSet();
        das = tm.GetList("m_mail <> ''");
        foreach (DataRow rows in das.Tables[0].Rows)
        {
            ListItem item = new ListItem();
            item.Text = rows["m_name"].ToString().Trim();
            item.Value = rows["m_mail"].ToString().Trim() + "[" + rows["m_name"].ToString().Trim() + "];";
            lbxlinkman.Items.Add(item);
        }

    }


    protected void lbxlinkman_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = tb_Email.Text.ToString();
        for (int i = 0; i >= 0; i++)
        {
            int startstr = str.IndexOf(lbxlinkman.SelectedItem.Value.ToString());
            int strlength = (lbxlinkman.SelectedItem.Value.ToString()).Length;
            if (startstr >= 0)
            {
                str = str.Remove(startstr, strlength);
                tb_Email.Text = str;
            }
            else
            {
                break;
            }
        }
        tb_Email.Text += lbxlinkman.SelectedItem.Value.ToString();
    }


    /// <summary>
    ///  创建文件及路径参数

    /// </summary>
    public void CreateMdAndFilePaht()
    {
        string upPaht = "upload";
        string createPaht = "\\SendEmail";
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
    }

    /// <summary>
    /// 发送邮件并保存到服务器
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //获得所需参数
        string str2 = tb_Email.Text.Trim();
        //把；替换为;
        str2 = str2.Replace("；", ";");
        //如果不是;结尾就加上

        if (!str2.EndsWith(";"))
        {
            str2 += ";";
        }
        //去除地址中的用户名

        for (int i = 0; i >= 0; i++)
        {
            int startstr = str2.IndexOf("[");
            int endstr = str2.IndexOf("];") + 1;
            if (startstr >= 0)
            {
                str2 = str2.Remove(startstr, (endstr - startstr));
            }
            else
            {
                break;
            }
        }
        string str3 = str2;
        List<string> strlist = new List<string>();
        List<string> strlist2 = new List<string>();
        //根据样式获取正确的邮箱地址
        Regex rx = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        MatchCollection matches = rx.Matches(str2);
        foreach (Match var in matches)
        {
            strlist2.Add(var.Value);
        }
        for (int i = 0; i >= 0; i++)
        {
            int endstr = str3.IndexOf(";");
            if (endstr >= 0)
            {
                //截取邮箱地址
                strlist.Add(str3.Substring(0, endstr));
                str3 = str3.Remove(0, (str3.Substring(0, endstr)).Length + 1);
                if (strlist.Count <= strlist2.Count)
                {
                    //如果地址不同就代表格式不正确
                    if (strlist[i] != strlist2[i])
                    {
                        Response.Write("<script type='text/javascript'>alert('" + strlist[i] + "的格式错误')</script>");
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                break;
            }
        }
        string strTitle = "隧道OA办公系统：" + tb_Title.Text.Trim();
        string strContent = tb_content.Text.Trim();
        HttpPostedFile hpf = file1.PostedFile;
        if (Convert.ToDouble(hpf.ContentLength) / 1024 / 1024 > 10)
        {
            Response.Write("<script>alert('附件大小不能大于10MB');</script>");

            return;
        }
        else
            CreateMdAndFilePaht();
        string[] arr = new string[1];
        if (hpf.ContentLength > 0)
        {
            if (!string.IsNullOrEmpty(hpf.FileName))
                fileName = fileName + System.IO.Path.GetExtension(hpf.FileName);
            else
                fileName = fileName + hpf.ContentType;
            filePaht = upDbFilePaht + fileName;
            fileDirectory = fileDirectory + fileName;
            arr[0] = fileDirectory;
            hpf.SaveAs(fileDirectory);
        }
        else
        {
            filePaht = string.Empty;
        }
        int relt1 = 0;
        for (int i = 0; i < strlist.Count; i++)
        {
            //发送邮件

            SendEamil se = new SendEamil();
            int relt = -1;

            relt = se.SendEmail(se.NcUserEmail, strlist[i], strTitle, strContent, arr);

            //写入数据库

            Tunnel.BLL.Tunnel_report rbll = new Tunnel.BLL.Tunnel_report();
            Tunnel.Model.Tunnel_report model = new Tunnel.Model.Tunnel_report();
            model.r_title = strTitle;
            model.r_Content = strContent;
            model.r_file = filePaht;
            model.r_time = DateTime.Now;
            model.r_user = ul.LoginID;
            model.r_toEmail = strlist[i];
            model.r_Ip = Tunnel.Common.Common.GetIp();
            rbll.Add(model);
            relt1++;
        }
        if (relt1 == strlist.Count)
        {
            string str = "邮件";
            string url = "N_MailManage.aspx";
            if (relt1 > 0)
                str += "发送成功！";
            else
                str += "发送失败！";

            MessageBox(str, url);
        }
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
    protected void btnclean_Click(object sender, EventArgs e)
    {
    }
}
