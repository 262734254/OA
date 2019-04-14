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
using BLL.Power;
using IDAL.Power;
using DAL;
public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserInfo userInfo = new UserInfo();
        userInfo.Name = txtName.Text.Trim();
        userInfo.Password = txtpass.Text.Trim();
        userInfo.IdentityCard = txtIDcard.Text.Trim();
        userInfo.Sex = DropDownList1.SelectedValue;
        userInfo.Age = Convert.ToInt32(txtAge.Text.Trim());
        userInfo.MobilePhone = Convert.ToInt32(txtphone.Text.Trim());
        userInfo.HomePhone = txtseat.Text.Trim();
        userInfo.Address = txtAddress.Text.Trim();
        userInfo.Qq = Convert.ToInt32(txtQQ.Text.Trim());
        userInfo.Email = txtEmail.Text.Trim();
        userInfo.Msn = txtMSN.Text.Trim();
        userInfo.Department.Id = Convert.ToInt32(DropDownList2.SelectedValue);
        userInfo.Remark = TextBox14.Text.Trim();
        userInfo.UserStatus = HiddenField1.Value;
        string FileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName).ToLower();
       if(!string.IsNullOrEmpty(FileName))
       {
        fileUpload.PostedFile.SaveAs(Server.MapPath("~/images/UpLoad/" + FileName));
        userInfo.Picture = "~/images/UpLoad/" + FileName;
       //IUserInfoService userInfoService = new UserInfoService();
       }
        else
       {
        userInfo.Picture="";
       }
        int num = UserInfoManager.AddCalendar(userInfo);
     
        if (num > 0)

            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');</script>");
        else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
          
    }
}
