<%@ WebHandler Language="C#" Class="updatemessage" %>

using System;
using System.Web;

public class updatemessage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int count = Tunnel.Common.GetValue.updatemessage(context.Request["mid"]);
        context.Response.Write(count);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}