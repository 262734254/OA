using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Model;
using BLL.Car;
using BLL.Power;

public partial class weixiujilu : System.Web.UI.Page
{
    static int S_Id = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string name = "0";
            S_Id = Convert.ToInt32(Request.QueryString["S_Id"]);
            name = Request.QueryString["S_name"];
            if (S_Id != 0)
            {
                Dasoue();
            }
            if (name == "Sel")
            {
                btnSave.Visible = false;
            }
            if (name == "Up")
            {
                fuBillPhoto.Enabled=false;
                rblCarType.Enabled = false;
                ddlCarMark.Enabled = false;
            }
            

        }
    }

    private void Dasoue()
    {
        S_Id = Convert.ToInt32(Request.QueryString["S_Id"]);
        Services se = ServicesManager.getServiceById(S_Id);
        txtBeginDate.Value = se.BeginDate.ToShortDateString();
        image.ImageUrl = se.BillPhoto;
        txtS_Reason.Text = se.S_Reason;
        rblCarType.SelectedValue = se.CarType;
        txtEndDate.Value = se.EndDate.ToShortDateString();

        txtS_Cost.Text = se.S_Cost.ToString();
        txtS_FactoryName.Text = se.S_FactoryName;
        txtS_Result.Text = se.S_Result;
        ddlS_Type.SelectedValue = se.S_Type;
        txtUseCost.Text = se.UseCost.ToString();
        ddlS_Branch.DataSourceID = null;
        ddlS_Branch.DataSource = DepartmentManager.GetAllDepartment();
        ddlS_Branch.DataTextField = "Departmentname";
        ddlS_Branch.DataValueField = "Id";
        ddlS_Branch.DataBind();
        ddlS_Branch.SelectedValue = ddlS_Branch.Items.FindByText(se.S_Branch).Value;

        ddlCarMark.DataSourceID = null;
        ddlCarMark.DataSource = CarsManager.GetAllCars();
        ddlCarMark.DataTextField = "CarMark";
        ddlCarMark.DataValueField = "Car_Id";
        ddlCarMark.DataBind();
        ddlCarMark.SelectedValue = ddlCarMark.Items.FindByText(se.CarMark).Value;

        NewMethod();
        ddlS_People.SelectedValue = ddlS_People.Items.FindByText(se.S_People).Value;
        ddlJerquePeople.SelectedValue = ddlJerquePeople.Items.FindByText(se.JerquePeople).Value;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string name = "0";
            name = Request.QueryString["S_name"];
            Services se = new Services();
            se.S_Id = Convert.ToInt32(Request.QueryString["S_Id"]);
            if (ddlS_Branch.SelectedItem.Text.Trim() == "请选择")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('温馨提示:请选择正确的部门!');", true);
                return;
            }
            else
            {
                se.S_Branch = ddlS_Branch.SelectedItem.Text.Trim();
            }
            if (ddlJerquePeople.SelectedValue.Trim() == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('温馨提示:该部门没人,请选择其它部门！');", true);
                return;
            }
            else
            {
                se.JerquePeople = ddlJerquePeople.SelectedItem.Text.Trim();
            }

            se.BeginDate = Convert.ToDateTime(txtBeginDate.Value);
            se.EndDate = Convert.ToDateTime(txtEndDate.Value);
            if (se.BeginDate >= se.EndDate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('温馨提示:进厂日期必须大于出厂日期!');", true);
                return;
            }
            if (ddlCarMark.SelectedItem.Text.Trim() == "请选择")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('温馨提示:请选择正确的车牌号!');", true);
                return;
            }
            else
            {
                se.CarMark = ddlCarMark.SelectedItem.Text.Trim();
            }

            //图片上传判断
            string FileName = "";
            if (fuBillPhoto.PostedFile != null)
            {
                FileName = System.IO.Path.GetFileName(fuBillPhoto.PostedFile.FileName).ToLower();
                if (FileName == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('清单照片不能为空！');", true);
                    return;
                }
                fuBillPhoto.PostedFile.SaveAs(Server.MapPath("~/images/UpLoad/" + FileName));
                se.BillPhoto = "~/images/UpLoad/" + FileName;
            }
            else
            {
                se.BillPhoto = image.ImageUrl;
            }
            image.ImageUrl = se.BillPhoto;

            se.CarType = rblCarType.SelectedValue.Trim();
            se.S_Reason = Server.HtmlDecode(txtS_Reason.Text.Trim());

            se.S_Cost = Convert.ToDouble(txtS_Cost.Text.Trim());
            se.S_FactoryName = txtS_FactoryName.Text.Trim();
            se.S_People = ddlS_People.SelectedItem.Text.Trim();
            se.S_Result = Server.HtmlDecode(txtS_Result.Text.Trim());
            se.S_Type = ddlS_Type.SelectedValue;
            se.UseCost = Convert.ToDouble(txtUseCost.Text.Trim());
            if (name == "Up")
            {
                int result = ServicesManager.updateService(se);
                if (result != 0)
                {

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功！');window.location.href='Servicelist.aspx'", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败！');", true);

                    return;
                }

            }
            else
            {

                int result = ServicesManager.addService(se);
                if (result != 0)
                {

                    int id = Convert.ToInt32(ddlCarMark.SelectedItem.Value);
                    Car_Cars car = CarsManager.GetAllCarsById(id);
                    car.State = "未出车";
                    car.Car_Id = id;
                    CarsManager.UpdateCars(car);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "温馨提示：", "alert('添加成功！');window.location.href='Servicelist.aspx'", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！');", true);

                    return;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    protected void ddlS_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        NewMethod();
    }

    private void NewMethod()
    {
        int id= Convert.ToInt32(ddlS_Branch.SelectedValue);
        if (id != 0)
        {
        ddlS_People.DataSource = UserInfoManager.GetAllUsersByDepartmentId(id);
        ddlJerquePeople.DataSource = UserInfoManager.GetAllUsersByDepartmentId(id);
        ddlS_People.DataValueField = "UID";
        ddlS_People.DataTextField = "Name";
        ddlJerquePeople.DataValueField = "UID";
        ddlJerquePeople.DataTextField = "Name";
        ddlS_People.DataBind();
        ddlJerquePeople.DataBind();
        }
        else 
        {
            ddlJerquePeople.SelectedItem.Text = "请选择";
            ddlS_People.SelectedItem.Text = "请选择";
        }
    }
    protected void ddlCarMark_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = "0";
        name = Request.QueryString["C_name"];
        int id = Convert.ToInt32(ddlCarMark.SelectedValue);
        if (id != 0)
        {
            Car_Cars car = CarsManager.GetAllCarsById(id);
            Car_Type cartype = (Car_Type)CarTypeManager.GetAllCarsById(car.Typeid.TypeId);
            rblCarType.SelectedValue = cartype.Genre;
            if (name == "Up")
            {
                rblCarType.Enabled = false;
            }
        }
        else
        {

            rblCarType.SelectedValue = "普通用车";
        }
    }
    
}
