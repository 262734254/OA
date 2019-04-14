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
public partial class CarManager_Servicelist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvService.DataSource = ServicesManager.getAllService("", "", "全部", "全部");
            gvService.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string statime = txtStatime.Value;
        string endtime = txtEndtime.Value;
        string c_CarType = ddlCharType.SelectedValue;
        string c_Station = ddlCheerStation.SelectedValue;

        gvService.DataSource = ServicesManager.getAllService(statime, endtime, c_CarType, c_Station);
        gvService.DataBind();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvService.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvService.Rows[i].FindControl("input") as CheckBox;
            if (cb.Checked == true)
            {

                HiddenField lfCarID = gvService.Rows[i].FindControl("lblS_Id") as HiddenField;
                int id = Convert.ToInt32(lfCarID.Value);
                ServicesManager.deleteServiceById(id);
            }

        }

        Response.Redirect("~/CarManager/Servicelist.aspx");
    }
    protected void lbtnSel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            int S_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/Service.aspx?S_Id=" + S_Id + "&&S_name=" + name);
        }
    }
    protected void lbtnUp_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            int S_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/Service.aspx?S_Id=" + S_Id + " &&S_name=" + name);
        }
    }
}
