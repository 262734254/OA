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
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

public partial class N_News_N_News_N_NewManage : System.Web.UI.Page
{
    private int cuttentPage;

    private int pageSize = 30;
    private bool delState;
    private Tunnel.BLL.Tunnel_information mbll = new Tunnel.BLL.Tunnel_information();
    private Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
    public int TypeId = 0;
    public string titleName = "管理新闻";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            PageBind();
        }
    }
    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_information";
        pb.FldName = "i_id";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;

        if (ul.LoginID == 1 || ul.JiaoSe(ul.LoginID).Equals("系统管理员"))
        {
            pb.StrWhere = " i_sort = " + TypeId + " and i_del=0";
        }
        else
        {
            if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "新闻审核", "新闻管理", false))
                pb.StrWhere = " i_sort = " + TypeId + " and i_user=" + ul.LoginID + " and i_del=0 or i_audituser=" + ul.LoginID;
            else
            pb.StrWhere = " i_sort = " + TypeId + " and i_user=" + ul.LoginID + " and i_del=0";
        }
        int count = 0;
        pb.DoCount = 1;
        mbll.GetList(pb, ref count); //获取总条数

        pb.DoCount = 0;
        //if (delState == true && pageSize == count)
        //{
        //    cuttentPage = cuttentPage - 1;
        //    pb.PageIndex = cuttentPage;
        //}
        List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
        if (!TextBox1.Text.Trim().Equals(""))
        {
            pb.StrWhere += " and i_title like '%" + TextBox1.Text.Trim() + "%' ";
        }
        modelList = mbll.GetList(pb, ref count);//获取分页结果

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

    /// <summary>
    /// 对功能按钮的功能控制
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lb = (LinkButton)e.Item.FindControl("LinkButton1");
        LinkButton lb2 = (LinkButton)e.Item.FindControl("LinkButton2");
        LinkButton lb3 = (LinkButton)e.Item.FindControl("LinkButton3");
        Tunnel.Model.Tunnel_information model = new Tunnel_information();
        model = mbll.GetModel(lb3.CommandName);
        //删除
        if (Convert.ToInt32(lb.CommandArgument.ToString()) == ul.LoginID || ul.LoginID == 1 || !ul.JiaoSe(ul.LoginID).Equals("系统管理员"))
        {
            lb.Enabled = true;
            lb.ToolTip = "";
        }
        else
        {
            lb.Enabled = false;
            lb.ToolTip = "不允许删除他人发布的信息";
        }
        //修改
        if (Convert.ToInt32(lb.CommandArgument) == ul.LoginID || model.i_audituser == ul.LoginID || ul.LoginID == 1 || ul.JiaoSe(ul.LoginID).Equals("系统管理员"))
        {
            lb2.Enabled = true;
            lb2.ToolTip = "";
        }
        else
        {
            lb2.Enabled = false;
            lb2.ToolTip = "不允许修改他人发布的信息";
        }
        //审核
        if (Tunnel.BLL.Permission.IfHasPrimision(ul.LoginID.ToString(), "新闻审核", "新闻管理", false) && ul.LoginID == model.i_audituser)
        {
            lb3.Visible = true;
            lb3.ToolTip = "";
        }
        else
        {
            if (ul.LoginID == 1 || ul.JiaoSe(ul.LoginID).Equals("系统管理员"))
            {
                lb3.Visible = true;
                lb3.ToolTip = "";
            }
            else
            {
                lb3.Visible = false;
                lb3.ToolTip = "您无法审核该信息";
            }
        }
        if (lb3.CommandArgument.Equals("1"))
        {
            lb3.Enabled = false;
            lb3.ToolTip = "审核已通过";
        }
    }

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {

        int Id = Convert.ToInt32(e.CommandName);
        string strsql = "select * from tunnel_information where i_id=" + Id + "";
        string file = "";
        SqlDataReader reader = Tunnel.Data.DbHelperSQL.ExecuteReader(strsql);
        string imgstr = "";
        if (reader.Read())
        {
            imgstr = From_Content(reader["i_content"].ToString().Trim());
            if (!reader["i_files"].Equals(null))
                file = reader["i_files"].ToString().Trim();
            if (!imgstr.Equals(""))
            {
                if (imgstr.IndexOf("|") > 0)
                {
                    string[] array = imgstr.Split('|');
                    foreach (string strtemp1 in array)
                    {
                        //File.Delete(Server.MapPath(strtemp1));
                    }
                }
                else
                {
                    //File.Delete(Server.MapPath(imgstr));
                }
            }
            reader.Close();
        }
        int relt = -1;
        relt = mbll.Delete(Id, ul.LoginID, Tunnel.Common.Common.GetIp());
        if (relt == 0)
            Tunnel.Common.Message.Show("删除成功");

        else
            Tunnel.Common.Message.Show("删除失败");       
        //DelDoc(Id);
        DelFile(file);
        cuttentPage = MTCPager1.PageIndex;
        delState = true;
        string temp = Server.MapPath("../").Replace("Index", "") + "upload/UpGongGaoImage" + "/" + Id + ".jpg";
        if (System.IO.File.Exists(temp))
            System.IO.File.Delete(temp);
        
        PageBind();
    }
    private void DelFile(string file)
    {
        string path = Request.PhysicalApplicationPath;
        path = path.Remove(path.LastIndexOf("\\", path.Length - 2));
        string files = Request.PhysicalApplicationPath + file;
        if (System.IO.File.Exists(files))
            System.IO.File.Delete(files);
    }
    private void DelDoc(int DocID)
    {
        XmlDocument XD = new XmlDocument();
        XD.Load(MapPath("~/FocusList.xml"));
        XmlNode XN = XD.SelectSingleNode("Image");
        XmlNode IC = XD.SelectSingleNode("/Image/*[@ID=\"" + DocID.ToString() + "\"]");
        if (IC != null)
        {
            XN.RemoveChild(IC);
            XD.Save(MapPath("~/FocusList.xml"));
        }
    }
    /// <summary>
    /// 取得图片信息
    /// </summary>
    /// <param name="htmlcontent"></param>
    /// <returns></returns>
    public string From_Content(string htmlcontent)
    {
        string str = string.Empty;
        string content = htmlcontent.Replace("\n", "").ToLower();
        content = content.Replace("\r", "");
        content = content.Replace("\t", "");
        string input_tag = @"(<img)((.|\n)*?)(>)";
        MatchCollection mx = Regex.Matches(content, input_tag);
        foreach (Match match in mx)
        {
            if (Regex.IsMatch(match.Value, @"(<img)((.|\n)*?)(>)"))
            {
                if (string.IsNullOrEmpty(str))
                {
                    Match match2 = Regex.Match(match.Value, "src=(?:\"|\')?(?<imgSrc>[^>]*[^/].(?:jpg|bmp|gif|png))(?:\"|\')?");
                    str = match2.Value.Remove(0, 5).Remove(match2.Value.Remove(0, 5).LastIndexOf('"'), 1);
                }
                else
                {
                    Match match2 = Regex.Match(match.Value, "src=(?:\"|\')?(?<imgSrc>[^>]*[^/].(?:jpg|bmp|gif|png))(?:\"|\')?");
                    str = match2.Value.Remove(0, 5).Remove(match2.Value.Remove(0, 5).LastIndexOf('"'), 1) + "|" + str;
                }
            }
        }
        return str;
    }



    /// <summary>
    /// 显示用户真实姓名
    /// </summary>
    /// <param name="Id">用户Id</param>
    /// <returns></returns>
    public string ShowUserName(string UserId)
    {
        Tunnel.BLL.Tunnel_menber mbll = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
        model = mbll.GetModel(Convert.ToInt64(UserId));
        string strTemp = string.Empty;
        if (model != null)
            strTemp = model.m_name;
        return strTemp;
    }
    /// <summary>
    /// 修改记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        string id = e.CommandName;

        Response.Redirect("N_NewUpd.aspx?id=" + id);
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        PageBind();
    }
    /// <summary>
    /// 审核
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton3_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("N_NewSh.aspx?id=" + e.CommandName);
    }
    /// <summary>
    /// 将附件节点写入XML中
    /// </summary>
    /// <param name="NewsID"></param>
    /// <param name="NewsTitle"></param>
    /// <param name="ImgPath"></param>
    private void AddDoc(int NewsID, string NewsTitle, string ImgPath)
    {
        XmlDocument XD = new XmlDocument();
        XD.Load(MapPath("~/FocusList.xml"));
        XmlNode IRoot = XD.SelectSingleNode("Image");
        XmlElement XE = XD.CreateElement("Focus");
        XE.SetAttribute("ID", NewsID.ToString());
        XmlElement ITitle = XD.CreateElement("Title");
        ITitle.InnerText = NewsTitle;
        XE.AppendChild(ITitle);
        XmlElement IPath = XD.CreateElement("Path");
        IPath.InnerText = ImgPath;
        XE.AppendChild(IPath);
        IRoot.AppendChild(XE);
        XD.Save(MapPath("~/FocusList.xml"));

    }
    public string Audit(object o)
    {
        string result = "";
        int i = (int)o;
        switch (i)
        {
            case 0:
                result = "<font color='red'>待审核</font>";
                break;
            case 1:
                result = "<font color='green'>已通过</font>";
                break;
            case 2:
                result = "<font color='red'>已驳回</font>";
                break;
            default:
                result = "<font color='red'>未审核</font>";
                break;
        }
        return result;
    }
}
