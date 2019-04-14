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

public partial class CarManager_Cheerlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvCheer.DataSource = CheerManager.getAllCheer("", "", "全部", "全部");
            gvCheer.DataBind();
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < gvCheer.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gvCheer.Rows[i].FindControl("input") as CheckBox;
            if (cb.Checked == true)
            {

                HiddenField lfCarID = gvCheer.Rows[i].FindControl("lblC_Id") as HiddenField;
                int id = Convert.ToInt32(lfCarID.Value);
                CheerManager.deleteCheerById(id);
            }

        }

        Response.Redirect("~/CarManager/Cheerlist.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string statime = txtStatime.Value;
        string endtime = txtEndtime.Value;
        string c_CarType = ddlCharType.SelectedValue;
        string c_Station = ddlCheerStation.SelectedValue;

        gvCheer.DataSource = CheerManager.getAllCheer(statime, endtime, c_CarType, c_Station);
        gvCheer.DataBind();
    }
    protected void lbtnSel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            int C_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/Cheer.aspx?C_Id=" + C_Id + "&&C_name=" + name);
        }
    }
    protected void lbtnUp_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            int C_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/Cheer.aspx?C_Id=" + C_Id + " &&C_name=" + name);
        }
    }
}
