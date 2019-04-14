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
public partial class CarManager_elseCost : System.Web.UI.Page
{
    static int CS_Id = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string name = "0";
            CS_Id = Convert.ToInt32(Request.QueryString["CS_Id"]);
            name = Request.QueryString["CS_name"];
            if (CS_Id != 0)
            {
                CostSupervise cs = CostSuperviseManager.getCostSuperviseById(CS_Id);
                txtCS_Date.Value = cs.CS_Date.ToShortDateString();
                ddlMark.DataSourceID = null;
                ddlMark.DataSource = CarsManager.GetAllCars();
                ddlMark.DataTextField = "CarMark";
                ddlMark.DataValueField = "Car_Id";
                ddlMark.DataBind();
                ddlMark.SelectedItem.Text = cs.CarMark;
                ddlCS_Item.SelectedValue = cs.CS_Item;
                txtC_Sum.Text = cs.CS_Cost.ToString();
                rblCarType.SelectedValue = cs.CS_CarType;
                image.ImageUrl = cs.BillPhoto;
                txtRemark.Value =Server.HtmlDecode(cs.Remark);
            }
            if (name == "Sel")
            {
                btnSave.Visible = false;

            }
            if (name == "Up")
            {
                fuBillPhoto.Enabled = false;
                rblCarType.Enabled = false;
                ddlMark.Enabled = false;
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
        name = Request.QueryString["CS_name"];
        CostSupervise cs = new CostSupervise();
        cs.CS_Id = CS_Id;
        cs.CS_Date = Convert.ToDateTime(txtCS_Date.Value);
        cs.CarMark = ddlMark.SelectedItem.Text;
        cs.CS_Item = ddlCS_Item.SelectedValue;
        cs.CS_Cost = Convert.ToDouble(txtC_Sum.Text);
        cs.CS_CarType = rblCarType.SelectedValue;
        if (ddlMark.SelectedItem.Text == "请选择")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请选择正确的车牌号！');", true);

            return;
        }
        //图片上传判断
        string FileName ="";
        if (fuBillPhoto.PostedFile!=null)
        {
            FileName = System.IO.Path.GetFileName(fuBillPhoto.PostedFile.FileName).ToLower();
            if (FileName=="")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('清单照片不能为空！');", true);
                return;
            }
            fuBillPhoto.PostedFile.SaveAs(Server.MapPath("~/images/UpLoad/" + FileName));
            cs.BillPhoto = "~/images/UpLoad/" + FileName;
        }
        else
        {
            cs.BillPhoto = image.ImageUrl;
        }
        image.ImageUrl=cs.BillPhoto;

        cs.Remark =Server.HtmlDecode(txtRemark.Value);
 
        if (name == "Up")
        {
            int result = CostSuperviseManager.updateCostSupervise(cs);
            if (result != 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功！');window.location.href='ElseCostlist.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败！');", true);
                txtCS_Date.Value = "";
                txtC_Sum.Text = "";
                txtRemark.Value = "";
                return;
            }

        }
        else
        {
      
            int result = CostSuperviseManager.addCostSupervise(cs);
            if (result != 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');window.location.href='ElseCostlist.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！');", true);
                txtCS_Date.Value = "";
                txtC_Sum.Text = "";
                txtRemark.Value = "";
                return;
            }
      
        }
    }
    protected void ddlMark_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = "0";
        name = Request.QueryString["C_name"];
        int  id = Convert.ToInt32(ddlMark.SelectedValue);
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
