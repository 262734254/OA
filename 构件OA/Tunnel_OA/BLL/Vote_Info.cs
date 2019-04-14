using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Vote_Info 的摘要说明。
	/// </summary>
	public class Vote_Info
	{
		private readonly Tunnel.DAL.Vote_Info dal=new Tunnel.DAL.Vote_Info();
		public Vote_Info()
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
		public bool Exists(int v_id)
		{
			return dal.Exists(v_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Vote_Info model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Vote_Info model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int v_id)
		{
			
			dal.Delete(v_id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Vote_Info GetModel(int v_id)
		{
			
			return dal.GetModel(v_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Vote_Info GetModelByCache(int v_id)
		{
			
			string CacheKey = "Vote_InfoModel-" + v_id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(v_id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Vote_Info)objModel;
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
		public List<Tunnel.Model.Vote_Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Vote_Info> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Vote_Info> modelList = new List<Tunnel.Model.Vote_Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Vote_Info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Vote_Info();
					if(dt.Rows[n]["v_id"].ToString()!="")
					{
						model.v_id=int.Parse(dt.Rows[n]["v_id"].ToString());
					}
					model.v_title=dt.Rows[n]["v_title"].ToString();
					if(dt.Rows[n]["v_count"].ToString()!="")
					{
						model.v_count=int.Parse(dt.Rows[n]["v_count"].ToString());
					}
					model.v_Img=dt.Rows[n]["v_Img"].ToString();
					model.v_author=dt.Rows[n]["v_author"].ToString();
					model.v_remark=dt.Rows[n]["v_remark"].ToString();
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

        /// <summary>
        /// 获取上下图片编号和标题
        /// </summary>
        /// <param name="vid">图片编号</param>
        /// <param name="otopid">上一张图片编号</param>
        /// <param name="odownid">下一张图片编号</param>
        /// <param name="toptitle">上一张图片标题</param>
        /// <param name="downtitle">下一张图片标题</param>
        public void GetTopDown(int vid, out int otopid, out int odownid, out string toptitle, out string downtitle)
        {
            dal.GetTopDown(vid, out otopid, out odownid, out toptitle, out downtitle);
        }
        /// <summary>
        /// 评论分页查询
        /// </summary>
        /// <param name="vateid">编号</param>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">当前页码</param>
        /// <param name="outvalue">总共页数</param>
        /// <returns></returns>
        public DataTable SelectListPage(int vateid, int pagesize, int pageindex, out int outvalue)
        {
            return dal.SelectListPage(vateid, pagesize, pageindex, out outvalue);
        }
        /// <summary>
        /// 图片分页查询
        /// </summary>
        /// <param name="pagesize">每页数量</param>
        /// <param name="pageindex">当前页码</param>
        /// <param name="outvalue">总共页数</param>
        /// <returns></returns>
        public DataTable SelectImgList(int pagesize, int pageindex, out int outvalue)
        {
            return dal.SelectImgList(pagesize, pageindex, out outvalue);
        }
		#endregion  成员方法
	}
}

