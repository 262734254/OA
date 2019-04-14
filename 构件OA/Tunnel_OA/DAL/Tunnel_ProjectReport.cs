using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_ProjectReport。
	/// </summary>
	public class Tunnel_ProjectReport
	{
		public Tunnel_ProjectReport()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Report_Id", "Tunnel_ProjectReport"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Report_Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tunnel_ProjectReport");
			strSql.Append(" where Report_Id=@Report_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Report_Id", SqlDbType.Int,4)};
			parameters[0].Value = Report_Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_ProjectReport model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tunnel_ProjectReport(");
			strSql.Append("Report_Name,Report_Class,Report_Sort,Report_State,Report_Shen,Report_Order,Report_UserID)");
			strSql.Append(" values (");
			strSql.Append("@Report_Name,@Report_Class,@Report_Sort,@Report_State,@Report_Shen,@Report_Order,@Report_UserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Report_Name", SqlDbType.VarChar,200),
					new SqlParameter("@Report_Class", SqlDbType.Int,4),
					new SqlParameter("@Report_Sort", SqlDbType.Int,4),
					new SqlParameter("@Report_State", SqlDbType.Int,4),
					new SqlParameter("@Report_Shen", SqlDbType.Int,4),
					new SqlParameter("@Report_Order", SqlDbType.Int,4),
					new SqlParameter("@Report_UserID", SqlDbType.Int,4)};
			parameters[0].Value = model.Report_Name;
			parameters[1].Value = model.Report_Class;
			parameters[2].Value = model.Report_Sort;
			parameters[3].Value = model.Report_State;
			parameters[4].Value = model.Report_Shen;
			parameters[5].Value = model.Report_Order;
			parameters[6].Value = model.Report_UserID;

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
		public void Update(Tunnel.Model.Tunnel_ProjectReport model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tunnel_ProjectReport set ");
			strSql.Append("Report_Name=@Report_Name,");
			strSql.Append("Report_Class=@Report_Class,");
			strSql.Append("Report_Sort=@Report_Sort,");
			strSql.Append("Report_State=@Report_State,");
			strSql.Append("Report_Shen=@Report_Shen,");
			strSql.Append("Report_Order=@Report_Order,");
			strSql.Append("Report_UserID=@Report_UserID");
			strSql.Append(" where Report_Id=@Report_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Report_Id", SqlDbType.Int,4),
					new SqlParameter("@Report_Name", SqlDbType.VarChar,200),
					new SqlParameter("@Report_Class", SqlDbType.Int,4),
					new SqlParameter("@Report_Sort", SqlDbType.Int,4),
					new SqlParameter("@Report_State", SqlDbType.Int,4),
					new SqlParameter("@Report_Shen", SqlDbType.Int,4),
					new SqlParameter("@Report_Order", SqlDbType.Int,4),
					new SqlParameter("@Report_UserID", SqlDbType.Int,4)};
			parameters[0].Value = model.Report_Id;
			parameters[1].Value = model.Report_Name;
			parameters[2].Value = model.Report_Class;
			parameters[3].Value = model.Report_Sort;
			parameters[4].Value = model.Report_State;
			parameters[5].Value = model.Report_Shen;
			parameters[6].Value = model.Report_Order;
			parameters[7].Value = model.Report_UserID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Report_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tunnel_ProjectReport ");
			strSql.Append(" where Report_Id=@Report_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Report_Id", SqlDbType.Int,4)};
			parameters[0].Value = Report_Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_ProjectReport GetModel(int Report_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Report_Id,Report_Name,Report_Class,Report_Sort,Report_State,Report_Shen,Report_Order,Report_UserID from Tunnel_ProjectReport ");
			strSql.Append(" where Report_Id=@Report_Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Report_Id", SqlDbType.Int,4)};
			parameters[0].Value = Report_Id;

			Tunnel.Model.Tunnel_ProjectReport model=new Tunnel.Model.Tunnel_ProjectReport();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Report_Id"].ToString()!="")
				{
					model.Report_Id=int.Parse(ds.Tables[0].Rows[0]["Report_Id"].ToString());
				}
				model.Report_Name=ds.Tables[0].Rows[0]["Report_Name"].ToString();
				if(ds.Tables[0].Rows[0]["Report_Class"].ToString()!="")
				{
					model.Report_Class=int.Parse(ds.Tables[0].Rows[0]["Report_Class"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Report_Sort"].ToString()!="")
				{
					model.Report_Sort=int.Parse(ds.Tables[0].Rows[0]["Report_Sort"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Report_State"].ToString()!="")
				{
					model.Report_State=int.Parse(ds.Tables[0].Rows[0]["Report_State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Report_Shen"].ToString()!="")
				{
					model.Report_Shen=int.Parse(ds.Tables[0].Rows[0]["Report_Shen"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Report_Order"].ToString()!="")
				{
					model.Report_Order=int.Parse(ds.Tables[0].Rows[0]["Report_Order"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Report_UserID"].ToString()!="")
				{
					model.Report_UserID=int.Parse(ds.Tables[0].Rows[0]["Report_UserID"].ToString());
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
			strSql.Append("select Report_Id,Report_Name,Report_Class,Report_Sort,Report_State,Report_Shen,Report_Order,Report_UserID ");
			strSql.Append(" FROM Tunnel_ProjectReport ");
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
			strSql.Append(" Report_Id,Report_Name,Report_Class,Report_Sort,Report_State,Report_Shen,Report_Order,Report_UserID ");
			strSql.Append(" FROM Tunnel_ProjectReport ");
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
			parameters[0].Value = "Tunnel_ProjectReport";
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

