using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// 业务逻辑类Tunnel_project 的摘要说明。
    /// </summary>
    public class Tunnel_project
    {
        private readonly Tunnel.DAL.Tunnel_project dal = new Tunnel.DAL.Tunnel_project();
        public Tunnel_project()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long p_id)
        {
            return dal.Exists(p_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_project model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_project model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long p_id, int p_user, string p_ip)
        {
            dal.Delete(p_id, p_user, p_ip);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_project GetModel(long p_id)
        {

            return dal.GetModel(p_id);
        }



        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_project> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_project> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_project> modelList = new List<Tunnel.Model.Tunnel_project>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_project model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_project();
                    model.p_id = Convert.ToInt64(dt.Rows[n]["p_id"].ToString());
                    model.p_name = dt.Rows[n]["p_name"].ToString();
                    model.p_yname = dt.Rows[n]["p_yname"].ToString();
                    model.p_jname = dt.Rows[n]["p_jname"].ToString();
                    model.p_xfile = dt.Rows[n]["p_xfile"].ToString();
                    model.p_zfile = dt.Rows[n]["p_zfile"].ToString();
                    if (dt.Rows[n]["p_user"].ToString() != "")
                    {
                        model.p_user = int.Parse(dt.Rows[n]["p_user"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总数</param>
        /// <returns></returns>
        public List<Tunnel.Model.Tunnel_project> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_project> modelList = new List<Tunnel.Model.Tunnel_project>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_project model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_project();
                    model.p_id = Convert.ToInt64(dt.Rows[n]["p_id"].ToString());
                    model.p_name = dt.Rows[n]["p_name"].ToString();
                    model.p_yname = dt.Rows[n]["p_yname"].ToString();
                    model.p_jname = dt.Rows[n]["p_jname"].ToString();
                    model.p_xfile = dt.Rows[n]["p_xfile"].ToString();
                    model.p_zfile = dt.Rows[n]["p_zfile"].ToString();
                    if (dt.Rows[n]["p_user"].ToString() != "")
                    {
                        model.p_user = int.Parse(dt.Rows[n]["p_user"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  成员方法
    }
}

