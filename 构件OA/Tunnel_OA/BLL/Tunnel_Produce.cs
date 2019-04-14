using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tunnel.Model;

namespace Tunnel.BLL
{
    public class Tunnel_Produce
    {
        #region 内部变量

        #region m_Produce
        private Tunnel.DAL.Tunnel_Produce tProduce;
        private Tunnel.DAL.Tunnel_Produce m_Produce
        {
            get
            {
                if (null == tProduce)
                    tProduce = new Tunnel.DAL.Tunnel_Produce();
                return tProduce;
            }
        }
        #endregion

        #endregion

        public Tunnel_Produce()
        {
        }

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="produce">产品实体集</param>
        /// <returns>添加结果</returns>
        public int Add(Tunnel.Model.Tunnel_Produce produce)
        {
            return m_Produce.Add(produce);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="produce">产品实体集</param>
        /// <returns>修改结果</returns>
        public int Update(Tunnel.Model.Tunnel_Produce produce)
        {
            return m_Produce.Update(produce);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="proID">产品编号</param>
        /// <param name="userID">操作者</param>
        /// <returns>删除结果</returns>
        public int Delete(int proID,int userID)
        {
            return m_Produce.Delete(proID,userID);
        }
        #endregion

        #region 获得产品集合
        /// <summary>
        /// 获得产品集合
        /// </summary>
        /// <param name="proType">产品类型</param>
        /// <returns>产品集合</returns>
        public DataSet GetProduceData(string proType)
        {
            return m_Produce.GetProduceData(proType);
        }
        #endregion

        #region 获得产品集合
        /// <summary>
        /// 获得产品集合
        /// </summary>
        /// <param name="proType">产品类型</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>产品集合</returns>
        public DataSet GetProduceData(string proType,string strWhere)
        {
            return m_Produce.GetProduceData(proType,strWhere);
        }
        #endregion

        #region 获得产品实体集
        /// <summary>
        /// 获得产品实体集
        /// </summary>
        /// <param name="proID">产品编号</param>
        /// <returns>产品实体集</returns>
        public Tunnel.Model.Tunnel_Produce GetProduceModel(int proID)
        {
            return m_Produce.GetProduceModel(proID);
        }
        #endregion


        #region 获得分页集合
        /// <summary>
        /// 获得分页集合
        /// </summary>
        /// <param name="pb">页类</param>
        /// <param name="count">总数</param>
        /// <returns>集合</returns>
        public List<Tunnel.Model.Tunnel_Produce> GetList(PageBase pb, ref int count)
        {
            DataTable dt = m_Produce.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_Produce> modelList = new List<Tunnel.Model.Tunnel_Produce>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_Produce model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_Produce();
                    model.ProID = Convert.ToInt32(dt.Rows[n]["ProID"].ToString());
                    model.ProName = dt.Rows[n]["ProName"].ToString();
                    model.ProTitle = dt.Rows[n]["ProTitle"].ToString();
                    model.ProType = dt.Rows[n]["ProType"].ToString();
                    model.ProSrc = dt.Rows[n]["ProSrc"].ToString();
                    model.CreateUser = Convert.ToInt32(dt.Rows[n]["CreateUser"].ToString());
                    model.CreateDate = Convert.ToDateTime(dt.Rows[n]["CreateDate"]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}
