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

public partial class N_UserContrl_Right : System.Web.UI.UserControl
{
    public string name = string.Empty;
    public string bum = string.Empty;
    public string duty = string.Empty;

    public string year = string.Empty;
    public string moon = string.Empty;
    public string content = string.Empty;
    public string img = string.Empty;
    public string mxId = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
        if (!IsPostBack)
        {

            HiddenField1.Value = ul.LoginID.ToString();
            showHtml(-1);
        }
    }


    /// <summary>
    /// 一周安排new两天
    /// </summary>
    public string PageBind()
    {
        string htmlSource = string.Empty;
        Tunnel.BLL.Tunnel_Index tbll = new Tunnel.BLL.Tunnel_Index();
        Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
        List<Tunnel.Model.Tunnel_index> txList = tbll.GetModelList("id=(select max(id) from tunnel_index where typeid=30 and del=0)");
        if (txList.Count > 0)
        {
            model = txList[0];
            if(Math.Abs( Convert.ToDateTime(model.SetDate).Subtract(DateTime.Now).Days)<2)
            htmlSource = "<font color='red'>new !</font>";
        }
        else
        {
            htmlSource = "";
        }
        return htmlSource;

    }

    public string showShengRi()
    {
        string str2 = string.Empty;
        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
        List<Tunnel.Model.Tunnel_menber> tmList = new List<Tunnel.Model.Tunnel_menber>();
        tmList = tm.GetModelList("1=1");
        for (int i = 0; i < tmList.Count; i++)
        {
            string shengRi = tmList[i].m_birth.ToString();
            string userName = tmList[i].m_name;
            for (int j = 0; j < 100; j++)
            {
                if (DateTime.Compare(Convert.ToDateTime(shengRi).AddYears(j), DateTime.Today) == 0)
                {
                    str2 += userName + "<br/>";
                }
            }
        }
        if (str2.Length > 0)
        {
            str2 = str2.Substring(0, str2.Length - 1);
        }
        return str2;
    }

    /// <summary>
    /// 明星员工
    /// </summary>
    /// <param name="d"></param>
    public void showHtml(int d)
    {
        Tunnel.BLL.Tunnel_MingXing tmx = new Tunnel.BLL.Tunnel_MingXing();
        Tunnel.Model.Tunnel_MingXing tmxx = new Tunnel.Model.Tunnel_MingXing();
        List<Tunnel.Model.Tunnel_MingXing> tmxxList = new List<Tunnel.Model.Tunnel_MingXing>();

        if (d == -1)
        {
            tmxxList = tmx.GetModelList(" 1=1 order by Convert(datetime,str(m_year)+'-'+str(M_moon)+'-'+'01') desc");
            if (tmxxList.Count > 0)
            {
                d = tmxxList[0].m_id;
            }
            
        }

        tmxxList = tmx.GetModelList("m_id = " + d + "");

        for (int i = 0; i < tmxxList.Count; i++)
        {
            Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
            Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();
            tmm = tm.GetModel(Convert.ToInt64(tmxxList[i].m_uid));
            if (tmm != null)
            {
                name = tmm.m_name;
                Tunnel.BLL.Tunnel_bum tb = new Tunnel.BLL.Tunnel_bum();
                Tunnel.Model.Tunnel_bum tbb = new Tunnel.Model.Tunnel_bum();
                tbb = tb.GetModel(Convert.ToInt64(tmm.m_bum));
                if (tbb != null)
                {
                    bum = tbb.b_name;
                    if (!string.IsNullOrEmpty(bum))
                    {
                        if (bum.Length > 8)
                        {
                            bum = bum.Substring(0, 8);
                        }
                    }
                }

                Tunnel.BLL.Tunnel_duty td = new Tunnel.BLL.Tunnel_duty();
                Tunnel.Model.Tunnel_duty tdd = new Tunnel.Model.Tunnel_duty();
                tdd = td.GetModel(Convert.ToInt64(tmm.m_duty));
                if (tdd != null)
                {
                    duty = tdd.d_name;
                }
            }
            year = tmxxList[i].m_year.ToString();
            moon = tmxxList[i].m_moon.ToString();
            img = "N_MyWork/N_Star/" + tmxxList[i].m_img;
            mxId = tmxxList[i].m_id.ToString();
        }

        string tempYear = DateTime.Now.AddMonths(-12).Year.ToString();
        string tempMoon = DateTime.Now.AddMonths(-12).Month.ToString();
        tmxxList = tmx.GetModelList("m_year >= " + tempYear + "  order by Convert(datetime,str(m_year)+'-'+str(M_moon)+'-'+'01') asc");

        int count = 0;
        foreach (Tunnel.Model.Tunnel_MingXing item in tmxxList)
        {
            if (item.m_moon >= Convert.ToInt32(tempMoon) || item.m_year != DateTime.Now.Year)
            {
                content += "<a href=?id=" + item.m_id + ">" + item.m_year + "-" + item.m_moon + "</a>  ";
                count++;
            }
            if (count > 1)
                break;
        }

    }

    public string showTitle(object o1, object o2)
    {
        string temp = string.Empty;

        if (DateTime.Now.CompareTo(Convert.ToDateTime(o2)) ==-1)
        {
            if (o1.ToString().Length > 10)
            {
                temp = o1.ToString().Substring(0, 10) + "..." + "<font color='red'>new!</font>";
            }
            else
            {
                temp = o1.ToString() + "<font color='red'> new!</font>";
            }
        }
        else
        {
            if (o1.ToString().Length > 10)
            {
                temp = o1.ToString().Substring(0, 10) + "...";
            }
            else
            {
                temp = o1.ToString();
            }
        }

        return temp;
    }
    public string getclass(object row)
    {
        if (Convert.ToInt32(row) <=3)
            return "STYLE8";
        else
            return "STYLE9";
    }
}
