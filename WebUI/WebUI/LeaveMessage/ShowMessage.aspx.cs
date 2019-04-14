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
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL.WorkHelper;
using Model;
using Common;
public partial class OfficeHelp_LeaveMessage_ShowMessage : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Pager1.onLoadPageIndexChaning += new _Controls_Pager.MyDele(Pager1_onLoadPageIndexChaning);
       
        if (!IsPostBack)
        {
            Pager1_onLoadPageIndexChaning(Pager1.PageIndex);
           
           
        }
    }

    void Pager1_onLoadPageIndexChaning(int pageIndex)
    {
        DataBind(pageIndex);
    }
    /// <summary>
    /// 利用PagedDataSource做数据源绑定数据分页
    /// </summary>
    /// <param name="pageIndex"></param>
    private void DataBind(int pageIndex)
    {

        try
        {
            PagedDataSource pds = new PagedDataSource();

            pds.DataSource = LeaveWordManager.SelectLeaveWordByAll(dropMsgTypeId.SelectedValue, dropMsgState.SelectedValue, RadioButtonList1.SelectedValue);
            Pager1.DataCount = pds.Count;//获取记录数 并赋值  
            if (pageIndex >=Pager1.PageCount-1)
            {
               pageIndex--;
            }
            pds.CurrentPageIndex = pageIndex;  //取得当前页索引
            pds.AllowPaging = true;
            pds.PageSize = 5;
           
            Pager1.PageCount = pds.PageCount;
            gvLeaveWord.DataSourceID = null; //LeaveWordManager.SelectLeaveWordByAll;
            gvLeaveWord.DataSource = pds;
            gvLeaveWord.DataBind();
        }
        catch (Exception)
        {

            return;
        }
    }

    protected void gvLeaveWord_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd = e.CommandName;
        LinkButton lbTypeId=e.CommandSource as LinkButton;

        Label lblType = lbTypeId.Parent.Parent.FindControl("lblType") as Label;
        
        int msgTypeId = Convert.ToInt32(e.CommandArgument);

        if (cmd == "Sele")
        {
            if (lblType.Text=="会议通知")
            {
                Response.Redirect("MeetingInform.aspx?TypeId="+e.CommandArgument);
            }
            else if (lblType.Text == "留言")
            {
                Response.Redirect("MessageDetails.aspx?TypeId=" + e.CommandArgument);
            }
            else if (lblType.Text=="回复留言")
            {
                Response.Redirect("MessageReply.aspx?TypeId=" + e.CommandArgument);
            }
            else if (lblType.Text=="反馈消息")
            {
                Response.Redirect("FeedBackDetails.aspx?TypeId=" + e.CommandArgument);
            }
            
        }

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        DataBind(0);
        Pager1_onLoadPageIndexChaning(Pager1.PageIndex);
    }


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] ids = new int[gvLeaveWord.Rows.Count];
        for (int a = 0; a < gvLeaveWord.Rows.Count; a++)
        {


            if ((gvLeaveWord.Rows[a].FindControl("chkOne") as CheckBox).Checked)
            {
                HiddenField hfId = gvLeaveWord.Rows[a].FindControl("hfOne") as HiddenField;
                ids[a] = Convert.ToInt32(hfId.Value);
            }
        }
        foreach (int riid in ids)
        {
            if (riid != 0)
            {
                LeaveWordManager.DeleteLeaveWordById(riid);
            }
        }
        Pager1_onLoadPageIndexChaning(Pager1.PageIndex);
    }
}
