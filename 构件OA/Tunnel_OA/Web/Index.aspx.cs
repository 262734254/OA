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
using Tunnel.Model;
using System.Xml.XPath;

public partial class Index : System.Web.UI.Page
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
    public string DoImg()
    {
        string ImgString = string.Empty;
        string TitleString = string.Empty;
        string IDString = string.Empty;
        XPathDocument XPD = new XPathDocument(MapPath("FocusList.xml"));
        XPathNavigator XN = XPD.CreateNavigator();
        XPathNodeIterator XNI = XN.Select("/Image/Focus");
        IDString = "";
        int i = XNI.Count;
        while (XNI.MoveNext())
        {
            XNI.Current.MoveToFirstAttribute();
            //IDString = "|N_Index\\ViewGongGao.aspx?id=" + XNI.Current.Value + "#ampTypeId=0#amplanmuId=3" + IDString;
            IDString = "||||||||||||||||||||";
            XNI.Current.MoveToParent();
            XNI.Current.MoveToFirstChild();
            TitleString += "|" + XNI.Current.Value;
            XNI.Current.MoveToNext();
            ImgString += "|" + " " + XNI.Current.Value;
            XNI.Current.MoveToParent();
        }
        if (ImgString.Length > 1 && TitleString.Length > 1 && IDString.Length > 1)
        {
            string finalstring = "bcastr_file=" + ImgString.Remove(0, 1) + "&bcastr_link=" + IDString.Remove(0, 1) + "&bcastr_title=" + TitleString.Remove(0, 1) +
                "&bcastr_config=black:文字颜色|2:文字位置|0xf6f6f6:文字背景颜色|100:文字背景透明度|black:按键文字颜色|0xf6f6f6:按键默认颜色|0x000033:按键当前颜色" +
                "|10:自动播放时间(秒)|1:图片过渡效果|1:是否显示按钮|_self:打开窗口";
            Response.Write(finalstring);
            return string.Empty;
        }
        else
        {
            return string.Empty;
        }
    }
    public string DoImg2()
    {
        string ImgString = string.Empty;
        string TitleString = string.Empty;
        string IDString = string.Empty;
        XPathDocument XPD = new XPathDocument(MapPath("FocusList2.xml"));
        XPathNavigator XN = XPD.CreateNavigator();
        XPathNodeIterator XNI = XN.Select("/Image/Focus");
        IDString = "";
        int i = XNI.Count;
        while (XNI.MoveNext())
        {
            XNI.Current.MoveToFirstAttribute();
            //IDString = "|N_Index\\ViewGongGao.aspx?id=" + XNI.Current.Value + "#ampTypeId=0#amplanmuId=3" + IDString;
            IDString = "||||||||||||||||||||";
            XNI.Current.MoveToParent();
            XNI.Current.MoveToFirstChild();
            TitleString += "|" + XNI.Current.Value ;
            XNI.Current.MoveToNext();
            ImgString += "|" + " " + XNI.Current.Value ;
            XNI.Current.MoveToParent();
        }
        if (ImgString.Length > 1 && TitleString.Length > 1 && IDString.Length > 1)
        {
            string finalstring = "bcastr_file=" + ImgString.Remove(0, 1) + "&bcastr_link=" + IDString.Remove(0, 1) + "&bcastr_title=" + TitleString.Remove(0, 1) +
                "&bcastr_config=black:文字颜色|2:文字位置|0xf6f6f6:文字背景颜色|100:文字背景透明度|black:按键文字颜色|0xf6f6f6:按键默认颜色|0x000033:按键当前颜色" +
                "|10:自动播放时间(秒)|1:图片过渡效果|1:是否显示按钮|_self:打开窗口";
            Response.Write(finalstring);
            return string.Empty;
        }
        else
        {
            return string.Empty;
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
    public string showusername(object id)
    {
        Tunnel.BLL.Tunnel_menber mbll = new Tunnel.BLL.Tunnel_menber();
        return mbll.GetModel(Convert.ToInt64(id)).m_name;
    }
    public string FormatDate(string str)
    {
        if (!string.IsNullOrEmpty(str))
            str = Convert.ToDateTime(str).ToString("yyyy-MM-dd").ToString();
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
        Repeater5.DataSource = tr.GetList("m_type<>2 and m_type<>3 and m_touser=" + ul.LoginID);
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
        pb.StrWhere = " i_sort = " + TypeId+" and i_del=0";
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
        pb.PageSize = 4;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int TypeId = 0;
        pb.StrWhere = " i_sort = " + TypeId + " and i_hit=1" + " and i_del=0";
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
    protected void AdRotator1_AdCreated(object sender, AdCreatedEventArgs e)
    {

    }
}
