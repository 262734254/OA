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

public partial class N_News_N_Departments_N_KeshiManage : System.Web.UI.Page
{
    private Tunnel.BLL.Tunnel_InfoXJB mbll = new Tunnel.BLL.Tunnel_InfoXJB();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    Tunnel.Model.Tunnel_menber tmm = new Tunnel_menber();
    Tunnel.BLL.Tunnel_Index ti = new Tunnel.BLL.Tunnel_Index();

    public string key = string.Empty;

    public static string where = string.Empty;
    public int cuttentPage;
    private int pageSize = 28;

    public string bhtype = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListBind();
        }
    }
    public string title(object str)
    {
        return Tunnel.Common.Common.SubStr(str, 32);
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }
    public void ListBind()
    {
        if (ul.LoginID == 1 || ul.JiaoSe(ul.LoginID).Equals("系统管理员"))
        {
            where = "";
            PageBind2();
        }
        else
        {
            Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
            Tunnel_bum tbb = new Tunnel_bum();
            tmm = tm.GetModel(Convert.ToInt64(ul.LoginID.ToString()));
            if (tmm != null)
            {
                if (!string.IsNullOrEmpty(tmm.m_bum.ToString()))
                {
                    tbb = tb.GetModel(Convert.ToInt64(tmm.m_bum.ToString()));
                    if (tbb != null)
                    {
                        List<Tunnel.Model.Tunnel_InfoXJB> tsList = new List<Tunnel_InfoXJB>();
                        Tunnel.BLL.Tunnel_InfoXJB tst = new Tunnel.BLL.Tunnel_InfoXJB();
                        tsList = tst.GetModelList("");
                        // bumname='" + tbb.b_name + "'
                        if (tsList.Count > 0)
                        {
                            for (int i = 0; i < tsList.Count; i++)
                            {
                                bhtype += tsList[i].TypeId.ToString() + "|";
                            }
                            if (bhtype.Length > 0)
                            {
                                bhtype = bhtype.Substring(0, bhtype.Length - 1);
                            }
                        }
                        where = "";
                        //for (int i = 0; i < bhtype.Split('|').Length; i++)
                        //{
                        //    if (where.Length > 0)
                        //    {
                        //        if (i == bhtype.Split('|').Length - 1)
                        //        {
                        //            where += "  or typeid=" + bhtype.Split('|')[i] + ")";
                        //        }
                        //        else
                        //        {
                        //            where += "  or typeid=" + bhtype.Split('|')[i] + "";
                        //        }

                        //    }
                        //    else
                        //    {
                        //        where += "   (typeid=" + bhtype.Split('|')[i] + "";
                        //    }

                        //}
                        PageBind2();
                    }
                    else
                    {

                        MTCPager1.RecordCount = 0;
                    }
                }
            }
        }




    }

    public void PageBind2()
    {
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
        if (key.Length > 0)
        {
            key += " and Title like '%" + TextBox1.Text + "%'";
        }
        else
        {
            key += " 1=1 and Title like '%" + TextBox1.Text + "%'";
        }
        if (ul.LoginID == 1 || ul.JiaoSe(ul.LoginID).Equals("系统管理员"))
            key += " and typeid in (92,93,94,95,96,97,98,99,100,101,102,103) ";
        else
            key += " and typeid in (92,93,94,95,96,97,98,99,100,101,102,103) and bum_bz= " + ul.getUserModel(ul.LoginID).m_bum.ToString() + " and userid=" + ul.LoginID;
        where += key;
        pb.StrWhere = key + " and del=0";
        mbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_InfoXJB> modelList = new List<Tunnel.Model.Tunnel_InfoXJB>();
        modelList = mbll.GetList3(pb, ref count);//获取分页结果


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

    /// <summary>
    /// 翻页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    {
        cuttentPage = MTCPager1.PageIndex;
        ListBind();
    }

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
        Tunnel_InfoXJB model = mbll.GetModel(Id);
        //DelPricAndRider(Id);
        relt = mbll.Delete(Id);
        if (relt == 0)
        {
            Tunnel.Common.Message.Show("删除成功");
            string strsql = "";
            strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>删除项经部信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',2)";
            Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
        }
        else
            Tunnel.Common.Message.Show("删除失败");
        PageBind2();
    }
    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        int Id = Convert.ToInt32(e.CommandName);
        Response.Redirect("N_XJBAdd.aspx?pagetitle=1&indexId=" + Id + "");
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
    /// <summary>
    /// 显示子栏目
    /// </summary>
    /// <param name="Id">用户Id</param>
    /// <returns></returns>
    public string Getsectype(object o)
    {
        if (Convert.ToInt32(o) == 0)
        {
            return "无子栏目";
        }
        else
        {
            Tunnel.BLL.Tunnel_xjbType xj = new Tunnel.BLL.Tunnel_xjbType();
            Tunnel.Model.Tunnel_xjbType model = new Tunnel.Model.Tunnel_xjbType();
            model = xj.GetModel(Convert.ToInt32(o));
            string strTemp = string.Empty;
            if (model != null)
                strTemp = model.Typename;
            return strTemp;
        }
    }

    public string strShow(string str)
    {
        if (string.IsNullOrEmpty(str))
            return "";
        int typeId = Convert.ToInt32(str);

        Tunnel.BLL.SelType ts = new Tunnel.BLL.SelType();
        str = ts.GetModel(typeId).TypeName;

        return str;
    }

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

        //string filelist = tii.Files;
        //int i = 0;
        //string filecontent = "";
        //if (filelist != "")
        //{
        //    string[] filearr = filelist.Split(',');
        //    foreach (string file in filearr)
        //    {
        //        if (file != "")
        //        {
        //            i++;
        //            filecontent += Tunnel.Common.GetValue.getfu(file, "", i);
        //        }
        //    }
        //    return filecontent;
        //}
        //else
        //{
        //    return "&nbsp;";
        //}
    }

    //批量删除操作
    protected void btnDel_Click(object sender, EventArgs e)
    {

        System.Web.UI.HtmlControls.HtmlInputCheckBox CBoxDelete;

        foreach (RepeaterItem rtitem in this.Repeater1.Items)
        {
            CBoxDelete = (System.Web.UI.HtmlControls.HtmlInputCheckBox)rtitem.FindControl("cb1");

            if (CBoxDelete.Checked)
            {
                string id = ((HtmlInputHidden)rtitem.FindControl("SelectCode")).Value;
                Tunnel_InfoXJB model = mbll.GetModel(Convert.ToInt32(id));
                //DelPricAndRider(Convert.ToInt32(model.Id));
                mbll.Delete(Convert.ToInt32(model.Id));
                string strsql = "";
                strsql = "insert into tunnel_log(l_user,l_time,l_content,l_ip,l_sort) values(" + ul.LoginID + ",'" + DateTime.Now + "','公司事务>>项经部信息>>删除项经部信息。标题：" + model.Title + "','" + Tunnel.Common.Common.GetIp() + "',2)";
                Tunnel.Data.DbHelperSQL.ExecuteSql(strsql);
            }
        }
        PageBind2();
    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (ul.LoginID != 1)
        {
            System.Web.UI.HtmlControls.HtmlInputCheckBox CBoxDelete;
            LinkButton lb = (LinkButton)e.Item.FindControl("LinkButton1");
            LinkButton lb2 = (LinkButton)e.Item.FindControl("LinkButton2");
            CBoxDelete = (System.Web.UI.HtmlControls.HtmlInputCheckBox)e.Item.FindControl("cb1");

            if (Convert.ToInt32(lb.CommandArgument.ToString()) != ul.LoginID && ul.JiaoSe(ul.LoginID) != "系统管理员")
            {
                lb.Enabled = false;
                CBoxDelete.EnableViewState = false;
                lb.ToolTip = "不允许删除他人发布的信息";
                lb2.Enabled = false;
                lb2.ToolTip = "不允许修改他人发布的信息";
            }
        }
    }
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

    protected void BtnSearch_Click(object sender, EventArgs e)
    {

        ListBind();
    }
}
