<%@ WebHandler Language="C#" Class="Get_XiangUser" %>

using System;
using System.Web;

public class Get_XiangUser : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string html = Tunnel.Common.GetValue.getXiangUser(context.Request["Uname"]);
        context.Response.Write(html);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}