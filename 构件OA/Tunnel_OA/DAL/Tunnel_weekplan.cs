using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//�����������
namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_weekplan��
	/// </summary>
	public class Tunnel_weekplan
	{
		public Tunnel_weekplan()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        public bool Exists(string week_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_weekID", SqlDbType.VarChar,200)};
            parameters[0].Value = week_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_weekplan_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_weekplan model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.BigInt,8),
					new SqlParameter("@w_title", SqlDbType.VarChar,200),
					new SqlParameter("@w_content", SqlDbType.VarChar,500),
					new SqlParameter("@w_address", SqlDbType.VarChar,100),
					new SqlParameter("@w_time", SqlDbType.VarChar,50),
					new SqlParameter("@w_daytime", SqlDbType.VarChar,50),
					new SqlParameter("@w_adddate", SqlDbType.DateTime),
					new SqlParameter("@w_weekID", SqlDbType.VarChar,200),
					new SqlParameter("@w_date", SqlDbType.VarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.w_title;
			parameters[2].Value = model.w_content;
			parameters[3].Value = model.w_address;
			parameters[4].Value = model.w_time;
			parameters[5].Value = model.w_daytime;
			parameters[6].Value = model.w_adddate;
			parameters[7].Value = model.w_weekID;
			parameters[8].Value = model.w_date;

			DbHelperSQL.RunProcedure("UP_Tunnel_weekplan_ADD",parameters,out rowsAffected);
			return int.Parse(parameters[0].Value.ToString());
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_weekplan model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.BigInt,8),
					new SqlParameter("@w_title", SqlDbType.VarChar,200),
					new SqlParameter("@w_content", SqlDbType.VarChar,500),
					new SqlParameter("@w_address", SqlDbType.VarChar,100),
					new SqlParameter("@w_time", SqlDbType.VarChar,50),
					new SqlParameter("@w_daytime", SqlDbType.VarChar,50),
					new SqlParameter("@w_adddate", SqlDbType.DateTime),
					new SqlParameter("@w_weekID", SqlDbType.VarChar,200),
					new SqlParameter("@w_date", SqlDbType.VarChar,50)};
			parameters[0].Value = model.w_id;
			parameters[1].Value = model.w_title;
			parameters[2].Value = model.w_content;
			parameters[3].Value = model.w_address;
			parameters[4].Value = model.w_time;
			parameters[5].Value = model.w_daytime;
			parameters[6].Value = model.w_adddate;
			parameters[7].Value = model.w_weekID;
			parameters[8].Value = model.w_date;

			DbHelperSQL.RunProcedure("UP_Tunnel_weekplan_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int w_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.BigInt)};
			parameters[0].Value = w_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_weekplan_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_weekplan GetModel(long w_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.BigInt)};
			parameters[0].Value = w_id;

			Tunnel.Model.Tunnel_weekplan model=new Tunnel.Model.Tunnel_weekplan();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_weekplan_GetModel",parameters,"ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["w_id"].ToString() != "")
                {
                    model.w_id = long.Parse(ds.Tables[0].Rows[0]["w_id"].ToString());
                }
                model.w_title = ds.Tables[0].Rows[0]["w_title"].ToString();
                model.w_content = ds.Tables[0].Rows[0]["w_content"].ToString();
                model.w_address = ds.Tables[0].Rows[0]["w_address"].ToString();
                model.w_time = ds.Tables[0].Rows[0]["w_time"].ToString();
                model.w_daytime = ds.Tables[0].Rows[0]["w_daytime"].ToString();
                if (ds.Tables[0].Rows[0]["w_adddate"].ToString() != "")
                {
                    model.w_adddate = DateTime.Parse(ds.Tables[0].Rows[0]["w_adddate"].ToString());
                }
                model.w_weekID = ds.Tables[0].Rows[0]["w_weekID"].ToString();
                model.w_date = ds.Tables[0].Rows[0]["w_date"].ToString();
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
			strSql.Append("select w_id,w_title,w_content,w_address,w_time,w_daytime,w_adddate,w_weekID,w_date ");
			strSql.Append(" FROM Tunnel_weekplan ");
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
			strSql.Append(" w_id,w_title,w_content,w_address,w_time,w_daytime,w_adddate,w_weekID,w_date ");
			strSql.Append(" FROM Tunnel_weekplan ");
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
			parameters[0].Value = "Tunnel_weekplan";
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

