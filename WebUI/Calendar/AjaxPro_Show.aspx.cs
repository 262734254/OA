using System;

using System.Data;

using System.Configuration;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;


public partial class AjaxPro_Show : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxPro_Show));//将本类的类型注册到ajaxPro中 好在js中调用该类的方法
        
    }


    [AjaxPro.AjaxMethod]//自定义ajaxpro方法
    public String GetServerTime()
    {

        return DateTime.Now.ToString();

    }



    [AjaxPro.AjaxMethod]
    public int AddTwo(int firstInt, int secondInt)
    {

        return firstInt + secondInt;

    }

}
