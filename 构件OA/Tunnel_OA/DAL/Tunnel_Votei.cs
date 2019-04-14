using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_Votei��
	/// </summary>
	public class Tunnel_Votei
	{
		public Tunnel_Votei()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ivote_Id", "Tunnel_Votei"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ivote_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ivote_Id", SqlDbType.Int,4)};
			parameters[0].Value = ivote_Id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_Votei_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_Votei model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ivote_Id", SqlDbType.Int,4),
					new SqlParameter("@ivote_Title", SqlDbType.VarChar,3000),
					new SqlParameter("@ivote_Count", SqlDbType.Int,4),
					new SqlParameter("@ivote_yesUserId", SqlDbType.VarChar,3000),
					new SqlParameter("@ivote_voteId", SqlDbType.Int,4)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.ivote_Title;
			parameters[2].Value = model.ivote_Count;
			parameters[3].Value = model.ivote_yesUserId;
			parameters[4].Value = model.ivote_voteId;

			DbHelperSQL.RunProcedure("UP_Tunnel_Votei_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Votei model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ivote_Id", SqlDbType.Int,4),
					new SqlParameter("@ivote_Title", SqlDbType.VarChar,3000),
					new SqlParameter("@ivote_Count", SqlDbType.Int,4),
					new SqlParameter("@ivote_yesUserId", SqlDbType.VarChar,3000),
					new SqlParameter("@ivote_voteId", SqlDbType.Int,4)};
			parameters[0].Value = model.ivote_Id;
			parameters[1].Value = model.ivote_Title;
			parameters[2].Value = model.ivote_Count;
			parameters[3].Value = model.ivote_yesUserId;
			parameters[4].Value = model.ivote_voteId;

			DbHelperSQL.RunProcedure("UP_Tunnel_Votei_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ivote_Id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@ivote_Id", SqlDbType.Int,4)};
			parameters[0].Value = ivote_Id;

			DbHelperSQL.RunProcedure("UP_Tunnel_Votei_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Votei GetModel(int ivote_Id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@ivote_Id", SqlDbType.Int,4)};
			parameters[0].Value = ivote_Id;

			Tunnel.Model.Tunnel_Votei model=new Tunnel.Model.Tunnel_Votei();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_Votei_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ivote_Id"].ToString()!="")
				{
					model.ivote_Id=int.Parse(ds.Tables[0].Rows[0]["ivote_Id"].ToString());
				}
				model.ivote_Title=ds.Tables[0].Rows[0]["ivote_Title"].ToString();
				if(ds.Tables[0].Rows[0]["ivote_Count"].ToString()!="")
				{
					model.ivote_Count=int.Parse(ds.Tables[0].Rows[0]["ivote_Count"].ToString());
				}
				model.ivote_yesUserId=ds.Tables[0].Rows[0]["ivote_yesUserId"].ToString();
				if(ds.Tables[0].Rows[0]["ivote_voteId"].ToString()!="")
				{
					model.ivote_voteId=int.Parse(ds.Tables[0].Rows[0]["ivote_voteId"].ToString());
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
			strSql.Append("select ivote_Id,ivote_Title,ivote_Count,ivote_yesUserId,ivote_voteId ");
			strSql.Append(" FROM Tunnel_Votei ");
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
			strSql.Append(" ivote_Id,ivote_Title,ivote_Count,ivote_yesUserId,ivote_voteId ");
			strSql.Append(" FROM Tunnel_Votei ");
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
			parameters[0].Value = "Tunnel_Votei";
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

