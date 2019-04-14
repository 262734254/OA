using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_projectlog。
	/// </summary>
	public class Tunnel_projectlog
	{
		public Tunnel_projectlog()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long pl_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@pl_id", SqlDbType.BigInt)};
			parameters[0].Value = pl_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_projectlog_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_projectlog model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@pl_id", SqlDbType.Int,8),
					new SqlParameter("@pl_title", SqlDbType.VarChar,200),
					new SqlParameter("@pl_content", SqlDbType.Text),
					new SqlParameter("@pl_time", SqlDbType.DateTime),
					new SqlParameter("@pl_user", SqlDbType.Int,4),
                    new SqlParameter("@pl_ip", SqlDbType.VarChar,20),
            };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.pl_title;
			parameters[2].Value = model.pl_content;
			parameters[3].Value = model.pl_time;
			parameters[4].Value = model.pl_user;
            parameters[5].Value = model.pl_Ip;

			DbHelperSQL.RunProcedure("Tunnel_projectlog_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_projectlog model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@pl_id", SqlDbType.BigInt,8),
					new SqlParameter("@pl_title", SqlDbType.VarChar,200),
					new SqlParameter("@pl_content", SqlDbType.Text),
					new SqlParameter("@pl_time", SqlDbType.DateTime),
					new SqlParameter("@pl_user", SqlDbType.Int,4),
                    new SqlParameter("@pl_ip", SqlDbType.VarChar,20),
            };
			parameters[0].Value = model.pl_id;
			parameters[1].Value = model.pl_title;
			parameters[2].Value = model.pl_content;
			parameters[3].Value = model.pl_time;
			parameters[4].Value = model.pl_user;
            parameters[5].Value = model.pl_Ip;

			DbHelperSQL.RunProcedure("Tunnel_projectlog_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(long pl_id,int pl_user,string pl_ip)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@pl_id", SqlDbType.BigInt),
                    new SqlParameter("@pl_user", SqlDbType.Int),
                    new SqlParameter("@pl_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Value = pl_id;
            parameters[1].Value = pl_user;
            parameters[2].Value = pl_ip;

			return  DbHelperSQL.RunProcedure("Tunnel_projectlog_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_projectlog GetModel(long pl_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@pl_id", SqlDbType.BigInt)};
			parameters[0].Value = pl_id;

			Tunnel.Model.Tunnel_projectlog model=new Tunnel.Model.Tunnel_projectlog();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_projectlog_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["pl_id"].ToString()!="")
				{
					model.pl_id=long.Parse(ds.Tables[0].Rows[0]["pl_id"].ToString());
				}
				model.pl_title=ds.Tables[0].Rows[0]["pl_title"].ToString();
				model.pl_content=ds.Tables[0].Rows[0]["pl_content"].ToString();
				if(ds.Tables[0].Rows[0]["pl_time"].ToString()!="")
				{
					model.pl_time=DateTime.Parse(ds.Tables[0].Rows[0]["pl_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pl_user"].ToString()!="")
				{
					model.pl_user=int.Parse(ds.Tables[0].Rows[0]["pl_user"].ToString());
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
			strSql.Append("select pl_id,pl_title,pl_content,pl_time,pl_user ");
			strSql.Append(" FROM Tunnel_projectlog ");
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
			strSql.Append(" pl_id,pl_title,pl_content,pl_time,pl_user ");
			strSql.Append(" FROM Tunnel_projectlog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
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

		#endregion  成员方法
	}
}

