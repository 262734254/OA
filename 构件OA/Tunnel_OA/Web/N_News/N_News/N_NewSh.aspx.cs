using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Tunnel.Model;
using System.Data.SqlClient;

public partial class Common_ViewNewsAnnouncement : System.Web.UI.Page
{
    private int Id;
    private Tunnel.BLL.Tunnel_information tbll = new Tunnel.BLL.Tunnel_information();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private int cuttentPage;
    private int TypeId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!string.IsNullOrEmpty(Request.QueryString["TypeId"]))
            TypeId = Convert.ToInt32(Request.QueryString["TypeId"]);
        PageBind();
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        if (Id == 0)
            return;
        Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
        List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
        model = tbll.GetModel(Id, ul.LoginID, Tunnel.Common.Common.GetIp());
        modelList.Add(model);
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
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

    public void NewSh()
    {
        if (Request.QueryString["id"] != null)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            int i_hit = 0;
            string str1 = "";
            if (RadioButton2.Checked)
            {
                i_hit = 1;
                str1 = "已通过审核";
            }
            if (RadioButton1.Checked)
            {
                i_hit = 2;
                str1 = "审核已被驳回";
            }
            string strsql = "update tunnel_information set i_hit=" + i_hit.ToString() + " where i_id=" + id.ToString();
            int result = Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            string str = "";
            if (result > 0)
            {
                str = "提交成功";
                PageBind();
            }
            else
                str = "提交失败";
            string strsql2 = "delete tunnel_remind where m_typeid=" + id.ToString() + " and m_type=4";
            Tunnel.Data.DbHelperSQL.ExecuteSql(strsql2);
            Tunnel.Common.Message.Show(str);
            Tunnel_log model = new Tunnel_log();
            model.l_content = "系统管理>>新闻管理>>审核新闻新闻，id:" + id;
            model.l_ip = Tunnel.Common.Common.GetIp();
            model.l_time = DateTime.Now;
            model.l_user = ul.LoginID;
            model.l_sort = 3;
            Tunnel.BLL.Tunnel_log log = new Tunnel.BLL.Tunnel_log();
            log.Add(model);
            strsql = "select * from tunnel_information where i_id=" + id;
            SqlDataReader reader = Tunnel.Data.DbHelperSQL.ExecuteReader(strsql);
            int touserId = 0;
            string titles = "";
            if (reader.Read())
            {
                touserId = Convert.ToInt32(reader["i_user"]);
                titles = reader["i_title"].ToString();
            }
            if (touserId > 0 && touserId != ul.LoginID)
            {
                Tunnel.BLL.Tunnel_mail rbll = new Tunnel.BLL.Tunnel_mail();
                Tunnel.Model.Tunnel_mail modelm = new Tunnel.Model.Tunnel_mail();
                modelm.m_title = "新闻" + str1;
                modelm.m_content = "您发布的新闻：" + titles + "。" + str1;
                modelm.m_file = "";
                modelm.m_time = DateTime.Now;
                modelm.m_from = ul.LoginID;
                modelm.m_sort = 0; // 0未删除、1删除
                modelm.m_state = 0; // 0未读、1已读
                modelm.m_Ip = Tunnel.Common.Common.GetIp();
                int relt1 = -1;
                for (int i = 1; i <= 2; i++)
                {
                    if (i == 1)
                    {
                        modelm.m_Main = 1; //标记是自己发的
                        modelm.m_to = Convert.ToInt32(touserId);
                        relt1 = rbll.Add(modelm);
                    }
                    else
                    {
                        modelm.m_Main = 0; //标记是发给别人的
                        modelm.m_to = Convert.ToInt32(touserId);
                        relt1 = rbll.Add(modelm);
                    }
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        NewSh();
    }
}
