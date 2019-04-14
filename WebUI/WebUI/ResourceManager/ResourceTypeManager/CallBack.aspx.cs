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
using BLL.Resource;
using System.Collections.Generic;

public partial class CallBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Response.Redirect("UseList.aspx");
        }
    }
    protected void txtBorrowNo_TextChanged(object sender, EventArgs e)
    {
        
    }
}
