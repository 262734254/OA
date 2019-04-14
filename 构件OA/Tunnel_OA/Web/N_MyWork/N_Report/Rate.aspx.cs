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

public partial class SystemManage_KaoHe_Tunnel_DFList : System.Web.UI.Page
{
    public static Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();

    public static string wid = string.Empty;
    public static string maxcent = string.Empty;
    public static string cid = string.Empty;

    public static Tunnel.BLL.Tunnel_check tc = new Tunnel.BLL.Tunnel_check();
    public static Tunnel.Model.Tunnel_check tcc = new Tunnel.Model.Tunnel_check();
    public static List<Tunnel.Model.Tunnel_check> tcList = new List<Tunnel.Model.Tunnel_check>();

    public static Tunnel.BLL.Tunnel_items ti = new Tunnel.BLL.Tunnel_items();
    public static Tunnel.Model.Tunnel_items tii = new Tunnel.Model.Tunnel_items();
    public static List<Tunnel.Model.Tunnel_items> tilist = new List<Tunnel.Model.Tunnel_items>();

    public static Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
    public static Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();

    public static Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
    public static Tunnel.Model.Tunnel_bum tbb = new Tunnel.Model.Tunnel_bum();

    public static Tunnel.BLL.Tunnel_work tw = new Tunnel.BLL.Tunnel_work();
    public static Tunnel.Model.Tunnel_work tww = new Tunnel.Model.Tunnel_work();
    public static List<Tunnel.Model.Tunnel_work> twList = new List<Tunnel.Model.Tunnel_work>();

    public static Tunnel.BLL.Tunnel_grade tg = new Tunnel.BLL.Tunnel_grade();
    public static Tunnel.Model.Tunnel_grade tgg = new Tunnel.Model.Tunnel_grade();
    public static List<Tunnel.Model.Tunnel_grade> tgList = new List<Tunnel.Model.Tunnel_grade>();

    public static string BumName = string.Empty;
    public static int BumID = 0;
    public static string tkBumList = string.Empty;
    public string tkWorkList = string.Empty;
    public string workAndKID = string.Empty;//工作表ID，最大分，考查表ID
    public string nianyue = string.Empty;
    public int GongZuoCount = 0;
    public int nums = 1;

    public static int cc = 0;

