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
using System.Collections.Generic;

public partial class ResourceManager_SelectResource : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void ddlResourceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlResourceName.DataSourceID = null;
        int id = Convert.ToInt32(ddlResourceType.SelectedValue);
        IList<ResourceInfo> items = ResourceInfoManager.GetAllResourceInfo(id);
        ddlResourceName.DataSource = items;
        ddlResourceName.DataValueField = "RIID";
        ddlResourceName.DataTextField = "RIName";
        ddlResourceName.DataBind();
        Bind(items);
    }

    private void Bind(IList<ResourceInfo> items)
    {
        if (items.Count == 0)
        {
            this.lblPrice.Text = "";
            this.lblProvider.Text = "";
            this.lblSpec.Text = "";
            this.txtNumber.Text = "";
        }
        else
        {
            BindResource(items[0].RIID);
        }
    }


    protected void ddlResourceName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ddlResourceName.SelectedValue);
        BindResource(id);

    }

    private void BindResource(int id)
    {
        ResourceInfo item = ResourceInfoManager.Get(id);
        this.lblPrice.Text = item.Price.ToString();
        this.lblSpec.Text = item.RISpec;
        this.lblProvider.Text = item.Provider.PName;
    }

}
