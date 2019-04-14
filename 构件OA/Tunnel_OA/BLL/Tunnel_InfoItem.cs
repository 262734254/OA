using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tunnel.Model;

namespace Tunnel.BLL
{
    public class Tunnel_InfoItem
    {
        public Tunnel_InfoItem()
        {
        }

        #region 内部变量

        #region m_Message
        private Tunnel.DAL.Tunnel_InfoItem infoItem;
        private Tunnel.DAL.Tunnel_InfoItem m_InfoItem
        {
            get
            {
                if (null == infoItem)
                    infoItem = new Tunnel.DAL.Tunnel_InfoItem();
                return infoItem;
            }
        }
        #endregion

        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="message">信息集合</param>
        /// <returns>添加结果</returns>
        public int Add(Tunnel.Model.Tunnel_index message)
        {
            return m_InfoItem.Add(message);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="message">信息集合</param>
        /// <returns>修改结果</returns>
        public int Update(Tunnel.Model.Tunnel_index message)
        {
            return m_InfoItem.Update(message);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="mesID">信息编号</param>
        /// <returns>删除结果</returns>
        public int Delete(int mesID)
        {
            return m_InfoItem.Delete(mesID);
        }
        #endregion

        #region 获得信息实体集
        /// <summary>
        /// 获得信息实体集
        /// </summary>
        /// <param name="mesID">住处编号</param>
        /// <returns>信息实体集</returns>
        //public Tunnel.Model.Tunnel_index GetMessageModel(int mesID)
        //{
        //    return m_InfoItem.GetMessageModel(mesID);
        //}
        #endregion

        #region 获得信息集合
        /// <summary>
        /// 获得信息集合
        /// </summary>
        /// <param name="userID">操作者</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns>信息集合</returns>
        //public DataSet GetMessageData(string strWhere)
        //{
        //    return m_InfoItem.GetMessageData(strWhere);
        //}
        #endregion

        #region 获得分页集合
        /// <summary>
        /// 获得分页集合
        /// </summary>
        /// <param name="pb">页类</param>
        /// <param name="count">总数</param>
        /// <returns>集合</returns>
        public List<Tunnel.Model.Tunnel_index> GetList(PageBase pb, ref int count)
        {
            //DataTable dt = m_InfoItem.GetList(pb, ref count).Tables[0];
            //List<Tunnel.Model.Tunnel_index> modelList = new List<Tunnel.Model.Tunnel_index>();
            //int rowsCount = dt.Rows.Count;
            //if (rowsCount > 0 && pb.DoCount == 0)
            //{
            //    Tunnel.Model.Tunnel_index model;
            //    for (int n = 0; n < rowsCount; n++)
            //    {
            //        model = new Tunnel.Model.Tunnel_Message();
            //        model.MesID = Convert.ToInt32(dt.Rows[n]["MesID"].ToString());
            //        model.MesTitle = dt.Rows[n]["MesTitle"].ToString();
            //        model.MesContent = dt.Rows[n]["MesContent"].ToString();
            //        model.MesDate = Convert.ToDateTime(dt.Rows[n]["MesDate"]);
            //        model.MesUser = Convert.ToInt32(dt.Rows[n]["MesUser"].ToString());
            //        modelList.Add(model);
            //    }
            //}
            //return modelList;
            return null;
        }
        #endregion
    }
}
