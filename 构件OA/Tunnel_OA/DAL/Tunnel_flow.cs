using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_flow。
	/// </summary>
	public class Tunnel_flow
	{
		public Tunnel_flow()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long f_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
			parameters[0].Value = f_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_flow_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_flow model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_name", SqlDbType.VarChar,200),
					new SqlParameter("@f_bum", SqlDbType.Int,4),
					new SqlParameter("@f_form", SqlDbType.Int,4),
					new SqlParameter("@f_isfile", SqlDbType.Int,4),
					new SqlParameter("@f_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@f_sort", SqlDbType.Int,4),
                    new SqlParameter("@f_stype", SqlDbType.Int,4),
                    new SqlParameter("@f_state", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.f_name;
			parameters[2].Value = model.f_bum;
			parameters[3].Value = model.f_form;
			parameters[4].Value = model.f_isfile;
			parameters[5].Value = model.f_depict;
			parameters[6].Value = model.f_sort;
            parameters[7].Value = model.f_stype;
            parameters[8].Value = model.f_state;

			DbHelperSQL.RunProcedure("Tunnel_flow_ADD",parameters,out rowsAffected);
			return int.Parse(parameters[0].Value.ToString());
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_flow model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_name", SqlDbType.VarChar,200),
					new SqlParameter("@f_bum", SqlDbType.Int,4),
					new SqlParameter("@f_form", SqlDbType.Int,4),
					new SqlParameter("@f_isfile", SqlDbType.Int,4),
					new SqlParameter("@f_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@f_sort", SqlDbType.Int,4),
                    new SqlParameter("@f_stype", SqlDbType.Int,4),
                    new SqlParameter("@f_state", SqlDbType.Int,4)};
			parameters[0].Value = model.f_id;
			parameters[1].Value = model.f_name;
			parameters[2].Value = model.f_bum;
			parameters[3].Value = model.f_form;
			parameters[4].Value = model.f_isfile;
			parameters[5].Value = model.f_depict;
            parameters[6].Value = model.f_sort;
            parameters[7].Value = model.f_stype;
            parameters[8].Value = model.f_state;

			DbHelperSQL.RunProcedure("Tunnel_flow_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long f_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
			parameters[0].Value = f_id;

			DbHelperSQL.RunProcedure("Tunnel_flow_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_flow GetModel(long f_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
			parameters[0].Value = f_id;

			Tunnel.Model.Tunnel_flow model=new Tunnel.Model.Tunnel_flow();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_flow_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["f_id"].ToString()!="")
				{
					model.f_id=long.Parse(ds.Tables[0].Rows[0]["f_id"].ToString());
				}
				model.f_name=ds.Tables[0].Rows[0]["f_name"].ToString();
				if(ds.Tables[0].Rows[0]["f_bum"].ToString()!="")
				{
					model.f_bum=int.Parse(ds.Tables[0].Rows[0]["f_bum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_form"].ToString()!="")
				{
					model.f_form=int.Parse(ds.Tables[0].Rows[0]["f_form"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_isfile"].ToString()!="")
				{
					model.f_isfile=int.Parse(ds.Tables[0].Rows[0]["f_isfile"].ToString());
				}
				model.f_depict=ds.Tables[0].Rows[0]["f_depict"].ToString();
				if(ds.Tables[0].Rows[0]["f_sort"].ToString()!="")
				{
					model.f_sort=int.Parse(ds.Tables[0].Rows[0]["f_sort"].ToString());
				}
                if (ds.Tables[0].Rows[0]["f_stype"].ToString() != "")
                {
                    model.f_stype = int.Parse(ds.Tables[0].Rows[0]["f_stype"].ToString());
                }
                if (ds.Tables[0].Rows[0]["f_state"].ToString() != "")
                {
                    model.f_state = int.Parse(ds.Tables[0].Rows[0]["f_state"].ToString());
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
            strSql.Append("select f_id,f_name,f_bum,f_form,f_isfile,f_depict,f_sort,f_stype,f_state ");
			strSql.Append(" FROM Tunnel_flow ");
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
            strSql.Append(" f_id,f_name,f_bum,f_form,f_isfile,f_depict,f_sortf_stype,f_state ");
			strSql.Append(" FROM Tunnel_flow ");
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
			parameters[0].Value = "Tunnel_flow";
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

