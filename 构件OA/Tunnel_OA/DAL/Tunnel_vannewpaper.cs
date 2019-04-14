using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
	/// <summary>
	/// 数据访问类Tunnel_vannewpaper。
	/// </summary>
	public class Tunnel_vannewpaper
	{
		public Tunnel_vannewpaper()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long v_id)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.BigInt)};
			parameters[0].Value = v_id;

			int result= DbHelperSQL.RunProcedure("Tunnel_vannewpaper_Exists",parameters,out rowsAffected);
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
		///  增加一条数据
		/// </summary>
		public int Add(Tunnel.Model.Tunnel_vannewpaper model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.Int,8),
					new SqlParameter("@v_title", SqlDbType.VarChar,200),
					new SqlParameter("@v_img", SqlDbType.VarChar,100),
					new SqlParameter("@v_file", SqlDbType.VarChar,100),
					new SqlParameter("@v_user", SqlDbType.Int,4),
					new SqlParameter("@v_sort", SqlDbType.Int,4),
                    new SqlParameter("@v_ip", SqlDbType.VarChar,20),
                    
            };
			parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.v_title;
			parameters[2].Value = model.v_img;
			parameters[3].Value = model.v_file;
			parameters[4].Value = model.v_user;
			parameters[5].Value = model.v_sort;
            parameters[6].Value = model.v_Ip;

			DbHelperSQL.RunProcedure("Tunnel_vannewpaper_ADD",parameters,out rowsAffected);
			return (int)parameters[0].Value;
		}

		/// <summary>
		///  更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_vannewpaper model)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.BigInt,8),
					new SqlParameter("@v_title", SqlDbType.VarChar,200),
					new SqlParameter("@v_img", SqlDbType.VarChar,100),
					new SqlParameter("@v_file", SqlDbType.VarBinary,200),
					new SqlParameter("@v_user", SqlDbType.Int,4),
					new SqlParameter("@v_sort", SqlDbType.Int,4),
                    new SqlParameter("@v_ip", SqlDbType.VarChar,20),
            };
			parameters[0].Value = model.v_id;
			parameters[1].Value = model.v_title;
			parameters[2].Value = model.v_img;
			parameters[3].Value = model.v_file;
			parameters[4].Value = model.v_user;
			parameters[5].Value = model.v_sort;
            parameters[6].Value = model.v_Ip;


			DbHelperSQL.RunProcedure("Tunnel_vannewpaper_Update",parameters,out rowsAffected);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long v_id, int v_user ,string v_ip)
		{
			int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.BigInt),
                    new SqlParameter("@v_user", SqlDbType.Int),
                    new SqlParameter("@v_ip", SqlDbType.VarChar,20)
            
            };
			parameters[0].Value = v_id;
            parameters[1].Value = v_user;
            parameters[2].Value = v_ip;

			DbHelperSQL.RunProcedure("Tunnel_vannewpaper_Delete",parameters,out rowsAffected);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_vannewpaper GetModel(long v_id)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@v_id", SqlDbType.BigInt)};
			parameters[0].Value = v_id;

			Tunnel.Model.Tunnel_vannewpaper model=new Tunnel.Model.Tunnel_vannewpaper();
			DataSet ds= DbHelperSQL.RunProcedure("Tunnel_vannewpaper_GetModel",parameters,"ds");
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["v_id"].ToString()!="")
				{
					model.v_id=long.Parse(ds.Tables[0].Rows[0]["v_id"].ToString());
				}
				model.v_title=ds.Tables[0].Rows[0]["v_title"].ToString();
				model.v_img=ds.Tables[0].Rows[0]["v_img"].ToString();
				if(ds.Tables[0].Rows[0]["v_file"].ToString()!="")
				{
					model.v_file=ds.Tables[0].Rows[0]["v_file"].ToString();
				}
				if(ds.Tables[0].Rows[0]["v_user"].ToString()!="")
				{
					model.v_user=int.Parse(ds.Tables[0].Rows[0]["v_user"].ToString());
				}
				if(ds.Tables[0].Rows[0]["v_sort"].ToString()!="")
				{
					model.v_sort=int.Parse(ds.Tables[0].Rows[0]["v_sort"].ToString());
				}
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
			strSql.Append("select v_id,v_title,v_img,v_file,v_user,v_sort ");
			strSql.Append(" FROM Tunnel_vannewpaper ");
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
			strSql.Append(" v_id,v_title,v_img,v_file,v_user,v_sort ");
			strSql.Append(" FROM Tunnel_vannewpaper ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总条数</param>
        /// <returns></returns>
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

		#endregion  成员方法
	}
}

