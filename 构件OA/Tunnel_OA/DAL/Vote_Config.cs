using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Vote_Config。
	/// </summary>
	public class Vote_Config
	{
		public Vote_Config()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("c_id", "Vote_Config"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int c_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4)};
			parameters[0].Value = c_id;

			int result= DbHelperSQL.RunProcedure("UP_Vote_Config_Exists",parameters,out rowsAffected);
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
		public void Add(Tunnel.Model.Vote_Config model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4),
					new SqlParameter("@c_name", SqlDbType.NVarChar,50),
					new SqlParameter("@c_type", SqlDbType.Int,4)};
			parameters[0].Value = model.c_id;
			parameters[1].Value = model.c_name;
			parameters[2].Value = model.c_type;

			DbHelperSQL.RunProcedure("UP_Vote_Config_ADD",parameters,out rowsAffected);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Vote_Config model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4),
					new SqlParameter("@c_name", SqlDbType.NVarChar,50),
					new SqlParameter("@c_type", SqlDbType.Int,4)};
			parameters[0].Value = model.c_id;
			parameters[1].Value = model.c_name;
			parameters[2].Value = model.c_type;

			DbHelperSQL.RunProcedure("UP_Vote_Config_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int c_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4)};
			parameters[0].Value = c_id;

			DbHelperSQL.RunProcedure("UP_Vote_Config_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Vote_Config GetModel(int c_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4)};
			parameters[0].Value = c_id;

			Tunnel.Model.Vote_Config model=new Tunnel.Model.Vote_Config();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Vote_Config_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["c_id"].ToString()!="")
				{
					model.c_id=int.Parse(ds.Tables[0].Rows[0]["c_id"].ToString());
				}
				model.c_name=ds.Tables[0].Rows[0]["c_name"].ToString();
				if(ds.Tables[0].Rows[0]["c_type"].ToString()!="")
				{
					model.c_type=int.Parse(ds.Tables[0].Rows[0]["c_type"].ToString());
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
			strSql.Append("select c_id,c_name,c_type ");
			strSql.Append(" FROM Vote_Config ");
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
			strSql.Append(" c_id,c_name,c_type ");
			strSql.Append(" FROM Vote_Config ");
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
			parameters[0].Value = "Vote_Config";
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

