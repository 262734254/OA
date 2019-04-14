using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tunnel.Data;

namespace Tunnel.DAL
{
    public class Tunnel_InfoItem
    {
        public Tunnel_InfoItem()
        {
        }

        #region 新增一条数据
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="message">实体集</param>
        /// <returns>新增结果</returns>
        public int Add(Tunnel.Model.Tunnel_index index)
        {
            string strSQL = string.Format("INSERT INTO Tunnel_InfoItem (typeid,title,content,imagePaht,htmlSource,setDate,userId,files,bum_bz,del,filename,readUser) "
                        + "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9]','{10}','{11}')", index.TypeId,index.Title,index.Content,index.ImagePaht,
                        index.HtmlSource,index.SetDate,index.UserId,index.Files,index.Bum_bz,0,index.Filename,index.ReadUser);
            object obj = DbHelperSQL.ExecuteSql(strSQL);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 更新数据
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="message">实体集</param>
        /// <returns>列新结果</returns>
        public int Update(Tunnel.Model.Tunnel_index index)
        {
            string strSQL = string.Format("UPDATE Tunnel_InfoItem SET title='{2}',content='{3}',imagePaht='{4}',htmlSource='{5}',setDate='{6}',userId='{7}',files='{8}',bum_bz='{9}',filename='{10}',readUser='{11}' WHERE id={0} AND typeid={1}",
                                            index.Id,index.TypeId,index.Title,index.Content,index.ImagePaht,index.HtmlSource,index.SetDate,index.UserId,index.Files,index.Bum_bz,index.Filename,index.ReadUser);
            object obj = DbHelperSQL.ExecuteSql(strSQL);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="mesID">信息编号</param>
        /// <returns>删除结果</returns>
        public int Delete(int mesID)
        {
            string strSQL = string.Format("UPDATE Tunnel_InfoItem SET del=1 WHERE id={0}", mesID);
            object obj = DbHelperSQL.ExecuteSql(strSQL);
            if (null != obj)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region 获得信息实体集
        /// <summary>
        /// 获得信息实体集
        /// </summary>
        /// <param name="mesID">信息编号</param>
        /// <returns>信息实体集</returns>
        public Tunnel.Model.Tunnel_index GetInfoItemModel(int mesID)
        {
            Tunnel.Model.Tunnel_index model = new Tunnel.Model.Tunnel_index();
            string strSQL = string.Format("SELECT * FROM Tunnel_InfoItem WHERE id={0}", mesID);
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(strSQL))
            {
                if (reader.Read())
                {
                    if (reader["id"].ToString() != "")
                    {
                        model.Id = int.Parse(reader["id"].ToString());
                    }
                    if (reader["typeId"].ToString() != "")
                    {
                        model.TypeId = int.Parse(reader["typeId"].ToString());
                    }
                    model.Title = reader["title"].ToString();
                    model.Content = reader["content"].ToString();
                    model.ImagePaht = reader["imagePaht"].ToString();
                    model.HtmlSource = reader["htmlSource"].ToString();
                    if (reader["setDate"].ToString() != "")
                    {
                        model.SetDate = Convert.ToString(reader["setDate"].ToString());
                    }
                    if (reader["userId"].ToString() != "")
                    {
                        model.UserId = int.Parse(reader["userId"].ToString());
                    }
                    model.Files = reader["files"].ToString();
                    model.Filename = reader["filename"].ToString();
                    model.ReadUser = reader["readUser"].ToString();
                    return model;
                }
            }
            return model;
        }
        #endregion

        #region 获得信息集合
        /// <summary>
        /// 获得信息集合
        /// </summary>
        /// <param name="userID">信息编号</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>信息集合</returns>
        public DataSet GetInfoItemData(string strWhere)
        {
            string strSQL = string.Format("SELECT * FROM Tunnel_InfoItem WHERE {0}", strWhere);
            return DbHelperSQL.Query(strSQL);
        }
        #endregion

        #region 获得分页集合
        /// <summary>
        /// 获得分页集合
        /// </summary>
        /// <param name="pb">页类</param>
        /// <param name="count">总数</param>
        /// <returns>集合</returns>
        public DataSet GetList(Tunnel.Model.PageBase pb, ref int count)
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
        #endregion

    }
}
