using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//�����������
namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_form��
	/// </summary>
	public class Tunnel_form
	{
		public Tunnel_form()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(long f_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
			parameters[0].Value = f_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_form_Exists",parameters,out rowsAffected);
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
        ///  ���ӱ�����
        /// </summary>
        public int Name_Add(Tunnel.Model.Tunnel_form model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_name", SqlDbType.VarChar,100),
					new SqlParameter("@f_bum", SqlDbType.Int,4),
					new SqlParameter("@f_lcid", SqlDbType.Int,4),
					new SqlParameter("@f_user", SqlDbType.Int,4),
					new SqlParameter("@f_date", SqlDbType.DateTime)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.f_name;
            parameters[2].Value = model.f_bum;
            parameters[3].Value = model.f_lcid;
            parameters[4].Value = model.f_user;
            parameters[5].Value = model.f_date;

            DbHelperSQL.RunProcedure("Tunnel_form_Name_add", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

		/// <summary>
		///  ����һ������
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_form model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_name", SqlDbType.VarChar,100),
					new SqlParameter("@f_bum", SqlDbType.Int,4),
					new SqlParameter("@f_lcid", SqlDbType.Int,4),
					new SqlParameter("@f_user", SqlDbType.Int,4),
					new SqlParameter("@f_date", SqlDbType.DateTime),
					new SqlParameter("@f_content", SqlDbType.Text)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.f_name;
			parameters[2].Value = model.f_bum;
			parameters[3].Value = model.f_lcid;
			parameters[4].Value = model.f_user;
			parameters[5].Value = model.f_date;
			parameters[6].Value = model.f_content;

			DbHelperSQL.RunProcedure("Tunnel_form_ADD",parameters,out rowsAffected);
			return int.Parse(parameters[0].Value.ToString());
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_form model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_content", SqlDbType.Text)};
			parameters[0].Value = model.f_id;
			parameters[1].Value = model.f_content;

			DbHelperSQL.RunProcedure("Tunnel_form_Update",parameters,out rowsAffected);
		}

        /// <summary>
        ///  ����һ������
        /// </summary>
        public void Update_Name(Tunnel.Model.Tunnel_form model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_name", SqlDbType.VarChar,100),
					new SqlParameter("@f_bum", SqlDbType.Int,4),
					new SqlParameter("@f_lcid", SqlDbType.Int,4)};
            parameters[0].Value = model.f_id;
            parameters[1].Value = model.f_name;
            parameters[2].Value = model.f_bum;
            parameters[3].Value = model.f_lcid;

            DbHelperSQL.RunProcedure("Tunnel_form_Update_Name", parameters, out rowsAffected);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(long f_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
			parameters[0].Value = f_id;

			DbHelperSQL.RunProcedure("Tunnel_form_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_form GetModel(long f_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
			parameters[0].Value = f_id;

			Tunnel.Model.Tunnel_form model=new Tunnel.Model.Tunnel_form();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_form_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["f_id"].ToString()!="")
				{
					model.f_id=long.Parse(ds.Tables[0].Rows[0]["f_id"].ToString());
				}
				model.f_name=ds.Tables[0].Rows[0]["f_name"].ToString();
				if(ds.Tables[0].Rows[0]["f_bum"].ToString()!="")
				{
					model.f_bum=int.Parse(ds.Tables[0].Rows[0]["f_bum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_lcid"].ToString()!="")
				{
					model.f_lcid=int.Parse(ds.Tables[0].Rows[0]["f_lcid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_user"].ToString()!="")
				{
					model.f_user=int.Parse(ds.Tables[0].Rows[0]["f_user"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_date"].ToString()!="")
				{
					model.f_date=DateTime.Parse(ds.Tables[0].Rows[0]["f_date"].ToString());
				}
				model.f_content=ds.Tables[0].Rows[0]["f_content"].ToString();
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
			strSql.Append("select f_id,f_name,f_bum,f_lcid,f_user,f_date,f_content ");
			strSql.Append(" FROM Tunnel_form ");
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
			strSql.Append(" f_id,f_name,f_bum,f_lcid,f_user,f_date,f_content ");
			strSql.Append(" FROM Tunnel_form ");
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
			parameters[0].Value = "Tunnel_form";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

