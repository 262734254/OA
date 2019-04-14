using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Date_Sys。
	/// </summary>
	public class Date_Sys
	{
		public Date_Sys()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("d_Id", "Date_Sys"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int d_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_Id", SqlDbType.Int,4)};
			parameters[0].Value = d_Id;

			int result= DbHelperSQL.RunProcedure("UP_Date_Sys_Exists",parameters,out rowsAffected);
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
		public void Add(Tunnel.Model.Date_Sys model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_Id", SqlDbType.Int,4),
					new SqlParameter("@d_userId", SqlDbType.Int,4),
					new SqlParameter("@d_beginPoll_Date", SqlDbType.DateTime),
					new SqlParameter("@d_endPoll_Date", SqlDbType.DateTime),
					new SqlParameter("@d_proce_Date", SqlDbType.DateTime)};
			parameters[0].Value = model.d_Id;
			parameters[1].Value = model.d_userId;
			parameters[2].Value = model.d_beginPoll_Date;
			parameters[3].Value = model.d_endPoll_Date;
			parameters[4].Value = model.d_proce_Date;

			DbHelperSQL.RunProcedure("UP_Date_Sys_ADD",parameters,out rowsAffected);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Date_Sys model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_Id", SqlDbType.Int,4),
					new SqlParameter("@d_userId", SqlDbType.Int,4),
					new SqlParameter("@d_beginPoll_Date", SqlDbType.DateTime),
					new SqlParameter("@d_endPoll_Date", SqlDbType.DateTime),
					new SqlParameter("@d_proce_Date", SqlDbType.DateTime)};
			parameters[0].Value = model.d_Id;
			parameters[1].Value = model.d_userId;
			parameters[2].Value = model.d_beginPoll_Date;
			parameters[3].Value = model.d_endPoll_Date;
			parameters[4].Value = model.d_proce_Date;

			DbHelperSQL.RunProcedure("UP_Date_Sys_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int d_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_Id", SqlDbType.Int,4)};
			parameters[0].Value = d_Id;

			DbHelperSQL.RunProcedure("UP_Date_Sys_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Date_Sys GetModel(int d_Id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@d_Id", SqlDbType.Int,4)};
			parameters[0].Value = d_Id;

			Tunnel.Model.Date_Sys model=new Tunnel.Model.Date_Sys();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Date_Sys_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["d_Id"].ToString()!="")
				{
					model.d_Id=int.Parse(ds.Tables[0].Rows[0]["d_Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["d_userId"].ToString()!="")
				{
					model.d_userId=int.Parse(ds.Tables[0].Rows[0]["d_userId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["d_beginPoll_Date"].ToString()!="")
				{
					model.d_beginPoll_Date=DateTime.Parse(ds.Tables[0].Rows[0]["d_beginPoll_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["d_endPoll_Date"].ToString()!="")
				{
					model.d_endPoll_Date=DateTime.Parse(ds.Tables[0].Rows[0]["d_endPoll_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["d_proce_Date"].ToString()!="")
				{
					model.d_proce_Date=DateTime.Parse(ds.Tables[0].Rows[0]["d_proce_Date"].ToString());
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
			strSql.Append("select d_Id,d_userId,d_beginPoll_Date,d_endPoll_Date,d_proce_Date ");
			strSql.Append(" FROM Date_Sys ");
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
			strSql.Append(" d_Id,d_userId,d_beginPoll_Date,d_endPoll_Date,d_proce_Date ");
			strSql.Append(" FROM Date_Sys ");
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
			parameters[0].Value = "Date_Sys";
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

