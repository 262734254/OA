using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_Img。
	/// </summary>
	public class Tunnel_Img
	{
		public Tunnel_Img()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("i_id", "Tunnel_Img"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int i_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tunnel_Img");
			strSql.Append(" where i_id=@i_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4)};
			parameters[0].Value = i_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_Img model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tunnel_Img(");
			strSql.Append("i_name,i_uri,i_date,i_user,i_type,i_year)");
			strSql.Append(" values (");
			strSql.Append("@i_name,@i_uri,@i_date,@i_user,@i_type,@i_year)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@i_name", SqlDbType.VarChar,50),
					new SqlParameter("@i_uri", SqlDbType.VarChar,50),
					new SqlParameter("@i_date", SqlDbType.DateTime),
					new SqlParameter("@i_user", SqlDbType.Int,4),
					new SqlParameter("@i_type", SqlDbType.VarChar,50),
					new SqlParameter("@i_year", SqlDbType.VarChar,5)};
			parameters[0].Value = model.i_name;
			parameters[1].Value = model.i_uri;
			parameters[2].Value = model.i_date;
			parameters[3].Value = model.i_user;
			parameters[4].Value = model.i_type;
			parameters[5].Value = model.i_year;

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
		public void Update(Tunnel.Model.Tunnel_Img model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tunnel_Img set ");
			strSql.Append("i_name=@i_name,");
			strSql.Append("i_uri=@i_uri,");
			strSql.Append("i_date=@i_date,");
			strSql.Append("i_user=@i_user,");
			strSql.Append("i_type=@i_type,");
			strSql.Append("i_year=@i_year");
			strSql.Append(" where i_id=@i_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4),
					new SqlParameter("@i_name", SqlDbType.VarChar,50),
					new SqlParameter("@i_uri", SqlDbType.VarChar,50),
					new SqlParameter("@i_date", SqlDbType.DateTime),
					new SqlParameter("@i_user", SqlDbType.Int,4),
					new SqlParameter("@i_type", SqlDbType.VarChar,50),
					new SqlParameter("@i_year", SqlDbType.VarChar,5)};
			parameters[0].Value = model.i_id;
			parameters[1].Value = model.i_name;
			parameters[2].Value = model.i_uri;
			parameters[3].Value = model.i_date;
			parameters[4].Value = model.i_user;
			parameters[5].Value = model.i_type;
			parameters[6].Value = model.i_year;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int i_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tunnel_Img ");
			strSql.Append(" where i_id=@i_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4)};
			parameters[0].Value = i_id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Img GetModel(int i_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 i_id,i_name,i_uri,i_date,i_user,i_type,i_year from Tunnel_Img ");
			strSql.Append(" where i_id=@i_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4)};
			parameters[0].Value = i_id;

			Tunnel.Model.Tunnel_Img model=new Tunnel.Model.Tunnel_Img();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["i_id"].ToString()!="")
				{
					model.i_id=int.Parse(ds.Tables[0].Rows[0]["i_id"].ToString());
				}
				model.i_name=ds.Tables[0].Rows[0]["i_name"].ToString();
				model.i_uri=ds.Tables[0].Rows[0]["i_uri"].ToString();
				if(ds.Tables[0].Rows[0]["i_date"].ToString()!="")
				{
					model.i_date=DateTime.Parse(ds.Tables[0].Rows[0]["i_date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_user"].ToString()!="")
				{
					model.i_user=int.Parse(ds.Tables[0].Rows[0]["i_user"].ToString());
				}
				model.i_type=ds.Tables[0].Rows[0]["i_type"].ToString();
				model.i_year=ds.Tables[0].Rows[0]["i_year"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select i_id,i_name,i_uri,i_date,i_user,i_type,i_year ");
			strSql.Append(" FROM Tunnel_Img ");
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
			strSql.Append(" i_id,i_name,i_uri,i_date,i_user,i_type,i_year ");
			strSql.Append(" FROM Tunnel_Img ");
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
			parameters[0].Value = "Tunnel_Img";
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

