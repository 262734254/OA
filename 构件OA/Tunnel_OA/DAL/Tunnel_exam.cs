using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_exam。
	/// </summary>
	public class Tunnel_exam
	{
		public Tunnel_exam()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long e_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.BigInt)};
			parameters[0].Value = e_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_exam_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_exam model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.BigInt,8),
					new SqlParameter("@e_gid", SqlDbType.Int,4),
					new SqlParameter("@e_bid", SqlDbType.Int,4),
					new SqlParameter("@e_time", SqlDbType.DateTime),
					new SqlParameter("@e_user", SqlDbType.Int,4),
					new SqlParameter("@e_endtime", SqlDbType.DateTime),
                    new SqlParameter("@e_nextbuser",SqlDbType.VarChar,500),
					new SqlParameter("@e_nextbid", SqlDbType.BigInt,8)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.e_gid;
			parameters[2].Value = model.e_bid;
			parameters[3].Value = model.e_time;
			parameters[4].Value = model.e_user;
			parameters[5].Value = model.e_endtime;
            parameters[6].Value = model.e_nextbuser;
			parameters[7].Value = model.e_nextbid;

			DbHelperSQL.RunProcedure("UP_Tunnel_exam_ADD",parameters,out rowsAffected);
			return Convert.ToInt32(parameters[0].Value);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_exam model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.BigInt,8),
					new SqlParameter("@e_gid", SqlDbType.Int,4),
					new SqlParameter("@e_bid", SqlDbType.Int,4),
					new SqlParameter("@e_time", SqlDbType.DateTime),
					new SqlParameter("@e_user", SqlDbType.Int,4),
					new SqlParameter("@e_endtime", SqlDbType.DateTime),
                    new SqlParameter("@e_nextbuser",SqlDbType.VarChar,500),
					new SqlParameter("@e_nextbid", SqlDbType.BigInt,8)};
			parameters[0].Value = model.e_id;
			parameters[1].Value = model.e_gid;
			parameters[2].Value = model.e_bid;
			parameters[3].Value = model.e_time;
			parameters[4].Value = model.e_user;
			parameters[5].Value = model.e_endtime;
            parameters[6].Value = model.e_nextbuser;
			parameters[7].Value = model.e_nextbid;

			DbHelperSQL.RunProcedure("UP_Tunnel_exam_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long e_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.BigInt)};
			parameters[0].Value = e_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_exam_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_exam GetModel(long e_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@e_id", SqlDbType.BigInt)};
			parameters[0].Value = e_id;

			Tunnel.Model.Tunnel_exam model=new Tunnel.Model.Tunnel_exam();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_exam_GetModel",parameters,"ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["e_id"].ToString() != "")
                {
                    model.e_id = long.Parse(ds.Tables[0].Rows[0]["e_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["e_gid"].ToString() != "")
                {
                    model.e_gid = int.Parse(ds.Tables[0].Rows[0]["e_gid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["e_bid"].ToString() != "")
                {
                    model.e_bid = int.Parse(ds.Tables[0].Rows[0]["e_bid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["e_time"].ToString() != "")
                {
                    model.e_time = DateTime.Parse(ds.Tables[0].Rows[0]["e_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["e_user"].ToString() != "")
                {
                    model.e_user = int.Parse(ds.Tables[0].Rows[0]["e_user"].ToString());
                }
                if (ds.Tables[0].Rows[0]["e_endtime"].ToString() != "")
                {
                    model.e_endtime = DateTime.Parse(ds.Tables[0].Rows[0]["e_endtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["e_nextbid"].ToString() != "")
                {
                    model.e_nextbid = long.Parse(ds.Tables[0].Rows[0]["e_nextbid"].ToString());
                }
                model.e_nextbuser = ds.Tables[0].Rows[0]["e_nextbuser"].ToString();
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
            strSql.Append("select e_id,e_gid,e_bid,e_time,e_user,e_endtime,e_nextbid,e_nextbuser ");
			strSql.Append(" FROM Tunnel_exam ");
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
            strSql.Append(" e_id,e_gid,e_bid,e_time,e_user,e_endtime,e_nextbid,e_nextbuser ");
			strSql.Append(" FROM Tunnel_exam ");
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
			parameters[0].Value = "Tunnel_exam";
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

