using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_duty。
	/// </summary>
	public class Tunnel_duty
	{
		public Tunnel_duty()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long d_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.BigInt)};
			parameters[0].Value = d_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_duty_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_duty model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.Int,8),
					new SqlParameter("@d_name", SqlDbType.VarChar,100),
					new SqlParameter("@d_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@d_flag", SqlDbType.VarChar,2000)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.d_name;
			parameters[2].Value = model.d_depict;
			parameters[3].Value = model.d_flag;

			DbHelperSQL.RunProcedure("Tunnel_duty_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_duty model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.Int,8),
					new SqlParameter("@d_name", SqlDbType.VarChar,100),
					new SqlParameter("@d_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@d_flag", SqlDbType.VarChar,2000)};
			parameters[0].Value = model.d_id;
			parameters[1].Value = model.d_name;
			parameters[2].Value = model.d_depict;
			parameters[3].Value = model.d_flag;

			DbHelperSQL.RunProcedure("Tunnel_duty_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long d_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.Int)};
			parameters[0].Value = d_id;

			DbHelperSQL.RunProcedure("Tunnel_duty_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_duty GetModel(long d_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@d_id", SqlDbType.Int)};
			parameters[0].Value = d_id;

			Tunnel.Model.Tunnel_duty model=new Tunnel.Model.Tunnel_duty();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_duty_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["d_id"].ToString()!="")
				{
					model.d_id=long.Parse(ds.Tables[0].Rows[0]["d_id"].ToString());
				}
				model.d_name=ds.Tables[0].Rows[0]["d_name"].ToString();
				model.d_depict=ds.Tables[0].Rows[0]["d_depict"].ToString();
				model.d_flag=ds.Tables[0].Rows[0]["d_flag"].ToString();
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select d_id,d_name,d_depict,d_flag ");
			strSql.Append(" FROM Tunnel_duty ");
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
			strSql.Append(" d_id,d_name,d_depict,d_flag ");
			strSql.Append(" FROM Tunnel_duty ");
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
			parameters[0].Value = "Tunnel_duty";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

