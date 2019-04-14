using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tunnel.Model;
using Tunnel.Data;

namespace Tunnel.DAL
{
    public class Tunnel_FilesManage
    {

        #region 新增一条数据
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="files">实体集</param>
        /// <returns>新增结果</returns>
        public int Add(Tunnel.Model.Tunnel_FilesManage files)
        {
            string strSQL = string.Format("INSERT INTO Tunnel_FilesManage (F_Type,F_Title,F_Content,F_Name,F_URL,F_CreateUser,F_CreateDate,F_ModiUser,F_ModiDate,F_DelUser,F_DelDate) "
                        + "VALUES ('{0}','{1}','{2}','{3}','{4}',{5},'{6}',{7},'{8}',{9},'{10}')", 
                        files.F_Type,files.F_Title,files.F_Content,files.F_Name,files.F_URL,files.F_CreateUser,files.F_CreateDate,files.F_ModiUser,files.F_ModiDate,files.F_DelUser,files.F_DelDate);
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
        /// <param name="files">实体集</param>
        /// <returns>更新结果</returns>
        public int Update(Tunnel.Model.Tunnel_FilesManage files)
        {
            string strSQL = string.Format("UPDATE Tunnel_FilesManage SET F_Title='{1}',F_Content='{2}',F_Name='{3}',F_ModiUser={4},F_ModiDate='{5}' WHERE F_ID={0}",
                        files.F_ID,files.F_Title, files.F_Content, files.F_Name, files.F_ModiUser, files.F_ModiDate);
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
        /// <param name="fid">档案编号</param>
        /// <returns>删除结果</returns>
        public int Del(int fid,int userID)
        {
            string strSQL = string.Format("UPDATE Tunnel_FilesManage SET F_DelUser={1},F_DelDate='{2}' WHERE F_ID={0}",fid,userID,DateTime.Now);
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

        #region 获得档案集合
        /// <summary>
        /// 获得档案集合
        /// </summary>
        /// <param name="title">档案标题</param>
        /// <returns>档案集合</returns>
        public DataSet GetFilesManageData(string where)
        {
            string strSQL = string.Format("SELECT * FROM Tunnel_FilesManage WHERE {0}", where);
            return DbHelperSQL.Query(strSQL);
        }
        #endregion

        #region 获得档案Model
        /// <summary>
        /// 获得档案Model
        /// </summary>
        /// <param name="fid">档案编号</param>
        /// <returns>档案Model</returns>
        public Tunnel.Model.Tunnel_FilesManage GetFilesManageModel(int fid)
        {
            Tunnel.Model.Tunnel_FilesManage filesManage = new Tunnel.Model.Tunnel_FilesManage();
            string strSQL = string.Format("SELECT F_ID,F_Type,F_Title,F_Content,F_Name,F_URL,F_CreateUser,F_CreateDate FROM Tunnel_FilesManage WHERE F_ID={0}", fid);
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSQL))
            {
                if (reader.Read())
                {
                    filesManage.F_ID = Convert.ToInt32(reader["F_ID"]);
                    filesManage.F_Type = reader["F_Type"].ToString().Trim();
                    filesManage.F_Title = reader["F_Title"].ToString().Trim();
                    filesManage.F_Content = reader["F_Content"].ToString().Trim();
                    filesManage.F_Name = reader["F_Name"].ToString().Trim();
                    filesManage.F_URL = reader["F_URL"].ToString().Trim();
                    filesManage.F_CreateUser = Convert.ToInt32(reader["F_CreateUser"]);
                    filesManage.F_CreateDate = Convert.ToDateTime(reader["F_CreateDate"]);
                }
            }
            return filesManage;
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
