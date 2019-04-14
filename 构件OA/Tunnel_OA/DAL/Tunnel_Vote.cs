using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_Vote。
	/// </summary>
	public class Tunnel_Vote
	{
		public Tunnel_Vote()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("vote_Id", "Tunnel_Vote"); 
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

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_Vote_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_Vote model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4),
					new SqlParameter("@vote_userId", SqlDbType.Int,4),
					new SqlParameter("@vote_userGroup", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_bumGroup", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_jsGroup", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_Title", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_mark", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_Type", SqlDbType.Int,4),
					new SqlParameter("@vote_startDate", SqlDbType.DateTime),
					new SqlParameter("@vote_endDate", SqlDbType.DateTime),
					new SqlParameter("@vote_seeType", SqlDbType.Int,4),
					new SqlParameter("@vote_state", SqlDbType.Int,4),
					new SqlParameter("@vote_max", SqlDbType.Int,4),
					new SqlParameter("@vote_top", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.vote_userId;
			parameters[2].Value = model.vote_userGroup;
			parameters[3].Value = model.vote_bumGroup;
			parameters[4].Value = model.vote_jsGroup;
			parameters[5].Value = model.vote_Title;
			parameters[6].Value = model.vote_mark;
			parameters[7].Value = model.vote_Type;
			parameters[8].Value = model.vote_startDate;
			parameters[9].Value = model.vote_endDate;
			parameters[10].Value = model.vote_seeType;
			parameters[11].Value = model.vote_state;
			parameters[12].Value = model.vote_max;
			parameters[13].Value = model.vote_top;

			DbHelperSQL.RunProcedure("UP_Tunnel_Vote_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Vote model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4),
					new SqlParameter("@vote_userId", SqlDbType.Int,4),
					new SqlParameter("@vote_userGroup", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_bumGroup", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_jsGroup", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_Title", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_mark", SqlDbType.VarChar,3000),
					new SqlParameter("@vote_Type", SqlDbType.Int,4),
					new SqlParameter("@vote_startDate", SqlDbType.DateTime),
					new SqlParameter("@vote_endDate", SqlDbType.DateTime),
					new SqlParameter("@vote_seeType", SqlDbType.Int,4),
					new SqlParameter("@vote_state", SqlDbType.Int,4),
					new SqlParameter("@vote_max", SqlDbType.Int,4),
					new SqlParameter("@vote_top", SqlDbType.Int,4)};
			parameters[0].Value = model.vote_Id;
			parameters[1].Value = model.vote_userId;
			parameters[2].Value = model.vote_userGroup;
			parameters[3].Value = model.vote_bumGroup;
			parameters[4].Value = model.vote_jsGroup;
			parameters[5].Value = model.vote_Title;
			parameters[6].Value = model.vote_mark;
			parameters[7].Value = model.vote_Type;
			parameters[8].Value = model.vote_startDate;
			parameters[9].Value = model.vote_endDate;
			parameters[10].Value = model.vote_seeType;
			parameters[11].Value = model.vote_state;
			parameters[12].Value = model.vote_max;
			parameters[13].Value = model.vote_top;

			DbHelperSQL.RunProcedure("UP_Tunnel_Vote_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_Tunnel_Vote_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Vote GetModel(int vote_Id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@vote_Id", SqlDbType.Int,4)};
			parameters[0].Value = vote_Id;

			Tunnel.Model.Tunnel_Vote model=new Tunnel.Model.Tunnel_Vote();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_Vote_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["vote_Id"].ToString()!="")
				{
					model.vote_Id=int.Parse(ds.Tables[0].Rows[0]["vote_Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vote_userId"].ToString()!="")
				{
					model.vote_userId=int.Parse(ds.Tables[0].Rows[0]["vote_userId"].ToString());
				}
				model.vote_userGroup=ds.Tables[0].Rows[0]["vote_userGroup"].ToString();
				model.vote_bumGroup=ds.Tables[0].Rows[0]["vote_bumGroup"].ToString();
				model.vote_jsGroup=ds.Tables[0].Rows[0]["vote_jsGroup"].ToString();
				model.vote_Title=ds.Tables[0].Rows[0]["vote_Title"].ToString();
				model.vote_mark=ds.Tables[0].Rows[0]["vote_mark"].ToString();
				if(ds.Tables[0].Rows[0]["vote_Type"].ToString()!="")
				{
					model.vote_Type=int.Parse(ds.Tables[0].Rows[0]["vote_Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vote_startDate"].ToString()!="")
				{
					model.vote_startDate=DateTime.Parse(ds.Tables[0].Rows[0]["vote_startDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vote_endDate"].ToString()!="")
				{
					model.vote_endDate=DateTime.Parse(ds.Tables[0].Rows[0]["vote_endDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vote_seeType"].ToString()!="")
				{
					model.vote_seeType=int.Parse(ds.Tables[0].Rows[0]["vote_seeType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vote_state"].ToString()!="")
				{
					model.vote_state=int.Parse(ds.Tables[0].Rows[0]["vote_state"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vote_max"].ToString()!="")
				{
					model.vote_max=int.Parse(ds.Tables[0].Rows[0]["vote_max"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vote_top"].ToString()!="")
				{
					model.vote_top=int.Parse(ds.Tables[0].Rows[0]["vote_top"].ToString());
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
			strSql.Append("select vote_Id,vote_userId,vote_userGroup,vote_bumGroup,vote_jsGroup,vote_Title,vote_mark,vote_Type,vote_startDate,vote_endDate,vote_seeType,vote_state,vote_max,vote_top ");
			strSql.Append(" FROM Tunnel_Vote ");
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
			strSql.Append(" vote_Id,vote_userId,vote_userGroup,vote_bumGroup,vote_jsGroup,vote_Title,vote_mark,vote_Type,vote_startDate,vote_endDate,vote_seeType,vote_state,vote_max,vote_top ");
			strSql.Append(" FROM Tunnel_Vote ");
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
			parameters[0].Value = "Tunnel_Vote";
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

