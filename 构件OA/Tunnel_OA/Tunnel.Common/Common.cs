using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tunnel.Common
{
    /// <summary>
    /// 公共方法类
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int CreateMd(string path)
        {
            int relt = 0;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                if (!Directory.Exists(path))
                    relt = -1;
            }
            return relt;
        }

        /// <summary>
        /// 获取Ip地址
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string user_IP;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                user_IP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                user_IP = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }

        /// <summary>
        /// 根据制定长度截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="len">长度</param>
        /// <returns>截取后字符串</returns>
        public static string SubStr(object o, int len)
        {
            string str = "";
            if (o != null)
            {
                str = o.ToString();
            }
            else
            {
                return "";
            }
            string result = "";
            char[] arrchar=str.ToCharArray();
            int i=0;
            if (str.Length > 0)
            {
                if (arrchar[0] > 0 && arrchar[0] < 128)
                    i = 1;
                else
                    i = 2;
                if (str.Length > 1)
                {
                    for (int j = 1; i <= len; j++)
                    {
                        if (j <= str.Length)
                        {
                            if (j < arrchar.Length)
                            {
                                if (arrchar[j] > 0 && arrchar[j] < 128)
                                    i++;
                                else
                                    i += 2;
                            }
                            else
                            {
                                i += 2;
                            }
                            result += arrchar[j - 1].ToString();
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (str.Length > result.Length)
                        result += "..";
                }
                else
                    result = str;
            }
            return result;

        }
    }
}
