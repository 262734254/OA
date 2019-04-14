<%@ WebHandler Language="C#" Class="getChatList" %>

using System;
using System.Web;

public class getChatList : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string list = Tunnel.Common.GetValue.getChat(context.Request["Uid"]);
        context.Response.Write(list);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}