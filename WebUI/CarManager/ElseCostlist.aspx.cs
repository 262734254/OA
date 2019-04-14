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
using BLL.Car;
public partial class CarManager_ElseCostlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dvCostSupervise.DataSource = CostSuperviseManager.getAllCostSupervise("", "", "全部", "全部");
            dvCostSupervise.DataBind();
        }
    }
    protected void btnSel_Click(object sender, EventArgs e)
    {
        string statime = txtStatime.Value;
        string endtime = txtEndtime.Value;
        string carType = ddlCharType.SelectedValue;
        string carMark = ddlCarMark.SelectedValue;
        dvCostSupervise.DataSource = CostSuperviseManager.getAllCostSupervise(statime, endtime, carType, carMark);
        dvCostSupervise.DataBind();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dvCostSupervise.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)dvCostSupervise.Rows[i].FindControl("input") as CheckBox;
            if (cb.Checked == true)
            {

                HiddenField lfCarID = dvCostSupervise.Rows[i].FindControl("lblCS_Id") as HiddenField;
                int id = Convert.ToInt32(lfCarID.Value);
                CostSuperviseManager.delCostSuperviseById(id);
            }

        }

        Response.Redirect("~/CarManager/ElseCostlist.aspx");
    }
    protected void lbtnSel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            int CS_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/elseCost.aspx?CS_Id=" + CS_Id + "&&CS_name=" + name);
        }
    }
    protected void lbtnUp_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            int CS_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/elseCost.aspx?CS_Id=" + CS_Id + " &&CS_name=" + name);
        }
    }
    protected void dvCostSupervise_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

