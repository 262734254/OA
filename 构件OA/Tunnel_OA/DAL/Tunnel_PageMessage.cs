using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_PageMessage。
	/// </summary>
	public class Tunnel_PageMessage
	{
		public Tunnel_PageMessage()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pic_ID", "Tunnel_PageMessage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pic_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Tunnel_PageMessage");
			strSql.Append(" where pic_ID=@pic_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pic_ID", SqlDbType.Int,4)};
			parameters[0].Value = pic_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_PageMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tunnel_PageMessage(");
			strSql.Append("pic_AspxName,pic_TitleName,pic_TopicName,pic_TopImgURL,pic_BgColor)");
			strSql.Append(" values (");
			strSql.Append("@pic_AspxName,@pic_TitleName,@pic_TopicName,@pic_TopImgURL,@pic_BgColor)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pic_AspxName", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_TitleName", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_TopicName", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_TopImgURL", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_BgColor", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.pic_AspxName;
			parameters[1].Value = model.pic_TitleName;
			parameters[2].Value = model.pic_TopicName;
			parameters[3].Value = model.pic_TopImgURL;
			parameters[4].Value = model.pic_BgColor;

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
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_PageMessage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Tunnel_PageMessage set ");
			strSql.Append("pic_AspxName=@pic_AspxName,");
			strSql.Append("pic_TitleName=@pic_TitleName,");
			strSql.Append("pic_TopicName=@pic_TopicName,");
			strSql.Append("pic_TopImgURL=@pic_TopImgURL,");
			strSql.Append("pic_BgColor=@pic_BgColor");
			strSql.Append(" where pic_ID=@pic_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pic_ID", SqlDbType.Int,4),
					new SqlParameter("@pic_AspxName", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_TitleName", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_TopicName", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_TopImgURL", SqlDbType.NVarChar,100),
					new SqlParameter("@pic_BgColor", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.pic_ID;
			parameters[1].Value = model.pic_AspxName;
			parameters[2].Value = model.pic_TitleName;
			parameters[3].Value = model.pic_TopicName;
			parameters[4].Value = model.pic_TopImgURL;
			parameters[5].Value = model.pic_BgColor;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int pic_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tunnel_PageMessage ");
			strSql.Append(" where pic_ID=@pic_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pic_ID", SqlDbType.Int,4)};
			parameters[0].Value = pic_ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_PageMessage GetModel(int pic_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pic_ID,pic_AspxName,pic_TitleName,pic_TopicName,pic_TopImgURL,pic_BgColor from Tunnel_PageMessage ");
			strSql.Append(" where pic_ID=@pic_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pic_ID", SqlDbType.Int,4)};
			parameters[0].Value = pic_ID;

			Tunnel.Model.Tunnel_PageMessage model=new Tunnel.Model.Tunnel_PageMessage();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["pic_ID"].ToString()!="")
				{
					model.pic_ID=int.Parse(ds.Tables[0].Rows[0]["pic_ID"].ToString());
				}
				model.pic_AspxName=ds.Tables[0].Rows[0]["pic_AspxName"].ToString();
				model.pic_TitleName=ds.Tables[0].Rows[0]["pic_TitleName"].ToString();
				model.pic_TopicName=ds.Tables[0].Rows[0]["pic_TopicName"].ToString();
				model.pic_TopImgURL=ds.Tables[0].Rows[0]["pic_TopImgURL"].ToString();
				model.pic_BgColor=ds.Tables[0].Rows[0]["pic_BgColor"].ToString();
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
			strSql.Append("select pic_ID,pic_AspxName,pic_TitleName,pic_TopicName,pic_TopImgURL,pic_BgColor ");
			strSql.Append(" FROM Tunnel_PageMessage ");
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
			strSql.Append(" pic_ID,pic_AspxName,pic_TitleName,pic_TopicName,pic_TopImgURL,pic_BgColor ");
			strSql.Append(" FROM Tunnel_PageMessage ");
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
			parameters[0].Value = "Tunnel_PageMessage";
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

