using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_step。
	/// </summary>
	public class Tunnel_step
	{
		public Tunnel_step()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long s_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.BigInt)};
			parameters[0].Value = s_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_step_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_step model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.BigInt,8),
					new SqlParameter("@s_name", SqlDbType.VarChar,100),
					new SqlParameter("@s_num", SqlDbType.Int,4),
					new SqlParameter("@s_zid", SqlDbType.VarChar,500),
					new SqlParameter("@s_lid", SqlDbType.Int,4),
					new SqlParameter("@s_depict", SqlDbType.VarChar,1000),
                    new SqlParameter("@s_ishui", SqlDbType.Int,4),
					new SqlParameter("@s_isbak", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.s_name;
			parameters[2].Value = model.s_num;
			parameters[3].Value = model.s_zid;
			parameters[4].Value = model.s_lid;
			parameters[5].Value = model.s_depict;
            parameters[6].Value = model.s_ishui;
            parameters[7].Value = model.s_isbak;

			DbHelperSQL.RunProcedure("Tunnel_step_ADD",parameters,out rowsAffected);
			return Convert.ToInt32(parameters[0].Value);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_step model)
		{
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.BigInt,8),
					new SqlParameter("@s_name", SqlDbType.VarChar,100),
					new SqlParameter("@s_num", SqlDbType.Int,4),
					new SqlParameter("@s_zid", SqlDbType.VarChar,500),
					new SqlParameter("@s_lid", SqlDbType.Int,4),
					new SqlParameter("@s_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@s_ishui", SqlDbType.Int,4),
					new SqlParameter("@s_isbak", SqlDbType.Int,4)};
            parameters[0].Value = model.s_id;
            parameters[1].Value = model.s_name;
            parameters[2].Value = model.s_num;
            parameters[3].Value = model.s_zid;
            parameters[4].Value = model.s_lid;
            parameters[5].Value = model.s_depict;
            parameters[6].Value = model.s_ishui;
            parameters[7].Value = model.s_isbak;

			DbHelperSQL.RunProcedure("Tunnel_step_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long s_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.BigInt)};
			parameters[0].Value = s_id;

			DbHelperSQL.RunProcedure("Tunnel_step_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_step GetModel(long s_id)
		{
            SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.BigInt)};
            parameters[0].Value = s_id;

            Tunnel.Model.Tunnel_step model = new Tunnel.Model.Tunnel_step();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_step_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["s_id"].ToString() != "")
                {
                    model.s_id = long.Parse(ds.Tables[0].Rows[0]["s_id"].ToString());
                }
                model.s_name = ds.Tables[0].Rows[0]["s_name"].ToString();
                if (ds.Tables[0].Rows[0]["s_num"].ToString() != "")
                {
                    model.s_num = int.Parse(ds.Tables[0].Rows[0]["s_num"].ToString());
                }
                model.s_zid = ds.Tables[0].Rows[0]["s_zid"].ToString();
                if (ds.Tables[0].Rows[0]["s_lid"].ToString() != "")
                {
                    model.s_lid = int.Parse(ds.Tables[0].Rows[0]["s_lid"].ToString());
                }
                model.s_depict = ds.Tables[0].Rows[0]["s_depict"].ToString();
                if (ds.Tables[0].Rows[0]["s_ishui"].ToString() != "")
                {
                    model.s_ishui = int.Parse(ds.Tables[0].Rows[0]["s_ishui"].ToString());
                }
                if (ds.Tables[0].Rows[0]["s_isbak"].ToString() != "")
                {
                    model.s_isbak = int.Parse(ds.Tables[0].Rows[0]["s_isbak"].ToString());
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
			strSql.Append("select s_id,s_name,s_num,s_zid,s_lid,s_depict ");
			strSql.Append(" FROM Tunnel_step ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select s_id,s_name,s_num,s_zid,s_lid,s_depict ");
            strSql.Append(" FROM Tunnel_step ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows.Count;
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
			strSql.Append(" s_id,s_name,s_num,s_zid,s_lid,s_depict ");
			strSql.Append(" FROM Tunnel_step ");
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
			parameters[0].Value = "Tunnel_step";
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

