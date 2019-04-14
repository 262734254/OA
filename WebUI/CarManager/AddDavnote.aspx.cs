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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Car_Davnote davnote = new Car_Davnote();
        davnote = getdavs(ref davnote);
        int num = CarDavnoteManager.AddDavte(davnote);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.href='Davnotelist.aspx';</script>");

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');", true);
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
    protected void drpDept_TextChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(drpDept.SelectedValue.ToString());
        IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
        drpMan.Items.Clear();
        foreach (var item in userlist)
        {
            drpMan.Items.Add(new ListItem(item.Name, item.Name));
        }
    }
    protected void drpDept_DataBound(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(drpDept.SelectedValue.ToString());
        IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
        drpMan.Items.Clear();
        foreach (var item in userlist)
        {
            drpMan.Items.Add(new ListItem(item.Name, item.Name));
        }
    }
    public Car_Davnote getdavs(ref Car_Davnote dav)
    {
     

        dav.DavDept.Id =Convert.ToInt32( drpDept.SelectedValue.ToString());
        dav.DavTtion = txtDirection.Text.ToString();
        dav.DavDriver = drpDriver.SelectedItem.Text;
        dav.DavCourse = Decimal.Parse(txtLiCheng.Text.ToString());
        dav.DavMan = drpMan.SelectedItem.Text;
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
}
