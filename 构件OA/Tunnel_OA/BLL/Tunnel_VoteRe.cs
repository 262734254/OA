using System;
using System.Data;
using System.Collections.Generic;
using Tunnel.Model;
namespace Tunnel.BLL
{
	/// <summary>
	/// 业务逻辑类Tunnel_VoteRe 的摘要说明。
	/// </summary>
	public class Tunnel_VoteRe
	{
		private readonly Tunnel.DAL.Tunnel_VoteRe dal=new Tunnel.DAL.Tunnel_VoteRe();
		public Tunnel_VoteRe()
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
		public bool Exists(int vote_Id)
		{
			return dal.Exists(vote_Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Tunnel.Model.Tunnel_VoteRe model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Tunnel.Model.Tunnel_VoteRe model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int vote_Id)
		{
			
			dal.Delete(vote_Id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tunnel.Model.Tunnel_VoteRe GetModel(int vote_Id)
		{
			
			return dal.GetModel(vote_Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Tunnel.Model.Tunnel_VoteRe GetModelByCache(int vote_Id)
		{
			
			string CacheKey = "Tunnel_VoteReModel-" + vote_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(vote_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Tunnel.Model.Tunnel_VoteRe)objModel;
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
		public List<Tunnel.Model.Tunnel_VoteRe> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Tunnel.Model.Tunnel_VoteRe> DataTableToList(DataTable dt)
		{
			List<Tunnel.Model.Tunnel_VoteRe> modelList = new List<Tunnel.Model.Tunnel_VoteRe>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Tunnel.Model.Tunnel_VoteRe model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Tunnel.Model.Tunnel_VoteRe();
					if(dt.Rows[n]["vote_Id"].ToString()!="")
					{
						model.vote_Id=int.Parse(dt.Rows[n]["vote_Id"].ToString());
					}
					model.vote_Message=dt.Rows[n]["vote_Message"].ToString();
					if(dt.Rows[n]["vate_Date"].ToString()!="")
					{
						model.vate_Date=DateTime.Parse(dt.Rows[n]["vate_Date"].ToString());
					}
					if(dt.Rows[n]["vate_userId"].ToString()!="")
					{
						model.vate_userId=int.Parse(dt.Rows[n]["vate_userId"].ToString());
					}
					if(dt.Rows[n]["vate_voteId"].ToString()!="")
					{
						model.vate_voteId=int.Parse(dt.Rows[n]["vate_voteId"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

        public List<Tunnel.Model.Tunnel_VoteRe> GetList(PageBase pb, ref int count)
        {
            DataTable dt = dal.GetList(pb, ref count).Tables[0];
            List<Tunnel.Model.Tunnel_VoteRe> modelList = new List<Tunnel.Model.Tunnel_VoteRe>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0 && pb.DoCount == 0)
            {
                Tunnel.Model.Tunnel_VoteRe model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Tunnel.Model.Tunnel_VoteRe();
                    if (dt.Rows[n]["vote_Id"].ToString() != "")
                    {
                        model.vote_Id = int.Parse(dt.Rows[n]["vote_Id"].ToString());
                    }
                    model.vote_Message = dt.Rows[n]["vote_Message"].ToString();
                    if (dt.Rows[n]["vate_Date"].ToString() != "")
                    {
                        model.vate_Date = DateTime.Parse(dt.Rows[n]["vate_Date"].ToString());
                    }
                    if (dt.Rows[n]["vate_userId"].ToString() != "")
                    {
                        model.vate_userId = int.Parse(dt.Rows[n]["vate_userId"].ToString());
                    }
                    if (dt.Rows[n]["vate_voteId"].ToString() != "")
                    {
                        model.vate_voteId = int.Parse(dt.Rows[n]["vate_voteId"].ToString());
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

