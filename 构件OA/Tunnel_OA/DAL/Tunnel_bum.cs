using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_bum。
	/// </summary>
	public class Tunnel_bum
	{
		public Tunnel_bum()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long b_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt)};
			parameters[0].Value = b_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_bum_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_bum model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt,8),
					new SqlParameter("@b_name", SqlDbType.VarChar,100),
					new SqlParameter("@b_hid", SqlDbType.Int,4),
					new SqlParameter("@b_depict", SqlDbType.VarChar,1000)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.b_name;
			parameters[2].Value = model.b_hid;
			parameters[3].Value = model.b_depict;

			DbHelperSQL.RunProcedure("Tunnel_bum_ADD",parameters,out rowsAffected);
			return int.Parse(parameters[0].Value.ToString());
		}

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public int AddProject(Tunnel.Model.Tunnel_bum model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt,8),
					new SqlParameter("@b_name", SqlDbType.VarChar,100),
					new SqlParameter("@b_hid", SqlDbType.Int,4),
                    new SqlParameter("@b_projectid", SqlDbType.Int,4),
					new SqlParameter("@b_depict", SqlDbType.VarChar,1000)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.b_name;
            parameters[2].Value = model.b_hid;
            parameters[4].Value = model.b_projectid;
            parameters[5].Value = model.b_depict;

            DbHelperSQL.RunProcedure("Tunnel_bum_ADDPoject", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_bum model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt,8),
					new SqlParameter("@b_name", SqlDbType.VarChar,100),
					new SqlParameter("@b_hid", SqlDbType.Int,4),
					new SqlParameter("@b_depict", SqlDbType.VarChar,1000)};
			parameters[0].Value = model.b_id;
			parameters[1].Value = model.b_name;
			parameters[2].Value = model.b_hid;
			parameters[3].Value = model.b_depict;

			DbHelperSQL.RunProcedure("Tunnel_bum_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long b_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt)};
			parameters[0].Value = b_id;

			DbHelperSQL.RunProcedure("Tunnel_bum_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_bum GetModel(long b_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt)};
			parameters[0].Value = b_id;

			Tunnel.Model.Tunnel_bum model=new Tunnel.Model.Tunnel_bum();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_bum_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["b_id"].ToString()!="")
				{
					model.b_id=long.Parse(ds.Tables[0].Rows[0]["b_id"].ToString());
				}
				model.b_name=ds.Tables[0].Rows[0]["b_name"].ToString();
				if(ds.Tables[0].Rows[0]["b_hid"].ToString()!="")
				{
					model.b_hid=int.Parse(ds.Tables[0].Rows[0]["b_hid"].ToString());
				}
				model.b_depict=ds.Tables[0].Rows[0]["b_depict"].ToString();
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
            strSql.Append("select b_id,b_name,b_hid,b_depict,b_projectid ");
			strSql.Append(" FROM Tunnel_bum ");
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
			strSql.Append(" b_id,b_name,b_hid,b_depict ");
			strSql.Append(" FROM Tunnel_bum ");
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
			parameters[0].Value = "Tunnel_bum";
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

