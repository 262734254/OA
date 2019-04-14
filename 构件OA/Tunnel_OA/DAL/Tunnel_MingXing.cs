using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_MingXing。
	/// </summary>
	public class Tunnel_MingXing
	{
		public Tunnel_MingXing()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("m_id", "Tunnel_MingXing"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int m_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,4)};
			parameters[0].Value = m_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_MingXing_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_MingXing model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@m_uid", SqlDbType.Int,4),
					new SqlParameter("@m_img", SqlDbType.VarChar,50),
					new SqlParameter("@m_content", SqlDbType.VarChar,2000),
					new SqlParameter("@m_year", SqlDbType.Int,4),
					new SqlParameter("@m_moon", SqlDbType.Int,4),
                    new SqlParameter("@m_title",SqlDbType.VarChar,100)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.m_uid;
			parameters[2].Value = model.m_img;
			parameters[3].Value = model.m_content;
			parameters[4].Value = model.m_year;
			parameters[5].Value = model.m_moon;
            parameters[6].Value = model.Title;

			DbHelperSQL.RunProcedure("UP_Tunnel_MingXing_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_MingXing model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,4),
					new SqlParameter("@m_uid", SqlDbType.Int,4),
					new SqlParameter("@m_img", SqlDbType.VarChar,50),
					new SqlParameter("@m_content", SqlDbType.VarChar,2000),
					new SqlParameter("@m_year", SqlDbType.Int,4),
					new SqlParameter("@m_moon", SqlDbType.Int,4),
                    new SqlParameter("@m_title",SqlDbType.VarChar,100)};
			parameters[0].Value = model.m_id;
			parameters[1].Value = model.m_uid;
			parameters[2].Value = model.m_img;
			parameters[3].Value = model.m_content;
			parameters[4].Value = model.m_year;
			parameters[5].Value = model.m_moon;
            parameters[6].Value = model.Title;

			DbHelperSQL.RunProcedure("UP_Tunnel_MingXing_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int m_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,4)};
			parameters[0].Value = m_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_MingXing_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_MingXing GetModel(int m_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,4)};
			parameters[0].Value = m_id;

			Tunnel.Model.Tunnel_MingXing model=new Tunnel.Model.Tunnel_MingXing();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_MingXing_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_id"].ToString()!="")
				{
					model.m_id=int.Parse(ds.Tables[0].Rows[0]["m_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_uid"].ToString()!="")
				{
					model.m_uid=int.Parse(ds.Tables[0].Rows[0]["m_uid"].ToString());
				}
				model.m_img=ds.Tables[0].Rows[0]["m_img"].ToString();
				model.m_content=ds.Tables[0].Rows[0]["m_content"].ToString();
               
				if(ds.Tables[0].Rows[0]["m_year"].ToString()!="")
				{
					model.m_year=int.Parse(ds.Tables[0].Rows[0]["m_year"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_moon"].ToString()!="")
				{
					model.m_moon=int.Parse(ds.Tables[0].Rows[0]["m_moon"].ToString());
				}
                model.Title = ds.Tables[0].Rows[0]["m_title"].ToString();
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
			strSql.Append("select  m_id,m_uid,m_img,m_content,m_year,m_moon,m_title ");
			strSql.Append(" FROM Tunnel_MingXing ");
            
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListMingXing(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 3 m_id,m_uid,m_img,m_content,m_year,m_moon,m_title ");
            strSql.Append(" FROM Tunnel_MingXing ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
			strSql.Append(" m_id,m_uid,m_img,m_content,m_year,m_moon,m_title ");
			strSql.Append(" FROM Tunnel_MingXing ");
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
			parameters[0].Value = "Tunnel_MingXing";
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

