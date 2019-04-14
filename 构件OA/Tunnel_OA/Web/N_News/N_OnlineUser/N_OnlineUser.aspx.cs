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
using System.Text;
using System.Collections.Generic;

public partial class grzm_OnlineUser : System.Web.UI.Page
{
    int i = 0;
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public int onLineUser;
    public class CacheItems
    {
        public CacheItems(string key, string type)
        {
            this.CacheKey = key;
            this.CacheType = type;
        }

        private string cacheKey = string.Empty;

        public string CacheKey
        {
            get { return cacheKey; }
            set { cacheKey = value; }
        }
        private string cacheType = string.Empty;

        public string CacheType
        {
            get { return cacheType; }
            set { cacheType = value; }
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        List<CacheItems> cList = new List<CacheItems>();
        cList.Clear();
        IDictionaryEnumerator dic = Cache.GetEnumerator();
        while (dic.MoveNext())
        {
            if (dic.Value.GetType().ToString() == "Tunnel.Model.Tunnel_menber")
                cList.Add(new CacheItems(dic.Key.ToString(), dic.Value.GetType().ToString()));
        }
        onLineUser = cList.Count;
        if (!Page.IsPostBack)
        {
            i = 0;
            Bind();
        }
    }
    public string SearchWhere = string.Empty;

    public int cuttentPage;
    private Tunnel.BLL.Tunnel_menber tbll = new Tunnel.BLL.Tunnel_menber();
    void PageInit()
    {


    }
    public string GetFontColor(object o)
    {
        string str = o.ToString();
        Tunnel.BLL.UserLogin userlogin = new Tunnel.BLL.UserLogin();
        if (userlogin.ValidateCache(str))
        {
            return "red";
        }
        else
        {
            return "gray";
        }
    }
    #region MyRegion
    //protected void MTCPager1_PageIndexChanged(object sender, EventArgs e)
    //{
    //    cuttentPage = MTCPager1.PageIndex;
    //    Bind();
    //} 
    #endregion

    private void Bind()
    {
        #region MyRegion
        //Tunnel.Model.PageBase pagebase = new Tunnel.Model.PageBase();
        //pagebase.ProcedureName = "pagination_up";
        //pagebase.TblName = "Tunnel_menber";
        //pagebase.FldName = "m_id";
        //pagebase.StrWhere = "m_counttime>=0";
        //pagebase.OrderName = "m_counttime";
        //pagebase.OrderType = 1;
        //pagebase.DoCount = 0;
        //pagebase.PageSize = 20;
        //if (cuttentPage == 0)
        //    cuttentPage = pagebase.PageIndex;
        //pagebase.PageIndex = cuttentPage;
        //int count = 0;
        //List<Tunnel.Model.Tunnel_menber> modelList = new List<Tunnel.Model.Tunnel_menber>();
        //modelList = tbll.GetList_up(pagebase, ref count);//获取分页结果
        //pagebase.DoCount = 1;
        //tbll.GetList_up(pagebase, ref count); //获取总条数


        ////数据绑定
        //Repeater1.DataSource = modelList;
        //Repeater1.DataBind();

        ////数据分页
        //MTCPager1.PageSize = 20;
        //MTCPager1.RecordCount = count;
        //MTCPager1.PageIndex = cuttentPage;
        //if (count <= pagebase.PageSize)
        //    MTCPager1.Visible = false;
        //else
        //    MTCPager1.Visible = true; 
        #endregion


        StringBuilder strSql = new StringBuilder();
        strSql.Append("select m_id,m_name,m_online,m_onlinetime,m_counttime ");
        strSql.Append(" FROM Tunnel_menber where m_counttime>=0 order by m_counttime desc");
        DataSet ds = Tunnel.Data.DbHelperSQL.Query(strSql.ToString());
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }

    public string convertTime(string str)
    {
        string temp = string.Empty;
        if (!string.IsNullOrEmpty(str))
        {
            long num = Convert.ToInt64(str);
            long dayNum = 0;
            long HourNum = num / 60;
            long MinuteNum = num % 60;

            if (HourNum > 0)
                temp = HourNum + "小时" + MinuteNum + "分钟";
            else
                temp = MinuteNum + "分钟";

        }
        return temp;
    }
    public string username()
    { 
        i++;
        return i.ToString() + ". ";
    }
}
