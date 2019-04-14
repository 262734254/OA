using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Collections;

namespace Tunnel.BLL
{
    public class HttpModule : IHttpModule
    {

        #region IHttpModule 成员

        public void Dispose()
        {

        }


   

        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(context_Error);
        }



        void context_Error(object sender, EventArgs e)
        {
            HttpApplication ap = sender as HttpApplication;
            Exception ex = ap.Server.GetLastError();
            if (ex is HttpException)
            {
                HttpException hx = (HttpException)ex;
                if (hx.GetHttpCode() == 404)
                {
                    HttpContext.Current.Response.Write("<script>alert('" + hx.Message + "')</script>");
                    //HttpContext.Current.Response.Redirect("http://www.stec-oa.com/");
                    return;
                }
            }
            else
            {
                throw ex;
            }
        }

        #endregion
    }
}
