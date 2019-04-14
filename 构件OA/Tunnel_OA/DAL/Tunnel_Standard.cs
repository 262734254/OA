using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;
using System.Data;

namespace Tunnel.DAL
{
  public  class Tunnel_Standard
    {
        #region 标准规范数据访问类
        /// <summary> 
        ///  增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_Standard model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,8),
                     new SqlParameter("@S_File", SqlDbType.VarChar,200),
                    new SqlParameter("@S_Title", SqlDbType.VarChar,200),
                    new SqlParameter("@S_Name", SqlDbType.VarChar,100),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.Int,4),
                    new SqlParameter("@S_bum", SqlDbType.Int,4),

                   
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.S_File;
            parameters[2].Value = model.S_Title;
            parameters[3].Value = model.S_Name;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.CreateUser;
            parameters[6].Value = model.S_bum;

            DbHelperSQL.RunProcedure("UP_Tunnel_Standard_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,S_File,S_Title,S_Name,CreateDate,CreateUser,S_bum ");
            strSql.Append(" FROM Tunnel_Standard ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tunnel_Standard ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,S_File,S_Title,S_Name,CreateDate,CreateUser,S_bum ");
            strSql.Append(" FROM Tunnel_Standard ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总条数</param>
        /// <returns></returns>
        public DataSet GetList(PageBase pb, ref int count)
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_Standard GetModel(int Id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int)};
            parameters[0].Value = Id;

            Tunnel.Model.Tunnel_Standard model = new Tunnel.Model.Tunnel_Standard();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_Standard_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.S_File = ds.Tables[0].Rows[0]["S_File"].ToString();
                model.S_Title = ds.Tables[0].Rows[0]["S_Title"].ToString();
                model.S_Name = ds.Tables[0].Rows[0]["S_Name"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateUser"].ToString() != "")
                {
                    model.CreateUser = int.Parse(ds.Tables[0].Rows[0]["CreateUser"].ToString());
                }
                if (ds.Tables[0].Rows[0]["S_bum"].ToString() != "")
                {
                    model.S_bum = int.Parse(ds.Tables[0].Rows[0]["S_bum"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        
        #endregion
    }
}
