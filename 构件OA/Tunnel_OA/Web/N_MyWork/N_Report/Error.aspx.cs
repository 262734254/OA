using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class N_MyWork_N_Report_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        label1.InnerText = (Request.QueryString["id"]);
    }
}
