using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_meeting。
	/// </summary>
	public class Tunnel_meeting
	{
		public Tunnel_meeting()
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

			int result= DbHelperSQL.RunProcedure("Tunnel_meeting_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_meeting model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,8),
					new SqlParameter("@m_title", SqlDbType.VarChar,200),
					new SqlParameter("@m_content", SqlDbType.Text),
					new SqlParameter("@m_menber", SqlDbType.VarChar,1000),
					new SqlParameter("@m_startime", SqlDbType.DateTime),
					new SqlParameter("@m_endtime", SqlDbType.DateTime),
					new SqlParameter("@m_user", SqlDbType.Int,4),
					new SqlParameter("@m_state", SqlDbType.Int,4),
                    new SqlParameter("@m_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.m_title;
			parameters[2].Value = model.m_content;
			parameters[3].Value = model.m_menber;
			parameters[4].Value = model.m_startime;
			parameters[5].Value = model.m_endtime;
			parameters[6].Value = model.m_user;
			parameters[7].Value = model.m_state;
            parameters[8].Value = model.m_Ip;

			DbHelperSQL.RunProcedure("Tunnel_meeting_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public int Update(Tunnel.Model.Tunnel_meeting model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt,8),
					new SqlParameter("@m_title", SqlDbType.VarChar,200),
					new SqlParameter("@m_content", SqlDbType.Text),
					new SqlParameter("@m_menber", SqlDbType.VarChar,1000),
					new SqlParameter("@m_startime", SqlDbType.DateTime),
					new SqlParameter("@m_endtime", SqlDbType.DateTime),
					new SqlParameter("@m_user", SqlDbType.Int,4),
					new SqlParameter("@m_state", SqlDbType.Int,4),
                    new SqlParameter("@m_ip", SqlDbType.VarChar,20)
            };
			parameters[0].Value = model.m_id;
			parameters[1].Value = model.m_title;
			parameters[2].Value = model.m_content;
			parameters[3].Value = model.m_menber;
			parameters[4].Value = model.m_startime;
			parameters[5].Value = model.m_endtime;
			parameters[6].Value = model.m_user;
			parameters[7].Value = model.m_state;
            parameters[8].Value = model.m_Ip;

            int relt = -1;
            relt = DbHelperSQL.RunProcedure("Tunnel_meeting_Update", parameters, out rowsAffected);
            return relt;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(long m_id, int m_user, string m_ip)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt),
                    new SqlParameter("@m_user", SqlDbType.Int),
                    new SqlParameter("@m_ip", SqlDbType.VarChar, 20)
            };
			parameters[0].Value = m_id;
            parameters[1].Value = m_user;
            parameters[2].Value = m_ip;
            int relt = -1;
			relt = DbHelperSQL.RunProcedure("Tunnel_meeting_Delete",parameters,out rowsAffected);
            return relt;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_meeting GetModel(long m_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
			parameters[0].Value = m_id;

			Tunnel.Model.Tunnel_meeting model=new Tunnel.Model.Tunnel_meeting();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_meeting_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["m_id"].ToString()!="")
				{
					model.m_id=long.Parse(ds.Tables[0].Rows[0]["m_id"].ToString());
				}
				model.m_title=ds.Tables[0].Rows[0]["m_title"].ToString();
				model.m_content=ds.Tables[0].Rows[0]["m_content"].ToString();
				model.m_menber=ds.Tables[0].Rows[0]["m_menber"].ToString();
				if(ds.Tables[0].Rows[0]["m_startime"].ToString()!="")
				{
					model.m_startime=DateTime.Parse(ds.Tables[0].Rows[0]["m_startime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_endtime"].ToString()!="")
				{
					model.m_endtime=DateTime.Parse(ds.Tables[0].Rows[0]["m_endtime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_user"].ToString()!="")
				{
					model.m_user=int.Parse(ds.Tables[0].Rows[0]["m_user"].ToString());
				}
				if(ds.Tables[0].Rows[0]["m_state"].ToString()!="")
				{
					model.m_state=int.Parse(ds.Tables[0].Rows[0]["m_state"].ToString());
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
			strSql.Append("select m_id,m_title,m_content,m_menber,m_startime,m_endtime,m_user,m_state ");
			strSql.Append(" FROM Tunnel_meeting ");
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
			strSql.Append(" m_id,m_title,m_content,m_menber,m_startime,m_endtime,m_user,m_state ");
			strSql.Append(" FROM Tunnel_meeting ");
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

