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
using BLL.Car;
using Model;

public partial class CarManager_newCars : System.Web.UI.Page
{
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int cars = int.Parse(Request.Params["op"].ToString());
            Id = int.Parse(Request.Params["id"].ToString());
            if (cars == 1)
            {

                this.Page.Title = "添加新车辆信息";
                this.lblTitle1.Text = "添加新车辆信息";

                btnSave.Visible = false;
                ddlState.Enabled = false;
                
                
            }
            if (cars == 2)
            {
                Page.Title = "车辆详细信息";
                this.lblTitle1.Text = "车辆详细信息";
                btnSubmit.Visible = false;
                btnSave.Visible = false;
                btnrepeat.Visible = false;
                CasDatdBind(Id);
                txtBuyDate.Attributes.Add("readonly", "true");
                rdo1.Enabled = false;
                rdo2.Enabled = false;
                rdo3.Enabled = false;
                rdo4.Enabled = false;
                txtBuyMoney.Enabled = false;
                txtChangJia.Enabled = false;
                txtLisence.Enabled = false;
                txtRemark.Enabled = false;
                txtSeating.Enabled = false;
                ddlState.Enabled = false;
                
            }
            if (cars == 3)
            {
                Page.Title = "修改车辆信息";
                
                this.lblTitle1.Text = "修改车辆信息";
                btnSubmit.Visible = false;
                this.txtLisence.Enabled = false;
                ddlState.Enabled = false;
                btnrepeat.Visible = false;
                CasDatdBind(Id);
            }

        }
    }


      /// <summary>
      /// 详细信息绑定
      /// </summary>
    private void CasDatdBind(int id)
    {
     
        Model.Car_Cars cars = CarsManager.GetAllCarsById(Id);
        txtBuyDate.Text = cars.BuyData.ToString();
        txtBuyMoney.Text = cars.BuyMoney.ToString();
        txtChangJia.Text = cars.Buywork.ToString();
        txtLisence.Text = cars.CarMark.ToString();
        txtRemark.Text = cars.ReMark.ToString();
        txtSeating.Text = cars.Seating.ToString();
        ddlState.SelectedValue = cars.State.ToString();
     
      



        if (cars.Typeid.TypeId == 1)
        {
            rdo1.Checked = true;
          
        }
        else if (cars.Typeid.TypeId == 2)
        {
            rdo2.Checked = true;
        }
        else if (cars.Typeid.TypeId == 3)
        {
            rdo3.Checked = true;
        }
        else
        {
            rdo4.Checked = true;
        }

    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="car"></param>
    /// <returns></returns>
    public Model.Car_Cars getcheers(ref Model.Car_Cars car)
    {
        Car_Cars cars = CarsManager.GetAllCarsById(Id);
        car.BuyData = DateTime.Parse(txtBuyDate.Text.ToString());
        car.BuyMoney = Decimal.Parse(txtBuyMoney.Text.ToString());
        car.Buywork = txtChangJia.Text.ToString();
        car.CarMark = txtLisence.Text.ToString();
        car.ReMark = txtRemark.Text.ToString();
        car.State = ddlState.SelectedValue.ToString();
      
        car.Seating =Convert.ToInt32( txtSeating.Text);


        if (rdo1.Checked)
        {
            car.Typeid.TypeId = 1;
        }
        if (rdo2.Checked)
        {
            car.Typeid.TypeId = 2;
        }
        if (rdo3.Checked)
        {
            car.Typeid.TypeId = 3;
        }
        if (rdo4.Checked)
        {
            car.Typeid.TypeId = 4;
        }
        return car;

    }

    /// <summary>
    /// 修改方法
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Model.Car_Cars car = new Model.Car_Cars();
        car = getcheers(ref car);
        car.Car_Id = Id;

        int num = CarsManager.UpdateCars(car);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('保存成功！');window.location.href='carslist.aspx';</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存失败！');", true);
        }
    }
    /// <summary>
    /// 添加车辆
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       try 
	{	        
		 Model.Car_Cars cars = new Model.Car_Cars();
        cars = getcheers(ref cars);
        int num = CarsManager.InsertCars(cars);
        if (num > 0)
        {

            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('添加成功！');window.location.href='carslist.aspx';</script>");

        }
	}
	catch (Exception)
	{
		
		
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('车牌号码有重复，添加失败！');", true);
        
	}
        
    }
    /// <summary>
    /// 返回
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 重填
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnrepeat_Click(object sender, EventArgs e)
    {
        txtBuyDate.Text = "";
        txtBuyMoney.Text = "";
        txtChangJia.Text = "";
        txtLisence.Text = "";
        txtRemark.Text = "";

    }

   
}
