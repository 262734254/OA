using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class N_News_OutMessage_NowMessage : System.Web.UI.Page
{
    public static string SearchWhere = string.Empty;

    private Tunnel.BLL.Tunnel_menber tbll = new Tunnel.BLL.Tunnel_menber();
    public static Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchWhere = "";
            PageBind();
        }
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        string strsql = "select * from Tunnel_Message where datediff(dd,MesDate,GETDATE())=0 " + SearchWhere + " and DelDate is null order by MesDate Desc";
        DataSet das = Tunnel.Data.DbHelperSQL.Query(strsql);
        GridViewE.DataSource = das;
        GridViewE.DataBind();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string word = " ";
        word = TextBox1.Text;
        SearchWhere =
            " and (MesTitle like '%" + word + "%' or " +
            "  MesContent like '%" + word + "%' )";
        PageBind();
    }

    #region 获得用户名
    public string GetUserName(string uid)
    {

        if (!string.IsNullOrEmpty(uid))
        {
            return Tunnel.Common.GetValue.getDataValue("Tunnel_menber", "m_name", "m_id=" + uid);
        }
        else
        {
            return "&nbsp;";
        }
    }
    #endregion
}
