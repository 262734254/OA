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
using System.Collections.Generic;
using Model;
using BLL.Resource;

public partial class Return : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UserInfo user = new UserInfo();
            if (Session["user"] == null)
            {
                Response.Redirect("../login.aspx");
                return;
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            ResourceRestore restore = new ResourceRestore();
            restore.Borrow.BAID = Convert.ToInt32(txtBorrowNo.Text.Trim());
            restore.Resource.RIID = Convert.ToInt32(ddlName.SelectedValue);
            restore.User.UID = Convert.ToInt32(hfUID.Value);
            restore.RRTime = txtTime.Value.Trim();
            restore.RRNumber = Convert.ToInt32(txtRebackNum.Text.Trim());
            ApplicationResourseInfo appResource = ApplicationResourceManager.GetApplicationResourse(restore.Borrow.BAID, restore.Resource.RIID);
            if (restore.RRNumber > appResource.Number)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('您的输入归还数量有误!')</script>");
                return;
            }
            restore.RRRemark = txtMark.Text.Trim();
            if (ResourceRestoreManager.Add(restore) != 0)
            {
                restore.Resource = ResourceInfoManager.Get(restore.Resource.RIID);
                restore.Resource.Number += restore.RRNumber;
                ResourceInfoManager.UpdateResourceInfo(restore.Resource);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('录入成功!')</script>");
            }
            Response.Redirect("UseList.aspx");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("UseList.aspx");
    }
    protected void txtBorrowNo_TextChanged(object sender, EventArgs e)
    {
        ddlName.Items.Clear();
        int borrowNo = Convert.ToInt32(this.txtBorrowNo.Text.Trim());
        IList<ApplicationResourseInfo> ari = new List<ApplicationResourseInfo>();
        IList<ResourceInfo> resources = new List<ResourceInfo>();
        ari = ApplicationResourceManager.GetAllApplicationResource(1, borrowNo);
        foreach (ApplicationResourseInfo item in ari)
        {
            if (item.Borrow != new BorrowApplication())
                resources.Add(item.Resource);
        }
        ddlName.AppendDataBoundItems = true;
        ddlName.Items.Insert(0, new ListItem("--请选择--", "0"));
        this.ddlName.DataSource = resources;
        ddlName.DataTextField = "RIName";
        ddlName.DataValueField = "RIID";
        ddlName.DataBind();
        BorrowApplication borrow = BorrowApplicationManager.Get(borrowNo);
        if (borrow != null && borrow != new BorrowApplication())
        {
            this.txtUser.Text = borrow.User.Name;
            this.hfUID.Value = borrow.User.UID.ToString();
        }
    }
}
