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

public partial class ResourceManager_UpdateResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ResourceInfo item = ResourceInfoManager.Get(id);
            this.txtResourceName.Text = item.RIName;
            txtNumber.Text = item.Number.ToString();
            txtPrice.Text = item.Price.ToString();
            txtTime.Value = item.InTime;
            ddlProvider.SelectedValue = item.Provider.PID.ToString();

            ddlType.SelectedValue = item.Type.RTID.ToString();
            txtRISpec.Text = item.RISpec;
            ddlState.SelectedValue = item.RIState.ToString();
            txtRemark.Text = item.RIRemark;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            ResourceInfo item = new ResourceInfo();
            item.RIName = txtResourceName.Text.Trim();
            item.Number = Convert.ToInt32(txtNumber.Text.Trim());
            item.Price = Convert.ToDouble(txtPrice.Text.Trim());
            item.InTime = txtTime.Value.Trim();
            item.Provider.PID = Convert.ToInt32(ddlProvider.SelectedValue);
            item.Type.RTID = Convert.ToInt32(ddlType.SelectedValue);
            item.RISpec = txtRISpec.Text.Trim();
            item.RIState = Convert.ToInt32(ddlState.SelectedValue);
            ResourceInfoManager.UpdateResourceInfo(item);
            Response.Redirect("ResourceInfoList.aspx");
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResourceInfoList.aspx");
    }
}
