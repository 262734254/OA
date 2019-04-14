using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Vote_Config 的摘要说明。
	/// </summary>
	public class Vote_Config
	{
		private readonly Tunnel.DAL.Vote_Config dal=new Tunnel.DAL.Vote_Config();
		public Vote_Config()
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
		public bool Exists(int c_id)
		{
			return dal.Exists(c_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Tunnel.Model.Vote_Config model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Vote_Config model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int c_id)
		{
			
			dal.Delete(c_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Vote_Config GetModel(int c_id)
		{
			
			return dal.GetModel(c_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Vote_Config GetModelByCache(int c_id)
		{
			
			string CacheKey = "Vote_ConfigModel-" + c_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(c_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Vote_Config)objModel;
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
		public List<Tunnel.Model.Vote_Config> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Vote_Config> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Vote_Config> modelList = new List<Tunnel.Model.Vote_Config>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Vote_Config model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Vote_Config();
					if(dt.Rows[n]["c_id"].ToString()!="")
					{
						model.c_id=int.Parse(dt.Rows[n]["c_id"].ToString());
					}
					model.c_name=dt.Rows[n]["c_name"].ToString();
					if(dt.Rows[n]["c_type"].ToString()!="")
					{
						model.c_type=int.Parse(dt.Rows[n]["c_type"].ToString());
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

