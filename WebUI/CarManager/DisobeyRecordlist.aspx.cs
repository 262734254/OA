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
public partial class CarManager_DisobeyRecordlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dvDisobeyRecord.DataSource = DisobeyRecordManager.getAllDisobeyRecord("", "", "全部", "全部");
            dvDisobeyRecord.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string statime = txtStatime.Value;
        string endtime = txtEndtime.Value;
        string carType = ddlCharType.SelectedValue;
        string carMark = ddlCarMark.SelectedValue;
        dvDisobeyRecord.DataSource = DisobeyRecordManager.getAllDisobeyRecord(statime, endtime, carType, carMark);
        dvDisobeyRecord.DataBind();
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dvDisobeyRecord.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)dvDisobeyRecord.Rows[i].FindControl("input") as CheckBox;
            if (cb.Checked == true)
            {

                HiddenField lfCarID = dvDisobeyRecord.Rows[i].FindControl("lblDR_Id") as HiddenField;
                int id = Convert.ToInt32(lfCarID.Value);
                DisobeyRecordManager.delDisobeyRecordById(id);
            }

        }

        Response.Redirect("~/CarManager/DisobeyRecordlist.aspx");
    }
    protected void lbtnSel_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Sel")
        {
            int DR_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/DisobeyRecord.aspx?DR_Id=" + DR_Id + "&&DR_name=" + name);
        }
    }
    protected void lbtnUp_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            int DR_Id = Convert.ToInt32(e.CommandArgument);
            string name = e.CommandName;
            Response.Redirect("~/CarManager/DisobeyRecord.aspx?DR_Id=" + DR_Id + " &&DR_name=" + name);
        }
    }
}
