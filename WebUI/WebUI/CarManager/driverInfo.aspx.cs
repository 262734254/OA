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
using System.Data.SqlClient;
using Model;

public partial class CarManager_driverInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ucpage.onPageIndexChanging += new CarManager_MyPage.myDele(ucpage_onPageIndexChanging);
        if (!IsPostBack)
        {
            ucpage_onPageIndexChanging(ucpage.PageIndex);
          
        }
    }

    void ucpage_onPageIndexChanging(int pageIndex)
    {
        string userName = txtMark.Text.ToString();
        gvUserInfo.DataSourceID = null;
        IList<Car_UserInfo> list = CarUserInfoManager.SelectCarsDark(userName);
        if (list.Count == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('无记录！');", true);

        }
        PagedDataSource page = new PagedDataSource();
        page.AllowPaging = true;
        page.DataSource = list;//CarUserInfoManager.GetAllUserInfo();
        page.PageSize = 5;
        ucpage.PageCount = page.PageCount;

        page.CurrentPageIndex = pageIndex;

        gvUserInfo.DataSource = page;
        ucpage.SetButtonEnable();

        gvUserInfo.DataBind();
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        ucpage.PageIndex = 0;
        ucpage_onPageIndexChanging(ucpage.PageIndex);
        txtMark.Text = "";
    }

    protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            string Id = e.CommandArgument.ToString();
            try
            {
                Car_UserInfo cars = CarUserInfoManager.GetAllCarsById(Convert.ToInt32(Id));

                if (cars.State == "已出车" || cars.State == "维修中")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('此车不是未出车状态不可删除！');", true);
                }
                else
                {
                    int num = CarUserInfoManager.DeleteDriver(Id);

                    if (num > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除成功！');", true);
                    }

                    gvUserInfo.DataSourceID = null;
                    gvUserInfo.DataSource = odsUserInfo;
                    gvUserInfo.DataBind();
                }
            }
            catch
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('删除失败！');", true);
                return;
            }
        }
    }
  
}
