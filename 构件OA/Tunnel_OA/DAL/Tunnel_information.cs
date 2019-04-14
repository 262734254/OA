using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tunnel.Data;
using Tunnel.Model;//请先添加引用
namespace Tunnel.DAL
{
    /// <summary>
    /// 数据访问类Tunnel_information。

    /// </summary>
    public class Tunnel_information
    {
        public Tunnel_information()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录

        /// </summary>
        public bool Exists(long i_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.BigInt)};
            parameters[0].Value = i_id;

            int result = DbHelperSQL.RunProcedure("Tunnel_information_Exists", parameters, out rowsAffected);
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
        public int Add(Tunnel.Model.Tunnel_information model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,8),
					new SqlParameter("@i_title", SqlDbType.VarChar,100),
					new SqlParameter("@i_sort", SqlDbType.Int,4),
					new SqlParameter("@i_user", SqlDbType.Int,4),
					new SqlParameter("@i_time", SqlDbType.DateTime),
					new SqlParameter("@i_hit", SqlDbType.Int,4),
					new SqlParameter("@i_content", SqlDbType.Text),
                    new SqlParameter("@i_ip", SqlDbType.VarChar,20),
                    new SqlParameter("@i_files",SqlDbType.VarChar,500),
                    new SqlParameter("@i_audituser",SqlDbType.Int),
                    new SqlParameter("@i_auditmark",SqlDbType.VarChar,500),
                    new SqlParameter("@i_audittime",SqlDbType.VarChar,30)
                    
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.i_title;
            parameters[2].Value = model.i_sort;
            parameters[3].Value = model.i_user;
            parameters[4].Value = model.i_time;
            parameters[5].Value = model.i_hit;
            parameters[6].Value = model.i_content;
            parameters[7].Value = model.i_Ip;
            parameters[8].Value = model.i_files;
            parameters[9].Value = model.i_audituser;
            parameters[10].Value = model.i_auditmark;
            parameters[11].Value = model.i_audittime;


            DbHelperSQL.RunProcedure("Tunnel_information_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }


        /// <summary>
        ///  增加一条数据

        /// </summary>
        public int Add(Tunnel.Model.Tunnel_viewTable model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,8),
					new SqlParameter("@objId", SqlDbType.Int,8),
                    new SqlParameter("@typeId", SqlDbType.Int,8),
					new SqlParameter("@content", SqlDbType.VarChar,800),
					new SqlParameter("@userId", SqlDbType.Int,8),
                    
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.ObjId;
            parameters[2].Value = model.TypeId;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.UserId;

            DbHelperSQL.RunProcedure("UP_ViewTable_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        public int Add(Tunnel.Model.Tunnel_index model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,8),
					new SqlParameter("@typeId", SqlDbType.Int,8),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@content", SqlDbType.Text),
					new SqlParameter("@imagePaht", SqlDbType.VarChar,100),
					new SqlParameter("@htmlSource", SqlDbType.Text),
					new SqlParameter("@userId", SqlDbType.Int,8),
                    new SqlParameter("@files", SqlDbType.VarChar,500),
                    new SqlParameter("@bum_bz",SqlDbType.Int,4),
                    new SqlParameter("@filename",SqlDbType.VarChar,500),
                    new SqlParameter("@readUser",SqlDbType.VarChar,500),};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.ImagePaht;
            parameters[5].Value = model.HtmlSource;
            parameters[6].Value = model.UserId;
            parameters[7].Value = model.Files;
            parameters[8].Value = model.Bum_bz;
            parameters[9].Value = model.Filename;
            parameters[10].Value = model.ReadUser;



            DbHelperSQL.RunProcedure("UP_Tunnel_Index_ADD", parameters, out rowsAffected);
            return (int)parameters[0].Value;
        }

        /// <summary>
        ///  更新一条数据

