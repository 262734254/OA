using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_work。
	/// </summary>
	public class Tunnel_work
	{
		public Tunnel_work()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("w_id", "Tunnel_work"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int w_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.Int,4)};
			parameters[0].Value = w_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_work_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_work model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.Int,4),
					new SqlParameter("@w_bumName", SqlDbType.VarChar,50),
					new SqlParameter("@w_maxCent", SqlDbType.Int,4),
					new SqlParameter("@w_workName", SqlDbType.VarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.w_bumName;
			parameters[2].Value = model.w_maxCent;
			parameters[3].Value = model.w_workName;

			DbHelperSQL.RunProcedure("UP_Tunnel_work_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_work model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.Int,4),
					new SqlParameter("@w_bumName", SqlDbType.VarChar,50),
					new SqlParameter("@w_maxCent", SqlDbType.Int,4),
					new SqlParameter("@w_workName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.w_id;
			parameters[1].Value = model.w_bumName;
			parameters[2].Value = model.w_maxCent;
			parameters[3].Value = model.w_workName;

			DbHelperSQL.RunProcedure("UP_Tunnel_work_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int w_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.Int,4)};
			parameters[0].Value = w_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_work_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_work GetModel(int w_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.Int,4)};
			parameters[0].Value = w_id;

			Tunnel.Model.Tunnel_work model=new Tunnel.Model.Tunnel_work();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_work_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["w_id"].ToString()!="")
				{
					model.w_id=int.Parse(ds.Tables[0].Rows[0]["w_id"].ToString());
				}
				model.w_bumName=ds.Tables[0].Rows[0]["w_bumName"].ToString();
				if(ds.Tables[0].Rows[0]["w_maxCent"].ToString()!="")
				{
					model.w_maxCent=int.Parse(ds.Tables[0].Rows[0]["w_maxCent"].ToString());
				}
				model.w_workName=ds.Tables[0].Rows[0]["w_workName"].ToString();
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
			strSql.Append("select w_id,w_bumName,w_maxCent,w_workName ");
			strSql.Append(" FROM Tunnel_work ");
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
			strSql.Append(" w_id,w_bumName,w_maxCent,w_workName ");
			strSql.Append(" FROM Tunnel_work ");
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
			parameters[0].Value = "Tunnel_work";
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

