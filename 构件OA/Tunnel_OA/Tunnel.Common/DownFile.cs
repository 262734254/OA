using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Tunnel.Common
{
    public class DownFile
    {
        public DownFile() { }

        public void downloadfile(string URL)
        {

            string fileName = GetValue.getfu(URL);//客户端保存的文件名 

            string filePath = System.Web.HttpContext.Current.Server.MapPath("./") + URL;//路径

            //以字符流的形式下载文件 

            FileStream fs = new FileStream(filePath, FileMode.Open);

            byte[] bytes = new byte[(int)fs.Length];

            fs.Read(bytes, 0, bytes.Length);

            fs.Close();

            System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";

            //通知浏览器下载文件而不是打开 

            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));

            System.Web.HttpContext.Current.Response.BinaryWrite(bytes);

            System.Web.HttpContext.Current.Response.Flush();

            System.Web.HttpContext.Current.Response.End();

        }
    }
}
