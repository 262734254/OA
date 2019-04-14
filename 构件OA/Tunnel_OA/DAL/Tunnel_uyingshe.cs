using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_uyingshe。
	/// </summary>
	public class Tunnel_uyingshe
	{
		public Tunnel_uyingshe()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("uy_id", "Tunnel_uyingshe"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int uy_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@uy_id", SqlDbType.Int,4)};
			parameters[0].Value = uy_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_uyingshe_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_uyingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@uy_id", SqlDbType.Int,4),
					new SqlParameter("@uy_uid", SqlDbType.VarChar,50),
					new SqlParameter("@uy_list", SqlDbType.VarChar,2000)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.uy_uid;
			parameters[2].Value = model.uy_list;

			DbHelperSQL.RunProcedure("UP_Tunnel_uyingshe_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_uyingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@uy_id", SqlDbType.Int,4),
					new SqlParameter("@uy_uid", SqlDbType.VarChar,50),
					new SqlParameter("@uy_list", SqlDbType.VarChar,2000)};
			parameters[0].Value = model.uy_id;
			parameters[1].Value = model.uy_uid;
			parameters[2].Value = model.uy_list;

			DbHelperSQL.RunProcedure("UP_Tunnel_uyingshe_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int uy_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@uy_id", SqlDbType.Int,4)};
			parameters[0].Value = uy_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_uyingshe_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_uyingshe GetModel(int uy_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@uy_id", SqlDbType.Int,4)};
			parameters[0].Value = uy_id;

			Tunnel.Model.Tunnel_uyingshe model=new Tunnel.Model.Tunnel_uyingshe();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_uyingshe_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["uy_id"].ToString()!="")
				{
					model.uy_id=int.Parse(ds.Tables[0].Rows[0]["uy_id"].ToString());
				}
				model.uy_uid=ds.Tables[0].Rows[0]["uy_uid"].ToString();
				model.uy_list=ds.Tables[0].Rows[0]["uy_list"].ToString();
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
			strSql.Append("select uy_id,uy_uid,uy_list ");
			strSql.Append(" FROM Tunnel_uyingshe ");
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
			strSql.Append(" uy_id,uy_uid,uy_list ");
			strSql.Append(" FROM Tunnel_uyingshe ");
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
			parameters[0].Value = "Tunnel_uyingshe";
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

