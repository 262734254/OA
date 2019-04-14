using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Common
{
    public class CommHelper
    {

        //获取gridView每页显示的行数
        private static int pageCount;

        public static int GetPageCount
        {
            get
            {
                pageCount = Convert.ToInt32(ConfigurationManager.AppSettings["pageCount"].ToString());
                return pageCount;
            }
        }
    }
}
