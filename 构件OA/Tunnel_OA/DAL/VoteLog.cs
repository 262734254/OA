using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类VoteLog。
	/// </summary>
	public class VoteLog
	{
		public VoteLog()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("vg_id", "VoteLog"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int vg_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vg_id", SqlDbType.Int,4)};
			parameters[0].Value = vg_id;

			int result= DbHelperSQL.RunProcedure("UP_VoteLog_Exists",parameters,out rowsAffected);
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
		public void Add(Tunnel.Model.VoteLog model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {					
					new SqlParameter("@vg_setDate", SqlDbType.DateTime),
					new SqlParameter("@vg_userId", SqlDbType.Int,4),
					new SqlParameter("@vg_voteId", SqlDbType.Int,4)};
			
			parameters[0].Value = model.vg_setDate;
			parameters[1].Value = model.vg_userId;
			parameters[2].Value = model.vg_voteId;

			DbHelperSQL.RunProcedure("UP_VoteLog_ADD",parameters,out rowsAffected);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.VoteLog model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vg_id", SqlDbType.Int,4),
					new SqlParameter("@vg_setDate", SqlDbType.DateTime),
					new SqlParameter("@vg_userId", SqlDbType.Int,4),
					new SqlParameter("@vg_voteId", SqlDbType.Int,4)};
			parameters[0].Value = model.vg_id;
			parameters[1].Value = model.vg_setDate;
			parameters[2].Value = model.vg_userId;
			parameters[3].Value = model.vg_voteId;

			DbHelperSQL.RunProcedure("UP_VoteLog_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int vg_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vg_id", SqlDbType.Int,4)};
			parameters[0].Value = vg_id;

			DbHelperSQL.RunProcedure("UP_VoteLog_Delete",parameters,out rowsAffected);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByVote_ID(int vg_voteId)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@vg_voteId", SqlDbType.Int,4)};
            parameters[0].Value = vg_voteId;

            DbHelperSQL.RunProcedure("VoteLog_DeleteByVoteID", parameters, out rowsAffected);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.VoteLog GetModel(int vg_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@vg_id", SqlDbType.Int,4)};
			parameters[0].Value = vg_id;

			Tunnel.Model.VoteLog model=new Tunnel.Model.VoteLog();
			DataSet ds= DbHelperSQL.RunProcedure("UP_VoteLog_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["vg_id"].ToString()!="")
				{
					model.vg_id=int.Parse(ds.Tables[0].Rows[0]["vg_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vg_setDate"].ToString()!="")
				{
					model.vg_setDate=DateTime.Parse(ds.Tables[0].Rows[0]["vg_setDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vg_userId"].ToString()!="")
				{
					model.vg_userId=int.Parse(ds.Tables[0].Rows[0]["vg_userId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vg_voteId"].ToString()!="")
				{
					model.vg_voteId=int.Parse(ds.Tables[0].Rows[0]["vg_voteId"].ToString());
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
			strSql.Append("select vg_id,vg_setDate,vg_userId,vg_voteId ");
			strSql.Append(" FROM VoteLog ");
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
			strSql.Append(" vg_id,vg_setDate,vg_userId,vg_voteId ");
			strSql.Append(" FROM VoteLog ");
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
			parameters[0].Value = "VoteLog";
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

