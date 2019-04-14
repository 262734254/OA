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

public partial class TaskManager_TaskPart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
        
        }
    }


    public string GetColorLength(string strStart, string strEnd)
    {
        int d = 0;

        if (strEnd != "" && strStart!="")
            d = 50 * (Convert.ToInt32(strEnd) - Convert.ToInt32(strStart));
        else
            d = 0;
        return d.ToString() + "px";
    }


     public string GetLeftColorLength(string strStart)
    {
        int d = 0;

        if (strStart != "")
            d = 50 * (Convert.ToInt32(strStart)-1);
        else
            d = 0;
        return d.ToString() + "px";
    }

     

    protected void dlistShow_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemIndex > -1)//排除第一项 头部
        {
            TextBox txtBox = e.Item.FindControl("txtShowColor") as TextBox;
            TextBox txtLeft = e.Item.FindControl("txtLeft") as TextBox;
            HiddenField hidfile = e.Item.FindControl("hidSId") as HiddenField;
            HiddenField hidStart = e.Item.FindControl("hidStart") as HiddenField;
            HiddenField hidEnd = e.Item.FindControl("hidEnd") as HiddenField;
            HiddenField filishRate = e.Item.FindControl("hidRate") as HiddenField;
            if (filishRate.Value != "" && Convert.ToDecimal(filishRate.Value) < 100 && Convert.ToDecimal(filishRate.Value)>0)
                txtBox.Style.Add("background-color", "green");
            else if (filishRate.Value!=""&& Convert.ToDecimal(filishRate.Value) == 0)
                txtBox.Style.Add("background-color", "gray");
            txtBox.Style.Add("width", GetColorLength(hidStart.Value, hidEnd.Value));
            if (filishRate.Value.IndexOf('.') != -1)
            {
                txtBox.Text = filishRate.Value.Substring(0, filishRate.Value.IndexOf('.')) + "%";
            }
            else
            {
                txtBox.Text = filishRate.Value + "%";
            }
            txtBox.Style.Add("width", GetColorLength(hidStart.Value, hidEnd.Value));
            txtLeft.Style.Add("width", GetLeftColorLength(hidStart.Value));
        }
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if (ddlYears.SelectedValue != "")
        {
            lblYear.Text = ddlYears.SelectedItem.Text;
        }
    }
}
