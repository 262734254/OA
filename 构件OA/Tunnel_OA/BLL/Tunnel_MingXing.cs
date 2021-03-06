using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_MingXing 的摘要说明。
	/// </summary>
	public class Tunnel_MingXing
	{
		private readonly Tunnel.DAL.Tunnel_MingXing dal=new Tunnel.DAL.Tunnel_MingXing();
		public Tunnel_MingXing()
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
		public bool Exists(int m_id)
		{
			return dal.Exists(m_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_MingXing model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_MingXing model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int m_id)
		{
			
			dal.Delete(m_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_MingXing GetModel(int m_id)
		{
			
			return dal.GetModel(m_id);
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
		public List<Tunnel.Model.Tunnel_MingXing> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        public List<Tunnel.Model.Tunnel_MingXing> GetModelMingXIng(string strWhere)
        {
            DataSet ds = dal.GetListMingXing(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_MingXing> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_MingXing> modelList = new List<Tunnel.Model.Tunnel_MingXing>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_MingXing model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_MingXing();
					if(dt.Rows[n]["m_id"].ToString()!="")
					{
						model.m_id=int.Parse(dt.Rows[n]["m_id"].ToString());
					}
					if(dt.Rows[n]["m_uid"].ToString()!="")
					{
						model.m_uid=int.Parse(dt.Rows[n]["m_uid"].ToString());
					}
					model.m_img=dt.Rows[n]["m_img"].ToString();
					model.m_content=dt.Rows[n]["m_content"].ToString();
                    model.Title = dt.Rows[n]["m_title"].ToString();
					if(dt.Rows[n]["m_year"].ToString()!="")
					{
						model.m_year=int.Parse(dt.Rows[n]["m_year"].ToString());
					}
					if(dt.Rows[n]["m_moon"].ToString()!="")
					{
						model.m_moon=int.Parse(dt.Rows[n]["m_moon"].ToString());
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

