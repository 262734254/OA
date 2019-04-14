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
    public string UrlReferrer
    {
        get
        {
            return ViewState["urlReferrer"].ToString();
        }
        set
        {
            ViewState["urlReferrer"] = value;
        }
    }

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
            ViewState["urlReferrer"] = Request.UrlReferrer.LocalPath;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ResourceInfo item = ResourceInfoManager.Get(id);
            if (item != new ResourceInfo() && item != null)
            {
                this.lblResourceName.Text = item.RIName;
                this.lblNumber.Text = item.Number.ToString();
                this.lblPrice.Text = item.Price.ToString();
                this.lblInTime.Text = item.InTime;
                this.lblProvider.Text = item.Provider.PID.ToString();
                this.lblResourceType.Text = item.Type.RTName;
                this.lblSpec.Text = item.RISpec;
                if (item.RIState == 1)
                    this.lblState.Text = "可用";
                else
                    this.lblState.Text = "禁用";
                this.lblResourceStore.Text = item.Store.RSName;
                this.txtRemark.Text = item.RIRemark;
            }
        }

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format("UpdateResource.aspx?id={0}", Request.QueryString["id"].ToString()));
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (UrlReferrer == "/WebUI/ResourceManager/UseList.aspx")
        {
            Response.Redirect("UseList.aspx");
        }
        else if (UrlReferrer == "/WebUI/ResourceManager/ResourceInfoList.aspx")
        {
            Response.Redirect("ResourceInfoList.aspx");
        }
    }
}
