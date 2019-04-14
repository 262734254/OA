using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_Right_Right : System.Web.UI.Page
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
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                string id = Request["id"].ToString();
                showHtml(Convert.ToInt32(id));
            }
            else
            {
                showHtml(-1);
            }

        }
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
                    str2 += userName + "<br />";
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
            img = "../N_MyWork/N_Star/" + tmxxList[i].m_img;
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
        lblcontent.Text = content;

    }

    public string showTitle(object o1, object o2)
    {
        string temp = string.Empty;

        if (Math.Abs(DateTime.Now.CompareTo(Convert.ToDateTime(o2))) < 7)
        {
            if (o1.ToString().Length > 10)
            {
                temp = o1.ToString().Substring(0, 10) + "..." + "<font color='red'>new!</font>";
            }
            else
            {
                temp = o1.ToString() + "<font color='red'>new!</font>";
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
}
