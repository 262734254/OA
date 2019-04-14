using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//�����������
namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_Advice��
	/// </summary>
	public class Tunnel_Advice
	{
		public Tunnel_Advice()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long a_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.BigInt)};
			parameters[0].Value = a_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_Advice_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_Advice model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.BigInt,8),
					new SqlParameter("@a_user", SqlDbType.Int,4),
					new SqlParameter("@a_bid", SqlDbType.Int,4),
                    new SqlParameter("@a_gid", SqlDbType.Int,4),
					new SqlParameter("@a_content", SqlDbType.Text),
					new SqlParameter("@a_time", SqlDbType.DateTime)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.a_user;
			parameters[2].Value = model.a_bid;
            parameters[3].Value = model.a_gid;
			parameters[4].Value = model.a_content;
			parameters[5].Value = model.a_time;

			DbHelperSQL.RunProcedure("UP_Tunnel_Advice_ADD",parameters,out rowsAffected);
			return Convert.ToInt32(parameters[0].Value);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Advice model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.BigInt,8),
					new SqlParameter("@a_user", SqlDbType.Int,4),
					new SqlParameter("@a_bid", SqlDbType.Int,4),
                    new SqlParameter("@a_gid", SqlDbType.Int,4),
					new SqlParameter("@a_content", SqlDbType.Text),
					new SqlParameter("@a_time", SqlDbType.DateTime)};
			parameters[0].Value = model.a_id;
			parameters[1].Value = model.a_user;
			parameters[2].Value = model.a_bid;
            parameters[3].Value = model.a_gid;
			parameters[4].Value = model.a_content;
			parameters[5].Value = model.a_time;

			DbHelperSQL.RunProcedure("UP_Tunnel_Advice_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long a_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.BigInt)};
			parameters[0].Value = a_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_Advice_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Advice GetModel(long a_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@a_id", SqlDbType.BigInt)};
			parameters[0].Value = a_id;

			Tunnel.Model.Tunnel_Advice model=new Tunnel.Model.Tunnel_Advice();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_Advice_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["a_id"].ToString()!="")
				{
					model.a_id=long.Parse(ds.Tables[0].Rows[0]["a_id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["a_user"].ToString()!="")
				{
					model.a_user=int.Parse(ds.Tables[0].Rows[0]["a_user"].ToString());
				}
				if(ds.Tables[0].Rows[0]["a_bid"].ToString()!="")
				{
					model.a_bid=int.Parse(ds.Tables[0].Rows[0]["a_bid"].ToString());
				}
                if (ds.Tables[0].Rows[0]["a_gid"].ToString() != "")
                {
                    model.a_gid = int.Parse(ds.Tables[0].Rows[0]["a_gid"].ToString());
                }
				model.a_content=ds.Tables[0].Rows[0]["a_content"].ToString();
				if(ds.Tables[0].Rows[0]["a_time"].ToString()!="")
				{
					model.a_time=DateTime.Parse(ds.Tables[0].Rows[0]["a_time"].ToString());
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
            strSql.Append("select a_id,a_user,a_bid,a_content,a_time,a_gid ");
			strSql.Append(" FROM Tunnel_Advice ");
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
            strSql.Append(" a_id,a_user,a_bid,a_content,a_time,a_gid ");
			strSql.Append(" FROM Tunnel_Advice ");
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
			parameters[0].Value = "Tunnel_Advice";
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

