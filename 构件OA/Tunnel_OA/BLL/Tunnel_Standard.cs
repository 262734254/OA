using System;
using System.Collections.Generic;
using System.Text;
using Tunnel.Common;
using Tunnel.Model;
using System.Data;

namespace Tunnel.BLL
{
   public  class Tunnel_Standard
    {
        #region 标准规范业务层成员访问方法
        private readonly Tunnel.DAL.Tunnel_Standard dal = new Tunnel.DAL.Tunnel_Standard();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_Standard model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int Id)
        {

            dal.Delete(Id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_Standard GetModel(int Id)
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
        public List<Tunnel.Model.Tunnel_Standard> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_Standard> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_Standard> modelList = new List<Tunnel.Model.Tunnel_Standard>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_Standard model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Standard();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.S_File = dt.Rows[n]["S_File"].ToString();
                    model.S_Title = dt.Rows[n]["S_Title"].ToString();
                    model.S_Name = dt.Rows[n]["S_Name"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["CreateUser"].ToString() != "")
                    {
                        model.CreateUser = int.Parse(dt.Rows[n]["CreateUser"].ToString());
                    }
                    if (dt.Rows[n]["S_bum"].ToString() != "")
                    {
                        model.S_bum = int.Parse(dt.Rows[n]["S_bum"].ToString());
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
        public List<Tunnel.Model.Tunnel_Standard> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_Standard> modelList = new List<Tunnel.Model.Tunnel_Standard>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_Standard model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Standard();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.S_File = dt.Rows[n]["S_File"].ToString();
                    model.S_Title = dt.Rows[n]["S_Title"].ToString();
                    model.S_Name = dt.Rows[n]["S_Name"].ToString();
                    if (dt.Rows[n]["CreateDate"].ToString() != "")
                    {
                        model.CreateDate = DateTime.Parse(dt.Rows[n]["CreateDate"].ToString());
                    }
                    if (dt.Rows[n]["CreateUser"].ToString() != "")
                    {
                        model.CreateUser = int.Parse(dt.Rows[n]["CreateUser"].ToString());
                    }
                    if (dt.Rows[n]["S_bum"].ToString() != "")
                    {
                        model.S_bum = int.Parse(dt.Rows[n]["S_bum"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        
        #endregion
    }
}
