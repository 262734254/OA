using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_Chat。
	/// </summary>
	public class Tunnel_Chat
	{
		public Tunnel_Chat()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Chat_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tunnel_Chat");
			strSql.Append(" where Chat_ID=@Chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Chat_ID", SqlDbType.BigInt)};
			parameters[0].Value = Chat_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_Chat model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tunnel_Chat(");
			strSql.Append("Chat_UserID,Chat_UserName,Chat_Content,Chat_Date,Chat_State,Chat_ToUserID)");
			strSql.Append(" values (");
			strSql.Append("@Chat_UserID,@Chat_UserName,@Chat_Content,@Chat_Date,@Chat_State,@Chat_ToUserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Chat_UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Chat_UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Chat_Content", SqlDbType.VarChar,200),
					new SqlParameter("@Chat_Date", SqlDbType.DateTime),
					new SqlParameter("@Chat_State", SqlDbType.Int,4),
					new SqlParameter("@Chat_ToUserID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Chat_UserID;
			parameters[1].Value = model.Chat_UserName;
			parameters[2].Value = model.Chat_Content;
			parameters[3].Value = model.Chat_Date;
			parameters[4].Value = model.Chat_State;
			parameters[5].Value = model.Chat_ToUserID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Chat model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tunnel_Chat set ");
			strSql.Append("Chat_UserID=@Chat_UserID,");
			strSql.Append("Chat_UserName=@Chat_UserName,");
			strSql.Append("Chat_Content=@Chat_Content,");
			strSql.Append("Chat_Date=@Chat_Date,");
			strSql.Append("Chat_State=@Chat_State,");
			strSql.Append("Chat_ToUserID=@Chat_ToUserID");
			strSql.Append(" where Chat_ID=@Chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Chat_ID", SqlDbType.BigInt,8),
					new SqlParameter("@Chat_UserID", SqlDbType.BigInt,8),
					new SqlParameter("@Chat_UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Chat_Content", SqlDbType.VarChar,200),
					new SqlParameter("@Chat_Date", SqlDbType.DateTime),
					new SqlParameter("@Chat_State", SqlDbType.Int,4),
					new SqlParameter("@Chat_ToUserID", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Chat_ID;
			parameters[1].Value = model.Chat_UserID;
			parameters[2].Value = model.Chat_UserName;
			parameters[3].Value = model.Chat_Content;
			parameters[4].Value = model.Chat_Date;
			parameters[5].Value = model.Chat_State;
			parameters[6].Value = model.Chat_ToUserID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long Chat_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tunnel_Chat ");
			strSql.Append(" where Chat_ID=@Chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Chat_ID", SqlDbType.BigInt)};
			parameters[0].Value = Chat_ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Chat GetModel(long Chat_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Chat_ID,Chat_UserID,Chat_UserName,Chat_Content,Chat_Date,Chat_State,Chat_ToUserID from Tunnel_Chat ");
			strSql.Append(" where Chat_ID=@Chat_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Chat_ID", SqlDbType.BigInt)};
			parameters[0].Value = Chat_ID;

			Tunnel.Model.Tunnel_Chat model=new Tunnel.Model.Tunnel_Chat();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Chat_ID"].ToString()!="")
				{
					model.Chat_ID=long.Parse(ds.Tables[0].Rows[0]["Chat_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Chat_UserID"].ToString()!="")
				{
					model.Chat_UserID=long.Parse(ds.Tables[0].Rows[0]["Chat_UserID"].ToString());
				}
				model.Chat_UserName=ds.Tables[0].Rows[0]["Chat_UserName"].ToString();
				model.Chat_Content=ds.Tables[0].Rows[0]["Chat_Content"].ToString();
				if(ds.Tables[0].Rows[0]["Chat_Date"].ToString()!="")
				{
					model.Chat_Date=DateTime.Parse(ds.Tables[0].Rows[0]["Chat_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Chat_State"].ToString()!="")
				{
					model.Chat_State=int.Parse(ds.Tables[0].Rows[0]["Chat_State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Chat_ToUserID"].ToString()!="")
				{
					model.Chat_ToUserID=long.Parse(ds.Tables[0].Rows[0]["Chat_ToUserID"].ToString());
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
			strSql.Append("select Chat_ID,Chat_UserID,Chat_UserName,Chat_Content,Chat_Date,Chat_State,Chat_ToUserID ");
			strSql.Append(" FROM Tunnel_Chat ");
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
			strSql.Append(" Chat_ID,Chat_UserID,Chat_UserName,Chat_Content,Chat_Date,Chat_State,Chat_ToUserID ");
			strSql.Append(" FROM Tunnel_Chat ");
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
			parameters[0].Value = "Tunnel_Chat";
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

