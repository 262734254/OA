using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_quanxian。
	/// </summary>
	public class Tunnel_quanxian
	{
		public Tunnel_quanxian()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("q_id", "Tunnel_quanxian"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int q_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4)};
			parameters[0].Value = q_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_quanxian_Exists",parameters,out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_quanxian model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4),
					new SqlParameter("@q_name", SqlDbType.VarChar,50),
					new SqlParameter("@q_mark", SqlDbType.VarChar,200),
                    new SqlParameter("@q_rId", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.q_name;
			parameters[2].Value = model.q_mark;
            parameters[3].Value = model.q_rId;

			DbHelperSQL.RunProcedure("Tunnel_quanxian_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
        public void Update(Tunnel.Model.Tunnel_quanxian model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4),
					new SqlParameter("@q_name", SqlDbType.VarChar,50),
					new SqlParameter("@q_mark", SqlDbType.VarChar,200),
                                        new SqlParameter("@q_rId", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.q_name;
            parameters[2].Value = model.q_mark;
            parameters[3].Value = model.q_rId;

			DbHelperSQL.RunProcedure("Tunnel_quanxian_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int q_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4)};
			parameters[0].Value = q_id;

			DbHelperSQL.RunProcedure("Tunnel_quanxian_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_quanxian GetModel(int q_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@q_id", SqlDbType.Int,4)};
			parameters[0].Value = q_id;

            Tunnel.Model.Tunnel_quanxian model = new Tunnel.Model.Tunnel_quanxian();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_quanxian_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["q_id"].ToString()!="")
				{
					model.q_id=int.Parse(ds.Tables[0].Rows[0]["q_id"].ToString());
				}
				model.q_name=ds.Tables[0].Rows[0]["q_name"].ToString();
				model.q_mark=ds.Tables[0].Rows[0]["q_mark"].ToString();
                model.q_rId = Convert.ToInt32(ds.Tables[0].Rows[0]["q_rId"].ToString());
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
			strSql.Append("select * ");
			strSql.Append(" FROM Tunnel_quanxian ");
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
			strSql.Append(" * ");
			strSql.Append(" FROM Tunnel_quanxian ");
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
			parameters[0].Value = "Tunnel_quanxian";
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

