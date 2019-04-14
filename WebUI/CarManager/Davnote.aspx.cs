using System;
using System.Collections.Generic;
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


public partial class Davnote : System.Web.UI.Page
{
    public static int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
               
           // JiaZaiBind();
           
        }
    }
  /// <summary>
  /// 保存
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Car_Davnote dav = new Car_Davnote();
        dav = getdavs(ref dav);
        dav.DavnoteId = Id;

        int num = CarDavnoteManager.UpdateDavte(dav);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('保存成功！');window.location.href=Davnotelist.aspx';</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('保存失败！');", true);
        }
    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Car_Davnote davnote = new Car_Davnote();
        davnote = getdavs(ref davnote);
        int num = CarDavnoteManager.AddDavte(davnote);
        if (num > 0)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('保存成功！');window.location.href=Davnotelist.aspx';</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加失败！');", true);
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

    }

    //private void JiaZaiBind()
    //{
    //      int chuan = int.Parse(Request.Params["op"].ToString());
    //        Id = int.Parse(Request.Params["id"].ToString());
    //        if (chuan == 1)
    //        {
    //            this.Page.Title = "添加出车信息";
    //            this.lblTitle.Text = "添加出车信息";
    //            btnback.Visible = false;
    //            btnSave.Visible = false;
    //        }
    //        if (chuan == 2)
    //        {
    //            drpDept.DataSourceID = null;
    //            drpDept.DataSource = DepartmentManager.GetAllDepartment();
    //            drpDept.DataTextField = "departmentName";
    //            drpDept.DataValueField = "Id";
    //            drpDept.DataBind();
    //            this.Page.Title = "出车详细信息";
    //            this.lblTitle.Text = "出车详细信息";
    //            btnSubmit.Visible = false;
    //            btnSave.Visible = false;
    //            btnrepeat.Visible = false;
    //            Bind(Id);
    //            drpDept.Enabled=false;
    //            txtDirection.Enabled=false;
    //            drpDriver.Enabled=false;
    //            txtLiCheng.Enabled=false;
    //            drpMan.Enabled=false;
    //            txtMark.Enabled=false;
    //            drpDeptDriver.Enabled = false;
    //            txtReMark.Enabled=false;
    //            txtStartAddr.Enabled=false;
    //            rdo1.Enabled = false;
    //            rdo2.Enabled = false;
    //            rdo3.Enabled = false;
    //            rdo4.Enabled = false;
    //        }
    //        if (chuan == 3)
    //        {
    //            this.Page.Title= "修改出车信息";
    //            this.lblTitle.Text = "修改出车信息";
    //            btnSubmit.Visible = false;
    //            Bind(Id);
    //        }
    //    }
    /// <summary>
    /// 详细
    /// </summary>
    /// <param name="id"></param>
    public void Bind(int id)
    {

        //Car_Davnote dav = CarDavnoteManager.SelectDavnoteById(Id);
        //drpDept.SelectedValue = dav.DavDept.Id.ToString();
        
        //txtDirection.Text = dav.DavTtion.ToString();
        //drpDriver.Text = dav.DavDriver.Trim().ToString();
        //txtLiCheng.Text = dav.DavCourse.ToString();
        //drpMan.Text = dav.DavMan.Trim().ToString();
        //txtMark.Text = dav.DavMark.ToString();
        //txtOutDate.Value = dav.DavData.ToString();
        //txtReMark.Text = dav.DavRemark.ToString();
        //txtReturnDate.Value = dav.DavReturnData.ToString();
        //txtStartAddr.Text = dav.DavPlace.ToString();

        //if (dav.DavTypeId.TypeId == 1)
        //{
        //    rdo1.Checked = true;
        //}
        //else if (dav.DavTypeId.TypeId == 2)
        //{
        //    rdo2.Checked = true;
        //}
        //else if (dav.DavTypeId.TypeId == 3)
        //{
        //    rdo3.Checked = true;
        //}
        //else
        //{
        //    rdo4.Checked = true;
        //}

    }

    protected void drpDept_TextChanged(object sender, EventArgs e)
    {
        //int id = Convert.ToInt32(drpDept.SelectedValue.ToString());
        //IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
        //drpMan.Items.Clear();
        //foreach (var item in userlist)
        //{
        //    drpMan.Items.Add(new ListItem(item.Name, item.Name));
        //}
    }
    protected void drpDept_DataBound(object sender, EventArgs e)
    {
       // int id = Convert.ToInt32(drpDept.SelectedValue.ToString());
       //IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
       // drpMan.Items.Clear();
       // foreach (var item in userlist)
       // {
       //     drpMan.Items.Add(new ListItem(item.Name, item.Name));
       // }
    }
    protected void drpDeptDriver_TextChanged(object sender, EventArgs e)
    {
        //int id = Convert.ToInt32(drpDeptDriver.SelectedValue.ToString());
        //IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
        //drpDriver.Items.Clear();
        //foreach (var item in userlist)
        //{
        //    drpDriver.Items.Add(new ListItem(item.Name, item.Name));
        //}
    }
    protected void drpDeptDriver_DataBound(object sender, EventArgs e)
    {
        //int id = Convert.ToInt32(drpDeptDriver.SelectedValue.ToString());
        //IList<UserInfo> userlist = UserInfoManager.GetAllUsersByDepartmentId(id);
        //drpDriver.Items.Clear();
        //foreach (var item in userlist)
        //{
        //    drpDriver.Items.Add(new ListItem(item.Name, item.Name));
        //}
    }


    public Car_Davnote getdavs(ref Car_Davnote dav)
    {
        //dav.DavDept.DepartmentName = drpDept.SelectedItem.Text;
        //dav.DavTtion = txtDirection.Text.ToString();
        ////dav.DavDriver = drpDriver.SelectedItem.Text;
        //dav.DavCourse = Decimal.Parse(txtLiCheng.Text.ToString());
        //dav.DavMan = drpMan.SelectedItem.Text;
        //dav.DavMark = txtMark.Text.ToString();
        //dav.DavData = DateTime.Parse(txtOutDate.Value.ToString());
        //dav.DavRemark = txtReMark.Text.ToString();
        //dav.DavReturnData = DateTime.Parse(txtReturnDate.Value.ToString());
        //dav.DavPlace = txtStartAddr.Text.ToString();
      
        //if (rdo1.Checked)
        //{
        //    dav.DavTypeId.TypeId = 1;
        //}
        //if (rdo2.Checked)
        //{
        //    dav.DavTypeId.TypeId = 2;
        //}
        //if (rdo3.Checked)
        //{
        //    dav.DavTypeId.TypeId = 3;
        //}
        //if (rdo4.Checked)
        //{
        //    dav.DavTypeId.TypeId = 4;
        //}
        //return dav;
        return null;

    }
}

