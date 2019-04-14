using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
    /// <summary>
    /// 业务逻辑类Tunnel_information 的摘要说明。
    /// </summary>
    public class Tunnel_information
    {
        private readonly Tunnel.DAL.Tunnel_information dal = new Tunnel.DAL.Tunnel_information();
        public Tunnel_information()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long i_id)
        {
            return dal.Exists(i_id);
        }

        /// <summary>
        /// 查询首页显示的图片
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public string selectIndex(int typeId)
        {
            return dal.selectIndex(typeId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_information model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_viewTable model)
        {
            return dal.Add(model);
        }

        public int Add(Tunnel.Model.Tunnel_index model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_information model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(long i_id, int i_user, string i_ip)
        {
            return dal.Delete(i_id, i_user, i_ip);
        }

        /// <summary>
        /// 删除首页信息一条数据
        /// </summary>
        public int Delete(int i_id)
        {
            return dal.Delete(i_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_information GetModel(long i_id, int i_user, string i_ip)
        {
            return dal.GetModel(i_id, i_user, i_ip);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_index GetModel(long i_id)
        {
            return dal.GetModel(i_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_information GetModel(string i_id)
        {
            return dal.GetModel(i_id);
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
        public List<Tunnel.Model.Tunnel_information> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_information> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_information model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_information();
                    model.i_id = Convert.ToInt64(dt.Rows[n]["i_id"].ToString());
                    model.i_title = dt.Rows[n]["i_title"].ToString();
                    if (dt.Rows[n]["i_sort"].ToString() != "")
                    {
                        model.i_sort = int.Parse(dt.Rows[n]["i_sort"].ToString());
                    }
                    if (dt.Rows[n]["i_user"].ToString() != "")
                    {
                        model.i_user = int.Parse(dt.Rows[n]["i_user"].ToString());
                    }
                    if (dt.Rows[n]["i_time"].ToString() != "")
                    {
                        model.i_time = DateTime.Parse(dt.Rows[n]["i_time"].ToString());
                    }
                    if (dt.Rows[n]["i_hit"].ToString() != "")
                    {
                        model.i_hit = int.Parse(dt.Rows[n]["i_hit"].ToString());
                    }
                    model.i_content = dt.Rows[n]["i_content"].ToString();
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
        public List<Tunnel.Model.Tunnel_information> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_information> modelList = new List<Tunnel.Model.Tunnel_information>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_information model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_information();
                    model.i_id = Convert.ToInt64(dt.Rows[n]["i_id"].ToString());
                    model.i_title = dt.Rows[n]["i_title"].ToString();
                    if (dt.Rows[n]["i_sort"].ToString() != "")
                    {
                        model.i_sort = int.Parse(dt.Rows[n]["i_sort"].ToString());
                    }
                    if (dt.Rows[n]["i_user"].ToString() != "")
                    {
                        model.i_user = int.Parse(dt.Rows[n]["i_user"].ToString());
                    }
                    if (dt.Rows[n]["i_time"].ToString() != "")
                    {
                        model.i_time = DateTime.Parse(dt.Rows[n]["i_time"].ToString());
                    }
                    if (dt.Rows[n]["i_hit"].ToString() != "")
                    {
                        model.i_hit = int.Parse(dt.Rows[n]["i_hit"].ToString());
                    }
     
                     model.i_files = dt.Rows[n]["i_files"].ToString();
                    model.i_content = dt.Rows[n]["i_content"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总数</param>
        /// <returns></returns>
        public List<Tunnel.Model.Tunnel_viewTable> GetList2(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList2(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_viewTable> modelList = new List<Tunnel.Model.Tunnel_viewTable>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_viewTable model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_viewTable();
                    model.Id = Convert.ToInt32(dt.Rows[n]["id"].ToString());
                    model.ObjId =  Convert.ToInt32(dt.Rows[n]["objId"].ToString());
                    model.TypeId = int.Parse(dt.Rows[n]["typeId"].ToString());
                    model.UserId = int.Parse(dt.Rows[n]["userId"].ToString());
                    model.SetDate = dt.Rows[n]["setDate"].ToString();
                    model.Content = dt.Rows[n]["content"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总数</param>
        /// <returns></returns>
        public List<Tunnel.Model.Tunnel_index> GetList3(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList2(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_index> modelList = new List<Tunnel.Model.Tunnel_index>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_index model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_index();
                    model.Id = Convert.ToInt32(dt.Rows[n]["id"].ToString());
                    model.TypeId = int.Parse(dt.Rows[n]["typeId"].ToString());
                    model.UserId = int.Parse(dt.Rows[n]["userId"].ToString());
                    model.SetDate = dt.Rows[n]["setDate"].ToString();
                    model.Title = dt.Rows[n]["title"].ToString();
                    model.Content = dt.Rows[n]["content"].ToString();
                    model.ImagePaht = dt.Rows[n]["ImagePaht"].ToString();
                    model.HtmlSource = dt.Rows[n]["HtmlSource"].ToString();
                    model.Filename = dt.Rows[n]["filename"].ToString();
                    model.ReadUser = dt.Rows[n]["readUser"].ToString().Trim();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  成员方法
    }
}

