using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;
namespace Tunnel.DAL
{
	/// <summary>
	/// ���ݷ�����Vote_Info��
	/// </summary>
	public class Vote_Info
	{
		public Vote_Info()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("v_id", "Vote_Info"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int v_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Vote_Info");
			strSql.Append(" where v_id=@v_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.Int,4)};
			parameters[0].Value = v_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Tunnel.Model.Vote_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Vote_Info(");
			strSql.Append("v_title,v_count,v_Img,v_author,v_remark)");
			strSql.Append(" values (");
			strSql.Append("@v_title,@v_count,@v_Img,@v_author,@v_remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@v_title", SqlDbType.NVarChar,50),
					new SqlParameter("@v_count", SqlDbType.Int,4),
					new SqlParameter("@v_Img", SqlDbType.NVarChar,100),
					new SqlParameter("@v_author", SqlDbType.NVarChar,50),
					new SqlParameter("@v_remark", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.v_title;
			parameters[1].Value = model.v_count;
			parameters[2].Value = model.v_Img;
			parameters[3].Value = model.v_author;
			parameters[4].Value = model.v_remark;

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
		/// ����һ������
		/// </summary>
		public void Update(Tunnel.Model.Vote_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Vote_Info set ");
			strSql.Append("v_title=@v_title,");
			strSql.Append("v_count=@v_count,");
			strSql.Append("v_Img=@v_Img,");
			strSql.Append("v_author=@v_author,");
			strSql.Append("v_remark=@v_remark");
			strSql.Append(" where v_id=@v_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.Int,4),
					new SqlParameter("@v_title", SqlDbType.NVarChar,50),
					new SqlParameter("@v_count", SqlDbType.Int,4),
					new SqlParameter("@v_Img", SqlDbType.NVarChar,100),
					new SqlParameter("@v_author", SqlDbType.NVarChar,50),
					new SqlParameter("@v_remark", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.v_id;
			parameters[1].Value = model.v_title;
			parameters[2].Value = model.v_count;
			parameters[3].Value = model.v_Img;
			parameters[4].Value = model.v_author;
			parameters[5].Value = model.v_remark;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int v_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Vote_Info ");
			strSql.Append(" where v_id=@v_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.Int,4)};
			parameters[0].Value = v_id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Tunnel.Model.Vote_Info GetModel(int v_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 v_id,v_title,v_count,v_Img,v_author,v_remark from Vote_Info ");
			strSql.Append(" where v_id=@v_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.Int,4)};
			parameters[0].Value = v_id;

			Tunnel.Model.Vote_Info model=new Tunnel.Model.Vote_Info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["v_id"].ToString()!="")
				{
					model.v_id=int.Parse(ds.Tables[0].Rows[0]["v_id"].ToString());
				}
				model.v_title=ds.Tables[0].Rows[0]["v_title"].ToString();
				if(ds.Tables[0].Rows[0]["v_count"].ToString()!="")
				{
					model.v_count=int.Parse(ds.Tables[0].Rows[0]["v_count"].ToString());
				}
				model.v_Img=ds.Tables[0].Rows[0]["v_Img"].ToString();
				model.v_author=ds.Tables[0].Rows[0]["v_author"].ToString();
				model.v_remark=ds.Tables[0].Rows[0]["v_remark"].ToString();
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
			strSql.Append("select v_id,v_title,v_count,v_Img,v_author,v_remark ");
			strSql.Append(" FROM Vote_Info ");
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
			strSql.Append(" v_id,v_title,v_count,v_Img,v_author,v_remark ");
			strSql.Append(" FROM Vote_Info ");
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
			parameters[0].Value = "Vote_Info";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        /// <summary>
        /// ��ȡ����ͼƬ��źͱ���
        /// </summary>
        /// <param name="vid">ͼƬ���</param>
        /// <param name="otopid">��һ��ͼƬ���</param>
        /// <param name="odownid">��һ��ͼƬ���</param>
        /// <param name="toptitle">��һ��ͼƬ����</param>
        /// <param name="downtitle">��һ��ͼƬ����</param>
        public void GetTopDown(int vid, out int otopid, out int odownid, out string toptitle, out string downtitle)
        {
            string sql = "pro_selectTopDownImg";
            SqlParameter[] parameters = {
					new SqlParameter("@vid", SqlDbType.Int,4),
					new SqlParameter("@otopId", SqlDbType.Int,4),
					new SqlParameter("@odownId", SqlDbType.Int,4),
					new SqlParameter("@vtoptitle", SqlDbType.NVarChar,50),
					new SqlParameter("@vdowntitle", SqlDbType.NVarChar,50)};

            parameters[0].Value = vid;
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure(sql, parameters);
            otopid = int.Parse(parameters[1].Value.ToString());
            odownid = int.Parse(parameters[2].Value.ToString());
            toptitle = parameters[3].Value.ToString();
            downtitle = parameters[4].Value.ToString();
        }

        /// <summary>
        /// ���۷�ҳ��ѯ
        /// </summary>
        /// <param name="vateid">�û����</param>
        /// <param name="pagesize">ÿҳ����</param>
        /// <param name="pageindex">��ǰҳ��</param>
        /// <param name="outvalue">�ܹ�ҳ��</param>
        /// <returns></returns>
        public DataTable SelectListPage(int vateid, int pagesize, int pageindex, out int outvalue) 
        {
            string sql = "pro_SelectcommonpropValue";
            SqlParameter[] parameters = {
					new SqlParameter("@vateid", SqlDbType.Int,4),
					new SqlParameter("@pPageSize", SqlDbType.Int,4),
					new SqlParameter("@pPageIndex", SqlDbType.Int,4),
					new SqlParameter("@outvalue", SqlDbType.Int,4)};
            parameters[0].Value = vateid;
            parameters[1].Value = pagesize;
            parameters[2].Value = pageindex;
            parameters[3].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure(sql, parameters, "view_Comment");
            outvalue = int.Parse(parameters[3].Value.ToString());

            return ds.Tables[1];
            
        }
        /// <summary>
        /// ͼƬ��ҳ��ѯ
        /// </summary>
        /// <param name="pagesize">ÿҳ����</param>
        /// <param name="pageindex">��ǰҳ��</param>
        /// <param name="outvalue">�ܹ�ҳ��</param>
        /// <returns></returns>
        public DataTable SelectImgList(int pagesize, int pageindex, out int outvalue) 
        {
            string sql = "pro_SelectImgList";
            SqlParameter[] parameters = {
					new SqlParameter("@pPageSize", SqlDbType.Int,4),
					new SqlParameter("@pPageIndex", SqlDbType.Int,4),
					new SqlParameter("@outvalue", SqlDbType.Int,4)};
            parameters[0].Value = pagesize;
            parameters[1].Value = pageindex;
            parameters[2].Direction = ParameterDirection.Output;

            DataSet ds = DbHelperSQL.RunProcedure(sql, parameters, "Vote_Info");

            outvalue = int.Parse(parameters[2].Value.ToString());
            return ds.Tables[1];
            
        }
        
		#endregion  ��Ա����
	}
}

