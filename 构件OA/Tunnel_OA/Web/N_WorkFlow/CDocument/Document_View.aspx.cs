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

public partial class N_WorkFlow_VDocument_Document_View : System.Web.UI.Page
{
    public string file = "";
    Tunnel.BLL.Tunnel_CView tc = new Tunnel.BLL.Tunnel_CView();
    Tunnel.Model.Tunnel_CView mc = new Tunnel.Model.Tunnel_CView();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
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
            Tunnel.BLL.Tunnel_Cfile tf = new Tunnel.BLL.Tunnel_Cfile();
            Tunnel.Model.Tunnel_Cfile mf = new Tunnel.Model.Tunnel_Cfile();
            
            
            mf = tf.GetModel(Convert.ToInt32(Request.Params["File_Id"]));
            Label1.Text = mf.f_title;
            Label2.Text = mf.f_content;
            ul.UsbnLogin=ul.getUserModel(mf.f_user);
            Label3.Text = "发布人：" + ul.UsbnLogin.m_name + " 发布时间：" + mf.f_date.ToString();
            file=getFile(mf.f_file);

            
            DataSet ds = tc.GetList("c_fid=" + mf.f_id+" order by c_id asc");
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }
    int i = 0;
    public string getFile(string filelist)
    {

        string filecontent = "";
        if (!string.IsNullOrEmpty(filelist))
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
            return "&nbsp;";
        }
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Document_Manage.aspx");
    }
}
