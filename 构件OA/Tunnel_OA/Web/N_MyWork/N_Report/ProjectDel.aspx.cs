using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Tunnel.Model;

public partial class SystemManage_KaoHe_DelAllCent : System.Web.UI.Page
{
    public static string SearchWhere = string.Empty;

    public int cuttentPage;

    private int pageSize = 15;

    public static int itms = 0;

    public static string kaoList = string.Empty;

    public static string FenList = string.Empty;

    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public void IfShow()
    {
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核管理", "统计报表", false))
        {
            xinzengkaohe.Disabled = true;
            xinzengkaohe.HRef = "";
            guanligongcheng.Disabled = true;
            guanligongcheng.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核打分", "统计报表", false))
        {
            kaohedafen.Disabled = true;
            kaohedafen.HRef = "";
        }
    }
    Tunnel.BLL.Tunnel_items ti = new Tunnel.BLL.Tunnel_items();
    Tunnel.Model.Tunnel_items tii = new Tunnel.Model.Tunnel_items();
    List<Tunnel.Model.Tunnel_items> tiiList = new List<Tunnel.Model.Tunnel_items>();

    Tunnel.BLL.Tunnel_check tc = new Tunnel.BLL.Tunnel_check();
    Tunnel.Model.Tunnel_check tcc = new Tunnel.Model.Tunnel_check();
    List<Tunnel.Model.Tunnel_check> tccList = new List<Tunnel.Model.Tunnel_check>();

    Tunnel.BLL.Tunnel_grade tg = new Tunnel.BLL.Tunnel_grade();
    Tunnel.Model.Tunnel_grade tgg = new Tunnel.Model.Tunnel_grade();
    List<Tunnel.Model.Tunnel_grade> tggList = new List<Tunnel.Model.Tunnel_grade>();

    protected void Page_Load(object sender, EventArgs e)
    {
        IfShow();
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                itms = Convert.ToInt32(Request["id"].ToString());
                try
                {
                    Del();
                }
                catch (Exception)
                {

                }
                Response.Redirect("ProjectDel.aspx");
            }
            PageBind();
        }
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

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_items";
        pb.FldName = "i_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        pb.StrWhere = SearchWhere;
        int count = 0;
        List<Tunnel.Model.Tunnel_items> modelList = new List<Tunnel.Model.Tunnel_items>();
        modelList = ti.GetList(pb, ref count);//获取分页结果
        pb.DoCount = 1;
        ti.GetList(pb, ref count); //获取总条数


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

    public void Del()
    {
        GetTccList();
        GetTggList();        
    }

    public void GetTccList()
    {
        tccList = tc.GetModelList("c_itemsId = " + itms + "");
        foreach (Tunnel_check item in tccList)
        {
            kaoList += item.c_id + "|";
            tc.Delete(item.c_id);
        }
        ti.Delete(itms);
    }

    public void GetTggList()
    {
        if (kaoList.Length > 0)
        {
            foreach (string item in  kaoList.Split('|'))
            {
                tggList = tg.GetModelList("g_checkId = " + item.ToString() + "");
                foreach (Tunnel_grade item1 in tggList)
                {
                    tg.Delete(item1.g_id);
                }
            }
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item in Repeater1.Items)
        {
            string tempText = ((TextBox)item.FindControl("TextBox1")).Text;
            itms = Convert.ToInt32(tempText);
            if (((CheckBox)item.FindControl("CheckBox1")).Checked)
            {
                try
                {
                    Del();
                }
                catch (Exception)
                {

                }
            }
        }
        PageBind();
    }
}
