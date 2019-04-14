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
using BLL.WorkHelper;
using Model;
public partial class Calendar_UpdateCalender : System.Web.UI.Page
{
    static int id;
    static int sid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Id"].ToString()))
            {
                sid = Convert.ToInt32(Request.QueryString["Id"]);
                Bind();
            }
        }
    }
    private void Bind()
    {
        Model.Calendar calendar = BLL.WorkHelper.CalendarManager.GetAllCalendarByID(sid);
        id = calendar.UId.UID;
        this.txtTime.Value = Convert.ToString(calendar.TransactTime);
        this.txtJackTime.Value = Convert.ToString(calendar.RemaindTime);
        if (calendar.Repeat.Trim() == "是")
        {
            this.rdoRepeat.SelectedValue = "是";
        }
        else
        {
            this.rdoRepeat.SelectedValue = "否";
        }
        this.droType.SelectedValue = calendar.CalType;
        this.txtTitle.Text = calendar.CalTheme;
        this.txDes.Value = calendar.CalContent;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Model.Calendar calendar = BLL.WorkHelper.CalendarManager.GetAllCalendarByID(Id);
        Model.Calendar calendar = new Model.Calendar();
        if (id > 0)
        {
            calendar.Id = sid;
            calendar.UId.UID = id;
            calendar.TransactTime =Convert.ToDateTime(this.txtTime.Value);
            calendar.RemaindTime = Convert.ToDateTime(this.txtJackTime.Value);
            calendar.Repeat = this.rdoRepeat.SelectedValue;
            calendar.CalType = this.droType.SelectedValue;
            calendar.CalTheme = this.txtTitle.Text;
            calendar.CalContent = this.txDes.Value;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新成功！');</script>");

            BLL.WorkHelper.CalendarManager.GetCalendarById(calendar);

            Response.Redirect("SelectCalender.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新失败！');</script>");

        }
    }
}
