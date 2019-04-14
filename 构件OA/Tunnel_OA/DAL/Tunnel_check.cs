using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_check。
	/// </summary>
	public class Tunnel_check
	{
		public Tunnel_check()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("c_id", "Tunnel_check"); 
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

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_check_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_check model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4),
					new SqlParameter("@c_userId", SqlDbType.Int,4),
					new SqlParameter("@c_itemsId", SqlDbType.Int,4),
					new SqlParameter("@c_score", SqlDbType.Int,4),
					new SqlParameter("@c_income", SqlDbType.VarChar,50),
					new SqlParameter("@c_date", SqlDbType.VarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.c_userId;
			parameters[2].Value = model.c_itemsId;
			parameters[3].Value = model.c_score;
			parameters[4].Value = model.c_income;
			parameters[5].Value = model.c_date;

			DbHelperSQL.RunProcedure("UP_Tunnel_check_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_check model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4),
					new SqlParameter("@c_userId", SqlDbType.Int,4),
					new SqlParameter("@c_itemsId", SqlDbType.Int,4),
					new SqlParameter("@c_score", SqlDbType.Int,4),
					new SqlParameter("@c_income", SqlDbType.VarChar,50),
					new SqlParameter("@c_date", SqlDbType.VarChar,50)};
			parameters[0].Value = model.c_id;
			parameters[1].Value = model.c_userId;
			parameters[2].Value = model.c_itemsId;
			parameters[3].Value = model.c_score;
			parameters[4].Value = model.c_income;
			parameters[5].Value = model.c_date;

			DbHelperSQL.RunProcedure("UP_Tunnel_check_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_Tunnel_check_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_check GetModel(int c_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.Int,4)};
			parameters[0].Value = c_id;

			Tunnel.Model.Tunnel_check model=new Tunnel.Model.Tunnel_check();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_check_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["c_id"].ToString()!="")
				{
					model.c_id=int.Parse(ds.Tables[0].Rows[0]["c_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["c_userId"].ToString()!="")
				{
					model.c_userId=int.Parse(ds.Tables[0].Rows[0]["c_userId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["c_itemsId"].ToString()!="")
				{
					model.c_itemsId=int.Parse(ds.Tables[0].Rows[0]["c_itemsId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["c_score"].ToString()!="")
				{
					model.c_score=int.Parse(ds.Tables[0].Rows[0]["c_score"].ToString());
				}

                model.c_income=ds.Tables[0].Rows[0]["c_income"].ToString();

				model.c_date=ds.Tables[0].Rows[0]["c_date"].ToString();
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
			strSql.Append("select c_id,c_userId,c_itemsId,c_score,c_income,c_date ");
			strSql.Append(" FROM Tunnel_check ");
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
			strSql.Append(" c_id,c_userId,c_itemsId,c_score,c_income,c_date ");
			strSql.Append(" FROM Tunnel_check ");
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
			parameters[0].Value = "Tunnel_check";
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

