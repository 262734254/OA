using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Date_Sys 的摘要说明。
	/// </summary>
	public class Date_Sys
	{
		private readonly Tunnel.DAL.Date_Sys dal=new Tunnel.DAL.Date_Sys();
		public Date_Sys()
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
		public bool Exists(int d_Id)
		{
			return dal.Exists(d_Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Tunnel.Model.Date_Sys model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Date_Sys model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int d_Id)
		{
			
			dal.Delete(d_Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Date_Sys GetModel(int d_Id)
		{
			
			return dal.GetModel(d_Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Date_Sys GetModelByCache(int d_Id)
		{
			
			string CacheKey = "Date_SysModel-" + d_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(d_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Date_Sys)objModel;
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
		public List<Tunnel.Model.Date_Sys> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Date_Sys> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Date_Sys> modelList = new List<Tunnel.Model.Date_Sys>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Date_Sys model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Date_Sys();
					if(dt.Rows[n]["d_Id"].ToString()!="")
					{
						model.d_Id=int.Parse(dt.Rows[n]["d_Id"].ToString());
					}
					if(dt.Rows[n]["d_userId"].ToString()!="")
					{
						model.d_userId=int.Parse(dt.Rows[n]["d_userId"].ToString());
					}
					if(dt.Rows[n]["d_beginPoll_Date"].ToString()!="")
					{
						model.d_beginPoll_Date=DateTime.Parse(dt.Rows[n]["d_beginPoll_Date"].ToString());
					}
					if(dt.Rows[n]["d_endPoll_Date"].ToString()!="")
					{
						model.d_endPoll_Date=DateTime.Parse(dt.Rows[n]["d_endPoll_Date"].ToString());
					}
					if(dt.Rows[n]["d_proce_Date"].ToString()!="")
					{
						model.d_proce_Date=DateTime.Parse(dt.Rows[n]["d_proce_Date"].ToString());
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

