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
using System.Collections.Generic;
using BLL.Resource;

public partial class Damage : System.Web.UI.Page
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
            SpoilageRegister item = new SpoilageRegister();
            item.Borrow.BAID = Convert.ToInt32(this.txtBorrowNo.Text.Trim());
            item.User.UID = Convert.ToInt32(this.hfUID.Value.Trim());
            item.Resourse.RIID = Convert.ToInt32(this.ddlName.SelectedValue);
            item.SRNo = Convert.ToInt32(this.txtPreNum.Text.Trim());
            item.SRGrade = this.txtGrade.Text.Trim();
            item.SRCause = this.txtCause.Text.Trim();
            item.SRTime = txtDrawTime.Value.Trim();
            item.SRRemark = txtRemark.Text.Trim();
            ApplicationResourseInfo resource = ApplicationResourceManager.GetApplicationResourse(item.Borrow.BAID, item.Resourse.RIID);
            ResourceRestore restore = ResourceRestoreManager.GetRestoreByBAIDAndRIID(item.Borrow.BAID, item.Resourse.RIID);
            if (restore != new ResourceRestore() && restore!=null)
            {
                if (item.SRNo > resource.Number - restore.RRNumber)
                {
                    ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('您输入损耗数量超出了需要归还的数量!')</script>");
                    return;
                }
            }
            SpoilageRegisterManager.Add(item);
            Response.Redirect("UseList.aspx");
        }
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
        this.ddlName.DataSource = resources;
        ddlName.DataTextField = "RIName";
        ddlName.DataValueField = "RIID";
        ddlName.DataBind();
        BorrowApplication borrow = BorrowApplicationManager.Get(borrowNo);
        if (borrow != new BorrowApplication()&&borrow!=null)
        {
            this.txtUser.Text = borrow.User.Name;
            this.hfUID.Value = borrow.User.UID.ToString();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("UseList.aspx");
    }
}
