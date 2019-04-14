using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
    /// <summary>
    /// 数据访问类Tunnel_workplan。
    /// </summary>
    public class Tunnel_workplan
    {
        public Tunnel_workplan()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long w_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.BigInt)};
            parameters[0].Value = w_id;

            int result = DbHelperSQL.RunProcedure("Tunnel_workplan_Exists", parameters, out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_workplan model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.BigInt,8),
					new SqlParameter("@w_title", SqlDbType.VarChar,200),
					new SqlParameter("@w_content", SqlDbType.Text),
					new SqlParameter("@w_starttime", SqlDbType.DateTime),
					new SqlParameter("@w_endtime", SqlDbType.DateTime),
					new SqlParameter("@w_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@w_user", SqlDbType.Int,4),
                    new SqlParameter("@w_ip", SqlDbType.VarChar,20),
            };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.w_title;
            parameters[2].Value = model.w_content;
            parameters[3].Value = model.w_starttime;
            parameters[4].Value = model.w_endtime;
            parameters[5].Value = model.w_depict;
            parameters[6].Value = model.w_user;
            parameters[7].Value = model.w_Ip;

            DbHelperSQL.RunProcedure("Tunnel_workplan_ADD", parameters, out rowsAffected);
            int relt = -1;
            relt = Convert.ToInt32(parameters[0].Value);
            return relt;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_workplan model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.BigInt,8),
					new SqlParameter("@w_title", SqlDbType.VarChar,200),
					new SqlParameter("@w_content", SqlDbType.Text),
					new SqlParameter("@w_starttime", SqlDbType.DateTime),
					new SqlParameter("@w_endtime", SqlDbType.DateTime),
					new SqlParameter("@w_depict", SqlDbType.VarChar,1000),
					new SqlParameter("@w_user", SqlDbType.Int,4),
                    new SqlParameter("@w_ip", SqlDbType.VarChar,20)
            };
            parameters[0].Value = model.w_id;
            parameters[1].Value = model.w_title;
            parameters[2].Value = model.w_content;
            parameters[3].Value = model.w_starttime;
            parameters[4].Value = model.w_endtime;
            parameters[5].Value = model.w_depict;
            parameters[6].Value = model.w_user;
            parameters[7].Value = model.w_Ip;

            int relt = -1;
            if (DateTime.Compare(model.w_endtime, DateTime.Now.Date) > -1)
                relt = DbHelperSQL.RunProcedure("Tunnel_workplan_Update", parameters, out rowsAffected);
            return relt;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int w_id, int w_user, string w_ip)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.Int),
                    new SqlParameter("@w_user", SqlDbType.Int),
                    new SqlParameter("@w_ip", SqlDbType.VarChar,20)
            };
            parameters[0].Value = w_id;
            parameters[1].Value = w_user;
            parameters[2].Value = w_ip;
            int relt = -1;
            relt = DbHelperSQL.RunProcedure("Tunnel_workplan_Delete", parameters, out rowsAffected);
            return relt;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_workplan GetModel(int w_id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@w_id", SqlDbType.Int)};
            parameters[0].Value = w_id;

            Tunnel.Model.Tunnel_workplan model = new Tunnel.Model.Tunnel_workplan();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_workplan_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["w_id"].ToString() != "")
                {
                    model.w_id = long.Parse(ds.Tables[0].Rows[0]["w_id"].ToString());
                }
                model.w_title = ds.Tables[0].Rows[0]["w_title"].ToString();
                model.w_content = ds.Tables[0].Rows[0]["w_content"].ToString();
                if (ds.Tables[0].Rows[0]["w_starttime"].ToString() != "")
                {
                    model.w_starttime = DateTime.Parse(ds.Tables[0].Rows[0]["w_starttime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["w_endtime"].ToString() != "")
                {
                    model.w_endtime = DateTime.Parse(ds.Tables[0].Rows[0]["w_endtime"].ToString());
                }
                model.w_depict = ds.Tables[0].Rows[0]["w_depict"].ToString();
                if (ds.Tables[0].Rows[0]["w_user"].ToString() != "")
                {
                    model.w_user = int.Parse(ds.Tables[0].Rows[0]["w_user"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Tunnel_workplan ");
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

        #endregion  成员方法
    }
}

