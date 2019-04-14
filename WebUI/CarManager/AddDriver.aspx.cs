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

public partial class CarManager_AddDriver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void JiaZaiBind()
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Car_UserInfo davnote = new Car_UserInfo();
        davnote = getdavs(ref davnote);
        int num = CarUserInfoManager.AddDavte(davnote);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.href='driverInfo.aspx';</script>");

         
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！');", true);
            return;
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    public Car_UserInfo getdavs(ref Car_UserInfo dav)
    {

        dav.Address = txtAddRess.Text.ToString();
        dav.Age =Convert.ToInt32(txtAge.Text.Trim());
        dav.Phone = txtPhone.Text.ToString();
        dav.State = txtState.Text.ToString();
        dav.UserName = txtName.Text.ToString();
      

        if(rdoMan.Checked)
        {
            dav.Sex = "男";
        }
        if (rdoGril.Checked)
        {
            dav.Sex="女";
        }
      
        return dav;

    }
}
