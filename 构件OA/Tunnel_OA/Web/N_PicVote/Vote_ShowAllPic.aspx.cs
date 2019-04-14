using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections;


public partial class _Default : System.Web.UI.Page
{
   
    public string BottomColor = string.Empty;//底部颜色
    public string TitleName = string.Empty;//页面标题

    private int vote_Count = 1;//默认每人只能投一票
    Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();//获取用户登录信息
    private int UserID = 0;//保存用户登录ID

    private Tunnel.BLL.Vote_Info voteInfoBLL = new Tunnel.BLL.Vote_Info();
    private Tunnel.Model.Vote_Info voteInfoModel = new Tunnel.Model.Vote_Info();

    private Tunnel.Model.VoteLog voteLogModel = new Tunnel.Model.VoteLog();
    private Tunnel.BLL.VoteLog voteLogBll = new Tunnel.BLL.VoteLog();
    private Tunnel.BLL.Date_Sys date_sysBLL = new Tunnel.BLL.Date_Sys();

    private Tunnel.BLL.Vote_Config config = new Tunnel.BLL.Vote_Config();
    private Tunnel.DAL.Vote_Config vote_configDAL = new Tunnel.DAL.Vote_Config();

    string VoteType = System.Configuration.ConfigurationSettings.AppSettings["VoteType"];
    /// <summary>
    /// 设置页面的基本布局
    /// </summary>
    private void getPageMessage()
    {
        Tunnel.BLL.Tunnel_PageMessage pmBLL = new Tunnel.BLL.Tunnel_PageMessage();
        List<Tunnel.Model.Tunnel_PageMessage> list = pmBLL.GetModelList(" 1=1 order by pic_ID desc");
        if (list.Count > 0)
        {
            TitleName = list[0].pic_TitleName;//页面标题
            lblTopicName.Text = list[0].pic_TopicName;//主题
            img_top.Style.Add("background-image", "../N_PicVote/Pic/" + list[0].pic_TopImgURL);                     
            BottomColor = list[0].pic_BgColor;//底部颜色
            this.divBottom.Style.Add("background-color", BottomColor);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //页面加载时，选定加载的图片
        getPageMessage();
        //第一次请求执行
        if (!Page.IsPostBack)
        {
            DataLoad(24, 1);
        }
    }
    private void DataLoad(int ppageseize, int ppageindex)
    {
        int outcount = 0;
        DataTable dt = voteInfoBLL.SelectImgList(ppageseize, ppageindex, out outcount);
        DataList1.DataSource = dt;
        DataList1.DataBind();

        if (dt.Rows.Count == 0)
            ANPBYPage.Visible = false;

        ANPBYPage.PageSize = ppageseize;
        ANPBYPage.CurrentPageIndex = ppageindex;
        ANPBYPage.RecordCount = outcount;
    }
    /// <summary>
    /// 投票事件
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string cmd = e.CommandName;
        if (cmd == "Ed")
        {

            int id = Convert.ToInt32(e.CommandArgument);

            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
            int UID = Convert.ToInt32(ul.LoginID);

            Tunnel.Model.VoteLog voteLog = new Tunnel.Model.VoteLog();
            Tunnel.BLL.VoteLog voteLogBll = new Tunnel.BLL.VoteLog();

            IList<Tunnel.Model.VoteLog> list_VoteLog = new List<Tunnel.Model.VoteLog>();

            list_VoteLog = (new Tunnel.BLL.VoteLog()).GetModelList("vg_userId=" + UID + " and vg_voteId=" + id);

            //获取投票记录项
            if (list_VoteLog.Count > 0)
                voteLog = list_VoteLog[list_VoteLog.Count-1];
      
            switch (VoteType)
            {
                case "1":
                    #region 每人一天可以投一次
                    if (list_VoteLog.Count == 0 )
                    {                      
                        //添加一条投票记录
                        voteLogModel.vg_setDate = DateTime.Now;
                        voteLogModel.vg_userId = UID;
                        voteLogModel.vg_voteId = id;
                        voteLogBll.Add(voteLogModel);

                        String Update_VoteCount = string.Format("update Vote_Info set v_count =v_count+1 where v_id={0} ", id);
                        String Add_Date_Sys = String.Format("insert into  Date_Sys values('{0}','{1}','{2}','{3}')", UID, DateTime.Now, DateTime.Now, null);                       

                        //更新票数，对票数进行加1
                        int result = Tunnel.Data.DbHelperSQL.ExecuteSql(Update_VoteCount);
                        //第一次投票
                        int Result = Tunnel.Data.DbHelperSQL.ExecuteSql(Add_Date_Sys);     

                        Label lb = (Label)e.Item.FindControl("lblCount");
                        int v_count = Convert.ToInt32(lb.Text.ToString());
                        v_count++;
                        lb.Text = v_count.ToString();
                                           
                        ClientScript.RegisterStartupScript(GetType(), "确定", "<script>alert('投票成功！');</script>");
                        

                    }
                    else if (voteLog.vg_setDate.Date != DateTime.Now.Date)
                    {
                        //添加一条投票记录
                        voteLogModel.vg_setDate = DateTime.Now;
                        voteLogModel.vg_userId = UID;
                        voteLogModel.vg_voteId = id;
                        voteLogBll.Add(voteLogModel);
                        String Update_VoteCount = string.Format("update Vote_Info set v_count =v_count+1 where v_id={0} ", id);
                        String Update_VoteLog = string.Format("update VoteLog  set vg_setDate ='{0}' where vg_id='{1}' and vg_userId='{2}'",DateTime.Now,id,UID);
                        String Update_VoteDate = string.Format("update Date_Sys set d_endPoll_Date='{0}'where d_userId={1} ", DateTime.Now, UID);
                        //更新票数，对票数进行加1
                        int result = Tunnel.Data.DbHelperSQL.ExecuteSql(Update_VoteCount);
                        //更新投票的时间，最后一次投票的时间 
                        int count = Tunnel.Data.DbHelperSQL.ExecuteSql(Update_VoteDate);
                        int record = Tunnel.Data.DbHelperSQL.ExecuteSql(Update_VoteLog);
                        Label lb = (Label)e.Item.FindControl("lblCount");
                        int v_count = Convert.ToInt32(lb.Text.ToString());
                        v_count++;
                        lb.Text = v_count.ToString();

                        ClientScript.RegisterStartupScript(GetType(), "确定", "<script>alert('投票成功！');</script>");

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "确定", "<script>alert('每张图片，一天可以投一次!');</script>");
                        
                    }

                    #endregion
                    break;
                case "0":
                    #region   限定每人只能投一次票

                    if (list_VoteLog.Count == 0)
                    {
                        //添加一条投票记录
                        voteLogModel.vg_setDate = DateTime.Now;
                        voteLogModel.vg_userId = UID;
                        voteLogModel.vg_voteId = id;
                        voteLogBll.Add(voteLogModel);

                        String Update_VoteCount = string.Format("update Vote_Info set v_count =v_count+1 where v_id={0} ", id);
                        String Add_Date_Sys = String.Format("insert into  Date_Sys values('{0}','{1}','{2}','{3}')", UID, DateTime.Now, DateTime.Now, null);                       

                        //更新票数，对票数进行加1
                        int result = Tunnel.Data.DbHelperSQL.ExecuteSql(Update_VoteCount);
                        //第一次投票
                        int Result = Tunnel.Data.DbHelperSQL.ExecuteSql(Add_Date_Sys);
                        Label lb = (Label)e.Item.FindControl("lblCount");
                        int v_count = Convert.ToInt32(lb.Text.ToString());
                        v_count++;
                        lb.Text = v_count.ToString();                                         

                    }
                    else
                    {
                        Tunnel.Common.Message.Show("每人每张只能投一次票");
                    }

                    #endregion
                    break;

            }
        }
    }

    protected void ANPBYPage_PageChanged(object sender, EventArgs e)
    {
        DataLoad(ANPBYPage.PageSize, ANPBYPage.CurrentPageIndex);
    }
}