        /// </summary>
        public int Update(Tunnel.Model.Tunnel_information model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.Int,8),
					new SqlParameter("@i_title", SqlDbType.VarChar,100),
					new SqlParameter("@i_sort", SqlDbType.Int,4),
					new SqlParameter("@i_user", SqlDbType.Int,4),
					new SqlParameter("@i_time", SqlDbType.DateTime),
					new SqlParameter("@i_hit", SqlDbType.Int,4),
					new SqlParameter("@i_content", SqlDbType.Text),
                    new SqlParameter("@i_files", SqlDbType.VarChar,500),
                    new SqlParameter("@i_ip", SqlDbType.VarChar,20),
                    new SqlParameter("@i_audituser",SqlDbType.Int),
                    new SqlParameter("@i_auditmark",SqlDbType.VarChar,500),
                    new SqlParameter("@i_audittime",SqlDbType.VarChar,30),
					new SqlParameter("@i_idout", SqlDbType.Int,8)
                    
            };
            parameters[0].Value = model.i_id;
            parameters[1].Value = model.i_title;
            parameters[2].Value = model.i_sort;
            parameters[3].Value = model.i_user;
            parameters[4].Value = model.i_time;
            parameters[5].Value = model.i_hit;
            parameters[6].Value = model.i_content;
            parameters[7].Value = model.i_files;
            parameters[8].Value = model.i_Ip;
            parameters[9].Value = model.i_audituser;
            parameters[10].Value = model.i_auditmark;
            parameters[11].Value = model.i_audittime;
            parameters[12].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("Tunnel_information_Update", parameters, out rowsAffected);
            return (int)parameters[12].Value;
        }

        /// <summary>
        /// 删除一条数据

        /// </summary>
        public int Delete(long i_id, int i_user, string i_ip)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.BigInt),
                    new SqlParameter("@i_user", SqlDbType.Int),
                    new SqlParameter("@i_ip", SqlDbType.VarChar,20)
            
            };
            parameters[0].Value = i_id;
            parameters[1].Value = i_user;
            parameters[2].Value = i_ip;

            return DbHelperSQL.RunProcedure("Tunnel_information_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除首页信息一条数据

        /// </summary>
        public int Delete(long i_id)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int),
            
            };
            parameters[0].Value = i_id;

            return DbHelperSQL.RunProcedure("UP_Tunnel_Index_Delete", parameters, out rowsAffected);
        }

        /// <summary>
        /// 得到一个对象实体

        /// </summary>
        public Tunnel.Model.Tunnel_information GetModel(long i_id, int i_user, string i_ip)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@i_id", SqlDbType.BigInt),
                    new SqlParameter("@i_user", SqlDbType.Int),
                    new SqlParameter("@i_ip", SqlDbType.VarChar)
            
            };
            parameters[0].Value = i_id;
            parameters[1].Value = i_user;
            parameters[2].Value = i_ip;

            Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
            DataSet ds = DbHelperSQL.RunProcedure("Tunnel_information_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["i_id"].ToString() != "")
                {
                    model.i_id = long.Parse(ds.Tables[0].Rows[0]["i_id"].ToString());
                }
                model.i_title = ds.Tables[0].Rows[0]["i_title"].ToString();
                if (ds.Tables[0].Rows[0]["i_sort"].ToString() != "")
                {
                    model.i_sort = int.Parse(ds.Tables[0].Rows[0]["i_sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_user"].ToString() != "")
                {
                    model.i_user = int.Parse(ds.Tables[0].Rows[0]["i_user"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_time"].ToString() != "")
                {
                    model.i_time = DateTime.Parse(ds.Tables[0].Rows[0]["i_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_hit"].ToString() != "")
                {
                    model.i_hit = int.Parse(ds.Tables[0].Rows[0]["i_hit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_files"].ToString() != "")
                {
                    model.i_files = ds.Tables[0].Rows[0]["i_files"].ToString();
                }
                model.i_content = ds.Tables[0].Rows[0]["i_content"].ToString();
                if (ds.Tables[0].Rows[0]["i_audituser"].ToString() != "")
                {
                    model.i_audituser = Convert.ToInt32(ds.Tables[0].Rows[0]["i_audituser"]);
                }
                if (ds.Tables[0].Rows[0]["i_auditmark"].ToString() != "")
                {
                    model.i_auditmark = ds.Tables[0].Rows[0]["i_auditmark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["i_audittime"].ToString() != "")
                {
                    model.i_audittime = ds.Tables[0].Rows[0]["i_audittime"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体

        /// </summary>
        public Tunnel.Model.Tunnel_index GetModel(long i_id)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt),
            
            };
            parameters[0].Value = i_id;

            Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
            DataSet ds = DbHelperSQL.RunProcedure("UP_Tunnel_Index_GetModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                int n = 0;
                model.Id = Convert.ToInt32(dt.Rows[n]["id"].ToString());
                model.TypeId = int.Parse(dt.Rows[n]["typeId"].ToString());
                model.UserId = int.Parse(dt.Rows[n]["userId"].ToString());
                model.SetDate = dt.Rows[n]["setDate"].ToString();
                model.Title = dt.Rows[n]["title"].ToString();
                model.Content = dt.Rows[n]["content"].ToString();
                model.ImagePaht = dt.Rows[n]["ImagePaht"].ToString();
                model.HtmlSource = dt.Rows[n]["HtmlSource"].ToString();
                model.Files = dt.Rows[n]["files"].ToString();
                model.Filename = dt.Rows[n]["filename"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体

        /// </summary>
        public Tunnel.Model.Tunnel_information GetModel(string i_id)
        {

            Tunnel.Model.Tunnel_information model = new Tunnel.Model.Tunnel_information();
            SqlDataReader reader = DbHelperSQL.ExecuteReader("select * from tunnel_information where i_id=" + i_id + "");
            if (reader.Read())
            {
                if (reader["i_id"].ToString() != "")
                {
                    model.i_id = long.Parse(reader["i_id"].ToString());
                }
                model.i_title = reader["i_title"].ToString();
                if (reader["i_sort"].ToString() != "")
                {
                    model.i_sort = int.Parse(reader["i_sort"].ToString());
                }
                if (reader["i_user"].ToString() != "")
                {
                    model.i_user = int.Parse(reader["i_user"].ToString());
                }
                if (reader["i_time"].ToString() != "")
                {
                    model.i_time = DateTime.Parse(reader["i_time"].ToString());
                }
                if (reader["i_hit"].ToString() != "")
                {
                    model.i_hit = int.Parse(reader["i_hit"].ToString());
                }
                if (reader["i_audituser"].ToString() != "")
                {
                    model.i_audituser = Convert.ToInt32(reader["i_audituser"]);
                }
                if (reader["i_auditmark"].ToString() != "")
                {
                    model.i_auditmark = reader["i_auditmark"].ToString();
                }
                if (reader["i_audittime"].ToString() != "")
                {
                    model.i_audittime = reader["i_audittime"].ToString();
                }
                model.i_content = reader["i_content"].ToString();
                model.i_files = reader["i_files"].ToString();
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
            strSql.Append("select i_id,i_title,i_sort,i_user,i_time,i_hit,i_content,i_audituser,i_auditmark,i_audittime ");
            strSql.Append(" FROM Tunnel_information ");
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
            strSql.Append(" i_id,i_title,i_sort,i_user,i_time,i_hit,i_content,i_audituser,i_auditmark,i_audittime ");
            strSql.Append(" FROM Tunnel_information ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据

        /// </summary>
        public string selectIndex(int typeId)
        {
            string image = string.Empty;
            try
            {
                SqlParameter[] parameters = 
            {
                new SqlParameter("@typeId", SqlDbType.Int,8),
            };
                parameters[0].Value = typeId;

                DataSet ds = new DataSet();
                ds = DbHelperSQL.RunProcedure("selectIndex", parameters, "ds");
                if (ds != null)
                {
                    if (ds.Tables.Count == 1)
                    {
                        if (ds.Tables[0].Rows[0][0] != null)
                        {
                            image = ds.Tables[0].Rows[0][0].ToString();
                            string[] arr = image.Split('|');
                            image = arr[0].ToString();
                        }
                    }
                }
            }
            catch
            {

            }
            return image;
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
                new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.NVarChar, 255),
                new SqlParameter("@fldName", SqlDbType.NVarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar,5000),
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
        /// 分页获取数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总条数</param>
        /// <returns></returns>
        public DataSet GetList2(PageBase pb, ref int count)
        {
            SqlParameter[] parameters = 
            {
                new SqlParameter("@tblName", SqlDbType.NVarChar, 255),
                new SqlParameter("@strGetFields", SqlDbType.VarChar, 255),
                new SqlParameter("@fldName", SqlDbType.NVarChar, 255),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@doCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar,5500),
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

