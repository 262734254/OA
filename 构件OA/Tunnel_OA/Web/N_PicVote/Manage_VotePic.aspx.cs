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

public partial class N_PicVote_Manage_VotePic : System.Web.UI.Page
{
    public string BottomColor = string.Empty;//底部颜色
    private Tunnel.BLL.Vote_Info voteInfoBLL = new Tunnel.BLL.Vote_Info();
    private Tunnel.Model.Vote_Info voteInfoModel = new Tunnel.Model.Vote_Info();

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
    /// <summary>
    /// 设置页面的基本布局
    /// </summary>
    private void getPageMessage()
    {
        Tunnel.BLL.Tunnel_PageMessage pmBLL = new Tunnel.BLL.Tunnel_PageMessage();
        List<Tunnel.Model.Tunnel_PageMessage> list = pmBLL.GetModelList(" 1=1 order by pic_ID desc");
        if (list.Count > 0)
        {

            lblTopicName.Text = list[0].pic_TopicName;//主题
            img_top.Style.Add("background-image", "../N_PicVote/Pic/" + list[0].pic_TopImgURL);
            BottomColor = list[0].pic_BgColor;//底部颜色
            this.divBottom.Style.Add("background-color", BottomColor);
        }
    }
    /// <summary>
    /// 绑定分页项
    /// </summary>
    /// <param name="ppageseize"></param>
    /// <param name="ppageindex"></param>
    private void DataLoad(int ppageseize, int ppageindex)
    {
        int outcount = 0;
        DataTable dt = voteInfoBLL.SelectImgList(ppageseize, ppageindex, out outcount);
        dt_VotePic.DataSource = dt;
        dt_VotePic.DataBind();

        if (dt.Rows.Count == 0)
            ANPBYPage.Visible = false;

        ANPBYPage.PageSize = ppageseize;
        ANPBYPage.CurrentPageIndex = ppageindex;
        ANPBYPage.RecordCount = outcount;
    }

    protected void ANPBYPage_PageChanged(object sender, EventArgs e)
    {
        DataLoad(ANPBYPage.PageSize, ANPBYPage.CurrentPageIndex);
    }

    /// <summary>
    /// 重命名和删除
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void dt_VotePic_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string cmd = e.CommandName;
        if (cmd == "UP")
        {
            //获取图片的编号
            int Vote_Id = Convert.ToInt32(e.CommandArgument);
            Tunnel.BLL.Vote_Info voteInfoBLL = new Tunnel.BLL.Vote_Info();
            Tunnel.Model.Vote_Info voteInfoModel = voteInfoBLL.GetModel(Vote_Id);
            //修改图片的标题
            TextBox tb = (TextBox)e.Item.FindControl("txtName");
            voteInfoModel.v_title = tb.Text.ToString();
            voteInfoBLL.Update(voteInfoModel);
            ClientScript.RegisterStartupScript(GetType(), "确定", "<script>alert('更新成功！');</script>");
            DataLoad(24, 1);
        }
        else if (cmd == "DEL")
        {
            //获取图片的编号
            int id = Convert.ToInt32(e.CommandArgument);
            Button btnDel = (Button)e.Item.FindControl("btn_DeleteVote");
            btnDel.Attributes.Add("OnClientClick", "javascript:return confirm('确认要删除此项投票吗?');");
            Tunnel.BLL.Vote_Info voteInfoBLL = new Tunnel.BLL.Vote_Info();
            voteInfoBLL.Delete(id);

            Tunnel.BLL.VoteLog voteLogBLL = new Tunnel.BLL.VoteLog();
            //删除该投票选项的投票记录
            voteLogBLL.DeleteByVote_ID(id);
            //重新绑定页面
            DataLoad(24, 1);
            ClientScript.RegisterStartupScript(GetType(), "确定", "<script>alert('删除图片成功！');</script>");
        }

    }
}
