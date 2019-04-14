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
using BLL.Target;
using Model;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlistShow.DataSourceID = null;
            ddlistShow.DataSource = TaskManager.GetAllTaskFinishRate("","","");
            ddlistShow.DataBind();
        }
    }
  

    public static string GetWidth(object rate)
    {
        string str = "";
        if (rate.ToString() == "")
        {
            str = "0px";

        }else  if (Convert.ToDecimal(rate) >= 100)
        {
            str = "600px";
        }
        else
        {
            str = (6 * Convert.ToDecimal(rate)).ToString()+"px";
        }
        return str;
    }


    protected void ddlistShow_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemIndex > -1)//从-1开始加载 排除头部
        {
            TextBox txtBox = e.Item.FindControl("txtRateNow") as TextBox;
            HiddenField TitleLabel = e.Item.FindControl("hidId") as HiddenField;
            HiddenField lbltxt = e.Item.FindControl("FinishRate") as HiddenField;
            txtBox.Style.Add("width", GetWidth(lbltxt.Value.Trim()));
            txtBox.Text = lbltxt.Value.Trim()+"%";
        }

    }
    protected void ddlistShow_ItemCommand(object source, DataListCommandEventArgs e)
    {
       
        if (e.CommandName == "Detail")
        {
            int taskId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("TaskPart.aspx?taskId="+taskId);
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       ddlistShow.DataSourceID=null;
       ddlistShow.DataSource= TaskManager.GetAllTaskFinishRate(ddlYear.SelectedValue, ddlMonth.SelectedValue, ddlType.SelectedValue);
       ddlistShow.DataBind();
    }
}
