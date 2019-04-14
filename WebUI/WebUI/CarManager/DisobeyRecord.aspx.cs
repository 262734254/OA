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
public partial class weizhangshigujilu : System.Web.UI.Page
{
    static int DR_Id = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string name = "0";
            DR_Id = Convert.ToInt32(Request.QueryString["DR_Id"]);
            name = Request.QueryString["DR_name"];
            if (DR_Id != 0)
            {
                Dasoue();
            }
            if (name == "Sel")
            {
                btnSave.Visible = false;
            }
            if (name == "Up")
            {
                fuBillPhoto.Enabled = false;
                rblDR_CarType.Enabled = false;
                ddlCarMark.Enabled = false;
                ddlDR_Type.Enabled = false;
            }
            if(ddlDR_Type.SelectedItem.Text == "违章")
            {
                txtDR_Circs.Text = "无";
                txtDR_Circs.ReadOnly = true;
            }
           

        }
    }
    private void Dasoue()
    {

        DR_Id = Convert.ToInt32(Request.QueryString["DR_Id"]);
        DisobeyRecord dr = DisobeyRecordManager.getDisobeyRecordById(DR_Id);
        image.ImageUrl = dr.BillPhoto;
        rblDR_CarType.SelectedValue = dr.Dr_CarType;
        txtDR_Circs.Text = dr.DR_Circs;
        txtDR_Date.Value = dr.DR_Date.ToShortDateString();
        txtDR_Expense.Text = dr.DR_Expense.ToString();
        txtDR_Explain.Value = dr.DR_Explain;
        txtDR_Locus.Text = dr.DR_Locus;
        txtDR_Sum.Text = dr.DR_Sum.ToString();
        ddlDR_Type.SelectedValue = dr.DR_Type;
        txtFactCost.Text = dr.FactCost.ToString();
        txtRemark.Value = dr.Remark;
        image.ImageUrl = dr.BillPhoto;
        ddlDR_Department.DataSourceID = null;
        ddlDR_Department.DataSource = DepartmentManager.GetAllDepartment();
        ddlDR_Department.DataTextField = "Departmentname";
        ddlDR_Department.DataValueField = "Id";
        ddlDR_Department.DataBind();
        ddlDR_Department.SelectedValue = ddlDR_Department.Items.FindByText(dr.DR_Department).Value;
        NewMethod();
        ddlDR_People.SelectedValue = ddlDR_People.Items.FindByText(dr.DR_People).Value;
        ddlCarMark.DataSourceID = null;
        ddlCarMark.DataSource = CarsManager.GetAllCars(); ;
        ddlCarMark.DataTextField = "CarMark";
        ddlCarMark.DataValueField = "Car_Id";
        ddlCarMark.DataBind();
        ddlCarMark.SelectedValue = ddlCarMark.Items.FindByText(dr.CarMark).Value;
        NewMethod();
 
        
    }

    protected void ddlDR_Department_SelectedIndexChanged(object sender, EventArgs e)
    {
        NewMethod();
    }

    private void NewMethod()
    {
        int id = 1;
        id = Convert.ToInt32(ddlDR_Department.SelectedValue);
        if (id != 0)
        {
            ddlDR_People.DataSource = UserInfoManager.GetAllUsersByDepartmentId(id);
            ddlDR_People.DataValueField = "UID";
            ddlDR_People.DataTextField = "Name";
            ddlDR_People.DataBind();
        }
        else
        {
            ddlDR_People.SelectedItem.Text = "请选择";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
      try 
	{	        
		  string name = "0";
        name = Request.QueryString["DR_name"];
        DisobeyRecord dr = new DisobeyRecord();
        dr.DR_Id = Convert.ToInt32(Request.QueryString["DR_Id"]);
  
     
        if (ddlCarMark.SelectedItem.Text=="请选择")
        {
             Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('温馨提示:请选择正确的车牌号！')", true);
             return;
        }
        else
        {
        dr.CarMark = ddlCarMark.SelectedItem.Text;
        }
        dr.Dr_CarType = rblDR_CarType.SelectedValue;
     
        dr.DR_Date = Convert.ToDateTime(txtDR_Date.Value);
        if (ddlDR_Department.SelectedItem.Text=="请选择")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(),"","alert('温馨提示:请选择正确的部门！')",true);
            return;
        }else
        {
        dr.DR_Department = ddlDR_Department.SelectedItem.Text;
        }
       
        dr.DR_Explain =Server.HtmlDecode(txtDR_Explain.Value.Trim()); 
        dr.DR_Locus = txtDR_Locus.Text.Trim(); 
        if (ddlDR_People.SelectedItem.Text=="")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('温馨提示:该部门没人,请选择其它部门！')", true);
            return;
        }
        else
        {
        dr.DR_People = ddlDR_People.SelectedItem.Text;
        }
      
        dr.DR_Type = ddlDR_Type.SelectedValue;                     //类型（违章，事故）
        dr.DR_Expense = Convert.ToDouble(txtDR_Expense.Text);      //经  济  损  失
        dr.DR_Sum = Convert.ToDouble(txtDR_Sum.Text.Trim());       //罚 款 金额
        dr.FactCost = Convert.ToDouble(txtFactCost.Text.Trim());   //实际赔偿费

            dr.DR_Circs = txtDR_Circs.Text.Trim(); 
            dr.Remark =Server.HtmlDecode(txtRemark.Value.Trim());


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
                dr.BillPhoto = "~/images/UpLoad/" + FileName;
            }
            else
            {
                dr.BillPhoto = image.ImageUrl;
            }
            image.ImageUrl = dr.BillPhoto;
       
        if (name == "Up")
        {
            int result = DisobeyRecordManager.updateDisobeyRecord(dr);
            if (result != 0)
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功！');window.location.href='DisobeyRecordlist.aspx'", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新失败！');", true);

                return;
            }

        }
        else
        {
            int result = DisobeyRecordManager.addDisobeyRecord(dr);
            if (result != 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');window.location.href='DisobeyRecordlist.aspx'", true);
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
          return;
      }
       
    }
    protected void ddlCarMark_SelectedIndexChanged(object sender, EventArgs e)
    {
        string name = "0";
        name = Request.QueryString["DR_name"];
        int id = Convert.ToInt32(ddlCarMark.SelectedValue);
        if (id != 0)
        {
            Car_Cars car = CarsManager.GetAllCarsById(id);
            Car_Type cartype = (Car_Type)CarTypeManager.GetAllCarsById(car.Typeid.TypeId);
            rblDR_CarType.SelectedValue = cartype.Genre;
            if (name == "Up")
            {
                rblDR_CarType.Enabled = false;
            }
        }
        else
        {

            rblDR_CarType.SelectedValue = "普通用车";

        }
    }
    protected void ddlDR_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDR_Type.SelectedItem.Text == "事故")
        {
            txtDR_Circs.Text = "";
            txtDR_Circs.ReadOnly = false;
            //txtFactCost.ReadOnly = true;
        }
        else 
        {

            txtDR_Circs.Text = "无";
            txtDR_Circs.ReadOnly = true;
        }
    }
}