    public void GetAndBind()
    {
        List<Tunnel.Model.CheckList> clList = new List<Tunnel.Model.CheckList>();

        if (workAndKID.Length > 0)
        {
            foreach (string item in workAndKID.Split('|'))
            {
                string workid = item.Split(',')[0].ToString(); //工作表ID
                string maxcent = item.Split(',')[1].ToString();//最大分
                string checkid = item.Split(',')[2].ToString();//考核表ID
                tcc = tc.GetModel(Convert.ToInt32(checkid));
                tww = tw.GetModel(Convert.ToInt32(workid));
                if (tg.GetModelList("g_checkId=" + checkid + " and g_workId=" + workid + "").Count > 0)
                {
                    tgg = tg.GetModelList("g_checkId=" + checkid + " and g_workId=" + workid + "")[0];
                }
                Tunnel.Model.CheckList cl = new Tunnel.Model.CheckList();
                cl.Income = tcc.c_income;
                cl.Score = Convert.ToInt32(tcc.c_score.ToString());
                cl.Checkdate = tcc.c_date;
                cl.ItemsName = ti.GetModel(Convert.ToInt32(tcc.c_itemsId.ToString())).i_name;
                cl.UserName = tm.GetModel(Convert.ToInt64(tcc.c_userId.ToString())).m_name;
                cl.MaxCent = Convert.ToInt32(maxcent);
                cl.WorkName = tww.w_workName;
                cl.BumName = tww.w_bumName;
                cl.PFlist = "wid=" + workid + "&maxcent=" + maxcent + "&cid=" + checkid + "";
                clList.Add(cl);
            }
        }
        GridView1.DataSource = clList;
        GridView1.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        IfShow();
        nianyue = DropDownList1.SelectedValue;
        if (!IsPostBack)
        {
            for (int i = 2009; i < 2019; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    if (j > 9)
                        DropDownList1.Items.Add(new ListItem(i.ToString() + j.ToString(), i.ToString() + j.ToString()));
                    else
                        DropDownList1.Items.Add(new ListItem(i.ToString() + "0" + j.ToString(), i.ToString() + "0" + j.ToString()));
                    cc = 0;
                }
            }
            nianyue = DropDownList1.SelectedValue;

            try
            {
                CheckBumAndWork();
                if (cc == 0)
                    GetNotDaFen(true);
                else
                    GetNotDaFen();
                GetAndBind();
                cc++;
            }
            catch (Exception)
            {
                nianyue = DropDownList1.SelectedValue;
            }
        }
    }

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


    /// <summary>
    /// 判断是否属于打分部门并提取所有工作类型ID
    /// </summary>
    public void CheckBumAndWork()
    {
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "考核打分", "统计报表", false))
        {
            if (tm.GetModel(Convert.ToInt64(ul.LoginID.ToString())).m_bum != 0)
            {
                BumID = tm.GetModel(Convert.ToInt64(ul.LoginID.ToString())).m_bum;
                BumName = tb.GetModel(Convert.ToInt64(BumID.ToString())).b_name;
                twList = tw.GetModelList("1=1");
                if (twList.Count > 0)
                {
                    foreach (Tunnel.Model.Tunnel_work item in twList)
                    {
                        tkBumList += item.w_bumName + "|";
                    }
                }
                else
                {
                    Response.Redirect("error.aspx?id=无工作类型");
                }
                if (tkBumList.IndexOf(BumName) > -1)
                {
                    twList = tw.GetModelList("w_bumname='" + BumName + "'");

                    foreach (Tunnel.Model.Tunnel_work item in twList)
                    {
                        tkWorkList += item.w_id.ToString() + "," + item.w_maxCent.ToString() + "|";
                    }
                    if (tkWorkList.Length > 1)
                    {
                        tkWorkList = tkWorkList.Substring(0, tkWorkList.Length - 1);
                    }
                }
                else
                {
                    Response.Redirect("error.aspx?id=所在部门不在评分部门范围");
                }

            }
            else
            {
                Response.Redirect("error.aspx?id=您现在不属于任何部门");
            }
        }
        else
        {
            Response.Redirect("error.aspx?id=无评分权限");
        }

    }

    /// <summary>
    /// 得到还未打分的工作类型及对应的未打分项 并检查日期
    /// </summary>
    /// <param name="b"></param>
    public void GetNotDaFen(bool b)
    {
        for (int k = 200901; k < 201201; k++)
        {
            nianyue = k.ToString();
            tcList = tc.GetModelList("c_date='" + nianyue + "'");

            if (tcList.Count > 0)
            {
                foreach (Tunnel.Model.Tunnel_check itemCheck in tcList)
                {
                    foreach (string item in tkWorkList.Split('|'))
                    {
                        if (tg.GetModelList("g_workId=" + item.Split(',')[0].ToString() + " and g_checkId=" + itemCheck.c_id.ToString() + "").Count == 0)
                        {
                            workAndKID += item.Split(',')[0].ToString() + "," + item.Split(',')[1].ToString() + "," + itemCheck.c_id.ToString() + "|";
                        }
                    }
                }
                if (workAndKID.Length > 1)
                {
                    workAndKID = workAndKID.Substring(0, workAndKID.Length - 1);
                    DropDownList1.SelectedValue = nianyue;
                    return;
                }
            }
            else
            {
                nianyue = DropDownList1.SelectedValue;
            }
        }
    }


    /// <summary>
    ///  得到还未打分的工作类型及对应的未打分项 并检查日期
    /// </summary>
    public void GetNotDaFen()
    {
        tcList = tc.GetModelList("c_date='" + nianyue + "'");

        if (tcList.Count > 0)
        {

            foreach (Tunnel.Model.Tunnel_check item in tcList)
            {
                foreach (string item1 in tkWorkList.Split('|'))
                {
                    if (tg.GetModelList("g_workId=" + item1.Split(',')[0].ToString() + " and g_checkId=" + item.c_id.ToString() + "").Count == 0)
                    {
                        workAndKID += item1.Split(',')[0].ToString() + "," + item1.Split(',')[1].ToString() + "," + item.c_id.ToString() + "|";
                    }
                }
            }
            if (workAndKID.Length > 1)
            {
                workAndKID = workAndKID.Substring(0, workAndKID.Length - 1);
                DropDownList1.SelectedValue = nianyue;
                return;
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            int count = 0;
            foreach (RepeaterItem item in GridView1.Items)
            {
                string a = ((TextBox)item.FindControl("TextBox1")).Text;
                string b = ((TextBox)item.FindControl("TextBox2")).Text;

                tgg.g_checkId = Convert.ToInt32(b.Split('&')[2].Split('=')[1].ToString());
                tgg.g_workId = Convert.ToInt32(b.Split('&')[0].Split('=')[1].ToString());
                if (a.Length > 0)
                {
                    tgg.g_cent = Convert.ToSingle(b.Split('&')[1].Split('=')[1].ToString()) > Convert.ToSingle(a) ? Convert.ToSingle(a) : Convert.ToSingle(b.Split('&')[1].Split('=')[1].ToString());
                }

                if (a.Length > 0)
                {
                    tg.Add(tgg);
                    count++;
                }
            }

            if (count != 0)
            {
                Tunnel.Common.Message.Show("打分成功！", "Rate.aspx");
            }

        }
        catch (Exception)
        {
            Tunnel.Common.Message.Show("分数只能是整数或小数！", "Rate.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        nianyue = DropDownList1.SelectedValue;
        CheckBumAndWork();
        if (cc == 0)
            GetNotDaFen(true);
        else
            GetNotDaFen();
        GetAndBind();
        cc++;
    }
}
