using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tunnel.Model;

namespace Tunnel.BLL
{
    public class Tunnel_FilesManage
    {
        #region 内部变量
        private Tunnel.DAL.Tunnel_FilesManage filesManageDAL;
        private Tunnel.DAL.Tunnel_FilesManage m_FilesManageDAL
        {
            get
            {
                if (null == filesManageDAL)
                {
                    filesManageDAL = new Tunnel.DAL.Tunnel_FilesManage();
                }
                return filesManageDAL;
            }
        }
        #endregion
        public Tunnel_FilesManage()
        {
        }

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="files">档案实体集</param>
        /// <returns>添加结果</returns>
        public int Add(Tunnel.Model.Tunnel_FilesManage files)
        {
            return m_FilesManageDAL.Add(files);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="files">档案实体集</param>
        /// <returns>修改结果</returns>
        public int Update(Tunnel.Model.Tunnel_FilesManage files)
        {
            return m_FilesManageDAL.Update(files);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fid">档案编号</param>
        /// <param name="userID">操作者</param>
        /// <returns>删除结果</returns>
        public int Delete(int fid, int userID)
        {
            return m_FilesManageDAL.Del(fid, userID);
        }
        #endregion

        #region 获得产品实体集
        /// <summary>
        /// 获得产品实体集
        /// </summary>
        /// <param name="fid">产品编号</param>
        /// <returns>产品实体集</returns>
        public Tunnel.Model.Tunnel_FilesManage GetFilesManageModel(int fid)
        {
            return m_FilesManageDAL.GetFilesManageModel(fid);
        }
        #endregion

        #region 获得分页集合
        /// <summary>
        /// 获得分页集合
        /// </summary>
        /// <param name="pb">页类</param>
        /// <param name="count">总数</param>
        /// <returns>集合</returns>
        public List<Tunnel.Model.Tunnel_FilesManage> GetList(PageBase pb, ref int count)
        {
            DataTable dt = m_FilesManageDAL.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_FilesManage> modelList = new List<Tunnel.Model.Tunnel_FilesManage>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_FilesManage model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_FilesManage();
                    model.F_ID = Convert.ToInt32(dt.Rows[n]["F_ID"].ToString());
                    model.F_Type = dt.Rows[n]["F_Type"].ToString().Trim();
                    model.F_Title = dt.Rows[n]["F_Title"].ToString().Trim();
                    model.F_Content = dt.Rows[n]["F_Content"].ToString().Trim();
                    model.F_Name = dt.Rows[n]["F_Name"].ToString().Trim();
                    model.F_URL = dt.Rows[n]["F_URL"].ToString().Trim();
                    model.F_CreateUser = Convert.ToInt32(dt.Rows[n]["F_CreateUser"].ToString().Trim());
                    model.F_CreateDate = Convert.ToDateTime(dt.Rows[n]["F_CreateDate"]);

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
    }
}
