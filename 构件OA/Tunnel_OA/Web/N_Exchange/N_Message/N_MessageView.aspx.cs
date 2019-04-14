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

public partial class grzm_ViewMessage : System.Web.UI.Page
{
    public int Id;
    private int typeid = 0;
    private Tunnel.BLL.Tunnel_mail tbll = new Tunnel.BLL.Tunnel_mail();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            Id = Convert.ToInt32(Request.QueryString["Id"]);
        if (!string.IsNullOrEmpty(Request.QueryString["typeid"]))
            typeid = Convert.ToInt32(Request.QueryString["typeid"]);
        else
            typeid = 1;
        if (typeid != 1)
            resert.Visible = false;
        PageBind();
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        if (Id == 0)
            return;
        Tunnel.Model.Tunnel_mail model = new Tunnel.Model.Tunnel_mail();
        List<Tunnel.Model.Tunnel_mail> modelList = new List<Tunnel.Model.Tunnel_mail>();
        model = tbll.GetModel(Id);
        modelList.Add(model);
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();

        if (model.m_Main == 0 && model.m_state == 0)
        {
            Tunnel.Model.Tunnel_mail modelUp = new Tunnel.Model.Tunnel_mail();
            modelUp.m_id = Id;
            modelUp.m_state = 1;
            modelUp.m_from = ul.LoginID;
            modelUp.m_Ip = Tunnel.Common.Common.GetIp();
            tbll.Update(modelUp);

            Tunnel.Model.Tunnel_mail modelUp2 = new Tunnel.Model.Tunnel_mail();
            modelUp2.m_id = Id - 1;
            modelUp2.m_state = 1;
            modelUp2.m_from = ul.LoginID;
            modelUp2.m_Ip = Tunnel.Common.Common.GetIp();
            tbll.Update(modelUp2);
            string strsql = "delete Tunnel_Remind where m_typeid=" + Id + " and m_type=2";
            Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
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

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Command(object sender, EventArgs e)
    {
        int relt = -1;
        if (Id > 0)
        {
            Tunnel.Model.Tunnel_mail model = new Tunnel_mail();
            model.m_id = Id;
            model.m_sort = 1;
            model.m_Ip = Tunnel.Common.Common.GetIp();
            model.m_from = ul.LoginID;
            relt = tbll.Update(model);
        }
        Tunnel.Common.Message.Show("删除成功！", "ReceiveMessage.aspx");
    }
    public string file(string fi)
    {
        if (!fi.Equals(""))
            return "附件：";
        else
            return "";
    }
    protected void resert_Click(object sender, EventArgs e)
    {
        Response.Redirect("N_MessageSend.aspx?Id=" + Id + "&classId=1");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string url = "N_MessageReceive.aspx";
        switch (typeid)
        {
            case 1:
                url = "N_MessageReceive.aspx";
                break;
            case 2:
                url = "N_MessageOld.aspx";
                break;
            case 3:
                url = "N_MessageRecycle.aspx";
                break;
            default:
                url = "N_MessageReceive.aspx";
                break;
        }
        Response.Redirect(url);
    }
}
