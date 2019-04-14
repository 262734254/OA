using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// 业务逻辑类Tunnel_report 的摘要说明。
    /// </summary>
    public class Tunnel_report
    {
        private readonly Tunnel.DAL.Tunnel_report dal = new Tunnel.DAL.Tunnel_report();
        public Tunnel_report()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long r_id)
        {
            return dal.Exists(r_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_report model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_report model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long r_id, int r_user, string r_ip)
        {
            dal.Delete(r_id, r_user, r_ip);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_report GetModel(long r_id)
        {

            return dal.GetModel(r_id);
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
        public List<Tunnel.Model.Tunnel_report> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_report> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_report> modelList = new List<Tunnel.Model.Tunnel_report>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_report model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_report();
                    model.r_id = Convert.ToInt64(dt.Rows[n]["r_id"].ToString());
                    model.r_title = dt.Rows[n]["r_title"].ToString();
                    model.r_file = dt.Rows[n]["r_file"].ToString();
                    if (dt.Rows[n]["r_time"].ToString() != "")
                    {
                        model.r_time = DateTime.Parse(dt.Rows[n]["r_time"].ToString());
                    }
                    if (dt.Rows[n]["r_from"].ToString() != "")
                    {
                        model.r_from = int.Parse(dt.Rows[n]["r_from"].ToString());
                    }
                    if (dt.Rows[n]["r_user"].ToString() != "")
                    {
                        model.r_user = int.Parse(dt.Rows[n]["r_user"].ToString());
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
        public List<Tunnel.Model.Tunnel_report> GetList(PageBase pb, ref int count)
        {
            DataSet ds = dal.GetList(pb, ref count);
            List<Tunnel.Model.Tunnel_report> modelList = new List<Tunnel.Model.Tunnel_report>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_report model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_report();
                    if (ds.Tables[0].Rows[n]["r_id"].ToString() != "")
                    {
                        model.r_id = long.Parse(ds.Tables[0].Rows[n]["r_id"].ToString());
                    }
                    model.r_title = ds.Tables[0].Rows[n]["r_title"].ToString();
                    model.r_file = ds.Tables[0].Rows[n]["r_file"].ToString();
                    if (ds.Tables[0].Rows[n]["r_time"].ToString() != "")
                    {
                        model.r_time = DateTime.Parse(ds.Tables[0].Rows[n]["r_time"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["r_from"].ToString() != "")
                    {
                        model.r_from = int.Parse(ds.Tables[0].Rows[n]["r_from"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["r_user"].ToString() != "")
                    {
                        model.r_user = int.Parse(ds.Tables[0].Rows[n]["r_user"].ToString());
                    }
                    model.r_Content = ds.Tables[0].Rows[n]["r_content"].ToString();
                    model.r_toEmail = ds.Tables[0].Rows[n]["r_toemail"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  成员方法
    }
}

