using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_dyingshe。
	/// </summary>
	public class Tunnel_dyingshe
	{
		public Tunnel_dyingshe()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("dy_id", "Tunnel_dyingshe"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int dy_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@dy_id", SqlDbType.Int,4)};
			parameters[0].Value = dy_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_dyingshe_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_dyingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@dy_id", SqlDbType.Int,4),
					new SqlParameter("@dy_did", SqlDbType.VarChar,50),
					new SqlParameter("@dy_list", SqlDbType.VarChar,2000)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.dy_did;
			parameters[2].Value = model.dy_list;

			DbHelperSQL.RunProcedure("UP_Tunnel_dyingshe_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_dyingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@dy_id", SqlDbType.Int,4),
					new SqlParameter("@dy_did", SqlDbType.VarChar,50),
					new SqlParameter("@dy_list", SqlDbType.VarChar,2000)};
			parameters[0].Value = model.dy_id;
			parameters[1].Value = model.dy_did;
			parameters[2].Value = model.dy_list;

			DbHelperSQL.RunProcedure("UP_Tunnel_dyingshe_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int dy_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@dy_id", SqlDbType.Int,4)};
			parameters[0].Value = dy_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_dyingshe_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_dyingshe GetModel(int dy_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@dy_id", SqlDbType.Int,4)};
			parameters[0].Value = dy_id;

			Tunnel.Model.Tunnel_dyingshe model=new Tunnel.Model.Tunnel_dyingshe();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_dyingshe_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["dy_id"].ToString()!="")
				{
					model.dy_id=int.Parse(ds.Tables[0].Rows[0]["dy_id"].ToString());
				}
				model.dy_did=ds.Tables[0].Rows[0]["dy_did"].ToString();
				model.dy_list=ds.Tables[0].Rows[0]["dy_list"].ToString();
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
			strSql.Append("select dy_id,dy_did,dy_list ");
			strSql.Append(" FROM Tunnel_dyingshe ");
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
			strSql.Append(" dy_id,dy_did,dy_list ");
			strSql.Append(" FROM Tunnel_dyingshe ");
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
			parameters[0].Value = "Tunnel_dyingshe";
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

