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


            JiaZaiBind();
           
        }
    }
    private void JiaZaiBind()
    {
        int chuan = int.Parse(Request.Params["op"].ToString());
        Id = int.Parse(Request.Params["id"].ToString());

        if (chuan == 2)
        {

            this.Page.Title = "出车详细信息";
            this.lblTitle.Text = "出车详细信息";

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
            txtOutDate.Enabled = false;
            txtReturnDate.Enabled = false;
        }

    }
    /// <summary>
    /// 详细
    /// </summary>
    /// <param name="id"></param>
    public void Bind(int id)
    {

        Car_Davnote dav = CarDavnoteManager.SelectDavnoteById(Id);
        txtDept.Text = dav.DavDept.Departmentname.ToString();
        txtDirection.Text = dav.DavTtion.ToString();
        txtLiCheng.Text = dav.DavCourse.ToString();
        txtMan.Text = dav.DavMan.Trim().ToString();
        txtDriver.Text = dav.DavDriver.Trim().ToString();
        txtMark.Text = dav.DavMark.ToString();
        txtOutDate.Text = dav.DavData.ToString();
        txtReMark.Text = dav.DavRemark.ToString();
        txtReturnDate.Text = dav.DavReturnData.ToString();
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
}

