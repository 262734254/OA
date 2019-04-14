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
using System.Collections.Generic;

public partial class N_WorkFlow_MyApply_Apply_Sp : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_bumf tb = new Tunnel.BLL.Tunnel_bumf();
    Tunnel.Model.Tunnel_bumf mb = new Tunnel.Model.Tunnel_bumf();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
    Tunnel.Model.Tunnel_index tmt = new Tunnel.Model.Tunnel_index();
    Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.ShowInit("");
            if (!string.IsNullOrEmpty(Request.Params["delid"]))
            {
                mb = tb.GetModel(Convert.ToInt32(Request.Params["delid"]));
                if ("issure".Equals(Request.Params["mod"]))
                {
                    tmt.Title = mb.b_title;
                    tmt.TypeId = 5;
                    tmt.HtmlSource = fc.From_Content(mb.b_formcontent, mb.b_content, true);//取得替换后的表单数据
                    tmt.UserId = mb.b_user;
                    Tunnel.BLL.Tunnel_information bllf = new Tunnel.BLL.Tunnel_information();
                    int relt = -1;
                    relt = bllf.Add(tmt);
                }
                tb.Delete(mb.b_id);
                Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE FROM TUNNEL_EXAM WHERE E_GID=" + mb.b_id);
                Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE FROM Tunnel_Advice WHERE A_GID=" + mb.b_id);
                Tunnel.Common.Del_File delfile = new Tunnel.Common.Del_File();
                delfile.FileDelete(mb.b_file);
                Tunnel.Common.Message.Show("操作成功！");
            }
        }
    }

    void ShowInit(string sql)
    {
        DataSet ds = new DataSet();
        string where = "";
        string userlist = "0";
        Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
        ul.UsbnLogin = bm.GetModel(ul.LoginID);
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "流程审核", "我的工作", false))
        {
            DataSet dss = new DataSet();
            if (ul.JiaoSe(ul.LoginID) != "系统管理员")
            {
                dss = bm.GetList("m_bum=" + ul.UsbnLogin.m_bum);

                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    userlist += dr["m_id"].ToString() + ",";
                }
                if (userlist.Length > 0)
                {
                    userlist = userlist.Substring(0, userlist.Length - 1);
                }
            }
            else
            {
                userlist = "0";
            }
        }
        else
        {
            userlist = "0";
        }
        if ("search".Equals(sql))
        {
            if (TextBox1.Text.Trim() != "")
            {
                where += " and b_time>='" + TextBox1.Text + "'";
            }
            if (TextBox2.Text.Trim() != "")
            {
                where += " and b_time<='" + TextBox2.Text + "'";
            }
            if (TextBox3.Text.Trim() != "")
            {
                try
                {
                    where += " and b_id=" + int.Parse(TextBox3.Text.Trim());
                }
                catch
                {
                    Tunnel.Common.Message.back("请输入正确的文号");
                }
            }
            if (TextBox4.Text.Trim() != "")
            {
                where += " and b_title like '%" + TextBox4.Text + "%'";
            }
        }
        else
        {
            where = "";
        }
        string sWhere = "";
        if (ul.JiaoSe(ul.LoginID) != "系统管理员")
        {
            sWhere = "select DISTINCT bf.b_id,bf.b_title,bf.b_sort,bf.b_time,bf.b_file,bf.b_state,bf.b_user,bf.b_suser,bf.b_stype from tunnel_bumf bf left join tunnel_exam em on bf.b_id=em.e_gid left join tunnel_step ep on em.e_nextbid=ep.s_id where (((CHARINDEX('" + ul.LoginID + ",', ep.s_zid)>=1 or ep.s_zid ='" + ul.LoginID + "') or (CHARINDEX('" + ul.LoginID + ",', em.e_nextbuser) >= 1 or em.e_nextbuser ='" + ul.LoginID + "')) " + where + " and bf.b_state>0) or (b_user in(" + userlist + ") or b_suser=" + ul.LoginID + ") order by bf.b_state asc,bf.b_time desc";
            ds = Tunnel.Data.DbHelperSQL.Query(sWhere);
        }
        else
        {
            ds = tb.GetList("b_state>0 " + where + " order by b_state asc,b_time desc");
        }
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables[0].DefaultView;//设置数据源(DataTable类型)
        pds.AllowPaging = true;
        //每页显示的行数
        //pds.PageSize = 12;
        AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        pds.PageSize = AspNetPager1.PageSize;
        Repeater1.DataSource = pds;
        Repeater1.DataBind();
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        ShowInit("");
    }

    int i = 0;
    public string getFile(string filelist)
    {

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
            return "&nbsp;";
        }

    }

    public string getState(string state)
    {
        switch (state)
        {
            case "1":
                return "<font color=green>审核中</font>";
            case "2":
                return "<font color=red>审批中</font>";
            case "3":
                return "己结束";
            default:
                return "<font color=blue>审批未通过</font>";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.ShowInit("search");
    }
    public string geshiriqi(object o)
    {
        string str = "";
        string result = "";
        if (o != null)
        {
            str = o.ToString();
        }
        if (str.IndexOf("(") > 0 && str.LastIndexOf(")") > 0)
        {
            result = str.Substring(0, str.IndexOf("(") + 1) + (Convert.ToDateTime(str.Substring(str.IndexOf("(") + 1, str.LastIndexOf(")") - str.LastIndexOf("(") - 2))).ToString("yyyy-MM-dd HH:mm:ss") + ")";
        }
        else
        {
            result = str;
        }
        return result;
    }

    public string getUserName(string uid)
    {

        if (!string.IsNullOrEmpty(uid))
        {
            return Tunnel.Common.GetValue.getDataValue("Tunnel_menber", "m_name", "m_id=" + uid);
        }
        else
        {
            return "";
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.ShowInit("search");
    }
    /// <summary>
    /// 获取菜单
    /// </summary>
    /// <param name="bid">公文ID</param>
    /// <param name="state">公文状态</param>
    /// <param name="uli">发布人ID</param>
    /// <param name="sort">公文分类</param>
    /// <returns></returns>
    public string GetMenu(string bid, string state, string uli, string sort, string stype)
    {
        string l = "";
        if ("0".Equals(stype) || string.IsNullOrEmpty(stype))
        {
            l = "<a href=\"../ODocument/Document_FlowView.aspx?lid=" + bid + "\" target=\"_blank\">流程图</a> ";
            switch (state)
            {
                case "1":
                    if (ul.JiaoSe(ul.LoginID) == "系统管理员")
                        l += "<a href=\"Apply_zSh.aspx?bid=" + bid + "\">审核</a>";
                    else
                    {
                        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "流程审批", "我的工作", false))
                        {
                            if (ul.JiaoSe(ul.LoginID) != "系统管理员")
                            {
                                string ll = "";
                                List<Tunnel.Model.Tunnel_menber> mlist = new List<Tunnel.Model.Tunnel_menber>();
                                mlist = bm.GetModelList("m_bum=" + ul.UsbnLogin.m_bum);
                                foreach (Tunnel.Model.Tunnel_menber mm in mlist)
                                {
                                    ll = "<a href=\"Apply_zSh.aspx?bid=" + bid + "\">审核</a>";
                                }
                                l += ll;
                            }
                        }
                    }
                    break;
                case "2":
                    if (ul.JiaoSe(ul.LoginID) == "系统管理员")
                    {
                        l += "<a href=\"Apply_zSp.aspx?bid=" + bid + "\">审批</a>";
                    }
                    else
                    {
                        string currbid = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbid", "e_gid=" + bid + " order by e_id desc");
                        if ("".Equals(currbid)) return "";
                        string ulist = Tunnel.Common.GetValue.getDataValue("Tunnel_step", "s_zid", "s_id=" + currbid);
                        if ("".Equals(ulist)) return "";
                        else
                        {
                            string[] list = ulist.Split(',');

                            foreach (string u in list)
                            {
                                if (u == ul.LoginID.ToString())
                                    l += "<a href=\"Apply_zSp.aspx?bid=" + bid + "\">审批</a>";
                            }
                        }
                    }
                    break;
                default:
                    l += "";
                    break;
            }
        }
        else
        {
            l = "<a href=\"../OtherDocument/Other_FlowView.aspx?lid=" + bid + "\" target=\"_blank\">流程图</a> ";
            switch (state)
            {
                case "1":
                    if (ul.JiaoSe(ul.LoginID) == "系统管理员")
                        l += "<a href=\"Apply_zSh.aspx?bid=" + bid + "\">审核</a>";
                    else
                    {
                        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "流程审批", "我的工作", false))
                        {
                            if (ul.JiaoSe(ul.LoginID) != "系统管理员")
                            {
                                string ll = "";
                                List<Tunnel.Model.Tunnel_menber> mlist = new List<Tunnel.Model.Tunnel_menber>();
                                mlist = bm.GetModelList("m_bum=" + ul.UsbnLogin.m_bum);
                                foreach (Tunnel.Model.Tunnel_menber mm in mlist)
                                {
                                    ll= "<a href=\"Apply_zSh.aspx?bid=" + bid + "\">审核</a>";
                                }
                                l += ll;
                            }
                        }
                    }
                    break;
                case "2":
                    if (ul.JiaoSe(ul.LoginID) == "系统管理员")
                    {
                        l += "<a href=\"../OtherDocument/Other_zSp.aspx?bid=" + bid + "\">审批</a>";
                    }
                    else
                    {
                        string ulist = Tunnel.Common.GetValue.getDataValue("Tunnel_exam", "e_nextbuser", "e_gid=" + bid + " order by e_id desc");
                        if ("".Equals(ulist)) return "";
                        else
                        {
                            string[] list = ulist.Split(',');

                            foreach (string u in list)
                            {
                                if (u == ul.LoginID.ToString())
                                    l += "<a href=\"../OtherDocument/Other_zSp.aspx?bid=" + bid + "\">审批</a>";
                            }
                        }
                    }
                    break;
                default:
                    l += "";
                    break;
            }
        }
        return l;
    }

    public string getTitleUrl(string bid, string title, string stype)
    {
        if ("0".Equals(stype) || string.IsNullOrEmpty(stype))
        {
            return "<a href=\"../ODocument/Document_View.aspx?lid=" + Tunnel.Data.DESEncrypt.Encrypt(bid) + "\" target=\"_blank\">" + title + "</a>";
        }
        else
        {
            return "<a href=\"../OtherDocument/Other_View.aspx?lid=" + Tunnel.Data.DESEncrypt.Encrypt(bid) + "\" target=\"_blank\">" + title + "</a>";
        }
    }
}
