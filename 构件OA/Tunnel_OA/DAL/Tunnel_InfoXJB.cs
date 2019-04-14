using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using System.Data;
using Tunnel.Model;

namespace Tunnel.DAL
{
    public class Tunnel_InfoXJB
    {
        public Tunnel_InfoXJB()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "Tunnel_InfoXJB");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int result = DbHelperSQL.RunProcedure("Tunnel_InfoXJB_Exists", parameters, out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_InfoXJB model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@imagePaht", SqlDbType.VarChar,100),
					new SqlParameter("@htmlSource", SqlDbType.Text),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@files", SqlDbType.VarChar,500),
                    new SqlParameter("@bum_bz",SqlDbType.Int,4),
                    new SqlParameter("@sectype",SqlDbType.Int,4),
                    new SqlParameter("@filename",SqlDbType.VarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.ImagePaht;
            parameters[5].Value = model.HtmlSource;
            parameters[6].Value = model.UserId;
            parameters[7].Value = model.Files;
            parameters[8].Value = model.Bum_bz;
            parameters[9].Value = model.Sectype;
            parameters[10].Value = model.Filename;
            DbHelperSQL.RunProcedure("Tunnel_InfoXJB_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_InfoXJB model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@imagePaht", SqlDbType.VarChar,100),
					new SqlParameter("@htmlSource", SqlDbType.Text),
					new SqlParameter("@modiDate", SqlDbType.DateTime),
					new SqlParameter("@modiUser", SqlDbType.Int,4),
					new SqlParameter("@files", SqlDbType.VarChar,500),
                    new SqlParameter("@sectype",SqlDbType.Int,4),
                    new SqlParameter("@filename",SqlDbType.VarChar,500)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.ImagePaht;
            parameters[5].Value = model.HtmlSource;
            parameters[6].Value = model.ModiDate;
            parameters[7].Value = model.ModiUser;
            parameters[8].Value = model.Files;
            parameters[9].Value = model.Sectype;
            parameters[10].Value = model.Filename;
            DbHelperSQL.RunProcedure("Tunnel_InfoXJB_Update", parameters, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
                    new SqlParameter("@delUser",SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.RunProcedure("Tunnel_InfoXJB_Delete", parameters, out rowsAffected);
            return 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_InfoXJB GetModel(int id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Tunnel.Model.Tunnel_InfoXJB model = new Tunnel.Model.Tunnel_InfoXJB();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_InfoXJB_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(ds.Tables[0].Rows[0]["typeId"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["content"].ToString();
                model.ImagePaht = ds.Tables[0].Rows[0]["imagePaht"].ToString();
                model.HtmlSource = ds.Tables[0].Rows[0]["htmlSource"].ToString();
                if (ds.Tables[0].Rows[0]["setDate"].ToString() != "")
                {
                    model.SetDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["setDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["userId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["modiUser"].ToString().Trim() != "")
                    model.ModiUser = int.Parse(ds.Tables[0].Rows[0]["modiUser"].ToString().Trim());
                if (ds.Tables[0].Rows[0]["modiDate"].ToString().Trim()!="")
                    model.ModiDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["modiDate"].ToString().Trim());
                if (ds.Tables[0].Rows[0]["delUser"].ToString().Trim() != "")
                    model.DelUser = int.Parse(ds.Tables[0].Rows[0]["delUser"].ToString().Trim());
                if (ds.Tables[0].Rows[0]["delDate"].ToString().Trim()!="")
                    model.DelDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["delDate"].ToString().Trim());
                model.Files = ds.Tables[0].Rows[0]["files"].ToString();
                model.Sectype = Convert.ToInt32(ds.Tables[0].Rows[0]["sectype"].ToString());
                model.Filename = ds.Tables[0].Rows[0]["filename"].ToString();

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
            strSql.Append("select id,typeId,sectype,title,content,imagePaht,htmlSource,setDate,userId,modiUser,modiDate,delUser,delDate,files,filename ");
            strSql.Append(" FROM Tunnel_InfoXJB ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" id,typeId,sectype,title,content,imagePaht,htmlSource,setDate,userId,modiUser,modiDate,delUser,delDate,files,filename ");
            strSql.Append(" FROM Tunnel_InfoXJB ");
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
                new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.NVarChar, 255),
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
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总条数</param>
        /// <returns></returns>
        public DataSet GetList2(PageBase pb, ref int count)
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
        /// <summary>
        ///  增加一条数据

        /// </summary>
        public int Add(Tunnel.Model.Tunnel_viewTable model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,8),
					new SqlParameter("@objId", SqlDbType.Int,8),
                    new SqlParameter("@typeId", SqlDbType.Int,8),
					new SqlParameter("@content", SqlDbType.VarChar,800),
					new SqlParameter("@userId", SqlDbType.Int,8),
                    
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.ObjId;
            parameters[2].Value = model.TypeId;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.UserId;

            DbHelperSQL.RunProcedure("UP_ViewTable_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }
        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Tunnel_Index";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}
