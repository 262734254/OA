using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;
namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Tunnel_items��
	/// </summary>
	public class Tunnel_items
	{
		public Tunnel_items()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("i_id", "Tunnel_items"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int i_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4)};
			parameters[0].Value = i_id;

			int result= DbHelperSQL.RunProcedure("UP_Tunnel_items_Exists",parameters,out rowsAffected);
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
		public int Add(Tunnel.Model.Tunnel_items model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4),
					new SqlParameter("@i_name", SqlDbType.VarChar,50),
					new SqlParameter("@year", SqlDbType.VarChar,50),
					new SqlParameter("@moon", SqlDbType.VarChar,50)};
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.i_name;
			parameters[2].Value = model.year;
			parameters[3].Value = model.moon;

			DbHelperSQL.RunProcedure("UP_Tunnel_items_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_items model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4),
					new SqlParameter("@i_name", SqlDbType.VarChar,50),
					new SqlParameter("@year", SqlDbType.VarChar,50),
					new SqlParameter("@moon", SqlDbType.VarChar,50)};
			parameters[0].Value = model.i_id;
			parameters[1].Value = model.i_name;
			parameters[2].Value = model.year;
			parameters[3].Value = model.moon;

			DbHelperSQL.RunProcedure("UP_Tunnel_items_Update",parameters,out rowsAffected);
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
                new SqlParameter("@strWhere", SqlDbType.VarChar,1000)                
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
		/// ɾ��һ������
		/// </summary>
		public void Delete(int i_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4)};
			parameters[0].Value = i_id;

			DbHelperSQL.RunProcedure("UP_Tunnel_items_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Tunnel_items GetModel(int i_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,4)};
			parameters[0].Value = i_id;

			Tunnel.Model.Tunnel_items model=new Tunnel.Model.Tunnel_items();
			DataSet ds= DbHelperSQL.RunProcedure("UP_Tunnel_items_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["i_id"].ToString()!="")
				{
					model.i_id=int.Parse(ds.Tables[0].Rows[0]["i_id"].ToString());
				}
				model.i_name=ds.Tables[0].Rows[0]["i_name"].ToString();
				model.year=ds.Tables[0].Rows[0]["year"].ToString();
				model.moon=ds.Tables[0].Rows[0]["moon"].ToString();
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
			strSql.Append("select i_id,i_name,year,moon ");
			strSql.Append(" FROM Tunnel_items ");
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
			strSql.Append(" i_id,i_name,year,moon ");
			strSql.Append(" FROM Tunnel_items ");
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
			parameters[0].Value = "Tunnel_items";
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
