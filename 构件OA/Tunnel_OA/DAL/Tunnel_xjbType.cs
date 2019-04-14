using System;
using System.Collections.Generic;
using System.Text;
using Tunnel.Model;
using System.Data;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
    public class Tunnel_xjbType
    {
        #region 新增一条数据
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="produce">实体集</param>
        /// <returns>新增结果</returns>
        public int Add(Tunnel.Model.Tunnel_xjbType xjbType)
        {
            string strSQL = string.Format("INSERT INTO Tunnel_xjbType (typename,typeid,parentid,url,IsStop,UserID) "
                        + "VALUES ('{0}','{1}','{2}','{3}','{4}',{5})", xjbType.Typename, xjbType.Typeid, xjbType.Parentid, xjbType.Url,xjbType.IsStop,xjbType.UserID);
            object obj = DbHelperSQL.ExecuteSql(strSQL);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="produce">产品实体集</param>
        /// <returns>修改结果</returns>
        public int Update(Tunnel.Model.Tunnel_xjbType xjbType)
        {
            string strSQL = string.Format("UPDATE Tunnel_xjbType SET typename='{1}',IsStop='{2}',UserID={3} WHERE id={0}",
                        +xjbType.Id,xjbType.Typename,xjbType.IsStop,xjbType.UserID);
            object obj = DbHelperSQL.ExecuteSql(strSQL);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion


        /// <summary>
        /// 获取项经部信息类型数据集
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetList(string where)
        {
            DataSet das = new DataSet();
            string strsql = "select * from tunnel_xjbtype";
            if (!where.Trim().Equals(""))
                where = " where 1=1 and " + where;
            else
                where = "";
            strsql += where;
            das = Tunnel.Data.DbHelperSQL.Query(strsql);
            return das;
        }

        #region 获得分页集合
        /// <summary>
        /// 获得分页集合
        /// </summary>
        /// <param name="pb">页类</param>
        /// <param name="count">总数</param>
        /// <returns>集合</returns>
        public DataSet GetList(Tunnel.Model.PageBase pb, ref int count)
        {
            SqlParameter[] parameters = 
            {
                new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 255),
                new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
            };
            parameters[0].Value = pb.TblName;
            parameters[1].Value = pb.StrGetFields;
            parameters[2].Value = pb.FldName;
            parameters[3].Value = pb.PageSize;
            parameters[4].Value = pb.PageIndex;
            parameters[5].Value = pb.DoCount;
            parameters[6].Value = pb.OrderType;
            parameters[7].Value = pb.StrWhere;

            DataSet ds = new DataSet();
            ds = DbHelperSQL.RunProcedure(pb.ProcedureName, parameters, "ds");
            if (pb.DoCount == 1)
            {
                if (ds.Tables.Count == 1)
                    count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }

            return ds;
        }
        #endregion
    }
}
