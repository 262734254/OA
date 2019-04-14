using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// 业务逻辑类Tunnel_file 的摘要说明。
    /// </summary>
    public class Tunnel_file
    {
        private readonly Tunnel.DAL.Tunnel_file dal = new Tunnel.DAL.Tunnel_file();
        public Tunnel_file()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long f_id)
        {
            return dal.Exists(f_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_file model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_file model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(long f_id, int f_user, string f_ip)
        {
            dal.Delete(f_id, f_user, f_ip);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_file GetModel(long f_id)
        {

            return dal.GetModel(f_id);
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
        public List<Tunnel.Model.Tunnel_file> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_file> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_file> modelList = new List<Tunnel.Model.Tunnel_file>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_file model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_file();
                    model.f_id = Convert.ToInt64(dt.Rows[n]["f_id"].ToString());
                    model.f_title = dt.Rows[n]["f_title"].ToString();
                    if (dt.Rows[n]["f_file"].ToString() != "")
                    {
                        model.f_file = dt.Rows[n]["f_file"].ToString();
                    }
                    model.f_size = dt.Rows[n]["f_size"].ToString();
                    model.f_sort = Convert.ToInt32(dt.Rows[n]["f_sort"].ToString());
                    if (dt.Rows[n]["f_addtime"].ToString() != "")
                    {
                        model.f_addtime = DateTime.Parse(dt.Rows[n]["f_addtime"].ToString());
                    }
                    if (dt.Rows[n]["f_user"].ToString() != "")
                    {
                        model.f_user = int.Parse(dt.Rows[n]["f_user"].ToString());
                    }
                    model.f_juser = dt.Rows[n]["f_juser"].ToString();
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
        public List<Tunnel.Model.Tunnel_file> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_file> modelList = new List<Tunnel.Model.Tunnel_file>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_file model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_file();
                    model.f_id = Convert.ToInt64(dt.Rows[n]["f_id"].ToString());
                    model.f_title = dt.Rows[n]["f_title"].ToString();
                    model.f_file = dt.Rows[n]["f_file"].ToString();
                    model.f_size = dt.Rows[n]["f_size"].ToString();
                    model.f_sort = Convert.ToInt32(dt.Rows[n]["f_sort"].ToString());
                    if (dt.Rows[n]["f_addtime"].ToString() != "")
                    {
                        model.f_addtime = DateTime.Parse(dt.Rows[n]["f_addtime"].ToString());
                    }
                    if (dt.Rows[n]["f_user"].ToString() != "")
                    {
                        model.f_user = int.Parse(dt.Rows[n]["f_user"].ToString());
                    }
                    model.f_juser = dt.Rows[n]["f_juser"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  成员方法
    }
}

