using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// 业务逻辑类Tunnel_vannewpaper 的摘要说明。
    /// </summary>
    public class Tunnel_vannewpaper
    {
        private readonly Tunnel.DAL.Tunnel_vannewpaper dal = new Tunnel.DAL.Tunnel_vannewpaper();
        public Tunnel_vannewpaper()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long v_id)
        {
            return dal.Exists(v_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_vannewpaper model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tunnel.Model.Tunnel_vannewpaper model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long v_id, int v_user, string v_ip)
        {
            dal.Delete(v_id, v_user, v_ip);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_vannewpaper GetModel(long v_id)
        {

            return dal.GetModel(v_id);
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
        public List<Tunnel.Model.Tunnel_vannewpaper> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_vannewpaper> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_vannewpaper> modelList = new List<Tunnel.Model.Tunnel_vannewpaper>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_vannewpaper model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_vannewpaper();
                    model.v_id = Convert.ToInt64(dt.Rows[n]["v_id"].ToString());
                    model.v_title = dt.Rows[n]["v_title"].ToString();
                    model.v_img = dt.Rows[n]["v_img"].ToString();
                    if (dt.Rows[n]["v_file"].ToString() != "")
                    {
                        model.v_file = dt.Rows[n]["v_file"].ToString();
                    }
                    if (dt.Rows[n]["v_user"].ToString() != "")
                    {
                        model.v_user = int.Parse(dt.Rows[n]["v_user"].ToString());
                    }
                    if (dt.Rows[n]["v_sort"].ToString() != "")
                    {
                        model.v_sort = int.Parse(dt.Rows[n]["v_sort"].ToString());
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
        public List<Tunnel.Model.Tunnel_vannewpaper> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_vannewpaper> modelList = new List<Tunnel.Model.Tunnel_vannewpaper>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_vannewpaper model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_vannewpaper();
                    model.v_id = Convert.ToInt64(dt.Rows[n]["v_id"].ToString());
                    model.v_title = dt.Rows[n]["v_title"].ToString();
                    model.v_img = dt.Rows[n]["v_img"].ToString();
                    if (dt.Rows[n]["v_file"].ToString() != "")
                    {
                        model.v_file = dt.Rows[n]["v_file"].ToString();
                    }
                    if (dt.Rows[n]["v_user"].ToString() != "")
                    {
                        model.v_user = int.Parse(dt.Rows[n]["v_user"].ToString());
                    }
                    if (dt.Rows[n]["v_sort"].ToString() != "")
                    {
                        model.v_sort = int.Parse(dt.Rows[n]["v_sort"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        #endregion  成员方法
    }
}

