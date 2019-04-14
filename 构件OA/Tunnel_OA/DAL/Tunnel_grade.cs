using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_grade��
	/// </summary>
	public class Tunnel_grade
	{
		public Tunnel_grade()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("g_id", "Tunnel_grade"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int g_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@g_id", SqlDbType.Int,4)};
			parameters[0].Value = g_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_grade_Exists",parameters,out rowsAffected);
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
		///  ����һ������
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_grade model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@g_id", SqlDbType.Int,4),
					new SqlParameter("@g_workId", SqlDbType.Int,4),
					new SqlParameter("@g_checkId", SqlDbType.Int,4),
					new SqlParameter("@g_cent", SqlDbType.Float,8)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.g_workId;
			parameters[2].Value = model.g_checkId;
			parameters[3].Value = model.g_cent;

			DbHelperSQL.RunProcedure("UP_Tunnel_grade_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_grade model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@g_id", SqlDbType.Int,4),
					new SqlParameter("@g_workId", SqlDbType.Int,4),
					new SqlParameter("@g_checkId", SqlDbType.Int,4),
					new SqlParameter("@g_cent", SqlDbType.Float,8)};
			parameters[0].Value = model.g_id;
			parameters[1].Value = model.g_workId;
			parameters[2].Value = model.g_checkId;
			parameters[3].Value = model.g_cent;

			DbHelperSQL.RunProcedure("UP_Tunnel_grade_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int g_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@g_id", SqlDbType.Int,4)};
			parameters[0].Value = g_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_grade_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_grade GetModel(int g_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@g_id", SqlDbType.Int,4)};
			parameters[0].Value = g_id;

			Tunnel.Model.Tunnel_grade model=new Tunnel.Model.Tunnel_grade();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_grade_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["g_id"].ToString()!="")
				{
					model.g_id=int.Parse(ds.Tables[0].Rows[0]["g_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["g_workId"].ToString()!="")
				{
					model.g_workId=int.Parse(ds.Tables[0].Rows[0]["g_workId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["g_checkId"].ToString()!="")
				{
					model.g_checkId=int.Parse(ds.Tables[0].Rows[0]["g_checkId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["g_cent"].ToString()!="")
				{
					model.g_cent=Convert.ToSingle(ds.Tables[0].Rows[0]["g_cent"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select g_id,g_workId,g_checkId,g_cent ");
			strSql.Append(" FROM Tunnel_grade ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" g_id,g_workId,g_checkId,g_cent ");
			strSql.Append(" FROM Tunnel_grade ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "Tunnel_grade";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

