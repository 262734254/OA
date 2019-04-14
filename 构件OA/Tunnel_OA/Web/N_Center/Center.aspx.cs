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
using Tunnel.Model;
using System.Collections.Generic;

public partial class N_Center_Center : System.Web.UI.Page
{
    private Tunnel.BLL.Tunnel_information imbll = new Tunnel.BLL.Tunnel_information();
    private Tunnel.BLL.Tunnel_mail mbll = new Tunnel.BLL.Tunnel_mail();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    private int cuttentPage;
    private int pageSize = 8;
    public string imageName;
    public string userId;
    public int Count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageBind();
            GongGaoPageBind();
            XinWenPageBind();
        }
    }
    public string title(object str)
    {
        return Tunnel.Common.Common.SubStr(str, 30);
    }
    public string title(object str, int num)
    {
        return Tunnel.Common.Common.SubStr(str, num);
    }

    public string shownew(object o)
    {
        if (o != null)
        {
            string date = o.ToString().Split(' ')[0].ToString();
            if (Tunnel.BLL.Systemtime.GetThisWeekDate().Contains(date))
            {
                return "<sup>new!</sup>";
            }
            else
            {
                return " ";
            }
        }
        return " ";
    }
    public string FormatDate(string str)
    {
        if (!string.IsNullOrEmpty(str))
            str = Convert.ToDateTime(str).ToString("MM-dd").ToString();
        return str;
    }
    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_mail";
        pb.FldName = "m_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = 10;
        pb.PageIndex = 1;
        pb.StrWhere = " m_sort=0 and m_main = 0 and m_state=0 and m_to = " + ul.LoginID;
        pb.DoCount = 1;
        mbll.GetList(pb, ref Count); //获取总条数
        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_mail> modelList = new List<Tunnel.Model.Tunnel_mail>();
        modelList = mbll.GetList(pb, ref Count);//获取分页结果
        //数据绑定
        Repeater1.DataSource = modelList;
        Repeater1.DataBind();
        Tunnel.BLL.Tunnel_Remind tr = new Tunnel.BLL.Tunnel_Remind();
        Repeater5.DataSource = tr.GetList("m_touser=" + ul.LoginID);
        Repeater5.DataBind();
        Label1.Text = Repeater5.Items.Count.ToString();
    }
    /// <summary>
    /// 公告数据
    /// </summary>
    public void GongGaoPageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_information";
        pb.FldName = "i_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int TypeId = 1;
        pb.StrWhere = " i_sort = " + TypeId;
        int count = 0;
        pb.DoCount = 1;
        mbll.GetList(pb, ref count); //获取总条数
        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
        modelList = imbll.GetList(pb, ref count);//获取分页结果

        //数据绑定
        Repeater2.DataSource = modelList;
        Repeater2.DataBind();
        GetDirectories();
    }
    /// <summary>
    /// 新闻
    /// </summary>
    public void XinWenPageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_information";
        pb.FldName = "i_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int TypeId = 0;
        pb.StrWhere = " i_sort = " + TypeId + " and i_hit=1";
        int count = 0;
        pb.DoCount = 1;
        mbll.GetList(pb, ref count); //获取总条数
        pb.DoCount = 0;
        List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
        modelList = imbll.GetList(pb, ref count);//获取分页结果

        //数据绑定
        Repeater11.DataSource = modelList;
        Repeater11.DataBind();
        GetDirectories();
    }

    public void GetDirectories()
    {
        string dir = Server.MapPath("").Replace("Index", "") + "upload/UpGongGaoImage/";
        if (System.IO.Directory.Exists(dir))
        {
            System.IO.DirectoryInfo image = new System.IO.DirectoryInfo(dir);
            if (image.GetFiles("*.*").Length > 0)
            {
                string fileObj1 = image.GetFiles("*.jpg")[0].ToString().ToLower();
                string fileType1 = System.IO.Path.GetExtension(fileObj1);
                string fileObj2 = image.GetFiles("*.jpg")[image.GetFiles("*.jpg").Length - 1].ToString().ToLower();
                string fileType2 = System.IO.Path.GetExtension(fileObj2);
                int sImage = Convert.ToInt32(fileObj1.Replace(fileType1, ""));
                int bImage = Convert.ToInt32(fileObj2.Replace(fileType2, ""));
                if (image.GetFiles("*.jpg").Length > 1)
                {
                    if (sImage < bImage)
                        imageName = fileObj2;
                    else
                        imageName = fileObj1;
                }
                else
                {
                    imageName = fileObj1;
                }
            }
        }
    }
}
