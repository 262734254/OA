using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_formtype。
	/// </summary>
	public class Tunnel_formtype
	{
		public Tunnel_formtype()
		{}
		#region  成员方法


		/// <summary>
		///  增加一条数据
		/// </summary>
		public void Add(Tunnel.Model.Tunnel_formtype model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@Form_id", SqlDbType.Int,4),
					new SqlParameter("@Form_name", SqlDbType.VarChar,100),
					new SqlParameter("@Item_max", SqlDbType.Int,4)};
			parameters[0].Value = model.Form_id;
			parameters[1].Value = model.Form_name;
			parameters[2].Value = model.Item_max;

			DbHelperSQL.RunProcedure("Tunnel_formtype_ADD",parameters,out rowsAffected);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_formtype model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@Form_id", SqlDbType.Int,4),
					new SqlParameter("@Form_name", SqlDbType.VarChar,100),
					new SqlParameter("@Item_max", SqlDbType.Int,4)};
			parameters[0].Value = model.Form_id;
			parameters[1].Value = model.Form_name;
			parameters[2].Value = model.Item_max;

			DbHelperSQL.RunProcedure("Tunnel_formtype_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public void Delete(int Form_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
                new SqlParameter("@Form_id", SqlDbType.Int,4)
            };
            parameters[0].Value = Form_id;
			DbHelperSQL.RunProcedure("Tunnel_formtype_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_formtype GetModel(int Form_id)
		{
            SqlParameter[] parameters = {
                new SqlParameter("@Form_id", SqlDbType.Int,4)
            };
            parameters[0].Value = Form_id;

			Tunnel.Model.Tunnel_formtype model=new Tunnel.Model.Tunnel_formtype();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_formtype_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Form_id"].ToString()!="")
				{
					model.Form_id=int.Parse(ds.Tables[0].Rows[0]["Form_id"].ToString());
				}
				model.Form_name=ds.Tables[0].Rows[0]["Form_name"].ToString();
				if(ds.Tables[0].Rows[0]["Item_max"].ToString()!="")
				{
					model.Item_max=int.Parse(ds.Tables[0].Rows[0]["Item_max"].ToString());
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
			strSql.Append("select Form_id,Form_name,Item_max ");
			strSql.Append(" FROM Tunnel_formtype ");
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
			strSql.Append(" Form_id,Form_name,Item_max ");
			strSql.Append(" FROM Tunnel_formtype ");
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
			parameters[0].Value = "Tunnel_formtype";
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

