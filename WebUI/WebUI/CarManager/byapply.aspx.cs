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
using BLL.Power;

public partial class CarManager_byapply : System.Web.UI.Page
{
    public static int Id;
    public static UserInfo user;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user"] != null)
            {

                user = (UserInfo)Session["user"];
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('您必须先登录！');window.location.href='~/login.aspx'", true);
                return;
            }
            txtMan.Text = user.Name;
            Department Depart = DepartmentManager.GetAllDepartementById(user.Department.Id);
            txtDept.Text = Depart.Departmentname;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        Car_Byapply byapply = new Car_Byapply();
        try
        {

            byapply = getBind(byapply);
            int num = CarByapplyManager.InsertByCar(byapply);
            if (num > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('申请成功！,请等待审核！');window.location.href='shenlist.aspx';</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('添加失败！');</script>");
            }
        }
        catch (Exception)
        {
            
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('添加失败！');</script>");
        }
    }

    private void clear()
    {
        txtByCause.Text = "";
        txtByData.Text = "";
        txtByttion.Text = "";
        txtReData.Text = "";
    }
    public Car_Byapply getBind(Car_Byapply byapply)
    {
        byapply.ByCause = Server.HtmlDecode(txtByCause.Text);
        byapply.ByData = DateTime.Parse(txtByData.Text.Trim());

        byapply.ByDept.Id=Convert.ToInt32(user.Department.Id);
        byapply.ByDttion = txtByttion.Text.Trim();
        byapply.ByMan = txtMan.Text.ToString();
        byapply.ByReData = DateTime.Parse(txtReData.Text.Trim());
     
        if (rdo1.Checked == true)
        {
            byapply.ByTypeid.TypeId = 1;
        }
        if (rdo2.Checked == true)
        {
            byapply.ByTypeid.TypeId = 2;
        }
        if (rdo3.Checked == true)
        {
            byapply.ByTypeid.TypeId = 3;
        }
        if (rdo4.Checked == true)
        {
            byapply.ByTypeid.TypeId = 4;
        }
      
        return byapply;
    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
}
