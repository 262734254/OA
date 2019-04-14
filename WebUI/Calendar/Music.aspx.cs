using System;
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

public partial class rrrrr : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(rrrrr));//将本类的类型注册到ajaxPro中 好在js中调用该类的方法
        
    }


    [AjaxPro.AjaxMethod]//自定义ajaxpro方法  
    public string UpdataTommowerTime()
    {
        //获取日程Id 根据日程ID更新为明天这个时候
          


        return "1";

    }

}
