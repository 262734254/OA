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
using Tunnel.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class profile_ProfileList : System.Web.UI.Page
{
    private int cuttentPage;
    private int pageSize = 30;
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private Tunnel.BLL.Tunnel_Profile pf = new Tunnel.BLL.Tunnel_Profile();
    private Tunnel.Model.Tunnel_Profile pff = new Tunnel_Profile();

    private static string name = string.Empty;
    private static string year = string.Empty;
    private static string bum = string.Empty;
    private static string type = string.Empty;
    private static string ren = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                name = Request.QueryString["name"].ToString();
                TextBox1.Text = name;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["year"]))
            {
                if (Request.QueryString["year"].ToString() != "请选择")
                {
                    year = Request.QueryString["year"].ToString();
                    TextBox2.Text = year;
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["bum"]))
            {
                if (Request.QueryString["bum"].ToString() != "请选择")
                {
                    bum = Request.QueryString["bum"].ToString();
                    DropDownList1.SelectedValue = bum;
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["type"]))
            {
                if (Request.QueryString["type"].ToString() != "请选择")
                {
                    type = Request.QueryString["type"].ToString();
                    DropDownList2.SelectedValue = type;
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["ren"]))
            {
                ren = Request.QueryString["ren"].ToString();
                TextBox5.Text = ren;

            }
            string strsql = "select p_bum from Tunnel_Profile group by p_bum select p_filetype from Tunnel_Profile group by p_filetype";
            ListItem item = new ListItem();
            item.Value = "";
            item.Text = "    ";

            DataSet ds = Tunnel.Data.DbHelperSQL.Query(strsql.ToString());
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataTextField = "p_bum";
            DropDownList1.DataValueField = "p_bum";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, item);


            DropDownList2.DataSource = ds.Tables[1];
            DropDownList2.DataTextField = "p_filetype";
            DropDownList2.DataValueField = "p_filetype";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, item);
            PageBind();
        }
    }

    public bool ifshow(object o)
    {
        if (o.ToString() == ul.LoginID.ToString() || ul.JiaoSe(ul.LoginID) == "系统管理员" || ul.LoginID == 1)
            return true;
        else
            return false;
    }

    public string showname(object uid)
    {
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        if (tm.GetModel(Convert.ToInt64(uid.ToString())) != null)
        {
            return tm.GetModel(Convert.ToInt64(uid.ToString())).m_name;
        }
        else
        {
            return "";
        }
    }

    public string showuid(string uname)
    {
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        if (tm.GetModelList(" m_name = '" + ren.Trim() + "'").Count > 0)
        {
            return tm.GetModelList("  m_name = '" + ren.Trim() + "'")[0].m_id.ToString();
        }
        else
        {
            return "-1";
        }
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_Profile";
        pb.FldName = "p_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        

        #region 条件查询
        pb.StrWhere = "";
        if (name.Length > 0)
        {
            pb.StrWhere += "  p_name like '%" + name + "%'  ";
        }
        if (year.Length > 0)
        {
            if (pb.StrWhere.Length > 0)
            {
                pb.StrWhere += "  and p_year like '%" + year + "%' ";
            }
            else
            {
                pb.StrWhere += "  p_year like '%" + year + "%' ";
            }

        }
        if (bum.Length > 0)
        {
            if (pb.StrWhere.Length > 0)
            {
                pb.StrWhere += "  and p_bum like '%" + bum + "%'  ";
            }
            else
            {
                pb.StrWhere += "  p_bum like '%" + bum + "%'  ";
            }
        }
        if (type.Length > 0)
        {
            if (pb.StrWhere.Length > 0)
            {
                pb.StrWhere += "  and p_filetype like '%" + type + "%'  ";
            }
            else
            {
                pb.StrWhere += "  p_filetype like '%" + type + "%'  ";
            }
        }
        if (ren.Length > 0)
        {
            if (pb.StrWhere.Length > 0)
            {
                pb.StrWhere += "  and p_uid = '" + showuid(ren.Trim()) + "'  ";
            }
            else
            {
                pb.StrWhere += "  p_uid = '" + showuid(ren.Trim()) + "'  ";
            }
        }

        #endregion

        int count = 0;
        pb.DoCount = 1;
        pf.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_Profile> modelList = new List<Tunnel.Model.Tunnel_Profile>();
        modelList = pf.GetList(pb, ref count);//获取分页结果

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
        PageBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        name = TextBox1.Text;
        year = TextBox2.Text;
        bum = DropDownList1.SelectedValue;
        type = DropDownList2.SelectedValue;
        ren = TextBox5.Text;
        PageBind();
    }

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {

        string a = e.CommandName.ToString();
        Tunnel.BLL.Tunnel_Profile pf = new Tunnel.BLL.Tunnel_Profile();
        pf.Delete(IsNum(a));
        Tunnel.Common.Message.Show("删除成功！");


    }
    private int IsNum(string num)
    {
        int a = 0;
        try
        {
            a = Convert.ToInt32(num);
        }
        catch (Exception)
        {

        }
        return a;
    }

}
