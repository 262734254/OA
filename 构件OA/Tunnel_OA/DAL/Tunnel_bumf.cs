using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
    /// <summary>
    /// 数据访问类Tunnel_bumf。
    /// </summary>
    public class Tunnel_bumf
    {
        public Tunnel_bumf()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long b_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt)};
            parameters[0].Value = b_id;

            int result = DbHelperSQL.RunProcedure("UP_Tunnel_bumf_Exists", parameters, out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_bumf model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt,8),
                    new SqlParameter("@b_title", SqlDbType.VarChar,200),
					new SqlParameter("@b_sort", SqlDbType.Int,4),
					new SqlParameter("@b_time", SqlDbType.DateTime),
					new SqlParameter("@b_state", SqlDbType.Int,4),
					new SqlParameter("@b_user", SqlDbType.Int,4),
                    new SqlParameter("@b_suser", SqlDbType.Int,4),
                    new SqlParameter("@b_content", SqlDbType.Text),
					new SqlParameter("@b_formcontent", SqlDbType.Text),
                    new SqlParameter("@b_datefield", SqlDbType.Text),
                    new SqlParameter("@b_stype", SqlDbType.Int),
                    new SqlParameter("@b_file", SqlDbType.VarChar,3000)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.b_title;
            parameters[2].Value = model.b_sort;
            parameters[3].Value = model.b_time;
            parameters[4].Value = model.b_state;
            parameters[5].Value = model.b_user;
            parameters[6].Value = model.b_suser;
            parameters[7].Value = model.b_content;
            parameters[8].Value = model.b_formcontent;
            parameters[9].Value = model.b_datefield;
            parameters[10].Value = model.b_stype;
            parameters[11].Value = model.b_file;

            DbHelperSQL.RunProcedure("UP_Tunnel_bumf_TitleADD", parameters, out rowsAffected);
            return Convert.ToInt32(parameters[0].Value);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_bumf model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt,8),
					new SqlParameter("@b_title", SqlDbType.VarChar,200),
					new SqlParameter("@b_state", SqlDbType.Int,4),
                    new SqlParameter("@b_suser", SqlDbType.Int,4),
                    new SqlParameter("@b_content", SqlDbType.Text),
                    new SqlParameter("@b_datefield", SqlDbType.Text),
                    new SqlParameter("@b_file", SqlDbType.VarChar,3000)};
            parameters[0].Value = model.b_id;
            parameters[1].Value = model.b_title;
            parameters[2].Value = model.b_state;
            parameters[3].Value = model.b_suser;
            parameters[4].Value = model.b_content;
            parameters[5].Value = model.b_datefield;
            parameters[6].Value = model.b_file;

            DbHelperSQL.RunProcedure("UP_Tunnel_bumf_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long b_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt)};
            parameters[0].Value = b_id;

            DbHelperSQL.RunProcedure("UP_Tunnel_bumf_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_bumf GetModel(long b_id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@b_id", SqlDbType.BigInt)};
            parameters[0].Value = b_id;

            Tunnel.Model.Tunnel_bumf model = new Tunnel.Model.Tunnel_bumf();
            DataSet ds = DbHelperSQL.RunProcedure("UP_Tunnel_bumf_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["b_id"].ToString() != "")
                {
                    model.b_id = long.Parse(ds.Tables[0].Rows[0]["b_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["b_sort"].ToString() != "")
                {
                    model.b_sort = int.Parse(ds.Tables[0].Rows[0]["b_sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["b_time"].ToString() != "")
                {
                    model.b_time = DateTime.Parse(ds.Tables[0].Rows[0]["b_time"].ToString());
                }
                model.b_file = ds.Tables[0].Rows[0]["b_file"].ToString();
                if (ds.Tables[0].Rows[0]["b_state"].ToString() != "")
                {
                    model.b_state = int.Parse(ds.Tables[0].Rows[0]["b_state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["b_user"].ToString() != "")
                {
                    model.b_user = int.Parse(ds.Tables[0].Rows[0]["b_user"].ToString());
                }
                if (ds.Tables[0].Rows[0]["b_suser"].ToString() != "")
                {
                    model.b_suser = int.Parse(ds.Tables[0].Rows[0]["b_suser"].ToString());
                }
                else {
                    model.b_suser = 0;
                }
                if (ds.Tables[0].Rows[0]["b_stype"].ToString() != "")
                {
                    model.b_stype = int.Parse(ds.Tables[0].Rows[0]["b_stype"].ToString());
                }
                model.b_title = ds.Tables[0].Rows[0]["b_title"].ToString();
                model.b_content = ds.Tables[0].Rows[0]["b_content"].ToString();
                model.b_datefield = ds.Tables[0].Rows[0]["b_datefield"].ToString();
                model.b_formcontent = ds.Tables[0].Rows[0]["b_formcontent"].ToString();
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
            strSql.Append("select b_id,b_title,b_sort,b_time,b_file,b_state,b_user,b_content,b_datefield,b_formcontent,b_suser,b_stype ");
            strSql.Append(" FROM Tunnel_bumf ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            strSql.Append(" b_id,b_title,b_sort,b_time,b_file,b_state,b_user,b_content,b_datefield,b_formcontent,b_suser,b_sdate,b_stype ");
            strSql.Append(" FROM Tunnel_bumf ");
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
            parameters[0].Value = "Tunnel_bumf";
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

