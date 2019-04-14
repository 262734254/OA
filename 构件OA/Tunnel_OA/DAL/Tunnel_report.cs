using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_report。
	/// </summary>
	public class Tunnel_report
	{
		public Tunnel_report()
		{}

		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long r_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.BigInt)};
			parameters[0].Value = r_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_report_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_report model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.Int,8),
					new SqlParameter("@r_title", SqlDbType.VarChar,200),
					new SqlParameter("@r_file", SqlDbType.VarChar,100),
					new SqlParameter("@r_time", SqlDbType.DateTime),
					new SqlParameter("@r_from", SqlDbType.Int,4),
					new SqlParameter("@r_user", SqlDbType.Int,4),
                    new SqlParameter("@r_content", SqlDbType.VarChar,2000),
                    new SqlParameter("@r_toemail", SqlDbType.VarChar,200),
                    new SqlParameter("@r_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.r_title;
			parameters[2].Value = model.r_file;
			parameters[3].Value = model.r_time;
			parameters[4].Value = model.r_from;
			parameters[5].Value = model.r_user;
            parameters[6].Value = model.r_Content;
            parameters[7].Value = model.r_toEmail;
            parameters[8].Value = model.r_Ip;


			DbHelperSQL.RunProcedure("Tunnel_report_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_report model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.BigInt,8),
					new SqlParameter("@r_title", SqlDbType.VarChar,200),
					new SqlParameter("@r_file", SqlDbType.VarChar,100),
					new SqlParameter("@r_time", SqlDbType.DateTime),
					new SqlParameter("@r_from", SqlDbType.Int,4),
					new SqlParameter("@r_user", SqlDbType.Int,4),
                    new SqlParameter("@r_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Value = model.r_id;
			parameters[1].Value = model.r_title;
			parameters[2].Value = model.r_file;
			parameters[3].Value = model.r_time;
			parameters[4].Value = model.r_from;
			parameters[5].Value = model.r_user;
            parameters[6].Value = model.r_Ip;

			DbHelperSQL.RunProcedure("Tunnel_report_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long r_id, int r_user, string r_ip)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.BigInt),
                    new SqlParameter("@r_user", SqlDbType.Int),
                    new SqlParameter("@r_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Value = r_id;
            parameters[1].Value = r_user;
            parameters[2].Value = r_ip;

			DbHelperSQL.RunProcedure("Tunnel_report_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_report GetModel(long r_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@r_id", SqlDbType.BigInt)};
			parameters[0].Value = r_id;

			Tunnel.Model.Tunnel_report model=new Tunnel.Model.Tunnel_report();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_report_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["r_id"].ToString()!="")
				{
					model.r_id=long.Parse(ds.Tables[0].Rows[0]["r_id"].ToString());
				}
				model.r_title=ds.Tables[0].Rows[0]["r_title"].ToString();
				model.r_file=ds.Tables[0].Rows[0]["r_file"].ToString();
				if(ds.Tables[0].Rows[0]["r_time"].ToString()!="")
				{
					model.r_time=DateTime.Parse(ds.Tables[0].Rows[0]["r_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["r_from"].ToString()!="")
				{
					model.r_from=int.Parse(ds.Tables[0].Rows[0]["r_from"].ToString());
				}
				if(ds.Tables[0].Rows[0]["r_user"].ToString()!="")
				{
					model.r_user=int.Parse(ds.Tables[0].Rows[0]["r_user"].ToString());
				}
                model.r_Content = ds.Tables[0].Rows[0]["r_content"].ToString();
                model.r_toEmail = ds.Tables[0].Rows[0]["r_toemail"].ToString();
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
			strSql.Append("select r_id,r_title,r_file,r_time,r_from,r_user ");
			strSql.Append(" FROM Tunnel_report ");
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
			strSql.Append(" r_id,r_title,r_file,r_time,r_from,r_user ");
			strSql.Append(" FROM Tunnel_report ");
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

