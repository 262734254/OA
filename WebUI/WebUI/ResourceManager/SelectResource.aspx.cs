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
        }
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int riid = 0;
        int number = 0;
        try
        {
            number = Convert.ToInt32(txtNumber.Text.Trim());
            ResourceInfo resource = ResourceInfoManager.Get(Convert.ToInt32(ddlResourceType.SelectedValue));
            if (number > resource.Number)
            {
                this.ClientScript.RegisterStartupScript(GetType(), "", string.Format("<script>alert('库存数量为{0},您输入的数量以大于现有库存,请重新输入!')</script>", resource.Number));
                return;
            }
        }
        catch
        {
            this.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入数字!')</script>");
            return;
        }
        if (null != ddlResourceName.SelectedValue && "" != ddlResourceName.SelectedValue)
        {
            riid = Convert.ToInt32(ddlResourceName.SelectedValue);
            if (UrlReferrer == "/WebUI/ResourceManager/ApplyBorrow.aspx")
            {
                ApplicationResources.AddItem(ResourceInfoManager.Get(riid), 1, number);
                Response.Redirect("ApplyBorrow.aspx");

            }
            else if (UrlReferrer == "/WebUI/ResourceManager/ApplyStock.aspx")
            {
                ApplicationResources.AddItem(ResourceInfoManager.Get(riid), 2, number);
                Response.Redirect("ApplyStock.aspx");
            }
        }
        else
        {
            this.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择资源!')</script>");
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (UrlReferrer == "/WebUI/ResourceManager/ApplyBorrow.aspx")
        {
            Response.Redirect("ApplyBorrow.aspx");
        }
        else if (UrlReferrer == "/WebUI/ResourceManager/ApplyStock.aspx")
        {
            Response.Redirect("ApplyStock.aspx");
        }
    }
}
