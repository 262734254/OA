using System;
using System.Collections.Generic;
using System.Text;
using Tunnel.Common;
using Tunnel.Model;
using System.Data;
namespace Tunnel.BLL
{
    public class Tunnel_InfoXJB
    {
        private readonly Tunnel.DAL.Tunnel_InfoXJB dal = new Tunnel.DAL.Tunnel_InfoXJB();
        public Tunnel_InfoXJB()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Tunnel.Model.Tunnel_InfoXJB model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public int Update(Tunnel.Model.Tunnel_InfoXJB model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int id)
		{
			
			return dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Tunnel.Model.Tunnel_InfoXJB GetModel(int id)
		{
			
			return dal.GetModel(id);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Tunnel.Model.Tunnel_InfoXJB> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Tunnel.Model.Tunnel_InfoXJB> DataTableToList(DataTable dt)
		{
            List<Tunnel.Model.Tunnel_InfoXJB> modelList = new List<Tunnel.Model.Tunnel_InfoXJB>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Tunnel.Model.Tunnel_InfoXJB model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new Tunnel.Model.Tunnel_InfoXJB();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["typeId"].ToString()!="")
					{
						model.TypeId=int.Parse(dt.Rows[n]["typeId"].ToString());
					}
					model.Title=dt.Rows[n]["title"].ToString();
					model.Content=dt.Rows[n]["content"].ToString();
					model.ImagePaht=dt.Rows[n]["imagePaht"].ToString();
					model.HtmlSource=dt.Rows[n]["htmlSource"].ToString();
					if(dt.Rows[n]["setDate"].ToString()!="")
					{
						model.SetDate=Convert.ToDateTime(dt.Rows[n]["setDate"].ToString());
					}
					if(dt.Rows[n]["userId"].ToString()!="")
					{
						model.UserId=int.Parse(dt.Rows[n]["userId"].ToString());
					}
                    if (dt.Rows[n]["modiDate"].ToString() != "")
                    {
                        model.ModiDate = Convert.ToDateTime(dt.Rows[n]["modiDate"].ToString());
                    }
                    if (dt.Rows[n]["modiUser"].ToString() != "")
                    {
                        model.ModiUser = int.Parse(dt.Rows[n]["modiUser"].ToString());
                    }
                    if (dt.Rows[n]["delDate"].ToString() != "")
                    {
                        model.DelDate = Convert.ToDateTime(dt.Rows[n]["delDate"].ToString());
                    }
                    if (dt.Rows[n]["delUser"].ToString() != "")
                    {
                        model.DelUser = int.Parse(dt.Rows[n]["DelUser"].ToString());
                    }
					model.Files=dt.Rows[n]["files"].ToString();
                    model.Sectype = Convert.ToInt32(dt.Rows[n]["sectype"]);
                    model.Filename = dt.Rows[n]["filename"].ToString();
					modelList.Add(model);
				}
			}
            return (List<Tunnel.Model.Tunnel_InfoXJB>)modelList;
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}


        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总数</param>
        /// <returns></returns>
        public void GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="pb">分页基本信息</param>
        /// <param name="count">返回总数</param>
        /// <returns></returns>
        public List<Tunnel.Model.Tunnel_InfoXJB> GetList3(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList2(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_InfoXJB> modelList = new List<Tunnel.Model.Tunnel_InfoXJB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_InfoXJB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_InfoXJB();
                    model.Id = Convert.ToInt32(dt.Rows[n]["id"].ToString());
                    model.TypeId = int.Parse(dt.Rows[n]["typeId"].ToString());
                    if (dt.Rows[n]["setDate"].ToString() != "")
                    {
                        model.SetDate = Convert.ToDateTime(dt.Rows[n]["setDate"].ToString());
                    }
                    if (dt.Rows[n]["userId"].ToString() != "")
                    {
                        model.UserId = int.Parse(dt.Rows[n]["userId"].ToString());
                    }
                    if (dt.Rows[n]["modiDate"].ToString() != "")
                    {
                        model.ModiDate = Convert.ToDateTime(dt.Rows[n]["modiDate"].ToString());
                    }
                    if (dt.Rows[n]["modiUser"].ToString() != "")
                    {
                        model.ModiUser = int.Parse(dt.Rows[n]["modiUser"].ToString());
                    }
                    if (dt.Rows[n]["delDate"].ToString() != "")
                    {
                        model.DelDate = Convert.ToDateTime(dt.Rows[n]["delDate"].ToString());
                    }
                    if (dt.Rows[n]["delUser"].ToString() != "")
                    {
                        model.DelUser = int.Parse(dt.Rows[n]["DelUser"].ToString());
                    }
                    model.Title = dt.Rows[n]["title"].ToString();
                    model.Content = dt.Rows[n]["content"].ToString();
                    model.ImagePaht = dt.Rows[n]["ImagePaht"].ToString();
                    model.HtmlSource = dt.Rows[n]["HtmlSource"].ToString();
                    model.Sectype = Convert.ToInt32(dt.Rows[n]["sectype"]);
                    model.Filename = dt.Rows[n]["filename"].ToString();
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
                    model.ObjId = Convert.ToInt32(dt.Rows[n]["objId"].ToString());
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
        /// 增加一条数据
        /// </summary>
        public int Add(Tunnel.Model.Tunnel_viewTable model)
        {
            return dal.Add(model);
        }
		#endregion  成员方法
    }
}
