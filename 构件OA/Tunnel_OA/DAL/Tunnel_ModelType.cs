using System;
using System.Collections.Generic;
using System.Text;
using Tunnel.Data;
using System.Data;
using System.Data.SqlClient;
namespace Tunnel.DAL
{
  public  class Tunnel_ModelType
    {
      public Tunnel_ModelType() { }
        /// <summary>
        /// 新增模块分类
        /// </summary>
        /// <returns></returns>
        public int AddReport(Tunnel.Model.Tunnel_ModelType r)
        {
            int rowsAffected;
            string sql = "Tunnel_ReportModel_Add";
            IDataParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Name",r.Re_Name),
                new SqlParameter("@Num",r.Re_Num),
                new SqlParameter("@Parentid",r.Re_ParentId)
            };
            DbHelperSQL.RunProcedure(sql, para,out rowsAffected);
            return rowsAffected;
            //return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, para);
        }

        /// <summary>
        /// 根据模板ID得到模板对象
        /// </summary>
        /// <returns></returns>
        public Tunnel.Model.Tunnel_ModelType GetReportById(int id)
        {
            Tunnel.Model.Tunnel_ModelType r = new Tunnel.Model.Tunnel_ModelType();
            string sql = "Tunnel_ReportModel_ModelById";
            IDataParameter[]  para = new SqlParameter[]
            {
                new SqlParameter("@id",id)
                
            };
            using (SqlDataReader reader =DbHelperSQL.RunProcedure(sql,para))
            {
                if (reader.Read())
                {
                   
                    r.Re_Id = Convert.ToInt32(reader["Re_Id"]);
                    r.Re_Name = reader["Re_Name"].ToString();
                    r.Re_Num = Convert.ToInt32(reader["Re_Num"]);
                    r.Re_ParentId = Convert.ToInt32(reader["Re_ParentId"]);
  
                }

            }
            return r;
        }
        /// <summary>
        /// 获取所有父模块
        /// </summary>
        /// <returns></returns>
        public IList<Tunnel.Model.Tunnel_ModelType> GetAllParent()
        {
            IList<Tunnel.Model.Tunnel_ModelType> list=new List<Tunnel.Model.Tunnel_ModelType>();
            string sql = "Tunnel_ReportModel_GetAllParent";
            IDataParameter[] para = new SqlParameter[] { };
         
            using (SqlDataReader reader = DbHelperSQL.RunProcedure(sql,para))
            {
                while (reader.Read())
                {
                    Tunnel.Model.Tunnel_ModelType r = new Tunnel.Model.Tunnel_ModelType();
                    r.Re_Id = Convert.ToInt32(reader["Re_Id"]);
                    r.Re_Name = reader["Re_Name"].ToString();
                    r.Re_Num = Convert.ToInt32(reader["Re_Num"]);
                    r.Re_ParentId = Convert.ToInt32(reader["Re_ParentId"]);
                    list.Add(r);
                }
               
            }
            return list;
        }
        /// <summary>
        /// 根据父模块获取所有子模块
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IList<Tunnel.Model.Tunnel_ModelType> GetAllNode(int parentId)
        {
            IList<Tunnel.Model.Tunnel_ModelType> list = new List<Tunnel.Model.Tunnel_ModelType>();
            string sql = "Tunnel_ReportModel_GetAllNode";
            IDataParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ParentId",parentId)
            };

            using (SqlDataReader reader = DbHelperSQL.RunProcedure(sql,para))
            {
                while (reader.Read())
                {
                    Tunnel.Model.Tunnel_ModelType r = new Tunnel.Model.Tunnel_ModelType();
                    r.Re_Id = Convert.ToInt32(reader["Re_Id"]);
                    r.Re_Name = reader["Re_Name"].ToString();
                    r.Re_Num = Convert.ToInt32(reader["Re_Num"]);
                    r.Re_ParentId = Convert.ToInt32(reader["Re_ParentId"]);
                    list.Add(r);
                }

            }
            return list;
        }

      
    }
}
