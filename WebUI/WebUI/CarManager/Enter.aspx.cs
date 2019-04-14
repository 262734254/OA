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
using Model;
using BLL.Car;
using BLL.Power;


public partial class CarManager_Enter : System.Web.UI.Page
{
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        int chuan = int.Parse(Request.Params["op"].ToString());
        Id = int.Parse(Request.Params["id"].ToString());

            
        if (chuan == 1)
        {

           

            Bind(Id);
            
            txtDirection.Enabled = false;
            txtLiCheng.Enabled = false;
            txtMark.Enabled = false;
            txtReMark.Enabled = false;
            txtStartAddr.Enabled = false;
            rdo1.Enabled = false;
            rdo2.Enabled = false;
            rdo3.Enabled = false;
            rdo4.Enabled = false;
         }
        }
    }
    public void Bind(int id)
    {

        Car_Davnote dav = CarDavnoteManager.SelectDavnoteById(Id);
        
        ddlDepartment.DataSourceID = null;
        ddlDepartment.DataSource = DepartmentManager.GetAllDepartment();
        ddlDepartment.DataTextField = "departmentName";
        ddlDepartment.DataValueField = "Id";
        ddlDepartment.DataBind();
        ddlDepartment.SelectedValue = dav.DavDept.Id.ToString();

        txtDirection.Text = dav.DavTtion.ToString();
        txtLiCheng.Text = dav.DavCourse.ToString();
        txtMan.Text = dav.DavMan.Trim().ToString();
        txtDriver.Text = dav.DavDriver.Trim().ToString();
        txtMark.Text = dav.DavMark.ToString();
        txtOutDate.Value = dav.DavData.ToString();
        txtReMark.Text = dav.DavRemark.ToString();
        txtReturnDate.Value = dav.DavReturnData.ToString();
        txtStartAddr.Text = dav.DavPlace.ToString();

        if (dav.DavTypeId.TypeId == 1)
        {
            rdo1.Checked = true;
        }
        else if (dav.DavTypeId.TypeId == 2)
        {
            rdo2.Checked = true;
        }
        else if (dav.DavTypeId.TypeId == 3)
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

    protected void btnHuiChe_Click1(object sender, EventArgs e)
    {
        Car_Enter davnote = new Car_Enter();
        davnote = getdavs(ref davnote);
        int num = CarEnterManager.AddEnter(davnote);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回车成功！');window.location.href='Davnotelist.aspx';</script>");
          
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('回车失败！');", true);
        }

    }



    public Car_Enter getdavs(ref Car_Enter dav)
    {

        dav.Dept.Id = Convert.ToInt32(ddlDepartment.SelectedValue);
        dav.Ttion = txtDirection.Text.ToString();
        dav.Dirver = txtDriver.Text.ToString();
        dav.Course = Decimal.Parse(txtLiCheng.Text.ToString());
        dav.Man = txtMan.Text.ToString();
        dav.Mark = txtMark.Text.ToString();
        
        dav.EnterData = DateTime.Parse(txtOutDate.Value.ToString());
        dav.Remark = txtReMark.Text.ToString();
        dav.ReturnData = DateTime.Parse(txtReturnDate.Value.ToString());
        dav.Place = txtStartAddr.Text.ToString();
        dav.ShiJiReturnDatd = DateTime.Parse(txtShiJireturnDate.Text.ToString());
        dav.HuiCheLiCheng = Decimal.Parse(txtHuiCheLiCheng.Text.ToString());

        if (rdo1.Checked)
        {
            dav.Typeid.TypeId = 1;
        }
        if (rdo2.Checked)
        {
            dav.Typeid.TypeId = 2;
        }
        if (rdo3.Checked)
        {
            dav.Typeid.TypeId = 3;
        }
        if (rdo4.Checked)
        {
            dav.Typeid.TypeId = 4;
        }
        return dav;

    }
}
