using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;

namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_anpai。
	/// </summary>
	public class Tunnel_anpai
	{
		public Tunnel_anpai()
		{}
		#region  成员方法

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总条数</param>
        /// <returns></returns>
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
                new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
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
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("a_id", "Tunnel_anpai"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int a_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.Int,4)};
			parameters[0].Value = a_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_anpai_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_anpai model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.Int,4),
					new SqlParameter("@a_title", SqlDbType.VarChar,50),
					new SqlParameter("@a_content", SqlDbType.VarChar,500),
					new SqlParameter("@a_date", SqlDbType.DateTime),
					new SqlParameter("@a_ampm", SqlDbType.VarChar,50),
					new SqlParameter("@a_userId", SqlDbType.Int,4),
					new SqlParameter("@a_createDate", SqlDbType.DateTime)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.a_title;
			parameters[2].Value = model.a_content;
			parameters[3].Value = model.a_date;
			parameters[4].Value = model.a_ampm;
			parameters[5].Value = model.a_userId;
			parameters[6].Value = model.a_createDate;

			DbHelperSQL.RunProcedure("UP_Tunnel_anpai_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_anpai model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.Int,4),
					new SqlParameter("@a_title", SqlDbType.VarChar,50),
					new SqlParameter("@a_content", SqlDbType.VarChar,500),
					new SqlParameter("@a_date", SqlDbType.DateTime),
					new SqlParameter("@a_ampm", SqlDbType.VarChar,50),
					new SqlParameter("@a_userId", SqlDbType.Int,4),
					new SqlParameter("@a_createDate", SqlDbType.DateTime)};
			parameters[0].Value = model.a_id;
			parameters[1].Value = model.a_title;
			parameters[2].Value = model.a_content;
			parameters[3].Value = model.a_date;
			parameters[4].Value = model.a_ampm;
			parameters[5].Value = model.a_userId;
			parameters[6].Value = model.a_createDate;

			DbHelperSQL.RunProcedure("UP_Tunnel_anpai_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int a_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.Int,4)};
			parameters[0].Value = a_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_anpai_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_anpai GetModel(int a_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.Int,4)};
			parameters[0].Value = a_id;

			Tunnel.Model.Tunnel_anpai model=new Tunnel.Model.Tunnel_anpai();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_anpai_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["a_id"].ToString()!="")
				{
					model.a_id=int.Parse(ds.Tables[0].Rows[0]["a_id"].ToString());
				}
				model.a_title=ds.Tables[0].Rows[0]["a_title"].ToString();
				model.a_content=ds.Tables[0].Rows[0]["a_content"].ToString();
				if(ds.Tables[0].Rows[0]["a_date"].ToString()!="")
				{
					model.a_date=DateTime.Parse(ds.Tables[0].Rows[0]["a_date"].ToString());
				}
				model.a_ampm=ds.Tables[0].Rows[0]["a_ampm"].ToString();
				if(ds.Tables[0].Rows[0]["a_userId"].ToString()!="")
				{
					model.a_userId=int.Parse(ds.Tables[0].Rows[0]["a_userId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["a_createDate"].ToString()!="")
				{
					model.a_createDate=DateTime.Parse(ds.Tables[0].Rows[0]["a_createDate"].ToString());
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
			strSql.Append("select a_id,a_title,a_content,a_date,a_ampm,a_userId,a_createDate ");
			strSql.Append(" FROM Tunnel_anpai ");
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
			strSql.Append(" a_id,a_title,a_content,a_date,a_ampm,a_userId,a_createDate ");
			strSql.Append(" FROM Tunnel_anpai ");
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
			parameters[0].Value = "Tunnel_anpai";
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

