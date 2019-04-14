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

using BLL.Resource;
using Model;

public partial class ResourceDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        ResourceInfo item = ResourceInfoManager.Get(id);
        this.txtResourceName.Text = item.RIName;
        this.txtNumber.Text = item.Number.ToString();
        this.txtPrice.Text = item.Price.ToString();
        this.txtInTime.Text = item.InTime;
        this.txtProvider.Text = item.Provider.PID.ToString();
        this.txtResourceType.Text = item.Type.RTName;
        this.txtSpec.Text = item.RISpec;
        if (item.RIState == 1)
            this.txtState.Text = "可用";
        else
            this.txtState.Text = "禁用";
        this.txtResourceStore.Text = item.Store.RSName;
        this.txtRemark.Text = item.RIRemark;

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("UpdateResource.aspx?id={0}", Request.QueryString["id"].ToString()));
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResourceInfoList.aspx");
    }
}
