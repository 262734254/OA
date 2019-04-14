using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
namespace Tunnel.DAL
{
    /// <summary>
    /// 数据访问类Tunnel_Index。
    /// </summary>
    public class Tunnel_Index
    {
        public Tunnel_Index()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("id", "Tunnel_Index");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int result = DbHelperSQL.RunProcedure("UP_Tunnel_Index_Exists", parameters, out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_index model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@imagePaht", SqlDbType.VarChar,100),
					new SqlParameter("@htmlSource", SqlDbType.Text),
					new SqlParameter("@setDate", SqlDbType.DateTime),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@files", SqlDbType.VarChar,500),
                    new SqlParameter("@bum_bz",SqlDbType.Int,4),
                    new SqlParameter("@filename",SqlDbType.VarChar,500),
                    new SqlParameter("@readUser",SqlDbType.VarChar,500)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.ImagePaht;
            parameters[5].Value = model.HtmlSource;
            parameters[6].Value = model.SetDate;
            parameters[7].Value = model.UserId;
            parameters[8].Value = model.Files;
            parameters[9].Value = model.Bum_bz;
            parameters[10].Value = model.Filename;
            parameters[11].Value = model.ReadUser;
            DbHelperSQL.RunProcedure("UP_Tunnel_Index_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_index model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@typeId", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@imagePaht", SqlDbType.VarChar,100),
					new SqlParameter("@htmlSource", SqlDbType.Text),
					new SqlParameter("@setDate", SqlDbType.DateTime),
					new SqlParameter("@userId", SqlDbType.Int,4),
					new SqlParameter("@files", SqlDbType.VarChar,500),
                    new SqlParameter("@filename",SqlDbType.VarChar,500),
                    new SqlParameter("@readUser",SqlDbType.VarChar,500)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.ImagePaht;
            parameters[5].Value = model.HtmlSource;
            parameters[6].Value = model.SetDate;
            parameters[7].Value = model.UserId;
            parameters[8].Value = model.Files;
            parameters[9].Value = model.Filename;
            parameters[10].Value = model.ReadUser;
            DbHelperSQL.RunProcedure("UP_Tunnel_Index_Update", parameters, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.RunProcedure("UP_Tunnel_Index_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_index GetModel(int id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
            DataSet ds = DbHelperSQL.RunProcedure("UP_Tunnel_Index_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["typeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(ds.Tables[0].Rows[0]["typeId"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["content"].ToString();
                model.ImagePaht = ds.Tables[0].Rows[0]["imagePaht"].ToString();
                model.HtmlSource = ds.Tables[0].Rows[0]["htmlSource"].ToString();
                if (ds.Tables[0].Rows[0]["setDate"].ToString() != "")
                {
                    model.SetDate = Convert.ToString(ds.Tables[0].Rows[0]["setDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["userId"].ToString() != "")
                {
                    model.UserId = int.Parse(ds.Tables[0].Rows[0]["userId"].ToString());
                }
                model.Files = ds.Tables[0].Rows[0]["files"].ToString();
                model.Filename = ds.Tables[0].Rows[0]["filename"].ToString();
                model.ReadUser = ds.Tables[0].Rows[0]["readUser"].ToString();
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
            strSql.Append("select id,typeId,title,content,imagePaht,htmlSource,setDate,userId,files,filename,readUser ");
            strSql.Append(" FROM Tunnel_Index ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,typeId,title,content,imagePaht,htmlSource,setDate,userId,files,filename,readUser ");
            strSql.Append(" FROM Tunnel_Index ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "Tunnel_Index";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        public DataSet GetNewsHead(string id)
        {
            string strSQL = string.Format("SELECT * FROM Tunnel_NewsType WHERE BumID='{0}'", id);
            return DbHelperSQL.Query(strSQL.ToString());
        }
        #endregion  成员方法
    }
}

