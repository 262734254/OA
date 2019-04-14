using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_work 的摘要说明。
	/// </summary>
	public class Tunnel_work
	{
		private readonly Tunnel.DAL.Tunnel_work dal=new Tunnel.DAL.Tunnel_work();
		public Tunnel_work()
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
		public bool Exists(int w_id)
		{
			return dal.Exists(w_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_work model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_work model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int w_id)
		{
			
			dal.Delete(w_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_work GetModel(int w_id)
		{
			
			return dal.GetModel(w_id);
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
		public List<Tunnel.Model.Tunnel_work> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_work> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_work> modelList = new List<Tunnel.Model.Tunnel_work>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_work model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_work();
					if(dt.Rows[n]["w_id"].ToString()!="")
					{
						model.w_id=int.Parse(dt.Rows[n]["w_id"].ToString());
					}
					model.w_bumName=dt.Rows[n]["w_bumName"].ToString();
					if(dt.Rows[n]["w_maxCent"].ToString()!="")
					{
						model.w_maxCent=int.Parse(dt.Rows[n]["w_maxCent"].ToString());
					}
					model.w_workName=dt.Rows[n]["w_workName"].ToString();
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

