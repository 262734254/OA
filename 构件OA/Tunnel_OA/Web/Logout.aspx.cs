using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Threading;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FormsAuthentication.SignOut();
            Tunnel.BLL.UserLogin ul = new Tunnel.BLL.UserLogin();
            Tunnel.Common.GetValue.OffLine(ul.LoginID);
            ul.RemoveCache(ul.LoginID);
           
            // Cache.Remove(".TunnelLogin-CacheKey-" + ul.LoginID);

            //#region 为了看到脚本调用的时候改文件已经被执行 测试用;
            //string tempFilePaht = @"d:\test1.txt";
            //if (!System.IO.File.Exists(tempFilePaht))
            //{
            //    System.IO.FileStream f = System.IO.File.Create(tempFilePaht);
            //    f.Close();
            //    f.Dispose();
            //}

            //System.IO.StreamWriter f2 = new System.IO.StreamWriter(tempFilePaht, true, System.Text.Encoding.GetEncoding("gb2312"));
            //string Strings = "|" + ul.LoginID + "|";
            //f2.WriteLine(Strings);
            //f2.Close();
            //#endregion
            Thread.Sleep(5000);
            Response.Write("<script>window.close();</script>");
        }
    }
}
