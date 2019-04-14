using System;
using System.Collections.Generic;
using System.Text;
using Tunnel.Common;
using Tunnel.Model;

namespace Tunnel.BLL
{
    public class Tunnel_ModelType
    {
        public Tunnel_ModelType() { }
        private readonly Tunnel.DAL.Tunnel_ModelType report = new Tunnel.DAL.Tunnel_ModelType();
   
        
        /// <summary>
        /// 新增模块分类
        /// </summary>
        /// <returns></returns>
        public int AddReport(Tunnel.Model.Tunnel_ModelType r)
        {
            return report.AddReport(r);
        }
        /// <summary>
        /// 根据模板ID得到模板对象
        /// </summary>
        /// <returns></returns>
        public Tunnel.Model.Tunnel_ModelType GetReportById(int id)
        {
            return report.GetReportById(id);
        }
        /// <summary>
        /// 获取所有父模块
        /// </summary>
        /// <returns></returns>
        public IList<Tunnel.Model.Tunnel_ModelType> GetAllParent()
        {
            return report.GetAllParent();
        }
        /// <summary>
        /// 根据父模块获取所有子模块
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IList<Tunnel.Model.Tunnel_ModelType> GetAllNode(int parentId)
        {
            return report.GetAllNode(parentId);
        }
    }
}
