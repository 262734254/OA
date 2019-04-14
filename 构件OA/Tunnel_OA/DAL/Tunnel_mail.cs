using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_mail。
	/// </summary>
	public class Tunnel_mail
	{
		public Tunnel_mail()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long m_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
			parameters[0].Value = m_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_mail_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_mail model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,8),
					new SqlParameter("@m_title", SqlDbType.VarChar,200),
					new SqlParameter("@m_content", SqlDbType.Text),
					new SqlParameter("@m_from", SqlDbType.Int,4),
					new SqlParameter("@m_to", SqlDbType.VarChar,1000),
					new SqlParameter("@m_file", SqlDbType.VarChar,1000),
					new SqlParameter("@m_time", SqlDbType.DateTime),
					new SqlParameter("@m_sort", SqlDbType.Int,4),
					new SqlParameter("@m_state", SqlDbType.Int,4),
                    new SqlParameter("@m_main", SqlDbType.Int,4),
                    new SqlParameter("@m_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.m_title;
			parameters[2].Value = model.m_content;
			parameters[3].Value = model.m_from;
			parameters[4].Value = model.m_to;
			parameters[5].Value = model.m_file;
			parameters[6].Value = model.m_time;
			parameters[7].Value = model.m_sort;
			parameters[8].Value = model.m_state;
            parameters[9].Value = model.m_Main;
            parameters[10].Value = model.m_Ip;

			DbHelperSQL.RunProcedure("Tunnel_mail_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public int Update(Tunnel.Model.Tunnel_mail model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt,8),
                    //new SqlParameter("@m_title", SqlDbType.VarChar,200),
                    //new SqlParameter("@m_content", SqlDbType.Text),
                    //new SqlParameter("@m_from", SqlDbType.Int,4),
                    //new SqlParameter("@m_to", SqlDbType.Int,4),
                    //new SqlParameter("@m_file", SqlDbType.VarChar,1000),
                    //new SqlParameter("@m_time", SqlDbType.DateTime),
					new SqlParameter("@m_sort", SqlDbType.Int,4),
					new SqlParameter("@m_state", SqlDbType.Int,4),
                    new SqlParameter("@m_user", SqlDbType.Int,4),
                    new SqlParameter("@m_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Value = model.m_id;
            //parameters[1].Value = model.m_title;
            //parameters[2].Value = model.m_content;
            //parameters[3].Value = model.m_from;
            //parameters[4].Value = model.m_to;
            //parameters[5].Value = model.m_file;
            //parameters[6].Value = model.m_time;
			parameters[1].Value = model.m_sort;
			parameters[2].Value = model.m_state;
            parameters[3].Value = model.m_from;
            parameters[4].Value = model.m_Ip;


			return  DbHelperSQL.RunProcedure("Tunnel_mail_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long m_id, int m_user, string m_ip, ref int num)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt),
                    new SqlParameter("@m_user", SqlDbType.Int),
                    new SqlParameter("@m_ip", SqlDbType.VarChar,20),
                    new SqlParameter("@num", SqlDbType.Int)
            };
			parameters[0].Value = m_id;
            parameters[1].Value = m_user;
            parameters[2].Value = m_ip;
            parameters[3].Direction = ParameterDirection.Output;

			DbHelperSQL.RunProcedure("Tunnel_mail_Delete",parameters,out rowsAffected);
            if (!string.IsNullOrEmpty(parameters[3].Value.ToString()))
                num = Convert.ToInt32(parameters[3].Value.ToString());
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_mail GetModel(long m_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
			parameters[0].Value = m_id;

			Tunnel.Model.Tunnel_mail model=new Tunnel.Model.Tunnel_mail();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_mail_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_id"].ToString()!="")
				{
					model.m_id=long.Parse(ds.Tables[0].Rows[0]["m_id"].ToString());
				}
				model.m_title=ds.Tables[0].Rows[0]["m_title"].ToString();
				model.m_content=ds.Tables[0].Rows[0]["m_content"].ToString();
				if(ds.Tables[0].Rows[0]["m_from"].ToString()!="")
				{
					model.m_from=int.Parse(ds.Tables[0].Rows[0]["m_from"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_to"].ToString()!="")
				{
					model.m_to=int.Parse(ds.Tables[0].Rows[0]["m_to"].ToString());
				}
				model.m_file=ds.Tables[0].Rows[0]["m_file"].ToString();
				if(ds.Tables[0].Rows[0]["m_time"].ToString()!="")
				{
					model.m_time=DateTime.Parse(ds.Tables[0].Rows[0]["m_time"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_sort"].ToString()!="")
				{
					model.m_sort=int.Parse(ds.Tables[0].Rows[0]["m_sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_state"].ToString()!="")
				{
					model.m_state=int.Parse(ds.Tables[0].Rows[0]["m_state"].ToString());
				}
                if (ds.Tables[0].Rows[0]["m_main"].ToString() != "")
                {
                    model.m_Main = int.Parse(ds.Tables[0].Rows[0]["m_main"].ToString());
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
			strSql.Append("select m_id,m_title,m_content,m_from,m_to,m_file,m_time,m_sort,m_state ");
			strSql.Append(" FROM Tunnel_mail ");
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
			strSql.Append(" m_id,m_title,m_content,m_from,m_to,m_file,m_time,m_sort,m_state ");
			strSql.Append(" FROM Tunnel_mail ");
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

