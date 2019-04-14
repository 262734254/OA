using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_Remind。
	/// </summary>
	public class Tunnel_Remind
	{
		public Tunnel_Remind()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long m_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
			parameters[0].Value = m_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_Remind_Exists",parameters,out rowsAffected);
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
		public long Add(Tunnel.Model.Tunnel_Remind model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt,8),
					new SqlParameter("@m_title", SqlDbType.VarChar,500),
					new SqlParameter("@m_url", SqlDbType.VarChar,500),
					new SqlParameter("@m_touser", SqlDbType.BigInt,8),
					new SqlParameter("@m_time", SqlDbType.DateTime),
					new SqlParameter("@m_isread", SqlDbType.Int,4),
					new SqlParameter("@m_callTime", SqlDbType.DateTime),
					new SqlParameter("@m_type", SqlDbType.Int,4),
					new SqlParameter("@m_typeid", SqlDbType.Int,4),
                    new SqlParameter("@m_bid", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.m_title;
			parameters[2].Value = model.m_url;
			parameters[3].Value = model.m_touser;
			parameters[4].Value = model.m_time;
			parameters[5].Value = model.m_isread;
			parameters[6].Value = model.m_callTime;
			parameters[7].Value = model.m_type;
			parameters[8].Value = model.m_typeid;
            parameters[9].Value = model.m_bid;

			DbHelperSQL.RunProcedure("UP_Tunnel_Remind_ADD",parameters,out rowsAffected);
			return Convert.ToInt64(parameters[0].Value);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Remind model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt,8),
					new SqlParameter("@m_title", SqlDbType.VarChar,500),
					new SqlParameter("@m_url", SqlDbType.VarChar,500),
					new SqlParameter("@m_touser", SqlDbType.BigInt,8),
					new SqlParameter("@m_time", SqlDbType.DateTime),
					new SqlParameter("@m_isread", SqlDbType.Int,4),
					new SqlParameter("@m_callTime", SqlDbType.DateTime),
					new SqlParameter("@m_type", SqlDbType.Int,4),
					new SqlParameter("@m_typeid", SqlDbType.Int,4),
                    new SqlParameter("@m_bid", SqlDbType.Int,4)};
			parameters[0].Value = model.m_id;
			parameters[1].Value = model.m_title;
			parameters[2].Value = model.m_url;
			parameters[3].Value = model.m_touser;
			parameters[4].Value = model.m_time;
			parameters[5].Value = model.m_isread;
			parameters[6].Value = model.m_callTime;
			parameters[7].Value = model.m_type;
			parameters[8].Value = model.m_typeid;
            parameters[9].Value = model.m_bid;

			DbHelperSQL.RunProcedure("UP_Tunnel_Remind_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long m_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
			parameters[0].Value = m_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_Remind_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Remind GetModel(long m_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
			parameters[0].Value = m_id;

			Tunnel.Model.Tunnel_Remind model=new Tunnel.Model.Tunnel_Remind();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_Remind_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_id"].ToString()!="")
				{
					model.m_id=long.Parse(ds.Tables[0].Rows[0]["m_id"].ToString());
				}
				model.m_title=ds.Tables[0].Rows[0]["m_title"].ToString();
				model.m_url=ds.Tables[0].Rows[0]["m_url"].ToString();
				if(ds.Tables[0].Rows[0]["m_touser"].ToString()!="")
				{
					model.m_touser=long.Parse(ds.Tables[0].Rows[0]["m_touser"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_time"].ToString()!="")
				{
					model.m_time=DateTime.Parse(ds.Tables[0].Rows[0]["m_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_isread"].ToString()!="")
				{
					model.m_isread=int.Parse(ds.Tables[0].Rows[0]["m_isread"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_callTime"].ToString()!="")
				{
					model.m_callTime=DateTime.Parse(ds.Tables[0].Rows[0]["m_callTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_type"].ToString()!="")
				{
					model.m_type=int.Parse(ds.Tables[0].Rows[0]["m_type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_typeid"].ToString()!="")
				{
					model.m_typeid=int.Parse(ds.Tables[0].Rows[0]["m_typeid"].ToString());
				}
                if (ds.Tables[0].Rows[0]["m_bid"].ToString() != "")
                {
                    model.m_bid = int.Parse(ds.Tables[0].Rows[0]["m_bid"].ToString());
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
            strSql.Append("select m_id,m_title,m_url,m_touser,m_time,m_isread,m_callTime,m_type,m_typeid,m_bid ");
			strSql.Append(" FROM Tunnel_Remind ");
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
            strSql.Append(" m_id,m_title,m_url,m_touser,m_time,m_isread,m_callTime,m_type,m_typeid,m_bid ");
			strSql.Append(" FROM Tunnel_Remind ");
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
			parameters[0].Value = "Tunnel_Remind";
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

