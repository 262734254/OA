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

public partial class N_WorkFlow_VDocument_Document_ViewIn : System.Web.UI.Page
{
    public string formfile = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ShowInit();
        }
    }

    void ShowInit()
    {
        if (!string.IsNullOrEmpty(Request.Params["File_Id"]))
        {
            try
            {
                Tunnel.BLL.Tunnel_bumf btb = new Tunnel.BLL.Tunnel_bumf();
                Tunnel.Model.Tunnel_bumf mtb = new Tunnel.Model.Tunnel_bumf();
                Tunnel.BLL.Tunnel_form tf = new Tunnel.BLL.Tunnel_form();
                Tunnel.Model.Tunnel_form mtf = new Tunnel.Model.Tunnel_form();
                Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
                Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
                mtb = btb.GetModel(Convert.ToInt32(Request.Params["File_Id"]));
                formfile = getFile(mtb.b_file);//附件

                Label1.Text = mtb.b_title;
                Label2.Text = fc.From_Content(mtb.b_formcontent, mtb.b_content, true);//取得替换后的表单数据
                ul.UsbnLogin = ul.getUserModel(mtb.b_user);
                Label3.Text = "发布人：" + ul.UsbnLogin.m_name + " 发布时间：" + mtb.b_time.ToString();
            }
            catch
            {
                Tunnel.Common.Message.back("不正确的ID"); return;
            }
        }
    }

    /// <summary>
    /// 附件列表
    /// </summary>
    /// <param name="filelist"></param>
    /// <returns></returns>
    public string getFile(string filelist)
    {
        int i = 0;
        string filecontent = "";
        if (filelist != "")
        {
            string[] filearr = filelist.Split(',');
            foreach (string file in filearr)
            {
                if (file != "")
                {
                    i++;
                    filecontent += Tunnel.Common.GetValue.getfu(file, "", i);
                }
            }
            return filecontent;
        }
        else
        {
            return "无附件";
        }

    }
}
