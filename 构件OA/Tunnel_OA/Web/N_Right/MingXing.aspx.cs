using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MingXing : System.Web.UI.Page
{
    public string name = string.Empty;
    public string bum = string.Empty;
    public string title = string.Empty;
    public string year = string.Empty;
    public string moon = string.Empty;
    public string content = string.Empty;
    public string img = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
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
            }
            title = tmxxList[i].Title.ToString();
            year = tmxxList[i].m_year.ToString();
            moon = tmxxList[i].m_moon.ToString();
            img = "../N_MyWork/N_Star/" + tmxxList[i].m_img;
            content = tmxxList[i].m_content;

        }

        lblcontent.Text = content;


        string dateStr = string.Empty;

        string tempYear = year;
        string tempMoon = moon;
        string tempSql = @"
select * from (select top 4 * from (select top 4 * from tunnel_mingxing where  
Convert(datetime,lTRIM(str(m_year))+'-'+ltrim(str(m_moon))+'-'+'01') 
<substring(Convert(varchar,'" + year + "-" + (moon.Length == 1 ? "0" + moon : moon) + "-01" + @"',20),0,8)+'-01'  
order by Convert(datetime,lTRIM(str(m_year))+'-'+ltrim(str(m_moon))+'-'+'01') 
desc) as bb order by 
Convert(datetime,lTRIM(str(m_year))+'-'+ltrim(str(m_moon))+'-'+'01')) 
 as tunnel_mingxing 
union all  
select * from (select top 1 * from tunnel_mingxing where  
Convert(datetime,lTRIM(str(m_year))+'-'+ltrim(str(m_moon))+'-'+'01') 
=substring(Convert(varchar,'" + year + "-" + (moon.Length == 1 ? "0" + moon : moon) + "-01" + @"',20),0,8)+'-01' ) as tunnel_mingxing 
union all 
select * from (select top 4 * from tunnel_mingxing where  
Convert(datetime,lTRIM(str(m_year))+'-'+ltrim(str(m_moon))+'-'+'01') 
>substring(Convert(varchar,'" + year + "-" + (moon.Length == 1 ? "0" + moon : moon) + "-01" + @"',20),0,8)+'-01' ) as tunnel_mingxing 
 ";
        DataSet ds = Tunnel.Data.DbHelperSQL.Query(tempSql);
        tmxxList = tmx.DataTableToList(ds.Tables[0]);

        foreach (Tunnel.Model.Tunnel_MingXing item in tmxxList)
        {
            if (item.m_year == Convert.ToInt32(year) && Convert.ToInt32(item.m_moon) == Convert.ToInt32(moon))
                dateStr += "<a href=?id=" + item.m_id + "><font color=\"red\" style=\"14px\" >" + item.m_year + "-" + item.m_moon + "</font></a>  ";
            else
                dateStr += "<a href=?id=" + item.m_id + "><font color=\"black\" style=\"12px\" >" + item.m_year + "-" + item.m_moon + "</font></a>  ";
        }

        Label1.Text = dateStr;

    }
}
