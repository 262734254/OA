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

public partial class SystemManage_Tunnel_JueSeGuanLi : System.Web.UI.Page
{
    public static string jid = string.Empty;
    public static Tunnel.BLL.Tunnel_jiaose tj = new Tunnel.BLL.Tunnel_jiaose();
    public static Tunnel.BLL.Tunnel_yingshe ty = new Tunnel.BLL.Tunnel_yingshe();
    public int cuttentPage;

    private int pageSize = 28;

    private Tunnel.BLL.Tunnel_jiaose tbll = new Tunnel.BLL.Tunnel_jiaose();
    private Tunnel.BLL.Tunnel_bum tjll = new Tunnel.BLL.Tunnel_bum();
    private Tunnel.BLL.Tunnel_duty dbll = new Tunnel.BLL.Tunnel_duty();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["delid"]))
            {
                jid = Request.QueryString["delid"].ToString();
                tj.Delete(Convert.ToInt64(jid));
                if (ty.GetModelList("y_jsid=" + jid).Count != 0)
                {
                    ty.Delete(ty.GetModelList("y_jsid=" + jid + "")[0].y_id);
                }
                Tunnel.Common.Message.Show("删除成功", "tunnel_jueseguanli.aspx");
            }
            PageBind();
        }
    }

    public string showhd(object o,object oo)
    {
        string temp = string.Empty;
        if (o.Equals("总经理") || o.Equals("系统管理员"))
        {
            temp += "不能删除"+o.ToString();
        }
        else
        {
            temp+=""
                +"<a href=tunnel_jueseupd.aspx?updid="+oo.ToString()+"><font color='red'>[改]</font></a>"
                + "<a href=tunnel_jueseguanli.aspx?delid=" + oo.ToString() + " onClick=\"return confirm('是否删除此条记录？')\"><font color='red'>[删]</font></a>";
        }
        return temp;
    }

    /// <summary>
    /// 页面数据绑定
    /// </summary>
    public void PageBind()
    {
        PageBase pb = new PageBase();
        pb.TblName = "Tunnel_jiaose";
        pb.FldName = "JSSort";
        pb.ProcedureName = "pagination";
        pb.PageSize = pageSize;
        if (cuttentPage == 0)
            cuttentPage = pb.PageIndex;
        pb.PageIndex = cuttentPage;
        int count = 0;
        List<Tunnel.Model.Tunnel_jiaose> modelList = new List<Tunnel.Model.Tunnel_jiaose>();
        modelList = tbll.GetList(pb, ref count);//获取分页结果
        pb.DoCount = 1;
        tbll.GetList(pb, ref count); //获取总条数


        //数据绑定
        GridView1.DataSource = modelList;
        GridView1.DataBind();

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
}
