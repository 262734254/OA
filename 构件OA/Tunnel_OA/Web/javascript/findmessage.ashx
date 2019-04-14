<%@ WebHandler Language="C#" Class="findmessage" %>

using System;
using System.Web;
public class findmessage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int count = Tunnel.Common.GetValue.getmessage(context.Request["Uid"]);
        context.Response.Write(count);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}