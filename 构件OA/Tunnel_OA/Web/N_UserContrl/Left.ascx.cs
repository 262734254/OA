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

public partial class N_UserContrl_Left : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
            userid.Value = ul.LoginID.ToString();
            this.bind();
            PageBind();
        }
    }

    void bind()
    {
        Tunnel.BLL.Tunnel_flow bflow = new Tunnel.BLL.Tunnel_flow();
        DataSet ds = bflow.GetList("f_sort<>18");
        //Repeater1.DataSource = ds;
        //Repeater1.DataBind();
    }


    public void PageBind()
    {
        #region 我的工作
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "喜报管理", "我的工作", false))
        {
            mxyg.Disabled = true;
            mxyg.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "统计报表", "我的工作", false))
        {
            cwbb.Disabled = true;
            cwbb.HRef = "";           
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "流程审批", "我的工作", false) && !Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "流程审核", "我的工作", false))
        {
            lcsp.Disabled = true ;
            lcsp.HRef = "";           
        }
        #endregion

        #region 文件管理
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "发布公文", "文件管理", false))
        {
            fbgw.Disabled = true;
            fbgw.HRef = "";           
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "文件传阅", "文件管理", false))
        {
            wjcy.Disabled = true;
            wjcy.HRef = "";           
        }
        #endregion

        #region 生产管理
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "项目排片", "生产管理", false))
        {

            scxm.Disabled = true;
            scxm.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "生产安排", "生产管理", false))
        {

            scap.Disabled = true;
            scap.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "生产报表", "生产管理", false))
        {
            scbb.Disabled = true;
            scbb.HRef = "";
        }
        #endregion

        #region 绩效考核
    
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "科室考核", "绩效考核", false))
        {

            kskh.Disabled = true;
            kskh.HRef = "";
            
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "分厂考核", "绩效考核", false))
        {

            fckh.Disabled = true;
           
            fckh.HRef = "";
 
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "管理科室", "绩效考核", false))
        {

            glks.Disabled = true;
 
            glks.HRef = "";

        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "管理分厂", "绩效考核", false))
        {

            glfc.Disabled = true;
  
            glfc.HRef = "";

        }

        #endregion

        #region 档案管理
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "荣誉汇总", "档案管理", false))
        {
            ryhz.Disabled = true;
            ryhz.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "图纸管理", "档案管理", false))
        {
            tzgl.Disabled = true;
            tzgl.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "图片管理", "档案管理", false))
        {
            xztp.Disabled = true;
            xztp.HRef = "";
        }
        #endregion

        #region 信息发布
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "公告管理", "信息发布", false))
        {
            fbgg.Disabled = true;
            fbgg.HRef = "";           
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "新闻管理", "信息发布", false))
        {
            fbxw.Disabled = true;
            fbxw.HRef = "";           
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "科室信息", "信息发布", false) && !Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "总工室", "科室信息", false))
        {
            fbksxx.Disabled = true;
            fbksxx.HRef = "";           
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "党建信息", "党工团", false))
        {
            djxx.Disabled = true;
            djxx.HRef = "";           
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "工会信息", "党工团", false))
        {
            
            ghxx.Disabled = true;
            ghxx.HRef = "";
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "团务信息", "党工团", false))
        {
            
            twxx.Disabled = true;
            twxx.HRef = "";           
        }
        //if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "绩效考核", "信息发布", false))
        //{
        //    jxkh.Disabled = true;
        //    jxkh.HRef = "";
        //}
        //if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "档案管理", "信息发布", false))
        //{
        //    xzda.Disabled = true;
        //    xzda.HRef = "";           
        //}
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "图片管理", "信息发布", false))
        {
            xztp.Disabled = true;
            xztp.HRef = "";           
        }
        //if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "标准规范", "信息发布", false))
        //{
        //    bzgf.Disabled = true;
        //    bzgf.HRef = "";
        //}
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "项经部管理", "信息发布", false))
        {
            xjbgl.Disabled = true;
            xjbgl.HRef = "";
        }

        #endregion

        #region 系统设置
        int xtsz = 0;
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "流程分类", "系统设置", false))
        {
            xtsz1.Visible = false;
            lcfl.Visible = false;
            xtsz++;
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "表单设计", "系统设置", false))
        {
            xtsz1.Visible = false;
            bdsj.Visible = false;
            xtsz++;
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "流程设计", "系统设置", false))
        {
            xtsz1.Visible = false;
            lcsj.Visible = false;
            xtsz++;
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "用户管理", "系统设置", false))
        {
            xtsz1.Visible = false;
            yhgl.Visible = false;
            xtsz++;
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "部门管理", "系统设置", false))
        {
            xtsz1.Visible = false;
            bmgl.Visible = false;
            xtsz++;
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "职务管理", "系统设置", false))
        {
            xtsz1.Visible = false;
            zwgl.Visible = false;
            xtsz++;
        }
        if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "角色管理", "系统设置", false))
        {
            xtsz1.Visible = false;
            jsgl.Visible = false;
            xtsz++;
        }
        //if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "投票管理", "系统设置", false))
        //{
        //    tpgl.Visible = false;
        //    xtsz++;
        //}
        //if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "数据备份", "系统设置", false))
        //{
        //    xtsz1.Visible = false;
        //    sjbf.Visible = false;
        //    xtsz++;
        //}
        if (xtsz == 10)
        {
            pId_08.Visible = false;
            xtsz1.Visible = false;
        }
        #endregion

        #region 项经部
        //if (!Tunnel.BLL.Permission.IfHasPrimision(userid.Value, "信息管理", "项经部", false))
        //{
        //    xxs1.Disabled = true;
        //    xxs1.HRef = "";           
        //}
        #endregion
    }

}
