<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data.SqlClient;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        if (context.Request.QueryString["UserName"] != null)
        {
            string TmpName = context.Request.QueryString["UserName"].ToString();
            context.Response.Write(CheckName(TmpName));
        }
        else
        {
            context.Response.Write("no");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    public string CheckName(string Name)
    {
        string tmp = string.Empty;

        Tunnel.BLL.Tunnel_menber tm = new Tunnel.BLL.Tunnel_menber();
        Tunnel.Model.Tunnel_menber tmm = new Tunnel.Model.Tunnel_menber();

        if(tm.GetModelList("m_login='"+Name+"'").Count==0)

            {
                tmp = "no";
            }
            else
            {
                tmp = "yes";
            }
        return tmp;
        }
        

    }
