using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_PageMessage 的摘要说明。
	/// </summary>
	public class Tunnel_PageMessage
	{
		private readonly Tunnel.DAL.Tunnel_PageMessage dal=new Tunnel.DAL.Tunnel_PageMessage();
        
		public Tunnel_PageMessage()
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
		public bool Exists(int pic_ID)
		{
			return dal.Exists(pic_ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_PageMessage model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_PageMessage model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int pic_ID)
		{
			
			dal.Delete(pic_ID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_PageMessage GetModel(int pic_ID)
		{
			
			return dal.GetModel(pic_ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Tunnel_PageMessage GetModelByCache(int pic_ID)
		{
			
			string CacheKey = "Tunnel_PageMessageModel-" + pic_ID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(pic_ID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_PageMessage)objModel;
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
		public List<Tunnel.Model.Tunnel_PageMessage> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_PageMessage> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_PageMessage> modelList = new List<Tunnel.Model.Tunnel_PageMessage>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_PageMessage model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_PageMessage();
					if(dt.Rows[n]["pic_ID"].ToString()!="")
					{
						model.pic_ID=int.Parse(dt.Rows[n]["pic_ID"].ToString());
					}
					model.pic_AspxName=dt.Rows[n]["pic_AspxName"].ToString();
					model.pic_TitleName=dt.Rows[n]["pic_TitleName"].ToString();
					model.pic_TopicName=dt.Rows[n]["pic_TopicName"].ToString();
					model.pic_TopImgURL=dt.Rows[n]["pic_TopImgURL"].ToString();
					model.pic_BgColor=dt.Rows[n]["pic_BgColor"].ToString();
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

