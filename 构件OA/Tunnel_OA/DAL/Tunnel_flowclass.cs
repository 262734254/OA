using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_flowclass。
	/// </summary>
	public class Tunnel_flowclass
	{
		public Tunnel_flowclass()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long fc_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@fc_id", SqlDbType.BigInt)};
			parameters[0].Value = fc_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_flowclass_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_flowclass model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@fc_id", SqlDbType.BigInt,8),
					new SqlParameter("@fc_name", SqlDbType.VarChar,100),
                    new SqlParameter("@fc_desin", SqlDbType.VarChar,500)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.fc_name;
            parameters[2].Value = model.Fc_desin;

			DbHelperSQL.RunProcedure("Tunnel_flowclass_ADD",parameters,out rowsAffected);
			return int.Parse(parameters[0].Value.ToString());
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_flowclass model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@fc_id", SqlDbType.BigInt,8),
					new SqlParameter("@fc_name", SqlDbType.VarChar,100),
                    new SqlParameter("@fc_desin", SqlDbType.VarChar,500)};
			parameters[0].Value = model.fc_id;
			parameters[1].Value = model.fc_name;
            parameters[2].Value = model.Fc_desin;

			DbHelperSQL.RunProcedure("Tunnel_flowclass_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long fc_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@fc_id", SqlDbType.BigInt)};
			parameters[0].Value = fc_id;

			DbHelperSQL.RunProcedure("Tunnel_flowclass_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_flowclass GetModel(long fc_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@fc_id", SqlDbType.BigInt)};
			parameters[0].Value = fc_id;

			Tunnel.Model.Tunnel_flowclass model=new Tunnel.Model.Tunnel_flowclass();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_flowclass_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["fc_id"].ToString()!="")
				{
					model.fc_id=long.Parse(ds.Tables[0].Rows[0]["fc_id"].ToString());
				}
				model.fc_name=ds.Tables[0].Rows[0]["fc_name"].ToString();
                model.Fc_desin = ds.Tables[0].Rows[0]["fc_desin"].ToString();
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
            strSql.Append("select fc_id,fc_name,fc_desin ");
			strSql.Append(" FROM Tunnel_flowclass ");
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
            strSql.Append(" fc_id,fc_name,Fc_desin");
			strSql.Append(" FROM Tunnel_flowclass ");
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
			parameters[0].Value = "Tunnel_flowclass";
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

