using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;//�����������
namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_Cfile��
	/// </summary>
	public class Tunnel_Cfile
	{
		public Tunnel_Cfile()
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

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_Cfile_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_Cfile model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_title", SqlDbType.VarChar,200),
					new SqlParameter("@f_type", SqlDbType.Int,4),
					new SqlParameter("@f_content", SqlDbType.Text),
					new SqlParameter("@f_file", SqlDbType.VarChar,100),
					new SqlParameter("@f_first", SqlDbType.BigInt,8),
					new SqlParameter("@f_other", SqlDbType.VarChar,500),
                    new SqlParameter("@f_date", SqlDbType.DateTime),
                    new SqlParameter("@f_user", SqlDbType.BigInt,8)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.f_title;
			parameters[2].Value = model.f_type;
			parameters[3].Value = model.f_content;
			parameters[4].Value = model.f_file;
			parameters[5].Value = model.f_first;
			parameters[6].Value = model.f_other;
            parameters[7].Value = model.f_date;
            parameters[8].Value = model.f_user;


			DbHelperSQL.RunProcedure("UP_Tunnel_Cfile_ADD",parameters,out rowsAffected);
			return Convert.ToInt32(parameters[0].Value);
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Cfile model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
					new SqlParameter("@f_title", SqlDbType.VarChar,200),
					new SqlParameter("@f_type", SqlDbType.Int,4),
					new SqlParameter("@f_content", SqlDbType.Text),
					new SqlParameter("@f_file", SqlDbType.VarChar,100),
					new SqlParameter("@f_first", SqlDbType.BigInt,8),
					new SqlParameter("@f_other", SqlDbType.VarChar,500),
					new SqlParameter("@f_date", SqlDbType.DateTime)};
			parameters[0].Value = model.f_id;
			parameters[1].Value = model.f_title;
			parameters[2].Value = model.f_type;
			parameters[3].Value = model.f_content;
			parameters[4].Value = model.f_file;
			parameters[5].Value = model.f_first;
			parameters[6].Value = model.f_other;
			parameters[7].Value = model.f_date;

			DbHelperSQL.RunProcedure("UP_Tunnel_Cfile_Update",parameters,out rowsAffected);
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

			DbHelperSQL.RunProcedure("UP_Tunnel_Cfile_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_Cfile GetModel(long f_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
			parameters[0].Value = f_id;

			Tunnel.Model.Tunnel_Cfile model=new Tunnel.Model.Tunnel_Cfile();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_Cfile_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["f_id"].ToString()!="")
				{
					model.f_id=long.Parse(ds.Tables[0].Rows[0]["f_id"].ToString());
				}
				model.f_title=ds.Tables[0].Rows[0]["f_title"].ToString();
				if(ds.Tables[0].Rows[0]["f_type"].ToString()!="")
				{
					model.f_type=int.Parse(ds.Tables[0].Rows[0]["f_type"].ToString());
				}
				model.f_content=ds.Tables[0].Rows[0]["f_content"].ToString();
				model.f_file=ds.Tables[0].Rows[0]["f_file"].ToString();
				if(ds.Tables[0].Rows[0]["f_first"].ToString()!="")
				{
					model.f_first=long.Parse(ds.Tables[0].Rows[0]["f_first"].ToString());
				}
                if (ds.Tables[0].Rows[0]["f_user"].ToString() != "")
                {
                    model.f_user = long.Parse(ds.Tables[0].Rows[0]["f_user"].ToString());
                }
				model.f_other=ds.Tables[0].Rows[0]["f_other"].ToString();
				if(ds.Tables[0].Rows[0]["f_date"].ToString()!="")
				{
					model.f_date=DateTime.Parse(ds.Tables[0].Rows[0]["f_date"].ToString());
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
            strSql.Append("select f_id,f_title,f_type,f_content,f_file,f_first,f_other,f_date,f_user ");
			strSql.Append(" FROM Tunnel_Cfile ");
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
            strSql.Append(" f_id,f_title,f_type,f_content,f_file,f_first,f_other,f_date,f_user ");
			strSql.Append(" FROM Tunnel_Cfile ");
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
			parameters[0].Value = "Tunnel_Cfile";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����

        public DataSet GetList(Tunnel.Model.PageBase pb, ref int count)
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
    }
}

