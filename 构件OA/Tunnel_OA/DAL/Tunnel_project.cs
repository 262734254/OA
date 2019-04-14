using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_project。
	/// </summary>
	public class Tunnel_project
	{
		public Tunnel_project()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long p_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.BigInt)};
			parameters[0].Value = p_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_project_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_project model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.Int,8),
					new SqlParameter("@p_name", SqlDbType.VarChar,200),
					new SqlParameter("@p_yname", SqlDbType.VarChar,100),
					new SqlParameter("@p_jname", SqlDbType.VarChar,100),
					new SqlParameter("@p_xfile", SqlDbType.VarChar,200),
					new SqlParameter("@p_zfile", SqlDbType.VarChar,200),
					new SqlParameter("@p_user", SqlDbType.Int,4),
                    new SqlParameter("@p_ip", SqlDbType.VarChar,20),
                    
            };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.p_name;
			parameters[2].Value = model.p_yname;
			parameters[3].Value = model.p_jname;
			parameters[4].Value = model.p_xfile;
			parameters[5].Value = model.p_zfile;
			parameters[6].Value = model.p_user;
            parameters[7].Value = model.p_Ip;

			DbHelperSQL.RunProcedure("Tunnel_project_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_project model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.BigInt,8),
					new SqlParameter("@p_name", SqlDbType.VarChar,200),
					new SqlParameter("@p_yname", SqlDbType.VarChar,100),
					new SqlParameter("@p_jname", SqlDbType.VarChar,100),
					new SqlParameter("@p_xfile", SqlDbType.VarChar,200),
					new SqlParameter("@p_zfile", SqlDbType.VarChar,200),
					new SqlParameter("@p_user", SqlDbType.Int,4),
                    new SqlParameter("@p_ip", SqlDbType.VarChar,20),
            };
			parameters[0].Value = model.p_id;
			parameters[1].Value = model.p_name;
			parameters[2].Value = model.p_yname;
			parameters[3].Value = model.p_jname;
			parameters[4].Value = model.p_xfile;
			parameters[5].Value = model.p_zfile;
			parameters[6].Value = model.p_user;
            parameters[7].Value = model.p_Ip;

			DbHelperSQL.RunProcedure("Tunnel_project_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public void Delete(long p_id, int p_user, string p_ip)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.BigInt),
                    new SqlParameter("@p_user", SqlDbType.Int),
                    new SqlParameter("@p_ip", SqlDbType.VarChar,20)
            
            };
			parameters[0].Value = p_id;
            parameters[1].Value = p_user;
            parameters[2].Value = p_ip;

			DbHelperSQL.RunProcedure("Tunnel_project_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_project GetModel(long p_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.BigInt)};
			parameters[0].Value = p_id;

			Tunnel.Model.Tunnel_project model=new Tunnel.Model.Tunnel_project();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_project_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["p_id"].ToString()!="")
				{
					model.p_id=long.Parse(ds.Tables[0].Rows[0]["p_id"].ToString());
				}
				model.p_name=ds.Tables[0].Rows[0]["p_name"].ToString();
				model.p_yname=ds.Tables[0].Rows[0]["p_yname"].ToString();
				model.p_jname=ds.Tables[0].Rows[0]["p_jname"].ToString();
				model.p_xfile=ds.Tables[0].Rows[0]["p_xfile"].ToString();
				model.p_zfile=ds.Tables[0].Rows[0]["p_zfile"].ToString();
				if(ds.Tables[0].Rows[0]["p_user"].ToString()!="")
				{
					model.p_user=int.Parse(ds.Tables[0].Rows[0]["p_user"].ToString());
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
			strSql.Append("select p_id,p_name,p_yname,p_jname,p_xfile,p_zfile,p_user ");
			strSql.Append(" FROM Tunnel_project ");
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
			strSql.Append(" p_id,p_name,p_yname,p_jname,p_xfile,p_zfile,p_user ");
			strSql.Append(" FROM Tunnel_project ");
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

