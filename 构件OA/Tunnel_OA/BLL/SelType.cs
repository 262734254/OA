using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
using Tunnel.DAL;

namespace Tunnel.BLL
{
    
    public class SelType
    {
        private readonly Tunnel.DAL.Tunnel_SelType dal = new Tunnel.DAL.Tunnel_SelType();
        public SelType()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录

        /// </summary>
        public bool Exists(long TypeID)
        {
            return dal.Exists(TypeID);
        }

        public int Add(Tunnel.Model.Tunnel_SelType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tunnel.Model.Tunnel_SelType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int typeID)
        {
            return dal.Delete(typeID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tunnel.Model.Tunnel_SelType GetModel(int TypeID)
        {

            return dal.GetModel(TypeID);
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
       // public DataSet GetList(int Top, string strWhere, string filedOrder)
       // {
       //     return dal.GetList(Top, strWhere, filedOrder);
       // }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_SelType> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Tunnel.Model.Tunnel_SelType> DataTableToList(DataTable dt)
        {
            List<Tunnel.Model.Tunnel_SelType> modelList = new List<Tunnel.Model.Tunnel_SelType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Tunnel.Model.Tunnel_SelType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_SelType();
                    model.TypeID = Convert.ToInt32(dt.Rows[n]["TypeID"].ToString());
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    model.BumID = dt.Rows[n]["BumID"].ToString();
                    model.BumName = dt.Rows[n]["BumName"].ToString();
                    model.ParentID = Convert.ToInt32(dt.Rows[n]["ParentID"].ToString().Trim());
                    model.KSID = Convert.ToInt32(dt.Rows[n]["KSID"].ToString().Trim());
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
        public List<Tunnel.Model.Tunnel_SelType> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_SelType> modelList = new List<Tunnel.Model.Tunnel_SelType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_SelType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_SelType();
                    model.TypeID = Convert.ToInt32(dt.Rows[n]["TypeID"].ToString().Trim());
                    model.TypeName = dt.Rows[n]["TypeName"].ToString().Trim();
                    model.BumID = dt.Rows[n]["BumID"].ToString().Trim();
                    model.BumName = dt.Rows[n]["BumName"].ToString().Trim();
                    model.ParentID = Convert.ToInt32(dt.Rows[n]["ParentID"].ToString().Trim());
                    model.KSID = Convert.ToInt32(dt.Rows[n]["KSID"].ToString().Trim());
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion


    }
}
