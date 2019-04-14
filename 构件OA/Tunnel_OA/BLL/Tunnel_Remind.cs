using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_Remind 的摘要说明。
	/// </summary>
	public class Tunnel_Remind
	{
		private readonly Tunnel.DAL.Tunnel_Remind dal=new Tunnel.DAL.Tunnel_Remind();
		public Tunnel_Remind()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long m_id)
		{
			return dal.Exists(m_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(Tunnel.Model.Tunnel_Remind model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_Remind model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long m_id)
		{
			
			dal.Delete(m_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_Remind GetModel(long m_id)
		{
			
			return dal.GetModel(m_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Tunnel_Remind GetModelByCache(long m_id)
		{
			
			string CacheKey = "Tunnel_RemindModel-" + m_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(m_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_Remind)objModel;
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
		public List<Tunnel.Model.Tunnel_Remind> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_Remind> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_Remind> modelList = new List<Tunnel.Model.Tunnel_Remind>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_Remind model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_Remind();
                    if (dt.Rows[n]["m_id"].ToString() != "")
                    {
                        model.m_id = long.Parse(dt.Rows[n]["m_id"].ToString());
                    }
					model.m_title=dt.Rows[n]["m_title"].ToString();
					model.m_url=dt.Rows[n]["m_url"].ToString();
					//model.m_touser=dt.Rows[n]["m_touser"].ToString();
					if(dt.Rows[n]["m_time"].ToString()!="")
					{
						model.m_time=DateTime.Parse(dt.Rows[n]["m_time"].ToString());
					}
					if(dt.Rows[n]["m_isread"].ToString()!="")
					{
						model.m_isread=int.Parse(dt.Rows[n]["m_isread"].ToString());
					}
					if(dt.Rows[n]["m_callTime"].ToString()!="")
					{
						model.m_callTime=DateTime.Parse(dt.Rows[n]["m_callTime"].ToString());
					}
					if(dt.Rows[n]["m_type"].ToString()!="")
					{
						model.m_type=int.Parse(dt.Rows[n]["m_type"].ToString());
					}
					if(dt.Rows[n]["m_typeid"].ToString()!="")
					{
						model.m_typeid=int.Parse(dt.Rows[n]["m_typeid"].ToString());
					}
                    if (dt.Rows[n]["m_bid"].ToString() != "")
                    {
                        model.m_bid = int.Parse(dt.Rows[n]["m_bid"].ToString());
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

