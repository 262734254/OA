using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tunnel.DAL;
using Tunnel.Data;

namespace Tunnel.DAL
{
    public class Tunnel_InfoType
    {
        public Tunnel_InfoType()
        {
        }

        #region 获取集合
        /// <summary>
        /// 获得集合
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>集合</returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AutoID,HeadID,ItemName,url,IsDelete ");
            strSql.Append(" FROM Tunnel_InfoType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
    }
}
