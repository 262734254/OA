using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_VoteRe。
	/// </summary>
	public class Tunnel_VoteRe
	{
		public Tunnel_VoteRe()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("vote_Id", "Tunnel_VoteRe"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int vote_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4)};
			parameters[0].Value = vote_Id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_VoteRe_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_VoteRe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4),
					new SqlParameter("@vote_Message", SqlDbType.VarChar,3000),
					new SqlParameter("@vate_Date", SqlDbType.DateTime),
					new SqlParameter("@vate_userId", SqlDbType.Int,4),
					new SqlParameter("@vate_voteId", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.vote_Message;
			parameters[2].Value = model.vate_Date;
			parameters[3].Value = model.vate_userId;
			parameters[4].Value = model.vate_voteId;

			DbHelperSQL.RunProcedure("UP_Tunnel_VoteRe_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_VoteRe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4),
					new SqlParameter("@vote_Message", SqlDbType.VarChar,3000),
					new SqlParameter("@vate_Date", SqlDbType.DateTime),
					new SqlParameter("@vate_userId", SqlDbType.Int,4),
					new SqlParameter("@vate_voteId", SqlDbType.Int,4)};
			parameters[0].Value = model.vote_Id;
			parameters[1].Value = model.vote_Message;
			parameters[2].Value = model.vate_Date;
			parameters[3].Value = model.vate_userId;
			parameters[4].Value = model.vate_voteId;

			DbHelperSQL.RunProcedure("UP_Tunnel_VoteRe_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int vote_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4)};
			parameters[0].Value = vote_Id;

			DbHelperSQL.RunProcedure("UP_Tunnel_VoteRe_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_VoteRe GetModel(int vote_Id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4)};
			parameters[0].Value = vote_Id;

			Tunnel.Model.Tunnel_VoteRe model=new Tunnel.Model.Tunnel_VoteRe();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_VoteRe_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["vote_Id"].ToString()!="")
				{
					model.vote_Id=int.Parse(ds.Tables[0].Rows[0]["vote_Id"].ToString());
				}
				model.vote_Message=ds.Tables[0].Rows[0]["vote_Message"].ToString();
				if(ds.Tables[0].Rows[0]["vate_Date"].ToString()!="")
				{
					model.vate_Date=DateTime.Parse(ds.Tables[0].Rows[0]["vate_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vate_userId"].ToString()!="")
				{
					model.vate_userId=int.Parse(ds.Tables[0].Rows[0]["vate_userId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vate_voteId"].ToString()!="")
				{
					model.vate_voteId=int.Parse(ds.Tables[0].Rows[0]["vate_voteId"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}
        public DataSet GetList(PageBase pb, ref int count)
        {
            SqlParameter[] parameters = 
            {
                new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 255),
                new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar,1000)                
            };
            parameters[0].Value = pb.TblName;
            parameters[1].Value = pb.StrGetFields;
            parameters[2].Value = pb.FldName;
            parameters[3].Value = pb.PageSize;
            parameters[4].Value = pb.PageIndex;
            parameters[5].Value = pb.DoCount;
            parameters[6].Value = pb.OrderType;
            parameters[7].Value = pb.StrWhere;

            DataSet ds = new DataSet();
            ds = DbHelperSQL.RunProcedure(pb.ProcedureName, parameters, "ds");
            if (pb.DoCount == 1)
            {
                if (ds.Tables.Count == 1)
                    count = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            }
            return ds;
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select vote_Id,vote_Message,vate_Date,vate_userId,vate_voteId ");
			strSql.Append(" FROM Tunnel_VoteRe ");
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
			strSql.Append(" vote_Id,vote_Message,vate_Date,vate_userId,vate_voteId ");
			strSql.Append(" FROM Tunnel_VoteRe ");
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
			parameters[0].Value = "Tunnel_VoteRe";
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

