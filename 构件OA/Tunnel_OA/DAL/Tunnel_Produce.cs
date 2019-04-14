using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;

namespace Tunnel.DAL
{
    public class Tunnel_Produce
    {
        public Tunnel_Produce()
        {
        }

        #region 新增一条数据
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="produce">实体集</param>
        /// <returns>新增结果</returns>
        public int Add(Tunnel.Model.Tunnel_Produce produce)
        {
            string strSQL = string.Format("INSERT INTO Tunnel_Produce (ProType,ProTitle,ProName,ProSrc,CreateDate,CreateUser,ProState) "
                        + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", produce.ProType,produce.ProTitle, produce.ProName, produce.ProSrc, produce.CreateDate, produce.CreateUser, produce.ProState);
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
        public int Update(Tunnel.Model.Tunnel_Produce produce)
        {
            string strSQL = string.Format("UPDATE Tunnel_Produce SET ProName='{1}',ModiDate='{2}',ModiUser={3} WHERE ProID={0} AND ProState='N'",
                        + produce.ProID, produce.ProName,produce.ModiDate,produce.ModiUser);
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

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="proID">产品编号</param>
        /// <param name="userID">操作者</param>
        /// <returns>删除结果</returns>
        public int Delete(int proID,int userID)
        {
            string strSQL = string.Format("UPDATE Tunnel_Produce SET ProState='Y',DeleteDate='{1}',DeleteUser='{2}' WHERE ProID='{0}'", proID,DateTime.Now,userID);
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

        #region 获得产品集合
        /// <summary>
        /// 获得产品集合
        /// </summary>
        /// <param name="proType">产品类型</param>
        /// <returns>产品集合</returns>
        public DataSet GetProduceData(string proType)
        {
            string strSQL = string.Format("SELECT * FROM Tunnel_Produce WHERE ProType='{0}' AND ProState!='Y'", proType);
            return DbHelperSQL.Query(strSQL);
        }
        #endregion

        #region 获得产品集合
        /// <summary>
        /// 获得产品集合
        /// </summary>
        /// <param name="proType">产品类型</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>产品集合</returns>
        public DataSet GetProduceData(string proType,string strWhere)
        {
            string strSQL = string.Format("SELECT * FROM Tunnel_Produce WHERE ProType='{0}' AND ProState!='Y' AND {1}", proType,strWhere);
            return DbHelperSQL.Query(strSQL);
        }
        #endregion

        #region 获取产品实体集
        /// <summary>
        /// 获得产品实体集
        /// </summary>
        /// <param name="proID">产品编号</param>
        /// <returns>产品实体集</returns>
        public Tunnel.Model.Tunnel_Produce GetProduceModel(int proID)
        {
            Tunnel.Model.Tunnel_Produce produce = new Tunnel.Model.Tunnel_Produce();
            string strSQL = string.Format("SELECT ProID,ProType,ProTitle,ProName,ProSrc FROM Tunnel_Produce WHERE ProID={0}", proID);
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSQL))
            {
                if (reader.Read())
                {
                    produce.ProID = Convert.ToInt32(reader["ProID"]);
                    produce.ProType = reader["ProType"].ToString().Trim();
                    produce.ProTitle = reader["ProType"].ToString().Trim();
                    produce.ProName = reader["ProName"].ToString().Trim();
                    produce.ProSrc = reader["ProSrc"].ToString().Trim();
                }
            }
            return produce;
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
