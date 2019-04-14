using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_weekplan 的摘要说明。
	/// </summary>
	public class Tunnel_weekplan
	{
		private readonly Tunnel.DAL.Tunnel_weekplan dal=new Tunnel.DAL.Tunnel_weekplan();
		public Tunnel_weekplan()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string week_id)
		{
            return dal.Exists(week_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_weekplan model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_weekplan model)
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
		public Tunnel.Model.Tunnel_weekplan GetModel(long w_id)
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
		public List<Tunnel.Model.Tunnel_weekplan> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_weekplan> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_weekplan> modelList = new List<Tunnel.Model.Tunnel_weekplan>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_weekplan model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_weekplan();
					//model.w_id=dt.Rows[n]["w_id"].ToString();
					model.w_title=dt.Rows[n]["w_title"].ToString();
					model.w_content=dt.Rows[n]["w_content"].ToString();
					model.w_address=dt.Rows[n]["w_address"].ToString();
					model.w_time=dt.Rows[n]["w_time"].ToString();
					model.w_daytime=dt.Rows[n]["w_daytime"].ToString();
					if(dt.Rows[n]["w_adddate"].ToString()!="")
					{
						model.w_adddate=DateTime.Parse(dt.Rows[n]["w_adddate"].ToString());
					}
					//model.w_weekID=dt.Rows[n]["w_weekID"].ToString();
					model.w_date=dt.Rows[n]["w_date"].ToString();
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

