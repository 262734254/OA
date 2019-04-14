using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用

namespace Tunnel.DAL
{
     class SelType
    {
    }
    public class Tunnel_SelType
    {
        public Tunnel_SelType()
        { }

        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long TypeID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.BigInt)};
            parameters[0].Value = TypeID;

            int result = DbHelperSQL.RunProcedure("Tunnel_SelType_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据

        /// </summary>
        public int Add(Tunnel.Model.Tunnel_SelType model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@BumID", SqlDbType.VarChar,50),
					new SqlParameter("@BumName", SqlDbType.VarChar,50),
                    new SqlParameter("@BumUrl", SqlDbType.VarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Int,4)
                    
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.BumID;
            parameters[3].Value = model.BumName;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.ParentID;
            parameters[6].Value = model.IsDel;

            DbHelperSQL.RunProcedure("Tunnel_SelType_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_SelType model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@BumID", SqlDbType.VarChar,50),
					new SqlParameter("@BumName", SqlDbType.VarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@i_idout", SqlDbType.Int,4)
                    
            };
            parameters[0].Value = model.TypeID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.BumID;
            parameters[3].Value = model.BumName;
            parameters[4].Value = model.ParentID;
            parameters[5].Value = model.IsDel;
            parameters[6].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("Tunnel_SelType_Update", parameters, out rowsAffected);
            return (int)parameters[6].Value;
        }

        /// <summary>
        /// 删除一条数据

        /// </summary>
        public int Delete(int typeID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int)
            
            };
            parameters[0].Value = typeID;

            return DbHelperSQL.RunProcedure("Tunnel_SelType_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_SelType GetModel(int TypeID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int)};
            parameters[0].Value = TypeID;

            Tunnel.Model.Tunnel_SelType model = new Tunnel.Model.Tunnel_SelType();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_SelType_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                model.BumID = ds.Tables[0].Rows[0]["BumID"].ToString();
                model.BumName= ds.Tables[0].Rows[0]["BumName"].ToString();
                model.Url = ds.Tables[0].Rows[0]["BumUrl"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString().Trim());
                model.KSID = int.Parse(ds.Tables[0].Rows[0]["KSID"].ToString().Trim());
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TypeID,TypeName,BumName,BumID,ParentID,KSID ");
            strSql.Append(" FROM Tunnel_NewsType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
                new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 255),
                new SqlParameter("@fldName", SqlDbType.NVarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.NVarChar,2000),
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
