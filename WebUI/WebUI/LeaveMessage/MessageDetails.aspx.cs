﻿using System;
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
using BLL.WorkHelper;
using DAL;
public partial class OfficeHelp_LeaveMessage_MessageDetails : System.Web.UI.Page
{
    static int typeId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["TypeId"].ToString()))
            {
                typeId = Convert.ToInt32(Request.QueryString["TypeId"]);
                Bind();
            }
        }
    }
    private void Bind()
    {
        LeaveWord leaveWord = LeaveWordManager.GetLeaveWordMsgTypeId(typeId);
        this.txtTitle.Text = leaveWord.MsgTitle;
        this.txtSenderUser.Text =Convert.ToString(leaveWord.SenderUser.Name);
        this.txtEndTime.Text =Convert.ToString(leaveWord.MsgSendTime);
        this.txtMsgContent.Text = leaveWord.MsgContent;

    }
    protected void btnRestore_Click(object sender, EventArgs e)
    {
        Response.Redirect("MessageReply.aspx?TypeId=" + typeId + "&typeTitle=回复");
    }
}
