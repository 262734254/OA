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
using System.Data.SqlClient;
using Model;
using BLL.Car;

public partial class CarManager_ByapplyCaparticular : System.Web.UI.Page
{
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            JiaZaiBind();
        }
    }
    private void JiaZaiBind()
    {
        int chuan = int.Parse(Request.Params["op"].ToString());
        Id = int.Parse(Request.Params["id"].ToString());
        Bind(Id);
        if (chuan == 1)
        {

            this.Page.Title = "申请详细信息";
            this.lblTitle.Text = "申请详细信息";

            Bind(Id);
            rdo1.Enabled = false;
            rdo2.Enabled = false;
            rdo3.Enabled = false;
            rdo4.Enabled = false;
            btnShenPi.Visible = false;
        }
        else
        {

            this.Page.Title = "申请审批信息";
            this.lblTitle.Text = "申请审批信息";
            Bind(Id);
            rdo1.Enabled = false;
            rdo2.Enabled = false;
            rdo3.Enabled = false;
            rdo4.Enabled = false;
            btnShenPi.Visible = true;
            
        }

    }
    /// <summary>
    /// 详细
    /// </summary>
    /// <param name="id"></param>
    public void Bind(int id)
    {
        Car_Byapply car = CarByapplyManager.GetAllCarsByappyById(Id);
        txtByCause.Text = car.ByCause.ToString();
        txtByData.Value = car.ByData.ToString();
        txtByttion.Text = car.ByDttion.ToString();
        txtDept.Text = car.ByDept.Departmentname.ToString();
        txtMan.Text = car.ByMan.ToString();
        txtReData.Value = car.ByReData.ToString();

        if (car.ByTypeid.TypeId == 1)
        {
            rdo1.Checked = true;
        }
        else if (car.ByTypeid.TypeId == 2)
        {
            rdo2.Checked = true;
        }
        else if (car.ByTypeid.TypeId == 3)
        {
            rdo3.Checked = true;
        }
        else
        {
            rdo4.Checked = true;
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    protected void btnShenPi_Click(object sender, EventArgs e)

    {
        Car_Byapply car = CarByapplyManager.GetAllCarsByappyById(Id);
        Response.Redirect("~/PedingMatter/Auditing.aspx?type=用车申请&id="+Id.ToString());
       
    }
}
