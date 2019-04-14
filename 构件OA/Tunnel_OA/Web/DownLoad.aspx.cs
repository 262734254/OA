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

public partial class DownLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (null == Request["url"] || "".Equals(Request["url"]))
        {
            Tunnel.Common.Message.back("文件地址不存在！");
        }
        else
        {
            try
            {
                Tunnel.Common.DownFile downfile = new Tunnel.Common.DownFile();
                downfile.downloadfile(Request.QueryString["url"]);
            }
            catch
            {
                Tunnel.Common.Message.back("文件地址不存在！");
            }
        }
    }
}
