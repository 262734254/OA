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
using BLL.Resource;

public partial class ApplyBorrow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(this.Request.QueryString["id"]);
            BorrowApplication borrow = BorrowApplicationManager.Get(id);
            this.txtBorrowNo.Text = borrow.BAID.ToString();
            this.txtBATime.Value = borrow.BATime;
            this.txtExigentGrade.Text = borrow.ExigentGrade;
            this.txtUser.Text = borrow.User.Name;
            this.txtMark.Text = borrow.BARemark;
            this.txtExamine.Text = borrow.IsExamine;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Response.Redirect("ApplyBorrowList.aspx");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApplyBorrowList.aspx");
    }
    protected void gvBorrowResource_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void ddlResourceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}
