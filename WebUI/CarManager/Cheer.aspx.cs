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


public partial class jiayoujilu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rblCarType.Enabled = true;
            ddlCarMark.Enabled = true;
            int C_Id = 1;
            string name = "0";
            C_Id = Convert.ToInt32(Request.QueryString["C_Id"]);
            name = Request.QueryString["C_name"];
            if (C_Id != 0)
            {
                Cheer ch = CheerManager.getCheerById(C_Id);
                ddlCarMark.DataSourceID = null;
                ddlCarMark.DataSource = CarsManager.GetAllCars();
                ddlCarMark.DataTextField = "CarMark";
                ddlCarMark.DataValueField = "Car_Id";
                ddlCarMark.DataBind();
                ddlCarMark.SelectedItem.Text = ch.CarMark;
                ddlCheerType.SelectedValue = ch.C_CheerType;
                txtCheerDate.Value = ch.C_Date.ToShortDateString();
                txtMoney.Text = ch.C_Sum.ToString();
                txtStation.Text = ch.C_Station;
                rblCarType.SelectedValue = ch.C_CarType;
                txtRemark.Value = ch.Remark;
                image.ImageUrl = ch.BillPhoto;
            }
            if (name == "Up")
            {
                rblCarType.Enabled = false;
                ddlCarMark.Enabled = false;
            }
            //else
            //{
            //    rblCarType.Enabled = false;
            //}

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string name = "0";
        name = Request.QueryString["C_name"];
        Cheer ch = new Cheer();
        ch.C_Id = Convert.ToInt32(Request.QueryString["C_Id"]);

        string FileName = System.IO.Path.GetFileName(fuBillPhoto.PostedFile.FileName).ToLower();
        if (!string.IsNullOrEmpty(FileName))
        {
            fuBillPhoto.PostedFile.SaveAs(Server.MapPath("~/images/UpLoad/" + FileName));
            ch.BillPhoto = "~/images/UpLoad/" + FileName;
        }
        else
        {
            ch.BillPhoto = "";
        }


        image.ImageUrl = ch.BillPhoto;
        ch.C_CarType = rblCarType.SelectedValue;
        ch.C_CheerType = ddlCheerType.SelectedValue;
        ch.C_Date = Convert.ToDateTime(txtCheerDate.Value);
        ch.C_Station = txtStation.Text;
        ch.C_Sum = Convert.ToDouble(txtMoney.Text);
        ch.Remark = txtRemark.Value;
        ch.CarMark = ddlCarMark.SelectedItem.Text;
        if (ddlCarMark.SelectedItem.Text == "请选择")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请选择正确的车牌号！');", true);

            return;
        }
        if (name == "Up")
        {
        
       
            int result = CheerManager.updateCheer(ch);
            if (result != 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功！');window.location.href='Cheerlist.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败！');", true);
                txtCheerDate.Value = "";
                txtStation.Text = "";
                txtMoney.Text = "";
                txtRemark.Value = "";
                return;
            }

        }
        else
        {
           
            int result = CheerManager.addCheer(ch);
            if (result != 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');window.location.href='Cheerlist.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！');", true);
                txtCheerDate.Value = "";
                txtStation.Text = "";
                txtMoney.Text = "";
                txtRemark.Value = "";
                return;
            }
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
            //rblCarType.Enabled = true;
        }
    }
 
}
