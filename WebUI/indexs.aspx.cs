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
using ExtAspNet;
using System.Xml.Linq;

public partial class indexs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  //如果不是回传加载数据
        {
            // 加载菜单
            treeMenu.DataSource = XmlDataSource1;
            treeMenu.DataBind();

            
        }
    }
}
