using System;
using System.Collections.Generic;
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
using BLL.Power;

public partial class CarManager_AddDavnote : System.Web.UI.Page
{
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            JiaZaiBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Car_Davnote davnote = new Car_Davnote();
        davnote = getdavs(ref davnote);
        int num = CarDavnoteManager.AddDavte(davnote);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.href='Davnotelist.aspx';</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！');", true);
            return;
        }

    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    //protected void drpDept_TextChanged(object sender, EventArgs e)
    //{
    //    int id = Convert.ToInt32(drpDept.SelectedValue.ToString());
    //    IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
    //    drpMan.Items.Clear();
    //    foreach (var item in userlist)
    //    {
    //        drpMan.Items.Add(new ListItem(item.Name, item.Name));
    //    }
    //}
    //protected void drpDept_DataBound(object sender, EventArgs e)
    //{
    //    int id = Convert.ToInt32(drpDept.SelectedValue.ToString());
    //    IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
    //    drpMan.Items.Clear();
    //    foreach (var item in userlist)
    //    {
    //        drpMan.Items.Add(new ListItem(item.Name, item.Name));
    //    }
    //}
    public Car_Davnote getdavs(ref Car_Davnote dav)
    {


        dav.DavDept.Id = Convert.ToInt32(drpDept.SelectedValue);
        //dav.DavDept.Id = Convert.ToInt32(txtDept.Department.Id);
        dav.DavTtion = txtDirection.Text.ToString();
        dav.DavDriver = drpDriver.SelectedItem.Text;
        dav.DavCourse = Decimal.Parse(txtLiCheng.Text.ToString());
        dav.DavMan = txtMan.Text.ToString();
        dav.DavMark = dllMark.SelectedItem.Text;
        dav.DavData = DateTime.Parse(txtOutData.Text.ToString());
        dav.DavRemark = txtReMark.Text.ToString();
        dav.DavReturnData = DateTime.Parse(txtReturnDate.Text.ToString());
        dav.DavPlace = txtStartAddr.Text.ToString();

   
        if (rdo1.Checked)
        {
            dav.DavTypeId.TypeId = 1;
        }
        if (rdo2.Checked)
        {
            dav.DavTypeId.TypeId = 2;
        }
        if (rdo3.Checked)
        {
            dav.DavTypeId.TypeId = 3;
        }
        if (rdo4.Checked)
        {
            dav.DavTypeId.TypeId = 4;
        }
 
        return dav;

    }

      private void JiaZaiBind()
      {
        int chuan = int.Parse(Request.Params["op"].ToString());
        Id = int.Parse(Request.Params["id"].ToString());
        Bind(Id);
        if (chuan == 2)
        {

           
            Bind(Id);
            rdo1.Enabled = false;
            rdo2.Enabled = false;
            rdo3.Enabled = false;
            rdo4.Enabled = false;
           
        }
      

    
    }
    public void Bind(int id)
    {
      
        Car_Byapply car = CarByapplyManager.GetAllCarsByappyById(Id);
        txtOutData.Text = car.ByData.ToString();
        drpDept.DataSourceID = null;
        drpDept.DataSource = DepartmentManager.GetAllDepartment();
        drpDept.DataTextField = "departmentName";
        drpDept.DataValueField = "Id";
        drpDept.DataBind();
        drpDept.SelectedValue = car.ByDept.Id.ToString();
        txtMan.Text = car.ByMan.ToString();
        txtReMark.Text = car.ByCause.ToString();
        txtDirection.Text = car.ByDttion.ToString();
        txtReturnDate.Text = car.ByReData.ToString();
       

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


    protected void dllMark_SelectedIndexChanged(object sender, EventArgs e)
    {
              //string id = Convert.ToString (dllMark.SelectedValue);
              //string car =CarsManager.usp_SelectCarMarkType(Convert.ToString(id)) ;
              //Car_Type cartype = (Car_Type)CarTypeManager.GetAllCarsById(Convert.ToInt32(car));
              //rblCarType.SelectedValue = cartype.Genre;

    }
}
