using System;
using System.Collections.Generic;
using System.Text;
using LTP.Common;
using Tunnel.Model;
using System.Data;
namespace Tunnel.BLL
{
    #region 科室信息业务层成员方法
    public class Tunnel_Performance
    {
        private readonly Tunnel.DAL.Tunnel_Performance dal = new Tunnel.DAL.Tunnel_Performance();
        private Tunnel.DAL.Tunnel_Performance Performance;
        private Tunnel.DAL.Tunnel_Performance m_Performance
        {
            get
            {
                if (null == Performance)
                    Performance = new Tunnel.DAL.Tunnel_Performance();
                return Performance;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_Performance GetModel(int Id)
        {

            return dal.GetModel(Id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_Performance> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_Performance> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_Performance> modelList = new List<Tunnel.Model.Tunnel_Performance>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_Performance model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Performance();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.File = dt.Rows[n]["file"].ToString();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["CreateUser"].ToString() != "")
                    {
                        model.CreateUser = int.Parse(dt.Rows[n]["CreateUser"].ToString());
                    }
                    //model.CreateUser=dt.Rows[n]["CreateUser"].ToString();
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
        public List<Tunnel.Model.Tunnel_Performance> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_Performance> modelList = new List<Tunnel.Model.Tunnel_Performance>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_Performance model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Performance();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.File = dt.Rows[n]["file"].ToString();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["CreateUser"].ToString() != "")
                    {
                        model.CreateUser = int.Parse(dt.Rows[n]["CreateUser"].ToString());
                    }
                    //model.CreateUser=dt.Rows[n]["CreateUser"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }


        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Add(Tunnel.Model.Tunnel_Performance model)
        {
            return Tunnel.DAL.Tunnel_Performance.Add(model);
        }

    } 
    #endregion
}