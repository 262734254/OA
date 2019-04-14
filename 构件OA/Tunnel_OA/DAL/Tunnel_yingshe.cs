using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_yingshe。
	/// </summary>
	public class Tunnel_yingshe
	{
		public Tunnel_yingshe()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("y_id", "Tunnel_yingshe"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int y_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@y_id", SqlDbType.Int,4)};
			parameters[0].Value = y_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_yingshe_Exists",parameters,out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_yingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@y_id", SqlDbType.Int,4),
					new SqlParameter("@y_jsid", SqlDbType.Int,4),
					new SqlParameter("@y_qxlist", SqlDbType.VarChar,2000)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.y_jsid;
			parameters[2].Value = model.y_qxlist;

			DbHelperSQL.RunProcedure("Tunnel_yingshe_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
        public void Update(Tunnel.Model.Tunnel_yingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@y_id", SqlDbType.Int,4),
					new SqlParameter("@y_jsid", SqlDbType.Int,4),
					new SqlParameter("@y_qxlist", SqlDbType.VarChar,2000)};
			parameters[0].Value = model.y_id;
			parameters[1].Value = model.y_jsid;
			parameters[2].Value = model.y_qxlist;

			DbHelperSQL.RunProcedure("Tunnel_yingshe_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int y_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@y_id", SqlDbType.Int,4)};
			parameters[0].Value = y_id;

			DbHelperSQL.RunProcedure("Tunnel_yingshe_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_yingshe GetModel(int y_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@y_id", SqlDbType.Int,4)};
			parameters[0].Value = y_id;

            Tunnel.Model.Tunnel_yingshe model = new Tunnel.Model.Tunnel_yingshe();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_yingshe_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["y_id"].ToString()!="")
				{
					model.y_id=int.Parse(ds.Tables[0].Rows[0]["y_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["y_jsid"].ToString()!="")
				{
					model.y_jsid=int.Parse(ds.Tables[0].Rows[0]["y_jsid"].ToString());
				}
				model.y_qxlist=ds.Tables[0].Rows[0]["y_qxlist"].ToString();
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
			strSql.Append("select y_id,y_jsid,y_qxlist ");
			strSql.Append(" FROM Tunnel_yingshe ");
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
			strSql.Append(" y_id,y_jsid,y_qxlist ");
			strSql.Append(" FROM Tunnel_yingshe ");
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
			parameters[0].Value = "Tunnel_yingshe";
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

