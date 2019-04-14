using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_weekstate。
	/// </summary>
	public class Tunnel_weekstate
	{
		public Tunnel_weekstate()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string week_ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@week_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = week_ID;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_weekstate_Exists",parameters,out rowsAffected);
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
		public void Add(Tunnel.Model.Tunnel_weekstate model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@week_ID", SqlDbType.VarChar,200),
					new SqlParameter("@week_state", SqlDbType.Int,4)};
			parameters[0].Value = model.week_ID;
			parameters[1].Value = model.week_state;

			DbHelperSQL.RunProcedure("UP_Tunnel_weekstate_ADD",parameters,out rowsAffected);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_weekstate model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@week_ID", SqlDbType.VarChar,200),
					new SqlParameter("@week_state", SqlDbType.Int,4)};
			parameters[0].Value = model.week_ID;
			parameters[1].Value = model.week_state;

			DbHelperSQL.RunProcedure("UP_Tunnel_weekstate_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string week_ID)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@week_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = week_ID;

			DbHelperSQL.RunProcedure("UP_Tunnel_weekstate_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_weekstate GetModel(string week_ID)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@week_ID", SqlDbType.VarChar,50)};
			parameters[0].Value = week_ID;

			Tunnel.Model.Tunnel_weekstate model=new Tunnel.Model.Tunnel_weekstate();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_weekstate_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				model.week_ID=ds.Tables[0].Rows[0]["week_ID"].ToString();
				if(ds.Tables[0].Rows[0]["week_state"].ToString()!="")
				{
					model.week_state=int.Parse(ds.Tables[0].Rows[0]["week_state"].ToString());
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
			strSql.Append("select week_ID,week_state ");
			strSql.Append(" FROM Tunnel_weekstate ");
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
			strSql.Append(" week_ID,week_state ");
			strSql.Append(" FROM Tunnel_weekstate ");
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
			parameters[0].Value = "Tunnel_weekstate";
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

