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
using System.Collections.Generic;

public partial class ResourceManager_ResourceInfo : System.Web.UI.Page
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
            ResourceInfo item = new ResourceInfo();
            item.RIName = this.txtRIName.Text.Trim();
            item.Type.RTID = Convert.ToInt32(this.ddlResourceType.SelectedValue);
            item.Store.RSID = Convert.ToInt32(this.ddlResourceStore.SelectedValue);
            item.Provider.PID = Convert.ToInt32(this.ddlProvider.SelectedValue);
            item.Number = Convert.ToInt32(this.txtNumber.Text.Trim());
            item.Price = Convert.ToDouble(this.txtPrice.Text.Trim());
                item.InTime = this.txtInTime.Value.Trim();
            item.RISpec = this.txtRISpec.Text.Trim();
            item.RIState = 1;//1为可用，2为禁用
            item.RIRemark = this.txtRIRemark.Text.Trim();

            ResourceInfo resource = ResourceInfoManager.GetResourceInfoByRTIDAndName(item.RIName, item.Type.RTID);
            if (resource != null && resource != new ResourceInfo())
            {
                item.Number = resource.Number + item.Number;
                item.RIID = resource.RIID;
                int val = ResourceInfoManager.UpdateResourceInfo(item);
                if (val != 0)
                {
                    Response.Redirect("ResourceInfoList.aspx");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('输入有误，请重新填写');</script>");
                    return;
                }
            }
            else
            {
                int val = ResourceInfoManager.Add(item);
                if (val != 0)
                {
                    Response.Redirect("ResourceInfoList.aspx");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('输入有误，请重新填写');</script>");
                    return;
                }
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ResourceInfoList.aspx");
    }
}
