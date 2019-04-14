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

public partial class CommentPhotos : System.Web.UI.Page
{
    #region 实例化基层类
    Tunnel.BLL.Vote_Info voteManager = new Tunnel.BLL.Vote_Info();
    Tunnel.DAL.Vote_Info infoDAL = new Tunnel.DAL.Vote_Info();

    Tunnel.BLL.UserLogin ulBLL = new Tunnel.BLL.UserLogin();

    Tunnel.Model.VoteLog infolog = new Tunnel.Model.VoteLog();
    Tunnel.DAL.VoteLog infologDAL = new Tunnel.DAL.VoteLog();
    Tunnel.BLL.VoteLog infologBLL = new Tunnel.BLL.VoteLog();


    Tunnel.Model.LeaveWord leaveWord = new Tunnel.Model.LeaveWord();
    Tunnel.DAL.LeaveWord leaveWordDAL = new Tunnel.DAL.LeaveWord();
    Tunnel.BLL.LeaveWord leaveWordBLL = new Tunnel.BLL.LeaveWord();
    #endregion
    #region 定义全局变量
    public static int upID = 0;
    public static int downId = 0; 

    public string TopImage = string.Empty;//顶部图片
    public string BottomColor = string.Empty;//底部颜色
    public string TitleName = string.Empty;//页面标题
    public string TopicName = string.Empty;//主题名称
    #endregion
    //保存投票信息列表
    public static IList<Tunnel.Model.Vote_Info> list_vote = null;
    public void getPageMessage()
    {
        Tunnel.BLL.Tunnel_PageMessage pmBLL = new Tunnel.BLL.Tunnel_PageMessage();
        List<Tunnel.Model.Tunnel_PageMessage> list = pmBLL.GetModelList(" 1=1  order by pic_ID desc");
        if (list.Count > 0)
        {
            TitleName = list[0].pic_TitleName;
            TopicName = list[0].pic_TopicName;
            img_top.Style.Add("background-image", "../N_PicVote/Pic/" + list[0].pic_TopImgURL);
            BottomColor = list[0].pic_BgColor;
            this.divBottom.Style.Add("background-color", BottomColor);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        getPageMessage();
        #region 页面首次加载时触发
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["v_id"]))
                LoadData();
            else
                Response.Redirect("Vote_ShowAllPic.aspx");//跳转页面
        }

        #endregion
    }
    /// <summary>
    /// 绑定查询图片信息
    /// </summary>
    private void LoadData()
    {
        Tunnel.BLL.Vote_Info infoBLL = new Tunnel.BLL.Vote_Info();
        int vote_Id = int.Parse(Request.QueryString["v_id"].ToString());


        //设置当前图片的标题和作者
        Tunnel.Model.Vote_Info info = infoBLL.GetModel(vote_Id);
        //获取图片的路径
        this.imgPic.ImageUrl = "/N_PicVote/Pic/a" + info.v_Img;

        this.lblTitle.Text = info.v_title;

        //Tunnel.Model.Tunnel_menber menber = ulBLL.GetUserBean(info.v_author);
        //设置照片的作者
        this.lblAuthor.Text = info.v_author;
        this.lblRemark.Text = info.v_remark;
        ListPage(vote_Id, 5, 1);
    }
    private void ListPage(int vateid, int pagesize, int pageindex)
    {
        int outcount = 0;
        DataTable dt = voteManager.SelectListPage(vateid, pagesize, pageindex, out outcount);
        rptShow.DataSource = dt;
        rptShow.DataBind();
        if (dt.Rows.Count == 0)
            ANPBYPage.Visible = false;
        ANPBYPage.PageSize = pagesize;
        ANPBYPage.CurrentPageIndex = pageindex;
        ANPBYPage.RecordCount = outcount;

        TopDown(vateid);
    }

    /// <summary>
    /// 绑定上下翻页
    /// </summary>
    private void TopDown(int vote_Id)
    {
        int otopid = 0;
        int odownid = 0;
        string otoptitle = "";
        string odowntitle = "";
        voteManager.GetTopDown(vote_Id, out otopid, out odownid, out otoptitle, out odowntitle);
        if (otopid == 0)
            btnup.Enabled = false;
        else
            btnup.Text = "上一张 " + otoptitle;

        if (odownid == 0)
            btndown.Enabled = false;
        else
            btndown.Text = "下一张 " + odowntitle;

        lbltopid.Text = otopid.ToString();
        lbldownid.Text = odownid.ToString();
    }
    /// <summary>
    /// 设置日期格式
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string FormatDate(string str)
    {
        if (!string.IsNullOrEmpty(str))
            str = Convert.ToDateTime(str).ToString("yyyy-MM-dd").ToString();
        return str;
    }

    public string GetUser(string str)
    {
        if (!string.IsNullOrEmpty(str))
        {
            Tunnel.Model.Tunnel_menber men = ulBLL.GetUserBean(ulBLL.LoginID);
            return men.m_name.ToString();
        }
        else
        {
            return "";
        }
    }
    /// <summary>
    /// 发送信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void button_Click(object sender, EventArgs e)
    {     
            //添加信息
            string YourWord = this.txtYourword.Text;
            int uid = ulBLL.LoginID;
            if (!string.IsNullOrEmpty(Request.QueryString["v_id"]) && !string.IsNullOrEmpty(YourWord))
            {
                int vote_Id = int.Parse(Request.QueryString["v_id"].ToString());
                Tunnel.Model.LeaveWord leaveWordModel = new Tunnel.Model.LeaveWord();
                leaveWordModel.lw_SetDate = DateTime.Now;
                leaveWordModel.lw_UserId = uid;
                leaveWordModel.lw_VateId = vote_Id;
                leaveWordModel.lw_Content = YourWord;
                leaveWordDAL.Add(leaveWordModel);//新增一条评论                
                ClientScript.RegisterStartupScript(this.GetType(), "str", "alert('发表评论成功!')", true);
                txtYourword.Text = "";
                LoadData();
            }

    }
    /// <summary>
    /// 上一张
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbUp_Click(object sender, EventArgs e)
    {
        if (lbltopid.Text != "0")
        {
            Server.Transfer("CommentPhotos.aspx?v_id=" + lbltopid.Text.Trim());
        }
    }
    /// <summary>
    /// 下一张
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbDown_Click(object sender, EventArgs e)
    {
        if (lbldownid.Text != "0")
        {
            Server.Transfer("CommentPhotos.aspx?v_id=" + lbldownid.Text.Trim());
        }
    }

    protected void ANPBYPage_PageChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["v_id"]))
            ListPage(int.Parse(Request.QueryString["v_id"].ToString()), ANPBYPage.PageSize, ANPBYPage.CurrentPageIndex);
    }
}

