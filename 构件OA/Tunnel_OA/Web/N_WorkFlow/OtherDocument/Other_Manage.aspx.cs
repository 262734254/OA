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

public partial class N_WorkFlow_OtherDocument_Other_Manage : System.Web.UI.Page
{
    Tunnel.BLL.Tunnel_bumf tb = new Tunnel.BLL.Tunnel_bumf();
    Tunnel.Model.Tunnel_bumf mb = new Tunnel.Model.Tunnel_bumf();
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    Tunnel.Common.Form_Class fc = new Tunnel.Common.Form_Class();
    Tunnel.Model.Tunnel_index tmt = new Tunnel.Model.Tunnel_index();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
                Tunnel.Data.DbHelperSQL.ExecuteSql("DELETE FROM Tunnel_Remind WHERE m_type=1 and m_typeid=" + mb.b_id);
                Tunnel.Common.Del_File delfile = new Tunnel.Common.Del_File();
                delfile.FileDelete(mb.b_file);
                Tunnel.Common.Message.Show("操作成功！", "Other_Manage.aspx");
            }
            this.ShowInit("");
        }
    }

    void ShowInit(string sql)
    {
        DataSet ds = new DataSet();
        string where = "b_sort=0";
        Tunnel.BLL.Tunnel_menber bm = new Tunnel.BLL.Tunnel_menber();
        ul.UsbnLogin = bm.GetModel(ul.LoginID);
        if ("search".Equals(sql))
        {
            if (DropDownList2.SelectedValue != "")
            {
                where += " and b_state=" + DropDownList2.SelectedValue;
            }
            if (TextBox1.Text.Trim() != "")
            {
                where += " and b_time>='" + TextBox1.Text + "'";
            }
            if (TextBox2.Text.Trim() != "")
            {
                where += " and b_time<='" + TextBox2.Text + "'";
            }
            if (TextBox4.Text.Trim() != "")
            {
                where += " and b_title like '%" + TextBox4.Text + "%'";
            }
            if (ul.JiaoSe(ul.LoginID) != "系统管理员")
                where += " and b_user=" + ul.LoginID;
            where += " order by b_state asc,b_time desc";
            ds = tb.GetList(where);
            //对用于分页的类的引用
        }
        else
        {
            if (ul.JiaoSe(ul.LoginID) != "系统管理员")
                where = "b_user=" + ul.LoginID;
            where += " order by b_state asc,b_time desc";
            ds = tb.GetList(where);
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
            case "0":
                return "<font color=blue>审批未通过</font>";
            case "1":
                return "<font color=green>审核中</font>";
            case "2":
                return "<font color=red>审批中</font>";
            case "3":
                return "己结束";
            default:
                return "<font color=blue>审核未通过</font>";
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
    public string GetMenu(string bid, string state, string uli, string sort)
    {
        string l = "";
        switch (state)
        {
            case "-1":
            case "0":
                l = "<a href=\"Other_Edit.aspx?bid=" + bid + "\">重新提交</a>";
                break;
            default:
                l = "";
                break;
        }
        l += " <a onclick=\"return confirm('您确认删除及其所有附加项吗?');\" href=\"?delid=" + bid + "&mod=del\">删除</a>";
        return l;
    }
}