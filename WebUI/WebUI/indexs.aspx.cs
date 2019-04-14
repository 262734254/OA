using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ExtAspNet;
using System.Xml.Linq;
using BLL.Power;
using Model;
using BLL.WorkHelper;
using IDAL.WorkHelper;
using BLL.Matter;

// 日志组件配置
[assembly: log4net.Config.DOMConfigurator(ConfigFile = "web.config", Watch = true)]
public partial class indexs : System.Web.UI.Page
{
    RolePowerManager rolePowerManager = new RolePowerManager();
    private static log4net.ILog log = log4net.LogManager.GetLogger("我的日志记录");

    static int uid = 0;
      



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  //如果不是回传加载数据
        {
            // 加载菜单
            // treeMenu.DataSource = XmlDataSource1;
            // treeMenu.DataBind();

            AjaxPro.Utility.RegisterTypeForAjax(typeof(indexs));//将本类的类型注册到ajaxPro中 好在js中调用该类的方法



            rptPending.DataSource = ExamineManager.SearchPending("已办", "会议申请");

            rptPending.DataBind();

            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                UserInfo user = Session["user"] as UserInfo;
                uid = user.UID;
                log.Info(string.Format("{0}进入系统", user.Name));
                if (user.Sex == "男")
                {
                    lblLoginName.Text = user.Name + "  先生";
                }
                else
                {
                    lblLoginName.Text = user.Name + "  女士";
                }
                //获取上次登录时间 
                lblTime.Text = Request.Cookies["LoginTime"].Value;
                lblCount.Text = Application["Count"].ToString();



                InitTree(user.Name);
                //清除没有子节点的根节点
                // ClearNodes();

                try
                {
                    log.Info("这是hansong的LOG INFO测试!");

                    log.Debug("这是hansong的LOG DEBUG测试!");

                    throw new Exception("这是hansong的LOG ERROR测试!");
                }
                catch (Exception er)
                {
                    log.Error("错误日志", er);
                }

            }


        }
    }
    protected void rptPending_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }



    private void InitTree(string username)
    {

        DataTable dt = rolePowerManager.SelectPowersByUID(((UserInfo)Session["user"]).UID);
        DataView dv = new DataView(dt);
        dv.RowFilter = "prarentId=0";

        foreach (DataRowView drv in dv)
        {
            ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
            node.Target = "main";

            node.Text = drv["PowerName"].ToString();
            node.ToolTip = drv["PowerId"].ToString();
            node.Expanded = true;
            treeMenu.Nodes.Add(node);
            AddReplies(dt, node);
        }



    }


    LeaveWord leave = LeaveWordManager.SelectLeaveWordMsgType("未读", uid);

    [AjaxPro.AjaxMethod]//自定义ajaxpro方法
    public String GetTotal()
    {

        return leave.Total == 0 ? "0" : leave.Total.ToString();

    }



    [AjaxPro.AjaxMethod]
    public string GetTitle()
    {


        return leave.MsgTitle.ToString();

    }




    //清除没有子节点的根节点
    private void ClearNodes()
    {
        if (treeMenu.Nodes[0] != null)
            treeMenu.Nodes[0].IconUrl = "~/images/tree_dir.gif";
        foreach (ExtAspNet.TreeNode node in treeMenu.Nodes[0].Nodes)// his.TVShow.Nodes所有第二个节点
        {
            if (node.Nodes.Count == 0)//是根节点并且没有子节点
            {
                node.Text = "";
                node.NodeID = "";
                node.IconUrl = "";

                //  treeMenu.Nodes.Remove(node);//删除该根节点
            }
            else
            {
                if (node.Nodes[0].Leaf)
                    node.IconUrl = "~/images/tree_27.gif";


            }

        }



    }


    private void AddReplies(DataTable dt, ExtAspNet.TreeNode node)
    {
        DataView dv = new DataView(dt);
        dv.RowFilter = "prarentId=" + node.ToolTip;
        foreach (DataRowView row in dv)
        {
            ExtAspNet.TreeNode replyNode = new ExtAspNet.TreeNode();


            replyNode.IconUrl = "~/images/tree_12.gif";

            replyNode.OnClientClick = string.Format("addTestTab('{0}','{1}');return false;", row["UrL"].ToString(), row["PowerName"].ToString());
            replyNode.Target = "main";
            replyNode.Text = row["PowerName"].ToString();
            replyNode.ToolTip = row["PowerId"].ToString();
            //replyNode.NavigateUrl =row["UrL"].ToString();
            replyNode.Expanded = true;


            node.Nodes.Add(replyNode);
            AddReplies(dt, replyNode);//子节点的子节点 
        }

    }
}
