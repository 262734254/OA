using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_jiaose。
	/// </summary>
	public class Tunnel_jiaose
	{
		public Tunnel_jiaose()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long j_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@j_id", SqlDbType.BigInt)};
			parameters[0].Value = j_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_jiaose_Exists",parameters,out rowsAffected);
			if(result==1)
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
		public int Add(Tunnel.Model.Tunnel_jiaose model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@j_id", SqlDbType.Int,8),
					new SqlParameter("@j_name", SqlDbType.VarChar,100),
					new SqlParameter("@j_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@j_flag", SqlDbType.VarChar,2000),
					new SqlParameter("@j_zdyjs", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.j_name;
			parameters[2].Value = model.j_depict;
			parameters[3].Value = model.j_flag;
			parameters[4].Value = model.j_zdyjs;

			DbHelperSQL.RunProcedure("Tunnel_jiaose_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
        public void Update(Tunnel.Model.Tunnel_jiaose model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@j_id", SqlDbType.BigInt,8),
					new SqlParameter("@j_name", SqlDbType.VarChar,100),
					new SqlParameter("@j_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@j_flag", SqlDbType.VarChar,2000),
					new SqlParameter("@j_zdyjs", SqlDbType.Int,4)};
			parameters[0].Value = model.j_id;
			parameters[1].Value = model.j_name;
			parameters[2].Value = model.j_depict;
			parameters[3].Value = model.j_flag;
			parameters[4].Value = model.j_zdyjs;

			DbHelperSQL.RunProcedure("Tunnel_jiaose_Update",parameters,out rowsAffected);
		}

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int UpdateSort(int id,int sort)
        {
            string strSQL = string.Format("UPDATE Tunnel_jiaose SET JSSort={1} WHERE j_id={0}",id,sort);
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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long j_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@j_id", SqlDbType.BigInt)};
			parameters[0].Value = j_id;

			DbHelperSQL.RunProcedure("Tunnel_jiaose_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_jiaose GetModel(long j_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@j_id", SqlDbType.BigInt)};
			parameters[0].Value = j_id;

            Tunnel.Model.Tunnel_jiaose model = new Tunnel.Model.Tunnel_jiaose();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_jiaose_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["j_id"].ToString()!="")
				{
					model.j_id=long.Parse(ds.Tables[0].Rows[0]["j_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["j_name"].ToString()!="")
				{
					model.j_name=ds.Tables[0].Rows[0]["j_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["j_depict"].ToString()!="")
				{
					model.j_depict=ds.Tables[0].Rows[0]["j_depict"].ToString();
				}
				model.j_flag=ds.Tables[0].Rows[0]["j_flag"].ToString();
				if(ds.Tables[0].Rows[0]["j_zdyjs"].ToString()!="")
				{
					model.j_zdyjs=int.Parse(ds.Tables[0].Rows[0]["j_zdyjs"].ToString());
				}
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select j_id,j_name,j_depict,j_flag,j_zdyjs ");
			strSql.Append(" FROM Tunnel_jiaose ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" j_id,j_name,j_depict,j_flag,j_zdyjs ");
			strSql.Append(" FROM Tunnel_jiaose ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "Tunnel_jiaose";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("GetRecordByPage",parameters,"ds");
		}*/

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

		#endregion  成员方法
	}
}

