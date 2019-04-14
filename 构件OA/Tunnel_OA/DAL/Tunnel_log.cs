using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_log。
	/// </summary>
	public class Tunnel_log
	{
		public Tunnel_log()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long l_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@l_id", SqlDbType.BigInt)};
			parameters[0].Value = l_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_log_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_log model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@l_id", SqlDbType.BigInt,8),
					new SqlParameter("@l_user", SqlDbType.Int,4),
					new SqlParameter("@l_content", SqlDbType.Text),
					new SqlParameter("@l_ip", SqlDbType.VarChar,50),
					new SqlParameter("@l_sort", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.l_user;
			parameters[2].Value = model.l_content;
			parameters[3].Value = model.l_ip;
			parameters[4].Value = model.l_sort;

			DbHelperSQL.RunProcedure("Tunnel_log_ADD",parameters,out rowsAffected);
			return Convert.ToInt32(parameters[0].Value);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_log model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@l_id", SqlDbType.BigInt,8),
					new SqlParameter("@l_user", SqlDbType.Int,4),
					new SqlParameter("@l_time", SqlDbType.DateTime),
					new SqlParameter("@l_content", SqlDbType.Text),
					new SqlParameter("@l_ip", SqlDbType.VarChar,50),
					new SqlParameter("@l_sort", SqlDbType.Int,4)};
			parameters[0].Value = model.l_id;
			parameters[1].Value = model.l_user;
			parameters[2].Value = model.l_time;
			parameters[3].Value = model.l_content;
			parameters[4].Value = model.l_ip;
			parameters[5].Value = model.l_sort;

			DbHelperSQL.RunProcedure("Tunnel_log_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long l_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@l_id", SqlDbType.BigInt)};
			parameters[0].Value = l_id;

			DbHelperSQL.RunProcedure("Tunnel_log_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_log GetModel(long l_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@l_id", SqlDbType.BigInt)};
			parameters[0].Value = l_id;

			Tunnel.Model.Tunnel_log model=new Tunnel.Model.Tunnel_log();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_log_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["l_id"].ToString()!="")
				{
					model.l_id=long.Parse(ds.Tables[0].Rows[0]["l_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["l_user"].ToString()!="")
				{
					model.l_user=int.Parse(ds.Tables[0].Rows[0]["l_user"].ToString());
				}
				if(ds.Tables[0].Rows[0]["l_time"].ToString()!="")
				{
					model.l_time=DateTime.Parse(ds.Tables[0].Rows[0]["l_time"].ToString());
				}
				model.l_content=ds.Tables[0].Rows[0]["l_content"].ToString();
				model.l_ip=ds.Tables[0].Rows[0]["l_ip"].ToString();
				if(ds.Tables[0].Rows[0]["l_sort"].ToString()!="")
				{
					model.l_sort=int.Parse(ds.Tables[0].Rows[0]["l_sort"].ToString());
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
			strSql.Append("select l_id,l_user,l_time,l_content,l_ip,l_sort ");
			strSql.Append(" FROM Tunnel_log ");
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
			strSql.Append(" l_id,l_user,l_time,l_content,l_ip,l_sort ");
			strSql.Append(" FROM Tunnel_log ");
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
			parameters[0].Value = "Tunnel_log";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

