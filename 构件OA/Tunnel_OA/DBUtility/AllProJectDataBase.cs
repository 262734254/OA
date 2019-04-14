using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tunnel.Data
{
    public class AllProJectDataBase
    {
        private string ConnectionString = PubConstant.ConnectionString;
        private DbHelperSQLP DbHelper;
        public AllProJectDataBase(string ProjectId)
        {
            ConnectionString = "server=192.168.18.2;database=ProJect" + ProjectId + ";uid=sa;pwd=yuxit2008;Persist Security Info=True";
            DbHelper = new DbHelperSQLP(ConnectionString);
        }

        /// <summary>
        /// 查询指定数据库内的表
        /// </summary>
        /// <param name="TableName">表</param>
        /// <param name="Where">条件</param>
        /// <param name="Order">排序条件</param>
        /// <returns></returns>
        public DataTable GetAllTableList(string TableName, string Where, string Order)
        {
            return DbHelper.Query("Select * From " + TableName + " Where " + Where + " " + Order).Tables[0];
        }
    }
}
