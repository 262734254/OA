using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类LeaveWord。
	/// </summary>
	public class LeaveWord
	{
		public LeaveWord()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("lw_Id", "LeaveWord"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int lw_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@lw_Id", SqlDbType.Int,4)};
			parameters[0].Value = lw_Id;

			int result= DbHelperSQL.RunProcedure("UP_LeaveWord_Exists",parameters,out rowsAffected);
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
		public void Add(Tunnel.Model.LeaveWord model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {					
					new SqlParameter("@lw_SetDate", SqlDbType.DateTime),
					new SqlParameter("@lw_Content", SqlDbType.NText),
					new SqlParameter("@lw_UserId", SqlDbType.Int,4),
					new SqlParameter("@lw_VateId", SqlDbType.Int,4)};			
			parameters[0].Value = model.lw_SetDate;
			parameters[1].Value = model.lw_Content;
			parameters[2].Value = model.lw_UserId;
			parameters[3].Value = model.lw_VateId;

			DbHelperSQL.RunProcedure("UP_LeaveWord_ADD",parameters,out rowsAffected);
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.LeaveWord model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@lw_Id", SqlDbType.Int,4),
					new SqlParameter("@lw_SetDate", SqlDbType.DateTime),
					new SqlParameter("@lw_Content", SqlDbType.NText),
					new SqlParameter("@lw_UserId", SqlDbType.Int,4),
					new SqlParameter("@lw_VateId", SqlDbType.Int,4)};
			parameters[0].Value = model.lw_Id;
			parameters[1].Value = model.lw_SetDate;
			parameters[2].Value = model.lw_Content;
			parameters[3].Value = model.lw_UserId;
			parameters[4].Value = model.lw_VateId;

			DbHelperSQL.RunProcedure("UP_LeaveWord_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int lw_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@lw_Id", SqlDbType.Int,4)};
			parameters[0].Value = lw_Id;

			DbHelperSQL.RunProcedure("UP_LeaveWord_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.LeaveWord GetModel(int lw_Id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@lw_Id", SqlDbType.Int,4)};
			parameters[0].Value = lw_Id;

			Tunnel.Model.LeaveWord model=new Tunnel.Model.LeaveWord();
			DataSet ds= DbHelperSQL.RunProcedure("UP_LeaveWord_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["lw_Id"].ToString()!="")
				{
					model.lw_Id=int.Parse(ds.Tables[0].Rows[0]["lw_Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lw_SetDate"].ToString()!="")
				{
					model.lw_SetDate=DateTime.Parse(ds.Tables[0].Rows[0]["lw_SetDate"].ToString());
				}
				model.lw_Content=ds.Tables[0].Rows[0]["lw_Content"].ToString();
				if(ds.Tables[0].Rows[0]["lw_UserId"].ToString()!="")
				{
					model.lw_UserId=int.Parse(ds.Tables[0].Rows[0]["lw_UserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["lw_VateId"].ToString()!="")
				{
					model.lw_VateId=int.Parse(ds.Tables[0].Rows[0]["lw_VateId"].ToString());
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
			strSql.Append("select lw_Id,lw_SetDate,lw_Content,lw_UserId,lw_VateId ");
			strSql.Append(" FROM LeaveWord ");
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
			strSql.Append(" lw_Id,lw_SetDate,lw_Content,lw_UserId,lw_VateId ");
			strSql.Append(" FROM LeaveWord ");
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
			parameters[0].Value = "LeaveWord";
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

