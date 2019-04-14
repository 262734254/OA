using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_byingshe��
	/// </summary>
	public class Tunnel_byingshe
	{
		public Tunnel_byingshe()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("by_id", "Tunnel_byingshe"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int by_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@by_id", SqlDbType.Int,4)};
			parameters[0].Value = by_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_byingshe_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_byingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@by_id", SqlDbType.Int,4),
					new SqlParameter("@by_bid", SqlDbType.VarChar,50),
					new SqlParameter("@by_list", SqlDbType.VarChar,2000)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.by_bid;
			parameters[2].Value = model.by_list;

			DbHelperSQL.RunProcedure("UP_Tunnel_byingshe_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_byingshe model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@by_id", SqlDbType.Int,4),
					new SqlParameter("@by_bid", SqlDbType.VarChar,50),
					new SqlParameter("@by_list", SqlDbType.VarChar,2000)};
			parameters[0].Value = model.by_id;
			parameters[1].Value = model.by_bid;
			parameters[2].Value = model.by_list;

			DbHelperSQL.RunProcedure("UP_Tunnel_byingshe_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int by_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@by_id", SqlDbType.Int,4)};
			parameters[0].Value = by_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_byingshe_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_byingshe GetModel(int by_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@by_id", SqlDbType.Int,4)};
			parameters[0].Value = by_id;

			Tunnel.Model.Tunnel_byingshe model=new Tunnel.Model.Tunnel_byingshe();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_byingshe_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["by_id"].ToString()!="")
				{
					model.by_id=int.Parse(ds.Tables[0].Rows[0]["by_id"].ToString());
				}
				model.by_bid=ds.Tables[0].Rows[0]["by_bid"].ToString();
				model.by_list=ds.Tables[0].Rows[0]["by_list"].ToString();
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
			strSql.Append("select by_id,by_bid,by_list ");
			strSql.Append(" FROM Tunnel_byingshe ");
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
			strSql.Append(" by_id,by_bid,by_list ");
			strSql.Append(" FROM Tunnel_byingshe ");
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
			parameters[0].Value = "Tunnel_byingshe";
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

