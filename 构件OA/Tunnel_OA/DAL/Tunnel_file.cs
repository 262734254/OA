using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
    /// <summary>
    /// 数据访问类Tunnel_file。
    /// </summary>
    public class Tunnel_file
    {
        public Tunnel_file()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long f_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
            parameters[0].Value = f_id;

            int result = DbHelperSQL.RunProcedure("Tunnel_file_Exists", parameters, out rowsAffected);
            if (result == 1)
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
        public int Add(Tunnel.Model.Tunnel_file model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.Int,8),
                    new SqlParameter("@f_title", SqlDbType.VarChar,100),
                    new SqlParameter("@f_file", SqlDbType.VarChar,200),
                    new SqlParameter("@f_size", SqlDbType.VarChar,50),
					new SqlParameter("@f_sort", SqlDbType.Int,8),
                    new SqlParameter("@f_addtime", SqlDbType.DateTime),
                    new SqlParameter("@f_user", SqlDbType.Int,4),
					new SqlParameter("@f_juser", SqlDbType.VarChar,500),
                    new SqlParameter("@f_ip", SqlDbType.VarChar,20),
                    new SqlParameter("@f_content", SqlDbType.Text),
                    new SqlParameter("@f_bum", SqlDbType.Int,8),
                   
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.f_title;
            parameters[2].Value = model.f_file;
            parameters[3].Value = model.f_size;
            parameters[4].Value = model.f_sort;
            parameters[5].Value = model.f_addtime;
            parameters[6].Value = model.f_user;
            parameters[7].Value = model.f_juser;
            parameters[8].Value = model.f_Ip;
            parameters[9].Value = model.f_Content;
            parameters[10].Value = model.f_Bum;

            DbHelperSQL.RunProcedure("Tunnel_file_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_file model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt,8),
                    //new SqlParameter("@f_title", SqlDbType.VarChar,100),
                    //new SqlParameter("@f_file", SqlDbType.VarBinary,100),
                    //new SqlParameter("@f_size", SqlDbType.VarChar,50),
					new SqlParameter("@f_sort", SqlDbType.VarChar,50),
                    //new SqlParameter("@f_addtime", SqlDbType.DateTime),
                    //new SqlParameter("@f_user", SqlDbType.Int,4),
					new SqlParameter("@f_juser", SqlDbType.VarChar,500),
                    new SqlParameter("@f_type", SqlDbType.Int,4),
                    new SqlParameter("@f_user", SqlDbType.Int,4),
                    new SqlParameter("@f_ip", SqlDbType.VarChar,20)
                    
            };
            parameters[0].Value = model.f_id;
            //parameters[1].Value = model.f_title;
            //parameters[2].Value = model.f_file;
            //parameters[3].Value = model.f_size;
            parameters[1].Value = model.f_sort;
            //parameters[5].Value = model.f_addtime;
            //parameters[6].Value = model.f_user;
            parameters[2].Value = model.f_juser;
            parameters[3].Value = model.f_Type;
            parameters[4].Value = model.f_user;
            parameters[5].Value = model.f_Ip;


            return DbHelperSQL.RunProcedure("Tunnel_file_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long f_id, int f_user, string f_ip)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt),
                    new SqlParameter("@f_user", SqlDbType.Int),
                    new SqlParameter("@f_ip", SqlDbType.VarChar,20)
            
            };
            parameters[0].Value = f_id;
            parameters[1].Value = f_user;
            parameters[2].Value = f_ip;

            DbHelperSQL.RunProcedure("Tunnel_file_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_file GetModel(long f_id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@f_id", SqlDbType.BigInt)};
            parameters[0].Value = f_id;

            Tunnel.Model.Tunnel_file model = new Tunnel.Model.Tunnel_file();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_file_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["f_id"].ToString() != "")
                {
                    model.f_id = long.Parse(ds.Tables[0].Rows[0]["f_id"].ToString());
                }
                model.f_title = ds.Tables[0].Rows[0]["f_title"].ToString();
                if (ds.Tables[0].Rows[0]["f_file"].ToString() != "")
                {
                    model.f_file = ds.Tables[0].Rows[0]["f_file"].ToString();
                }
                model.f_size = ds.Tables[0].Rows[0]["f_size"].ToString();
                model.f_sort = Convert.ToInt32(ds.Tables[0].Rows[0]["f_sort"].ToString());
                if (ds.Tables[0].Rows[0]["f_addtime"].ToString() != "")
                {
                    model.f_addtime = DateTime.Parse(ds.Tables[0].Rows[0]["f_addtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["f_user"].ToString() != "")
                {
                    model.f_user = int.Parse(ds.Tables[0].Rows[0]["f_user"].ToString());
                }
                model.f_juser = ds.Tables[0].Rows[0]["f_juser"].ToString();
                model.f_Content = ds.Tables[0].Rows[0]["f_content"].ToString();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["f_Bum"].ToString()))
                    model.f_Bum = Convert.ToInt32(ds.Tables[0].Rows[0]["f_Bum"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select f_id,f_title,f_file,f_size,f_sort,f_addtime,f_user,f_juser ");
            strSql.Append(" FROM Tunnel_file ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere,string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" f_id,f_title,f_file,f_size,f_sort,f_addtime,f_user,f_juser ");
            strSql.Append(" FROM Tunnel_file ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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

