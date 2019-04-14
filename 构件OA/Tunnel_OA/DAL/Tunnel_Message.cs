using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;

namespace Tunnel.DAL
{
    public class Tunnel_Message
    {
        public Tunnel_Message()
        {
        }

        #region 新增一条数据
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="message">实体集</param>
        /// <returns>新增结果</returns>
        public int Add(Tunnel.Model.Tunnel_Message message)
        {
            string strSQL = string.Format("INSERT INTO Tunnel_Message (MesTitle,MesContent,MesDate,MesUser) "
                        + "VALUES ('{0}','{1}','{2}','{3}')",message.MesTitle,message.MesContent,message.MesDate,message.MesUser);
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

        #region 更新数据
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="message">实体集</param>
        /// <returns>列新结果</returns>
        public int Update(Tunnel.Model.Tunnel_Message message)
        {
            string strSQL = string.Format("UPDATE Tunnel_Message SET MesTitle='{1}',MesContent='{2}',ModiDate='{3}' WHERE MesID={0}",message.MesID,message.MesTitle,message.MesContent,message.ModiDate);
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

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="mesID">信息编号</param>
        /// <returns>删除结果</returns>
        public int Delete(int mesID)
        {
            string strSQL = string.Format("UPDATE Tunnel_Message SET DelDate='{1}' WHERE MesID='{0}'", mesID, DateTime.Now);
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

        #region 获得信息实体集
        /// <summary>
        /// 获得信息实体集
        /// </summary>
        /// <param name="mesID">信息编号</param>
        /// <returns>信息实体集</returns>
        public Tunnel.Model.Tunnel_Message GetMessageModel(int mesID)
        {
            Tunnel.Model.Tunnel_Message mes = new Tunnel.Model.Tunnel_Message();
            string strSQL = string.Format("SELECT * FROM Tunnel_Message WHERE MesID={0}", mesID);
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSQL))
            {
                if (reader.Read())
                {
                    mes.MesID = Convert.ToInt32(reader["MesID"]);
                    mes.MesTitle = reader["MesTitle"].ToString();
                    mes.MesContent = reader["MesContent"].ToString();
                    mes.MesDate = Convert.ToDateTime(reader["MesDate"]);
                    mes.MesUser = Convert.ToInt32(reader["MesUser"]);
                }
            }
            return mes;
        }
        #endregion

        #region 获得信息集合
        /// <summary>
        /// 获得信息集合
        /// </summary>
        /// <param name="userID">信息编号</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>信息集合</returns>
        public DataSet GetMessageData(int userID,string strWhere)
        {
            string strSQL = string.Format("SELECT * FROM Tunnel_Message WHERE (DelDate is null OR DelDate='') AND MesUser={0} AND {1}", userID,strWhere);
            return DbHelperSQL.Query(strSQL);
        }
        #endregion

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
