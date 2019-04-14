using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_CView。
	/// </summary>
	public class Tunnel_CView
	{
		public Tunnel_CView()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long c_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.BigInt)};
			parameters[0].Value = c_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_CView_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_CView model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.BigInt,8),
					new SqlParameter("@c_fid", SqlDbType.BigInt,8),
					new SqlParameter("@c_uid", SqlDbType.BigInt,8),
					new SqlParameter("@c_read", SqlDbType.Int,4),
					new SqlParameter("@c_content", SqlDbType.Text)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.c_fid;
			parameters[2].Value = model.c_uid;
			parameters[3].Value = model.c_read;
			parameters[4].Value = model.c_content;

			DbHelperSQL.RunProcedure("UP_Tunnel_CView_ADD",parameters,out rowsAffected);
			return Convert.ToInt32(parameters[0].Value);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_CView model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_fid", SqlDbType.BigInt,8),
					new SqlParameter("@c_uid", SqlDbType.BigInt,8),
					new SqlParameter("@c_read", SqlDbType.Int,4),
					new SqlParameter("@c_readdate", SqlDbType.DateTime),
					new SqlParameter("@c_content", SqlDbType.Text)};
			parameters[0].Value = model.c_fid;
			parameters[1].Value = model.c_uid;
			parameters[2].Value = model.c_read;
			parameters[3].Value = model.c_readdate;
			parameters[4].Value = model.c_content;

			DbHelperSQL.RunProcedure("UP_Tunnel_CView_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long c_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.BigInt)};
			parameters[0].Value = c_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_CView_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_CView GetModel(long c_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@c_id", SqlDbType.BigInt)};
			parameters[0].Value = c_id;

			Tunnel.Model.Tunnel_CView model=new Tunnel.Model.Tunnel_CView();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_CView_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["c_id"].ToString()!="")
				{
					model.c_id=long.Parse(ds.Tables[0].Rows[0]["c_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["c_fid"].ToString()!="")
				{
					model.c_fid=long.Parse(ds.Tables[0].Rows[0]["c_fid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["c_uid"].ToString()!="")
				{
					model.c_uid=long.Parse(ds.Tables[0].Rows[0]["c_uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["c_read"].ToString()!="")
				{
					model.c_read=int.Parse(ds.Tables[0].Rows[0]["c_read"].ToString());
				}
				if(ds.Tables[0].Rows[0]["c_readdate"].ToString()!="")
				{
					model.c_readdate=DateTime.Parse(ds.Tables[0].Rows[0]["c_readdate"].ToString());
				}
				model.c_content=ds.Tables[0].Rows[0]["c_content"].ToString();
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
			strSql.Append("select c_id,c_fid,c_uid,c_read,c_readdate,c_content ");
			strSql.Append(" FROM Tunnel_CView ");
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
			strSql.Append(" c_id,c_fid,c_uid,c_read,c_readdate,c_content ");
			strSql.Append(" FROM Tunnel_CView ");
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
			parameters[0].Value = "Tunnel_CView";
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

