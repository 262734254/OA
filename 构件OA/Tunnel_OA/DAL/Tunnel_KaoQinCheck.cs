using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_KaoQinCheck。
	/// </summary>
	public class Tunnel_KaoQinCheck
	{
		public Tunnel_KaoQinCheck()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("s_id", "Tunnel_KaoQinCheck"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int s_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.Int,4)};
			parameters[0].Value = s_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_KaoQinCheck_Exists",parameters,out rowsAffected);
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
        /// 根据年月查询数据是否存在
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="bid">部门ID</param>
        /// <returns>0不存在，1存在</returns>
        public int Exist(string year, string month,string bid)
        {
            SqlParameter[] parameters ={
                                          new SqlParameter("@s_year",SqlDbType.NChar,4),
                                          new SqlParameter("@s_moon",SqlDbType.NChar,2),
                                       new SqlParameter("@s_bid",SqlDbType.NChar,2)};
            parameters[0].Value = year;
            parameters[1].Value = month;
            parameters[2].Value = bid;
            string strsql = "";
            if (bid == "0")
            {
                strsql = "select 1 from tunnel_bum where b_id not in(select s_bid from tunnel_kaoqincheck where s_year=@s_year  and s_moon=@s_moon)";
                if (DbHelperSQL.Exists(strsql, parameters))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                strsql = "select 1 from tunnel_kaoqincheck where s_year=@s_year  and s_moon=@s_moon and s_bid=@s_bid";
            }
            if (DbHelperSQL.Exists(strsql, parameters))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 验证考勤是否已审核
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns>0未审核，1审核</returns>
        public int ExistKaoQin(string year, string month, string bid)
        {
            SqlParameter[] parameters ={
                                          new SqlParameter("@s_year",SqlDbType.NChar,4),
                                          new SqlParameter("@s_moon",SqlDbType.NChar,2),
                                       new SqlParameter("@s_bid",SqlDbType.NChar,2)};
            parameters[0].Value = year;
            parameters[1].Value = month;
            parameters[2].Value = bid;
            string strsql = "";
            if (bid == "0")
            {
                strsql="select 1 from tunnel_kaoqincheck where s_year=@s_year  and s_moon=@s_moon ";
            }
            else
            { 
                strsql="select 1 from tunnel_kaoqincheck where s_year=@s_year  and s_moon=@s_moon and s_bid=@s_bid";
            }
            if (DbHelperSQL.Exists(strsql, parameters))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

		/// <summary>
		///  增加一条数据
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_KaoQinCheck model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.Int,4),
					new SqlParameter("@s_year", SqlDbType.Int,4),
					new SqlParameter("@s_moon", SqlDbType.Int,4),
					new SqlParameter("@s_bid", SqlDbType.Int,4),
					new SqlParameter("@s_bname", SqlDbType.VarChar,50),
					new SqlParameter("@s_uid", SqlDbType.Int,4),
					new SqlParameter("@s_date", SqlDbType.DateTime)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.s_year;
			parameters[2].Value = model.s_moon;
			parameters[3].Value = model.s_bid;
			parameters[4].Value = model.s_bname;
			parameters[5].Value = model.s_uid;
			parameters[6].Value = model.s_date;

			DbHelperSQL.RunProcedure("UP_Tunnel_KaoQinCheck_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_KaoQinCheck model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.Int,4),
					new SqlParameter("@s_year", SqlDbType.Int,4),
					new SqlParameter("@s_moon", SqlDbType.Int,4),
					new SqlParameter("@s_bid", SqlDbType.Int,4),
					new SqlParameter("@s_bname", SqlDbType.VarChar,50),
					new SqlParameter("@s_uid", SqlDbType.Int,4),
					new SqlParameter("@s_date", SqlDbType.DateTime)};
			parameters[0].Value = model.s_id;
			parameters[1].Value = model.s_year;
			parameters[2].Value = model.s_moon;
			parameters[3].Value = model.s_bid;
			parameters[4].Value = model.s_bname;
			parameters[5].Value = model.s_uid;
			parameters[6].Value = model.s_date;

			DbHelperSQL.RunProcedure("UP_Tunnel_KaoQinCheck_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int s_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.Int,4)};
			parameters[0].Value = s_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_KaoQinCheck_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_KaoQinCheck GetModel(int s_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@s_id", SqlDbType.Int,4)};
			parameters[0].Value = s_id;

			Tunnel.Model.Tunnel_KaoQinCheck model=new Tunnel.Model.Tunnel_KaoQinCheck();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_KaoQinCheck_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["s_id"].ToString()!="")
				{
					model.s_id=int.Parse(ds.Tables[0].Rows[0]["s_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["s_year"].ToString()!="")
				{
					model.s_year=int.Parse(ds.Tables[0].Rows[0]["s_year"].ToString());
				}
				if(ds.Tables[0].Rows[0]["s_moon"].ToString()!="")
				{
					model.s_moon=int.Parse(ds.Tables[0].Rows[0]["s_moon"].ToString());
				}
				if(ds.Tables[0].Rows[0]["s_bid"].ToString()!="")
				{
					model.s_bid=int.Parse(ds.Tables[0].Rows[0]["s_bid"].ToString());
				}
				model.s_bname=ds.Tables[0].Rows[0]["s_bname"].ToString();
				if(ds.Tables[0].Rows[0]["s_uid"].ToString()!="")
				{
					model.s_uid=int.Parse(ds.Tables[0].Rows[0]["s_uid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["s_date"].ToString()!="")
				{
					model.s_date=DateTime.Parse(ds.Tables[0].Rows[0]["s_date"].ToString());
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
			strSql.Append("select s_id,s_year,s_moon,s_bid,s_bname,s_uid,s_date ");
			strSql.Append(" FROM Tunnel_KaoQinCheck ");
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
			strSql.Append(" s_id,s_year,s_moon,s_bid,s_bname,s_uid,s_date ");
			strSql.Append(" FROM Tunnel_KaoQinCheck ");
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
			parameters[0].Value = "Tunnel_KaoQinCheck";
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

