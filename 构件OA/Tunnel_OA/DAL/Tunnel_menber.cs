using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
    /// <summary>
    /// 数据访问类Tunnel_menber。
    /// </summary>
    public class Tunnel_menber
    {
        public Tunnel_menber()
        { }
        #region  成员方法
        /// <summary>
        /// 查询可以删除用户否
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public bool Exists(int userid)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@userid", SqlDbType.Int),
            };
            parameters[0].Value = userid;

            int result = DbHelperSQL.RunProcedure("Tunnel_GetUserID", parameters, out rowsAffected);
            if (result > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userName, string userPass, string m_ip, ref int m_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt),
                    new SqlParameter("@m_user", SqlDbType.VarChar, 50),
                    new SqlParameter("@m_pass", SqlDbType.VarChar ,50),
                    new SqlParameter("@m_ip", SqlDbType.VarChar ,50),
            };
            parameters[0].Value = m_id;
            parameters[1].Value = userName;
            parameters[2].Value = userPass;
            parameters[3].Value = m_ip;

            int result = DbHelperSQL.RunProcedure("Tunnel_menber_Exists", parameters, out rowsAffected);
            m_id = result;
            if (result > 0)
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
        public int Add(Tunnel.Model.Tunnel_menber model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.Int,8),
					new SqlParameter("@m_login", SqlDbType.VarChar,50),
					new SqlParameter("@m_name", SqlDbType.VarChar,50),
					new SqlParameter("@m_password", SqlDbType.VarChar,50),
					new SqlParameter("@m_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@m_mail", SqlDbType.VarChar,50),
					new SqlParameter("@m_idcard", SqlDbType.VarChar,50),
					new SqlParameter("@m_spassword", SqlDbType.VarChar,50),
					new SqlParameter("@m_jiao", SqlDbType.Int,4),
					new SqlParameter("@m_bum", SqlDbType.Int,4),
					new SqlParameter("@m_duty", SqlDbType.Int,4),
                    new SqlParameter("@m_xjb", SqlDbType.VarChar,200),
					new SqlParameter("@m_state", SqlDbType.Int,4),
					new SqlParameter("@m_flag", SqlDbType.VarChar,2000),
					new SqlParameter("@m_zdyqx", SqlDbType.Int,4),
                    new SqlParameter("@m_birth", SqlDbType.DateTime,8),
                    new SqlParameter("@m_KSID", SqlDbType.VarChar,200)
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.m_login;
            parameters[2].Value = model.m_name;
            parameters[3].Value = model.m_password;
            parameters[4].Value = model.m_mobile;
            parameters[5].Value = model.m_mail;
            parameters[6].Value = model.m_idcard;
            parameters[7].Value = model.m_spassword;
            parameters[8].Value = model.m_jiao;
            parameters[9].Value = model.m_bum;
            parameters[10].Value = model.m_duty;
            parameters[11].Value = model.m_xjb;
            parameters[12].Value = model.m_state;
            parameters[13].Value = model.m_flag;
            parameters[14].Value = model.m_zdyqx;
            parameters[15].Value = model.m_birth;
            parameters[16].Value = model.m_KSID;

            DbHelperSQL.RunProcedure("Tunnel_menber_ADD", parameters, out rowsAffected);
            int relt = Convert.ToInt32(parameters[0].Value);
            return relt;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_menber model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt,8),
					new SqlParameter("@m_login", SqlDbType.VarChar,50),
					new SqlParameter("@m_name", SqlDbType.VarChar,50),
					new SqlParameter("@m_password", SqlDbType.VarChar,50),
					new SqlParameter("@m_mobile", SqlDbType.VarChar,50),
					new SqlParameter("@m_mail", SqlDbType.VarChar,50),
					new SqlParameter("@m_idcard", SqlDbType.VarChar,50),
					new SqlParameter("@m_spassword", SqlDbType.VarChar,50),
					new SqlParameter("@m_jiao", SqlDbType.Int,4),
					new SqlParameter("@m_bum", SqlDbType.Int,4),
					new SqlParameter("@m_duty", SqlDbType.Int,4),
                    new SqlParameter("@m_xjb", SqlDbType.VarChar,200),
					new SqlParameter("@m_state", SqlDbType.Int,4),
					new SqlParameter("@m_flag", SqlDbType.VarChar,2000),
					new SqlParameter("@m_zdyqx", SqlDbType.Int,4),
                    new SqlParameter("@m_birth", SqlDbType.DateTime,8),
                    new SqlParameter("@m_KSID", SqlDbType.VarChar,200)
            };
            parameters[0].Value = model.m_id;
            parameters[1].Value = model.m_login;
            parameters[2].Value = model.m_name;
            parameters[3].Value = model.m_password;
            parameters[4].Value = model.m_mobile;
            parameters[5].Value = model.m_mail;
            parameters[6].Value = model.m_idcard;
            parameters[7].Value = model.m_spassword;
            parameters[8].Value = model.m_jiao;
            parameters[9].Value = model.m_bum;
            parameters[10].Value = model.m_duty;
            parameters[11].Value = model.m_xjb;
            parameters[12].Value = model.m_state;
            parameters[13].Value = model.m_flag;
            parameters[14].Value = model.m_zdyqx;
            parameters[15].Value = model.m_birth;
            parameters[16].Value = model.m_KSID;

            DbHelperSQL.RunProcedure("Tunnel_menber_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long m_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
            parameters[0].Value = m_id;

            DbHelperSQL.RunProcedure("Tunnel_menber_Delete", parameters, out rowsAffected);
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

        public DataSet GetList_up(PageBase pb, ref int count)
        {
            SqlParameter[] parameters = 
            {
                new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 255),
                new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                new SqlParameter("@OrderName", SqlDbType.VarChar,255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar,1000)                
            };
            parameters[0].Value = pb.TblName;
            parameters[1].Value = pb.StrGetFields;
            parameters[2].Value = pb.FldName;
            parameters[3].Value = pb.OrderName;
            parameters[4].Value = pb.PageSize;
            parameters[5].Value = pb.PageIndex;
            parameters[6].Value = pb.DoCount;
            parameters[7].Value = pb.OrderType;
            parameters[8].Value = pb.StrWhere;

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
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_menber GetModel(long m_id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@m_id", SqlDbType.BigInt)};
            parameters[0].Value = m_id;

            Tunnel.Model.Tunnel_menber model = new Tunnel.Model.Tunnel_menber();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_menber_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["m_id"].ToString() != "")
                {
                    model.m_id = long.Parse(ds.Tables[0].Rows[0]["m_id"].ToString());
                }
                model.m_login = ds.Tables[0].Rows[0]["m_login"].ToString();
                model.m_name = ds.Tables[0].Rows[0]["m_name"].ToString();
                model.m_password = ds.Tables[0].Rows[0]["m_password"].ToString();
                model.m_mobile = ds.Tables[0].Rows[0]["m_mobile"].ToString();
                if (ds.Tables[0].Rows[0]["m_mail"].ToString() != "")
                {
                    model.m_mail = ds.Tables[0].Rows[0]["m_mail"].ToString() ;
                }
                model.m_idcard = ds.Tables[0].Rows[0]["m_idcard"].ToString();
                model.m_spassword = ds.Tables[0].Rows[0]["m_spassword"].ToString();
                if (ds.Tables[0].Rows[0]["m_jiao"].ToString() != "")
                {
                    model.m_jiao = int.Parse(ds.Tables[0].Rows[0]["m_jiao"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_bum"].ToString() != "")
                {
                    model.m_bum = int.Parse(ds.Tables[0].Rows[0]["m_bum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_duty"].ToString() != "")
                {
                    model.m_duty = int.Parse(ds.Tables[0].Rows[0]["m_duty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["m_xjb"].ToString() != "")
                {
                    model.m_xjb= ds.Tables[0].Rows[0]["m_xjb"].ToString();
                }
                if (ds.Tables[0].Rows[0]["m_state"].ToString() != "")
                {
                    model.m_state = int.Parse(ds.Tables[0].Rows[0]["m_state"].ToString());
                }
                model.m_flag = ds.Tables[0].Rows[0]["m_flag"].ToString();
                if (ds.Tables[0].Rows[0]["m_zdyqx"].ToString() != "")
                {
                    model.m_zdyqx = int.Parse(ds.Tables[0].Rows[0]["m_zdyqx"].ToString());
                }
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["m_birth"].ToString()))
                {
                    model.m_birth = Convert.ToDateTime(ds.Tables[0].Rows[0]["m_birth"].ToString());                    
                }
                model.m_KSID = ds.Tables[0].Rows[0]["m_KSID"].ToString();
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
            strSql.Append("select m_id,m_login,m_name,m_password,m_mobile,m_mail,m_idcard,m_spassword,m_jiao,m_bum,m_duty,m_xjb,m_state,m_flag,m_zdyqx,m_birth,m_online,m_onlinetime,m_counttime,m_KSID ");
            strSql.Append(" FROM Tunnel_menber ");
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
            strSql.Append(" m_id,m_login,m_name,m_password,m_mobile,m_mail,m_idcard,m_spassword,m_jiao,m_bum,m_duty,m_xjb,m_state,m_flag,m_zdyqx,m_birth,m_KSID ");
            strSql.Append(" FROM Tunnel_menber ");
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
            parameters[0].Value = "Tunnel_menber";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

