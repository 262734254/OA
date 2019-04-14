using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SystemManage_BaseData_Flow_UserSelect : System.Web.UI.Page
{
    public string title = "联系人";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["titles"] != null)
        {
            int i = Convert.ToInt32(Request.QueryString["titles"]);
            switch (i)
            {
                case 0:
                    title = "请选择收件人";
                    break;
                case 1:
                    title = "请选择经办人";
                    break;
            }


        }
    }
}
