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
using System.Data.SqlClient;
using Tunnel.Model;
using System.Collections.Generic;

public partial class N_News_N_EntryByTheDepartmentOf_N_XJBInfoManage : System.Web.UI.Page
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

    int cuttentPage;
    int pageSize = 28;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageBind();
        }
    }

    #region 页初始
    public void PageBind()
    {
        string xjb = m_UserLogin.getUserModel(m_UserLogin.LoginID).m_xjb.Replace("|",",");
        string strWhere = "";
        if (m_UserLogin.JiaoSe(m_UserLogin.LoginID).Trim().Equals("系统管理员"))
            strWhere = "1=1 AND del=0";
        else if (null != xjb && xjb != "")
            strWhere = string.Format("typeId IN ({0}) AND userId={1} AND del=0", xjb, m_UserLogin.LoginID);
        else
            strWhere = "1=2";

        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_InfoXJB";
        pb.FldName = "id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        pb.DoCount = 1;

        if (TextBox1.Text.Trim() != "")
        {
            strWhere += " AND Title like '%" + TextBox1.Text.Trim() + "%'";
        }

        pb.StrWhere = strWhere;
        m_InfoXJBBLL.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_InfoXJB> modelList = new List<Tunnel.Model.Tunnel_InfoXJB>();
        modelList = m_InfoXJBBLL.GetList3(pb, ref count);//获取分页结果


        //数据绑定
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();

        //数据分页
        MTCPager1.PageSize = pageSize;
        MTCPager1.RecordCount = count;
        MTCPager1.PageIndex = cuttentPage;
        if (count <= pb.PageSize)
            MTCPager1.Visible = false;
        else
            MTCPager1.Visible = true;
    }
    #endregion

    #region 翻页
    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        PageBind();
    }
    #endregion

    #region 删除记录
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandName);
        int relt = -1;
        cuttentPage = MTCPager1.PageIndex;
        Tunnel_InfoXJB model = m_InfoXJBBLL.GetModel(Id);
        //DelPricAndRider(Id);
        relt = m_InfoXJBBLL.Delete(Id);
        if (relt == 0)
        {
            Tunnel.Common.Message.Show("删除成功");
            string strsql = "";
            strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + m_UserLogin.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>删除项经部信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',2)";
            Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
        }
        else
            Tunnel.Common.Message.Show("删除失败");

        PageBind();
    }
    #endregion

    #region 修改
    /// <summary>
    /// 修改记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandName);
        Response.Redirect("N_XJBInfoAdd.aspx?id=" + Id + "");
    }
    #endregion

    #region 获得标题
    public string title(object str)
    {
        return Tunnel.Common.Common.SubStr(str, 32);
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }
    #endregion

    #region 显示用户真实姓名
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
    #endregion

    #region 获取部门
    public string GetBum(object o)
    {
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel_menber();
        tmm = tm.GetModel(Convert.ToInt64(o.ToString()));
        string strTemp = string.Empty;
        if (tmm != null)
        {
            Tunnel_bum tbb = new Tunnel_bum();
            Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
            tbb = tb.GetModel(Convert.ToInt64(tmm.m_bum.ToString()));
            if (tbb != null)
            {
                strTemp = tbb.b_name;
            }
        }
        return strTemp;
    }
    #endregion

    #region 显示项经部
    /// <summary>
    /// 显示项经部
    /// </summary>
    /// <param name="typeid">项经部ID</param>
    /// <returns>项经部名称</returns>
    public string Getsectype(string typeid)
    {
        return m_xjbTypeBLL.GetModel(int.Parse(typeid)).Typename.Trim();
    }
    #endregion

    #region 显示类型
    public string strShow(string str)
    {
        if ("1" == str)
            return "生产日志";
        else
            return "基地动态";
    }
    #endregion

    #region 获取附件
    public string iffile(object o)
    {
        Tunnel.BLL.Tunnel_InfoXJB ti = new Tunnel.BLL.Tunnel_InfoXJB();
        Tunnel.Model.Tunnel_InfoXJB tii = new Tunnel_InfoXJB();
        tii = ti.GetModel(Convert.ToInt32(o.ToString()));

        if (!string.IsNullOrEmpty(tii.Files))
        {
            return "<font color=red>有</font>";
        }
        else
        {
            return "无";
        }
    }
    #endregion

    #region 批量删除操作
    protected void btnDel_Click(object sender, EventArgs e)
    {

        System.Web.UI.HtmlControls.HtmlInputCheckBox CBoxDelete;

        foreach (RepeaterItem rtitem in this.Repeater1.Items)
        {
            CBoxDelete = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rtitem.FindControl("cb1");

            if (CBoxDelete.Checked)
            {
                string id = ((HtmlInputHidden)rtitem.FindControl("SelectCode")).Value;
                Tunnel_InfoXJB model = m_InfoXJBBLL.GetModel(Convert.ToInt32(id));
                //DelPricAndRider(Convert.ToInt32(model.Id));
                m_InfoXJBBLL.Delete(Convert.ToInt32(model.Id));
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + m_UserLogin.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>删除项经部信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',2)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
        }
        PageBind();
    }
    #endregion

    #region Repeater绑定事件
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (m_UserLogin.LoginID != 1)
        {
            System.Web.UI.HtmlControls.HtmlInputCheckBox CBoxDelete;
            LinkButton lb = (LinkButton)e.Item.FindControl("LinkButton1");
            LinkButton lb2 = (LinkButton)e.Item.FindControl("LinkButton2");
            CBoxDelete = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("cb1");

            if (Convert.ToInt32(lb.CommandArgument.ToString()) != m_UserLogin.LoginID && m_UserLogin.JiaoSe(m_UserLogin.LoginID) != "系统管理员")
            {
                lb.Enabled = false;
                CBoxDelete.EnableViewState = false;
                lb.ToolTip = "不允许删除他人发布的信息";
                lb2.Enabled = false;
                lb2.ToolTip = "不允许修改他人发布的信息";
            }
        }
    }
    #endregion

    #region 删除附件和图片
    /// <summary>
    /// 删除附件和图片
    /// </summary>
    /// <param name="id">记录ID</param>
    protected void DelPricAndRider(int id)
    {
        string strsql = "select * from Tunnel_InfoXJB where id=" + id + "";
        SqlDataReader reader = Tunnel.Data.DbHelperSQL.ExecuteReader(strsql);
        string imgstr = "";
        if (reader.Read())
        {

            imgstr = From_Content(reader["htmlSource"].ToString().Trim());
            if (!imgstr.Equals(""))
            {
                if (imgstr.IndexOf("|") > 0)
                {
                    string[] array = imgstr.Split('|');
                    foreach (string strtemp1 in array)
                    {
                        File.Delete(Server.MapPath(strtemp1));
                    }
                }
                else
                {
                    File.Delete(Server.MapPath(imgstr));
                }
            }
            if (!reader["files"].ToString().Trim().Equals(""))
            {
                File.Delete(Request.PhysicalApplicationPath + reader["files"].ToString().Trim());
            }
            reader.Close();
        }

    }
    #endregion

    #region 取得图片信息
    /// <summary>
    /// 取得图片信息
    /// </summary>
    /// <param name="htmlcontent"></param>
    /// <returns></returns>
    private string From_Content(string htmlcontent)
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
                {
                    Match match2 = Regex.Match(match.Value, "src=(?:\"|\')?(?<imgSrc>[^>]*[^/].(?:jpg|bmp|gif|png))(?:\"|\')?");
                    str = match2.Value.Remove(0, 5).Remove(match2.Value.Remove(0, 5).LastIndexOf('"'), 1);
                }
                else
                {
                    Match match2 = Regex.Match(match.Value, "src=(?:\"|\')?(?<imgSrc>[^>]*[^/].(?:jpg|bmp|gif|png))(?:\"|\')?");
                    str = match2.Value.Remove(0, 5).Remove(match2.Value.Remove(0, 5).LastIndexOf('"'), 1) + "|" + str;
                }
            }
        }
        return str;
    }
    #endregion

    #region 查询
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        PageBind();
    }
    #endregion
}
