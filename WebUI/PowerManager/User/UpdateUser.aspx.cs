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
using DAL;
public partial class PowerManager_User_UpdateUser : System.Web.UI.Page
{
    static int uId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["UID"].ToString()))
            {
                uId = Convert.ToInt32(Request.QueryString["UID"]);
                Bind();
            }
        }
    }
    private void Bind()
    {

        UserInfo userInfo = UserInfoManager.GetAllUserById(uId);
        this.txtName.Text = userInfo.Name;
        this.txtIDcard.Text = userInfo.IdentityCard;

        if (userInfo.Sex.Trim() == "男")
        {
            this.rdoSex.SelectedValue = "男";
        }
        else
        {
            this.rdoSex.SelectedValue = "女";
        }
        this.txtAddress.Text = userInfo.Address;
        this.txtAge.Text = Convert.ToString(userInfo.Age);
        this.txtphone.Text = Convert.ToString(userInfo.MobilePhone);
        this.txtseat.Text = userInfo.HomePhone;
        this.txtQQ.Text = Convert.ToString(userInfo.Qq);
        this.txtEmail.Text = userInfo.Email;
        this.txtMSN.Text = userInfo.Msn;
        this.TextBox14.Text = userInfo.Remark;
        this.DropDownList2.SelectedValue = userInfo.Department.Id.ToString();

        Image1.ImageUrl = userInfo.Picture;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserInfo userInfo = UserInfoManager.GetAllUserById(uId);

        if (uId > 0)
        {
            userInfo.Name = this.txtName.Text.Trim();
            userInfo.IdentityCard = this.txtIDcard.Text.Trim();
            userInfo.Department.Id = Convert.ToInt32(this.DropDownList2.SelectedValue);

            userInfo.Sex = rdoSex.SelectedValue;
            userInfo.Address = this.txtAddress.Text.Trim();
            userInfo.Age = Convert.ToInt32(this.txtAge.Text.Trim());
            userInfo.MobilePhone = Convert.ToInt32(this.txtphone.Text.Trim());
            userInfo.HomePhone = this.txtseat.Text.Trim();
            userInfo.Qq = Convert.ToInt32(this.txtQQ.Text.Trim());
            userInfo.Email = this.txtEmail.Text.Trim();
            userInfo.Msn = this.txtMSN.Text.Trim();
            userInfo.Remark = this.TextBox14.Text.Trim();
            userInfo.Picture = Image1.ImageUrl;
            string FileName = System.IO.Path.GetFileName(fileUpload.PostedFile.FileName).ToLower();
            if (!string.IsNullOrEmpty(FileName))
            {
                fileUpload.PostedFile.SaveAs(Server.MapPath("~/images/UpLoad/" + FileName));
                userInfo.Picture = "~/images/UpLoad/" + FileName;
                UserInfoManager.UpdateUserInfo(userInfo);
            }
            else
            {
                userInfo.Picture = "";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新成功！');</script>");

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新失败！');</script>");

        }
    }
}
