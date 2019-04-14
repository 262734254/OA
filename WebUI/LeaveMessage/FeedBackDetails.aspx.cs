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
using System.Xml.Linq;
using Model;
using DAL;
using BLL.WorkHelper;
public partial class OfficeHelp_LeaveMessage_FeedBackDetails : System.Web.UI.Page
{
    static int typeId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["TypeId"].ToString()))
            {
                typeId = Convert.ToInt32(Request.QueryString["TypeId"].ToString());
                if(Request.QueryString["typeTitle"] == null)
                {
                    LeaveWord leaveWord = LeaveWordManager.GetLeaveWordById(typeId);
                    this.txtTitle.Text = leaveWord.MsgTitle;
                    this.txtSenderUser.Text = leaveWord.ReceiverUser.Name;
                    this.txtEndTime.Text = Convert.ToString(leaveWord.MsgSendTime);
                    if (leaveWord.IsAgree.Trim() == "是")
                    {
                        this.rdoAgree.SelectedValue = "是";
                    }
                    else
                    {
                        this.rdoAgree.SelectedValue = "否";
                    }
                    this.txtRemark.Text = leaveWord.Remark;
                    this.btnOK.Visible = false;
                }else
                {
                typeId = Convert.ToInt32(Request.QueryString["TypeId"]);
                Bind();
                }
            }
        }
    }
    private void Bind()
    {
        LeaveWord leaveWord = LeaveWordManager.GetLeaveWordById(typeId);
        this.txtTitle.Text = leaveWord.MsgTitle;
        this.txtEndTime.Text =Convert.ToString(leaveWord.MeetingBeginTime);
        this.txtSenderUser.Text =Convert.ToString(leaveWord.ReceiverUser.Name);
        
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        LeaveWord leaveWord = new LeaveWord();

        if (typeId > 0)
        {
            leaveWord.MsgTitle = this.txtTitle.Text.Trim();
            leaveWord.MsgSendTime =Convert.ToDateTime( this.txtEndTime.Text.Trim());
            leaveWord.MeetingBeginTime = Convert.ToDateTime("2010-10-01");
            leaveWord.MsgContent = "";
            leaveWord.MsgState = "";
            leaveWord.MeetingAddr = "";
            leaveWord.ChargeMan = "";
            leaveWord.MeetingType="";
            leaveWord.MsgTypeId.Id=3;
            leaveWord.SenderUser.UID = 1;
            leaveWord.ReceiverUser.UID = 1;
            leaveWord.IsAgree = this.rdoAgree.SelectedValue;
            leaveWord.Remark = this.txtRemark.Text.Trim();
            LeaveWordManager.AddLeaveWord(leaveWord);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回复成功！');</script>");
            
            Response.Redirect("ShowMessage.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回复失败！');</script>");
        
        }
    }
}
