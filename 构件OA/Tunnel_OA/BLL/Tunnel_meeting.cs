using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// 业务逻辑类Tunnel_meeting 的摘要说明。
    /// </summary>
    public class Tunnel_meeting
    {
        private readonly Tunnel.DAL.Tunnel_meeting dal = new Tunnel.DAL.Tunnel_meeting();
        public Tunnel_meeting()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long m_id)
        {
            return dal.Exists(m_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_meeting model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_meeting model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(long m_id, int m_user, string m_ip)
        {
            return dal.Delete(m_id, m_user, m_ip);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_meeting GetModel(long m_id)
        {

            return dal.GetModel(m_id);
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
        public List<Tunnel.Model.Tunnel_meeting> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_meeting> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_meeting> modelList = new List<Tunnel.Model.Tunnel_meeting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_meeting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_meeting();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_title = dt.Rows[n]["m_title"].ToString();
                    model.m_content = dt.Rows[n]["m_content"].ToString();
                    model.m_menber = dt.Rows[n]["m_menber"].ToString();
                    if (dt.Rows[n]["m_startime"].ToString() != "")
                    {
                        model.m_startime = DateTime.Parse(dt.Rows[n]["m_startime"].ToString());
                    }
                    if (dt.Rows[n]["m_endtime"].ToString() != "")
                    {
                        model.m_endtime = DateTime.Parse(dt.Rows[n]["m_endtime"].ToString());
                    }
                    if (dt.Rows[n]["m_user"].ToString() != "")
                    {
                        model.m_user = int.Parse(dt.Rows[n]["m_user"].ToString());
                    }
                    if (dt.Rows[n]["m_state"].ToString() != "")
                    {
                        model.m_state = int.Parse(dt.Rows[n]["m_state"].ToString());
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
        public List<Tunnel.Model.Tunnel_meeting> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_meeting> modelList = new List<Tunnel.Model.Tunnel_meeting>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_meeting model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_meeting();
                    model.m_id = Convert.ToInt64(dt.Rows[n]["m_id"].ToString());
                    model.m_title = dt.Rows[n]["m_title"].ToString();
                    model.m_content = dt.Rows[n]["m_content"].ToString();
                    model.m_menber = dt.Rows[n]["m_menber"].ToString();
                    if (dt.Rows[n]["m_startime"].ToString() != "")
                    {
                        model.m_startime = DateTime.Parse(dt.Rows[n]["m_startime"].ToString());
                    }
                    if (dt.Rows[n]["m_endtime"].ToString() != "")
                    {
                        model.m_endtime = DateTime.Parse(dt.Rows[n]["m_endtime"].ToString());
                    }
                    if (dt.Rows[n]["m_user"].ToString() != "")
                    {
                        model.m_user = int.Parse(dt.Rows[n]["m_user"].ToString());
                    }
                    if (dt.Rows[n]["m_state"].ToString() != "")
                    {
                        model.m_state = int.Parse(dt.Rows[n]["m_state"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  成员方法
    }
}

