using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tunnel.Common
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class Del_File
    {
        public Del_File(){}

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="path">目录路径</param>
        private void DelDictionary(string path)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(path);
                if (info.Exists)
                {
                    info.Delete();
                }
            }
            catch (System.IO.IOException iex)
            {
                throw iex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path">文件路径</param>
        private void DelFiles(string path)
        {
            try
            {
                FileInfo file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("../")+path);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="files">多文件字符串</param>
        /// <returns>否成功</returns>
        public bool FileDelete(string files)
        {
            try
            {
                string[] filepath = files.Split(',');
                foreach (string file in filepath)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        this.DelFiles(file);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
