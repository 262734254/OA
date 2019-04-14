using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_ProJectMent。
	/// </summary>
	public class Tunnel_ProJectMent
	{
		public Tunnel_ProJectMent()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long Pro_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@Pro_Id", SqlDbType.BigInt)};
			parameters[0].Value = Pro_Id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_ProJectMent_Exists",parameters,out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_ProJectMent model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@Pro_Id", SqlDbType.BigInt,8),
					new SqlParameter("@Pro_Title", SqlDbType.VarChar,200),
					new SqlParameter("@Pro_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Pro_StartDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_ManDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_ContractDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_EquipmentDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_MaterialDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_PlanDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_SecurityDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_Status", SqlDbType.Int,4),
					new SqlParameter("@Pro_Manager", SqlDbType.BigInt,8)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Pro_Title;
            parameters[2].Value = model.Pro_Name;
            parameters[3].Value = model.Pro_StartDate;
            parameters[4].Value = model.Pro_ManDate;
            parameters[5].Value = model.Pro_ContractDate;
            parameters[6].Value = model.Pro_EquipmentDate;
            parameters[7].Value = model.Pro_MaterialDate;
            parameters[8].Value = model.Pro_PlanDate;
            parameters[9].Value = model.Pro_SecurityDate;
            parameters[10].Value = model.Pro_Status;
            parameters[11].Value = model.Pro_Manager;

            DbHelperSQL.RunProcedure("UP_Tunnel_ProJectMent_ADD", parameters, out rowsAffected);
            return Convert.ToInt32(parameters[0].Value);
        }

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_ProJectMent model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@Pro_Id", SqlDbType.BigInt,8),
					new SqlParameter("@Pro_Title", SqlDbType.VarChar,200),
					new SqlParameter("@Pro_Name", SqlDbType.VarChar,100),
					new SqlParameter("@Pro_StartDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_EndDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_ManDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_ManEndDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_ContractDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_ContractEndDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_EquipmentDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_EquipmentEndDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_MaterialDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_MaterialEndDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_PlanDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_PlanEndDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_SecurityDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_SecurityEndDate", SqlDbType.DateTime),
					new SqlParameter("@Pro_Status", SqlDbType.Int,4),
					new SqlParameter("@Pro_Manager", SqlDbType.BigInt,8)};
			parameters[0].Value = model.Pro_Id;
			parameters[1].Value = model.Pro_Title;
			parameters[2].Value = model.Pro_Name;
			parameters[3].Value = model.Pro_StartDate;
			parameters[4].Value = model.Pro_EndDate;
			parameters[5].Value = model.Pro_ManDate;
			parameters[6].Value = model.Pro_ManEndDate;
			parameters[7].Value = model.Pro_ContractDate;
			parameters[8].Value = model.Pro_ContractEndDate;
			parameters[9].Value = model.Pro_EquipmentDate;
			parameters[10].Value = model.Pro_EquipmentEndDate;
			parameters[11].Value = model.Pro_MaterialDate;
			parameters[12].Value = model.Pro_MaterialEndDate;
			parameters[13].Value = model.Pro_PlanDate;
			parameters[14].Value = model.Pro_PlanEndDate;
			parameters[15].Value = model.Pro_SecurityDate;
			parameters[16].Value = model.Pro_SecurityEndDate;
			parameters[17].Value = model.Pro_Status;
			parameters[18].Value = model.Pro_Manager;

			DbHelperSQL.RunProcedure("UP_Tunnel_ProJectMent_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long Pro_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@Pro_Id", SqlDbType.BigInt)};
			parameters[0].Value = Pro_Id;

			DbHelperSQL.RunProcedure("UP_Tunnel_ProJectMent_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_ProJectMent GetModel(long Pro_Id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@Pro_Id", SqlDbType.BigInt)};
			parameters[0].Value = Pro_Id;

			Tunnel.Model.Tunnel_ProJectMent model=new Tunnel.Model.Tunnel_ProJectMent();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_ProJectMent_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Pro_Id"].ToString()!="")
				{
					model.Pro_Id=long.Parse(ds.Tables[0].Rows[0]["Pro_Id"].ToString());
				}
				model.Pro_Title=ds.Tables[0].Rows[0]["Pro_Title"].ToString();
				model.Pro_Name=ds.Tables[0].Rows[0]["Pro_Name"].ToString();
				if(ds.Tables[0].Rows[0]["Pro_StartDate"].ToString()!="")
				{
					model.Pro_StartDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_StartDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_EndDate"].ToString()!="")
				{
					model.Pro_EndDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_EndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_ManDate"].ToString()!="")
				{
					model.Pro_ManDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_ManDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_ManEndDate"].ToString()!="")
				{
					model.Pro_ManEndDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_ManEndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_ContractDate"].ToString()!="")
				{
					model.Pro_ContractDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_ContractDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_ContractEndDate"].ToString()!="")
				{
					model.Pro_ContractEndDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_ContractEndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_EquipmentDate"].ToString()!="")
				{
					model.Pro_EquipmentDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_EquipmentDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_EquipmentEndDate"].ToString()!="")
				{
					model.Pro_EquipmentEndDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_EquipmentEndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_MaterialDate"].ToString()!="")
				{
					model.Pro_MaterialDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_MaterialDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_MaterialEndDate"].ToString()!="")
				{
					model.Pro_MaterialEndDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_MaterialEndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_PlanDate"].ToString()!="")
				{
					model.Pro_PlanDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_PlanDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_PlanEndDate"].ToString()!="")
				{
					model.Pro_PlanEndDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_PlanEndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_SecurityDate"].ToString()!="")
				{
					model.Pro_SecurityDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_SecurityDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_SecurityEndDate"].ToString()!="")
				{
					model.Pro_SecurityEndDate=DateTime.Parse(ds.Tables[0].Rows[0]["Pro_SecurityEndDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_Status"].ToString()!="")
				{
					model.Pro_Status=int.Parse(ds.Tables[0].Rows[0]["Pro_Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Pro_Manager"].ToString()!="")
				{
					model.Pro_Manager=long.Parse(ds.Tables[0].Rows[0]["Pro_Manager"].ToString());
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
			strSql.Append("select Pro_Id,Pro_Title,Pro_Name,Pro_StartDate,Pro_EndDate,Pro_ManDate,Pro_ManEndDate,Pro_ContractDate,Pro_ContractEndDate,Pro_EquipmentDate,Pro_EquipmentEndDate,Pro_MaterialDate,Pro_MaterialEndDate,Pro_PlanDate,Pro_PlanEndDate,Pro_SecurityDate,Pro_SecurityEndDate,Pro_Status,Pro_Manager ");
			strSql.Append(" FROM Tunnel_ProJectMent ");
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
			strSql.Append(" Pro_Id,Pro_Title,Pro_Name,Pro_StartDate,Pro_EndDate,Pro_ManDate,Pro_ManEndDate,Pro_ContractDate,Pro_ContractEndDate,Pro_EquipmentDate,Pro_EquipmentEndDate,Pro_MaterialDate,Pro_MaterialEndDate,Pro_PlanDate,Pro_PlanEndDate,Pro_SecurityDate,Pro_SecurityEndDate,Pro_Status,Pro_Manager ");
			strSql.Append(" FROM Tunnel_ProJectMent ");
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
			parameters[0].Value = "Tunnel_ProJectMent";
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

