using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_kaosetting。
	/// </summary>
	public class Tunnel_kaosetting
	{
		public Tunnel_kaosetting()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long k_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@k_id", SqlDbType.BigInt)};
			parameters[0].Value = k_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_kaosetting_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_kaosetting model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@k_id", SqlDbType.BigInt,8),
					new SqlParameter("@k_amtime", SqlDbType.VarChar,20),
					new SqlParameter("@k_pmtime", SqlDbType.VarChar,20),
					new SqlParameter("@k_xiu", SqlDbType.VarChar,20),
					new SqlParameter("@k_am2time", SqlDbType.VarChar,20),
					new SqlParameter("@k_pm2time", SqlDbType.VarChar,20)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.k_amtime;
			parameters[2].Value = model.k_pmtime;
			parameters[3].Value = model.k_xiu;
			parameters[4].Value = model.k_am2time;
			parameters[5].Value = model.k_pm2time;

			DbHelperSQL.RunProcedure("Tunnel_kaosetting_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_kaosetting model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@k_id", SqlDbType.BigInt,8),
					new SqlParameter("@k_amtime", SqlDbType.VarChar,20),
					new SqlParameter("@k_pmtime", SqlDbType.VarChar,20),
					new SqlParameter("@k_xiu", SqlDbType.VarChar,20),
					new SqlParameter("@k_am2time", SqlDbType.VarChar,20),
					new SqlParameter("@k_pm2time", SqlDbType.VarChar,20)};
			parameters[0].Value = model.k_id;
			parameters[1].Value = model.k_amtime;
			parameters[2].Value = model.k_pmtime;
			parameters[3].Value = model.k_xiu;
			parameters[4].Value = model.k_am2time;
			parameters[5].Value = model.k_pm2time;

			DbHelperSQL.RunProcedure("Tunnel_kaosetting_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long k_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@k_id", SqlDbType.BigInt)};
			parameters[0].Value = k_id;

			DbHelperSQL.RunProcedure("Tunnel_kaosetting_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_kaosetting GetModel(long k_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@k_id", SqlDbType.BigInt)};
			parameters[0].Value = k_id;

			Tunnel.Model.Tunnel_kaosetting model=new Tunnel.Model.Tunnel_kaosetting();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_kaosetting_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["k_id"].ToString()!="")
				{
					model.k_id=long.Parse(ds.Tables[0].Rows[0]["k_id"].ToString());
				}
				model.k_amtime=ds.Tables[0].Rows[0]["k_amtime"].ToString();
				model.k_pmtime=ds.Tables[0].Rows[0]["k_pmtime"].ToString();
				model.k_xiu=ds.Tables[0].Rows[0]["k_xiu"].ToString();
				model.k_am2time=ds.Tables[0].Rows[0]["k_am2time"].ToString();
				model.k_pm2time=ds.Tables[0].Rows[0]["k_pm2time"].ToString();
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
			strSql.Append("select k_id,k_amtime,k_pmtime,k_xiu,k_am2time,k_pm2time ");
			strSql.Append(" FROM Tunnel_kaosetting ");
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
			strSql.Append(" k_id,k_amtime,k_pmtime,k_xiu,k_am2time,k_pm2time ");
			strSql.Append(" FROM Tunnel_kaosetting ");
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
			parameters[0].Value = "Tunnel_kaosetting";
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

